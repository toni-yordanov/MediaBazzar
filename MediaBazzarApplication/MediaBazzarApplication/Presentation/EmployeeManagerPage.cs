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
    public partial class EmployeeManagerPage : Form
    {
        EmployeeDB edb;
        Employee e;
        DepartmentDB ddb; 
        public EmployeeManagerPage()
        {
            InitializeComponent();

            edb = new EmployeeDB();
            e = new Employee();
            ddb = new DepartmentDB();

            UpdateEmployeeTable();


        }


        public void PopulateDepartments()
        {
            cbxDep.Items.Clear();
            cbxDepartment.Items.Clear();
            foreach (Department d in ddb.GetDepartments())
            {
                cbxDep.Items.Add(d);
                cbxDepartment.Items.Add(d);
            }
        }

        public void UpdateEmployeeTable()
        {
            dgvEmployees.DataSource = edb.GetEmployees();

        }

        public void GenerateEmployees()
        {
            dgvEmployees.DataSource = "";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbFirstname.Text == "" || tbLastname.Text == "" || tbUsername.Text == "" || cbxGender.SelectedItem is null || tbAdress.Text == ""|| tbCity.Text == "" ||
                tbCountry.Text == ""|| tbPostCode.Text == ""|| tbEmail.Text == ""|| tbPhonenum.Text == "" || tbBsn.Text == ""
                || cbxDep.SelectedItem is null || cbxPosition.SelectedItem is null)
            {
                MessageBox.Show("Please fill all the required fields first.");
            }
            else
            {
                string firstname = tbFirstname.Text;
                string lastname = tbLastname.Text;
                DateTime DateofBirth = Convert.ToDateTime(dtpBirth.Value);
                string username = tbUsername.Text;
                string password = tbPassword.Text;
                string gender = Convert.ToString(cbxGender.SelectedItem);
                string bsn = tbBsn.Text;
                string adress = tbAdress.Text;
                string city = tbCity.Text;
                string country = tbCountry.Text;
                string postalcode = tbPostCode.Text;
                string email = tbEmail.Text;
                string phonenum = tbPhonenum.Text;
                string departmentname = Convert.ToString(cbxDep.SelectedItem);
                string position = Convert.ToString(cbxPosition.SelectedItem);
                string contracttype = Convert.ToString(cbxContype.SelectedItem);
                double wage = Convert.ToDouble(nudWage.Value);
                    


                edb.AddEmployee(firstname, lastname, DateofBirth, username, password, 
                    gender, bsn, adress, city, country, postalcode, email, phonenum,
                    departmentname, position, contracttype , wage);

                UpdateEmployeeTable();
                tabPage1.Show(); 

            }
        }


        #region Radiobuttons
        public void CheckRBStatus()
        {
            if (rbName.Checked)
            {
                rbName.Checked = true;
                tbName.Enabled = true;



                rbnId.Checked = false;
                tbID.Enabled = false;


                rbnDepartment.Checked = false;
                cbxDepartment.Enabled = false;

            }
            else if (rbnId.Checked)
            {
                rbName.Checked = false;
                tbName.Enabled = false;



                rbnId.Checked = true;
                tbID.Enabled = true;


                rbnDepartment.Checked = false;
                cbxDepartment.Enabled = false;

            }
            else if (rbnDepartment.Checked)
            {
                rbName.Checked = false;
                tbName.Enabled = false;



                rbnId.Checked = false;
                tbID.Enabled = false;


                rbnDepartment.Checked = true;
                cbxDepartment.Enabled = true;

            }
        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            CheckRBStatus();
        }

        private void rbnId_CheckedChanged(object sender, EventArgs e)
        {
            CheckRBStatus();
        }

        private void rbnDepartment_CheckedChanged(object sender, EventArgs e)
        {
            CheckRBStatus();
        }


        #endregion


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbName.Checked == false && rbnId.Checked == false && rbnDepartment.Checked == false)
            {
                MessageBox.Show("Please first select a field to filter the table.");
            }
            else
            {
                if (rbName.Checked)
                {
                    List <Employee> employees = edb.GetEmployeesbyName(tbName.Text);
                    if (employees.Count == 0)
                    {
                        MessageBox.Show("We couldn't find anyone with this name.");
                    }
                    else
                    {
                        dgvEmployees.DataSource = employees;
                    }
                }
                else if (rbnId.Checked)
                {
                    List<Employee> employees = edb.GetEmployeesbyID(Convert.ToInt32(tbID.Text));
                    if (employees.Count == 0)
                    {
                        MessageBox.Show("We couldn't find anyone with this ID.");
                    }
                }
                else
                {
                    List<Employee> employees = edb.GetEmployeesbyDepartment(cbxDepartment.SelectedItem.ToString());
                    if (employees.Count == 0)
                    {
                        MessageBox.Show("We couldn't find anyone with this ID.");
                    }
                }

            }
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            label19.Visible = true; 
        }
    }
}
