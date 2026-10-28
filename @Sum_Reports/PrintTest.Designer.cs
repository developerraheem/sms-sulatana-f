namespace School._forms
{
    partial class PrintTest
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
            this.Attendance_DatasetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.attendanceDatasetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.attendance_DatasetTableAdapter = new School.Report_datasetTableAdapters.Attendance_DatasetTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Attendance_DatasetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceDatasetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Attendance_DatasetBindingSource
            // 
            this.Attendance_DatasetBindingSource.DataMember = "Attendance_Dataset";
            this.Attendance_DatasetBindingSource.DataSource = this.report_dataset;
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
            reportDataSource1.Value = this.Attendance_DatasetBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.RptMonthly.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(877, 586);
            this.reportViewer1.TabIndex = 2;
            // 
            // attendanceDatasetBindingSource
            // 
            this.attendanceDatasetBindingSource.DataMember = "Attendance_Dataset";
            this.attendanceDatasetBindingSource.DataSource = this.report_dataset;
            // 
            // attendance_DatasetTableAdapter
            // 
            this.attendance_DatasetTableAdapter.ClearBeforeFill = true;
            // 
            // PrintTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 586);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintTest";
            this.Text = "PrintTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrintTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Attendance_DatasetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceDatasetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_dataset report_dataset;
        private System.Windows.Forms.BindingSource attendanceDatasetBindingSource;
        private Report_datasetTableAdapters.Attendance_DatasetTableAdapter attendance_DatasetTableAdapter;
        private System.Windows.Forms.BindingSource Attendance_DatasetBindingSource;
    }
}