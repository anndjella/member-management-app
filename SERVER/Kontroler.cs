using DBBroker;
using SERVER.SistemskeOperacije;
using SERVER.SistemskeOperacije.Clanovi;
using SERVER.SistemskeOperacije.Grupni_programi;
using SERVER.SistemskeOperacije.Odlasci;
using SERVER.SistemskeOperacije.Racuni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;

namespace SERVER
{
    public class Kontroler
    {
        private Broker broker;
        private static Kontroler instance;
        public static Kontroler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kontroler();
                }
                return instance;
            }
        }
        private Kontroler()
        {
            broker = new Broker();
        }

        internal object Login(Operater operater)
        {
            LoginSO loginSO = new LoginSO(operater);
            loginSO.ExecuteTemplate();
            return loginSO.Rezultat;
        }



        internal List<Clan> VratiListuClanova()
        {
            UcitajListuClanova vlcSO = new UcitajListuClanova();
            vlcSO.ExecuteTemplate();
            return vlcSO.Rezultat;
        }

        internal List<Kategorija> VratiListuKategorija()
        {
            UcitajListuKategorija vlkSO = new UcitajListuKategorija();
            vlkSO.ExecuteTemplate();
            return vlkSO.Rezultat;
        }

        internal void ZapamtiClanaKon(Clan argument)
        {
            ZapamtiClana zaSO = new ZapamtiClana(argument);
            zaSO.ExecuteTemplate();
        }

        internal List<Clan> VratiKonkretneClanove(Clan argument)
        {
            NadjiClanove ncSO = new NadjiClanove(argument);
            ncSO.ExecuteTemplate();
            return ncSO.Rezultat;
        }

        internal void IzbrisiClana(Clan argument)
        {
            ObrisiClana ocSO = new ObrisiClana(argument);
            ocSO.ExecuteTemplate();
        }

        internal void IzmeniClana(Clan argument)
        {
            IzmeniClana icSO = new IzmeniClana(argument);
            icSO.ExecuteTemplate();
        }

        internal List<GrupniProgram> VratiSveGr()
        {
            UcitajListuGrupnihPrograma SO = new UcitajListuGrupnihPrograma();
            SO.ExecuteTemplate();
            return SO.Rezultat;
        }

        internal void SacuvajOdlazak(List<Odlazak> argument)
        {
            ZapamtiOdlaske zoSO = new ZapamtiOdlaske(argument);
            zoSO.ExecuteTemplate();

        }

        internal List<Racun> PronadjiRacune(Racun argument)
        {
            NadjiRacune SO = new NadjiRacune(argument);
            SO.ExecuteTemplate();
            return SO.Rezultat;
        }

        internal void SacuvajRacun(Racun argument)
        {
            ZapamtiRacun SO = new ZapamtiRacun(argument);
            SO.ExecuteTemplate();
        }

        internal object PronadjiOdlaske(Odlazak argument)
        {
            NadjiOdlaske SO = new NadjiOdlaske(argument);
            SO.ExecuteTemplate();
            return SO.Rezultat;
        }

        internal void PromeniRacun(Racun argument)
        {
            IzmeniRacun irSo = new IzmeniRacun(argument);
            irSo.ExecuteTemplate();
        }

        internal void PromeniOdlazak(Odlazak argument)
        {
            IzmeniOdlazak ioSO = new IzmeniOdlazak(argument);
            ioSO.ExecuteTemplate();
        }
    }
}
