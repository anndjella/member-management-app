using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicko.Komunikacija
{
    public class Posiljalac
    {
        private Socket soket;
        private NetworkStream stream;
        private BinaryFormatter formatter;
        public Posiljalac(Socket soket)
        {
            this.soket = soket;
            formatter = new BinaryFormatter();  
            stream = new NetworkStream(soket);
        }
        public void Posalji(object objekat)
        {
            formatter.Serialize(stream, objekat);
        }
    }
}
