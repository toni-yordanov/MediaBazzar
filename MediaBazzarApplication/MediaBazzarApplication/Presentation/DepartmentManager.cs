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
    public partial class DepartmentManager : Form
    {
        DepartmentDB ddb;

        public DepartmentManager()
        {
            InitializeComponent();
            ddb = new DepartmentDB();

            GetDepartments();

        }

        public void GetDepartments()
        {
            lbDepartments.Items.Clear();
            foreach (Department d in ddb.GetDepartments())
            {
                lbDepartments.Items.Add(d);
            }
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            
            if (tbName.Text == "")
            {
                MessageBox.Show("Please enter a department name first");
            }
            else
            {
                foreach (Department department in ddb.GetDepartments())
                {
                    if (department.DepartmentName == tbName.Text)
                    {
                        MessageBox.Show("This department already exists.");
                    }
                }

                ddb.AddDepartment(tbName.Text);

                GetDepartments();
            }
        }
    }
}
