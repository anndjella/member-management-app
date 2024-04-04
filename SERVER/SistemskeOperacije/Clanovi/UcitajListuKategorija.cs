using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije.Clanovi
{
    public class UcitajListuKategorija : OpstaSistemskaOperacija
    {
        private List<Kategorija> kategorije=new List<Kategorija>();
        public List<Kategorija> Rezultat => kategorije;
        public UcitajListuKategorija()
        {
           
        }
        public override void IzvrsiKonkretnuOp()
        {
            List<IEntitet> lista = broker.VratiSve(new Kategorija());

            foreach (Kategorija k in lista)
            {
                kategorije.Add(k);
            }
        }
    }
}
