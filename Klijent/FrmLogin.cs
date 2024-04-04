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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            btnLogin.Click += LoginGUIKontroler.Instance.Login;
            txtEmail.TextChanged += LoginGUIKontroler.Instance.VratiBojuPolju;
            txtLozinka.TextChanged += LoginGUIKontroler.Instance.VratiBojuPolju;
        }
    }
}
