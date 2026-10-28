namespace School._forms
{
    partial class VoucherslistReport
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
            this.FEE_HISTORYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_DataSet_new = new School.Report_DataSet_new();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fEEHISTORYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fEE_HISTORYTableAdapter = new School.Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FEE_HISTORYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fEEHISTORYBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FEE_HISTORYBindingSource
            // 
            this.FEE_HISTORYBindingSource.DataMember = "FEE_HISTORY";
            this.FEE_HISTORYBindingSource.DataSource = this.report_DataSet_new;
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
            reportDataSource1.Value = this.FEE_HISTORYBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.VoucherslistReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(804, 587);
            this.reportViewer1.TabIndex = 6;
            // 
            // fEEHISTORYBindingSource
            // 
            this.fEEHISTORYBindingSource.DataMember = "FEE_HISTORY";
            this.fEEHISTORYBindingSource.DataSource = this.report_DataSet_new;
            // 
            // fEE_HISTORYTableAdapter
            // 
            this.fEE_HISTORYTableAdapter.ClearBeforeFill = true;
            // 
            // VoucherslistReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 587);
            this.Controls.Add(this.reportViewer1);
            this.Name = "VoucherslistReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher List Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ClasswiseStregnthReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FEE_HISTORYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fEEHISTORYBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_DataSet_new report_DataSet_new;
        private System.Windows.Forms.BindingSource fEEHISTORYBindingSource;
        private Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter fEE_HISTORYTableAdapter;
        private System.Windows.Forms.BindingSource FEE_HISTORYBindingSource;
    }
}