namespace School.Fee_Summary_Reports
{
    partial class Head_student_wise_fee_param
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbmonth = new System.Windows.Forms.DateTimePicker();
            this.cmbclassfrom = new System.Windows.Forms.ComboBox();
            this.cmbclassto = new System.Windows.Forms.ComboBox();
            this.frmclose = new Glass.GlassButton();
            this.btnSave = new Glass.GlassButton();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbsectionfrom = new System.Windows.Forms.ComboBox();
            this.cmbsectionto = new System.Windows.Forms.ComboBox();
            this.cmbtypefrom = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbtypeto = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Head, Student wise Fee Detail Report Parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 65;
            this.label1.Text = "Select Fee Month:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 14);
            this.label3.TabIndex = 66;
            this.label3.Text = "Select Class From : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(360, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 14);
            this.label4.TabIndex = 67;
            this.label4.Text = "Select Class To : ";
            // 
            // cmbmonth
            // 
            this.cmbmonth.CustomFormat = "MM yyyy";
            this.cmbmonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbmonth.Location = new System.Drawing.Point(175, 25);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(145, 20);
            this.cmbmonth.TabIndex = 68;
            // 
            // cmbclassfrom
            // 
            this.cmbclassfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclassfrom.FormattingEnabled = true;
            this.cmbclassfrom.Location = new System.Drawing.Point(175, 67);
            this.cmbclassfrom.Name = "cmbclassfrom";
            this.cmbclassfrom.Size = new System.Drawing.Size(145, 21);
            this.cmbclassfrom.TabIndex = 69;
            // 
            // cmbclassto
            // 
            this.cmbclassto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclassto.FormattingEnabled = true;
            this.cmbclassto.Location = new System.Drawing.Point(490, 67);
            this.cmbclassto.Name = "cmbclassto";
            this.cmbclassto.Size = new System.Drawing.Size(145, 21);
            this.cmbclassto.TabIndex = 70;
            // 
            // frmclose
            // 
            this.frmclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmclose.Location = new System.Drawing.Point(535, 245);
            this.frmclose.Name = "frmclose";
            this.frmclose.Size = new System.Drawing.Size(100, 36);
            this.frmclose.TabIndex = 72;
            this.frmclose.Text = "Close";
            this.frmclose.Click += new System.EventHandler(this.frmclose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(375, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 36);
            this.btnSave.TabIndex = 71;
            this.btnSave.Text = "Generate Report";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(360, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 14);
            this.label5.TabIndex = 73;
            this.label5.Text = "Select Paid Status:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PAID",
            "NOT-PAID",
            "ALL"});
            this.comboBox1.Location = new System.Drawing.Point(490, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 21);
            this.comboBox1.TabIndex = 74;
            this.comboBox1.Text = "ALL";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(35, 195);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 20);
            this.checkBox1.TabIndex = 75;
            this.checkBox1.Text = "Include Fee Head";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 14);
            this.label6.TabIndex = 76;
            this.label6.Text = "Section From :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(360, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 77;
            this.label7.Text = "Section To :";
            // 
            // cmbsectionfrom
            // 
            this.cmbsectionfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbsectionfrom.FormattingEnabled = true;
            this.cmbsectionfrom.Location = new System.Drawing.Point(175, 109);
            this.cmbsectionfrom.Name = "cmbsectionfrom";
            this.cmbsectionfrom.Size = new System.Drawing.Size(145, 21);
            this.cmbsectionfrom.TabIndex = 78;
            // 
            // cmbsectionto
            // 
            this.cmbsectionto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbsectionto.FormattingEnabled = true;
            this.cmbsectionto.Location = new System.Drawing.Point(490, 109);
            this.cmbsectionto.Name = "cmbsectionto";
            this.cmbsectionto.Size = new System.Drawing.Size(145, 21);
            this.cmbsectionto.TabIndex = 79;
            // 
            // cmbtypefrom
            // 
            this.cmbtypefrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtypefrom.FormattingEnabled = true;
            this.cmbtypefrom.Location = new System.Drawing.Point(175, 151);
            this.cmbtypefrom.Name = "cmbtypefrom";
            this.cmbtypefrom.Size = new System.Drawing.Size(145, 21);
            this.cmbtypefrom.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 14);
            this.label8.TabIndex = 80;
            this.label8.Text = "Student Type From:";
            // 
            // cmbtypeto
            // 
            this.cmbtypeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtypeto.FormattingEnabled = true;
            this.cmbtypeto.Location = new System.Drawing.Point(490, 151);
            this.cmbtypeto.Name = "cmbtypeto";
            this.cmbtypeto.Size = new System.Drawing.Size(145, 21);
            this.cmbtypeto.TabIndex = 83;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(360, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 14);
            this.label9.TabIndex = 82;
            this.label9.Text = "Student Type To:";
            // 
            // Head_student_wise_fee_param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 420);
            this.Controls.Add(this.cmbtypeto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbtypefrom);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbsectionto);
            this.Controls.Add(this.cmbsectionfrom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.frmclose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbclassto);
            this.Controls.Add(this.cmbclassfrom);
            this.Controls.Add(this.cmbmonth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Head_student_wise_fee_param";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parameters";
            this.Load += new System.EventHandler(this.Head_Class_wise_feereport_param_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker cmbmonth;
        private System.Windows.Forms.ComboBox cmbclassfrom;
        private System.Windows.Forms.ComboBox cmbclassto;
        private Glass.GlassButton frmclose;
        private Glass.GlassButton btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbsectionfrom;
        private System.Windows.Forms.ComboBox cmbsectionto;
        private System.Windows.Forms.ComboBox cmbtypefrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbtypeto;
        private System.Windows.Forms.Label label9;
    }
}