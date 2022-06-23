using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaBazzarApplication.Logic;

namespace MediaBazzarApplication.DAL
{
    class ShiftsDB
    {

        public DataAccess conn;
        public Employee e;
        public EmployeeDB edb;

        public ShiftsDB()
        {
            edb = new EmployeeDB();
            conn = new DataAccess();
        }
        #region Shift
        public void AddShift
            (Employee e, ShiftType type, DateTime date)
        {

            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string addshiftq = DBQueries.AddShift;
            MySqlCommand commandDatabase = new MySqlCommand(addshiftq, databaseConnection);
            try
            {
                commandDatabase.Parameters.AddWithValue("@empId", e.ID);
                commandDatabase.Parameters.AddWithValue("@shifId", (int)type);
                commandDatabase.Parameters.AddWithValue("@date", date);

                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();


                if (reader is null)
                {
                    return;
                }


            }
            catch (Exception exc)
            {
                throw exc;

            }
            finally
            {
                databaseConnection.Close();
            }
        }


        public void DeleteShift(int id)
        {
            
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string removeshiftq = DBQueries.RemoveShift;
            MySqlCommand commandDatabase = new MySqlCommand(removeshiftq, databaseConnection);
            try
            {
                databaseConnection.Open();
                // commandDatabase.Parameters.AddWithValue("@id", );
               
                    commandDatabase.Parameters.AddWithValue("@id", id);
                    commandDatabase.ExecuteNonQuery();
               
                
               
            }
            catch (Exception exc)
            {
                throw exc;

            }
            finally
            {
                databaseConnection.Close();
            }
        }


        public List<Shift> GetShifts()
        {
           
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string GetShifts = DBQueries.GetShifts;
            MySqlCommand commandDatabase = new MySqlCommand(GetShifts, databaseConnection);

            List<Shift> shifts = new List<Shift>();
            try
            {
                databaseConnection.Open();
                MySqlCommand cmd = new MySqlCommand(GetShifts, databaseConnection);
              //  cmd.Parameters.AddWithValue("@empId", employee.ID);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr is null)
                {
                    return null;
                }

                while (dr.Read())
                {
                    if (dr.RecordsAffected > 0)
                    {
                        //MessageBox.Show("Successfull");
                    }
                    
                    Employee employee = null;
                    Shift shift = null;
                    foreach (Employee emp in edb.GetEmployees()) {
                        if ((int)dr[1] == emp.ID) {
                            employee = emp;
                             shift = new Shift((int)dr[0], employee, (ShiftType)dr[2], (DateTime)dr[3]);
                        }
                    }
                   

                    shifts.Add(shift);
                }
                
                return shifts;
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

        public List<int> GetAvailability(int id)
        {
            string conn = "Server=studmysql01.fhict.local;Uid=dbi463896;Database=dbi463896;Pwd=VuiManqk; SSL Mode=None;";
            MySqlConnection con = new MySqlConnection(conn);
            try
            {
                
                string sql7 = "SELECT * FROM availability_shift_reletion_prj where employeeId = @employeeId";
                List<int> availabilities = new List<int>();
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql7, con);
                cmd.Parameters.AddWithValue("@employeeId", id);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    availabilities.Add((int)dr["shiftId"]);
                }
                return availabilities;
            }
            finally
            {
                con.Close();
            }

        }
        public int GetContract(int iD)
        {
            string conn = "Server=studmysql01.fhict.local;Uid=dbi463896;Database=dbi463896;Pwd=VuiManqk; SSL Mode=None;";
            MySqlConnection con = new MySqlConnection(conn);
            string sql = "SELECT  ContractType FROM contracts_prj where EmployeeID = @id ";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", iD);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr[0].ToString().ToLower() == "student")
                    {
                        return 5;
                    }
                    if (dr[0].ToString().ToLower() == "full-time")
                    {
                        return 10;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                con.Close();
            }
            return -1;
        }

        public int GetShift(string shift)
        {
            if ("Monday - Morning" == shift)
            {
                return 0;
            }
            else if ("Monday - Afternoon" == shift)
            {
                return 1;
            }
            else if ("Monday - Evening" == shift)
            {
                return 2;
            }
            else if ("Tuesday - Morning" == shift)
            {
                return 3;
            }
            else if ("Tuesday - Afternoon" == shift)
            {
                return 4;
            }
            else if ("Tuesday - Evening" == shift)
            {
                return 5;
            }
            else if ("Wednesday - Morning" == shift)
            {
                return 6;
            }
            else if ("Wednesday - Afternoon" == shift)
            {
                return 7;
            }
            else if ("Wednesday - Evening" == shift)
            {
                return 8;
            }
            else if ("Thursday - Morning" == shift)
            {
                return 9;
            }
            else if ("Thursday - Afternoon" == shift)
            {
                return 10;
            }
            else if ("Thursday - Evening" == shift)
            {
                return 11;
            }
            else if ("Friday - Morning" == shift)
            {
                return 12;
            }
            else if ("Friday - Afternoon" == shift)
            {
                return 13;
            }
            else if ("Friday - Evening" == shift)
            {
                return 14;
            }
            else if ("Saturday - Morning" == shift)
            {
                return 15;
            }
            else if ("Saturday - Afternoon" == shift)
            {
                return 16;
            }
            else if ("Saturday - Evening" == shift)
            {
                return 17;
            }
            else if ("Sunday - Morning" == shift)
            {
                return 18;
            }
            else if ("Sunday - Afternoon" == shift)
            {
                return 19;
            }
            else if ("Sunday - Evening" == shift)
            {
                return 20;
            }
            return -1;
        }

        internal List<DateTime> GetUnavaivableDate(int id)
        {
            string sql = "Select date from unavaivabledates_prj where accountId = @accountId";

            string conn = "Server=studmysql01.fhict.local;Uid=dbi463896;Database=dbi463896;Pwd=VuiManqk; SSL Mode=None;";
            MySqlConnection con = new MySqlConnection(conn);
            List<DateTime> list = new List<DateTime>();
            try
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand(sql, con);
                cmd1.Parameters.AddWithValue("@accountId", id);
                MySqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    list.Add((DateTime)dr[0]);
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
            return list;
        }

        #endregion


    }
    }
