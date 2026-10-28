namespace School.ReportsNew
{
    partial class DefaulterStudents
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
            this.FEE_HISTORYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_DataSet_new = new School.Report_DataSet_new();
            this.fEEHISTORYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fEE_HISTORYTableAdapter = new School.Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FEE_HISTORYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fEEHISTORYBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FEE_HISTORYBindingSource
            // 
            this.FEE_HISTORYBindingSource.DataMember = "FEE_HISTORY";
            this.FEE_HISTORYBindingSource.DataSource = this.report_DataSet_new;
            // 
            // report_DataSet_new
            // 
            this.report_DataSet_new.DataSetName = "Report_DataSet_new";
            this.report_DataSet_new.EnforceConstraints = false;
            this.report_DataSet_new.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fEEHISTORYBindingSource
            // 
            this.fEEHISTORYBindingSource.DataMember = "FEE_HISTORY";
            this.fEEHISTORYBindingSource.DataSource = this.report_DataSet_new;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FEE_HISTORYBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.ReportsNew.DefaulterStudents1_n.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1321, 725);
            this.reportViewer1.TabIndex = 6;
            // 
            // fEE_HISTORYTableAdapter
            // 
            this.fEE_HISTORYTableAdapter.ClearBeforeFill = true;
            // 
            // DefaulterStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 725);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DefaulterStudents";
            this.Text = "DefaulterStudents";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DefaulterStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FEE_HISTORYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fEEHISTORYBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource fEEHISTORYBindingSource;
        private Report_DataSet_new report_DataSet_new;
        private Report_DataSet_newTableAdapters.FEE_HISTORYTableAdapter fEE_HISTORYTableAdapter;
        private System.Windows.Forms.BindingSource FEE_HISTORYBindingSource;
    }
}