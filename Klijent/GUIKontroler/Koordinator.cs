using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.Domain;

namespace Klijent.GUIKontroler
{
    public class Koordinator
    {
        private GlavnaForma glavnaForma;
        private static Koordinator instance;
        public static Koordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Koordinator();
                }
                return instance;
            }
        }
        private Koordinator()
        {
        }

        private void UgasiProgram(object sender, FormClosedEventArgs e)
        {
           Environment.Exit(0);
        }

        internal void PrikaziGlavnuFormu(Operater rezultat)
        {
            glavnaForma = new GlavnaForma();
            glavnaForma.FormClosed += UgasiProgram;
            glavnaForma.Text = rezultat.Ime + " " + rezultat.Prezime;
            glavnaForma.WindowState = FormWindowState.Maximized;
            glavnaForma.ShowDialog();
        }

        internal void PrikaziKontroluClanovi(object sender, EventArgs e)
        {
            glavnaForma.PromeniControl(ClanoviKontroler.Instance.vratiKontroluClanovi());
        }

        internal void PrikaziPanelDodajDolazak(object sender, EventArgs e)
        {
            glavnaForma.PromeniDrugiPanel(DodajOdlazakKontroler.Instance.VratiKontroluDodajDolazak());
        }

        internal void PrikaziDodajRacun(object sender, EventArgs e)
        {
            glavnaForma.PromeniDrugiPanel(RacunKontroler.Instance.VratiKontroluDodajRacun());
        }

        internal void PrikaziSveRacune(object sender, EventArgs e)
        {
            glavnaForma.PromeniDrugiPanel(RacunKontroler.Instance.VratiKontroluSviRacuni());
        }

        internal void PrikaziPanelDetaljiORacunu()
        {
            glavnaForma.PromeniTreciPanel(DetaljiRacunaKontroler.Instance.VratiKontrolu());
        }

    }
}
