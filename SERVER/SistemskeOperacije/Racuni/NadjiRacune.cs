using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije.Racuni
{
    public class NadjiRacune : OpstaSistemskaOperacija
    {
        List<Racun> racuni = new List<Racun>();
        private Racun racun;

        public NadjiRacune(Racun racun)
        {
            this.racun = racun;
        }

        public List<Racun> Rezultat => racuni;
        public override void IzvrsiKonkretnuOp()
        {
            List<IEntitet> lista = broker.VratiSveUslov(new Racun(), racun);

            foreach (Racun r in lista)
            {
                racuni.Add(r);
            }

        }
    }
}
