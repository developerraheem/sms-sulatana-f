namespace School.Attendance_module
{
    partial class award_list
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
            this.awardListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new School.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.award_ListTableAdapter = new School.DataSet1TableAdapters.Award_ListTableAdapter();
            this.RESULTS_MULTIPLEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Award_ListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.awardListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RESULTS_MULTIPLEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Award_ListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // awardListBindingSource
            // 
            this.awardListBindingSource.DataMember = "Award_List";
            this.awardListBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Award_ListBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Attendance_module.award_list.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1275, 816);
            this.reportViewer1.TabIndex = 8;
            // 
            // award_ListTableAdapter
            // 
            this.award_ListTableAdapter.ClearBeforeFill = true;
            // 
            // RESULTS_MULTIPLEBindingSource
            // 
            this.RESULTS_MULTIPLEBindingSource.DataMember = "RESULTS_MULTIPLE";
            this.RESULTS_MULTIPLEBindingSource.DataSource = this.dataSet1;
            // 
            // Award_ListBindingSource
            // 
            this.Award_ListBindingSource.DataMember = "Award_List";
            this.Award_ListBindingSource.DataSource = this.dataSet1;
            // 
            // award_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 816);
            this.Controls.Add(this.reportViewer1);
            this.Name = "award_list";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Award List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.award_list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.awardListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RESULTS_MULTIPLEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Award_ListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource awardListBindingSource;
        private DataSet1 dataSet1;
        private DataSet1TableAdapters.Award_ListTableAdapter award_ListTableAdapter;
        private System.Windows.Forms.BindingSource RESULTS_MULTIPLEBindingSource;
        private System.Windows.Forms.BindingSource Award_ListBindingSource;
    }
}