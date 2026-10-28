namespace School.Fee_Summary_Reports
{
    partial class Head_student_wise_fee_withouthead
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
            this.HEAD_STUDENT_WISE_FEEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Fee_Summary_Reports = new School.DataSet_Fee_Summary_Reports();
            this.hEADSTUDENTWISEFEEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.hEAD_STUDENT_WISE_FEETableAdapter = new School.DataSet_Fee_Summary_ReportsTableAdapters.HEAD_STUDENT_WISE_FEETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HEAD_STUDENT_WISE_FEEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hEADSTUDENTWISEFEEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // HEAD_STUDENT_WISE_FEEBindingSource
            // 
            this.HEAD_STUDENT_WISE_FEEBindingSource.DataMember = "HEAD_STUDENT_WISE_FEE";
            this.HEAD_STUDENT_WISE_FEEBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // dataSet_Fee_Summary_Reports
            // 
            this.dataSet_Fee_Summary_Reports.DataSetName = "DataSet_Fee_Summary_Reports";
            this.dataSet_Fee_Summary_Reports.EnforceConstraints = false;
            this.dataSet_Fee_Summary_Reports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hEADSTUDENTWISEFEEBindingSource
            // 
            this.hEADSTUDENTWISEFEEBindingSource.DataMember = "HEAD_STUDENT_WISE_FEE";
            this.hEADSTUDENTWISEFEEBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.HEAD_STUDENT_WISE_FEEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Fee_Summary_Reports.Head_student_wise_fee_withouthead.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(970, 584);
            this.reportViewer1.TabIndex = 7;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // hEAD_STUDENT_WISE_FEETableAdapter
            // 
            this.hEAD_STUDENT_WISE_FEETableAdapter.ClearBeforeFill = true;
            // 
            // Head_student_wise_fee_withouthead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 584);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Head_student_wise_fee_withouthead";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Head Class Wise Fee Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Head_Class_wise_feereport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HEAD_STUDENT_WISE_FEEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hEADSTUDENTWISEFEEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Fee_Summary_Reports fee_Summary_Reports;
        private DataSet_Fee_Summary_Reports.Head_Class_wise_FeereportDataTable head_Class_wise_FeereportTableAdapter;
        private System.Windows.Forms.BindingSource hEADSTUDENTWISEFEEBindingSource;
        private DataSet_Fee_Summary_Reports dataSet_Fee_Summary_Reports;
        private DataSet_Fee_Summary_ReportsTableAdapters.HEAD_STUDENT_WISE_FEETableAdapter hEAD_STUDENT_WISE_FEETableAdapter;
        private System.Windows.Forms.BindingSource HEAD_STUDENT_WISE_FEEBindingSource;
    }
}