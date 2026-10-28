namespace School.Fee_Summary_Reports
{
    partial class Fee_according_strength
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
            this.FEE_ACCORDING_STRENGHTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Fee_Summary_Reports = new School.DataSet_Fee_Summary_Reports();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fEE_ACCORDING_STRENGHTTableAdapter = new School.DataSet_Fee_Summary_ReportsTableAdapters.FEE_ACCORDING_STRENGHTTableAdapter();
            this.tableAdapterManager = new School.DataSet_Fee_Summary_ReportsTableAdapters.TableAdapterManager();
            this.feemonthToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.dpAe = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FEE_ACCORDING_STRENGHTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).BeginInit();
            this.SuspendLayout();
            // 
            // FEE_ACCORDING_STRENGHTBindingSource
            // 
            this.FEE_ACCORDING_STRENGHTBindingSource.DataMember = "FEE_ACCORDING_STRENGHT";
            this.FEE_ACCORDING_STRENGHTBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // dataSet_Fee_Summary_Reports
            // 
            this.dataSet_Fee_Summary_Reports.DataSetName = "DataSet_Fee_Summary_Reports";
            this.dataSet_Fee_Summary_Reports.EnforceConstraints = false;
            this.dataSet_Fee_Summary_Reports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FEE_ACCORDING_STRENGHTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Fee_Summary_Reports.Fee_according_strength.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 45);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(990, 597);
            this.reportViewer1.TabIndex = 7;
            // 
            // fEE_ACCORDING_STRENGHTTableAdapter
            // 
            this.fEE_ACCORDING_STRENGHTTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = School.DataSet_Fee_Summary_ReportsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // feemonthToolStripTextBox
            // 
            this.feemonthToolStripTextBox.Name = "feemonthToolStripTextBox";
            this.feemonthToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // dpAe
            // 
            this.dpAe.CustomFormat = "MM yyyy";
            this.dpAe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpAe.Location = new System.Drawing.Point(102, 10);
            this.dpAe.Name = "dpAe";
            this.dpAe.Size = new System.Drawing.Size(99, 20);
            this.dpAe.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 9);
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
            // Fee_according_strength
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 642);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dpAe);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Fee_according_strength";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee According to Strength";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Head_Class_wise_feereport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FEE_ACCORDING_STRENGHTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Fee_Summary_Reports fee_Summary_Reports;
        private DataSet_Fee_Summary_Reports.Head_Class_wise_FeereportDataTable head_Class_wise_FeereportTableAdapter;
        private System.Windows.Forms.BindingSource FEE_ACCORDING_STRENGHTBindingSource;
        private DataSet_Fee_Summary_Reports dataSet_Fee_Summary_Reports;
        private DataSet_Fee_Summary_ReportsTableAdapters.FEE_ACCORDING_STRENGHTTableAdapter fEE_ACCORDING_STRENGHTTableAdapter;
        private DataSet_Fee_Summary_ReportsTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ToolStripTextBox feemonthToolStripTextBox;
        private System.Windows.Forms.DateTimePicker dpAe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}