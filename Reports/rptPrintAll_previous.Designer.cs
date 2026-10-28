namespace School.Reports
{
    partial class rptPrintAll_previous
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.attendance_ds = new School.Attendance_ds();
            this.aTTENDSUBREPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aTTEND_SUB_REPORTTableAdapter = new School.Attendance_dsTableAdapters.ATTEND_SUB_REPORTTableAdapter();
            this.ATTEND_SUB_REPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.s_IDToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.s_IDToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.attendance_ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTTENDSUBREPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ATTEND_SUB_REPORTBindingSource)).BeginInit();
            this.fillByToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.ATTEND_SUB_REPORTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.SF_REPORTS.attend_sub_report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(542, 484);
            this.reportViewer1.TabIndex = 7;
            // 
            // attendance_ds
            // 
            this.attendance_ds.DataSetName = "Attendance_ds";
            this.attendance_ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aTTENDSUBREPORTBindingSource
            // 
            this.aTTENDSUBREPORTBindingSource.DataMember = "ATTEND_SUB_REPORT";
            this.aTTENDSUBREPORTBindingSource.DataSource = this.attendance_ds;
            // 
            // aTTEND_SUB_REPORTTableAdapter
            // 
            this.aTTEND_SUB_REPORTTableAdapter.ClearBeforeFill = true;
            // 
            // ATTEND_SUB_REPORTBindingSource
            // 
            this.ATTEND_SUB_REPORTBindingSource.DataMember = "ATTEND_SUB_REPORT";
            this.ATTEND_SUB_REPORTBindingSource.DataSource = this.attendance_ds;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.s_IDToolStripLabel,
            this.s_IDToolStripTextBox,
            this.fillByToolStripButton});
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(542, 25);
            this.fillByToolStrip.TabIndex = 8;
            this.fillByToolStrip.Text = "fillByToolStrip";
            // 
            // s_IDToolStripLabel
            // 
            this.s_IDToolStripLabel.Name = "s_IDToolStripLabel";
            this.s_IDToolStripLabel.Size = new System.Drawing.Size(32, 22);
            this.s_IDToolStripLabel.Text = "S_ID:";
            // 
            // s_IDToolStripTextBox
            // 
            this.s_IDToolStripTextBox.Name = "s_IDToolStripTextBox";
            this.s_IDToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(39, 19);
            this.fillByToolStripButton.Text = "FillBy";
            this.fillByToolStripButton.Click += new System.EventHandler(this.fillByToolStripButton_Click_1);
            // 
            // rptPrintAll_previous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 484);
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptPrintAll_previous";
            this.Text = "rptPrintAll_previous";
            this.Load += new System.EventHandler(this.rptPrintAll_previous_Load);
            ((System.ComponentModel.ISupportInitialize)(this.attendance_ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTTENDSUBREPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ATTEND_SUB_REPORTBindingSource)).EndInit();
            this.fillByToolStrip.ResumeLayout(false);
            this.fillByToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ATTEND_SUB_REPORTBindingSource;
        private Attendance_ds attendance_ds;
        private System.Windows.Forms.BindingSource aTTENDSUBREPORTBindingSource;
        private Attendance_dsTableAdapters.ATTEND_SUB_REPORTTableAdapter aTTEND_SUB_REPORTTableAdapter;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripLabel s_IDToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox s_IDToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
    }
}