using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazzarApplication
{
   public class ShiftManager
    {

        public  List<Shift> _shifts = new List<Shift>();

        public void AddShift(Employee employee, Logic.ShiftType shiftType, DateTime date)
        {
            Shift shift = new Shift(employee, shiftType, date);
            _shifts.Add(shift);
        }


        public void EditShift(List<Shift> shifts, List<Employee> employees, Logic.ShiftType shiftType, DateTime dateTime)
        {
            List<Shift> shiftsPassed = new List<Shift>();
           // List<Shift> shiftsForEdit = shifts;
            List<Employee> employeesLeft = new List<Employee>();
            foreach (Shift s in shifts) {

                foreach (Employee e in employees)
                {
                    if (s.Employee == e)
                    {
                       // shiftsPassed.Add(s);
                       // shiftsForEdit.Remove(s);
                        if (employeesLeft.Contains(e)) {
                            employeesLeft.Remove(e);
                        }
                    }
                    else {
                        //shiftsForEdit.Add(s);
                        employeesLeft.Add(e);
                    }
                }
            }//All the shifts that are allready fine are separated into the list shiftPassed and the employees that are not in the shiftPassed list yet are separated in the list employeesLeft


            foreach (Employee e in employees) {
                Shift shift = new Shift(e, shiftType, dateTime);
                shiftsPassed.Add(shift);
            }//The employees from employeesLeft are in shiftsPassed

            foreach (Shift s in shiftsPassed) {
                s.ShiftType = shiftType;
                s.Date = dateTime;
                _shifts.Add(s);
            }//Put all the passed shifts to the main list with the new dateTime/shiftType

            foreach (Shift shift in shifts){
                _shifts.Remove(shift);
            }//removes from the original list all the shifts from the list passed to the method(it either removes the shifts that are edited or the shifts that are fine are allready passed to the main list to prevent double the data)
            //foreach (Employee e in employees)
            //{

            //}
        }




    }
}
