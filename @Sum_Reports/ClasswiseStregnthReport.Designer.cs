namespace School._forms
{
    partial class ClasswiseStregnthReport
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
            this.Class_wise_stregnthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_DataSet_new = new School.Report_DataSet_new();
            this.classwisestregnthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.class_wise_stregnthTableAdapter = new School.Report_DataSet_newTableAdapters.Class_wise_stregnthTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Class_wise_stregnthBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classwisestregnthBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Class_wise_stregnthBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.StrengthReport1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1072, 722);
            this.reportViewer1.TabIndex = 6;
            // 
            // Class_wise_stregnthBindingSource
            // 
            this.Class_wise_stregnthBindingSource.DataMember = "Class_wise_stregnth";
            this.Class_wise_stregnthBindingSource.DataSource = this.report_DataSet_new;
            // 
            // report_DataSet_new
            // 
            this.report_DataSet_new.DataSetName = "Report_DataSet_new";
            this.report_DataSet_new.EnforceConstraints = false;
            this.report_DataSet_new.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // classwisestregnthBindingSource
            // 
            this.classwisestregnthBindingSource.DataMember = "Class_wise_stregnth";
            this.classwisestregnthBindingSource.DataSource = this.report_DataSet_new;
            // 
            // class_wise_stregnthTableAdapter
            // 
            this.class_wise_stregnthTableAdapter.ClearBeforeFill = true;
            // 
            // ClasswiseStregnthReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 722);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ClasswiseStregnthReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ClasswiseStregnthReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Class_wise_stregnthBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classwisestregnthBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_DataSet_new report_DataSet_new;
        private System.Windows.Forms.BindingSource classwisestregnthBindingSource;
        private Report_DataSet_newTableAdapters.Class_wise_stregnthTableAdapter class_wise_stregnthTableAdapter;
        private System.Windows.Forms.BindingSource Class_wise_stregnthBindingSource;
    }
}