using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;
using System.Net.Sockets;
using Klijent.Abstractions;
using Klijent.Infra;


namespace Klijent.GUIKontroler
{
    public class LoginGUIKontroler
    {
        private FrmLogin frmLogin;
        private static LoginGUIKontroler instance;

        private readonly IAppGateway _gw;
        private readonly ISystemServices _sys;
        public bool DisableNavigationForTests { get; set; }

        public static LoginGUIKontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    //instance = new LoginGUIKontroler();
                    instance = new LoginGUIKontroler(new DefaultGateway(), new WinFormsSystemServices(),null);

                }
                return instance;
            }
        }
        private LoginGUIKontroler()
        {
        }
        public LoginGUIKontroler(IAppGateway gw, ISystemServices sys, FrmLogin form = null)
        {
            _gw = gw;
            _sys = sys;
            frmLogin = form;
        }
        internal void PrikaziFormu()
        {
            //Komunikacija.Instance.PoveziSaServerom();
            bool uspesnoPovezano = Komunikacija.Instance.PoveziSaServerom();
            if (!uspesnoPovezano)
            {
                MessageBox.Show("Unable to connect to the server. Please start the server and try again.");
                Environment.Exit(0);
                return; 
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin = new FrmLogin();
            frmLogin.TxtLozinka.PasswordChar = '*';
            Application.Run(frmLogin);
        }
        internal void Login(object sender, EventArgs e)
        {
            if (!Validacija())
                return;

            try
            {
                Operater operater = new Operater();
                operater.Email = frmLogin.TxtEmail.Text;
                string loz = frmLogin.TxtLozinka.Text;
                SHA256 sha256 = SHA256.Create();
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(loz));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                operater.Lozinka = builder.ToString();
                //Odgovor odgovor =Komunikacija.Instance.IzvrsiFju(Operacija.Login,operater);
                Odgovor odgovor = _gw.Izvrsi(Operacija.Login, operater);

                if (((List<Operater>)odgovor.Rezultat).Count ==0)
                {
                    //MessageBox.Show("This operator does not exist in the system!");
                    _sys.Info("This operator does not exist in the system!");
                }
                else if(odgovor.Exception!= null)
                {
                    //MessageBox.Show(odgovor.Exception.Message.ToString());
                    _sys.Info(odgovor.Exception.Message);
                    frmLogin.Close();
                }
                else
                {
                    Operater op=new Operater();
                    op.Ime = ((List<Operater>)odgovor.Rezultat)[0].Ime;
                    op.Prezime = ((List<Operater>)odgovor.Rezultat)[0].Prezime;
                    //MessageBox.Show("Welcome "+ op.Ime+
                    //    " "+ op.Prezime+"!");
                    _sys.Info($"Welcome {op.Ime} {op.Prezime}!");

                    if (!DisableNavigationForTests)
                        Koordinator.Instance.PrikaziGlavnuFormu(op);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error!" +ex.Message);
                _sys.Info("Error!" + ex.Message);
            }
        }
        internal bool Validacija()
        {
            if (string.IsNullOrEmpty(frmLogin.TxtEmail.Text) && string.IsNullOrEmpty(frmLogin.TxtLozinka.Text))
            {
                //MessageBox.Show("Please enter email and password!");
                _sys.Info("Please enter email and password!");
                frmLogin.TxtEmail.BackColor = Color.Red;
                frmLogin.TxtLozinka.BackColor = Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(frmLogin.TxtEmail.Text))
            {
                //MessageBox.Show("Please enter email!");
                _sys.Info("Please enter email!");
                frmLogin.TxtEmail.BackColor = Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(frmLogin.TxtLozinka.Text))
            {
                //MessageBox.Show("Please enter password!");
                _sys.Info("Please enter password!");
                frmLogin.TxtLozinka.BackColor = Color.Red;
                return false;
            }
            return true;
        }

        internal void VratiBojuPolju(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            if (sender != null)
            {
                tBox.BackColor = SystemColors.Window;
            }
        }
    }
}
