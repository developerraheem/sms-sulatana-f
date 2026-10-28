namespace GL_SCHOOL.Reports
{
    partial class GENERAL_LEDGER
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
            this.dataSet1 = new GL_SCHOOL.DataSet1();
            this.gENERALLEDGERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gENERAL_LEDGERTableAdapter = new GL_SCHOOL.DataSet1TableAdapters.GENERAL_LEDGERTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gENERALLEDGERBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.gENERALLEDGERBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GL_SCHOOL.Reports.GENERAL_LEDGER.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(7, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1120, 663);
            this.reportViewer1.TabIndex = 2;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.EnforceConstraints = false;
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gENERALLEDGERBindingSource
            // 
            this.gENERALLEDGERBindingSource.DataMember = "GENERAL_LEDGER";
            this.gENERALLEDGERBindingSource.DataSource = this.dataSet1;
            // 
            // gENERAL_LEDGERTableAdapter
            // 
            this.gENERAL_LEDGERTableAdapter.ClearBeforeFill = true;
            // 
            // GENERAL_LEDGER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 588);
            this.Controls.Add(this.reportViewer1);
            this.Name = "GENERAL_LEDGER";
            this.Text = "GENERAL_LEDGER";
            this.Load += new System.EventHandler(this.GENERAL_LEDGER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gENERALLEDGERBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource gENERALLEDGERBindingSource;
        private DataSet1TableAdapters.GENERAL_LEDGERTableAdapter gENERAL_LEDGERTableAdapter;
    }
}