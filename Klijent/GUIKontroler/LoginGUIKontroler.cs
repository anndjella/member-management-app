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


namespace Klijent.GUIKontroler
{
    public class LoginGUIKontroler
    {
        private FrmLogin frmLogin;
        private static LoginGUIKontroler instance;
        public static LoginGUIKontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginGUIKontroler();
                }
                return instance;
            }
        }
        private LoginGUIKontroler()
        {
        }
        internal void PrikaziFormu()
        {
            Komunikacija.Instance.PoveziSaServerom();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin = new FrmLogin();
            frmLogin.TxtLozinka.PasswordChar = '*';
            Application.Run(frmLogin);
        }
        internal void Login(object sender, EventArgs e)
        {
            if (Validacija())
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
                Odgovor odgovor =Komunikacija.Instance.IzvrsiFju(Operacija.Login,operater);

                if (((List<Operater>)odgovor.Rezultat).Count ==0)
                {
                    MessageBox.Show("Ovaj operater ne postoji u sistemu!");
                }
                else if(odgovor.Exception!= null)
                {
                    MessageBox.Show(odgovor.Exception.Message.ToString());
                    frmLogin.Close();
                }
                else
                {
                    Operater op=new Operater();
                    op.Ime = ((List<Operater>)odgovor.Rezultat)[0].Ime;
                    op.Prezime = ((List<Operater>)odgovor.Rezultat)[0].Prezime;
                    MessageBox.Show("Dobrodosao/la "+ op.Ime+
                        " "+ op.Prezime+"!");
                    Koordinator.Instance.PrikaziGlavnuFormu(op);
                }
            }
        }
        private bool Validacija()
        {
            if (string.IsNullOrEmpty(frmLogin.TxtEmail.Text) && string.IsNullOrEmpty(frmLogin.TxtLozinka.Text))
            {
                MessageBox.Show("Unesite email i lozinku!");
                frmLogin.TxtEmail.BackColor = Color.Red;
                frmLogin.TxtLozinka.BackColor = Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(frmLogin.TxtEmail.Text))
            {
                MessageBox.Show("Unesite email!");
                frmLogin.TxtEmail.BackColor = Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(frmLogin.TxtLozinka.Text))
            {
                MessageBox.Show("Unesite lozinku!");
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
