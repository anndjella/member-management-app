using Klijent.UserKontrole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;

namespace Klijent.GUIKontroler
{
    public class DodajVišeOdlazakaKontroler
    {
        private FrmAddMultipleAttendances frmViseDol;
        private static DodajVišeOdlazakaKontroler instance;
        public static DodajVišeOdlazakaKontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DodajVišeOdlazakaKontroler();
                }
                return instance;
            }
        }

        internal void PrikaziUC(object sender, EventArgs e)
        {
            frmViseDol = new FrmAddMultipleAttendances();
            frmViseDol.BtnSacuvaj.Click += Pokupi;
            frmViseDol.Dgv.CellValidating += ProveriBroj;
            List<GrupniProgram> grupni = (List<GrupniProgram>)Komunikacija.Instance.IzvrsiFju(Operacija.VratiSveGrPr).Rezultat;
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn
            {
                DataSource = grupni,
                DisplayMember = "Naziv",
                ValueMember = "Self",
                DataPropertyName = "GrupniProgram",
                HeaderText = "Group program",
                Name = "GrPr"
            };
            frmViseDol.Dgv.Columns.Add(cmb);
            DataGridViewTextBoxColumn dan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Day",
                Name = "Dan"
            };
            frmViseDol.Dgv.Columns.Add(dan);
            DataGridViewCheckBoxColumn chBox = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "CheckBox",
                HeaderText = "Paid?",
                Name = "Placeno"
            };
            frmViseDol.Dgv.Columns.Add(chBox);
            frmViseDol.ShowDialog();
        }

        private void ProveriBroj(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                DataGridViewCell polje = frmViseDol.Dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    if (int.TryParse(e.FormattedValue.ToString(), out int broj))
                    {
                        if (broj > DateTime.Now.Day)
                        {
                            MessageBox.Show("You cannot record future attendances!");
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a number!");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void Pokupi(object sender, EventArgs e)
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
                    MessageBox.Show("You cannot add attendances because no invoice has been created!");
                }
                else
                {
                    List<Odlazak> odlasci = new List<Odlazak>();

                    foreach (DataGridViewRow red in frmViseDol.Dgv.Rows)
                    {
                        if (!red.IsNewRow)
                        {

                            GrupniProgram grupniProgram = (GrupniProgram)red.Cells["GrPr"].Value;
                            bool okej = int.TryParse(red.Cells["Dan"].Value.ToString(), out int dan);
                            object placenoObj = red.Cells["Placeno"].Value;
                            bool placeno;
                            if (placenoObj != null && placenoObj is bool)
                            {
                                placeno = true;
                            }
                            else
                            {
                                placeno = false;
                            }
                            Clan clan = ClanoviKontroler.Instance.Clan;
                            Odlazak odlazak = new Odlazak();
                            if (okej)
                            {
                                string datumString = dan + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
                                DateTime datum = DateTime.Parse(datumString);
                                odlazak.DatumOdlaska = datum;
                            }
                            odlazak.Placeno = placeno;
                            odlazak.Clan = clan;
                            odlazak.GrupniProgram = grupniProgram;
                            odlasci.Add(odlazak);

                        }
                    }
                    Odgovor odg = Komunikacija.Instance.IzvrsiFjuSacuvajVise(Operacija.SacuvajOdlazak, odlasci);
                    if (odg.Exception != null)
                    {
                        MessageBox.Show("The system could not save the attendances!");
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
                        MessageBox.Show("Attendances have been saved successfully!");
                    }


                }
            }
        }
    }
}


