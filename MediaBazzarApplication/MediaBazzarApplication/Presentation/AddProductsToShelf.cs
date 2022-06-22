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
    public partial class AddProductsToShelf : Form
    {
        private ProductManager productManager;
        private ShelfManager shelfManager;
        private RequestManager requestManager;
        private int s { get; set; }
        private Shelf shelf;
        private List<Product> products;
        private int shelfamount;
        public AddProductsToShelf(int id)
        {
            InitializeComponent();
            this.productManager = new ProductManager();
            this.shelfManager = new ShelfManager();
            this.requestManager = new RequestManager();
            this.s = id;
            shelf = shelfManager.GetShelfByID(s);
            lbShelfID.Text = (id).ToString();
            lbCountProducts.Text = (shelfManager.CheckShelfAvailability(id)).ToString();
            lbShelfCap.Text = (shelfManager.GetShelfByID(id).Capacity).ToString();
            // products = LoadData();

            //    productManager.Load();
            //   LoadAllProducts();
            // LoadData();
            LoadAllProducts();
            //  shelfamount = shelfManager.CheckShelfAvailability(s);

        }


        private void LoadAllProducts()
        {
            this.DVGProducts.Rows.Clear();
            this.DVGProducts.ColumnCount = 9;
            this.DVGProducts.Columns[0].Name = "ID";
            this.DVGProducts.Columns[1].Name = "Name";
            this.DVGProducts.Columns[2].Name = "Brand";
            this.DVGProducts.Columns[3].Name = "Cost Price";
            this.DVGProducts.Columns[4].Name = "Sell Price";
            this.DVGProducts.Columns[5].Name = "In Stock";
            this.DVGProducts.Columns[6].Name = "Max Capacity";
            this.DVGProducts.Columns[7].Name = "Threshold";
            foreach (Product p in LoadData())
            {
                this.DVGProducts.Rows.Add(p.Id, p.Name, p.Brand, p.BuyPrice + " €", p.SellPrice + " €", p.InStock, p.MaxCapacity, p.Threshold);
            }
            foreach (DataGridViewRow row in DVGProducts.Rows)
                if (Convert.ToInt32(row.Cells[5].Value) < Convert.ToInt32(row.Cells[7].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
        }
        private List<Product> LoadData()
        {
            int type = Convert.ToInt32(shelf.Floors);
            List<Product> list = new List<Product>();
            foreach (Product p in productManager.GetProductsByShelfType(type))
            {
                list.Add(p);
            }
            return list;
        }
        private int GetProduct()
        {
            int selectedRowIndex = this.DVGProducts.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = this.DVGProducts.Rows[selectedRowIndex];
            return Convert.ToInt32(selectedRow.Cells["ID"].Value);
        }
        private void SendRestockRequest(Product product)
        {
            RestockRequest request = new RestockRequest(product, (int)nUdCount.Value);
            requestManager.Add(request);
        }
        private void btnAddProductToSHelf_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSendRestock_Click(object sender, EventArgs e)
        {
          
        }
        private Product GetProduct2()
        {
            int selectedRowIndex = this.DVGProducts.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = this.DVGProducts.Rows[selectedRowIndex];
            Product product = this.productManager.Get(Convert.ToInt32(selectedRow.Cells["ID"].Value));
            return product;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProductToSHelf_Click_1(object sender, EventArgs e)
        {
            if (this.DVGProducts.SelectedCells.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to store {nUdCount.Value} amount of this product on shelf ID:{s} ?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int selectedRowIndex = this.DVGProducts.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = this.DVGProducts.Rows[selectedRowIndex];

                    int p = this.GetProduct();
                    int stockAmount = Convert.ToInt32(selectedRow.Cells["In Stock"].Value);
                    if ((stockAmount - nUdCount.Value) > 0)
                    {
                        int x = Convert.ToInt32(shelfManager.CheckShelfAvailability(s));
                        int v = Convert.ToInt32(nUdCount.Value);
                        int f = x + v;
                        if (f <= shelf.Capacity)
                        {
                            shelfManager.AddProductToshelf(s, p, Convert.ToInt32(nUdCount.Value));
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Select less products!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Not enough of this item is in stock!");
                    }
                    Product product = productManager.Get(p);
                    product.ProductOutOfStock += SendRestockRequest;
                    if (product.CheckQuantity())
                    {
                        MessageBox.Show("Instock quantity is lower than than threshold value of the product, so an automatic restock request has been sent.");
                    }
                    if (dialogResult == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    product.ProductOutOfStock -= SendRestockRequest;
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnSendRestock_Click_1(object sender, EventArgs e)
        {
            int selectedAmount = (int)nUdCount.Value;
            if (this.DVGProducts.SelectedCells.Count > 0)
            {
                Product product = this.GetProduct2();
                if (selectedAmount + product.InStock > product.MaxCapacity)
                {
                    MessageBox.Show("Restock has to be lower than max capacity");
                }
                else
                {
                    if (product.InStock < product.MaxCapacity)
                    {
                        RestockRequest restockRequest = new RestockRequest(product);
                        if (!requestManager.CheckRequestAlreadySent(restockRequest))
                        {
                            requestManager.Add(new RestockRequest(product, selectedAmount));
                            MessageBox.Show("Restock request has been sent successfully! ");
                        }
                        else { MessageBox.Show("A restock request for this product has already been sent."); }
                    }
                    else
                    {
                        MessageBox.Show("Can not send a restock request when the product is at full capacity.");
                    }
                }

            }
            else { MessageBox.Show("Please select a product from the table."); }
        }

        private void btBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
