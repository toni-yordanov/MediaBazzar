using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MediaBazzarApplication.Service;
using MediaBazzarApplication.Enums;
using MediaBazzarApplication.Enteties;


namespace MediaBazzarApplication.Presentation
{
    public partial class StoreManager : Form
    {
        private ShelfManager shelfManager;
        private ProductManager pm = new ProductManager();
        public StoreManager()
        {
            InitializeComponent();
            shelfManager = new ShelfManager();


            cbFloors.DataSource = Enum.GetValues(typeof(Floors));
            shelfManager.LoadShelfs();
            LoadS();
        }

        private void btnAddShelf_Click(object sender, EventArgs e)
        {
            
        }
        private void LoadS()
        {
            cbShelfs.Items.Clear();
            foreach (Shelf s in shelfManager.GetShelvess())
            {
                this.cbShelfs.Items.Add(s.Get());
            }

        }
        private void loadProducts(int id)
        {
            lbProductOnShelf.Items.Clear();
            foreach (var item in shelfManager.GetItemsOnShelf(id))
            {
                lbProductOnShelf.Items.Add(item);
            }
        }

        private void btnReturnProduct_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void cbShelfs_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddShelf_Click_1(object sender, EventArgs e)
        {
            if (cbFloors.Text != "")
            {
                if (numericUpDown1.Value > 1)
                {
                    DialogResult r = MessageBox.Show("Are you sure you want to create a new shelf on this floor?", "", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        Shelf s = new Shelf((Floors)cbFloors.SelectedIndex, Convert.ToInt32(numericUpDown1.Value));
                        this.shelfManager.AddShelf(s);
                        MessageBox.Show("Shelf added");

                        LoadS();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid capacity input");
                }
            }

            else
            {
                MessageBox.Show("Please select a floor!");

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.cbShelfs.SelectedItem != null)
            {
                int id = Convert.ToInt32(cbShelfs.SelectedItem.ToString().Substring(0, cbShelfs.SelectedItem.ToString().IndexOf(" ")));
                AddProductsToShelf ap = new AddProductsToShelf(id);

                ap.ShowDialog();
                this.LoadS();
                loadProducts(id);
            }
            else { MessageBox.Show("Please select a shelf to move product to!"); }
        }

        private void btnReturnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbProductOnShelf.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a item you want to renturn from the list!");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to return all of the selected products back to depot?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var result = Regex.Match(lbProductOnShelf.SelectedItem.ToString(), @"^([\w\-]+)");
                        int id = Convert.ToInt32(cbShelfs.SelectedItem.ToString().Substring(0, cbShelfs.SelectedItem.ToString().IndexOf(" ")));
                        int prodID = Convert.ToInt32(result.Value);
                        string[] words = lbProductOnShelf.SelectedItem.ToString().Split(' ');
                        shelfManager.AddProductToshelf(id, prodID, -Convert.ToInt32(words[words.Length - 1]));
                        loadProducts(id);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }

        }

        private void cbShelfs_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbShelfs.SelectedItem.ToString().Substring(0, cbShelfs.SelectedItem.ToString().IndexOf(" ")));

            loadProducts(id);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
