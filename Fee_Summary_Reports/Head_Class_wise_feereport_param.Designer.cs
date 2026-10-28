namespace School.Fee_Summary_Reports
{
    partial class Head_Class_wise_feereport_param
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtenddate = new System.Windows.Forms.DateTimePicker();
            this.txtstartdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(108, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(453, 25);
            this.label2.TabIndex = 64;
            this.label2.Text = "Head Class wise Fee Summary Report Parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 18);
            this.label1.TabIndex = 65;
            this.label1.Text = "Select Month From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 248);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 18);
            this.label3.TabIndex = 66;
            this.label3.Text = "Select Class From : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(392, 248);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 18);
            this.label4.TabIndex = 67;
            this.label4.Text = "Select Class To : ";
            // 
            // cmbmonth
            // 
            this.cmbmonth.CustomFormat = "MM yyyy";
            this.cmbmonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbmonth.Location = new System.Drawing.Point(172, 94);
            this.cmbmonth.Margin = new System.Windows.Forms.Padding(4);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(175, 22);
            this.cmbmonth.TabIndex = 68;
            this.cmbmonth.ValueChanged += new System.EventHandler(this.cmbmonth_ValueChanged);
            // 
            // cmbclassfrom
            // 
            this.cmbclassfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclassfrom.FormattingEnabled = true;
            this.cmbclassfrom.Location = new System.Drawing.Point(172, 245);
            this.cmbclassfrom.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclassfrom.Name = "cmbclassfrom";
            this.cmbclassfrom.Size = new System.Drawing.Size(175, 25);
            this.cmbclassfrom.TabIndex = 69;
            // 
            // cmbclassto
            // 
            this.cmbclassto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclassto.FormattingEnabled = true;
            this.cmbclassto.Location = new System.Drawing.Point(518, 245);
            this.cmbclassto.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclassto.Name = "cmbclassto";
            this.cmbclassto.Size = new System.Drawing.Size(175, 25);
            this.cmbclassto.TabIndex = 70;
            // 
            // frmclose
            // 
            this.frmclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmclose.Location = new System.Drawing.Point(610, 321);
            this.frmclose.Margin = new System.Windows.Forms.Padding(4);
            this.frmclose.Name = "frmclose";
            this.frmclose.Size = new System.Drawing.Size(83, 33);
            this.frmclose.TabIndex = 72;
            this.frmclose.Text = "Close";
            this.frmclose.Click += new System.EventHandler(this.frmclose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(464, 321);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 33);
            this.btnSave.TabIndex = 71;
            this.btnSave.Text = "Generate Report";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(518, 94);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(175, 22);
            this.dateTimePicker1.TabIndex = 74;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(402, 96);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 18);
            this.label5.TabIndex = 73;
            this.label5.Text = "Select Month To:";
            // 
            // txtenddate
            // 
            this.txtenddate.CustomFormat = "MM yyyy";
            this.txtenddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtenddate.Location = new System.Drawing.Point(518, 175);
            this.txtenddate.Margin = new System.Windows.Forms.Padding(4);
            this.txtenddate.Name = "txtenddate";
            this.txtenddate.Size = new System.Drawing.Size(175, 22);
            this.txtenddate.TabIndex = 91;
            this.txtenddate.ValueChanged += new System.EventHandler(this.txtenddate_ValueChanged);
            // 
            // txtstartdate
            // 
            this.txtstartdate.CustomFormat = "MM yyyy";
            this.txtstartdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtstartdate.Location = new System.Drawing.Point(172, 175);
            this.txtstartdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtstartdate.Name = "txtstartdate";
            this.txtstartdate.Size = new System.Drawing.Size(175, 22);
            this.txtstartdate.TabIndex = 90;
            this.txtstartdate.ValueChanged += new System.EventHandler(this.txtstartdate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(402, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 89;
            this.label6.Text = "End Date : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 178);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 17);
            this.label7.TabIndex = 88;
            this.label7.Text = "Start Date :";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(39, 147);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 21);
            this.checkBox1.TabIndex = 92;
            this.checkBox1.Text = "Date wise";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Head_Class_wise_feereport_param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(723, 387);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtenddate);
            this.Controls.Add(this.txtstartdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker1);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Head_Class_wise_feereport_param";
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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtenddate;
        private System.Windows.Forms.DateTimePicker txtstartdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}