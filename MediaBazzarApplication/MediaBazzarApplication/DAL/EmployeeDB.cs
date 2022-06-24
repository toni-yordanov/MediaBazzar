using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using MediaBazzarApplication.Logic;

namespace MediaBazzarApplication.DAL
{
    class EmployeeDB
    {
        public DataAccess conn;
        public Employee e;
        public List<Contract> contracts;
        public List<DepartmentChangeRequest> requests;

        public EmployeeDB()
        {
            conn = new DataAccess();
            contracts = GetContracts();
            requests = GetDepartmentChangeRequests();
        }



        #region Employees
        public void AddEmployee
            (string name, string lastname, DateTime birth, string username,
            string password, string gender, string bsn, string adress, string city, string country,
            string postal, string email, string phone, string departmentname)
        {
            
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string addemployeequery = DBQueries.AddEmployee;
            MySqlCommand commandDatabase = new MySqlCommand(addemployeequery, databaseConnection);
            try
            {
                commandDatabase.Parameters.AddWithValue("@name", name);
                commandDatabase.Parameters.AddWithValue("@lastname", lastname);
                commandDatabase.Parameters.AddWithValue("@dateofbirth", birth);
                commandDatabase.Parameters.AddWithValue("@gender", gender);
                commandDatabase.Parameters.AddWithValue("@bsn", bsn);
                commandDatabase.Parameters.AddWithValue("@phone", phone);
                commandDatabase.Parameters.AddWithValue("@adress", adress);
                commandDatabase.Parameters.AddWithValue("@postalcode", postal);
                commandDatabase.Parameters.AddWithValue("@email", email);
                commandDatabase.Parameters.AddWithValue("@city", city);
                commandDatabase.Parameters.AddWithValue("@country", country);
                commandDatabase.Parameters.AddWithValue("@username", username);
                commandDatabase.Parameters.AddWithValue("@password", password);
                commandDatabase.Parameters.AddWithValue("@depname", departmentname);
            




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

        public List<Employee> GetEmployeesLogin()
        {
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string GetEmployees = DBQueries.GetEmployeeswithpassword;
            MySqlCommand commandDatabase = new MySqlCommand(GetEmployees, databaseConnection);

            List<Employee> employees = new List<Employee>();
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

                    Employee emp = new Employee()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Firstname = (reader["Firstname"]).ToString(),
                        Lastname = (reader["Lastname"]).ToString(),
                        DateOfBirth = (reader["Dateofbirth"]).ToString(),
                        Gender = (reader["Gender"]).ToString(),
                        BSN = (reader["BSN"]).ToString(),
                        PhoneNumber = (reader["Phonenumber"]).ToString(),
                        Address = (reader["Adress"]).ToString(),
                        PostalCode = (reader["Postalcode"]).ToString(),
                        Email = (reader["Email"]).ToString(),
                        City = (reader["City"]).ToString(),
                        Country = (reader["Country"]).ToString(),
                        Username = (reader["Username"]).ToString(),
                        Password = (reader["Password"]).ToString(),
                        DepartmentName = (reader["Departmentname"]).ToString(),
                        


                    };
                    employees.Add(emp);
                }

                return employees;
            }
            catch (Exception e)
            {

            }
            finally
            {
                databaseConnection.Close();
            }
            return employees;
        }
        
