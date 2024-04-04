using Klijent.UserKontrole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.Komunikacija;
using Zajednicko;
using Zajednicko.Domain;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Drawing;

namespace Klijent.GUIKontroler
{
    public class DodajOdlazakKontroler
    {
        private UCDodajDolazak ucDodajOdlazak;
        public Clan Clan { get; set; }
        private static DodajOdlazakKontroler instance;
        public static DodajOdlazakKontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DodajOdlazakKontroler();
                }
                return instance;
            }
        }
        public DodajOdlazakKontroler()
        {
            ucDodajOdlazak = new UCDodajDolazak();
            ucDodajOdlazak.CmbGrPr.DataSource = (List<GrupniProgram>)
                  Komunikacija.Instance.IzvrsiFju(Operacija.VratiSveGrPr).Rezultat;
            ucDodajOdlazak.CmbGrPr.SelectedIndex = -1;
            Clan = ClanoviKontroler.Instance.Clan;
            ucDodajOdlazak.TxtMesec.Text = ((Mesec)DateTime.Now.Month).ToString();
            ucDodajOdlazak.TxtGodina.Text = DateTime.Now.Year.ToString();
            ucDodajOdlazak.TxtDan.Click += RefresujPolje;
            ucDodajOdlazak.CmbGrPr.SelectedIndexChanged += PopuniCenu;
            ucDodajOdlazak.BtnSacuvajDolazak.Click += SacuvajDolazak;
            ucDodajOdlazak.BtnViseDolazaka.Click += DodajVišeOdlazakaKontroler.Instance.PrikaziUC;
        }

        private void RefresujPolje(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            if (tBox != null)
            {
                tBox.ForeColor = Color.Black;
                tBox.Text = "";
            }
        }
        private void PopuniCenu(object sender, EventArgs e)
        {
            GrupniProgram gr = ucDodajOdlazak.CmbGrPr.SelectedItem as GrupniProgram;
            ucDodajOdlazak.TxtCena.Text = gr.CenaJednog.ToString();

        }
        private void SacuvajDolazak(object sender, EventArgs e)
        {
            Racun r = new Racun();
            r.Clan = ClanoviKontroler.Instance.Clan;
            if (r.Clan != null)
            {
                List<Racun> racuniClana = (List<Racun>)Komunikacija.Instance.IzvrsiFju(Operacija.PronadjiRacune, r).Rezultat;
                List<Racun> racuniZaMesecIGod = racuniClana.Where(c => c.Mesec == (Mesec)DateTime.Now.Month &&
                c.Godina == DateTime.Now.Year).ToList();
                if (racuniZaMesecIGod.Count == 0)
                {
                    MessageBox.Show("Ne možete dodati dolaske jer nije kreiran račun!");
                }
                else
                if (ucDodajOdlazak.CmbGrPr.SelectedIndex == -1 && (!ucDodajOdlazak.TxtDan.Text.All(char.IsDigit) || ucDodajOdlazak.TxtDan.Text.Equals("npr \"12\"")
                    || string.IsNullOrEmpty(ucDodajOdlazak.TxtDan.Text)))
                {
                    MessageBox.Show("Unesite dan i izaberite vrstu grupnog treninga!");
                }
                else if (ucDodajOdlazak.CmbGrPr.SelectedIndex == -1)
                {
                    MessageBox.Show("Izaberite vrstu grupnog treninga!");
                }
                else if (!ucDodajOdlazak.TxtDan.Text.All(char.IsDigit) || ucDodajOdlazak.TxtDan.Text.Equals("npr \"12\"")
                    || string.IsNullOrEmpty(ucDodajOdlazak.TxtDan.Text))
                {
                    MessageBox.Show("Unesite dan!");
                }
                else if (!ValidacijaDana(ucDodajOdlazak.TxtDan.Text))
                {
                    MessageBox.Show("Unesite adekvatan broj dana u ovom mesecu!");
                }
                else if (int.Parse(ucDodajOdlazak.TxtDan.Text) > DateTime.Now.Day)
                {
                    MessageBox.Show("Ne možete evidentirati buduće dolaske!");
                }
                else
                {
                    Odlazak odlazak = new Odlazak();
                    odlazak.Clan = ClanoviKontroler.Instance.Clan;

                    odlazak.GrupniProgram = ucDodajOdlazak.CmbGrPr.SelectedItem as GrupniProgram;
                    //odlazak.GrupniProgram.Id = ucDodajOdlazak.CmbGrPr.SelectedIndex + 1;
                    string datumString = ucDodajOdlazak.TxtDan.Text + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                    DateTime datum = DateTime.Parse(datumString);
                    odlazak.DatumOdlaska = datum;
                    odlazak.Placeno = ucDodajOdlazak.ChBPlaceno.Checked;
                    List<Odlazak> odlasci = new List<Odlazak>();
                    odlasci.Add(odlazak);
                    Odgovor odg = Komunikacija.Instance.IzvrsiFjuSacuvajVise(Operacija.SacuvajOdlazak, odlasci);
                    if (odg.Exception != null)
                    {
                        MessageBox.Show("Sistem ne može da zapamti odlazak.");
                    }
                    else
                    {
                        foreach (Odlazak odl in odlasci)
                        {
                            if (!odl.Placeno)
                            {
                                foreach (Racun ra in racuniZaMesecIGod)
                                {
                                    GrupniProgram gr = odl.GrupniProgram;
                                    ra.Iznos += gr.CenaJednog - (gr.CenaJednog * (odl.Clan.Kategorija.Popust / 100));
                                    Komunikacija.Instance.IzvrsiFju(Operacija.PromeniRacun, ra);
                                }
                            }
                        }
                        MessageBox.Show("Sistem je zapamtio odlazak.");
                    }
                }
            }
        }

        private bool ValidacijaDana(string text)
        {
            DateTime trenutniDatum = DateTime.Now;
            int brojDanaUMesecu = DateTime.DaysInMonth(trenutniDatum.Year, trenutniDatum.Month);
            int unetiDan = int.Parse(text);
            if (unetiDan >= 1 && unetiDan <= brojDanaUMesecu)
            {
                return true;
            }
            return false;
        }

        internal UserControl VratiKontroluDodajDolazak()
        {
            return ucDodajOdlazak;
        }
    }
}
