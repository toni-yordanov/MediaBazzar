using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication
{
    class Shift
    {
        public List<Shift> shifts = new List<Shift>();
        //properties
        private static int idSeeder = 10000;
        public int Id { get; private set; }
        public Employee EmployeeOnShift { get; set; }
        public Logic.ShiftType ShiftType { get; set; }
        public DateTime Date { get; set; }
        //constructor
        public Shift(Employee employee, Logic.ShiftType shiftType, DateTime date) {
            Id = idSeeder;
            EmployeeOnShift = employee;
            ShiftType = shiftType;
            Date = date;

            idSeeder++ ;
        }
        //add shift
        public void AddShift(Employee employee, Logic.ShiftType shiftType, DateTime date) {
            Shift shift = new Shift(employee, shiftType, date);
            shifts.Add(shift);
        }
        //edit shift
        public void EditShift(Shift shift, Employee employee, Logic.ShiftType shiftType)
        {
           
            shift.ShiftType = shiftType;
            shift.EmployeeOnShift= employee;
        }

        //public void DeleteShift(int id)
        //{
        //    Shift shift = shifts.Find(x => x.Id == id);
        //    shifts.Re(shift);
        //}


        public string ShiftInfo() {
            return $"{ShiftType} assigned to: {EmployeeOnShift}-{Id}/ {Date.Day}/{Date.Month}/{Date.Year}";
        }

        

    }
}
