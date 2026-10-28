namespace School._forms
{
    partial class SummaryReport
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
            this.sUMMARY_REPORTTableAdapter = new School.Student_DataSetTableAdapters.SUMMARY_REPORTTableAdapter();
            this.tableAdapterManager = new School.Student_DataSetTableAdapters.TableAdapterManager();
            this.SUMMARY_REPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student_DataSet = new School.Student_DataSet();
            this.VIEW_CLASS_MONTH_HEAD_WISEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vIEWCLASSMONTHHEADWISEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vIEW_CLASS_MONTH_HEAD_WISETableAdapter = new School.Student_DataSetTableAdapters.VIEW_CLASS_MONTH_HEAD_WISETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SUMMARY_REPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VIEW_CLASS_MONTH_HEAD_WISEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIEWCLASSMONTHHEADWISEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SUMMARY_REPORTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.ReportsNew.SummaryReport1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1000, 644);
            this.reportViewer1.TabIndex = 3;
            // 
            // sUMMARY_REPORTTableAdapter
            // 
            this.sUMMARY_REPORTTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = School.Student_DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // SUMMARY_REPORTBindingSource
            // 
            this.SUMMARY_REPORTBindingSource.DataMember = "SUMMARY_REPORT";
            this.SUMMARY_REPORTBindingSource.DataSource = this.student_DataSet;
            // 
            // student_DataSet
            // 
            this.student_DataSet.DataSetName = "Student_DataSet";
            this.student_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VIEW_CLASS_MONTH_HEAD_WISEBindingSource
            // 
            this.VIEW_CLASS_MONTH_HEAD_WISEBindingSource.DataMember = "VIEW_CLASS_MONTH_HEAD_WISE";
            this.VIEW_CLASS_MONTH_HEAD_WISEBindingSource.DataSource = this.student_DataSet;
            // 
            // vIEWCLASSMONTHHEADWISEBindingSource
            // 
            this.vIEWCLASSMONTHHEADWISEBindingSource.DataMember = "VIEW_CLASS_MONTH_HEAD_WISE";
            this.vIEWCLASSMONTHHEADWISEBindingSource.DataSource = this.student_DataSet;
            // 
            // vIEW_CLASS_MONTH_HEAD_WISETableAdapter
            // 
            this.vIEW_CLASS_MONTH_HEAD_WISETableAdapter.ClearBeforeFill = true;
            // 
            // SummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 644);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SummaryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Record";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Rpt_Student_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SUMMARY_REPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VIEW_CLASS_MONTH_HEAD_WISEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIEWCLASSMONTHHEADWISEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Student_DataSet student_DataSet;
        private System.Windows.Forms.BindingSource vIEWCLASSMONTHHEADWISEBindingSource;
        private Student_DataSetTableAdapters.VIEW_CLASS_MONTH_HEAD_WISETableAdapter vIEW_CLASS_MONTH_HEAD_WISETableAdapter;
        private System.Windows.Forms.BindingSource VIEW_CLASS_MONTH_HEAD_WISEBindingSource;
        private System.Windows.Forms.BindingSource SUMMARY_REPORTBindingSource;
        private Student_DataSetTableAdapters.SUMMARY_REPORTTableAdapter sUMMARY_REPORTTableAdapter;
        private Student_DataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}