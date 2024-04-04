using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using Zajednicko;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SERVER
{
    public class ClientHandler
    {
        private Socket klijentskiSoket;
        private Posiljalac posiljalac;
        private Primalac primalac;
       public string Email { get; private set; }
        public ClientHandler(Socket klijentskiSoket)
        {
            this.klijentskiSoket = klijentskiSoket;
            primalac = new Primalac(klijentskiSoket);
            posiljalac=new Posiljalac(klijentskiSoket);
        }

        public void HandleRequest()
        {
            try
            {
                while (true)
                {
                    Zahtev zahtev = (Zahtev)primalac.Primi();
                    Odgovor odg = ObradiZahtev(zahtev);
                    posiljalac.Posalji(odg);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>" + ex);
               // throw ex;
            }
        }

        private Odgovor ObradiZahtev(Zahtev zahtev)
        {
            Odgovor odg = new Odgovor();
            try
            {
                switch (zahtev.Operacija)
                {
                    case Operacija.Login:
                        odg.Rezultat = Kontroler.Instance.Login((Operater)zahtev.Argument);
                        odg.Exception = Validacija(zahtev.Argument);
                        break;
                    case Operacija.VratiSveClanove:
                        odg.Rezultat = Kontroler.Instance.VratiListuClanova();

                        break;
                    case Operacija.VratiSveKategorije:
                        odg.Rezultat = Kontroler.Instance.VratiListuKategorija();
                        break;
                    case Operacija.ZapamtiClana:
                        Kontroler.Instance.ZapamtiClanaKon((Clan)zahtev.Argument);
                        break;
                    case Operacija.VratiKonkretneClanove:
                        odg.Rezultat = Kontroler.Instance.VratiKonkretneClanove((Clan)zahtev.Argument);
                        break;
                    case Operacija.IzbrisiClana:
                        Kontroler.Instance.IzbrisiClana((Clan)zahtev.Argument);
                        break;
                    case Operacija.IzmeniClana:
                        Kontroler.Instance.IzmeniClana((Clan)zahtev.Argument);
                        break;
                    case Operacija.VratiSveGrPr:
                        odg.Rezultat = Kontroler.Instance.VratiSveGr();
                        break;
                    case Operacija.SacuvajOdlazak:
                        // try
                        // {
                        Kontroler.Instance.SacuvajOdlazak((List<Odlazak>)zahtev.Argument);
                        // }
                        // catch (Exception)
                        //{
                        //   odg.Exception = new Exception("Sistem ne može da zapamti odlazak!");
                        // }
                        break;
                    case Operacija.PronadjiRacune:
                        odg.Rezultat = Kontroler.Instance.PronadjiRacune((Racun)zahtev.Argument);
                        break;
                    case Operacija.DodajRacun:
                        Kontroler.Instance.SacuvajRacun((Racun)zahtev.Argument);
                        break;
                    case Operacija.PronadjiOdlaske:
                        odg.Rezultat = Kontroler.Instance.PronadjiOdlaske((Odlazak)zahtev.Argument);
                        break;
                    case Operacija.PromeniRacun:
                        Kontroler.Instance.PromeniRacun((Racun)zahtev.Argument);
                        break;
                    case Operacija.PromeniOdlazak:
                        Kontroler.Instance.PromeniOdlazak((Odlazak)zahtev.Argument);
                        break;
                }
            }
            catch (Exception ex)
            {
                odg.Exception = ex;
            }
            return odg;
        }

        private Exception Validacija(object rezultat)
        {
            Exception izuzetak = null;
            foreach (ClientHandler klijent in Server.klijenti)
            {
                if (klijent.Email == ((Operater)rezultat).Email)
                {
                    izuzetak = new Exception("Operater sa ovim email-om se vec prijavio na sistem!");
                    break;
                }
            }
            if (izuzetak==null)
            {
                Email = ((Operater)rezultat).Email;
            }
            return izuzetak;
        }

        internal void UgasiSoket()
        {
            klijentskiSoket.Shutdown(SocketShutdown.Both);
            klijentskiSoket.Close();
        }
    }
}