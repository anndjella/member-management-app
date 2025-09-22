using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Moq;
using Xunit;
using Xunit.Sdk;
using Klijent.GUIKontroler;
using Klijent.Abstractions;
using Zajednicko;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;

public class RacunKontrolerTests
{
    private readonly Mock<ISystemServices> _sys;
    private readonly Mock<IAppGateway> _gw;
    private readonly List<string> _messages;
    private readonly DateTime _fixedNow = new DateTime(2025, 7, 15);

    private static bool ContainsCI(string s, string term) =>
    s?.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

    public RacunKontrolerTests()
    {
        _sys = new Mock<ISystemServices>(MockBehavior.Strict);
        _gw = new Mock<IAppGateway>(MockBehavior.Strict);
        _messages = new List<string>();

        _sys.Setup(s => s.Now()).Returns(_fixedNow);
        _sys.Setup(s => s.Info(It.IsAny<string>()))
            .Callback<string>(m => _messages.Add(m));
    }

    [StaFact]
    public void KreirajRacun_WhenUserCancels_DoesNothing()
    {
        _sys.Setup(s => s.Confirm(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(false);

        var ctrl = new RacunKontroler(_sys.Object, _gw.Object);
        ctrl.Clan = new Clan { IdClana = 123 };

        ctrl.KreirajRacun(null, EventArgs.Empty);

        _gw.Verify(g => g.Izvrsi(It.IsAny<Operacija>(), It.IsAny<IEntitet>()), Times.Never);
        Assert.DoesNotContain(_messages, m => ContainsCI(m, "saved"));
    }

    [StaFact]
    public void KreirajRacun_WhenCurrentMonthExists_ShowsInfoAndDoesNotAdd()
    {
        _sys.Setup(s => s.Confirm(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        var existing = new List<Racun>
        {
            new Racun { Mesec = (Mesec)7, Godina = 2025, Clan = new Clan{ IdClana=123 }, Iznos = 1000 }
        };

        _gw.Setup(g => g.Izvrsi(Operacija.PronadjiRacune, It.IsAny<IEntitet>()))
           .Returns(new Odgovor { Rezultat = existing });

        var ctrl = new RacunKontroler(_sys.Object, _gw.Object);
        ctrl.Clan = new Clan { IdClana = 123 };

        ctrl.KreirajRacun(null, EventArgs.Empty);

        Assert.Contains(_messages, m => ContainsCI(m, "already has"));
        _gw.Verify(g => g.Izvrsi(Operacija.PronadjiRacune, It.IsAny<IEntitet>()), Times.Once);
        _gw.Verify(g => g.Izvrsi(Operacija.DodajRacun, It.IsAny<IEntitet>()), Times.Never);
    }

    [StaFact]
    public void KreirajRacun_WhenNotExists_AddsAndShowsSavedMessage()
    {
        _sys.Setup(s => s.Confirm(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        _gw.Setup(g => g.Izvrsi(Operacija.PronadjiRacune, It.IsAny<IEntitet>()))
           .Returns(new Odgovor { Rezultat = new List<Racun>() }); 

        _gw.Setup(g => g.Izvrsi(Operacija.DodajRacun, It.IsAny<IEntitet>()))
           .Returns(new Odgovor { Exception = null });

        var ctrl = new RacunKontroler(_sys.Object, _gw.Object);
        ctrl.Clan = new Clan { IdClana = 555 };

        ctrl.KreirajRacun(null, EventArgs.Empty);

        Assert.Contains(_messages, m => ContainsCI(m, "saved the invoice"));
       

        _gw.Verify(g => g.Izvrsi(
            Operacija.DodajRacun,
            It.Is<IEntitet>(e =>
                    e is Racun
                    && ((Racun)e).Clan != null
                    && ((Racun)e).Clan.IdClana == 555
                    && (int)((Racun)e).Mesec == 7
                    && ((Racun)e).Godina == 2025
                    && ((Racun)e).Iznos == 0
              )), Times.Once);
    }

    [StaFact]
    public void PretragaRacuna_InvalidInput_ShowsInvalidMessage()
    {
        _sys.Setup(s => s.Confirm(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        var ctrl = new RacunKontroler(_sys.Object, _gw.Object);
        ctrl.SetRacuni(new List<Racun>());

        ctrl.View.TxtUnos.Text = "Jullly"; 
        ctrl.PretragaRacuna(null, EventArgs.Empty);

        Assert.Contains(_messages, m => ContainsCI(m, "Invalid format entered!"));
    }

    [StaFact]
    public void PretragaRacuna_ValidMonth_FiltersGridRows()
    {
        _sys.Setup(s => s.Confirm(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        var july1 = new Racun { Mesec = (Mesec)7, Godina = 2025, Iznos = 100 };
        var july2 = new Racun { Mesec = (Mesec)7, Godina = 2024, Iznos = 200 };
        var aug = new Racun { Mesec = (Mesec)8, Godina = 2025, Iznos = 300 };

        var ctrl = new RacunKontroler(_sys.Object, _gw.Object);
        ctrl.SetRacuni(new List<Racun> { july1, july2, aug });

        ctrl.View.TxtUnos.Text = "July";
        ctrl.PretragaRacuna(null, EventArgs.Empty);

        var grid = ctrl.View.DgvOdlasci;
        var _ = grid.Handle;
        System.Windows.Forms.Application.DoEvents();

        int total = grid.Rows.Count;
        int visible = grid.Rows.Cast<DataGridViewRow>().Count(r => r.Visible);

        Assert.Equal(3, total);
        Assert.Equal(2, visible);
    }
}
