using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.Komunikacija
{
    [Serializable]
    public class Zahtev
    {
        public Operacija Operacija { get; set; }
        public object Argument { get; set; }
    }
}
