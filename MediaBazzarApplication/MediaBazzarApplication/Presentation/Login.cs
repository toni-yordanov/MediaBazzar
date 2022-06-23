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
                                }
                                else if (contract.Position == "Store Manager")
                                {
                                    StoreManager storeManager = new StoreManager();
                                    storeManager.Show();
                                }
                                else if (contract.Position == "Shift Manager")
                                {
                                    this.Hide();
                                    ShiftMakingForm shiftManager = new ShiftMakingForm();
                                    shiftManager.Show();
                                }
                                else if (contract.Position == "Department Manager")
                                {
                                    this.Hide();
                                    DepartmentManager departmentManager = new DepartmentManager();
                                    departmentManager.Show();
                                }
                                else if (contract.Position == "Stock Manager")
                                {
                                    StockManager stockManager = new StockManager();
                                    stockManager.Show();
                                }
                                else if (contract.Position == "Employee")
                                {
                                    // add employee form - department change request
                                }
                            }
                        }
                        
                    }
                }
            }
            
        }
    }
}
