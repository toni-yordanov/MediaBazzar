using MediaBazzarApplication.Exeptions;
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
using MediaBazzarApplication.Enums;
using MediaBazzarApplication.Service;

namespace MediaBazzarApplication.Presentation
{
    public partial class CreateProduct : Form
    {
        private RequestManager requestManager;

        private ProductManager productManager = new ProductManager();
        public CreateProduct()
        {
            InitializeComponent();
            cbBoxSize.DataSource = Enum.GetValues(typeof(BoxSize));
            cbProductCategory.DataSource = Enum.GetValues(typeof(ProductCategory));
            this.requestManager = new RequestManager();
        }
        private void SendRestockRequest(Product product)
        {
            RestockRequest request = new RestockRequest(product);
            requestManager.Add(request);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          
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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbDesc.Text == "" || tbBrand.Text == "" || tbBuyPrice.Text == "" || tbSellPrice.Text == "" || tbSerialNum.Text == "" || tbThresh.Text == "" || tbMaxCap.Text == "" || cbBoxSize.Text == "" || cbProductCategory.Text == "" || tbInStock.Text == "")
            {
                MessageBox.Show("Please fill all data fields!");
            }
            else
            {
                try
                {
                    string name = tbName.Text;
                    string desc = tbDesc.Text;
                    string brand = tbBrand.Text;
                    string boxSize = cbBoxSize.Text;
                    string category = cbProductCategory.Text;
                    int serialNum = Convert.ToInt32(tbSerialNum.Text);
                    int inStock = Convert.ToInt32(tbInStock.Text);
                    int buyPrice = Convert.ToInt32(tbBuyPrice.Text);
                    int sellPrice = Convert.ToInt32(tbSellPrice.Text);
                    int maxCap = Convert.ToInt32(tbMaxCap.Text);
                    int threshold = Convert.ToInt32(tbThresh.Text);
                    if (threshold > maxCap || inStock > maxCap)
                    {
                        throw new CapacityExeption();
                    }
                    // Product product = new Product(name, desc, brand, serialNum, buyPrice, sellPrice, inStock, threshold, boxSize, category, maxCap)
                    Product product = new Product(tbName.Text, tbDesc.Text, tbBrand.Text, Convert.ToInt32(tbSerialNum.Text), Convert.ToInt32(tbBuyPrice.Text), Convert.ToInt32(tbSellPrice.Text), Convert.ToInt32(tbInStock.Text),
                       Convert.ToInt32(tbThresh.Text), (BoxSize)cbBoxSize.SelectedIndex, (ProductCategory)cbProductCategory.SelectedIndex, Convert.ToInt32(tbMaxCap.Text));
                    if (!productManager.Add(product))
                    {
                        MessageBox.Show("This product exists!");
                    }
                    else
                    {
                        DialogResult box = MessageBox.Show("Product has been added successfully.");
                        product.ProductOutOfStock += SendRestockRequest;
                        if (product.CheckQuantity())
                        {
                            MessageBox.Show("Instock quantity is lower than than threshold value of the product, so an automatic restock request has been sent.");
                        }

                        if (box == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        product.ProductOutOfStock -= SendRestockRequest;

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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
