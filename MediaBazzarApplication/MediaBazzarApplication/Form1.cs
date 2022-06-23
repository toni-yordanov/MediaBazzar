using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazzarApplication.Presentation;

namespace MediaBazzarApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShiftManager_Click(object sender, EventArgs e)
        {
            ShiftMakingForm smf = new ShiftMakingForm();
            smf.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StoreManager smm = new StoreManager();
            smm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            StockManager sm = new StockManager();
            sm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeManagerPage employeeManagerPage = new EmployeeManagerPage();
            employeeManagerPage.Show();
        }

        private void btnStockManager_Click(object sender, EventArgs e)
        {

        }




        //private void button1_Click(object sender, EventArgs e)
        //{
        //    StockManager sk = new StockManager();
        //    sk.ShowDialog();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    EmployeeManager em = new EmployeeManager();
        //    em.ShowDialog();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    ShiftMakingForm smf = new ShiftMakingForm();
        //    smf.ShowDialog();
        //}
    }
}
