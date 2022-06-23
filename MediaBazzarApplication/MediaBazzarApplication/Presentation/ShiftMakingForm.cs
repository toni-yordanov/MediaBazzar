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
using MediaBazzarApplication.DAL;
using MediaBazzarApplication.Logic;


namespace MediaBazzarApplication
{
    public partial class ShiftMakingForm : Form
    {
        ShiftManager sm = new ShiftManager();
        EmployeeDB edb = new EmployeeDB();
        ShiftsDB sdb = new ShiftsDB();
        // List<Shift> shifts;
        List<Employee> employees;
        int selection = -2;
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
            //shifts = new List<Shift>();
            employees = edb.GetEmployees();
            //Employee e1 = new Employee(1, "George");
            //Employee e2 = new Employee(2, "Peter");
            //Employee e3 = new Employee(3, "Denis");
            //Employee e4 = new Employee(4, "Alex");
            //Employee e5 = new Employee(5, "Steven");
            //Employee e6 = new Employee(6, "Patrik");
            //Employee e7 = new Employee(7, "Marso");
            //Employee e8 = new Employee(8, "Gagaga");
            //employees.Add(e1);
            //employees.Add(e2);
            //employees.Add(e3);
            //employees.Add(e4);
            //employees.Add(e5);
            //employees.Add(e6);
            //employees.Add(e7);
            //employees.Add(e8);
            CalendarLoad();
        }

        //

        private void UpdateShiftListbox()
        {
            lbShifts.Items.Clear();
            lbEmployeesForShift.Items.Clear();
            List<Shift> Temp = sdb.GetShifts();
            foreach (Shift s1 in Temp)
            {
                string employeesOnShift = "";
                int i = 0;
                foreach (Shift s2 in Temp)
                {
                    if (s1.Date.Year == s2.Date.Year && s1.Date.DayOfYear == s2.Date.DayOfYear && s1.ShiftType == s2.ShiftType)
                    {

                        employeesOnShift += $"{s2.ToString()}({s2.Employee.ID}), ";
                        i++;
                    }
                }


                //for (int x = shifts.Count - 1; x >= 0; x--)
                //{
                //    if (s1.Date.Year == Temp[i].Date.Year && s1.Date.DayOfYear == Temp[i].Date.DayOfYear)
                //    {
                //        employeesOnShift += $"{Temp[i].Employee.Firstname} {Temp[i].Employee.Lastname}";
                //    }
                //    i++;

                //}
                if (!lbShifts.Items.Contains($"{s1.ShiftType} on {s1.Date.Day}/{s1.Date.Month}/{s1.Date.Year} is assigned to: {employeesOnShift}"))
                {
                    lbShifts.Items.Add($"{s1.ShiftType} on {s1.Date.Day}/{s1.Date.Month}/{s1.Date.Year} is assigned to: {employeesOnShift}");
                }
                //Temp.Remove(Temp[i]);




            }
            //foreach (Shift s in shifts)
            //{
            //    string employeesOnShift = "";
            //    foreach (Shift shift in shifts)
            //    {
            //        if (shift.Date.Year == s.date.Year && shift.Date.DayOfYear == date.DayOfYear)
            //        {
            //            employeesOnShift += $"{shift.Employee.Firstname} {shift.Employee.Lastname} | ";
            //        }
            //        lbShifts.Items.Add(shift.EmployeesOnShift(shift.Date));

            //}
            foreach (Employee e in employees)
            {
                lbEmployeesForShift.Items.Add($"{e.Firstname} {e.Lastname}, {e.ID}");
            }
        }

        private void CreateShift()
        {
            if (string.IsNullOrEmpty(cbShiftType.Text))
            {
                MessageBox.Show($"Please sellect shift type");
            }
            else
            {
                List<Employee> employeesOnShift = new List<Employee>();
                List<int> index = new List<int>();
                if (lbEmployeesForShift.SelectedItems.Count >= 0)
                {
                    for (int i = 0; i < lbEmployeesForShift.SelectedItems.Count; i++)
                    {
                        index.Add(lbEmployeesForShift.SelectedIndices[i]);
                    }
                }

                foreach (int i in index)
                {
                    // employeesOnShift.Add();

                    DateTime date = dateTimePickerShifts.Value;
                    string typeString = $"{date.DayOfWeek}_{cbShiftType.Text}";
                    Logic.ShiftType shiftType = (Logic.ShiftType)Enum.Parse(typeof(Logic.ShiftType), typeString);
                    Shift shift = new Shift(employees[i], shiftType, date);
                    sdb.AddShift(edb.GetEmployees().ElementAt(i), shiftType, date);
                    sm._shifts.Add(shift);

                }


            }
        }



