using MediaBazzarApplication.DAL;
using MediaBazzarApplication.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazzarApplication.Presentation
{
    public partial class AddContract : Form
    {

        EmployeeDB edb;
        Employee employee;
        DepartmentDB ddb;


        public AddContract()
        {
            InitializeComponent();

            edb = new EmployeeDB();
            employee = new Employee();
            ddb = new DepartmentDB();


            PopulateComboboxes();
            
            dtpStart.MinDate = DateTime.Today.AddDays(1);
            StartDateNextMonthFirstDay();
            dtpEnd.Value = dtpStart.Value.AddYears(1);
            


        }

        public void StartDateNextMonthFirstDay()
        {
            if (DateTime.Today.Date.Day == 1)
            {
                return; 
            }
            else
            {
                DateTime dt = DateTime.Now;
                dtpStart.Value = DateTime.Today.AddDays(-(dt.Day -1)).AddMonths(1);
            }

        }

        public void PopulateComboboxes()
        {
            //more functionalities for easier use can be added here
            #region Employee 
            cbxEmployee.Items.Clear();
            List<Employee> employees = edb.GetEmployees();
            foreach (Employee e in employees)
            {
                cbxEmployee.Items.Add(e);
            }
            #endregion
            #region Department 
            cbxDept.Items.Clear();
            List<Department> departments = ddb.GetDepartments();
            foreach (Department d in departments)
            { 
                cbxDept.Items.Add(d);
            }
            #endregion


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbxEmployee.SelectedItem is null)
            {
                MessageBox.Show("Please select an employee first.");
            }
            else if (cbxDept.SelectedItem is null)
            {
                MessageBox.Show("Please select a department.");
            }
            else if (cbxPosition.SelectedItem is null)
            {
                MessageBox.Show("Select a position.");
            }
            else if (cbxContType.SelectedItem is null)
            {
                MessageBox.Show("Please select a contract type.");
            }
            else
            {
                Employee emp = (Employee)cbxEmployee.SelectedItem;
                DateTime start = dtpStart.Value;
                DateTime end = dtpEnd.Value;
                Department d = (Department)cbxDept.SelectedItem;
                string position = cbxPosition.SelectedItem.ToString();
                string type = cbxContType.Text;
                double wage = Convert.ToDouble(nudWage.Value);
                bool active = false; 

                Contract c = new Contract(emp.ID,start,end,d.DepartmentName,position,type,wage, active);

                edb.AddContract(c);

                MessageBox.Show("Succesfully created a contract");

                EmployeeManagerPage empage = new EmployeeManagerPage();
                this.Hide();
                empage.Show();
                


            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            EmployeeManagerPage emp = new EmployeeManagerPage();
            emp.Show();
        }

        private void cbxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpStart.Enabled = true;
            employee = (Employee)cbxEmployee.SelectedItem;
            Department d = new Department();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(rb1year.Checked) && !(rb2year.Checked) && !(rb3year.Checked))
            {
                dtpEnd.Enabled = false;
                cbxDept.Enabled = false;
                cbxPosition.Enabled = false;
                cbxContType.Enabled = false;
                nudWage.Enabled = false; 
            }
            else
            {
                DateTime date = dtpStart.Value;
                date = dtpStart.Value.AddYears(1);
                dtpEnd.Value = date;
                cbxDept.Enabled = true;

            }


        }

        private void rb2year_CheckedChanged(object sender, EventArgs e)
        {
            if (!(rb1year.Checked) && !(rb2year.Checked) && !(rb3year.Checked))
            {
                dtpEnd.Enabled = false;
                cbxDept.Enabled = false;
                cbxPosition.Enabled = false;
                cbxContType.Enabled = false;
                nudWage.Enabled = false;
            }
            else
            {
                DateTime date = dtpStart.Value;
                date = dtpStart.Value.AddYears(2);
                dtpEnd.Value = date;
                cbxDept.Enabled = true; 
            }
        }

        private void rb3year_CheckedChanged(object sender, EventArgs e)
        {
            if (!(rb1year.Checked) && !(rb2year.Checked) && !(rb3year.Checked))
            {
                dtpEnd.Enabled = false;
                cbxDept.Enabled = false;
                cbxPosition.Enabled = false;
                cbxContType.Enabled = false;
                nudWage.Enabled = false;
            }
            else
            {
                DateTime date = dtpStart.Value;
                date = dtpStart.Value.AddYears(3);
                dtpEnd.Value = date;
                cbxDept.Enabled = true;

            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            rb1year.Enabled = true;
            rb2year.Enabled = true;
            rb3year.Enabled = true;
        }

        private void cbxDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxPosition.Enabled = true; 
        }

        private void cbxPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxContType.Enabled = true;
        }

        private void cbxContType_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudWage.Enabled = true;
        }

        private void nudWage_ValueChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
        }
    }
}
