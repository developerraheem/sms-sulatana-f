namespace School._forms
{
    partial class RptDaily_attand
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
            this.dailyattndBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_dataset = new School.Report_dataset();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.daily_attndTableAdapter = new School.Report_datasetTableAdapters.daily_attndTableAdapter();
            this.txtdate = new System.Windows.Forms.TextBox();
            this.txtclassid = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dailyattndBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // dailyattndBindingSource
            // 
            this.dailyattndBindingSource.DataMember = "daily_attnd";
            this.dailyattndBindingSource.DataSource = this.report_dataset;
            // 
            // report_dataset
            // 
            this.report_dataset.DataSetName = "Report_dataset";
            this.report_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dailyattndBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Reports.RptDailyAttnd.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(713, 620);
            this.reportViewer1.TabIndex = 2;
            // 
            // daily_attndTableAdapter
            // 
            this.daily_attndTableAdapter.ClearBeforeFill = true;
            // 
            // txtdate
            // 
            this.txtdate.Location = new System.Drawing.Point(312, 330);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(100, 20);
            this.txtdate.TabIndex = 6;
            this.txtdate.Visible = false;
            // 
            // txtclassid
            // 
            this.txtclassid.Location = new System.Drawing.Point(300, 272);
            this.txtclassid.Name = "txtclassid";
            this.txtclassid.Size = new System.Drawing.Size(100, 20);
            this.txtclassid.TabIndex = 5;
            this.txtclassid.Visible = false;
            // 
            // RptDaily_attand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 623);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.txtclassid);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "RptDaily_attand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Attandence Report";
            this.Load += new System.EventHandler(this.RptDaily_attand_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dailyattndBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_dataset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dailyattndBindingSource;
        private Report_dataset report_dataset;
        private Report_datasetTableAdapters.daily_attndTableAdapter daily_attndTableAdapter;
        private System.Windows.Forms.TextBox txtdate;
        private System.Windows.Forms.TextBox txtclassid;
    }
}