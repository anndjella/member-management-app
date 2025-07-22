using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERVER
{
    public partial class FrmServer : Form
    {
        private Server server;
        public FrmServer()
        {
            InitializeComponent();
        }

        private void btnPokreniServer_Click(object sender, EventArgs e)
        {
            btnPokreniServer.Visible = false;   
            btnZaustaviServer.Visible = true;
            lblStatusServera.Text = "Server is running!";
            lblStatusServera.ForeColor = Color.ForestGreen;
            server = new Server();
            server.PokreniServer();
        }

        private void btnZaustaviServer_Click(object sender, EventArgs e)
        {
            btnPokreniServer.Visible = true;
            btnZaustaviServer.Visible = false;
            lblStatusServera.Text = "Server is not running!";
            lblStatusServera.ForeColor = Color.Red;
            server.ZaustaviServer();
        }

        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
