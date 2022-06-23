namespace MediaBazzarApplication.Presentation
{
    partial class StockManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnLogOff = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnViewProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnCreateProduct = new System.Windows.Forms.Button();
            this.DGVStock = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Threshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDecline = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.RestockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RestockAMount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNameing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStock)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogOff
            // 
            this.btnLogOff.Location = new System.Drawing.Point(992, 441);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Size = new System.Drawing.Size(127, 50);
            this.btnLogOff.TabIndex = 1;
            this.btnLogOff.Text = "LogOut";
            this.btnLogOff.UseVisualStyleBackColor = true;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(993, 408);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbSearch);
            this.tabPage1.Controls.Add(this.btnViewProduct);
            this.tabPage1.Controls.Add(this.btnDeleteProduct);
            this.tabPage1.Controls.Add(this.btnUpdateProduct);
            this.tabPage1.Controls.Add(this.btnCreateProduct);
            this.tabPage1.Controls.Add(this.DGVStock);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(985, 379);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Product Manipulation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search for a product:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(179, 19);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(374, 22);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged_1);
            // 
            // btnViewProduct
            // 
            this.btnViewProduct.Location = new System.Drawing.Point(563, 275);
            this.btnViewProduct.Name = "btnViewProduct";
            this.btnViewProduct.Size = new System.Drawing.Size(147, 74);
            this.btnViewProduct.TabIndex = 4;
            this.btnViewProduct.Text = "View Product Info";
            this.btnViewProduct.UseVisualStyleBackColor = true;
            this.btnViewProduct.Click += new System.EventHandler(this.btnViewProduct_Click_1);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Location = new System.Drawing.Point(377, 275);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(147, 74);
            this.btnDeleteProduct.TabIndex = 3;
            this.btnDeleteProduct.Text = "Delete Product";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click_1);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Location = new System.Drawing.Point(194, 275);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(147, 74);
            this.btnUpdateProduct.TabIndex = 2;
            this.btnUpdateProduct.Text = "Update Product Info";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click_1);
            // 
            // btnCreateProduct
            // 
            this.btnCreateProduct.Location = new System.Drawing.Point(19, 275);
            this.btnCreateProduct.Name = "btnCreateProduct";
            this.btnCreateProduct.Size = new System.Drawing.Size(147, 74);
            this.btnCreateProduct.TabIndex = 1;
            this.btnCreateProduct.Text = "Register Product";
            this.btnCreateProduct.UseVisualStyleBackColor = true;
            this.btnCreateProduct.Click += new System.EventHandler(this.btnCreateProduct_Click_1);
            // 
            // DGVStock
            // 
            this.DGVStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProductName,
            this.Brand,
            this.InStock,
            this.Threshold,
            this.MaxCapacity,
            this.BuyPrice,
            this.SellPrice,
            this.BoxSize,
            this.Category});
            this.DGVStock.Location = new System.Drawing.Point(8, 47);
            this.DGVStock.Name = "DGVStock";
            this.DGVStock.RowHeadersWidth = 51;
            this.DGVStock.RowTemplate.Height = 24;
            this.DGVStock.Size = new System.Drawing.Size(971, 222);
            this.DGVStock.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 125;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 125;
            // 
            // Brand
            // 
            this.Brand.HeaderText = "Brand";
            this.Brand.MinimumWidth = 6;
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Width = 125;
            // 
            // InStock
            // 
            this.InStock.HeaderText = "InStock";
            this.InStock.MinimumWidth = 6;
            this.InStock.Name = "InStock";
            this.InStock.ReadOnly = true;
            this.InStock.Width = 125;
            // 
            // Threshold
            // 
            this.Threshold.HeaderText = "Threshold";
            this.Threshold.MinimumWidth = 6;
            this.Threshold.Name = "Threshold";
            this.Threshold.ReadOnly = true;
            this.Threshold.Width = 125;
            // 
            // MaxCapacity
            // 
            this.MaxCapacity.HeaderText = "MaxCapacity";
            this.MaxCapacity.MinimumWidth = 6;
            this.MaxCapacity.Name = "MaxCapacity";
            this.MaxCapacity.ReadOnly = true;
            this.MaxCapacity.Width = 125;
            // 
            // BuyPrice
            // 
            this.BuyPrice.HeaderText = "BuyPrice";
            this.BuyPrice.MinimumWidth = 6;
            this.BuyPrice.Name = "BuyPrice";
            this.BuyPrice.ReadOnly = true;
            this.BuyPrice.Width = 125;
            // 
            // SellPrice
            // 
            this.SellPrice.HeaderText = "SellPrice";
            this.SellPrice.MinimumWidth = 6;
            this.SellPrice.Name = "SellPrice";
            this.SellPrice.ReadOnly = true;
            this.SellPrice.Width = 125;
            // 
            // BoxSize
            // 
            this.BoxSize.HeaderText = "BoxSize";
            this.BoxSize.MinimumWidth = 6;
            this.BoxSize.Name = "BoxSize";
            this.BoxSize.ReadOnly = true;
            this.BoxSize.Width = 125;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 125;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDecline);
            this.tabPage2.Controls.Add(this.btnAccept);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(985, 379);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Restock Requests";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDecline
            // 
            this.btnDecline.BackColor = System.Drawing.Color.Red;
            this.btnDecline.Location = new System.Drawing.Point(581, 272);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(169, 79);
            this.btnDecline.TabIndex = 2;
            this.btnDecline.Text = "Decline Request";
            this.btnDecline.UseVisualStyleBackColor = false;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click_1);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Green;
            this.btnAccept.Location = new System.Drawing.Point(238, 272);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(169, 79);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept Request";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click_1);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RestockID,
            this.RestockAMount,
            this.SentTime,
            this.ProductNameing});
            this.dataGridView2.Location = new System.Drawing.Point(238, 31);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(512, 212);
            this.dataGridView2.TabIndex = 0;
            // 
            // RestockID
            // 
            this.RestockID.HeaderText = "Restock ID";
            this.RestockID.MinimumWidth = 6;
            this.RestockID.Name = "RestockID";
            this.RestockID.ReadOnly = true;
            this.RestockID.Width = 125;
            // 
            // RestockAMount
            // 
            this.RestockAMount.HeaderText = "RestockAmount";
            this.RestockAMount.MinimumWidth = 6;
            this.RestockAMount.Name = "RestockAMount";
            this.RestockAMount.ReadOnly = true;
            this.RestockAMount.Width = 125;
            // 
            // SentTime
            // 
            this.SentTime.HeaderText = "Sent Time";
            this.SentTime.MinimumWidth = 6;
            this.SentTime.Name = "SentTime";
            this.SentTime.ReadOnly = true;
            this.SentTime.Width = 125;
            // 
            // ProductNameing
            // 
            this.ProductNameing.HeaderText = "Product Name";
            this.ProductNameing.MinimumWidth = 6;
            this.ProductNameing.Name = "ProductNameing";
            this.ProductNameing.ReadOnly = true;
            this.ProductNameing.Width = 125;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // StockManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 503);
            this.Controls.Add(this.btnLogOff);
            this.Controls.Add(this.tabControl1);
            this.Name = "StockManager";
            this.Text = "StockManager";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStock)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogOff;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnViewProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnCreateProduct;
        private System.Windows.Forms.DataGridView DGVStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn InStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Threshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxCapacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestockID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestockAMount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SentTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNameing;
        private System.Windows.Forms.Timer timer1;
    }
}