        private void btnDeleteShift_Click(object sender, EventArgs e)
        {
            int id = lbShifts.SelectedIndex;
            sm._shifts.RemoveAt(id);
            UpdateShiftListbox();
        }

        private void ShiftMakingForm_Load(object sender, EventArgs e)
        {
            UpdateShiftListbox();

            cbShiftType.Items.Add("Morning");
            cbShiftType.Items.Add("Afternoon");
            cbShiftType.Items.Add("Evening");
            cbShiftType.SelectedIndex = 0;
            CalendarLoad();
            

        }

        private void CalendarLoad()
        {

            lbMondayMorning.Items.Clear();
            lbMondayAfternoon.Items.Clear();
            lbMondayEvening.Items.Clear();

            lbTuesdayMorning.Items.Clear();
            lbTuesdayAfternoon.Items.Clear();
            lbTuesdayEvening.Items.Clear();

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


            foreach (Shift s in sdb.GetShifts())
            {

                if (s.ShiftType == ShiftType.Monday_Morning && s.Date.Date == Monday.Date)
                {
                    lbMondayMorning.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Monday_Afternoon && s.Date.Date == Monday.Date)
                {
                    lbMondayAfternoon.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Monday_Evening && s.Date.Date == Monday.Date)
                {
                    lbMondayEvening.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }

                if (s.ShiftType == ShiftType.Tuesday_Morning && s.Date.Date == Tuesday.Date)
                {
                    lbTuesdayMorning.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Tuesday_Afternoon && s.Date.Date == Tuesday.Date)
                {
                    lbTuesdayAfternoon.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Tuesday_Evening && s.Date.Date == Tuesday.Date)
                {
                    lbTuesdayEvening.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }

                if (s.ShiftType == ShiftType.Wednesday_Morning && s.Date.Date == Wednesday.Date)
                {
                    lbWednesdayMorning.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Wednesday_Afternoon && s.Date.Date == Wednesday.Date)
                {
                    lbWednesdayAfternoon.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Wednesday_Evening && s.Date.Date == Wednesday.Date)
                {
                    lbWednesdayEvening.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }

                if (s.ShiftType == ShiftType.Thursday_Morning && s.Date.Date == Thursday.Date)
                {
                    lbThursdayMorning.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Thursday_Afternoon && s.Date.Date == Thursday.Date)
                {
                    lbThursdayAfternoon.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Thursday_Evening && s.Date.Date == Thursday.Date)
                {
                    lbThursdayEvening.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }

                if (s.ShiftType == ShiftType.Friday_Morning && s.Date.Date == Friday.Date)
                {
                    lbFridayMorning.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");

                }
                if (s.ShiftType == ShiftType.Friday_Afternoon && s.Date.Date == Friday.Date)
                {
                    lbFridayAfternoon.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Friday_Evening && s.Date.Date == Friday.Date)
                {
                    lbFridayEvening.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }

                if (s.ShiftType == ShiftType.Saturday_Morning && s.Date.Date == Saturday.Date)
                {
                    lbSaturdayMorning.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Saturday_Afternoon && s.Date.Date == Saturday.Date)
                {
                    lbSaturdayAfternoon.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Saturday_Evening && s.Date.Date == Saturday.Date)
                {
                    lbSaturdayEvening.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }

                if (s.ShiftType == ShiftType.Sunday_Morning && s.Date.Date == Sunday.Date)
                {
                    lbSundayMorning.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Sunday_Afternoon && s.Date.Date == Sunday.Date)
                {
                    lbSundayAfternoon.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                if (s.ShiftType == ShiftType.Sunday_Evening && s.Date.Date == Sunday.Date)
                {
                    lbSundayEvening.Items.Add($"{s.Employee.Firstname} {s.Employee.Lastname}");
                }
                /*
                                lblMondayDate.Text = $"{Monday.Day}.{Monday.Month}";
                                lblTuesdayDate.Text = $"{Tuesday.Day}.{Tuesday.Month}";
                                lblWednesdayDate.Text = $"{Wednesday.Day}.{Wednesday.Month}";
                                lblThursdayDate.Text = $"{Thursday.Day}.{Thursday.Month}";
                                lblFridayDate.Text = $"{Friday.Day}.{Friday.Month}";
                                lblSaturdayDate.Text = $"{Saturday.Day}.{Saturday.Month}";
                                lblSundayDate.Text = $"{Sunday.Day}.{Sunday.Month}";*/





            }

            lblMonday.Text = $"{Monday.Day}.{Monday.Month}.{Monday.Year}";
            lblTuesday.Text = $"{Tuesday.Day}.{Monday.Month}.{Monday.Year}";
            lblWednesday.Text = $"{Wednesday.Day}.{Monday.Month}.{Monday.Year}";
            lblThursday.Text = $"{Thursday.Day}.{Monday.Month}.{Monday.Year}";
            lblFriday.Text = $"{Friday.Day}.{Monday.Month}.{Monday.Year}";
            lblSaturday.Text = $"{Saturday.Day}.{Monday.Month}.{Monday.Year}";
            lblSunday.Text = $" {Sunday.Day}.{Sunday.Month}.{Sunday.Year}";

        }

        private void btnPreviousWeek_Click(object sender, EventArgs e)
        {
            weekOfset -= 7;
            CalendarLoad();
        }

        private void btnCreateShift_Click_1(object sender, EventArgs e)
        {
            //  MessageBox.Show($"{lbEmployeesForShift.}");
            if (lbEmployeesForShift.SelectedItems.Count >= 1)
            {
                CreateShift();
                UpdateShiftListbox();
                CalendarLoad();
            }
            else
            {
                MessageBox.Show("Please select employees!");
            }

        }

        private void EditShift()
        {
            string shiftCheck = lbShifts.SelectedItem.ToString();
            List<Shift> shiftsForEdit = new List<Shift>();
            DateTime time = dateTimePickerShifts.Value;
            string typeString = $"{time.DayOfWeek}_{cbShiftType.Text}";
            Logic.ShiftType shiftType = (Logic.ShiftType)Enum.Parse(typeof(Logic.ShiftType), typeString);

            foreach (Shift s in sm._shifts)
            {

                if (shiftCheck.Contains($"{s.ShiftType} on {s.Date.Day}/{s.Date.Month}/{s.Date.Year}"))
                {
                    shiftsForEdit.Add(s);
                }
            }
            //puts all shifts for the edit and passes it to the method
            List<Employee> emp = new List<Employee>();
            List<int> index = new List<int>();
            if (lbEmployeesForShift.SelectedItems.Count >= 0)
            {
                for (int i = 0; i < lbEmployeesForShift.SelectedItems.Count; i++)
                {
                    index.Add(lbEmployeesForShift.SelectedIndices[i]);
                }
            }

            foreach (int i in index)
            {
                emp.Add(employees[i]);
            }
            //puts all employees needed for the edited shifts and passes it to the method
            sm.EditShift(shiftsForEdit, emp, shiftType, time);
        }

        private void btnEditShift_Click_1(object sender, EventArgs e)
        {

            EditShift();
            CalendarLoad();
            UpdateShiftListbox();
        }

        private void btnDeleteShift_Click_1(object sender, EventArgs e)
        {
            List<Shift> shiftsToBeDeleted = new List<Shift>();
            List<Shift> shifts = sdb.GetShifts();
            // if (selection != lbShifts.SelectedIndex && lbShifts.SelectedItems.Count > 0)
            //   {
            selection = lbShifts.SelectedIndex;
            lbEmployeesForShift.SelectedIndex = -1;
            string shiftCheck = lbShifts.SelectedItem.ToString();

            foreach (Shift s in shifts)
            {
                if (shiftCheck.Contains(s.ToString()))

                {
                    sdb.DeleteShift(s.Id);

                }//
            }
            //  }
            CalendarLoad();
            UpdateShiftListbox();

            //if (lbShifts.SelectedItems.Count > 0)
            //{
            //    int id = lbShifts.SelectedIndex;
            //    sm._shifts.RemoveAt(id);
            //    UpdateShiftListbox();
            //}
            //else { MessageBox.Show($"Please select shift to perform this action!"); }
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            weekOfset += 7;
            CalendarLoad();
        }

        private void lbShifts_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (selection != lbShifts.SelectedIndex && lbShifts.SelectedItems.Count > 0)
            {
                selection = lbShifts.SelectedIndex;
                lbEmployeesForShift.SelectedIndex = -1;
                string shiftCheck = lbShifts.SelectedItem.ToString();

                foreach (Shift s in sm._shifts)
                {

                    if (shiftCheck.Contains($"{s.ShiftType} on {s.Date.Day}/{s.Date.Month}/{s.Date.Year}"))
                    {
                        lbEmployeesForShift.SelectedItems.Add($"{s.Employee.Firstname} {s.Employee.Lastname}, {s.Employee.ID}");
                        dateTimePickerShifts.Value = s.Date;
                        string type = s.ShiftType.ToString();
                        string cbBox = type.Replace($"{s.Date.DayOfWeek}", string.Empty);

                        cbShiftType.SelectedItem = cbBox;
                    }
                }
            }
            else
            {
                lbEmployeesForShift.SelectedIndex = -1;

                lbShifts.SelectedIndex = -1;
                selection = -2;


            }
        }

