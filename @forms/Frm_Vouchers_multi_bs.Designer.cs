namespace School._forms
{
    partial class Frm_Vouchers_multi_bs
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
            this.Voucher_Print_multiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_DataSet_new = new School.Report_DataSet_new();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.voucherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.voucherTableAdapter = new School.Report_datasetTableAdapters.VoucherTableAdapter();
            this.Voucher_PrintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.voucherPrintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.voucher_PrintTableAdapter = new School.Report_DataSet_newTableAdapters.Voucher_PrintTableAdapter();
            this.voucher_Print_multiTableAdapter = new School.Report_DataSet_newTableAdapters.Voucher_Print_multiTableAdapter();
            this.tableAdapterManager = new School.Report_DataSet_newTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.Voucher_Print_multiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Voucher_PrintBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherPrintBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Voucher_Print_multiBindingSource
            // 
            this.Voucher_Print_multiBindingSource.DataMember = "Voucher_Print_multi";
            this.Voucher_Print_multiBindingSource.DataSource = this.report_DataSet_new;
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
            reportDataSource1.Value = this.Voucher_Print_multiBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.RptPrintAll_multi_BS.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1379, 811);
            this.reportViewer1.TabIndex = 2;
            // 
            // voucherBindingSource
            // 
            this.voucherBindingSource.DataMember = "Voucher";
            this.voucherBindingSource.DataSource = this.report_dataset;
            // 
            // report_dataset
            // 
            this.report_dataset.DataSetName = "Report_dataset";
            this.report_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // voucherTableAdapter
            // 
            this.voucherTableAdapter.ClearBeforeFill = true;
            // 
            // Voucher_PrintBindingSource
            // 
            this.Voucher_PrintBindingSource.DataMember = "Voucher_Print";
            this.Voucher_PrintBindingSource.DataSource = this.report_DataSet_new;
            // 
            // voucherPrintBindingSource
            // 
            this.voucherPrintBindingSource.DataMember = "Voucher_Print";
            this.voucherPrintBindingSource.DataSource = this.report_DataSet_new;
            // 
            // voucher_PrintTableAdapter
            // 
            this.voucher_PrintTableAdapter.ClearBeforeFill = true;
            // 
            // voucher_Print_multiTableAdapter
            // 
            this.voucher_Print_multiTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.EDIT_VOUCHERTableAdapter = null;
            this.tableAdapterManager.Fee_Class_updateTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = School.Report_DataSet_newTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Frm_Vouchers_multi_bs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 811);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Vouchers_multi_bs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher Printing M";
            this.Load += new System.EventHandler(this.Frm_Vouchers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Voucher_Print_multiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Voucher_PrintBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.voucherPrintBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_dataset report_dataset;
        private System.Windows.Forms.BindingSource voucherBindingSource;
        private Report_datasetTableAdapters.VoucherTableAdapter voucherTableAdapter;
        private System.Windows.Forms.BindingSource voucherPrintBindingSource;
        private Report_DataSet_new report_DataSet_new;
        private Report_DataSet_newTableAdapters.Voucher_PrintTableAdapter voucher_PrintTableAdapter;
        private System.Windows.Forms.BindingSource Voucher_PrintBindingSource;
        private Report_DataSet_newTableAdapters.Voucher_Print_multiTableAdapter voucher_Print_multiTableAdapter;
        private Report_DataSet_newTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource Voucher_Print_multiBindingSource;

    }
}