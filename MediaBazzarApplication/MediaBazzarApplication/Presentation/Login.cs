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
    public partial class Login : Form
    {

        private List<Employee> employees;
        private List<Contract> contracts;
        EmployeeDB edb;
        private int trial = 0; 
        public Login()
        {
            InitializeComponent();
            edb = new EmployeeDB();
            this.employees = edb.GetEmployeesLogin();

            this.contracts = edb.contracts;


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            if (tbUsername.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Please fill all the fields first.");
            }
            else
            {
                foreach (Employee employee in employees)
                {
                    if (employee.Username == username && employee.Password == password)
                    {
                        MessageBox.Show($"Successfully logged in as {employee.Firstname}");
                        foreach (Contract contract in contracts)
                        {
                            if (contract.EmployeeID == employee.ID)
                            {
                                if (contract.Position == "Employee Manager")
                                {
                                    this.Hide();
                                    EmployeeManagerPage employeeManagerPage = new EmployeeManagerPage();
                                    employeeManagerPage.Show();
                                    return;
                                }
                                else if (contract.Position == "Store Manager")
                                {
                                    StoreManager storeManager = new StoreManager();
                                    storeManager.Show();
                                    return;
                                }
                                else if (contract.Position == "Shift Manager")
                                {
                                    this.Hide();
                                    ShiftMakingForm shiftManager = new ShiftMakingForm();
                                    shiftManager.Show();
                                    return;
                                }
                                else if (contract.Position == "Department Manager")
                                {
                                    this.Hide();
                                    DepartmentManager departmentManager = new DepartmentManager();
                                    departmentManager.Show();
                                    return;
                                }
                                else if (contract.Position == "Stock Manager")
                                {
                                    StockManager stockManager = new StockManager();
                                    stockManager.Show();
                                    return;

                                }
                                else if (contract.Position == "Employee")
                                {
                                    this.Hide();
                                    EmployeeForm employeeForm = new EmployeeForm(employee);
                                    employeeForm.Show();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Your position is not in correct format please contact support");
                                    return;
                                }
                            }
                        }
                        
                    }
                    
                }
                
                MessageBox.Show("Your username or password is wrong please try again.");
                if (trial % 3 != 0 || trial == 0)
                {
                    trial++;
                }
                else
                {
                    MessageBox.Show($"Your tried logging in for {trial} times. You can try again later.");
                    btnLogin.Enabled = false;
                    Loginlock.Enabled = true;
                    Loginlock.Start();
                }
                return;

            }
            
        }

        private void Loginlock_Tick(object sender, EventArgs e)
        {
            Loginlock.Interval = 20;
            btnLogin.Enabled = true; 
        }
    }
}
