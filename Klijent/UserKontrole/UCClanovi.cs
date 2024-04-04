using Klijent.GUIKontroler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.UserKontrole
{
    public partial class UCClanovi : UserControl
    {
        public UCClanovi()
        {
            InitializeComponent();
            // btnDodajClana.Click += Koordinator.Instance.PrikaziFormuDodajClana;
             btnDodajClana.Click += DodajClanaKontroler.Instance.PrikaziFormuDodajClana;
            btnKreirajDolazak.Click += Koordinator.Instance.PrikaziPanelDodajDolazak;
            btnKreirajRacun.Click += Koordinator.Instance.PrikaziDodajRacun;
            btnSviRacuni.Click += Koordinator.Instance.PrikaziSveRacune;
            // btnDetalji.Click += DodajClanaKontroler.Instance.PrikaziFormuDetaljiClana;
            // btnPretraga.Click += ClanoviKontroler.Instance.PretraziClana;


        }

       
    }
}
