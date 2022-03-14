using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediaBazzarApplication.Database
{
    class DBConnection
    {
        public static string ConnectionString()
        {
            return
            "Server=studmysql01.fhict.local; Port=3306; Database=dbi431568; Uid=dbi431568; Pwd=Jdv3ABrVdE; SslMode=none";
            
        }

        MySqlConnection conn;
        public void OpenConnection()
        {
            conn = new MySqlConnection(ConnectionString());
            conn.Open();
        }

        public void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void ExecuteQueries(string Query_)
        {
            MySqlCommand cmd = new MySqlCommand(Query_, conn);
            cmd.ExecuteNonQuery();
        }

        public MySqlDataReader DataReader(string Query_)
        {
            MySqlCommand cmd = new MySqlCommand(Query_, conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
