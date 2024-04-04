using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije.Clanovi
{
    public class UcitajListuClanova : OpstaSistemskaOperacija
    {
        List<Clan> clanovi = new List<Clan>();
        public List<Clan> Rezultat =>clanovi;
        public override void IzvrsiKonkretnuOp()
        {
            List<IEntitet> lista = broker.VratiSve(new Clan());

            foreach (Clan c in lista)
            {
                clanovi.Add(c);
            }
        }
    }
}
