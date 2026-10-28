namespace School._forms
{
    partial class rpt_admission_datewise_rpt
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
            this.aDMISSIONDATEWISEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student_DataSet = new School.Student_DataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.aDMISSION_DATEWISETableAdapter = new School.Student_DataSetTableAdapters.ADMISSION_DATEWISETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.aDMISSIONDATEWISEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // aDMISSIONDATEWISEBindingSource
            // 
            this.aDMISSIONDATEWISEBindingSource.DataMember = "ADMISSION_DATEWISE";
            this.aDMISSIONDATEWISEBindingSource.DataSource = this.student_DataSet;
            // 
            // student_DataSet
            // 
            this.student_DataSet.DataSetName = "Student_DataSet";
            this.student_DataSet.EnforceConstraints = false;
            this.student_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.aDMISSIONDATEWISEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.rpt_admission_datewise.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(804, 587);
            this.reportViewer1.TabIndex = 6;
            // 
            // aDMISSION_DATEWISETableAdapter
            // 
            this.aDMISSION_DATEWISETableAdapter.ClearBeforeFill = true;
            // 
            // rpt_admission_datewise_rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 587);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rpt_admission_datewise_rpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Voucher Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrntUnpaidvoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aDMISSIONDATEWISEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource aDMISSIONDATEWISEBindingSource;
        private Student_DataSet student_DataSet;
        private Student_DataSetTableAdapters.ADMISSION_DATEWISETableAdapter aDMISSION_DATEWISETableAdapter;
    }
}