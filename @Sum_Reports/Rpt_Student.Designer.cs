namespace School._forms
{
    partial class Rpt_Student
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.viewStudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.txtclassid = new System.Windows.Forms.TextBox();
            this.txtsearchingvalue = new System.Windows.Forms.TextBox();
            this.view_StudentTableAdapter = new School.Report_datasetTableAdapters.view_StudentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.viewStudentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            this.SuspendLayout();
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
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.viewStudentBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.RptStudent.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1000, 644);
            this.reportViewer1.TabIndex = 3;
            // 
            // txtvalue
            // 
            this.txtvalue.Location = new System.Drawing.Point(30, 122);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.Size = new System.Drawing.Size(100, 20);
            this.txtvalue.TabIndex = 5;
            this.txtvalue.Visible = false;
            // 
            // txtclassid
            // 
            this.txtclassid.Location = new System.Drawing.Point(30, 96);
            this.txtclassid.Name = "txtclassid";
            this.txtclassid.Size = new System.Drawing.Size(100, 20);
            this.txtclassid.TabIndex = 8;
            this.txtclassid.Visible = false;
            // 
            // txtsearchingvalue
            // 
            this.txtsearchingvalue.Location = new System.Drawing.Point(30, 148);
            this.txtsearchingvalue.Name = "txtsearchingvalue";
            this.txtsearchingvalue.Size = new System.Drawing.Size(100, 20);
            this.txtsearchingvalue.TabIndex = 9;
            this.txtsearchingvalue.Visible = false;
            // 
            // view_StudentTableAdapter
            // 
            this.view_StudentTableAdapter.ClearBeforeFill = true;
            // 
            // Rpt_Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 644);
            this.Controls.Add(this.txtsearchingvalue);
            this.Controls.Add(this.txtclassid);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Rpt_Student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Record";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Rpt_Student_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewStudentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_dataset report_dataset;
        private System.Windows.Forms.BindingSource viewStudentBindingSource;
        private Report_datasetTableAdapters.view_StudentTableAdapter view_StudentTableAdapter;
        private System.Windows.Forms.TextBox txtvalue;
        private System.Windows.Forms.TextBox txtclassid;
        private System.Windows.Forms.TextBox txtsearchingvalue;
    }
}