using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zajednicko;
using Zajednicko.Domain;

namespace DBBroker
{
    public class Broker:IBroker<IEntitet>
    {
        private DbKonekcija connection;

        public Broker()
        {
            connection = new DbKonekcija();
        }
        public void ZatvoriKonekciju()
        {
            connection.ZatvoriKonekciju();
        }

        public void OtvoriKonekciju()
        {
            connection.OtvoriKonekciju();
        }
        public void Rollback()
        {
            connection.Rollback();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void PokreniTransakciju()
        {
            connection.PokreniTransakciju();
        }
        public List<IEntitet> VratiSve(IEntitet argument)
        {
            List<IEntitet> lista = new List<IEntitet>();
            SqlCommand komanda = connection.CreateCommand();
            bool prazan = false;
            if ((argument is Clan && string.IsNullOrEmpty(((Clan)argument).Prezime))
                || (argument is GrupniProgram && string.IsNullOrEmpty(((GrupniProgram)argument).Naziv)))
            {
                prazan = true;
            }
            komanda.CommandText = $"select * from {argument.ImeTabele} " +
                $"{argument.IzrazZaJoin}" +
                (!prazan && (argument is Clan || argument is Operater) ?
                $"{argument.UslovZaWhereVratiSve}" : "");
            SqlDataReader reader = komanda.ExecuteReader();
            while (reader.Read())
            {
                Transformator transformator = new Transformator();
                lista.Add(transformator.Transformisi(argument, reader));
            }
            reader.Close();
            return lista;
        }

        //public void Dodaj(IEntitet argument)
        //{
        //    SqlCommand komanda = connection.CreateCommand();
        //    komanda.CommandText = $"insert into {argument.ImeTabele} values ({argument.Vrednosti})";
        //    komanda.ExecuteNonQuery();
        //}
        public void Dodaj(List<IEntitet> argument)
        {
            SqlCommand komanda = connection.CreateCommand();
            foreach(IEntitet ie in argument)
            {
                komanda.CommandText = $"insert into {ie.ImeTabele} values ({ie.Vrednosti})";
                komanda.ExecuteNonQuery();
            }         
        }

        public void Izbrisi(IEntitet argument)
        {
            SqlCommand komanda = connection.CreateCommand();
            komanda.CommandText = $"delete from {argument.ImeTabele} {argument.UslovZaDelete}";
            komanda.ExecuteNonQuery();
        }
        public void Izmeni(IEntitet argument)
        {
            SqlCommand komanda = connection.CreateCommand();
            komanda.CommandText = $"update {argument.ImeTabele}  {argument.UslovZaSet} {argument.UslovZaUpdate}";
            komanda.ExecuteNonQuery();
        }

        public List<IEntitet> VratiSveUslov(IEntitet entitet, IEntitet objekatZaUslov)
        {
            List<IEntitet> lista = new List<IEntitet>();
            SqlCommand komanda = connection.CreateCommand();
            komanda.CommandText = "select * from " + entitet.ImeTabele + " " +
                    entitet.IzrazZaJoin + " " + entitet.UslovZaWhereVratiSveSaObjektom(objekatZaUslov);                  
            SqlDataReader reader = komanda.ExecuteReader();
            while (reader.Read())
            {
                Transformator transformator = new Transformator();
                lista.Add(transformator.Transformisi(entitet, reader));
            }
            reader.Close();
            return lista;
        }
    }
}
