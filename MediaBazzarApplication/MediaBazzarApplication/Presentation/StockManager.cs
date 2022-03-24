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

namespace MediaBazzarApplication.Presentation
{
    public partial class StockManager : Form
    {
        private ProductManager productManager;
        public StockManager()
        {
            InitializeComponent();
            this.productManager = new ProductManager();
            productManager.Load();
            LoadAllProducts();
        }

      
        private void LoadAllProducts()
        {
            this.DGVStock.Rows.Clear();
            foreach (Product p in productManager.GetProducts())
            {
                this.DGVStock.Rows.Add(p.Id, p.Name, p.Brand, p.InStock, p.Threshold, p.MaxCapacity, p.BuyPrice, p.SellPrice, p.boxSizes, p.ProductCategory);
            }
            //foreach (DataGridViewRow row in DGVStock.Rows)
            //    if (Convert.ToInt32(row.Cells[3].Value) < Convert.ToInt32(row.Cells[4].Value))
            //    {
            //        row.DefaultCellStyle.BackColor = Color.Red;
            //    }
        }

    
        private Product GetProduct()
        {
            int selectedRowIndex = this.DGVStock.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = this.DGVStock.Rows[selectedRowIndex];
            Product product = this.productManager.Get(Convert.ToInt32(selectedRow.Cells["ID"].Value));

            return product;
        }

      

       

        

        private void btnCreateProduct_Click_1(object sender, EventArgs e)
        {
           
                CreateProduct creatp = new CreateProduct();
                creatp.ShowDialog();
                LoadAllProducts();
            
        }

        private void btnUpdateProduct_Click_1(object sender, EventArgs e)
        {
           
                if (this.DGVStock.SelectedCells.Count > 0)
                {
                    Product product = this.GetProduct();

                    EditProduct form = new EditProduct(product, productManager);
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        this.LoadAllProducts();
                    }
               }
            
        }

        private void btnDeleteProduct_Click_1(object sender, EventArgs e)
        {
           
                if (this.DGVStock.SelectedCells.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Product product = this.GetProduct();
                        this.productManager.Remove(product);

                        this.LoadAllProducts();
                        MessageBox.Show("Product has been removed successfully.");
                    }
                }
                else { MessageBox.Show("Please select a product from the table."); }
            
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
           
                if (this.DGVStock.SelectedCells.Count > 0)
                {
                    Product product = this.GetProduct();

                    ViewProduct form = new ViewProduct(product);
                    DialogResult result = form.ShowDialog();

                }
          
        }

        private void tbSearch_TextChanged_1(object sender, EventArgs e)
        {
            // LoadAllProducts();
            string text = tbSearch.Text;
            if (text == "")
            {
                LoadAllProducts();
            }
            else
            {
                this.DGVStock.Rows.Clear();
                foreach (Product p in productManager.SearchProducts(text))
                {
                    this.DGVStock.Rows.Add(p.Id, p.Name, p.Brand, p.InStock, p.Threshold, p.MaxCapacity, p.BuyPrice, p.SellPrice, p.boxSizes, p.ProductCategory);
                }
            }
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
