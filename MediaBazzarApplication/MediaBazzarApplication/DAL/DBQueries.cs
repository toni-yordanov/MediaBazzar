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
        public static readonly string AddEmployee = "INSERT INTO employees_prj(Firstname, Lastname, Dateofbirth, Gender, BSN, Phonenumber, Adress, Postalcode, Email, City, Country, Username, Password, Departmentname) VALUES (@name, @lastname, @dateofbirth, @gender, @bsn, @phone, @adress, @postalcode, @email, @city, @country, @username, @password, @depname)";
        public static readonly string GetEmployees = "SELECT ID, Firstname, Lastname, Dateofbirth, Gender, BSN, Phonenumber, Adress, Postalcode, Email, City, Country, Username, Departmentname FROM employees_prj";
        public static readonly string GetEmployeeswithpassword = "SELECT `ID`, `Firstname`, `Lastname`, `Dateofbirth`, `Gender`, `BSN`, `Phonenumber`, `Adress`, `Postalcode`, `Email`, `City`, `Country`, `Username`, `Password`, `Departmentname` FROM `employees_prj`";

        public static readonly string GetEmployeesbyName = "SELECT ID, Firstname, Lastname, Dateofbirth, Gender, BSN, Phonenumber, Adress, Postalcode, Email, City, Country, Username, Departmentname, Position, Contracttype, Wage FROM employees_prj WHERE Firstname = @name";
        public static readonly string GetEmployeesbyID = "SELECT ID, Firstname, Lastname, Dateofbirth, Gender, BSN, Phonenumber, Adress, Postalcode, Email, City, Country, Username, Departmentname FROM employees_prj WHERE ID = @id";
        public static readonly string GetEmployeesbyDepartment = "SELECT ID, Firstname, Lastname, Dateofbirth, Gender, BSN, Phonenumber, Adress, Postalcode, Email, City, Country, Username, Departmentname, Position, Contracttype, Wage FROM employees_prj WHERE Departmentname = @name";







        #endregion


        //Contracts
        #region Contracts

        public static readonly string AddContract = "INSERT INTO contracts_prj(EmployeeID, StartDate, EndDate, DepartmentName, Position, ContractType, Wage, Active) VALUES " +
            "                                                                   (@id , @start , @end , @depname , @position , @type , @wage , @active)"; 
        public static readonly string GetContracts = "SELECT ContractID, EmployeeID, StartDate, EndDate, DepartmentName, Position, ContractType, Wage, Active FROM contracts_prj";
        public static readonly string GetContractswithId = "SELECT ContractID, EmployeeID, StartDate, EndDate, DepartmentName, Position, ContractType, Wage, Active FROM contracts_prj WHERE EmployeeID =  @id";
        public static readonly string GetSpesificContract = "SELECT ContractID, EmployeeID, StartDate, EndDate, DepartmentName, Position, ContractType, Wage, Active FROM contracts_prj WHERE ContractID = @id";

        public static readonly string GetContractsLogin = "SELECT EmployeeID, Position, FROM contracts_prj";


        #endregion
        //Departments

        #region Departments


        public static readonly string AddDepartment = "INSERT INTO departments_prj(Departmentname) VALUES (@name)"; 
        public static readonly string GetDepartments = "SELECT ID, Departmentname FROM departments_prj";


        #endregion

        //shifts
        #region Shifts
        public static readonly string AddShift = "INSERT INTO emp_shift_relation_prj(empId, shifId, date) VALUES (@empId, @shifId, @date)";
        public static readonly string GetShifts = "SELECT id, empId, shifId, date FROM emp_shift_relation_prj";
        public static readonly string RemoveShift = "DELETE  FROM emp_shift_relation_prj WHERE id = @id ";
        #endregion

        //department change requests 
        #region Department Change Request

        public static readonly string AddRequest = "INSERT INTO `departmentchangerequest`( `EmployeeName`, `EmployeeID`, `PastDepartment`, `RequestedDepartment`, `Status`) " +
            "                                                                           VALUES (@name, @id, @past, @request ,'Unanswered')";
        public static readonly string UpdateRequest = "UPDATE `departmentchangerequest` SET `Status`= @status WHERE `EmployeeID` = @id";
        public static readonly string GetRequests = "SELECT `RequestID`, `EmployeeName`, `EmployeeID`, `PastDepartment`, `RequestedDepartment`, `Status` FROM `departmentchangerequest`"; 



        #endregion


    }
}
