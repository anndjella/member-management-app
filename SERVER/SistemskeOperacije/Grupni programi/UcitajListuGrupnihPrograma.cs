using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije.Grupni_programi
{
    public class UcitajListuGrupnihPrograma:OpstaSistemskaOperacija
    {
        private List<GrupniProgram> grProgrami;
        public List<GrupniProgram> Rezultat => grProgrami;
        public UcitajListuGrupnihPrograma()
        {
            grProgrami = new List<GrupniProgram>(); 
        }

        public override void IzvrsiKonkretnuOp()
        {
            List<IEntitet> lista = broker.VratiSve(new GrupniProgram());

            foreach (GrupniProgram gr in lista)
            {
                grProgrami.Add(gr);
            }
        }
    }
}
