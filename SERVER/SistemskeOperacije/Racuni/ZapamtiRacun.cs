using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.Domain;
using Zajednicko;

namespace SERVER.SistemskeOperacije.Racuni
{
    public class ZapamtiRacun:OpstaSistemskaOperacija
    {
        private Racun racun;
        private List<Racun> racuni = new List<Racun>();
        public ZapamtiRacun(Racun racun)
        {
            this.racun = racun;
            racuni.Add(racun);
        }
        public override void IzvrsiKonkretnuOp()
        {
            List<IEntitet> lista = new List<IEntitet>();
            foreach (Racun rac in racuni)
            {
                lista.Add(rac);
            }
            broker.Dodaj(lista);
        }
    }
}
