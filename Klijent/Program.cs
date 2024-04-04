using Klijent.GUIKontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zajednicko.Domain;

namespace Klijent
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new FrmKlijent());
            LoginGUIKontroler.Instance.PrikaziFormu();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Operater operater = new Operater();
            //operater.Ime = "Andjela";
            //operater.Prezime = "sta";
            //Koordinator.Instance.PrikaziGlavnuFormu(operater);
        }
    }
}
