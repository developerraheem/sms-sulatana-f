namespace School._forms
{
    partial class PrntClasswiseoutst
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
            this.MonthlyFeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_DataSet_new = new School.Report_DataSet_new();
            this.Month_wise_fee_statusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.monthwisefeestatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.month_wise_fee_statusTableAdapter = new School.Report_DataSet_newTableAdapters.Month_wise_fee_statusTableAdapter();
            this.monthlyFeeTableAdapter = new School.Report_DataSet_newTableAdapters.MonthlyFeeTableAdapter();
            this.tableAdapterManager = new School.Report_DataSet_newTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.MonthlyFeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Month_wise_fee_statusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthwisefeestatusBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MonthlyFeeBindingSource
            // 
            this.MonthlyFeeBindingSource.DataMember = "MonthlyFee";
            this.MonthlyFeeBindingSource.DataSource = this.report_DataSet_new;
            // 
            // report_DataSet_new
            // 
            this.report_DataSet_new.DataSetName = "Report_DataSet_new";
            this.report_DataSet_new.EnforceConstraints = false;
            this.report_DataSet_new.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Month_wise_fee_statusBindingSource
            // 
            this.Month_wise_fee_statusBindingSource.DataMember = "Month_wise_fee_status";
            this.Month_wise_fee_statusBindingSource.DataSource = this.report_DataSet_new;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.MonthlyFeeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.ReportsNew.feemonthlyreport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(745, 504);
            this.reportViewer1.TabIndex = 5;
            // 
            // monthwisefeestatusBindingSource
            // 
            this.monthwisefeestatusBindingSource.DataMember = "Month_wise_fee_status";
            this.monthwisefeestatusBindingSource.DataSource = this.report_DataSet_new;
            // 
            // month_wise_fee_statusTableAdapter
            // 
            this.month_wise_fee_statusTableAdapter.ClearBeforeFill = true;
            // 
            // monthlyFeeTableAdapter
            // 
            this.monthlyFeeTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.EDIT_VOUCHERTableAdapter = null;
            this.tableAdapterManager.Fee_Class_updateTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = School.Report_DataSet_newTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // PrntClasswiseoutst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 504);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrntClasswiseoutst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class Wise Outstanding Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrntClasswiseoutst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MonthlyFeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Month_wise_fee_statusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthwisefeestatusBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_DataSet_new report_DataSet_new;
        private System.Windows.Forms.BindingSource monthwisefeestatusBindingSource;
        private Report_DataSet_newTableAdapters.Month_wise_fee_statusTableAdapter month_wise_fee_statusTableAdapter;
        private System.Windows.Forms.BindingSource Month_wise_fee_statusBindingSource;
        private System.Windows.Forms.BindingSource MonthlyFeeBindingSource;
        private Report_DataSet_newTableAdapters.MonthlyFeeTableAdapter monthlyFeeTableAdapter;
        private Report_DataSet_newTableAdapters.TableAdapterManager tableAdapterManager;
    }
}