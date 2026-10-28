namespace School._forms
{
    partial class RptExpReport
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
            this.Expense_DetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.expenseDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.expense_DetailTableAdapter = new School.Report_datasetTableAdapters.Expense_DetailTableAdapter();
            this.txtdto = new System.Windows.Forms.TextBox();
            this.txtdfrom = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Expense_DetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expenseDetailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Expense_DetailBindingSource
            // 
            this.Expense_DetailBindingSource.DataMember = "Expense_Detail";
            this.Expense_DetailBindingSource.DataSource = this.report_dataset;
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
            reportDataSource1.Value = this.Expense_DetailBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.RptExpense.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(973, 595);
            this.reportViewer1.TabIndex = 2;
            // 
            // expenseDetailBindingSource
            // 
            this.expenseDetailBindingSource.DataMember = "Expense_Detail";
            this.expenseDetailBindingSource.DataSource = this.report_dataset;
            // 
            // expense_DetailTableAdapter
            // 
            this.expense_DetailTableAdapter.ClearBeforeFill = true;
            // 
            // txtdto
            // 
            this.txtdto.Location = new System.Drawing.Point(28, 79);
            this.txtdto.Name = "txtdto";
            this.txtdto.Size = new System.Drawing.Size(100, 20);
            this.txtdto.TabIndex = 4;
            this.txtdto.Visible = false;
            // 
            // txtdfrom
            // 
            this.txtdfrom.Location = new System.Drawing.Point(28, 105);
            this.txtdfrom.Name = "txtdfrom";
            this.txtdfrom.Size = new System.Drawing.Size(100, 20);
            this.txtdfrom.TabIndex = 5;
            this.txtdfrom.Visible = false;
            // 
            // RptExpReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(973, 595);
            this.Controls.Add(this.txtdfrom);
            this.Controls.Add(this.txtdto);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RptExpReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Date Wise Expense Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RptExpReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Expense_DetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expenseDetailBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource expenseDetailBindingSource;
        private Report_dataset report_dataset;
        private Report_datasetTableAdapters.Expense_DetailTableAdapter expense_DetailTableAdapter;
        private System.Windows.Forms.BindingSource Expense_DetailBindingSource;
        private System.Windows.Forms.TextBox txtdto;
        private System.Windows.Forms.TextBox txtdfrom;
    }
}