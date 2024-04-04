using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;
using Zajednicko.Komunikacija;

namespace SERVER.SistemskeOperacije
{
    public class LoginSO : OpstaSistemskaOperacija
    {
        private Operater op;
        private List<Operater> operateri = new List<Operater>();
        public List<Operater> Rezultat => operateri;
        public LoginSO(Operater op)
        {
            this.op = op;
        }

        public override void IzvrsiKonkretnuOp()
        {
            List<IEntitet> lista = broker.VratiSve(op);

            foreach (Operater o in lista)
            {
                operateri.Add(o);
            }

        }
    }
}
