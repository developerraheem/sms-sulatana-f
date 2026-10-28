namespace School.Fee_Summary_Reports
{
    partial class Summary_Defaulter
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
            this.sUMMARYDEFAULTERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Fee_Summary_Reports = new School.DataSet_Fee_Summary_Reports();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sUMMARY_DEFAULTERTableAdapter = new School.DataSet_Fee_Summary_ReportsTableAdapters.SUMMARY_DEFAULTERTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sUMMARYDEFAULTERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).BeginInit();
            this.SuspendLayout();
            // 
            // sUMMARYDEFAULTERBindingSource
            // 
            this.sUMMARYDEFAULTERBindingSource.DataMember = "SUMMARY_DEFAULTER";
            this.sUMMARYDEFAULTERBindingSource.DataSource = this.dataSet_Fee_Summary_Reports;
            // 
            // dataSet_Fee_Summary_Reports
            // 
            this.dataSet_Fee_Summary_Reports.DataSetName = "DataSet_Fee_Summary_Reports";
            this.dataSet_Fee_Summary_Reports.EnforceConstraints = false;
            this.dataSet_Fee_Summary_Reports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sUMMARYDEFAULTERBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Fee_Summary_Reports.Summary_Defaulter.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(970, 584);
            this.reportViewer1.TabIndex = 7;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // sUMMARY_DEFAULTERTableAdapter
            // 
            this.sUMMARY_DEFAULTERTableAdapter.ClearBeforeFill = true;
            // 
            // Summary_Defaulter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 584);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Summary_Defaulter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Defaulter Summary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Head_Class_wise_feereport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sUMMARYDEFAULTERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Fee_Summary_Reports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet_Fee_Summary_Reports fee_Summary_Reports;
        private DataSet_Fee_Summary_Reports.Head_Class_wise_FeereportDataTable head_Class_wise_FeereportTableAdapter;
        private System.Windows.Forms.BindingSource sUMMARYDEFAULTERBindingSource;
        private DataSet_Fee_Summary_Reports dataSet_Fee_Summary_Reports;
        private DataSet_Fee_Summary_ReportsTableAdapters.SUMMARY_DEFAULTERTableAdapter sUMMARY_DEFAULTERTableAdapter;
    }
}