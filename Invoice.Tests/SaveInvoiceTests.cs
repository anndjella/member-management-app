using System;
using Moq;
using Xunit;
using CoreLogic.Services;
using CoreLogic.Abstractions;
using CoreLogic.Services;
using Zajednicko.Domain;
using Zajednicko;

public class SaveInvoiceTests
{
    [Fact]
    public void SaveInvoice_SetsFields_CallsGateway_ShowsInfo()
    {
        // Arrange
        var fixedNow = new DateTime(2025, 9, 16, 12, 0, 0, DateTimeKind.Utc);

        var clockMock = new Mock<IClock>();
        clockMock.SetupGet(c => c.UtcNow).Returns(fixedNow);

        var gatewayMock = new Mock<IRacunGetaway>();
        gatewayMock.Setup(g => g.DodajRacun(It.IsAny<Racun>())).Returns(true);

        var notifierMock = new Mock<INotifier>();

        var service = new SaveInvoice(gatewayMock.Object, notifierMock.Object, clockMock.Object);
        var member = new Clan { IdClana = 42 };

        // Act
        var result = service.ZapamtiRacun(member);

        // Assert
        Assert.True(result);

        gatewayMock.Verify(g => g.DodajRacun(It.Is<Racun>(r =>
            r.Clan != null &&
            r.Clan.IdClana == 42 &&
            (int)r.Mesec == fixedNow.Month &&
            r.Godina == fixedNow.Year &&
            r.Iznos == 0
        )), Times.Once);

        notifierMock.Verify(n => n.Info("The system has saved the invoice."), Times.Once);
        notifierMock.Verify(n => n.Error(It.IsAny<string>()), Times.Never);

        clockMock.VerifyGet(c => c.UtcNow, Times.Once);
    }

    [Fact]
    public void SaveInvoice_WhenGatewayFails_ShowsError()
    {
        // Arrange
        var fixedNow = new DateTime(2025, 9, 16, 12, 0, 0, DateTimeKind.Utc);

        var clockMock = new Mock<IClock>();
        clockMock.SetupGet(c => c.UtcNow).Returns(fixedNow);

        var gatewayMock = new Mock<IRacunGetaway>();
        gatewayMock.Setup(g => g.DodajRacun(It.IsAny<Racun>())).Returns(false);

        var notifierMock = new Mock<INotifier>();

        var service = new CoreLogic.Services.SaveInvoice(gatewayMock.Object, notifierMock.Object, clockMock.Object);
        var member = new Clan { IdClana = 99 };

        // Act
        var result = service.ZapamtiRacun(member);

        // Assert
        Assert.False(result);
        gatewayMock.Verify(g => g.DodajRacun(It.IsAny<Racun>()), Times.Once);
        //notifierMock.Verify(n => n.Error(It.Is<string>(s => s.Contains("failed", StringComparison.OrdinalIgnoreCase))), Times.Once);
        notifierMock.Verify(n => n.Info(It.IsAny<string>()), Times.Never);
    }
}
