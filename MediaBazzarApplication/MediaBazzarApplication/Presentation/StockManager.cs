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
        private RequestManager requestManager;
        public StockManager()
        {
            InitializeComponent();
            this.productManager = new ProductManager();
            productManager.Load();
            LoadAllProducts();
            requestManager = new RequestManager();
            GridViewConfiguration();
            foreach (RestockRequest request in this.requestManager.GetAll())
            {
                this.dataGridView2.Rows.Add(request.ID, request.RequestedAmount, request.SentTime, request.ProductName);
            }

            this.timer1.Start();
        }


        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
          
        }
        private void LoadAllProducts()
        {
            this.DGVStock.Rows.Clear();
            foreach (Product p in productManager.GetProducts())
            {
                this.DGVStock.Rows.Add(p.Id, p.Name, p.Brand, p.InStock, p.Threshold, p.MaxCapacity, p.BuyPrice, p.SellPrice, p.boxSizes, p.ProductCategory);
            }
            foreach (DataGridViewRow row in DGVStock.Rows)
                if (Convert.ToInt32(row.Cells[3].Value) < Convert.ToInt32(row.Cells[4].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
           
        }
        private Product GetProduct()
        {
            int selectedRowIndex = this.DGVStock.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = this.DGVStock.Rows[selectedRowIndex];
            Product product = this.productManager.Get(Convert.ToInt32(selectedRow.Cells["ID"].Value));

            return product;
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
           
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
          
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
          
        }
        private void GridViewConfiguration()
        {
            this.dataGridView2.ColumnCount = 4;
            this.dataGridView2.Columns[0].Name = "ID";
            this.dataGridView2.Columns[1].Name = "Requested Amount";
            this.dataGridView2.Columns[2].Name = "Sent Time";
            this.dataGridView2.Columns[3].Name = "Product Name";
            this.dataGridView2.Columns[0].Width = 40;

            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewColumn column in this.dataGridView2.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView2.BackgroundColor = this.dataGridView2.DefaultCellStyle.BackColor;
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            

        }
        private RestockRequest GetRequest()
        {
            int r = this.dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView2.Rows[r];
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            RestockRequest request = this.requestManager.Get(id);
            return request;
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void btnCreateProduct_Click_1(object sender, EventArgs e)
        {
            CreateProduct creatp = new CreateProduct();
            creatp.ShowDialog();
            LoadAllProducts();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView2.CurrentCell.RowIndex;
                int columnIndex = dataGridView2.CurrentCell.ColumnIndex;

                this.dataGridView2.Rows.Clear();

                foreach (RestockRequest request in this.requestManager.GetAll())
                {
                    this.dataGridView2.Rows.Add(request.ID, request.RequestedAmount, request.SentTime, request.ProductName);
                }


                if (this.dataGridView2.Rows.Count >= rowIndex + 1)
                {
                    this.dataGridView2.ClearSelection();
                    this.dataGridView2.CurrentCell = this.dataGridView2.Rows[rowIndex].Cells[columnIndex];
                }

            }
            else
            {
                this.dataGridView2.Rows.Clear();
                foreach (RestockRequest request in this.requestManager.GetAll())
                {
                    this.dataGridView2.Rows.Add(request.ID, request.RequestedAmount, request.SentTime, request.ProductName);
                }
            }
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
            try
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
            catch (Exception)
            {
                MessageBox.Show("Product can not be removed becouse it may locted in the store shelf.");
            }
        
        }

        private void btnViewProduct_Click_1(object sender, EventArgs e)
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

        private void btnAccept_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridView2.SelectedCells.Count > 0)
            {
                DialogResult confirmation = MessageBox.Show("Are you sure you want to confirm this request?", "Confirmation", MessageBoxButtons.OKCancel);
                if (confirmation == DialogResult.OK)
                {
                    RestockRequest request = this.GetRequest();
                    int quantity = request.RequestedAmount;
                    Product product = this.productManager.Get(request.ProductId);
                    if (this.requestManager.Remove(request))
                    {
                        product.RestockProduct(quantity);
                        this.productManager.Update(product);
                        MessageBox.Show("Request accepted successfully");
                        LoadAllProducts();
                    }
                    else { MessageBox.Show("Failed"); }
                }
            }
            else
            {
                MessageBox.Show("Please select a request!");
            }
        }

        private void btnDecline_Click_1(object sender, EventArgs e)
        {

            if (this.dataGridView2.SelectedCells.Count > 0)
            {
                DialogResult confirmation = MessageBox.Show("Are you sure you want to reject this request?", "Confirmation", MessageBoxButtons.OKCancel);
                if (confirmation == DialogResult.OK)
                {
                    RestockRequest request = this.GetRequest();

                    if (this.requestManager.Remove(request))
                    {
                        MessageBox.Show("Request rejected successfully");
                    }
                    else { MessageBox.Show("Failed"); }
                }
            }
            else { MessageBox.Show("Please select a request!"); }
        }
    }
}
