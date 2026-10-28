namespace School.Fee_Summary_Reports
{
    partial class Head_Class_wise_feereport
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
            this.headClasswiseFeereportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Fee_Summary_Reports = new School.DataSet_Fee_Summary_Reports();
            this.head_Class_wise_FeereportTableAdapter1 = new School.DataSet_Fee_Summary_ReportsTableAdapters.Head_Class_wise_FeereportTableAdapter();
            this.Head_Class_wise_FeereportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headClasswiseFeereportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Head_Class_wise_FeereportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Head_Class_wise_FeereportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Fee_Summary_Reports.Head_Class_wise_feereport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(970, 584);
            this.reportViewer1.TabIndex = 7;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // headClasswiseFeereportBindingSource
            // 
            this.headClasswiseFeereportBindingSource.DataMember = "Head_Class_wise_Feereport";
            this.headClasswiseFeereportBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // dataSet_Fee_Summary_Reports
            // 
            this.dataSet_Fee_Summary_Reports.DataSetName = "DataSet_Fee_Summary_Reports";
            this.dataSet_Fee_Summary_Reports.EnforceConstraints = false;
            this.dataSet_Fee_Summary_Reports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // head_Class_wise_FeereportTableAdapter1
            // 
            this.head_Class_wise_FeereportTableAdapter1.ClearBeforeFill = true;
            // 
            // Head_Class_wise_FeereportBindingSource
            // 
            this.Head_Class_wise_FeereportBindingSource.DataMember = "Head_Class_wise_Feereport";
            this.Head_Class_wise_FeereportBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // Head_Class_wise_feereport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 584);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Head_Class_wise_feereport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Head Class Wise Fee Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Head_Class_wise_feereport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headClasswiseFeereportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Head_Class_wise_FeereportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Fee_Summary_Reports fee_Summary_Reports;
        private DataSet_Fee_Summary_Reports.Head_Class_wise_FeereportDataTable head_Class_wise_FeereportTableAdapter;
        private System.Windows.Forms.BindingSource headClasswiseFeereportBindingSource;
        private DataSet_Fee_Summary_Reports dataSet_Fee_Summary_Reports;
        private DataSet_Fee_Summary_ReportsTableAdapters.Head_Class_wise_FeereportTableAdapter head_Class_wise_FeereportTableAdapter1;
        private System.Windows.Forms.BindingSource Head_Class_wise_FeereportBindingSource;
    }
}