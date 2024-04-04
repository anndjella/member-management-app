using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.Komunikacija
{
    [Serializable]

    public class Odgovor
    {
        public object Rezultat { get; set; }
        public Exception Exception { get; set; }
    }
}
