namespace School._Sum_Reports
{
    partial class rptstreginths_mwisee
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
            this.aDMISSIONSTREGNTHREPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student_DataSet = new School.Student_DataSet();
            this.aDMISSION_STREGNTH_REPORTTableAdapter = new School.Student_DataSetTableAdapters.ADMISSION_STREGNTH_REPORTTableAdapter();
            this.ADMISSION_STREGNTH_REPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.aDMISSIONSTREGNTHREPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ADMISSION_STREGNTH_REPORTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ADMISSION_STREGNTH_REPORTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.Rpt_stregnth_report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(995, 579);
            this.reportViewer1.TabIndex = 7;
            // 
            // aDMISSIONSTREGNTHREPORTBindingSource
            // 
            this.aDMISSIONSTREGNTHREPORTBindingSource.DataMember = "ADMISSION_STREGNTH_REPORT";
            this.aDMISSIONSTREGNTHREPORTBindingSource.DataSource = this.student_DataSet;
            // 
            // student_DataSet
            // 
            this.student_DataSet.DataSetName = "Student_DataSet";
            this.student_DataSet.EnforceConstraints = false;
            this.student_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aDMISSION_STREGNTH_REPORTTableAdapter
            // 
            this.aDMISSION_STREGNTH_REPORTTableAdapter.ClearBeforeFill = true;
            // 
            // ADMISSION_STREGNTH_REPORTBindingSource
            // 
            this.ADMISSION_STREGNTH_REPORTBindingSource.DataMember = "ADMISSION_STREGNTH_REPORT";
            this.ADMISSION_STREGNTH_REPORTBindingSource.DataSource = this.student_DataSet;
            // 
            // rptstreginths_mwisee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 579);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptstreginths_mwisee";
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptstreginths_mwisee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aDMISSIONSTREGNTHREPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ADMISSION_STREGNTH_REPORTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource aDMISSIONSTREGNTHREPORTBindingSource;
        private Student_DataSet student_DataSet;
        private Student_DataSetTableAdapters.ADMISSION_STREGNTH_REPORTTableAdapter aDMISSION_STREGNTH_REPORTTableAdapter;
        private System.Windows.Forms.BindingSource ADMISSION_STREGNTH_REPORTBindingSource;
    }
}