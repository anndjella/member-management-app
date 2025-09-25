using System;
using System.Collections.Generic;
using System.Drawing;
using Moq;
using Xunit;
using Klijent.GUIKontroler;
using Klijent.Abstractions;
using Zajednicko;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;
using Xunit;

public class LoginTests
{
    private readonly Mock<IAppGateway> _gw = new Mock<IAppGateway>();
    private readonly Mock<ISystemServices> _sys = new Mock<ISystemServices>();

    private LoginGUIKontroler CreateCtrl(Klijent.FrmLogin form)
        => new LoginGUIKontroler(_gw.Object, _sys.Object,form);


    [StaFact]
    public void Validacija_WhenBothAreEmpty_ReturnsFalse_And_ColorsBoth()
    {
        var form = new Klijent.FrmLogin();
        form.TxtEmail.Text = "";
        form.TxtLozinka.Text = "";

        var ctrl = CreateCtrl(form);

        var ok = ctrl.Validacija();

        Assert.False(ok);
        _sys.Verify(s => s.Info("Please enter email and password!"), Times.Once);
        Assert.Equal(Color.Red, form.TxtEmail.BackColor);
        Assert.Equal(Color.Red, form.TxtLozinka.BackColor);
    }

    [StaFact]
    
    public void Validacija_EmptyEmail_ReturnsFalse_And_ColorsEmail()
    {
        var form = new Klijent.FrmLogin();
        form.TxtEmail.Text = "";
        form.TxtLozinka.Text = "x";

        var ctrl = CreateCtrl(form);

        var ok = ctrl.Validacija();

        Assert.False(ok);
        _sys.Verify(s => s.Info("Please enter email!"), Times.Once);
        Assert.Equal(Color.Red, form.TxtEmail.BackColor);
    }

    [StaFact]
    public void Validacija_EmptyPassword_ReturnsFalse_And_ColorsPassword()
    {
        var form = new Klijent.FrmLogin();
        form.TxtEmail.Text = "a@b.com";
        form.TxtLozinka.Text = "";

        var ctrl = CreateCtrl(form);

        var ok = ctrl.Validacija();

        Assert.False(ok);
        _sys.Verify(s => s.Info("Please enter password!"), Times.Once);
        Assert.Equal(Color.Red, form.TxtLozinka.BackColor);
    }

    [StaFact]
    public void Validacija_FilledIn_ReturnsTrue()
    {
        var form = new Klijent.FrmLogin();
        form.TxtEmail.Text = "a@b.com";
        form.TxtLozinka.Text = "pwd";

        var ctrl = CreateCtrl(form);

        var ok = ctrl.Validacija();

        Assert.True(ok);
        _sys.Verify(s => s.Info(It.IsAny<string>()), Times.Never);
    }

    [StaFact]
    public void Login_BothEmpty_DoesntCallServer()
    {
        var form = new Klijent.FrmLogin();
        form.TxtEmail.Text = "";
        form.TxtLozinka.Text = "";

        var ctrl = CreateCtrl(form);
        ctrl.Login(this, EventArgs.Empty);

        _gw.Verify(g => g.Izvrsi(It.IsAny<Operacija>(), It.IsAny<IEntitet>()), Times.Never);
    }


    [StaFact]
    public void Login_OperatorDoesNotExist_ShowsNotExistsMessage()
    {
        var form = new Klijent.FrmLogin();
        form.TxtEmail.Text = "a@b.com";
        form.TxtLozinka.Text = "pwd";

        _gw.Setup(g => g.Izvrsi(Operacija.Login, It.IsAny<IEntitet>()))
           .Returns(new Odgovor { Rezultat = new List<Operater>() });

        var ctrl = CreateCtrl(form);
        ctrl.Login(this, EventArgs.Empty);

        _sys.Verify(s => s.Info("This operator does not exist in the system!"), Times.Once);
    }

    [StaFact]
    public void Login_Successful_ShowsWelcome_WithoutNavigation()
    {
        var form = new Klijent.FrmLogin();
        form.TxtEmail.Text = "a@b.com";
        form.TxtLozinka.Text = "pwd";

        _gw.Setup(g => g.Izvrsi(Operacija.Login, It.IsAny<IEntitet>()))
           .Returns(new Odgovor
           {
               Rezultat = new List<Operater>
               {
               new Operater { Ime = "Ana", Prezime = "Popovic" }
               }
           });

        var ctrl = CreateCtrl(form);
        ctrl.DisableNavigationForTests = true;
        ctrl.Login(this, EventArgs.Empty);

        _sys.Verify(s => s.Info("Welcome Ana Popovic!"), Times.Once);
    }
}
