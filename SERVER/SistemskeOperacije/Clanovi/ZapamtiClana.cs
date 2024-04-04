using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije.Clanovi
{
    public class ZapamtiClana : OpstaSistemskaOperacija
    {
        private Clan clan;
        private List<Clan> clanovi = new List<Clan>();
        public ZapamtiClana(Clan clan)
        {
            this.clan = clan;
            clanovi.Add(clan);  
        }
        public override void IzvrsiKonkretnuOp()
        {
            List<IEntitet> lista = new List<IEntitet>();
            foreach(Clan cla in clanovi)
            {
                lista.Add(cla);
            }
            broker.Dodaj(lista);
        }
    }
}
