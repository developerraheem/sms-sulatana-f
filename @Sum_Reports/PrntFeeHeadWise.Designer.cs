namespace School._forms
{
    partial class PrntFeeHeadWise
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
            this.vIEWCLASSMONTHHEADWISEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.vIEW_CLASS_MONTH_HEAD_WISETableAdapter = new School.Report_datasetTableAdapters.VIEW_CLASS_MONTH_HEAD_WISETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vIEWCLASSMONTHHEADWISEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vIEWCLASSMONTHHEADWISEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.RptFeeheadwise.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(673, 582);
            this.reportViewer1.TabIndex = 6;
            // 
            // vIEWCLASSMONTHHEADWISEBindingSource
            // 
            this.vIEWCLASSMONTHHEADWISEBindingSource.DataMember = "VIEW_CLASS_MONTH_HEAD_WISE";
            this.vIEWCLASSMONTHHEADWISEBindingSource.DataSource = this.report_dataset;
            // 
            // report_dataset
            // 
            this.report_dataset.DataSetName = "Report_dataset";
            this.report_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vIEW_CLASS_MONTH_HEAD_WISETableAdapter
            // 
            this.vIEW_CLASS_MONTH_HEAD_WISETableAdapter.ClearBeforeFill = true;
            // 
            // PrntFeeHeadWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 582);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrntFeeHeadWise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Head Wise Monthly Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrntFeeHeadWise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vIEWCLASSMONTHHEADWISEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_dataset report_dataset;
        private System.Windows.Forms.BindingSource vIEWCLASSMONTHHEADWISEBindingSource;
        private Report_datasetTableAdapters.VIEW_CLASS_MONTH_HEAD_WISETableAdapter vIEW_CLASS_MONTH_HEAD_WISETableAdapter;
    }
}