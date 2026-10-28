namespace School._forms
{
    partial class rptFee
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
            this.Fee_VoucherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fee_VoucherTableAdapter = new School.Report_datasetTableAdapters.Fee_VoucherTableAdapter();
            this.tableAdapterManager = new School.Report_datasetTableAdapters.TableAdapterManager();
            this.reportdatasetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtclassid = new System.Windows.Forms.TextBox();
            this.txtrollno = new System.Windows.Forms.TextBox();
            this.txtmonth = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Fee_VoucherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportdatasetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Fee_VoucherBindingSource
            // 
            this.Fee_VoucherBindingSource.DataMember = "Fee_Voucher";
            this.Fee_VoucherBindingSource.DataSource = this.report_dataset;
            // 
            // report_dataset
            // 
            this.report_dataset.DataSetName = "Report_dataset";
            this.report_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Fee_VoucherBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.Rpt_feevoucher.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(544, 493);
            this.reportViewer1.TabIndex = 0;
            // 
            // fee_VoucherTableAdapter
            // 
            this.fee_VoucherTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = School.Report_datasetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // reportdatasetBindingSource
            // 
            this.reportdatasetBindingSource.DataSource = this.report_dataset;
            this.reportdatasetBindingSource.Position = 0;
            // 
            // txtclassid
            // 
            this.txtclassid.Location = new System.Drawing.Point(113, 129);
            this.txtclassid.Name = "txtclassid";
            this.txtclassid.Size = new System.Drawing.Size(100, 20);
            this.txtclassid.TabIndex = 1;
            this.txtclassid.Visible = false;
            // 
            // txtrollno
            // 
            this.txtrollno.Location = new System.Drawing.Point(223, 238);
            this.txtrollno.Name = "txtrollno";
            this.txtrollno.Size = new System.Drawing.Size(100, 20);
            this.txtrollno.TabIndex = 2;
            this.txtrollno.Visible = false;
            // 
            // txtmonth
            // 
            this.txtmonth.Location = new System.Drawing.Point(237, 300);
            this.txtmonth.Name = "txtmonth";
            this.txtmonth.Size = new System.Drawing.Size(100, 20);
            this.txtmonth.TabIndex = 3;
            this.txtmonth.Visible = false;
            // 
            // rptFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 497);
            this.Controls.Add(this.txtmonth);
            this.Controls.Add(this.txtrollno);
            this.Controls.Add(this.txtclassid);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "rptFee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Voucher Print";
            this.Load += new System.EventHandler(this.rptFee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Fee_VoucherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportdatasetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Fee_VoucherBindingSource;
        private Report_dataset report_dataset;
        private System.Windows.Forms.BindingSource reportdatasetBindingSource;
        private Report_datasetTableAdapters.Fee_VoucherTableAdapter fee_VoucherTableAdapter;
        private Report_datasetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox txtclassid;
        private System.Windows.Forms.TextBox txtrollno;
        private System.Windows.Forms.TextBox txtmonth;





    }
}