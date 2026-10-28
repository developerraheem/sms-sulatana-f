namespace School._forms
{
    partial class PrntClasswisefee
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
            this.vIEWFEECLASSWISEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.vIEW_FEE_CLASS_WISETableAdapter = new School.Report_datasetTableAdapters.VIEW_FEE_CLASS_WISETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vIEWFEECLASSWISEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vIEWFEECLASSWISEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.RptFeeClasswise.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(603, 508);
            this.reportViewer1.TabIndex = 6;
            // 
            // vIEWFEECLASSWISEBindingSource
            // 
            this.vIEWFEECLASSWISEBindingSource.DataMember = "VIEW_FEE_CLASS_WISE";
            this.vIEWFEECLASSWISEBindingSource.DataSource = this.report_dataset;
            // 
            // report_dataset
            // 
            this.report_dataset.DataSetName = "Report_dataset";
            this.report_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vIEW_FEE_CLASS_WISETableAdapter
            // 
            this.vIEW_FEE_CLASS_WISETableAdapter.ClearBeforeFill = true;
            // 
            // PrntClasswisefee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 508);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrntClasswisefee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthly Class Wise Fee";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RptClasswisefee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vIEWFEECLASSWISEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_dataset report_dataset;
        private System.Windows.Forms.BindingSource vIEWFEECLASSWISEBindingSource;
        private Report_datasetTableAdapters.VIEW_FEE_CLASS_WISETableAdapter vIEW_FEE_CLASS_WISETableAdapter;
    }
}