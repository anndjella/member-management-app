using Klijent.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Infra
{
    internal sealed class WinFormsSystemServices : ISystemServices
    {
        public DateTime Now() => DateTime.Now;

        public bool Confirm(string text, string caption)
        {
            var rez = MessageBox.Show(text, caption, MessageBoxButtons.YesNo);
            return rez == DialogResult.Yes;
        }

        public void Info(string message) => MessageBox.Show(message);
    }
}
