﻿
namespace MediaBazzarApplication
{
    partial class Form1
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
            this.btnStockManager = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnShiftManager = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStockManager
            // 
            this.btnStockManager.Location = new System.Drawing.Point(19, 108);
            this.btnStockManager.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStockManager.Name = "btnStockManager";
            this.btnStockManager.Size = new System.Drawing.Size(118, 19);
            this.btnStockManager.TabIndex = 0;
            this.btnStockManager.Text = "Stock Manager";
            this.btnStockManager.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 132);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 19);
            this.button2.TabIndex = 1;
            this.button2.Text = "HR";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnShiftManager
            // 
            this.btnShiftManager.Location = new System.Drawing.Point(19, 155);
            this.btnShiftManager.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShiftManager.Name = "btnShiftManager";
            this.btnShiftManager.Size = new System.Drawing.Size(118, 19);
            this.btnShiftManager.TabIndex = 2;
            this.btnShiftManager.Text = "ShiftManagment";
            this.btnShiftManager.UseVisualStyleBackColor = true;
            this.btnShiftManager.Click += new System.EventHandler(this.btnShiftManager_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 19);
            this.button1.TabIndex = 3;
            this.button1.Text = "StockManager";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 65);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 19);
            this.button3.TabIndex = 4;
            this.button3.Text = "StoreManager";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(19, 187);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 25);
            this.button4.TabIndex = 5;
            this.button4.Text = "Employee Manager";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(153, 245);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnShiftManager);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnStockManager);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStockManager;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnShiftManager;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}