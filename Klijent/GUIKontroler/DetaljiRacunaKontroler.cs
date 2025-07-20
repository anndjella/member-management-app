using Klijent.UserKontrole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;

namespace Klijent.GUIKontroler
{
    public class DetaljiRacunaKontroler
    {
        private UCDetaljiRacuna ucDetaljiRacuna;
      
        public event EventHandler RefresujDGV;
        private Odlazak Odlazak { get; set; }
        List<Odlazak> odlasciZaKonkretnogClanaUIzabranomMesecu = new List<Odlazak>();

        private static DetaljiRacunaKontroler instance;
        public static DetaljiRacunaKontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DetaljiRacunaKontroler();
                }
                return instance;
            }
        }
        private DetaljiRacunaKontroler()
        {
            ucDetaljiRacuna = new UCDetaljiRacuna();
            RacunKontroler.Instance.DetaljiRacuna += PopuniDgv;

            RacunKontroler.Instance.DetaljiRacuna += PopuniLabele;
            ucDetaljiRacuna.BtnPretrazi.Click += Pretrazi;
            ucDetaljiRacuna.TxtUnos.Click += RefresujPolje;
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

        private void Pretrazi(object sender, EventArgs e)
        {
            string unos=ucDetaljiRacuna.TxtUnos.Text;
            ucDetaljiRacuna.DgvDolasci.CurrentCell = null;
            int j = 0;
            bool okej = int.TryParse(unos, out int broj);
            if (!string.IsNullOrEmpty(unos) || unos.Equals("npr. \"3\""))
            {
                if (okej)
                {
                    List<Odlazak> dgvOdl = new List<Odlazak>();
                    List<Odlazak> odabraniOdlasci = odlasciZaKonkretnogClanaUIzabranomMesecu.Where(o=>o.DatumOdlaska.Day==broj).ToList();
                    if (odabraniOdlasci.Count == 0)
                    {
                        ucDetaljiRacuna.DgvDolasci.ClearSelection();
                        foreach (DataGridViewRow red in ucDetaljiRacuna.DgvDolasci.Rows)
                        {
                            red.Visible = false; // ponovo ih pokaži
                        }
                        //MessageBox.Show("Sistem ne može da nađe odlaske po zadatoj vrednosti");
                    }
                    else
                    {
                        foreach (DataGridViewRow red in ucDetaljiRacuna.DgvDolasci.Rows)
                        {
                            if (j<odabraniOdlasci.Count && red.DataBoundItem is Odlazak odl && odl == odabraniOdlasci[j])
                            {
                                j++;
                                red.Visible = true;
                            }
                            else
                            {
                                ucDetaljiRacuna.DgvDolasci.ClearSelection();
                                red.Visible = false;
                            }
                        }
                       //MessageBox.Show("Sistem je našao odlaske po zadatoj vrednosti.");
                    }
                }
                else
                {
                    MessageBox.Show("Unesite broj!");
                }
            }
            else
            {
                ucDetaljiRacuna.DgvDolasci.DataSource = odlasciZaKonkretnogClanaUIzabranomMesecu;
            }
        }

        private void PopuniLabele(object sender, EventArgs e)
        {
            Odlazak = new Odlazak();

            Odlazak.Clan = RacunKontroler.Instance.Clan;
            Racun racun = RacunKontroler.Instance.Racun;


            List<Racun> racuni = (List<Racun>)Komunikacija.Instance.IzvrsiFju(Operacija.PronadjiRacune, RacunKontroler.Instance.Racun).Rezultat;
            racuni=racuni.Where(r=>r.Mesec==racun.Mesec && r.Godina== racun.Godina).ToList();
            ucDetaljiRacuna.LblKonacniIznos.Text = "Konačni iznos računa sa obračunatim popustom:" + $"{racuni[0].Iznos}";

        }

        private void PopuniDgv(object sender, EventArgs e)
        {
            Odlazak = new Odlazak();
            Odlazak.Clan = RacunKontroler.Instance.Clan;
            string datumString = 1 + "." + (int)RacunKontroler.Instance.Racun.Mesec + "." + RacunKontroler.Instance.Racun.Godina;
            Odlazak.DatumOdlaska = DateTime.Parse(datumString);
            odlasciZaKonkretnogClanaUIzabranomMesecu =
               (List<Odlazak>)Komunikacija.Instance.IzvrsiFju(Operacija.PronadjiOdlaske, Odlazak).Rezultat;
            ucDetaljiRacuna.DgvDolasci.DataSource = odlasciZaKonkretnogClanaUIzabranomMesecu;
            ucDetaljiRacuna.DgvDolasci.Columns["Clan"].Visible = false;
            ucDetaljiRacuna.DgvDolasci.Columns["ImeTabele"].Visible = false;
            ucDetaljiRacuna.DgvDolasci.Columns["Vrednosti"].Visible = false;
            ucDetaljiRacuna.DgvDolasci.Columns["UslovZaWhereVratiSve"].Visible = false;
            ucDetaljiRacuna.DgvDolasci.Columns["IzrazZaJoin"].Visible = false;
            ucDetaljiRacuna.DgvDolasci.Columns["UslovZaDelete"].Visible = false;
            ucDetaljiRacuna.DgvDolasci.Columns["UslovZaUpdate"].Visible = false;
            ucDetaljiRacuna.DgvDolasci.Columns["UslovZaSet"].Visible = false;
            ucDetaljiRacuna.DgvDolasci.Columns["UslovZaWhereSaUslovom"].Visible = false;
            ucDetaljiRacuna.DgvDolasci.Columns["Identifikator"].Visible = false;
            ucDetaljiRacuna.DgvDolasci.CellContentClick += PromeniRacun;
            PopuniCene();
        }

        private void PopuniCene()
        {
            if (!ucDetaljiRacuna.DgvDolasci.Columns.Contains("Cena"))
            {
                DataGridViewTextBoxColumn kolonaCena = new DataGridViewTextBoxColumn();
                kolonaCena.HeaderText = "Cena";
                kolonaCena.Name = "Cena";
                ucDetaljiRacuna.DgvDolasci.Columns.Add(kolonaCena);
            }
            if (!ucDetaljiRacuna.DgvDolasci.Columns.Contains("KetegorijskiPopust"))
            {
                DataGridViewTextBoxColumn kolonaKategPopust = new DataGridViewTextBoxColumn();
                kolonaKategPopust.HeaderText = "Kategorijski popust (u %)";
                kolonaKategPopust.Name = "KetegorijskiPopust";
                ucDetaljiRacuna.DgvDolasci.Columns.Add(kolonaKategPopust);
            }
            if (!ucDetaljiRacuna.DgvDolasci.Columns.Contains("KonCena"))
            {
                DataGridViewTextBoxColumn kolonaKategPopust = new DataGridViewTextBoxColumn();
                kolonaKategPopust.HeaderText = "Konačna cena";
                kolonaKategPopust.Name = "KonCena";
                ucDetaljiRacuna.DgvDolasci.Columns.Add(kolonaKategPopust);
            }
            for (int i = 0; i < odlasciZaKonkretnogClanaUIzabranomMesecu.Count; i++)
            {
                ucDetaljiRacuna.DgvDolasci.Rows[i].Cells["KonCena"].Value = odlasciZaKonkretnogClanaUIzabranomMesecu.ElementAt(i).GrupniProgram.CenaJednog - (odlasciZaKonkretnogClanaUIzabranomMesecu.ElementAt(i).Clan.Kategorija.Popust / 100) * odlasciZaKonkretnogClanaUIzabranomMesecu.ElementAt(i).GrupniProgram.CenaJednog;
            }
            for (int i = 0; i < odlasciZaKonkretnogClanaUIzabranomMesecu.Count; i++)
            {
                ucDetaljiRacuna.DgvDolasci.Rows[i].Cells["Cena"].Value = odlasciZaKonkretnogClanaUIzabranomMesecu.ElementAt(i).GrupniProgram.CenaJednog;
            }
            for (int i = 0; i < odlasciZaKonkretnogClanaUIzabranomMesecu.Count; i++)
            {
                ucDetaljiRacuna.DgvDolasci.Rows[i].Cells["KetegorijskiPopust"].Value = odlasciZaKonkretnogClanaUIzabranomMesecu.ElementAt(i).Clan.Kategorija.Popust;
            }
        }

        private void PromeniRacun(object sender, DataGridViewCellEventArgs e)
        {
            if (ucDetaljiRacuna.DgvDolasci.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                if (!(bool)ucDetaljiRacuna.DgvDolasci[e.ColumnIndex, e.RowIndex].Value)
                {
                    ucDetaljiRacuna.DgvDolasci[e.ColumnIndex, e.RowIndex].Value = true;
                    Odlazak odlazak = (Odlazak)ucDetaljiRacuna.DgvDolasci.Rows[e.RowIndex].DataBoundItem;
                    Racun ra = RacunKontroler.Instance.Racun;
                    if (ra != null && ra.Iznos>0)
                    {
                        double smanjiZaIznos = odlazak.GrupniProgram.CenaJednog - ((odlazak.Clan.Kategorija.Popust / 100) * odlazak.GrupniProgram.CenaJednog);
                        ra.Iznos -= smanjiZaIznos;
                        odlazak.Placeno = true;
                        Komunikacija.Instance.IzvrsiFju(Operacija.PromeniOdlazak, odlazak);
                        Komunikacija.Instance.IzvrsiFju(Operacija.PromeniRacun, ra);                     
                        MessageBox.Show($"Odlazak je izmenjen i račun je smanjen za {smanjiZaIznos} dinara!");
                        RefresujDGV?.Invoke(this, EventArgs.Empty);
                        ucDetaljiRacuna.LblKonacniIznos.Text = "Konačni iznos računa sa obračunatim popustom:" + $" {ra.Iznos}";
                    }
                }
            }
        }

        internal UserControl VratiKontrolu()
        {
            return ucDetaljiRacuna;
        }
    }
}
