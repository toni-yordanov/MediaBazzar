namespace MediaBazzarApplication.Presentation
{
    partial class StoreManager
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
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReturnProduct = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbProductOnShelf = new System.Windows.Forms.ListBox();
            this.cbShelfs = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddShelf = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cbFloors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1010, 453);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnReturnProduct);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.lbProductOnShelf);
            this.groupBox2.Controls.Add(this.cbShelfs);
            this.groupBox2.Location = new System.Drawing.Point(286, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(789, 350);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shelf Manipulation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Select a floor:";
            // 
            // btnReturnProduct
            // 
            this.btnReturnProduct.Location = new System.Drawing.Point(602, 137);
            this.btnReturnProduct.Name = "btnReturnProduct";
            this.btnReturnProduct.Size = new System.Drawing.Size(161, 59);
            this.btnReturnProduct.TabIndex = 3;
            this.btnReturnProduct.Text = "Return Products to storage";
            this.btnReturnProduct.UseVisualStyleBackColor = true;
            this.btnReturnProduct.Click += new System.EventHandler(this.btnReturnProduct_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(602, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 66);
            this.button1.TabIndex = 2;
            this.button1.Text = "Move products to selected shelf";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lbProductOnShelf
            // 
            this.lbProductOnShelf.FormattingEnabled = true;
            this.lbProductOnShelf.ItemHeight = 16;
            this.lbProductOnShelf.Location = new System.Drawing.Point(251, 48);
            this.lbProductOnShelf.Name = "lbProductOnShelf";
            this.lbProductOnShelf.Size = new System.Drawing.Size(298, 260);
            this.lbProductOnShelf.TabIndex = 1;
            // 
            // cbShelfs
            // 
            this.cbShelfs.FormattingEnabled = true;
            this.cbShelfs.Location = new System.Drawing.Point(15, 136);
            this.cbShelfs.Name = "cbShelfs";
            this.cbShelfs.Size = new System.Drawing.Size(230, 24);
            this.cbShelfs.TabIndex = 0;
            this.cbShelfs.SelectedIndexChanged += new System.EventHandler(this.cbShelfs_SelectedIndexChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddShelf);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.cbFloors);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 275);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Shelf";
            // 
            // btnAddShelf
            // 
            this.btnAddShelf.Location = new System.Drawing.Point(47, 202);
            this.btnAddShelf.Name = "btnAddShelf";
            this.btnAddShelf.Size = new System.Drawing.Size(183, 43);
            this.btnAddShelf.TabIndex = 4;
            this.btnAddShelf.Text = "Create Shelf";
            this.btnAddShelf.UseVisualStyleBackColor = true;
            this.btnAddShelf.Click += new System.EventHandler(this.btnAddShelf_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Capacity";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(47, 126);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(183, 22);
            this.numericUpDown1.TabIndex = 2;
            // 
            // cbFloors
            // 
            this.cbFloors.FormattingEnabled = true;
            this.cbFloors.Location = new System.Drawing.Point(47, 60);
            this.cbFloors.Name = "cbFloors";
            this.cbFloors.Size = new System.Drawing.Size(183, 24);
            this.cbFloors.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a floor:";
            // 
            // StoreManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 525);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StoreManager";
            this.Text = "StoreManager";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReturnProduct;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbProductOnShelf;
        private System.Windows.Forms.ComboBox cbShelfs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddShelf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox cbFloors;
        private System.Windows.Forms.Label label1;
    }
}