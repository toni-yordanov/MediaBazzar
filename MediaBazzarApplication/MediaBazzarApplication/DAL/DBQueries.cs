using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MediaBazzarApplication.DAL
{
    public static class DBQueries
    {

        //employees
        #region
        public static readonly string AddEmployee = "INSERT INTO `employees_prj`(`Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Password`, `Departmentname`, `Position`,`Contracttype`, `Wage`) VALUES (@name, @lastname, @dateofbirth, @gender, @bsn, @phone, @adress, @postalcode, @email, @city, @country, @username, @password, @depname, @position, @contracttype, @wage)";
        public static readonly string GetEmployees = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Departmentname`, `Position`, `Contracttype`, `Wage` FROM `employees_prj`";
        public static readonly string GetEmployeeswithpassword = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Departmentname`, `Position`, `Contracttype`, `Wage` FROM `employees_prj`";

        public static readonly string GetEmployeesbyName = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Departmentname`, `Position`, `Contracttype`, `Wage` FROM `employees_prj` WHERE `Firstname` = @name";
        public static readonly string GetEmployeesbyID = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Departmentname`, `Position`, `Contracttype`, `Wage` FROM `employees_prj` WHERE `ID` = @id";
        public static readonly string GetEmployeesbyDepartment = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Departmentname`, `Position`, `Contracttype`, `Wage` FROM `employees_prj` WHEREvvv `Departmentname` = @name";







        #endregion

        //Departments

        #region


        public static readonly string AddDepartment = "INSERT INTO `departments_prj`(`Departmentname`) VALUES (@name)"; 
        public static readonly string GetDepartments = "SELECT `ID`, `Departmentname` FROM `departments_prj`";
        

        #endregion




    }
}
