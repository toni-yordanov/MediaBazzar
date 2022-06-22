using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using MediaBazzarApplication.Logic;
using System.Windows.Forms;

namespace MediaBazzarApplication.DAL
{
    class EmployeeDB
    {
        public DataAccess conn;
        public Employee e;


        public List<Employee> employees;
        public List<Contract> contracts; 
        public EmployeeDB()
        {
            conn = new DataAccess();

            employees = new List<Employee>();
            contracts = new List<Contract>();
        }



        #region Employees
        public void AddEmployeeWithoutContract
            (string name, string lastname, DateTime birth, string username,
            string password, string gender, string bsn, string adress,
            string city, string country, string postal, string email, 
            string phone, string departmentname)
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

        //adding employee with contract
        public void AddEmployeeWithContract
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
                    int ID = Convert.ToInt32(reader["ID"]);
                    string Firstname = (reader["Firstname"]).ToString();
                    string Lastname = (reader["Lastname"]).ToString();
                    string DateOfBirth = (reader["Dateofbirth"]).ToString();
                    string Gender = (reader["Gender"]).ToString();
                    string BSN = (reader["BSN"]).ToString();
                    string PhoneNumber = (reader["Phonenumber"]).ToString();
                    string Address = (reader["Adress"]).ToString();
                    string PostalCode = (reader["Postalcode"]).ToString();
                    string Email = (reader["Email"]).ToString();
                    string City = (reader["City"]).ToString();
                    string Country = (reader["Country"]).ToString();
                    string Username = (reader["Username"]).ToString();
                    string DepartmentName = (reader["Departmentname"]).ToString();
                    Employee emp = new Employee(ID,Firstname, Lastname, DateOfBirth, Gender, BSN, PhoneNumber, Address, PostalCode, Email, City, Country, Username, DepartmentName);
                    
                    employees.Add(emp);
                }

                this.employees = employees;
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

        public List<Employee> GetEmployeeByName(string name)
        {
            List<Employee> employeesbyname = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.Firstname == name)
                {
                    employeesbyname.Add(employee);
                }
            }

            return employeesbyname;
        }

        public List<Employee> GetEmployeeById(int id)
        {
            List<Employee> employeesbyid = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.ID == id)
                {
                    employeesbyid.Add(employee);
                }
            }
            return employeesbyid; 
        }

        public List<Employee> GetEmployeesbyDepartement(string depname)
        {
            List<Employee> employeesbydep = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.DepartmentName == depname)
                {
                    employeesbydep.Add(employee);
                }
            }
            return employeesbydep;
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
                throw e;
            }
            finally
            {
                databaseConnection.Close();
            }
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
                MessageBox.Show("There was a problem");
                return null; 
            }
            finally
            {
                databaseConnection.Close();
            }
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
                        Active = Convert.ToBoolean(reader["Active"]),
                        Terminated = Convert.ToBoolean(reader["Terminated"]),
                    };
                    contracts.Add(c);
                }
                this.contracts = contracts;
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
        public Contract GetContract(int id)
        {
            List<Contract> contracts = GetContracts();
            foreach (Contract contract in contracts)
            {
                if (contract.ContractID == id)
                {
                    return contract;
                }
            }

            return null; 
        }

        public List<Contract> GetActiveContracts()
        {
            List<Contract> activecontracts = new List<Contract>();
            foreach (Contract contract in contracts)
            {
                if (contract.Active is true)
                {
                    activecontracts.Add(contract);
                }

            }
            if (activecontracts.Count != 0)
            {
                return activecontracts;
            }
            else
            {
                return null;
            }
        }

        public List<Contract> GetTerminatedContracts()
        {
            List<Contract> activecontracts = new List<Contract>();
            foreach (Contract contract in contracts)
            {
                if (contract.Terminated is true)
                {
                    activecontracts.Add(contract);
                }

            }
            if (activecontracts.Count != 0)
            {
                return activecontracts;
            }
            else
            {
                return null;
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

        public void TermintateContract(int id)
        {
            MySqlConnection databaseConnection = new MySqlConnection(conn.Databaseconnection);
            string TerminateContractByid = DBQueries.TerminateContractWithId;
            MySqlCommand commandDatabase = new MySqlCommand(TerminateContractByid, databaseConnection);

            List<Contract> contracts = new List<Contract>();
            try
            {
                databaseConnection.Open();

                commandDatabase.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = commandDatabase.ExecuteReader();
                if (reader is null)
                {
                    return ;
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

        





        #endregion

    }
}
