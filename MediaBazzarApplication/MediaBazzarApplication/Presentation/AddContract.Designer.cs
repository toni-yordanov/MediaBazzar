
namespace MediaBazzarApplication.Presentation
{
    partial class AddContract
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
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxContType = new System.Windows.Forms.ComboBox();
            this.cbxPosition = new System.Windows.Forms.ComboBox();
            this.nudWage = new System.Windows.Forms.NumericUpDown();
            this.cbxDept = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cbxEmployee = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rb1year = new System.Windows.Forms.RadioButton();
            this.rb2year = new System.Windows.Forms.RadioButton();
            this.rb3year = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(13, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(49, 24);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Contract";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.rb3year);
            this.groupBox1.Controls.Add(this.rb2year);
            this.groupBox1.Controls.Add(this.rb1year);
            this.groupBox1.Controls.Add(this.cbxContType);
            this.groupBox1.Controls.Add(this.cbxPosition);
            this.groupBox1.Controls.Add(this.nudWage);
            this.groupBox1.Controls.Add(this.cbxDept);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.cbxEmployee);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 328);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contract Details";
            // 
            // cbxContType
            // 
            this.cbxContType.Enabled = false;
            this.cbxContType.FormattingEnabled = true;
            this.cbxContType.Items.AddRange(new object[] {
            "full-time",
            "part-time",
            "student"});
            this.cbxContType.Location = new System.Drawing.Point(110, 246);
            this.cbxContType.Name = "cbxContType";
            this.cbxContType.Size = new System.Drawing.Size(121, 21);
            this.cbxContType.TabIndex = 5;
            this.cbxContType.SelectedIndexChanged += new System.EventHandler(this.cbxContType_SelectedIndexChanged);
            // 
            // cbxPosition
            // 
            this.cbxPosition.Enabled = false;
            this.cbxPosition.FormattingEnabled = true;
            this.cbxPosition.Items.AddRange(new object[] {
            "General Manager",
            "MB Manager",
            "Department Manager",
            "Worker"});
            this.cbxPosition.Location = new System.Drawing.Point(110, 209);
            this.cbxPosition.Name = "cbxPosition";
            this.cbxPosition.Size = new System.Drawing.Size(121, 21);
            this.cbxPosition.TabIndex = 5;
            this.cbxPosition.SelectedIndexChanged += new System.EventHandler(this.cbxPosition_SelectedIndexChanged);
            // 
            // nudWage
            // 
            this.nudWage.Enabled = false;
            this.nudWage.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudWage.Location = new System.Drawing.Point(110, 283);
            this.nudWage.Minimum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.nudWage.Name = "nudWage";
            this.nudWage.Size = new System.Drawing.Size(120, 20);
            this.nudWage.TabIndex = 4;
            this.nudWage.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.nudWage.ValueChanged += new System.EventHandler(this.nudWage_ValueChanged);
            // 
            // cbxDept
            // 
            this.cbxDept.Enabled = false;
            this.cbxDept.FormattingEnabled = true;
            this.cbxDept.Location = new System.Drawing.Point(110, 172);
            this.cbxDept.Name = "cbxDept";
            this.cbxDept.Size = new System.Drawing.Size(121, 21);
            this.cbxDept.TabIndex = 3;
            this.cbxDept.SelectedIndexChanged += new System.EventHandler(this.cbxDept_SelectedIndexChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Location = new System.Drawing.Point(110, 144);
            this.dtpEnd.MinDate = new System.DateTime(1753, 2, 6, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(185, 20);
            this.dtpEnd.TabIndex = 2;
            this.dtpEnd.Value = new System.DateTime(2022, 4, 20, 16, 40, 59, 0);
            // 
            // dtpStart
            // 
            this.dtpStart.Enabled = false;
            this.dtpStart.Location = new System.Drawing.Point(110, 82);
            this.dtpStart.MinDate = new System.DateTime(2022, 4, 20, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(185, 20);
            this.dtpStart.TabIndex = 2;
            this.dtpStart.Value = new System.DateTime(2022, 4, 20, 16, 40, 49, 0);
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // cbxEmployee
            // 
            this.cbxEmployee.FormattingEnabled = true;
            this.cbxEmployee.Location = new System.Drawing.Point(110, 35);
            this.cbxEmployee.Name = "cbxEmployee";
            this.cbxEmployee.Size = new System.Drawing.Size(121, 21);
            this.cbxEmployee.TabIndex = 1;
            this.cbxEmployee.SelectedIndexChanged += new System.EventHandler(this.cbxEmployee_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Wage:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Contract Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Position:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Department:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Start Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Employee:";
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(250, 396);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 40);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add Contract";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rb1year
            // 
            this.rb1year.AutoSize = true;
            this.rb1year.Enabled = false;
            this.rb1year.Location = new System.Drawing.Point(56, 121);
            this.rb1year.Name = "rb1year";
            this.rb1year.Size = new System.Drawing.Size(54, 17);
            this.rb1year.TabIndex = 6;
            this.rb1year.TabStop = true;
            this.rb1year.Text = "1 year";
            this.rb1year.UseVisualStyleBackColor = true;
            this.rb1year.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rb2year
            // 
            this.rb2year.AutoSize = true;
            this.rb2year.Enabled = false;
            this.rb2year.Location = new System.Drawing.Point(147, 121);
            this.rb2year.Name = "rb2year";
            this.rb2year.Size = new System.Drawing.Size(54, 17);
            this.rb2year.TabIndex = 6;
            this.rb2year.TabStop = true;
            this.rb2year.Text = "2 year";
            this.rb2year.UseVisualStyleBackColor = true;
            this.rb2year.CheckedChanged += new System.EventHandler(this.rb2year_CheckedChanged);
            // 
            // rb3year
            // 
            this.rb3year.AutoSize = true;
            this.rb3year.Enabled = false;
            this.rb3year.Location = new System.Drawing.Point(237, 121);
            this.rb3year.Name = "rb3year";
            this.rb3year.Size = new System.Drawing.Size(54, 17);
            this.rb3year.TabIndex = 6;
            this.rb3year.TabStop = true;
            this.rb3year.Text = "3 year";
            this.rb3year.UseVisualStyleBackColor = true;
            this.rb3year.CheckedChanged += new System.EventHandler(this.rb3year_CheckedChanged);
            // 
            // AddContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(375, 472);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Name = "AddContract";
            this.Text = "AddContract";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxContType;
        private System.Windows.Forms.ComboBox cbxPosition;
        private System.Windows.Forms.NumericUpDown nudWage;
        private System.Windows.Forms.ComboBox cbxDept;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rb3year;
        private System.Windows.Forms.RadioButton rb2year;
        private System.Windows.Forms.RadioButton rb1year;
    }
}