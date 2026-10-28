namespace School.ReportsNew
{
    partial class MonthlyClassWiseReceiving
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.student_DataSet = new School.Student_DataSet();
            this.monthWiseFeeReceivingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monthWiseFeeReceivingTableAdapter = new School.Student_DataSetTableAdapters.MonthWiseFeeReceivingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthWiseFeeReceivingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.monthWiseFeeReceivingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.ReportsNew.MonthlyClassWiseReceiving.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(886, 587);
            this.reportViewer1.TabIndex = 7;
            // 
            // student_DataSet
            // 
            this.student_DataSet.DataSetName = "Student_DataSet";
            this.student_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // monthWiseFeeReceivingBindingSource
            // 
            this.monthWiseFeeReceivingBindingSource.DataMember = "MonthWiseFeeReceiving";
            this.monthWiseFeeReceivingBindingSource.DataSource = this.student_DataSet;
            // 
            // monthWiseFeeReceivingTableAdapter
            // 
            this.monthWiseFeeReceivingTableAdapter.ClearBeforeFill = true;
            // 
            // MonthlyClassWiseReceiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 587);
            this.Controls.Add(this.reportViewer1);
            this.Name = "MonthlyClassWiseReceiving";
            this.Text = "Monthly Class Wise Fee Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MonthlyClassWiseReceiving_Load);
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthWiseFeeReceivingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource monthWiseFeeReceivingBindingSource;
        private Student_DataSet student_DataSet;
        private Student_DataSetTableAdapters.MonthWiseFeeReceivingTableAdapter monthWiseFeeReceivingTableAdapter;
    }
}