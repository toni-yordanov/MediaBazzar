namespace MediaBazzarApplication.Presentation
{
    partial class AddProductsToShelf
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
            this.lbShelfCap = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCountProducts = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbShelfID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btBack = new System.Windows.Forms.Button();
            this.nUdCount = new System.Windows.Forms.NumericUpDown();
            this.btnSendRestock = new System.Windows.Forms.Button();
            this.btnAddProductToSHelf = new System.Windows.Forms.Button();
            this.DVGProducts = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nUdCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DVGProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // lbShelfCap
            // 
            this.lbShelfCap.AutoSize = true;
            this.lbShelfCap.Location = new System.Drawing.Point(677, 39);
            this.lbShelfCap.Name = "lbShelfCap";
            this.lbShelfCap.Size = new System.Drawing.Size(0, 16);
            this.lbShelfCap.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(548, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Shelf Capacity:";
            // 
            // lbCountProducts
            // 
            this.lbCountProducts.AutoSize = true;
            this.lbCountProducts.Location = new System.Drawing.Point(501, 39);
            this.lbCountProducts.Name = "lbCountProducts";
            this.lbCountProducts.Size = new System.Drawing.Size(0, 16);
            this.lbCountProducts.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(317, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Product count on shelf: ";
            // 
            // lbShelfID
            // 
            this.lbShelfID.AutoSize = true;
            this.lbShelfID.Location = new System.Drawing.Point(288, 39);
            this.lbShelfID.Name = "lbShelfID";
            this.lbShelfID.Size = new System.Drawing.Size(0, 16);
            this.lbShelfID.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Adding products to shelf ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Amount:";
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(887, 510);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 16;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click_1);
            // 
            // nUdCount
            // 
            this.nUdCount.Location = new System.Drawing.Point(41, 415);
            this.nUdCount.Name = "nUdCount";
            this.nUdCount.Size = new System.Drawing.Size(372, 22);
            this.nUdCount.TabIndex = 15;
            // 
            // btnSendRestock
            // 
            this.btnSendRestock.Location = new System.Drawing.Point(241, 443);
            this.btnSendRestock.Name = "btnSendRestock";
            this.btnSendRestock.Size = new System.Drawing.Size(172, 61);
            this.btnSendRestock.TabIndex = 14;
            this.btnSendRestock.Text = "Send a restock request";
            this.btnSendRestock.UseVisualStyleBackColor = true;
            this.btnSendRestock.Click += new System.EventHandler(this.btnSendRestock_Click_1);
            // 
            // btnAddProductToSHelf
            // 
            this.btnAddProductToSHelf.Location = new System.Drawing.Point(41, 443);
            this.btnAddProductToSHelf.Name = "btnAddProductToSHelf";
            this.btnAddProductToSHelf.Size = new System.Drawing.Size(194, 60);
            this.btnAddProductToSHelf.TabIndex = 13;
            this.btnAddProductToSHelf.Text = "Add Product To Shelf";
            this.btnAddProductToSHelf.UseVisualStyleBackColor = true;
            this.btnAddProductToSHelf.Click += new System.EventHandler(this.btnAddProductToSHelf_Click_1);
            // 
            // DVGProducts
            // 
            this.DVGProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DVGProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Name,
            this.Brand,
            this.CostPrice,
            this.SellPrice,
            this.InStock,
            this.MaxCapacity});
            this.DVGProducts.Location = new System.Drawing.Point(88, 77);
            this.DVGProducts.Name = "DVGProducts";
            this.DVGProducts.RowHeadersWidth = 51;
            this.DVGProducts.RowTemplate.Height = 24;
            this.DVGProducts.Size = new System.Drawing.Size(788, 300);
            this.DVGProducts.TabIndex = 12;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 125;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 125;
            // 
            // Brand
            // 
            this.Brand.HeaderText = "Brand";
            this.Brand.MinimumWidth = 6;
            this.Brand.Name = "Brand";
            this.Brand.Width = 125;
            // 
            // CostPrice
            // 
            this.CostPrice.HeaderText = "Cost Price";
            this.CostPrice.MinimumWidth = 6;
            this.CostPrice.Name = "CostPrice";
            this.CostPrice.ReadOnly = true;
            this.CostPrice.Width = 125;
            // 
            // SellPrice
            // 
            this.SellPrice.HeaderText = "Sell Price";
            this.SellPrice.MinimumWidth = 6;
            this.SellPrice.Name = "SellPrice";
            this.SellPrice.ReadOnly = true;
            this.SellPrice.Width = 125;
            // 
            // InStock
            // 
            this.InStock.HeaderText = "In Stock";
            this.InStock.MinimumWidth = 6;
            this.InStock.Name = "InStock";
            this.InStock.Width = 125;
            // 
            // MaxCapacity
            // 
            this.MaxCapacity.HeaderText = "Max Capacity";
            this.MaxCapacity.MinimumWidth = 6;
            this.MaxCapacity.Name = "MaxCapacity";
            this.MaxCapacity.ReadOnly = true;
            this.MaxCapacity.Width = 125;
            // 
            // AddProductsToShelf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 572);
            this.Controls.Add(this.lbShelfCap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbCountProducts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbShelfID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.nUdCount);
            this.Controls.Add(this.btnSendRestock);
            this.Controls.Add(this.btnAddProductToSHelf);
            this.Controls.Add(this.DVGProducts);
            //this.Name = "AddProductsToShelf";
            this.Text = "AddProducttsToShelf";
            ((System.ComponentModel.ISupportInitialize)(this.nUdCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DVGProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbShelfCap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCountProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbShelfID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.NumericUpDown nUdCount;
        private System.Windows.Forms.Button btnSendRestock;
        private System.Windows.Forms.Button btnAddProductToSHelf;
        private System.Windows.Forms.DataGridView DVGProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn InStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxCapacity;
    }
}