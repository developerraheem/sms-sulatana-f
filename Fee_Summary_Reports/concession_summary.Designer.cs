namespace School.Fee_Summary_Reports
{
    partial class concession_summary
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
            this.CONCESSION_SUMMARYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Fee_Summary_Reports = new School.DataSet_Fee_Summary_Reports();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.feemonthToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SULTANA_CONCESSIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sULTANACONCESSIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sULTANA_CONCESSIONTableAdapter = new School.DataSet_Fee_Summary_ReportsTableAdapters.SULTANA_CONCESSIONTableAdapter();
            this.cONCESSIONSUMMARYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cONCESSION_SUMMARYTableAdapter = new School.DataSet_Fee_Summary_ReportsTableAdapters.CONCESSION_SUMMARYTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CONCESSION_SUMMARYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SULTANA_CONCESSIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sULTANACONCESSIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONCESSIONSUMMARYBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CONCESSION_SUMMARYBindingSource
            // 
            this.CONCESSION_SUMMARYBindingSource.DataMember = "CONCESSION_SUMMARY";
            this.CONCESSION_SUMMARYBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // dataSet_Fee_Summary_Reports
            // 
            this.dataSet_Fee_Summary_Reports.DataSetName = "DataSet_Fee_Summary_Reports";
            this.dataSet_Fee_Summary_Reports.EnforceConstraints = false;
            this.dataSet_Fee_Summary_Reports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Top;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CONCESSION_SUMMARYBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Fee_Summary_Reports.concession_summary.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(990, 656);
            this.reportViewer1.TabIndex = 7;
            // 
            // feemonthToolStripTextBox
            // 
            this.feemonthToolStripTextBox.Name = "feemonthToolStripTextBox";
            this.feemonthToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // SULTANA_CONCESSIONBindingSource
            // 
            this.SULTANA_CONCESSIONBindingSource.DataMember = "SULTANA_CONCESSION";
            this.SULTANA_CONCESSIONBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // sULTANACONCESSIONBindingSource
            // 
            this.sULTANACONCESSIONBindingSource.DataMember = "SULTANA_CONCESSION";
            this.sULTANACONCESSIONBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // sULTANA_CONCESSIONTableAdapter
            // 
            this.sULTANA_CONCESSIONTableAdapter.ClearBeforeFill = true;
            // 
            // cONCESSIONSUMMARYBindingSource
            // 
            this.cONCESSIONSUMMARYBindingSource.DataMember = "CONCESSION_SUMMARY";
            this.cONCESSIONSUMMARYBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // cONCESSION_SUMMARYTableAdapter
            // 
            this.cONCESSION_SUMMARYTableAdapter.ClearBeforeFill = true;
            // 
            // concession_summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 660);
            this.Controls.Add(this.reportViewer1);
            this.Name = "concession_summary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Concession Summary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Head_Class_wise_feereport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CONCESSION_SUMMARYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SULTANA_CONCESSIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sULTANACONCESSIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cONCESSIONSUMMARYBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Fee_Summary_Reports fee_Summary_Reports;
        private DataSet_Fee_Summary_Reports.Head_Class_wise_FeereportDataTable head_Class_wise_FeereportTableAdapter;
        private System.Windows.Forms.ToolStripTextBox feemonthToolStripTextBox;
        private DataSet_Fee_Summary_Reports dataSet_Fee_Summary_Reports;
        private System.Windows.Forms.BindingSource sULTANACONCESSIONBindingSource;
        private DataSet_Fee_Summary_ReportsTableAdapters.SULTANA_CONCESSIONTableAdapter sULTANA_CONCESSIONTableAdapter;
        private System.Windows.Forms.BindingSource SULTANA_CONCESSIONBindingSource;
        private System.Windows.Forms.BindingSource CONCESSION_SUMMARYBindingSource;
        private System.Windows.Forms.BindingSource cONCESSIONSUMMARYBindingSource;
        private DataSet_Fee_Summary_ReportsTableAdapters.CONCESSION_SUMMARYTableAdapter cONCESSION_SUMMARYTableAdapter;
    }
}