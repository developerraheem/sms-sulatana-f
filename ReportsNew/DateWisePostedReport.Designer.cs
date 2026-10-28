namespace School.ReportsNew
{
    partial class DateWisePostedReport
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
            this.fEEHISTORYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_DataSet_new = new School.Report_DataSet_new();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fEE_HISTORYTableAdapter = new School.Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fEEHISTORYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).BeginInit();
            this.SuspendLayout();
            // 
            // fEEHISTORYBindingSource
            // 
            this.fEEHISTORYBindingSource.DataMember = "FEE_HISTORY";
            this.fEEHISTORYBindingSource.DataSource = this.report_DataSet_new;
            // 
            // report_DataSet_new
            // 
            this.report_DataSet_new.DataSetName = "Report_DataSet_new";
            this.report_DataSet_new.EnforceConstraints = false;
            this.report_DataSet_new.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.fEEHISTORYBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.ReportsNew.DateWisePostedReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(826, 575);
            this.reportViewer1.TabIndex = 7;
            // 
            // fEE_HISTORYTableAdapter
            // 
            this.fEE_HISTORYTableAdapter.ClearBeforeFill = true;
            // 
            // DateWisePostedReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 575);
            this.Controls.Add(this.reportViewer1);
            this.Name = "DateWisePostedReport";
            this.Text = "Date wise Posted Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DateWisePostedReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fEEHISTORYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource fEEHISTORYBindingSource;
        private Report_DataSet_new report_DataSet_new;
        private Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter fEE_HISTORYTableAdapter;
    }
}