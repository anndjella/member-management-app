using Klijent.UserKontrole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko;
using Zajednicko.Komunikacija;

namespace Klijent.GUIKontroler
{
    public class DodajClanaKontroler
    {
        private FrmDodajClana frmDodajClana;
        public event EventHandler ClanDodat;
        private bool dobarEmail = true;
        private bool dobarBroj = true;
        private Clan clan=new Clan();   
        List<Clan> clanovi;
        private static DodajClanaKontroler instance;
        public static DodajClanaKontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DodajClanaKontroler();
                }
                return instance;
            }
        }
        private DodajClanaKontroler()
        {
        }
        private void VratiBojuCmbPolju(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb.SelectedIndex != -1)
            {
                cmb.BackColor = Color.White;
            }
        }

        private void DodajClana(object sender, EventArgs e)
        {
           // MessageBox.Show("Sistem ne može da učita člana.");
            frmDodajClana.BtnDodajClana.Visible = true;
            frmDodajClana.BtnSacuvajIzmene.Visible = false;
            frmDodajClana.BtnObrisi.Visible = false;
            if (!ValidacijaPopunjenog())
{
    MessageBox.Show("Please fill in all fields!");
}
else if (!dobarBroj & !dobarEmail)
{
    MessageBox.Show("Invalid phone number, and email must contain at least one '@' and one '.'");
}
else if (!dobarEmail && dobarBroj)
{
    MessageBox.Show("Email must contain at least one '@' and one '.'!");
}
else if (dobarEmail && !dobarBroj)
{
    MessageBox.Show("Phone number must follow the format starting with 06..!");
}
else if (clanovi.Any(clan => clan.Email == frmDodajClana.TxtEmail.Text))
{
    MessageBox.Show("A user with this email address already exists!");
}
else if (clanovi.Any(clan => clan.BrojTelefona == frmDodajClana.TxtBrTel.Text))
{
    MessageBox.Show("A user with this phone number already exists!");
}

            else
            {
                Clan clan1 = new Clan();
                clan1.Ime = frmDodajClana.TxtIme.Text;
                clan1.Prezime = frmDodajClana.TxtPrezime.Text;
                clan1.BrojTelefona = frmDodajClana.TxtBrTel.Text;
                clan1.Email = frmDodajClana.TxtEmail.Text;
                clan1.Kategorija = new Kategorija();
                clan1.Kategorija.Id = frmDodajClana.CmbKateg.SelectedIndex + 1;
                Odgovor odg = Komunikacija.Instance.IzvrsiFju(Operacija.ZapamtiClana, clan1);
                if (odg.Exception == null)
                {
                    MessageBox.Show("The system has saved the member.");
                    ClanDodat?.Invoke(this, EventArgs.Empty);
                    frmDodajClana.Close();
                }
                else
                {
                    MessageBox.Show("The system cannot save the member.");
                }
            }
        }
        private void VratiBojuPolju(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            if (tBox != null)
            {
                tBox.BackColor = Color.White;
            }
        }
        internal void ZameniPlejsholder(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            if (tBox != null)
            {
                tBox.ForeColor = Color.Black;
                tBox.Text = "";
            }
        }
        internal void PrikaziFormuDodajClana(object sender, EventArgs e)
        {
            if (frmDodajClana == null || frmDodajClana.IsDisposed)
            {
                frmDodajClana = new FrmDodajClana();
                List<Kategorija> kategorije = (List<Kategorija>)Komunikacija.Instance.IzvrsiFju(Operacija.VratiSveKategorije).Rezultat;
                clanovi = (List<Clan>)Komunikacija.Instance.IzvrsiFju(Operacija.VratiSveClanove).Rezultat;
                frmDodajClana.CmbKateg.DataSource = new BindingList<Kategorija>(kategorije);
                frmDodajClana.CmbKateg.SelectedIndex = -1;
                frmDodajClana.TxtBrTel.Click += ZameniPlejsholder;
                frmDodajClana.BtnObrisi.Visible = false;
                frmDodajClana.BtnDodajClana.Visible = true;
                frmDodajClana.BtnSacuvajIzmene.Visible = false;
                frmDodajClana.BtnDodajClana.Click += DodajClana;
                frmDodajClana.TxtIme.TextChanged += VratiBojuPolju;
                frmDodajClana.TxtPrezime.TextChanged += VratiBojuPolju;
                frmDodajClana.TxtBrTel.TextChanged += VratiBojuPolju;
                frmDodajClana.TxtEmail.TextChanged += VratiBojuPolju;
                frmDodajClana.CmbKateg.SelectedIndexChanged += VratiBojuCmbPolju;
                frmDodajClana.FormClosed += (s, ev) => { frmDodajClana = null; };
                frmDodajClana.ShowDialog();
            }
            else
            {
                frmDodajClana.BringToFront();
            }
        }
        private bool ValidacijaPopunjenog()
        {
            bool sveUneto = true;
            if (!frmDodajClana.TxtBrTel.Text.All(char.IsDigit) || !frmDodajClana.TxtBrTel.Text.StartsWith("06"))
            {
                dobarBroj = false;
            }
            else
            {
                dobarBroj = true;
            }
            if (!frmDodajClana.TxtEmail.Text.Contains('@') || !frmDodajClana.TxtEmail.Text.Contains('.'))
            {
                dobarEmail = false;
            }
            else
            {
                dobarEmail = true;
            }
            foreach (Control c in frmDodajClana.Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty(c.Text) || c.Text.Equals("e.g. 069 4000 122"))
                    {
                        c.BackColor = Color.Red;
                        sveUneto = false;
                    }
                }
            }
            if (frmDodajClana.CmbKateg.SelectedIndex == -1)
            {
                sveUneto = false;
                frmDodajClana.CmbKateg.BackColor = Color.Red;
            }
            return sveUneto;
        }

        internal void PrikaziDetaljeOClanu(Clan clan)
        {
            if (frmDodajClana == null || frmDodajClana.IsDisposed)
            {
                frmDodajClana = new FrmDodajClana();
                List<Kategorija> kategorije = (List<Kategorija>)Komunikacija.Instance.IzvrsiFju(Operacija.VratiSveKategorije).Rezultat;
                clanovi = (List<Clan>)Komunikacija.Instance.IzvrsiFju(Operacija.VratiSveClanove).Rezultat;
                frmDodajClana.CmbKateg.DataSource = new BindingList<Kategorija>(kategorije);
                frmDodajClana.TxtBrTel.Click += ZameniPlejsholder;
                
                frmDodajClana.TxtIme.TextChanged += VratiBojuPolju;
                frmDodajClana.TxtPrezime.TextChanged += VratiBojuPolju;
                frmDodajClana.TxtBrTel.TextChanged += VratiBojuPolju;
                frmDodajClana.TxtEmail.TextChanged += VratiBojuPolju;
                frmDodajClana.CmbKateg.SelectedIndexChanged += VratiBojuCmbPolju;

                this.clan = clan;
                frmDodajClana.BtnDodajClana.Visible = false;
                frmDodajClana.BtnObrisi.Visible = false;    
                frmDodajClana.BtnSacuvajIzmene.Visible = true;
                frmDodajClana.BtnSacuvajIzmene.Click +=(m,e)=> { SacuvajIzmeneClana(clan); };
                frmDodajClana.TxtBrTel.Text = clan.BrojTelefona;
                frmDodajClana.TxtEmail.Text = clan.Email;
                frmDodajClana.TxtIme.Text = clan.Ime;
                frmDodajClana.TxtPrezime.Text = clan.Prezime;
                frmDodajClana.CmbKateg.SelectedIndex = clan.Kategorija.Id - 1;
                frmDodajClana.Text = $"User datails: {clan.Ime} {clan.Prezime}";
                frmDodajClana.FormClosed += (s, ev) => { frmDodajClana = null; };             
                frmDodajClana.ShowDialog();
                 //MessageBox.Show("Sistem je učitao člana.");

            }
            else
            {
                frmDodajClana.BringToFront();
            };
        }

        private void SacuvajIzmeneClana(Clan clan)
        {
            frmDodajClana.BtnDodajClana.Visible = false;
            frmDodajClana.BtnSacuvajIzmene.Visible = true;
            frmDodajClana.BtnObrisi.Visible = false;
            if (!ValidacijaPopunjenog())
            {
                MessageBox.Show("Please fill in all fields!");
            }
            else if (!dobarBroj && !dobarEmail)
            {
                MessageBox.Show("Invalid phone number and email must contain at least one '@' and one '.'");
            }
            else if (!dobarEmail && dobarBroj)
            {
                MessageBox.Show("Email must contain at least one '@' and one '.'!");
            }
            else if (dobarEmail && !dobarBroj)
            {
                MessageBox.Show("Phone number must be in the format starting with 06..!");
            }
            else if (clanovi.Any(cla => cla.Email == frmDodajClana.TxtEmail.Text && cla.IdClana != clan.IdClana))
            {
                MessageBox.Show("A user with this email address already exists!");
            }
            else if (clanovi.Any(cla => cla.BrojTelefona == frmDodajClana.TxtBrTel.Text && cla.IdClana != clan.IdClana))
            {
                MessageBox.Show("A user with this phone number already exists!");
            }
            else
            {
                Clan clan2 = new Clan();
                clan2.IdClana = clan.IdClana;
                clan2.Ime = frmDodajClana.TxtIme.Text;
                clan2.Prezime = frmDodajClana.TxtPrezime.Text;
                clan2.BrojTelefona = frmDodajClana.TxtBrTel.Text;
                clan2.Email = frmDodajClana.TxtEmail.Text;
                clan2.Kategorija = new Kategorija();
                clan2.Kategorija.Id = frmDodajClana.CmbKateg.SelectedIndex + 1;
                Odgovor odg = Komunikacija.Instance.IzvrsiFju(Operacija.IzmeniClana, clan2);
                if (odg.Exception == null)
                {
                    MessageBox.Show("The system has saved the member.");
                    ClanDodat?.Invoke(this, EventArgs.Empty);
                    frmDodajClana.Close();
                }
                else
                {
                    MessageBox.Show("The system cannot save the member");
                }
            }
        }

        internal void PrikaziDetaljeOClanuBrisanje(Clan clan)
        {
            if (frmDodajClana == null || frmDodajClana.IsDisposed)
            {
                frmDodajClana = new FrmDodajClana();
                List<Kategorija> kategorije = (List<Kategorija>)Komunikacija.Instance.IzvrsiFju(Operacija.VratiSveKategorije).Rezultat;
                clanovi = (List<Clan>)Komunikacija.Instance.IzvrsiFju(Operacija.VratiSveClanove).Rezultat;
                frmDodajClana.CmbKateg.DataSource = new BindingList<Kategorija>(kategorije);              

                this.clan = clan;
                frmDodajClana.BtnDodajClana.Visible = false;
                frmDodajClana.BtnObrisi.Visible = true;
                frmDodajClana.BtnSacuvajIzmene.Visible = false;
                frmDodajClana.BtnObrisi.Click += (m, e) => { ObrisiClana(clan); };
                frmDodajClana.TxtBrTel.Text = clan.BrojTelefona;
                frmDodajClana.TxtEmail.Text = clan.Email;
                frmDodajClana.TxtIme.Text = clan.Ime;
                frmDodajClana.TxtPrezime.Text = clan.Prezime;
                frmDodajClana.CmbKateg.SelectedIndex = clan.Kategorija.Id - 1;

                frmDodajClana.TxtBrTel.Enabled=false ;
                frmDodajClana.TxtEmail.Enabled =false;
                frmDodajClana.TxtIme.Enabled = false;
                frmDodajClana.TxtPrezime.Enabled = false;
                frmDodajClana.CmbKateg.Enabled= false;
                frmDodajClana.Text = $"User details: {clan.Ime} {clan.Prezime}";
                frmDodajClana.FormClosed += (s, ev) => { frmDodajClana = null; };
                frmDodajClana.ShowDialog();
                

            }
            else
            {
                frmDodajClana.BringToFront();
            };
        }

        private void ObrisiClana(Clan clan)
        {
            frmDodajClana.BtnDodajClana.Visible = false;
            frmDodajClana.BtnSacuvajIzmene.Visible = false;
            frmDodajClana.BtnObrisi.Visible = false;
            Odgovor odg=Komunikacija.Instance.IzvrsiFju(Operacija.IzbrisiClana,clan);
            if (odg.Exception == null)
            {
                MessageBox.Show("The system has deleted the member.");
            }
            else
            {
                MessageBox.Show("The system cannot delete the member.");
            }

        }
    }
}
