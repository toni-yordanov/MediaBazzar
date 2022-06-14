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
        #region Employees
        public static readonly string AddEmployee = "INSERT INTO `employees_prj`(`Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Password`, `Departmentname`) VALUES (@name, @lastname, @dateofbirth, @gender, @bsn, @phone, @adress, @postalcode, @email, @city, @country, @username, @password, @depname)";
        public static readonly string GetEmployees = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Departmentname` FROM `employees_prj`";
        public static readonly string GetEmployeeswithpassword = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Password`, `Departmentname` FROM `employees_prj`";

        public static readonly string GetEmployeesbyName = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Departmentname`, `Position`, `Contracttype`, `Wage` FROM `employees_prj` WHERE `Firstname` = @name";
        public static readonly string GetEmployeesbyID = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Departmentname`, `Position`, `Contracttype`, `Wage` FROM `employees_prj` WHERE `ID` = @id";
        public static readonly string GetEmployeesbyDepartment = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Departmentname`, `Position`, `Contracttype`, `Wage` FROM `employees_prj` WHEREvvv `Departmentname` = @name";







        #endregion


        //Contracts
        #region Contracts

        public static readonly string AddContract = "INSERT INTO `contracts_prj`(`EmployeeID`, `StartDate`, `EndDate`, `DepartmentName`, `Position`, `ContractType`, `Wage`, `Active`) VALUES " +
            "                                                                   (@id , @start , @end , @depname , @position , @type , @wage , @active)"; 
        public static readonly string GetContracts = "SELECT `ContractID`, `EmployeeID`, `StartDate`, `EndDate`, `DepartmentName`, `Position`, `ContractType`, `Wage`, `Active`, `Terminated` FROM `contracts_prj`";
        public static readonly string GetContractswithId = "SELECT `ContractID`, `EmployeeID`, `StartDate`, `EndDate`, `DepartmentName`, `Position`, `ContractType`, `Wage`, `Active` FROM `contracts_prj` WHERE EmployeeID =  @id";
        public static readonly string GetSpesificContract = "SELECT `ContractID`, `EmployeeID`, `StartDate`, `EndDate`, `DepartmentName`, `Position`, `ContractType`, `Wage`, `Active` FROM `contracts_prj` WHERE ContractID = @id";
        public static readonly string TerminateContractWithId = "UPDATE `contracts_prj` SET `Terminated`= true WHERE ContractID = @id";
        public static readonly string GetActiveContracts = "SELECT `ContractID`, `EmployeeID`, `StartDate`, `EndDate`, `DepartmentName`, `Position`, `ContractType`, `Wage`, `Active`, `Terminated` FROM `contracts_prj` WHERE `Active` = 1";
        public static readonly string GetTerminatedContracts = "SELECT `ContractID`, `EmployeeID`, `StartDate`, `EndDate`, `DepartmentName`, `Position`, `ContractType`, `Wage`, `Active`, `Terminated` FROM `contracts_prj` WHERE `Terminated` = 1 ";



        #endregion
        //Departments

        #region Departments


        public static readonly string AddDepartment = "INSERT INTO `departments_prj`(`Departmentname`) VALUES (@name)"; 
        public static readonly string GetDepartments = "SELECT `ID`, `Departmentname` FROM `departments_prj`";
        

        #endregion




    }
}
