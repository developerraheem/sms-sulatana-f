namespace School.Fee_Summary_Reports
{
    partial class school_profile
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dpAe = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet_Fee_Summary_Reports = new School.DataSet_Fee_Summary_Reports();
            this.fEEACCORDINGSTRENGHTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fEE_ACCORDING_STRENGHTTableAdapter = new School.DataSet_Fee_Summary_ReportsTableAdapters.FEE_ACCORDING_STRENGHTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fEEACCORDINGSTRENGHTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Select Fee Month";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dpAe
            // 
            this.dpAe.CustomFormat = "MM yyyy";
            this.dpAe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpAe.Location = new System.Drawing.Point(101, 18);
            this.dpAe.Name = "dpAe";
            this.dpAe.Size = new System.Drawing.Size(99, 20);
            this.dpAe.TabIndex = 16;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.fEEACCORDINGSTRENGHTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Fee_Summary_Reports.school_profile.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 51);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1185, 536);
            this.reportViewer1.TabIndex = 15;
            // 
            // dataSet_Fee_Summary_Reports
            // 
            this.dataSet_Fee_Summary_Reports.DataSetName = "DataSet_Fee_Summary_Reports";
            this.dataSet_Fee_Summary_Reports.EnforceConstraints = false;
            this.dataSet_Fee_Summary_Reports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fEEACCORDINGSTRENGHTBindingSource
            // 
            this.fEEACCORDINGSTRENGHTBindingSource.DataMember = "FEE_ACCORDING_STRENGHT";
            this.fEEACCORDINGSTRENGHTBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // fEE_ACCORDING_STRENGHTTableAdapter
            // 
            this.fEE_ACCORDING_STRENGHTTableAdapter.ClearBeforeFill = true;
            // 
            // school_profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 587);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dpAe);
            this.Controls.Add(this.reportViewer1);
            this.Name = "school_profile";
            this.Text = "School Profile";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.school_profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fEEACCORDINGSTRENGHTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dpAe;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource fEEACCORDINGSTRENGHTBindingSource;
        private DataSet_Fee_Summary_Reports dataSet_Fee_Summary_Reports;
        private DataSet_Fee_Summary_ReportsTableAdapters.FEE_ACCORDING_STRENGHTTableAdapter fEE_ACCORDING_STRENGHTTableAdapter;
    }
}