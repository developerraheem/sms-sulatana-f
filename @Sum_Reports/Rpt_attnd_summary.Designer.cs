namespace School._forms
{
    partial class Rpt_attnd_summary
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
            this.attendanceDatasetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.attendance_DatasetTableAdapter = new School.Report_datasetTableAdapters.Attendance_DatasetTableAdapter();
            this.txtdateto = new System.Windows.Forms.TextBox();
            this.txtdatefrom = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceDatasetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // attendanceDatasetBindingSource
            // 
            this.attendanceDatasetBindingSource.DataMember = "Attendance_Dataset";
            this.attendanceDatasetBindingSource.DataSource = this.report_dataset;
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
            reportDataSource1.Value = this.attendanceDatasetBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.Rpt_AttendanceSummary.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1017, 600);
            this.reportViewer1.TabIndex = 1;
            // 
            // attendance_DatasetTableAdapter
            // 
            this.attendance_DatasetTableAdapter.ClearBeforeFill = true;
            // 
            // txtdateto
            // 
            this.txtdateto.Location = new System.Drawing.Point(22, 103);
            this.txtdateto.Name = "txtdateto";
            this.txtdateto.Size = new System.Drawing.Size(100, 20);
            this.txtdateto.TabIndex = 3;
            this.txtdateto.Visible = false;
            // 
            // txtdatefrom
            // 
            this.txtdatefrom.Location = new System.Drawing.Point(22, 129);
            this.txtdatefrom.Name = "txtdatefrom";
            this.txtdatefrom.Size = new System.Drawing.Size(100, 20);
            this.txtdatefrom.TabIndex = 4;
            this.txtdatefrom.Visible = false;
            // 
            // Rpt_attnd_summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 600);
            this.Controls.Add(this.txtdatefrom);
            this.Controls.Add(this.txtdateto);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Rpt_attnd_summary";
            this.Text = "Rpt_attnd_summary";
            this.Load += new System.EventHandler(this.Rpt_attnd_summary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.attendanceDatasetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_dataset report_dataset;
        private System.Windows.Forms.BindingSource attendanceDatasetBindingSource;
        private Report_datasetTableAdapters.Attendance_DatasetTableAdapter attendance_DatasetTableAdapter;
        private System.Windows.Forms.TextBox txtdateto;
        private System.Windows.Forms.TextBox txtdatefrom;
    }
}