using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MediaBazzarApplication.Logic;

namespace MediaBazzarApplication
{
    public partial class ShiftMakingForm : Form
    {

        List<Shift> shifts;
        List<Employee> employees;
        private int weekOfset;
        private DateTime Monday;
        private DateTime Tuesday;
        private DateTime Wednesday;
        private DateTime Thursday;
        private DateTime Friday;
        private DateTime Saturday;
        private DateTime Sunday;
        public ShiftMakingForm()
        {
            InitializeComponent();
            shifts = new List<Shift>();
            employees = new List<Employee>();
             Employee e1 = new Employee(1, "George");
            Employee e2 = new Employee(2, "Peter");
            Employee e3 = new Employee(3, "Denis");
            employees.Add(e1);
            employees.Add(e2);
            employees.Add(e3);
        }

        private void UpdateListbox() {
            lbShifts.Items.Clear();
            foreach (Shift s in shifts) {
                lbShifts.Items.Add(s.ShiftInfo());
            }
        }

        private void CreateShift() {
            DateTime date = dateTimePickerShifts.Value;
            string typeString = $"{date.DayOfWeek}{cbShiftType.Text}";
            Logic.ShiftType shiftType= (Logic.ShiftType)Enum.Parse(typeof(Logic.ShiftType), typeString);
            Shift shift = new Shift(employees.ElementAt(cbEmployees.SelectedIndex), shiftType, date);
            shifts.Add(shift);
        }


        private void btnCreateShift_Click(object sender, EventArgs e)
        {
            CreateShift();
            //Shift shift = new Shift(employees.ElementAt(cbEmployees.SelectedIndex), (ShiftType)cbShiftType.SelectedIndex);
            //shifts.Add(shift);
            UpdateListbox();
        }

        private void btnEditShift_Click(object sender, EventArgs e)
        {
            Shift shift = shifts.ElementAt(lbShifts.SelectedIndex);
            shift.EditShift(shift, employees.ElementAt(cbEmployees.SelectedIndex), (ShiftType)cbShiftType.SelectedIndex);
            UpdateListbox();
        }

        private void btnDeleteShift_Click(object sender, EventArgs e)
        {
            int id = lbShifts.SelectedIndex;
            shifts.RemoveAt(id);
            UpdateListbox();
        }

        private void ShiftMakingForm_Load(object sender, EventArgs e)
        {
            cbShiftType.Items.Add("Morning");
            cbShiftType.Items.Add("Afternoon");
            cbShiftType.Items.Add("Evening");

            foreach (Employee employee in employees) {
                cbEmployees.Items.Add($"{employee.Firstname}, {employee.ID}");
            }
            
        }

