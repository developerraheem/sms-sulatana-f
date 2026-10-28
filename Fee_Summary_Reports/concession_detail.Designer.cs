namespace School.Fee_Summary_Reports
{
    partial class concession_detail
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
            this.SULTANA_CONCESSIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Fee_Summary_Reports = new School.DataSet_Fee_Summary_Reports();
            this.sULTANACONCESSIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.feemonthToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.txtfeemonth = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sULTANA_CONCESSIONTableAdapter = new School.DataSet_Fee_Summary_ReportsTableAdapters.SULTANA_CONCESSIONTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SULTANA_CONCESSIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sULTANACONCESSIONBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SULTANA_CONCESSIONBindingSource
            // 
            this.SULTANA_CONCESSIONBindingSource.DataMember = "SULTANA_CONCESSION";
            this.SULTANA_CONCESSIONBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // dataSet_Fee_Summary_Reports
            // 
            this.dataSet_Fee_Summary_Reports.DataSetName = "DataSet_Fee_Summary_Reports";
            this.dataSet_Fee_Summary_Reports.EnforceConstraints = false;
            this.dataSet_Fee_Summary_Reports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sULTANACONCESSIONBindingSource
            // 
            this.sULTANACONCESSIONBindingSource.DataMember = "SULTANA_CONCESSION";
            this.sULTANACONCESSIONBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SULTANA_CONCESSIONBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Fee_Summary_Reports.concession_detail.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 41);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(990, 608);
            this.reportViewer1.TabIndex = 7;
            // 
            // feemonthToolStripTextBox
            // 
            this.feemonthToolStripTextBox.Name = "feemonthToolStripTextBox";
            this.feemonthToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // txtfeemonth
            // 
            this.txtfeemonth.CustomFormat = "MM yyyy";
            this.txtfeemonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtfeemonth.Location = new System.Drawing.Point(103, 10);
            this.txtfeemonth.Name = "txtfeemonth";
            this.txtfeemonth.Size = new System.Drawing.Size(99, 20);
            this.txtfeemonth.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Select Fee Month";
            // 
            // sULTANA_CONCESSIONTableAdapter
            // 
            this.sULTANA_CONCESSIONTableAdapter.ClearBeforeFill = true;
            // 
            // concession_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 649);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtfeemonth);
            this.Controls.Add(this.reportViewer1);
            this.Name = "concession_detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Concession Detail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Head_Class_wise_feereport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SULTANA_CONCESSIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sULTANACONCESSIONBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Fee_Summary_Reports fee_Summary_Reports;
        private DataSet_Fee_Summary_Reports.Head_Class_wise_FeereportDataTable head_Class_wise_FeereportTableAdapter;
        private System.Windows.Forms.ToolStripTextBox feemonthToolStripTextBox;
        private System.Windows.Forms.DateTimePicker txtfeemonth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private DataSet_Fee_Summary_Reports dataSet_Fee_Summary_Reports;
        private System.Windows.Forms.BindingSource sULTANACONCESSIONBindingSource;
        private DataSet_Fee_Summary_ReportsTableAdapters.SULTANA_CONCESSIONTableAdapter sULTANA_CONCESSIONTableAdapter;
        private System.Windows.Forms.BindingSource SULTANA_CONCESSIONBindingSource;
    }
}