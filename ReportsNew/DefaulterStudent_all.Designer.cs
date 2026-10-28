namespace School.ReportsNew
{
    partial class DefaulterStudent_all
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dEFAULTERDETAILBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report_DataSet_new = new School.Report_DataSet_new();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dEFAULTER_DETAILTableAdapter = new School.Report_DataSet_newTableAdapters.DEFAULTER_DETAILTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dpAe = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dEFAULTERDETAILBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).BeginInit();
            this.SuspendLayout();
            // 
            // dEFAULTERDETAILBindingSource
            // 
            this.dEFAULTERDETAILBindingSource.DataMember = "DEFAULTER_DETAIL";
            this.dEFAULTERDETAILBindingSource.DataSource = this.report_DataSet_new;
            // 
            // report_DataSet_new
            // 
            this.report_DataSet_new.DataSetName = "Report_DataSet_new";
            this.report_DataSet_new.EnforceConstraints = false;
            this.report_DataSet_new.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.dEFAULTERDETAILBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.ReportsNew.DefaulterStudents_all.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 40);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(927, 690);
            this.reportViewer1.TabIndex = 7;
            // 
            // dEFAULTER_DETAILTableAdapter
            // 
            this.dEFAULTER_DETAILTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Select Fee Month";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dpAe
            // 
            this.dpAe.CustomFormat = "MM yyyy";
            this.dpAe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpAe.Location = new System.Drawing.Point(105, 12);
            this.dpAe.Name = "dpAe";
            this.dpAe.Size = new System.Drawing.Size(99, 20);
            this.dpAe.TabIndex = 19;
            // 
            // DefaulterStudent_all
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 721);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dpAe);
            this.Controls.Add(this.reportViewer1);
            this.Name = "DefaulterStudent_all";
            this.Text = "Defaulter Student List Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BankwisePosted_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dEFAULTERDETAILBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report_DataSet_new)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dEFAULTERDETAILBindingSource;
        private Report_DataSet_new report_DataSet_new;
        private Report_DataSet_newTableAdapters.DEFAULTER_DETAILTableAdapter dEFAULTER_DETAILTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dpAe;
    }
}