        private void CalendarLoad() {

            lbMondayMorning.Items.Clear();
            lbMondayAfternoon.Items.Clear();
            lbMondayEvening.Items.Clear();

            lbTuesdayMorning.Items.Clear();
            lbTuesdayAfternoon.Items.Clear();
            lbTuesdayAfternoon.Items.Clear();

            lbWednesdayMorning.Items.Clear();
            lbWednesdayAfternoon.Items.Clear();
            lbWednesdayEvening.Items.Clear();

            lbThursdayMorning.Items.Clear();
            lbThursdayAfternoon.Items.Clear();
            lbThursdayEvening.Items.Clear();

            lbFridayMorning.Items.Clear();
            lbFridayAfternoon.Items.Clear();
            lbFridayEvening.Items.Clear();

            lbSaturdayMorning.Items.Clear();
            lbSaturdayAfternoon.Items.Clear();
            lbSaturdayEvening.Items.Clear();

            lbSundayMorning.Items.Clear();
            lbSundayAfternoon.Items.Clear();
            lbSundayEvening.Items.Clear();


            Monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday + weekOfset);
            Tuesday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Tuesday + weekOfset);
            Wednesday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Wednesday + weekOfset);
            Thursday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Thursday + weekOfset);
            Friday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Friday + weekOfset);
            Saturday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday + weekOfset);
            Sunday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 7 + weekOfset);


            foreach (Shift s in shifts) {
                
                if (s.ShiftType == ShiftType.MondayMorning && s.Date.Date == Monday.Date) {
                    lbMondayMorning.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}") ;
                }
                if (s.ShiftType == ShiftType.MondayAfternoon && s.Date.Date == Monday.Date) {
                    lbMondayAfternoon.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.MondayEvening && s.Date.Date == Monday.Date) {
                    lbMondayEvening.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }

                if (s.ShiftType == ShiftType.TuesdayMorning && s.Date.Date == Tuesday.Date) {
                    lbTuesdayMorning.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.TuesdayAfternoon && s.Date.Date == Tuesday.Date) {
                    lbTuesdayAfternoon.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.TuesdayEvening && s.Date.Date == Tuesday.Date) {
                    lbTuesdayEvening.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }

                if (s.ShiftType == ShiftType.WednesdayMorning && s.Date.Date == Wednesday.Date) {
                    lbWednesdayMorning.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.WednesdayAfternoon && s.Date.Date == Wednesday.Date) {
                    lbWednesdayAfternoon.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.WednesdayEvening && s.Date.Date == Wednesday.Date) {
                    lbWednesdayEvening.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }

                if (s.ShiftType == ShiftType.ThursdayMorning && s.Date.Date == Thursday.Date) {
                    lbThursdayMorning.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.ThursdayAfternoon && s.Date.Date == Thursday.Date) {
                    lbThursdayAfternoon.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.ThursdayEvening && s.Date.Date == Thursday.Date) {
                    lbThursdayEvening.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }

                if (s.ShiftType == ShiftType.FridayMorning && s.Date.Date == Friday.Date) {
                    lbFridayMorning.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");

                }
                if (s.ShiftType == ShiftType.FridayAfternoon && s.Date.Date == Friday.Date) {
                    lbFridayAfternoon.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.FridayEvening && s.Date.Date == Friday.Date) {
                    lbFridayEvening.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }

                if (s.ShiftType == ShiftType.SaturdayMorning && s.Date.Date == Saturday.Date) {
                    lbSaturdayMorning.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.SaturdayAfternoon && s.Date.Date == Saturday.Date) {
                    lbSaturdayAfternoon.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.SaturdayEvening && s.Date.Date == Saturday.Date) {
                    lbSaturdayEvening.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }

                if (s.ShiftType == ShiftType.SundayMorning && s.Date.Date == Sunday.Date) {
                    lbSundayMorning.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.SundayAfternoon && s.Date.Date == Sunday.Date) {
                    lbSundayAfternoon.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                if (s.ShiftType == ShiftType.SundayEvening && s.Date.Date== Sunday.Date) {
                    lbSundayEvening.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
                }
                lbSundayEvening.Items.Add($"{s.EmployeeOnShift.Firstname} {s.EmployeeOnShift.Lastname}");
            }
            
            label31.Text = $"{Monday.Day}.{Monday.Month}.{Monday.Year} - {Sunday.Day}.{Sunday.Month}{Sunday.Year}";

        }

        private void btnPreviousWeek_Click(object sender, EventArgs e)
        {
            weekOfset -= 7;
            CalendarLoad();
        }

        private void btnCreateShift_Click_1(object sender, EventArgs e)
        {
            CreateShift();
          
            UpdateListbox();
            CalendarLoad();
            
        }

        private void btnEditShift_Click_1(object sender, EventArgs e)
        {
            Shift shift = shifts.ElementAt(lbShifts.SelectedIndex);
            shift.EditShift(shift, employees.ElementAt(cbEmployees.SelectedIndex), (ShiftType)cbShiftType.SelectedIndex);
            UpdateListbox();
        }

        private void btnDeleteShift_Click_1(object sender, EventArgs e)
        {
            int id = lbShifts.SelectedIndex;
            shifts.RemoveAt(id);
            UpdateListbox();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            weekOfset += 7;
            CalendarLoad();
        }
    }
}
