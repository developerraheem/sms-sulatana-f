namespace School.Fee_Summary_Reports
{
    partial class Summary_bank_wise_posted_param
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
            this.cmb_bankfrom = new System.Windows.Forms.ComboBox();
            this.cmb_bankto = new System.Windows.Forms.ComboBox();
            this.frmclose = new Glass.GlassButton();
            this.btnSave = new Glass.GlassButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(114, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Bank Wise Posted Vouchers Summary Report";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 65;
            this.label1.Text = "Select Fee Month:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 14);
            this.label3.TabIndex = 66;
            this.label3.Text = "Select Bank From : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(296, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 14);
            this.label4.TabIndex = 67;
            this.label4.Text = "Select Bank To : ";
            // 
            // cmbmonth
            // 
            this.cmbmonth.CustomFormat = "MM yyyy";
            this.cmbmonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbmonth.Location = new System.Drawing.Point(129, 76);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(132, 20);
            this.cmbmonth.TabIndex = 68;
            // 
            // cmb_bankfrom
            // 
            this.cmb_bankfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_bankfrom.FormattingEnabled = true;
            this.cmb_bankfrom.Location = new System.Drawing.Point(129, 121);
            this.cmb_bankfrom.Name = "cmb_bankfrom";
            this.cmb_bankfrom.Size = new System.Drawing.Size(132, 21);
            this.cmb_bankfrom.TabIndex = 69;
            // 
            // cmb_bankto
            // 
            this.cmb_bankto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_bankto.FormattingEnabled = true;
            this.cmb_bankto.Location = new System.Drawing.Point(390, 125);
            this.cmb_bankto.Name = "cmb_bankto";
            this.cmb_bankto.Size = new System.Drawing.Size(132, 21);
            this.cmb_bankto.TabIndex = 70;
            // 
            // frmclose
            // 
            this.frmclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmclose.Location = new System.Drawing.Point(458, 183);
            this.frmclose.Name = "frmclose";
            this.frmclose.Size = new System.Drawing.Size(62, 27);
            this.frmclose.TabIndex = 72;
            this.frmclose.Text = "Close";
            this.frmclose.Click += new System.EventHandler(this.frmclose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(349, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 71;
            this.btnSave.Text = "Generate Report";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Summary_bank_wise_posted_param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(542, 247);
            this.Controls.Add(this.frmclose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmb_bankto);
            this.Controls.Add(this.cmb_bankfrom);
            this.Controls.Add(this.cmbmonth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Summary_bank_wise_posted_param";
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
        private System.Windows.Forms.ComboBox cmb_bankfrom;
        private System.Windows.Forms.ComboBox cmb_bankto;
        private Glass.GlassButton frmclose;
        private Glass.GlassButton btnSave;
    }
}