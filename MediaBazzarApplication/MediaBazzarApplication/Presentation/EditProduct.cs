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
    public partial class EditProduct : Form
    {
        private Product product;
        private ProductManager productManager;
        public EditProduct(Product product, ProductManager productManager)
        {
            InitializeComponent();
            cbBoxSize.DataSource = Enum.GetValues(typeof(BoxSize));
            cbProductCategory.DataSource = Enum.GetValues(typeof(ProductCategory));

            this.product = product;
            this.productManager = productManager;
            LoadData(product);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
          
        }
        private void LoadData(Product product)
        {
            tbName.Text = product.Name;
            tbDesc.Text = product.Description;
            tbBrand.Text = product.Brand;
            cbBoxSize.SelectedIndex = (int)product.boxSizes;
            cbProductCategory.SelectedIndex = (int)product.ProductCategory;
            tbSerialNum.Text = product.SerialNumber.ToString();
            tbInStock.Text = product.InStock.ToString();
            tbBuyPrice.Text = product.BuyPrice.ToString();
            tbSellPrice.Text = product.SellPrice.ToString();
            tbMaxCap.Text = product.MaxCapacity.ToString();
            tbThresh.Text = product.Threshold.ToString();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbMaxCap_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbThresh_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbInStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSellPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbBuyPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSerialNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbBrand_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbDesc.Text == "" || tbBrand.Text == "" || tbBuyPrice.Text == "" || tbSellPrice.Text == "" || tbSerialNum.Text == "" || tbThresh.Text == "" || tbMaxCap.Text == "" || cbBoxSize.Text == "" || cbProductCategory.Text == "" || tbInStock.Text == "")
            {
                MessageBox.Show("Please fill all data fields!");
            }
            else
            {
                try
                {
                    int maxCapacity = 0;
                    int threshold = 0;
                    maxCapacity = Convert.ToInt32(tbMaxCap.Text);
                    threshold = Convert.ToInt32(tbThresh.Text);
                    if (threshold > maxCapacity)
                    {
                        throw new CapacityExeption();
                    }
                    this.product.UpdateProduct(tbName.Text, tbDesc.Text, tbBrand.Text, Convert.ToInt32(tbSerialNum.Text), Convert.ToInt32(tbBuyPrice.Text), Convert.ToInt32(tbSellPrice.Text),
                       Convert.ToInt32(tbThresh.Text), (BoxSize)cbBoxSize.SelectedIndex, (ProductCategory)cbProductCategory.SelectedIndex, Convert.ToInt32(tbMaxCap.Text));
                    productManager.Update(product);
                    DialogResult box = MessageBox.Show("Product has been edited successfully.");
                    if (box == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }
                catch (CapacityExeption)
                {
                    MessageBox.Show("Threshold or instock value can not be bigger than the maximum capacity of the product.");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter all of the information in the right format.");
                }
            }
        }
    }
}
