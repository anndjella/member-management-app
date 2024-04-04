using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije.Odlasci
{
    public class NadjiOdlaske : OpstaSistemskaOperacija
    {
        private Odlazak odlazak;
        private List<Odlazak> odlasci = new List<Odlazak>();
        public List<Odlazak> Rezultat => odlasci;
        public NadjiOdlaske(Odlazak odlazak)
        {
            this.odlazak = odlazak;
        }
        public override void IzvrsiKonkretnuOp()
        {
            List<IEntitet> lista = broker.VratiSveUslov(new Odlazak(), odlazak);

            foreach (Odlazak o in lista)
            {
                odlasci.Add(o);
            }
        }
    }
}
