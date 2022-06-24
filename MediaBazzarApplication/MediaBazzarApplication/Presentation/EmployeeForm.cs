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
    public partial class EmployeeForm : Form
    {
        Employee emp;
        EmployeeDB edb;
        DepartmentDB ddb; 
        private List<DepartmentChangeRequest> requests;
        private List<Department> departments;
        public EmployeeForm(Employee em)
        {
            InitializeComponent();
            
            this.emp = em;
            label1.Text += $" {emp.Firstname}";


            edb = new EmployeeDB();
            ddb = new DepartmentDB();
            departments = ddb.GetDepartments();
            cbxDepartments.Items.Clear();
            requests = new List<DepartmentChangeRequest>();
            foreach (Department item in departments)
            {
                cbxDepartments.Items.Add(item);
            }
            UpdateRequests();

        }

        public void UpdateRequests()
        {
            if (requests.Count > 0)
            {
                requests.Clear();
            }
            List<DepartmentChangeRequest> departmentChangeRequests = edb.GetDepartmentChangeRequests();
            foreach (DepartmentChangeRequest item in departmentChangeRequests)
            {
                if (item.EmployeeID == emp.ID)
                {
                    requests.Add(item);
                }
            }
            dgvRequest.DataSource = requests;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbxDepartments.SelectedItem is null)
            {
                MessageBox.Show("Select a department first.");
            }
            else if (((Department)cbxDepartments.SelectedItem).DepartmentName == emp.DepartmentName)
            {
                MessageBox.Show("You can't request the same department");
            }
            else
            {
                DepartmentChangeRequest d = new DepartmentChangeRequest(emp.Firstname, emp.ID, emp.DepartmentName, ((Department)cbxDepartments.SelectedItem).DepartmentName,"Unanswered");
                edb.AddRequest(d);
                MessageBox.Show("Succesfully added a new request. Please wait for your response.");
                UpdateRequests();
                tabPage1.Show();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
