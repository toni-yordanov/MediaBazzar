
using MediaBazzarWebsite.Classes;
using MySql.Data.MySqlClient;

namespace MediaBazzarWebsite.Data
{
    public class DataHelper
    {
        private string conn;
        MySqlConnection con;

        public DataHelper()
        {
            conn = "Server=studmysql01.fhict.local;Uid=dbi463896;Database=dbi463896;Pwd=VuiManqk; SSL Mode=None;";
            con = new MySqlConnection(conn);
        }

        public List<Employee> GetEmployees()
        {
            
            string sql = "SELECT  ID ,  Firstname ,  Lastname ,  Phonenumber ,  Adress ,  Postalcode ,  Email ,  " +
                "Password,  City ,  Country ,  Username  ,  Departmentname, Wage FROM employees_prj ";
            List<Employee> list = new List<Employee>();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee account = new Employee(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),
                dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), dr[12].ToString());
                    list.Add(account);
                }
            }
            catch (Exception ex)
            {
                //return null;
            }
            finally
            {
                con.Close();
            }
            return list;
        }

        public bool UpdateAccount(int id, string phone, string address, string email)
        {
            try
            {
                String sql = "UPDATE employees_prj SET Phonenumber = @Phone_Number, Adress = @Address, Email = @Email WHERE ID = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                this.con.Open();
                cmd.Parameters.AddWithValue("@Phone_Number", phone);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                this.con.Close();
            }

        }
    }
}
