namespace School.Reports
{
    partial class RptDailyattnd
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
            this.dailyattndBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.daily_attndTableAdapter = new School.Report_datasetTableAdapters.daily_attndTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dailyattndBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // dailyattndBindingSource
            // 
            this.dailyattndBindingSource.DataMember = "daily_attnd";
            this.dailyattndBindingSource.DataSource = this.report_dataset;
            // 
            // report_dataset
            // 
            this.report_dataset.DataSetName = "Report_dataset";
            this.report_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dailyattndBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.RptDailyAttnd.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(926, 589);
            this.reportViewer1.TabIndex = 1;
            // 
            // daily_attndTableAdapter
            // 
            this.daily_attndTableAdapter.ClearBeforeFill = true;
            // 
            // RptDailyattnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 589);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "RptDailyattnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Attandence Report";
            this.Load += new System.EventHandler(this.RptDailyattnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dailyattndBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dailyattndBindingSource;
        private Report_dataset report_dataset;
        private Report_datasetTableAdapters.daily_attndTableAdapter daily_attndTableAdapter;
    }
}