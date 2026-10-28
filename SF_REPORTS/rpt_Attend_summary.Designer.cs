namespace School.SF_REPORTS
{
    partial class rpt_Attend_summary
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
            this.dAILYATTENDSUMMARYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.attendance_ds = new School.Attendance_ds();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.dAILY_ATTEND_SUMMARYTableAdapter = new School.Attendance_dsTableAdapters.DAILY_ATTEND_SUMMARYTableAdapter();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.txtfromdate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.txtdateto = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.DAILY_ATTEND_SUMMARYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dAILYATTENDSUMMARYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendance_ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DAILY_ATTEND_SUMMARYBindingSource)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // dAILYATTENDSUMMARYBindingSource
            // 
            this.dAILYATTENDSUMMARYBindingSource.DataMember = "DAILY_ATTEND_SUMMARY";
            this.dAILYATTENDSUMMARYBindingSource.DataSource = this.attendance_ds;
            // 
            // attendance_ds
            // 
            this.attendance_ds.DataSetName = "Attendance_ds";
            this.attendance_ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DAILY_ATTEND_SUMMARYBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.SF_REPORTS.rpt_attend_summary_n.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 65);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1141, 669);
            this.reportViewer1.TabIndex = 8;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(1141, 25);
            this.fillByToolStrip.TabIndex = 9;
            this.fillByToolStrip.Text = "fillByToolStrip";
            this.fillByToolStrip.Visible = false;
            this.fillByToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fillByToolStrip_ItemClicked);
            // 
            // dAILY_ATTEND_SUMMARYTableAdapter
            // 
            this.dAILY_ATTEND_SUMMARYTableAdapter.ClearBeforeFill = true;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblFromDate);
            this.panelHeader.Controls.Add(this.txtfromdate);
            this.panelHeader.Controls.Add(this.lblToDate);
            this.panelHeader.Controls.Add(this.txtdateto);
            this.panelHeader.Controls.Add(this.button1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1141, 65);
            this.panelHeader.TabIndex = 70;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Daily Attendance Summary";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.White;
            this.lblFromDate.Location = new System.Drawing.Point(390, 20);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(53, 21);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "From:";
            // 
            // txtfromdate
            // 
            this.txtfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfromdate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfromdate.Location = new System.Drawing.Point(445, 17);
            this.txtfromdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtfromdate.Name = "txtfromdate";
            this.txtfromdate.Size = new System.Drawing.Size(130, 29);
            this.txtfromdate.TabIndex = 67;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.White;
            this.lblToDate.Location = new System.Drawing.Point(585, 20);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(31, 21);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "To:";
            // 
            // txtdateto
            // 
            this.txtdateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdateto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdateto.Location = new System.Drawing.Point(620, 17);
            this.txtdateto.Margin = new System.Windows.Forms.Padding(4);
            this.txtdateto.Name = "txtdateto";
            this.txtdateto.Size = new System.Drawing.Size(130, 29);
            this.txtdateto.TabIndex = 68;
            this.txtdateto.ValueChanged += new System.EventHandler(this.txtdateto_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.button1.Location = new System.Drawing.Point(765, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 32);
            this.button1.TabIndex = 69;
            this.button1.Text = "Show Record";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DAILY_ATTEND_SUMMARYBindingSource
            // 
            this.DAILY_ATTEND_SUMMARYBindingSource.DataMember = "DAILY_ATTEND_SUMMARY";
            this.DAILY_ATTEND_SUMMARYBindingSource.DataSource = this.attendance_ds;
            // 
            // rpt_Attend_summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 734);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.fillByToolStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "rpt_Attend_summary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Attendance Summary Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RPT_RESULTS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dAILYATTENDSUMMARYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendance_ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DAILY_ATTEND_SUMMARYBindingSource)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dAILYATTENDSUMMARYBindingSource;
        private Attendance_ds attendance_ds;
        private Attendance_dsTableAdapters.DAILY_ATTEND_SUMMARYTableAdapter dAILY_ATTEND_SUMMARYTableAdapter;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker txtfromdate;
        private System.Windows.Forms.DateTimePicker txtdateto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource DAILY_ATTEND_SUMMARYBindingSource;
    }
}