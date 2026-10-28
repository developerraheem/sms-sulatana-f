namespace School.Attendance_module
{
    partial class rpt_class_wise_attendance
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
            this.Class_wise_attendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.attendance_ds = new School.Attendance_ds();
            this.classwiseattendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.class_wise_attendanceTableAdapter = new School.Attendance_dsTableAdapters.Class_wise_attendanceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Class_wise_attendanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendance_ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classwiseattendanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Class_wise_attendanceBindingSource
            // 
            this.Class_wise_attendanceBindingSource.DataMember = "Class_wise_attendance";
            this.Class_wise_attendanceBindingSource.DataSource = this.attendance_ds;
            // 
            // attendance_ds
            // 
            this.attendance_ds.DataSetName = "Attendance_ds";
            this.attendance_ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // classwiseattendanceBindingSource
            // 
            this.classwiseattendanceBindingSource.DataMember = "Class_wise_attendance";
            this.classwiseattendanceBindingSource.DataSource = this.attendance_ds;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Class_wise_attendanceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Attendance_module.rpt_class_wise_attendance.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1496, 721);
            this.reportViewer1.TabIndex = 7;
            // 
            // class_wise_attendanceTableAdapter
            // 
            this.class_wise_attendanceTableAdapter.ClearBeforeFill = true;
            // 
            // rpt_class_wise_attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 721);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "rpt_class_wise_attendance";
            this.Text = "Class wise Attendance Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rpt_class_wise_attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Class_wise_attendanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendance_ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classwiseattendanceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource classwiseattendanceBindingSource;
        private Attendance_ds attendance_ds;
        private Attendance_dsTableAdapters.Class_wise_attendanceTableAdapter class_wise_attendanceTableAdapter;
        private System.Windows.Forms.BindingSource Class_wise_attendanceBindingSource;
    }
}