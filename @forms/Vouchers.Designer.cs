namespace School._forms
{
    partial class Vouchers
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
            this.voucherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fillBy1ToolStrip = new System.Windows.Forms.ToolStrip();
            this.fEE_MASTER_IDToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.fEE_MASTER_IDToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillBy1ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.voucherTableAdapter = new School.Report_datasetTableAdapters.VoucherTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.voucherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            this.fillBy1ToolStrip.SuspendLayout();
            this.SuspendLayout();
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
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.voucherBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.@Sum_Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(898, 623);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // fillBy1ToolStrip
            // 
            this.fillBy1ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fEE_MASTER_IDToolStripLabel,
            this.fEE_MASTER_IDToolStripTextBox,
            this.fillBy1ToolStripButton});
            this.fillBy1ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillBy1ToolStrip.Name = "fillBy1ToolStrip";
            this.fillBy1ToolStrip.Size = new System.Drawing.Size(898, 25);
            this.fillBy1ToolStrip.TabIndex = 4;
            this.fillBy1ToolStrip.Text = "fillBy1ToolStrip";
            // 
            // fEE_MASTER_IDToolStripLabel
            // 
            this.fEE_MASTER_IDToolStripLabel.Name = "fEE_MASTER_IDToolStripLabel";
            this.fEE_MASTER_IDToolStripLabel.Size = new System.Drawing.Size(94, 22);
            this.fEE_MASTER_IDToolStripLabel.Text = "FEE_MASTER_ID:";
            // 
            // fEE_MASTER_IDToolStripTextBox
            // 
            this.fEE_MASTER_IDToolStripTextBox.Name = "fEE_MASTER_IDToolStripTextBox";
            this.fEE_MASTER_IDToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fillBy1ToolStripButton
            // 
            this.fillBy1ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillBy1ToolStripButton.Name = "fillBy1ToolStripButton";
            this.fillBy1ToolStripButton.Size = new System.Drawing.Size(45, 22);
            this.fillBy1ToolStripButton.Text = "FillBy1";
            this.fillBy1ToolStripButton.Click += new System.EventHandler(this.fillBy1ToolStripButton_Click);
            // 
            // voucherTableAdapter
            // 
            this.voucherTableAdapter.ClearBeforeFill = true;
            // 
            // Vouchers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 623);
            this.Controls.Add(this.fillBy1ToolStrip);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Vouchers";
            this.Text = "Vouchers";
            this.Load += new System.EventHandler(this.Vouchers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.voucherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            this.fillBy1ToolStrip.ResumeLayout(false);
            this.fillBy1ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Report_dataset report_dataset;
        private System.Windows.Forms.BindingSource voucherBindingSource;
        private Report_datasetTableAdapters.VoucherTableAdapter voucherTableAdapter;
        private System.Windows.Forms.ToolStrip fillBy1ToolStrip;
        private System.Windows.Forms.ToolStripLabel fEE_MASTER_IDToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox fEE_MASTER_IDToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillBy1ToolStripButton;

    }
}