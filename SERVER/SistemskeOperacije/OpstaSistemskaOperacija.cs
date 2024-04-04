using DBBroker;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.Domain;

namespace SERVER.SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
        protected Broker broker;

        public OpstaSistemskaOperacija()
        {
            broker = new Broker();
        }


        public void ExecuteTemplate()
        {
            try
            {
                broker.OtvoriKonekciju();
                broker.PokreniTransakciju();

                IzvrsiKonkretnuOp();

                broker.Commit();
            }
            catch (SqlException ex)
            {
                broker.Rollback();
                throw;//ex;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        public abstract void IzvrsiKonkretnuOp();
        
    }
}
