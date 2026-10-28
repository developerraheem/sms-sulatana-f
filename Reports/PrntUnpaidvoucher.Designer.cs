namespace School._forms
{
    partial class PrntUnpaidvoucher
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.report_DataSet_new = new School.Report_DataSet_new();
            this.unpaidVouchersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.unpaidVouchersTableAdapter = new School.Report_DataSet_newTableAdapters.UnpaidVouchersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unpaidVouchersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.unpaidVouchersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.RptUnpaidVoucher.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(804, 587);
            this.reportViewer1.TabIndex = 6;
            // 
            // report_DataSet_new
            // 
            this.report_DataSet_new.DataSetName = "Report_DataSet_new";
            this.report_DataSet_new.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // unpaidVouchersBindingSource
            // 
            this.unpaidVouchersBindingSource.DataMember = "UnpaidVouchers";
            this.unpaidVouchersBindingSource.DataSource = this.report_DataSet_new;
            // 
            // unpaidVouchersTableAdapter
            // 
            this.unpaidVouchersTableAdapter.ClearBeforeFill = true;
            // 
            // PrntUnpaidvoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 587);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrntUnpaidvoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Voucher Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrntUnpaidvoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unpaidVouchersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource unpaidVouchersBindingSource;
        private Report_DataSet_new report_DataSet_new;
        private Report_DataSet_newTableAdapters.UnpaidVouchersTableAdapter unpaidVouchersTableAdapter;
    }
}