        private void dateTimePickerShifts_ValueChanged(object sender, EventArgs e)
        {
            if (lbShifts.SelectedItems.Count == 0)
            {
                lbShifts.Items.Clear();
                List<Shift> Temp = sm._shifts;
                foreach (Shift s1 in sm._shifts)
                {
                    if (s1.Date == dateTimePickerShifts.Value)
                    {
                        string employeesOnShift = "";
                        foreach (Shift s2 in Temp)
                        {
                            if (s1.Date.Year == s2.Date.Year && s1.Date.DayOfYear == s2.Date.DayOfYear && s1.ShiftType == s2.ShiftType)
                            {
                                employeesOnShift += s2.ToString();
                            }
                        }

                        if (!lbShifts.Items.Contains($"{s1.ShiftType} on {s1.Date.Day}/{s1.Date.Month}/{s1.Date.Year} is assigned to: {employeesOnShift}"))
                        {
                            lbShifts.Items.Add($"{s1.ShiftType} on {s1.Date.Day}/{s1.Date.Month}/{s1.Date.Year} is assigned to: {employeesOnShift}");
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            weekOfset += 7;

            lbMondayMorning.Items.Clear();
            lbMondayAfternoon.Items.Clear();
            lbMondayEvening.Items.Clear();

            lbTuesdayMorning.Items.Clear();
            lbTuesdayAfternoon.Items.Clear();
            lbTuesdayEvening.Items.Clear();

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

            int limit = 5;
            int max = limit * 3;
            ShiftsDB dh = new ShiftsDB();
            Dictionary<Employee, List<int>> employeeAvaivability = new Dictionary<Employee, List<int>>();
            Dictionary<Employee, List<DateTime>> UnavaivableDates = new Dictionary<Employee, List<DateTime>>();
            Dictionary<Employee, int> empContract = new Dictionary<Employee, int>();
            List<Shift> shifts1 = new List<Shift>();
            List<Shift> shifts2 = new List<Shift>();
            List<Shift> shifts3 = new List<Shift>();
            List<Shift> shifts4 = new List<Shift>();
            List<Shift> shifts5 = new List<Shift>();
            List<Shift> shifts6 = new List<Shift>();
            List<Shift> shifts7 = new List<Shift>();
            List<Shift> shifts8 = new List<Shift>();
            List<Shift> shifts9 = new List<Shift>();
            List<Shift> shifts10 = new List<Shift>();
            List<Shift> shifts11 = new List<Shift>();
            List<Shift> shifts12 = new List<Shift>();
            List<Shift> shifts13 = new List<Shift>();
            List<Shift> shifts14 = new List<Shift>();
            List<Shift> shifts15 = new List<Shift>();
            List<Shift> shifts16 = new List<Shift>();
            List<Shift> shifts17 = new List<Shift>();
            List<Shift> shifts18 = new List<Shift>();
            List<Shift> shifts19 = new List<Shift>();
            List<Shift> shifts20 = new List<Shift>();
            List<Shift> shifts21 = new List<Shift>();
            List<Shift> shiftList = new List<Shift>();
            Random random = new Random();

            foreach (Employee emp in employees)
            {
                employeeAvaivability.Add(emp, dh.GetAvailability(emp.ID));
            }
            foreach (Employee emp in employees)
            {
                UnavaivableDates.Add(emp, dh.GetUnavaivableDate(emp.ID));
            }
            foreach (Employee emp in employees)
            {
                empContract.Add(emp, dh.GetContract(emp.ID));
            }

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, ShiftType.Monday_Morning, Monday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts1.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(0))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Monday))
                            {
                                shifts1.Add(s);
                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts1.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)1, Monday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts2.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(1))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Monday))
                            {
                                shifts2.Add(s);
                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts2.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)2, Monday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts3.Any(item => item.Employee.ID == employee.ID) && !shifts1.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(2))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Monday))
                            {
                                shifts3.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts3.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)3, Tuesday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts4.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(3))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Tuesday))
                            {
                                shifts4.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts4.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)4, Tuesday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts5.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(4))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Tuesday))
                            {
                                shifts5.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts5.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)5, Tuesday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts6.Any(item => item.Employee.ID == employee.ID) && !shifts4.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(5))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Tuesday))
                            {
                                shifts6.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts6.Count < limit);


            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)6, Wednesday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts7.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(6))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Wednesday))
                            {
                                shifts7.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts7.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)7, Wednesday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts8.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(7))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Wednesday))
                            {
                                shifts8.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts8.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)8, Wednesday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts9.Any(item => item.Employee.ID == employee.ID) && !shifts7.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(8))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Wednesday))
                            {
                                shifts9.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts9.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)9, Thursday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts10.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(9))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Wednesday))
                            {
                                shifts10.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts10.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)10, Thursday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts11.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(10))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Thursday))
                            {
                                shifts11.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts11.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)11, Thursday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts12.Any(item => item.Employee.ID == employee.ID) && !shifts10.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(11))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Thursday))
                            {
                                shifts12.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts12.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)12, Friday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts13.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(12))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Friday))
                            {
                                shifts13.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts13.Count < limit);
            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)13, Friday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts14.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(13))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Friday))
                            {
                                shifts14.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts14.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)14, Friday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts15.Any(item => item.Employee.ID == employee.ID) && !shifts13.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(14))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Friday))
                            {
                                shifts15.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts15.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)15, Saturday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts16.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(15))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Saturday))
                            {
                                shifts16.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts16.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)16, Saturday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts17.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(16))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Saturday))
                            {
                                shifts17.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts17.Count < limit);


            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)17, Saturday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts18.Any(item => item.Employee.ID == employee.ID) && !shifts16.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(17))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Saturday))
                            {
                                shifts18.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts18.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)18, Sunday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts19.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(18))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Sunday))
                            {
                                shifts19.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }

            while (shifts19.Count < limit);
            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)19, Sunday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts20.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(19))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Sunday))
                            {
                                shifts20.Add(s);

                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts20.Count < limit);

            do
            {
                Employee employee = employees[random.Next(employees.Count)];
                Shift s = new Shift(employee, (ShiftType)20, Sunday);
                var count = shiftList.Where(x => x != null && x.Employee.ID == employee.ID).Count();
                if (!shifts21.Any(item => item.Employee.ID == employee.ID) && !shifts19.Any(item => item.Employee.ID == employee.ID))
                {
                    if (!employeeAvaivability[employee].Contains(20))
                    {
                        if (empContract[employee] >= count)
                        {
                            if (!UnavaivableDates[employee].Contains(Sunday))
                            {
                                shifts21.Add(s);
                                shiftList.Add(s);
                            }
                        }
                    }
                }
            }
            while (shifts21.Count < limit);





            foreach (Shift s in shifts1)
            {
                lbMondayMorning.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts2)
            {
                lbMondayAfternoon.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts4)
            {
                lbMondayEvening.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts21)
            {
                lbTuesdayMorning.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts5)
            {
                lbTuesdayAfternoon.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts6)
            {
                lbTuesdayEvening.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts7)
            {
                lbWednesdayMorning.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts8)
            {
                lbWednesdayAfternoon.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts9)
            {
                lbWednesdayEvening.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts10)
            {
                lbThursdayMorning.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts11)
            {
                lbThursdayAfternoon.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts12)
            {
                lbThursdayEvening.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts13)
            {
                lbFridayMorning.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts14)
            {
                lbFridayAfternoon.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts15)
            {
                lbFridayEvening.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts16)
            {
                lbSaturdayMorning.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts17)
            {
                lbSaturdayAfternoon.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts18)
            {
                lbSaturdayEvening.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts19)
            {
                lbSundayMorning.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts20)
            {
                lbSundayAfternoon.Items.Add(s.Employee.Firstname);
            }
            foreach (Shift s in shifts21)
            {
                lbSundayEvening.Items.Add(s.Employee.Firstname);
                }

                MessageBox.Show("Generated schedule");

            foreach (Shift s in shiftList)
            {
                sdb.AddShift(s.Employee, s.ShiftType, s.Date);
            }
            UpdateShiftListbox();
            }

        private void btnAutoShift_MouseHover(object sender, EventArgs e)
        {
            label37.Visible = true; 
        }
    }
}
