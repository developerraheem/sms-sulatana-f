namespace School._forms
{
    partial class SLC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SLC));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnfindstd = new System.Windows.Forms.Button();
            this.rdostudent = new System.Windows.Forms.RadioButton();
            this.rdotype = new System.Windows.Forms.RadioButton();
            this.txtstudentid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbshift = new System.Windows.Forms.ComboBox();
            this.com_cName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtdatefrom = new System.Windows.Forms.DateTimePicker();
            this.txtdateto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sLCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student_DataSet = new School.Student_DataSet();
            this.sLCTableAdapter = new School.Student_DataSetTableAdapters.SLCTableAdapter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sLCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sLCBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Fee_Summary_Reports.STUCKOFF_LEAVE1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-4, 82);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer1.Size = new System.Drawing.Size(1348, 422);
            this.reportViewer1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnfindstd);
            this.groupBox1.Controls.Add(this.rdostudent);
            this.groupBox1.Controls.Add(this.rdotype);
            this.groupBox1.Controls.Add(this.txtstudentid);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbshift);
            this.groupBox1.Controls.Add(this.com_cName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cmbtype);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1364, 76);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Parameters";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(697, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 76;
            this.button1.Text = "Print SLC";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnfindstd
            // 
            this.btnfindstd.Image = ((System.Drawing.Image)(resources.GetObject("btnfindstd.Image")));
            this.btnfindstd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfindstd.Location = new System.Drawing.Point(779, 39);
            this.btnfindstd.Name = "btnfindstd";
            this.btnfindstd.Size = new System.Drawing.Size(50, 24);
            this.btnfindstd.TabIndex = 75;
            this.btnfindstd.Text = "Find";
            this.btnfindstd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfindstd.UseVisualStyleBackColor = true;
            this.btnfindstd.Click += new System.EventHandler(this.btnfindstd_Click);
            // 
            // rdostudent
            // 
            this.rdostudent.AutoSize = true;
            this.rdostudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdostudent.Location = new System.Drawing.Point(260, 35);
            this.rdostudent.Name = "rdostudent";
            this.rdostudent.Size = new System.Drawing.Size(142, 19);
            this.rdostudent.TabIndex = 74;
            this.rdostudent.TabStop = true;
            this.rdostudent.Text = "Search By Student";
            this.rdostudent.UseVisualStyleBackColor = true;
            // 
            // rdotype
            // 
            this.rdotype.AutoSize = true;
            this.rdotype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdotype.Location = new System.Drawing.Point(13, 35);
            this.rdotype.Name = "rdotype";
            this.rdotype.Size = new System.Drawing.Size(123, 19);
            this.rdotype.TabIndex = 73;
            this.rdotype.TabStop = true;
            this.rdotype.Text = "Search By Type";
            this.rdotype.UseVisualStyleBackColor = true;
            // 
            // txtstudentid
            // 
            this.txtstudentid.Location = new System.Drawing.Point(721, 14);
            this.txtstudentid.Name = "txtstudentid";
            this.txtstudentid.Size = new System.Drawing.Size(108, 20);
            this.txtstudentid.TabIndex = 72;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(660, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "StudentID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(434, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 69;
            this.label8.Text = "Select Shift:";
            // 
            // cmbshift
            // 
            this.cmbshift.FormattingEnabled = true;
            this.cmbshift.Location = new System.Drawing.Point(516, 41);
            this.cmbshift.Name = "cmbshift";
            this.cmbshift.Size = new System.Drawing.Size(135, 21);
            this.cmbshift.TabIndex = 70;
            // 
            // com_cName
            // 
            this.com_cName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_cName.FormattingEnabled = true;
            this.com_cName.Location = new System.Drawing.Point(516, 13);
            this.com_cName.Name = "com_cName";
            this.com_cName.Size = new System.Drawing.Size(134, 21);
            this.com_cName.TabIndex = 68;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(389, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 67;
            this.label5.Text = "Select Class Name*";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1242, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 35);
            this.button2.TabIndex = 64;
            this.button2.Text = "Print Preview";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbtype
            // 
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.IntegralHeight = false;
            this.cmbtype.Items.AddRange(new object[] {
            "SLC",
            "Struck OFF",
            "Change Shift"});
            this.cmbtype.Location = new System.Drawing.Point(142, 35);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(112, 21);
            this.cmbtype.TabIndex = 45;
            this.cmbtype.Text = "SLC";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtdateto);
            this.groupBox2.Controls.Add(this.txtdatefrom);
            this.groupBox2.Location = new System.Drawing.Point(848, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 52);
            this.groupBox2.TabIndex = 77;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Criteria";
            // 
            // txtdatefrom
            // 
            this.txtdatefrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdatefrom.Location = new System.Drawing.Point(70, 21);
            this.txtdatefrom.Name = "txtdatefrom";
            this.txtdatefrom.Size = new System.Drawing.Size(104, 20);
            this.txtdatefrom.TabIndex = 0;
            // 
            // txtdateto
            // 
            this.txtdateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdateto.Location = new System.Drawing.Point(244, 21);
            this.txtdateto.Name = "txtdateto";
            this.txtdateto.Size = new System.Drawing.Size(104, 20);
            this.txtdateto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Start Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "End Date:";
            // 
            // sLCBindingSource
            // 
            this.sLCBindingSource.DataMember = "SLC";
            this.sLCBindingSource.DataSource = this.student_DataSet;
            // 
            // student_DataSet
            // 
            this.student_DataSet.DataSetName = "Student_DataSet";
            this.student_DataSet.EnforceConstraints = false;
            this.student_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sLCTableAdapter
            // 
            this.sLCTableAdapter.ClearBeforeFill = true;
            // 
            // SLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 524);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SLC/STRUCK OFF/ SHIFT CHANGE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrntClasswiseoutst_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sLCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Student_DataSet student_DataSet;
        private System.Windows.Forms.BindingSource sLCBindingSource;
        private Student_DataSetTableAdapters.SLCTableAdapter sLCTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox com_cName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbshift;
        private System.Windows.Forms.TextBox txtstudentid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdotype;
        private System.Windows.Forms.RadioButton rdostudent;
        private System.Windows.Forms.Button btnfindstd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker txtdatefrom;
        private System.Windows.Forms.DateTimePicker txtdateto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}