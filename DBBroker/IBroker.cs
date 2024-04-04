using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko.Domain;
using Zajednicko;

namespace DBBroker
{
    public interface IBroker<T> where T : class
    {
        void ZatvoriKonekciju();
        void OtvoriKonekciju();
        void Rollback();
        void Commit();
        void PokreniTransakciju();
        List<IEntitet> VratiSve(T argument);
        void Dodaj(List<T> argument);
        void Izbrisi(T argument);
        void Izmeni(T argument);
        List<T> VratiSveUslov(T entitet, T objekatZaUslov);
    }
}

