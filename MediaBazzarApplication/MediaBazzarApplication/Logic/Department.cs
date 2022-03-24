using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication.Logic
{
    public class Department
    {
        

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public Department()
        {

        }


        public Department(int departmentId, string departmentName)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
        }




        public override string ToString()
        {
            return $" ID: {DepartmentId} / {DepartmentName} ";
        }



    }
}
