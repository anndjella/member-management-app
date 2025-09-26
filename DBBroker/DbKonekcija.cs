using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBroker
{
    public class DbKonekcija
    {

        private SqlConnection connection;
        private SqlTransaction transaction;

        public DbKonekcija()
        {
            EnvLoader.Load();
            connection = new SqlConnection(DbConfig.ConnectionString());
            //connection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            //new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bazaAndjela;Integrated Security=True;");
        }

        public void OtvoriKonekciju()
        {
            connection?.Open();
        }

        public void ZatvoriKonekciju()
        {
            connection?.Close();
        }

        public void PokreniTransakciju()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaction?.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", connection, transaction);
        }
    }
}
