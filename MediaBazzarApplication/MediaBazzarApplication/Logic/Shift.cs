using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication
{
   public class Shift
    {
        //public List<Shift> shifts = new List<Shift>();
        
        //properties
        private static int idSeeder = 10000;
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Logic.ShiftType ShiftType { get; set; }
        public DateTime Date { get; set; }
        //constructor
        public Shift(Employee employee, Logic.ShiftType shiftType, DateTime date) {
            Employee = employee;
            ShiftType = shiftType;
            Date = date;

        }

        public Shift(int id, Employee employee, Logic.ShiftType shiftType, DateTime date)
        {
            Id = id;
            Employee = employee;
            ShiftType = shiftType;
            Date = date;

            }
        //add shift
        //public void AddShift(Employee employee, Logic.ShiftType shiftType, DateTime date) {
        //    Shift shift = new Shift(employee, shiftType, date);
        //    shifts.Add(shift);
        //}
        //edit shift
        //public void EditShift(List<Shift> shifts, List<Employee> employees, Logic.ShiftType shiftType)
        //{

        //    foreach (Employee e in employees)
        //    {
        //        if () { }
        //    }
        //}



        //public void DeleteShift(int id)
        //{
        //    Shift shift = shifts.Find(x => x.Id == id);
        //    shifts.Re(shift);
        //}


        public string ShiftInfo() {
        
         
            return $"{ShiftType} on {Date.Day}/{Date.Month}/{Date.Year} is assigned to: {Employee}! ";
        }

        public override string ToString()
        {
            return $"{this.ShiftType} on {this.Date.Day}/{this.Date.Month}/{this.Date.Year}";
        }

        //public string EmployeesOnShift(DateTime date) {
        //    string employeesOnShift = "";

        //    }

        //    return employeesOnShift;
        //}



    }
}
