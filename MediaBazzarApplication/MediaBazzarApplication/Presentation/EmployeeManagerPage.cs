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

            UpdateTables();
            PopulateDepartments();

        }


        public void PopulateDepartments()
        {
            cbxDep.Items.Clear();
            cbxDep2.Items.Clear();
            cbxDepartment.Items.Clear();
            foreach (Department d in ddb.GetDepartments())
            {
                cbxDep.Items.Add(d);
                cbxDep2.Items.Add(d);
                cbxDepartment.Items.Add(d);
            }
        }

        public void UpdateTables()
        {
            
            dgvEmployees.DataSource = edb.GetEmployees();

            dgvContracts.DataSource = edb.GetContracts();
            ColorGradeContracts();

        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            //first if to understand how the employee is being added 

            if (chkContr.Checked) //add employee with contract
            {
                cbxDep2.Enabled = false; 


                if (tbFirstname.Text == "" || tbLastname.Text == "" || tbUsername.Text == "" || cbxGender.SelectedItem is null || tbAdress.Text == "" || tbCity.Text == "" ||
                tbCountry.Text == "" || tbPostCode.Text == "" || tbEmail.Text == "" || tbPhonenum.Text == "" || tbBsn.Text == ""
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
                    DateTime start = dtpStart.Value;
                    DateTime end = dtpEnd.Value;


                    edb.AddEmployeeWithContract(firstname, lastname, DateofBirth, username, password,
                    gender, bsn, adress, city, country, postalcode, email, phonenum,
                    departmentname);
                    MessageBox.Show($"Succesfully added employee {firstname}");


                    Employee emp = new Employee();
                    foreach (Employee employee in edb.GetEmployees())
                    {
                        if (employee.Firstname == firstname && employee.Email == email)
                        {
                            emp = employee; 
                        }
                    }
                    Contract c = new Contract(emp.ID, start, end, departmentname, position, contracttype, wage);
                    edb.AddContract(c);
                    MessageBox.Show($"Succesfully added starting contract for {firstname}");

                    UpdateTables();

                }

            }
            else if (chkContr.Checked == false) //add employee without contract
            {
                if (tbFirstname.Text == "" || tbLastname.Text == "" || tbUsername.Text == "" || cbxGender.SelectedItem is null || tbAdress.Text == "" || tbCity.Text == "" ||
                   tbCountry.Text == "" || tbPostCode.Text == "" || tbEmail.Text == "" || tbPhonenum.Text == "" || tbBsn.Text == "" || cbxDep2.SelectedItem is null)
                {
                    MessageBox.Show(" You want to add an employee without a contract, Please fill all the employee credantials fields first.");

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

                    edb.AddEmployeeWithoutContract(firstname, lastname, DateofBirth, username, password, gender, bsn, adress, city, country, postalcode, email, phonenum, departmentname);


                    UpdateTables();
                    tabPage1.Show();
                }



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
                btnReset.Visible = true; 
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
                    else
                    {
                        dgvEmployees.DataSource = employees;
                    }
                }
                else
                {
                    List<Employee> employees = edb.GetEmployeesbyDepartment(cbxDepartment.SelectedItem.ToString());
                    if (employees is null || employees.Count == 0)
                    {
                        MessageBox.Show("We couldn't find anyone with this Departmentname.");
                    }
                    else
                    {
                        dgvEmployees.DataSource = employees;
                    }
                }

            }
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            label19.Visible = true; 
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbID.Text = "";
            cbxDepartment.Text = "";
            UpdateTables();
            btnReset.Visible = false; 
        }


        #region Contracts 

        public Contract GetContract()
        {
            int selectedrowindex = this.dgvContracts.SelectedCells[0].RowIndex;
            DataGridViewRow selectedrow = this.dgvContracts.Rows[selectedrowindex];
            Contract c = this.edb.GetContract(Convert.ToInt32(selectedrow.Cells["ContractID"].Value));
            return c; 
        }

        private void btnTerminateContract_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to terminate this contract? ", "Terminate Contract", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //terminating the contract
                Contract c = GetContract();
                edb.TermintateContract(c.ContractID);
                MessageBox.Show($"Succesfully terminated contract: {c.ContractID}");
                return;  
            }
            else if (dialogResult == DialogResult.No)
            {
                //returning to the page
                return;
            }
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            AddContract ac = new AddContract();
            ac.Show();
            this.Hide();
        }

        public void ColorGradeContracts()
        {
            foreach (DataGridViewRow row in dgvContracts.Rows)
            {
                if (Convert.ToDateTime(row.Cells[2].Value) < DateTime.Today)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }

        #endregion

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContr.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                chkContr.Checked = false;
                groupBox1.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dgvContracts.DataSource = edb.GetActiveContracts();
        }

        private void rbnAllContracts_CheckedChanged(object sender, EventArgs e)
        {
            dgvContracts.DataSource = edb.contracts;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dgvContracts.DataSource = edb.GetTerminatedContracts();
        }
    }
}
