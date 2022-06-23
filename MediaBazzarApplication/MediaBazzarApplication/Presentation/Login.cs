using MediaBazzarApplication.DAL;
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
        EmployeeDB edb; 
        public Login()
        {
            InitializeComponent();
            this.employees = edb.GetEmployees();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
