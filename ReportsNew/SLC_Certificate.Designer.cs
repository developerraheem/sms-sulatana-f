namespace School._forms
{
    partial class SLC_Certificate
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
            this.SLC_CERTIFICATEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student_DataSet = new School.Student_DataSet();
            this.sLCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sLCTableAdapter = new School.Student_DataSetTableAdapters.SLCTableAdapter();
            this.sLCCERTIFICATEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sLC_CERTIFICATETableAdapter = new School.Student_DataSetTableAdapters.SLC_CERTIFICATETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SLC_CERTIFICATEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sLCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sLCCERTIFICATEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SLC_CERTIFICATEBindingSource
            // 
            this.SLC_CERTIFICATEBindingSource.DataMember = "SLC_CERTIFICATE";
            this.SLC_CERTIFICATEBindingSource.DataSource = this.student_DataSet;
            // 
            // student_DataSet
            // 
            this.student_DataSet.DataSetName = "Student_DataSet";
            this.student_DataSet.EnforceConstraints = false;
            this.student_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sLCBindingSource
            // 
            this.sLCBindingSource.DataMember = "SLC";
            this.sLCBindingSource.DataSource = this.student_DataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SLC_CERTIFICATEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.ReportsNew.SLC_Certificate.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(745, 504);
            this.reportViewer1.TabIndex = 5;
            // 
            // sLCTableAdapter
            // 
            this.sLCTableAdapter.ClearBeforeFill = true;
            // 
            // sLCCERTIFICATEBindingSource
            // 
            this.sLCCERTIFICATEBindingSource.DataMember = "SLC_CERTIFICATE";
            this.sLCCERTIFICATEBindingSource.DataSource = this.student_DataSet;
            // 
            // sLC_CERTIFICATETableAdapter
            // 
            this.sLC_CERTIFICATETableAdapter.ClearBeforeFill = true;
            // 
            // SLC_Certificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 504);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SLC_Certificate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SLC/STRUCK OFF/ SHIFT CHANGE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrntClasswiseoutst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SLC_CERTIFICATEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sLCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sLCCERTIFICATEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Student_DataSet student_DataSet;
        private System.Windows.Forms.BindingSource sLCBindingSource;
        private Student_DataSetTableAdapters.SLCTableAdapter sLCTableAdapter;
        private System.Windows.Forms.BindingSource SLC_CERTIFICATEBindingSource;
        private System.Windows.Forms.BindingSource sLCCERTIFICATEBindingSource;
        private Student_DataSetTableAdapters.SLC_CERTIFICATETableAdapter sLC_CERTIFICATETableAdapter;
    }
}