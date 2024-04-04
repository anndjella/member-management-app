using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zajednicko.Domain;

namespace SERVER
{
    public class Server
    {
        private Socket osluskujuciSoket;
       public static List<ClientHandler> klijenti=new List<ClientHandler>(); 
        public Server()
        {
            osluskujuciSoket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void PokreniServer()
        {
            //  IPEndPoint endPo = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            IPEndPoint endPo = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));

            osluskujuciSoket.Bind(endPo);
            osluskujuciSoket.Listen(6);

            Thread nit = new Thread(PovezujKlijente);
            nit.Start();
        }
        public void PovezujKlijente()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSoket = osluskujuciSoket.Accept();
                    ClientHandler klijent = new ClientHandler(klijentskiSoket);
                    klijenti.Add(klijent);
                    Thread klNit = new Thread(klijent.HandleRequest);
                    klNit.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.Write(">>>"+ex.ToString()); 
            }
        }
        internal void ZaustaviServer()
        {
            osluskujuciSoket.Close();
            foreach(ClientHandler handler in klijenti)
            {
                handler.UgasiSoket();             
            }
            klijenti.Clear();
        }
    }
}