        public List<Employee> GetEmployees()
        {
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string GetEmployees = DBQueries.GetEmployees;
            MySqlCommand commandDatabase = new MySqlCommand(GetEmployees, databaseConnection);

            List<Employee> employees = new List<Employee>();
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

                    Employee emp = new Employee()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Firstname = (reader["Firstname"]).ToString(),
                        Lastname = (reader["Lastname"]).ToString(),
                        DateOfBirth = (reader["Dateofbirth"]).ToString(),
                        Gender = (reader["Gender"]).ToString(),
                        BSN = (reader["BSN"]).ToString(),
                        PhoneNumber = (reader["Phonenumber"]).ToString(),
                        Address = (reader["Adress"]).ToString(),
                        PostalCode = (reader["Postalcode"]).ToString(),
                        Email = (reader["Email"]).ToString(),
                        City = (reader["City"]).ToString(),
                        Country = (reader["Country"]).ToString(),
                        Username = (reader["Username"]).ToString(),
                        DepartmentName = (reader["Departmentname"]).ToString(),
                     
                       
                    };
                    employees.Add(emp);
                }

                return employees;
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                databaseConnection.Close();
            }
            return employees;
        }



        public List<Employee> GetEmployeesbyName(string name)
        {
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string GetEmployees = DBQueries.GetEmployeesbyName;
            MySqlCommand commandDatabase = new MySqlCommand(GetEmployees, databaseConnection);

            List<Employee> employees = new List<Employee>();
            try
            {
                databaseConnection.Open();

                commandDatabase.Parameters.AddWithValue("@name", name);

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

                    Employee emp = new Employee()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Firstname = (reader["Firstname"]).ToString(),
                        Lastname = (reader["Lastname"]).ToString(),
                        DateOfBirth = (reader["Dateofbirth"]).ToString(),
                        Gender = (reader["Gender"]).ToString(),
                        BSN = (reader["BSN"]).ToString(),
                        PhoneNumber = (reader["Phonenumber"]).ToString(),
                        Address = (reader["Adress"]).ToString(),
                        PostalCode = (reader["Postalcode"]).ToString(),
                        Email = (reader["Email"]).ToString(),
                        City = (reader["City"]).ToString(),
                        Country = (reader["Country"]).ToString(),
                        Username = (reader["Username"]).ToString(),
                        DepartmentName = (reader["Departmentname"]).ToString(),
                        Position = reader["Position"].ToString(),
                        Contracttype = (reader["Contracttype"]).ToString(),
                        Wage = Convert.ToDouble(reader["Wage"]),
                        
                    };
                    employees.Add(emp);
                }

                return employees;
            }
            catch (Exception e)
            {
                return null; 
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public List<Employee> GetEmployeesname (string name)
        {
            List<Employee> empllyees = new List<Employee>();
            foreach (Employee employee in GetEmployees())
            {
                if (employee.Firstname == name)
                {
                    empllyees.Add(employee);
                }
            }

            return empllyees;
        }


        public List<Employee> GetEmployeesbyID(int id)
        {
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string GetEmployeesByid = DBQueries.GetEmployeesbyID;
            MySqlCommand commandDatabase = new MySqlCommand(GetEmployeesByid, databaseConnection);

            List<Employee> employees = new List<Employee>();
            try
            {
                databaseConnection.Open();

                commandDatabase.Parameters.AddWithValue("@id", id);

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

                    Employee emp = new Employee()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Firstname = (reader["Firstname"]).ToString(),
                        Lastname = (reader["Lastname"]).ToString(),
                        DateOfBirth = (reader["Dateofbirth"]).ToString(),
                        Gender = (reader["Gender"]).ToString(),
                        BSN = (reader["BSN"]).ToString(),
                        PhoneNumber = (reader["Phonenumber"]).ToString(),
                        Address = (reader["Adress"]).ToString(),
                        PostalCode = (reader["Postalcode"]).ToString(),
                        Email = (reader["Email"]).ToString(),
                        City = (reader["City"]).ToString(),
                        Country = (reader["Country"]).ToString(),
                        Username = (reader["Username"]).ToString(),
                        DepartmentName = (reader["Departmentname"]).ToString(),
                      

                    };
                    employees.Add(emp);
                }

                return employees;
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


        public List<Employee> GetEmployeesbyDepartment(string departmentname)
        {
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string GetEmployees = DBQueries.GetEmployeesbyDepartment;
            MySqlCommand commandDatabase = new MySqlCommand(GetEmployees, databaseConnection);

            List<Employee> employees = new List<Employee>();
            try
            {
                databaseConnection.Open();

                commandDatabase.Parameters.AddWithValue("@name", departmentname);

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

                    Employee emp = new Employee()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Firstname = (reader["Firstname"]).ToString(),
                        Lastname = (reader["Lastname"]).ToString(),
                        DateOfBirth = (reader["Dateofbirth"]).ToString(),
                        Gender = (reader["Gender"]).ToString(),
                        BSN = (reader["BSN"]).ToString(),
                        PhoneNumber = (reader["Phonenumber"]).ToString(),
                        Address = (reader["Adress"]).ToString(),
                        PostalCode = (reader["Postalcode"]).ToString(),
                        Email = (reader["Email"]).ToString(),
                        City = (reader["City"]).ToString(),
                        Country = (reader["Country"]).ToString(),
                        Username = (reader["Username"]).ToString(),
                        DepartmentName = (reader["Departmentname"]).ToString(),
                        Position = (reader["Position"]).ToString(),
                        Contracttype = (reader["Contracttype"]).ToString(),
                        Wage = Convert.ToDouble(reader["Wage"]),

                    };
                    employees.Add(emp);
                }

                return employees;
            }
            catch (Exception e)
            {
                return null; 
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public List<Employee> GetEmployeesbydep(string depname)
        {
            List<Employee> employees = new List<Employee>();
            foreach (Employee item in GetEmployees())
            {
                if (item.DepartmentName == depname)
                {
                    employees.Add(item);
                }
            }

            return employees;
        }
        #endregion

        #region Contracts 
        public void AddContract(Contract c)
        {

            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string addcontractquery = DBQueries.AddContract;
            MySqlCommand commandDatabase = new MySqlCommand(addcontractquery, databaseConnection);
            try
            {
                commandDatabase.Parameters.AddWithValue("@id", c.EmployeeID);
                commandDatabase.Parameters.AddWithValue("@start", c.StartDate);
                commandDatabase.Parameters.AddWithValue("@end", c.EndDate);
                commandDatabase.Parameters.AddWithValue("@depname", c.DepartmentName);
                commandDatabase.Parameters.AddWithValue("@position", c.Position);
                commandDatabase.Parameters.AddWithValue("@type", c.ContractType);
                commandDatabase.Parameters.AddWithValue("@wage", c.Wage);
                commandDatabase.Parameters.AddWithValue("@active", c.Active);



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

        public List<Contract> GetContracts()
        {
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string GetContracts = DBQueries.GetContracts;
            MySqlCommand commandDatabase = new MySqlCommand(GetContracts, databaseConnection);

            List<Contract> contracts = new List<Contract>();
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

                    Contract c = new Contract()
                    {
                        ContractID = Convert.ToInt32(reader["ContractID"]),
                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        DepartmentName = reader["DepartmentName"].ToString(),
                        Position = reader["Position"].ToString(),
                        ContractType = reader["ContractType"].ToString(),
                        Wage = Convert.ToDouble(reader["Wage"]),
                        Active = Convert.ToBoolean(reader["Active"])
                    };
                    contracts.Add(c);
                }

                return contracts;
            }
            catch (Exception e)
            {
                return null;  
            }
            finally
            {
                databaseConnection.Close();
            }
        }

        public List<Contract> GetContractswithId(int id)
        {
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string GetContractsByid = DBQueries.GetContractswithId;
            MySqlCommand commandDatabase = new MySqlCommand(GetContractsByid, databaseConnection);

            List<Contract> contracts = new List<Contract>();
            try
            {
                databaseConnection.Open();

                commandDatabase.Parameters.AddWithValue("@id", id);

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

                    Contract c = new Contract()
                    {
                        ContractID = Convert.ToInt32(reader["ContractID"]),
                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        DepartmentName = reader["DepartmentName"].ToString(),
                        Position = reader["Position"].ToString(),
                        ContractType = reader["ContractType"].ToString(),
                        Wage = Convert.ToDouble(reader["Wage"]),
                        Active = Convert.ToBoolean(reader["Active"])
                    };
                    contracts.Add(c);
                }

                return contracts;
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






        #endregion

        #region Department Change Request
        public void AddRequest(DepartmentChangeRequest d)
        {

            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string addrequest = DBQueries.AddRequest;
            MySqlCommand commandDatabase = new MySqlCommand(addrequest, databaseConnection);
            try
            {
                commandDatabase.Parameters.AddWithValue("@name", d.EmployeeName);
                commandDatabase.Parameters.AddWithValue("@id", d.EmployeeID);
                commandDatabase.Parameters.AddWithValue("@past", d.PastDepartment);
                commandDatabase.Parameters.AddWithValue("@request", d.RequestedDepartment);



                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();


                if (reader is null)
                {
                    return;
                }


            }
            catch (Exception e)
            {

                return; 

            }
            finally
            {
                databaseConnection.Close();
            }


        }
        public void EditRequest(string status, int id)
        {
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string updaterequest = DBQueries.UpdateRequest;
            MySqlCommand commandDatabase = new MySqlCommand(updaterequest, databaseConnection);
            try
            {
                commandDatabase.Parameters.AddWithValue("@status", status);
                commandDatabase.Parameters.AddWithValue("@id", id);





                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();


                if (reader is null)
                {
                    return;
                }


            }
            catch (Exception e)
            {

                return;

            }
            finally
            {
                databaseConnection.Close();
            }
        }
        public DepartmentChangeRequest Getrequest(int id)
        {
            DepartmentChangeRequest d = new DepartmentChangeRequest();
            foreach (DepartmentChangeRequest item in requests)
            {
                if (item.RequestID == id)
                {
                    d = item;  
                }
            }
            return d; 

        }
        public List<DepartmentChangeRequest> GetDepartmentChangeRequests()
        {
            
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string GetRequests = DBQueries.GetRequests;
            MySqlCommand commandDatabase = new MySqlCommand(GetRequests, databaseConnection);

            List<DepartmentChangeRequest> requests = new List<DepartmentChangeRequest>();
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
                    int requestid = Convert.ToInt32(reader[0]);
                    string name = reader[1].ToString();
                    int id = Convert.ToInt32(reader[2]);
                    string pastname = reader[3].ToString();
                    string requestedname = reader[4].ToString();
                    string status = reader[5].ToString();


                    DepartmentChangeRequest d = new DepartmentChangeRequest(requestid, name, id, pastname, requestedname, status);


                    requests.Add(d);
                }

                this.requests = requests;
                return requests;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                databaseConnection.Close();
            }
            
        }

        #endregion

    }
}
