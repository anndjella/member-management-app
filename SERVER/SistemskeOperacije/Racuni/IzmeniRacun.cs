using DBBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.Domain;
using Zajednicko;

namespace SERVER.SistemskeOperacije.Racuni
{
    public class IzmeniRacun:OpstaSistemskaOperacija
    {
        private Racun racun;
        public  IzmeniRacun(Racun racun)
        {
            this.racun = racun;
        }
        public override void IzvrsiKonkretnuOp()
        {
            broker.Izmeni(racun);
        }
    }
}
