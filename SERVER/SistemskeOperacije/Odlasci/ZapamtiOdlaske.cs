using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije.Odlasci
{
    public class ZapamtiOdlaske:OpstaSistemskaOperacija
    {
        //Odlazak odlazak;
       // private List<Odlazak> odlasci = new List<Odlazak>();
        private List<Odlazak> odlasci=new List<Odlazak>();   
        public ZapamtiOdlaske(List<Odlazak> odlasci)
        {
            this.odlasci = odlasci;
          
        }

        public override void IzvrsiKonkretnuOp()
        {
            // broker.Dodaj(odla);  
            List<IEntitet> lista = new List<IEntitet>();
            foreach (Odlazak o in odlasci)
            {
                lista.Add(o);
            }
            broker.Dodaj(lista);
        }
    }
}
