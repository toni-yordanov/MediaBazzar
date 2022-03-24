using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MediaBazzarApplication
{
    public class DataAccess
    {
        protected MySqlConnection connection;
        protected MySqlCommand command;
        protected MySqlDataReader dataReader;
        protected string query = "";
        public string Databaseconnection = "Server=studmysql01.fhict.local;Uid=dbi463896;Database=dbi463896;Pwd=VuiManqk; SSL Mode=None;";

        public string MessageBox { get; set; }


        public DataAccess()
        {
            string database = "Server=studmysql01.fhict.local;Uid=dbi463896;Database=dbi463896;Pwd=VuiManqk; SSL Mode=None;";

            this.connection = new MySqlConnection(database);
        }


        public void AddWithValue(string parameterName, object value)
        {
            this.command.Parameters.AddWithValue(parameterName, value);
        }

        public void NonQueryEx()
        {
            this.command.ExecuteNonQuery();
        }

        public void Close()
        {
            connection.Close();
        }
        public bool ConnOpen()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    this.connection.Open();
                }
                //  this.connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:

                        MessageBox = "Can not connect (" + ex.Message + ")";

                        break;

                    case 1045:
                        MessageBox = ("Error in Database");
                        break;
                }
                return false;
            }
        }

        public void SqlQuery(string queryText)
        {
            this.command = new MySqlCommand(queryText, this.connection);
        }

    }
}
