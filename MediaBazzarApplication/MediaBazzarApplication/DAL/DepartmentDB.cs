using MediaBazzarApplication.Logic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication.DAL
{
    public class DepartmentDB
    {

        public DataAccess conn;


        public DepartmentDB()
        {
            conn = new DataAccess();
        }


        public void AddDepartment(string departmentname)
        {
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string adddepartmentquery = DBQueries.AddDepartment;
            MySqlCommand commandDatabase = new MySqlCommand(adddepartmentquery, databaseConnection);
            try
            {
                commandDatabase.Parameters.AddWithValue("@name", departmentname);


                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();


                if (reader is null)
                {
                    return;
                }


            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                databaseConnection.Close();
            }

             



        }

        public List<Department> GetDepartments()
        {

            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string GetDepartments = DBQueries.GetDepartments;
            MySqlCommand commandDatabase = new MySqlCommand(GetDepartments, databaseConnection);

            List<Department> departments = new List<Department>();
            try
            {
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();
                if (reader is null)
                {
                    return null;
                }

                while (reader.Read())
                {
                    if (reader.RecordsAffected > 0)
                    {
                        //MessageBox.Show("Successfull");
                    }

                    Department d = new Department()
                    {
                        DepartmentId = Convert.ToInt32(reader["ID"]),
                        DepartmentName = (reader["Departmentname"]).ToString(),

                    };
                    departments.Add(d);
                }

                return departments;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                databaseConnection.Close();
            }


        }

        




    }
}
