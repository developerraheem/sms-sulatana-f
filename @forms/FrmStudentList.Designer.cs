namespace School._forms
{
    partial class FrmStudentList
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
            this.view_StudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_DataSet_new = new School.Report_DataSet_new();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtclassid = new System.Windows.Forms.TextBox();
            this.txtsession = new System.Windows.Forms.TextBox();
            this.viewStudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.view_StudentTableAdapter = new School.Report_datasetTableAdapters.view_StudentTableAdapter();
            this.viewStudentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.view_StudentTableAdapter1 = new School.Report_DataSet_newTableAdapters.view_StudentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.view_StudentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStudentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStudentBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // view_StudentBindingSource
            // 
            this.view_StudentBindingSource.DataMember = "view_Student";
            this.view_StudentBindingSource.DataSource = this.report_DataSet_new;
            // 
            // report_DataSet_new
            // 
            this.report_DataSet_new.DataSetName = "Report_DataSet_new";
            this.report_DataSet_new.EnforceConstraints = false;
            this.report_DataSet_new.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.view_StudentBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.RptStudetnList.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(970, 625);
            this.reportViewer1.TabIndex = 2;
            // 
            // txtclassid
            // 
            this.txtclassid.Location = new System.Drawing.Point(103, 173);
            this.txtclassid.Name = "txtclassid";
            this.txtclassid.Size = new System.Drawing.Size(100, 20);
            this.txtclassid.TabIndex = 4;
            this.txtclassid.Visible = false;
            // 
            // txtsession
            // 
            this.txtsession.Location = new System.Drawing.Point(426, 293);
            this.txtsession.Name = "txtsession";
            this.txtsession.Size = new System.Drawing.Size(100, 20);
            this.txtsession.TabIndex = 5;
            this.txtsession.Visible = false;
            // 
            // viewStudentBindingSource
            // 
            this.viewStudentBindingSource.DataMember = "view_Student";
            this.viewStudentBindingSource.DataSource = this.report_dataset;
            // 
            // report_dataset
            // 
            this.report_dataset.DataSetName = "Report_dataset";
            this.report_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view_StudentTableAdapter
            // 
            this.view_StudentTableAdapter.ClearBeforeFill = true;
            // 
            // viewStudentBindingSource1
            // 
            this.viewStudentBindingSource1.DataMember = "view_Student";
            this.viewStudentBindingSource1.DataSource = this.report_DataSet_new;
            // 
            // view_StudentTableAdapter1
            // 
            this.view_StudentTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmStudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 625);
            this.Controls.Add(this.txtsession);
            this.Controls.Add(this.txtclassid);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmStudentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class wise Student List Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmStudentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.view_StudentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStudentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStudentBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_dataset report_dataset;
        private System.Windows.Forms.BindingSource viewStudentBindingSource;
        private Report_datasetTableAdapters.view_StudentTableAdapter view_StudentTableAdapter;
        private System.Windows.Forms.TextBox txtclassid;
        private System.Windows.Forms.TextBox txtsession;
        private System.Windows.Forms.BindingSource viewStudentBindingSource1;
        private Report_DataSet_new report_DataSet_new;
        private Report_DataSet_newTableAdapters.view_StudentTableAdapter view_StudentTableAdapter1;
        private System.Windows.Forms.BindingSource view_StudentBindingSource;
    }
}