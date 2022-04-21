using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication.Logic
{
    public class Contract
    {

        public int ContractID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public string ContractType { get; set; }
        public double Wage { get; set; }

        public int MinWorkingHours { get; set; }

        public bool Active { get; set; }


        public Contract()
        {

        }

        public Contract(int employeeID, DateTime startDate, DateTime endDate, string departmentName, string position, string contractType, double wage)
        {
            EmployeeID = employeeID;
            StartDate = startDate;
            EndDate = endDate;
            DepartmentName = departmentName;
            Position = position;
            ContractType = contractType;
            Wage = wage;
        }

        public Contract(int contractID, int employeeID, DateTime startDate, DateTime endDate, string departmentName, string position, string contractType, double wage)
        {
            ContractID = contractID;
            EmployeeID = employeeID;
            StartDate = startDate;
            EndDate = endDate;
            DepartmentName = departmentName;
            Position = position;
            ContractType = contractType;
            Wage = wage;
        }

        public Contract(int contractID, int employeeID, DateTime startDate, DateTime endDate, string departmentName, string position, string contractType, double wage, int minWorkingHours, bool active)
        {
            ContractID = contractID;
            EmployeeID = employeeID;
            StartDate = startDate;
            EndDate = endDate;
            DepartmentName = departmentName;
            Position = position;
            ContractType = contractType;
            Wage = wage;
            MinWorkingHours = minWorkingHours;
            Active = active;
        }
        public Contract(int employeeID, DateTime startDate, DateTime endDate, string departmentName, string position, string contractType, double wage, bool active)
        {
            EmployeeID = employeeID;
            StartDate = startDate;
            EndDate = endDate;
            DepartmentName = departmentName;
            Position = position;
            ContractType = contractType;
            Wage = wage;
            Active = active;
        }

        public override string ToString()
        {
            return $"ID: {ContractID} Employee :{EmployeeID}";
        }
    }
}
