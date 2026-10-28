namespace School.Attendance_module
{
    partial class rpt_class_wise_attendance_param
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
            this.frmclose = new Glass.GlassButton();
            this.btnSave = new Glass.GlassButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbsectionfrom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbclassfrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfeemonth = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbshift = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // frmclose
            // 
            this.frmclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmclose.Location = new System.Drawing.Point(442, 306);
            this.frmclose.Margin = new System.Windows.Forms.Padding(4);
            this.frmclose.Name = "frmclose";
            this.frmclose.Size = new System.Drawing.Size(83, 41);
            this.frmclose.TabIndex = 88;
            this.frmclose.Text = "Close";
            this.frmclose.Click += new System.EventHandler(this.frmclose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(302, 306);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 41);
            this.btnSave.TabIndex = 87;
            this.btnSave.Text = "Generate Report";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(167, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 25);
            this.label4.TabIndex = 96;
            this.label4.Text = "Class Wise Attendance Report";
            // 
            // cmbsectionfrom
            // 
            this.cmbsectionfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbsectionfrom.FormattingEnabled = true;
            this.cmbsectionfrom.Location = new System.Drawing.Point(182, 142);
            this.cmbsectionfrom.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsectionfrom.Name = "cmbsectionfrom";
            this.cmbsectionfrom.Size = new System.Drawing.Size(343, 28);
            this.cmbsectionfrom.TabIndex = 92;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 21);
            this.label6.TabIndex = 91;
            this.label6.Text = "Section From :";
            // 
            // cmbclassfrom
            // 
            this.cmbclassfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclassfrom.FormattingEnabled = true;
            this.cmbclassfrom.Location = new System.Drawing.Point(182, 100);
            this.cmbclassfrom.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclassfrom.Name = "cmbclassfrom";
            this.cmbclassfrom.Size = new System.Drawing.Size(343, 28);
            this.cmbclassfrom.TabIndex = 90;
            this.cmbclassfrom.SelectedIndexChanged += new System.EventHandler(this.cmbclassfrom_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 21);
            this.label3.TabIndex = 89;
            this.label3.Text = "Select Class From : ";
            // 
            // txtfeemonth
            // 
            this.txtfeemonth.CustomFormat = "MM yyyy";
            this.txtfeemonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtfeemonth.Location = new System.Drawing.Point(182, 188);
            this.txtfeemonth.Margin = new System.Windows.Forms.Padding(4);
            this.txtfeemonth.Name = "txtfeemonth";
            this.txtfeemonth.Size = new System.Drawing.Size(201, 22);
            this.txtfeemonth.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 190);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 98;
            this.label5.Text = "Select Month";
            // 
            // cmbshift
            // 
            this.cmbshift.FormattingEnabled = true;
            this.cmbshift.Location = new System.Drawing.Point(182, 224);
            this.cmbshift.Margin = new System.Windows.Forms.Padding(4);
            this.cmbshift.Name = "cmbshift";
            this.cmbshift.Size = new System.Drawing.Size(201, 24);
            this.cmbshift.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 229);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 100;
            this.label1.Text = "Select Shift";
            // 
            // rpt_class_wise_attendance_param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(605, 360);
            this.ControlBox = false;
            this.Controls.Add(this.cmbshift);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfeemonth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbsectionfrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbclassfrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.frmclose);
            this.Controls.Add(this.btnSave);
            this.Name = "rpt_class_wise_attendance_param";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class wise Attendance Report";
            this.Load += new System.EventHandler(this.rpt_class_wise_attendance_param_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Glass.GlassButton frmclose;
        private Glass.GlassButton btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbsectionfrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbclassfrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtfeemonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbshift;
        private System.Windows.Forms.Label label1;
    }
}