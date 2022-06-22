using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaBazzarApplication.Enteties;
using MediaBazzarApplication.Service;
using MediaBazzarApplication.Enums;
using MediaBazzarApplication.Exeptions;

namespace MediaBazzarApplication.Presentation
{
    public partial class ViewProduct : Form
    {
        private Product product;
        public ViewProduct(Product p)
        {
            InitializeComponent();
            this.product = p;
            LoadData(p);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData(Product product)
        {
            tbName.Text = product.Name;
            tbDesc.Text = product.Description;
            tbBrand.Text = product.Brand;
            cbBoxSize.Text = product.boxSizes.ToString();
            cbProductCategory.Text = product.ProductCategory.ToString();
            tbSerialNum.Text = product.SerialNumber.ToString();
            tbInStock.Text = product.InStock.ToString();
            tbBuyPrice.Text = product.BuyPrice.ToString();
            tbSellPrice.Text = product.SellPrice.ToString();
            tbMaxCap.Text = product.MaxCapacity.ToString();
            tbThresh.Text = product.Threshold.ToString();

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
