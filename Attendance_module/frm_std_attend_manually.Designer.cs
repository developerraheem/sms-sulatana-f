namespace School.Attendance_module
{
    partial class frm_std_attend_manually
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_std_attend_manually));
            this.aTTNDTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.attendance_ds = new School.Attendance_ds();
            this.aTTND_TYPETableAdapter = new School.Attendance_dsTableAdapters.ATTND_TYPETableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADMISSION_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLL_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtype = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SSC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.cmbshift = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbsection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbclassincharge = new System.Windows.Forms.ComboBox();
            this.txtfeemonth = new System.Windows.Forms.DateTimePicker();
            this.btnshow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RDOSSC = new System.Windows.Forms.RadioButton();
            this.rdohssc = new System.Windows.Forms.RadioButton();
            this.rdograd = new System.Windows.Forms.RadioButton();
            this.btnprint = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.aTTNDTYPEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendance_ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aTTNDTYPEBindingSource
            // 
            this.aTTNDTYPEBindingSource.DataMember = "ATTND_TYPE";
            this.aTTNDTYPEBindingSource.DataSource = this.attendance_ds;
            // 
            // attendance_ds
            // 
            this.attendance_ds.DataSetName = "Attendance_ds";
            this.attendance_ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aTTND_TYPETableAdapter
            // 
            this.aTTND_TYPETableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ADMISSION_NO,
            this.ROLL_NO,
            this.NAME,
            this.FNAME,
            this.clmtype,
            this.SSC});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(1372, 514);
            this.dataGridView1.TabIndex = 4;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 60;
            // 
            // ADMISSION_NO
            // 
            this.ADMISSION_NO.HeaderText = "Adm No";
            this.ADMISSION_NO.Name = "ADMISSION_NO";
            this.ADMISSION_NO.ReadOnly = true;
            this.ADMISSION_NO.Width = 70;
            // 
            // ROLL_NO
            // 
            this.ROLL_NO.HeaderText = "Roll No";
            this.ROLL_NO.Name = "ROLL_NO";
            this.ROLL_NO.ReadOnly = true;
            this.ROLL_NO.Width = 80;
            // 
            // NAME
            // 
            this.NAME.HeaderText = "Student Name";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Width = 200;
            // 
            // FNAME
            // 
            this.FNAME.HeaderText = "Father Name";
            this.FNAME.Name = "FNAME";
            this.FNAME.ReadOnly = true;
            this.FNAME.Width = 200;
            // 
            // clmtype
            // 
            this.clmtype.DataSource = this.aTTNDTYPEBindingSource;
            dataGridViewCellStyle2.NullValue = "Present";
            this.clmtype.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmtype.DisplayMember = "description";
            this.clmtype.HeaderText = "Attendance";
            this.clmtype.Name = "clmtype";
            this.clmtype.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmtype.ValueMember = "ID";
            // 
            // SSC
            // 
            this.SSC.DataPropertyName = "pecent";
            this.SSC.HeaderText = "Percnet. %";
            this.SSC.Name = "SSC";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panel4.Controls.Add(this.pictureBox10);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1372, 60);
            this.panel4.TabIndex = 70;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(60, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(280, 32);
            this.label11.TabIndex = 0;
            this.label11.Text = "Daily Student Attendance";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1040, 14);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(252, 24);
            this.comboBox1.TabIndex = 54;
            this.comboBox1.Visible = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(18, 14);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(31, 31);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 2;
            this.pictureBox10.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.btndelete);
            this.panel3.Controls.Add(this.btnprint);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.txtdate);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnshow);
            this.panel3.Controls.Add(this.txtfeemonth);
            this.panel3.Controls.Add(this.cmbclassincharge);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbsection);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.cmbshift);
            this.panel3.Controls.Add(this.cmbclass);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1372, 163);
            this.panel3.TabIndex = 71;
            // 
            // cmbclass
            // 
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Location = new System.Drawing.Point(152, 8);
            this.cmbclass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(201, 24);
            this.cmbclass.TabIndex = 76;
            // 
            // cmbshift
            // 
            this.cmbshift.FormattingEnabled = true;
            this.cmbshift.Location = new System.Drawing.Point(152, 60);
            this.cmbshift.Margin = new System.Windows.Forms.Padding(4);
            this.cmbshift.Name = "cmbshift";
            this.cmbshift.Size = new System.Drawing.Size(201, 24);
            this.cmbshift.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 116);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 75;
            this.label6.Text = "Select Section";
            // 
            // cmbsection
            // 
            this.cmbsection.FormattingEnabled = true;
            this.cmbsection.Location = new System.Drawing.Point(152, 109);
            this.cmbsection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsection.Name = "cmbsection";
            this.cmbsection.Size = new System.Drawing.Size(201, 24);
            this.cmbsection.TabIndex = 78;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 74;
            this.label5.Text = "Select Shift";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(743, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 79;
            this.label7.Text = "Class Incharge";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 73;
            this.label4.Text = "Select Class";
            // 
            // cmbclassincharge
            // 
            this.cmbclassincharge.FormattingEnabled = true;
            this.cmbclassincharge.Location = new System.Drawing.Point(850, 8);
            this.cmbclassincharge.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclassincharge.Name = "cmbclassincharge";
            this.cmbclassincharge.Size = new System.Drawing.Size(201, 24);
            this.cmbclassincharge.TabIndex = 80;
            // 
            // txtfeemonth
            // 
            this.txtfeemonth.CustomFormat = "MM yyyy";
            this.txtfeemonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtfeemonth.Location = new System.Drawing.Point(534, 60);
            this.txtfeemonth.Margin = new System.Windows.Forms.Padding(4);
            this.txtfeemonth.Name = "txtfeemonth";
            this.txtfeemonth.Size = new System.Drawing.Size(149, 22);
            this.txtfeemonth.TabIndex = 72;
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(634, 115);
            this.btnshow.Margin = new System.Windows.Forms.Padding(4);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(121, 37);
            this.btnshow.TabIndex = 81;
            this.btnshow.Text = "Show Record";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "Select Month";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(763, 115);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 37);
            this.button1.TabIndex = 82;
            this.button1.Text = "Update Attendance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 70;
            this.label2.Text = "Attendance Date";
            // 
            // txtdate
            // 
            this.txtdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdate.Location = new System.Drawing.Point(534, 8);
            this.txtdate.Margin = new System.Windows.Forms.Padding(4);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(149, 22);
            this.txtdate.TabIndex = 69;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdograd);
            this.groupBox2.Controls.Add(this.rdohssc);
            this.groupBox2.Controls.Add(this.RDOSSC);
            this.groupBox2.Location = new System.Drawing.Point(722, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 54);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Percentage %";
            // 
            // RDOSSC
            // 
            this.RDOSSC.AutoSize = true;
            this.RDOSSC.Checked = true;
            this.RDOSSC.Location = new System.Drawing.Point(26, 25);
            this.RDOSSC.Name = "RDOSSC";
            this.RDOSSC.Size = new System.Drawing.Size(72, 21);
            this.RDOSSC.TabIndex = 0;
            this.RDOSSC.TabStop = true;
            this.RDOSSC.Text = "SCC %";
            this.RDOSSC.UseVisualStyleBackColor = true;
            // 
            // rdohssc
            // 
            this.rdohssc.AutoSize = true;
            this.rdohssc.Location = new System.Drawing.Point(137, 25);
            this.rdohssc.Name = "rdohssc";
            this.rdohssc.Size = new System.Drawing.Size(82, 21);
            this.rdohssc.TabIndex = 1;
            this.rdohssc.Text = "HSSC %";
            this.rdohssc.UseVisualStyleBackColor = true;
            // 
            // rdograd
            // 
            this.rdograd.AutoSize = true;
            this.rdograd.Location = new System.Drawing.Point(235, 21);
            this.rdograd.Name = "rdograd";
            this.rdograd.Size = new System.Drawing.Size(120, 21);
            this.rdograd.TabIndex = 2;
            this.rdograd.Text = "Graduation  %";
            this.rdograd.UseVisualStyleBackColor = true;
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(1048, 115);
            this.btnprint.Margin = new System.Windows.Forms.Padding(4);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(121, 37);
            this.btnprint.TabIndex = 83;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btndelete
            // 
            this.btndelete.Enabled = false;
            this.btndelete.Location = new System.Drawing.Point(918, 116);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(122, 37);
            this.btndelete.TabIndex = 85;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1372, 514);
            this.panel1.TabIndex = 73;
            // 
            // frm_std_attend_manually
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 730);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_std_attend_manually";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Attendance Entry Form Manually";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_std_attend_manually_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aTTNDTYPEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendance_ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Attendance_ds attendance_ds;
        private System.Windows.Forms.BindingSource aTTNDTYPEBindingSource;
        private Attendance_dsTableAdapters.ATTND_TYPETableAdapter aTTND_TYPETableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADMISSION_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLL_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSC;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdograd;
        private System.Windows.Forms.RadioButton rdohssc;
        private System.Windows.Forms.RadioButton RDOSSC;
        private System.Windows.Forms.DateTimePicker txtdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.DateTimePicker txtfeemonth;
        private System.Windows.Forms.ComboBox cmbclassincharge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbsection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbshift;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.Panel panel1;
    }
}