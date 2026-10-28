namespace School.Reports
{
    partial class RPT_DEFAULTER_READMISSION
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DEFAULTER_READMISSIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Fee_Summary_Reports = new School.DataSet_Fee_Summary_Reports();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmonths = new System.Windows.Forms.TextBox();
            this.btnmonth = new System.Windows.Forms.Button();
            this.dEFAULTERREADMISSIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dEFAULTER_READMISSIONTableAdapter = new School.DataSet_Fee_Summary_ReportsTableAdapters.DEFAULTER_READMISSIONTableAdapter();
            this.cmbfeetype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfeemonth = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DEFAULTER_READMISSIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEFAULTERREADMISSIONBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DEFAULTER_READMISSIONBindingSource
            // 
            this.DEFAULTER_READMISSIONBindingSource.DataMember = "DEFAULTER_READMISSION";
            this.DEFAULTER_READMISSIONBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // dataSet_Fee_Summary_Reports
            // 
            this.dataSet_Fee_Summary_Reports.DataSetName = "DataSet_Fee_Summary_Reports";
            this.dataSet_Fee_Summary_Reports.EnforceConstraints = false;
            this.dataSet_Fee_Summary_Reports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DEFAULTER_READMISSIONBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.RPT_DEFAULTER_READMISSION.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 99);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(817, 435);
            this.reportViewer1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Months:";
            // 
            // txtmonths
            // 
            this.txtmonths.Location = new System.Drawing.Point(83, 10);
            this.txtmonths.Name = "txtmonths";
            this.txtmonths.Size = new System.Drawing.Size(143, 20);
            this.txtmonths.TabIndex = 4;
            // 
            // btnmonth
            // 
            this.btnmonth.Location = new System.Drawing.Point(232, 10);
            this.btnmonth.Name = "btnmonth";
            this.btnmonth.Size = new System.Drawing.Size(75, 23);
            this.btnmonth.TabIndex = 5;
            this.btnmonth.Text = "Go";
            this.btnmonth.UseVisualStyleBackColor = true;
            this.btnmonth.Click += new System.EventHandler(this.btnmonth_Click);
            // 
            // dEFAULTERREADMISSIONBindingSource
            // 
            this.dEFAULTERREADMISSIONBindingSource.DataMember = "DEFAULTER_READMISSION";
            this.dEFAULTERREADMISSIONBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // dEFAULTER_READMISSIONTableAdapter
            // 
            this.dEFAULTER_READMISSIONTableAdapter.ClearBeforeFill = true;
            // 
            // cmbfeetype
            // 
            this.cmbfeetype.FormattingEnabled = true;
            this.cmbfeetype.Location = new System.Drawing.Point(83, 19);
            this.cmbfeetype.Name = "cmbfeetype";
            this.cmbfeetype.Size = new System.Drawing.Size(121, 21);
            this.cmbfeetype.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fine Type";
            // 
            // txtfeemonth
            // 
            this.txtfeemonth.CustomFormat = "MM yyyy";
            this.txtfeemonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtfeemonth.Location = new System.Drawing.Point(292, 19);
            this.txtfeemonth.Name = "txtfeemonth";
            this.txtfeemonth.Size = new System.Drawing.Size(121, 20);
            this.txtfeemonth.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(219, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Fee Month";
            // 
            // txtamount
            // 
            this.txtamount.Location = new System.Drawing.Point(83, 48);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(121, 20);
            this.txtamount.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Amount";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtfeemonth);
            this.groupBox1.Controls.Add(this.txtamount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbfeetype);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(313, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 83);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Fine";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Generate Fine";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RPT_DEFAULTER_READMISSION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnmonth);
            this.Controls.Add(this.txtmonths);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RPT_DEFAULTER_READMISSION";
            this.Text = "Defaulter Report for Re Admission";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPT_DEFAULTER_READMISSION_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DEFAULTER_READMISSIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEFAULTERREADMISSIONBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Fee_Summary_Reports dataSet_Fee_Summary_Reports;
        private System.Windows.Forms.BindingSource dEFAULTERREADMISSIONBindingSource;
        private DataSet_Fee_Summary_ReportsTableAdapters.DEFAULTER_READMISSIONTableAdapter dEFAULTER_READMISSIONTableAdapter;
        private System.Windows.Forms.BindingSource DEFAULTER_READMISSIONBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmonths;
        private System.Windows.Forms.Button btnmonth;
        private System.Windows.Forms.ComboBox cmbfeetype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtfeemonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}