using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije.Clanovi
{
    public class NadjiClanove:OpstaSistemskaOperacija
    {
        List<Clan> clanovi=new List<Clan>();
        private Clan clan;
        public List<Clan> Rezultat => clanovi;
        public NadjiClanove(Clan clan)
        {
            this.clan = clan;
        }

        public override void IzvrsiKonkretnuOp()
        {
            List<IEntitet> vraceniClanovi = (List<IEntitet>)broker.VratiSve(clan);
            foreach (IEntitet ent in vraceniClanovi)
            {
                clanovi.Add((Clan)ent);
            }
        }
    }
}
