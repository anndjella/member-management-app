using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije.Clanovi
{
    public class ObrisiClana:OpstaSistemskaOperacija
    {
        private Clan clan;
        public ObrisiClana(Clan clan)
        {
            this.clan = clan;
        }

        public override void IzvrsiKonkretnuOp()
        {
            broker.Izbrisi(clan);
        }
    }
}
