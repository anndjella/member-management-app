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

namespace Klijent
{
    public partial class GlavnaForma : Form
    {
        public GlavnaForma()
        {
            InitializeComponent();
            clanoviToolStripMenuItem.Click += Koordinator.Instance.PrikaziKontroluClanovi;
        }
        public void PromeniControl(UserControl uCtrl)
        {
            panel.Controls.Clear();
            panel.Controls.Add(uCtrl);
         
        }
        public void PromeniDrugiPanel(UserControl uCtrl)
        {
            panel2.Controls.Clear();    
            panel1.Controls.Clear();
            panel1.Controls.Add(uCtrl);
        }

       

        internal void PromeniTreciPanel(UserControl userControl)
        {
            panel2.Controls.Add(userControl);
        }
    }
}
