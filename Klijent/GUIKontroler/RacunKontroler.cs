using Klijent.UserKontrole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Zajednicko;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;
using Klijent.Infra;
using Klijent.Abstractions;

namespace Klijent.GUIKontroler
{
    public class RacunKontroler
    {
        private UCRacun ucRacun;
        List<Racun> racuni;
        public Racun Racun { get; set; }
        public Clan Clan { get; set; }
        public EventHandler DetaljiRacuna;
        private static RacunKontroler instance;

        private readonly ISystemServices _sys;
        private readonly IAppGateway _gw;


        internal UCRacun View => ucRacun;
        internal void SetRacuni(List<Racun> r) => racuni = r ?? new List<Racun>();
        public static RacunKontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RacunKontroler(
                        new WinFormsSystemServices(), 
                        new DefaultGateway()         
                    );
                }
                return instance;
            }
        }
        private RacunKontroler()
        {
            ucRacun = new UCRacun();
            ClanoviKontroler.Instance.FormirajLabelu += InicijalicujFormuKreirajRacun;
            ClanoviKontroler.Instance.FormirajLabeluSviRacuni += InicijalicujFormuSviRacuni;
            ucRacun.BtnKreirajRacun.Click += KreirajRacun;
            ucRacun.DgvOdlasci.CellFormatting += PrevediMesece;

        }

        internal RacunKontroler(ISystemServices sys, IAppGateway gw)
        {
            _sys = sys;
            _gw = gw;

            ucRacun = new UCRacun();

            ClanoviKontroler.Instance.FormirajLabelu += InicijalicujFormuKreirajRacun;
            ClanoviKontroler.Instance.FormirajLabeluSviRacuni += InicijalicujFormuSviRacuni;

            ucRacun.BtnKreirajRacun.Click += KreirajRacun;
            ucRacun.DgvOdlasci.CellFormatting += PrevediMesece;

        }

        private void RefresujDgv(object sender, EventArgs e)
        {
            Racun r = new Racun();
            r.Clan = Clan;
            ucRacun.DgvOdlasci.DataSource = (List<Racun>)Komunikacija.Instance.IzvrsiFju(Operacija.PronadjiRacune, r).Rezultat;
        }

        private void PrevediMesece(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == ucRacun.DgvOdlasci.Columns["mesec"].Index && e.RowIndex >= 0)
            {
                Mesec mesecBroj = (Mesec)Convert.ToInt32(e.Value);
                string mesecNaziv = mesecBroj.ToString();
                e.Value = mesecNaziv;
                e.FormattingApplied = true;
            }
        }

        private void InicijalicujFormuSviRacuni(object sender, EventArgs e)
        {
            Clan = ClanoviKontroler.Instance.Clan;
            Racun r = new Racun();
            r.Clan = Clan;
            ucRacun.LblIme.Text = $"{Clan.Ime} {Clan.Prezime} invoices";
            racuni = (List<Racun>)Komunikacija.Instance.IzvrsiFju(Operacija.PronadjiRacune, r).Rezultat;

            ucRacun.DgvOdlasci.DataSource = new BindingList<Racun>(racuni);
            Sakrij();
            ucRacun.DgvOdlasci.Columns["Mesec"].HeaderText = "Month";
            ucRacun.DgvOdlasci.Columns["Godina"].HeaderText = "Year";
            ucRacun.DgvOdlasci.Columns["Iznos"].HeaderText = "Amount";
            ucRacun.BtnDetaljiORacunu.Click += DetaljiORacunu;
            ucRacun.BtnPretraga.Click += PretragaRacuna;
            ucRacun.TxtUnos.Click += RefresujPolje;
            DetaljiRacunaKontroler.Instance.RefresujDGV += RefresujDgv;
        }

       

        private void OtcekirajRed(object sender, EventArgs e)
        {
            if (ucRacun.DgvOdlasci.CurrentCell != null)
            {
                ucRacun.DgvOdlasci.CurrentCell.Selected = false;
            }
        }

        private void RefresujPolje(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            if (tBox != null)
            {
                tBox.ForeColor = System.Drawing.Color.Black;
                tBox.Text = "";
            }
        }
        internal void PretragaRacuna(object sender, EventArgs e)
        {
            string unos = ucRacun.TxtUnos.Text;
            bool okej = Enum.TryParse(unos, true, out Mesec mesec);
            int j = 0;
            List<DataGridViewRow> prikazaniRedovi = new List<DataGridViewRow>();

            ucRacun.DgvOdlasci.DataSource = null;
            ucRacun.DgvOdlasci.DataSource = racuni;
            Sakrij();
            if (!string.IsNullOrEmpty(unos) || unos.Equals("e.g. \"July\""))
            {
                if (okej)
                {
                    List<Racun> odabraniRacuni = racuni.Where(r => r.Mesec == mesec).ToList();
                    if (odabraniRacuni.Count == 0)
                    {
                        ucRacun.DgvOdlasci.DataSource = null;
                        ucRacun.DgvOdlasci.DataSource = odabraniRacuni;
                        Sakrij();
                      //  MessageBox.Show("Sistem ne moze da nađe račune po zadatoj vrednosti");
                    }
                    else
                    {
                        for (int i = 0; i < ucRacun.DgvOdlasci.Rows.Count; i++)
                        {
                            DataGridViewRow red = ucRacun.DgvOdlasci.Rows[i];
                            if (j < odabraniRacuni.Count && red.DataBoundItem is Racun odl && odl == odabraniRacuni[j])
                            {
                                j++;
                                prikazaniRedovi.Add(red);
                            }
                        }
                        ucRacun.DgvOdlasci.CurrentCell = null;
                        ucRacun.DgvOdlasci.Rows.Cast<DataGridViewRow>().Except(prikazaniRedovi).ToList().ForEach(r => r.Visible = false);
                       // MessageBox.Show("Sistem je našao račune po zadatoj vrednosti.");
                    }
                }
                else
                {
                    _sys.Info("Invalid format entered!"); 
                }
            }
            else
            {
                ucRacun.DgvOdlasci.DataSource = racuni;
            }

        }

        private void ObavestiDaNemaRacune(object sender, EventArgs e)
        {
            MessageBox.Show("The system cannot find subscriptions for the selected!");
        }

        private void DetaljiORacunu(object sender, EventArgs e)
        {
            if (ucRacun.DgvOdlasci.SelectedRows.Count == 1)
            {
                DataGridViewRow red = ucRacun.DgvOdlasci.SelectedRows[0];
                Racun izabraniRacun = red.DataBoundItem as Racun;
                if (izabraniRacun != null)
                {
                    Racun = izabraniRacun;
                    Koordinator.Instance.PrikaziPanelDetaljiORacunu();
                    DetaljiRacuna?.Invoke(this, EventArgs.Empty);
                }
            }

        }

        public void InicijalicujFormuKreirajRacun(object sender, EventArgs e)
        {
            Clan = ClanoviKontroler.Instance.Clan;
            ucRacun.LblIme.Text = $"{Clan.Ime} {Clan.Prezime} invoice {((Mesec)DateTime.Now.Month).ToString()} {DateTime.Now.Year}";

        }

        internal void KreirajRacun(object sender, EventArgs e)
        {
            if (!_sys.Confirm("Are you sure?", "Warning"))
                return;
            Racun ra = new Racun();
            ra.Clan = Clan;
            ra.Mesec = (Mesec)_sys.Now().Month;
            ra.Godina = _sys.Now().Year;

            racuni = (List<Racun>)_gw.Izvrsi(Operacija.PronadjiRacune, ra).Rezultat;

            bool postojiOvomesecniRacun = racuni.Any(r =>
                            r.Mesec == (Mesec)_sys.Now().Month &&
                            r.Godina == _sys.Now().Year);

            if (postojiOvomesecniRacun)
            {
                _sys.Info("The user already has an invoice created for this month!");
            }
            else
            {
                ZapamtiRacun();
            }

        }
        internal void ZapamtiRacun()
        {
            Racun racun = new Racun();
            racun.Clan = new Clan();
            racun.Clan.IdClana = Clan.IdClana;
            racun.Mesec = (Mesec)_sys.Now().Month;
            racun.Godina = _sys.Now().Year;
            racun.Iznos = 0;
            Odgovor odg = _gw.Izvrsi(Operacija.DodajRacun, racun);
            if (odg.Exception == null)
            {
                _sys.Info("The system has saved the invoice.");
            }
        }

        internal UserControl VratiKontroluDodajRacun()
        {
            ucRacun.DgvOdlasci.Visible = false;
            ucRacun.BtnDetaljiORacunu.Visible = false;
            ucRacun.BtnKreirajRacun.Visible = true;
            ucRacun.Pnl.Visible = false;
            return ucRacun;
        }

        internal UserControl VratiKontroluSviRacuni()
        {
            ucRacun.DgvOdlasci.Visible = true;
            ucRacun.Pnl.Visible=true;   
            ucRacun.BtnDetaljiORacunu.Visible = true;
            ucRacun.BtnKreirajRacun.Visible = false;
            return ucRacun;
        }
        private void Sakrij()
        {
            ucRacun.DgvOdlasci.Columns["rbrracuna"].Visible = false;
            ucRacun.DgvOdlasci.Columns["clan"].Visible = false;
            ucRacun.DgvOdlasci.Columns["imetabele"].Visible = false;
            ucRacun.DgvOdlasci.Columns["vrednosti"].Visible = false;
            ucRacun.DgvOdlasci.Columns["IzrazZaJoin"].Visible = false;
            ucRacun.DgvOdlasci.Columns["UslovZaDelete"].Visible = false;
            ucRacun.DgvOdlasci.Columns["UslovZaUpdate"].Visible = false;
            ucRacun.DgvOdlasci.Columns["UslovZaSet"].Visible = false;
            ucRacun.DgvOdlasci.Columns["UslovZaWhereSaUslovom"].Visible = false;
            ucRacun.DgvOdlasci.Columns["UslovZaWhereVratiSve"].Visible = false;
            ucRacun.DgvOdlasci.Columns["Identifikator"].Visible = false;
        }


    }
}
