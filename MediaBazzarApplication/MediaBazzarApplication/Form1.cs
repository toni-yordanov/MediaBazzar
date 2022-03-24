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

        private void button1_Click(object sender, EventArgs e)
        {
            StockManager sk = new StockManager();
            sk.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeManager em = new EmployeeManager();
            em.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShiftMakingForm smf = new ShiftMakingForm();
            smf.ShowDialog();
        }
    }
}
