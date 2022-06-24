using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication.Logic
{
    public class DepartmentChangeRequest
    {

        public int RequestID { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public string PastDepartment { get; set; }
        public string RequestedDepartment { get; set; }
        public string Status { get; set; }
        public DepartmentChangeRequest()
        {

        }

        public DepartmentChangeRequest(string employeeName, int employeeID, string pastDepartment, string requestedDepartment, string status)
        {
            EmployeeName = employeeName;
            EmployeeID = employeeID;
            PastDepartment = pastDepartment;
            RequestedDepartment = requestedDepartment;
            Status = status;
        }

        public DepartmentChangeRequest(int requestID, string employeeName, int employeeID, string pastDepartment, string requestedDepartment, string status)
        {
            RequestID = requestID;
            EmployeeName = employeeName;
            EmployeeID = employeeID;
            PastDepartment = pastDepartment;
            RequestedDepartment = requestedDepartment;
            Status = status;
        }

        
    }
}
