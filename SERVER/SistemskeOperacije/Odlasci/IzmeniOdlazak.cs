using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije.Odlasci
{
    public class IzmeniOdlazak : OpstaSistemskaOperacija
    {
        private Odlazak odlazak;
        public IzmeniOdlazak(Odlazak odlazak)
        {
            this.odlazak = odlazak;
        }
        public override void IzvrsiKonkretnuOp()
        {
            broker.Izmeni(odlazak);
        }
    }
}
