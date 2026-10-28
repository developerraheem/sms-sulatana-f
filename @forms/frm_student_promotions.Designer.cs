namespace School._forms
{
    partial class frm_student_promotions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_student_promotions));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnfinditems_advance = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbsessionfrom = new System.Windows.Forms.ComboBox();
            this.cmbsection = new System.Windows.Forms.ComboBox();
            this.cmbshift = new System.Windows.Forms.ComboBox();
            this.cmbclassfrom = new System.Windows.Forms.ComboBox();
            this.btntransfer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLL_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADMISSION_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmtype = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.studentpromotionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student_DataSet = new School.Student_DataSet();
            this.section = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindsectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dashboard = new School.Dashboard();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbsessionto = new System.Windows.Forms.ComboBox();
            this.cmbsectionto = new System.Windows.Forms.ComboBox();
            this.cmbshiftto = new System.Windows.Forms.ComboBox();
            this.cmbclassto = new System.Windows.Forms.ComboBox();
            this.student_promotionsTableAdapter = new School.Student_DataSetTableAdapters.student_promotionsTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sectionsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sectionsTableAdapter = new School.DashboardTableAdapters.SectionsTableAdapter();
            this.bind_sectionsTableAdapter = new School.DashboardTableAdapters.bind_sectionsTableAdapter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentpromotionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindsectionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnfinditems_advance
            // 
            this.btnfinditems_advance.BackColor = System.Drawing.Color.FromArgb(8, 120, 61);
            this.btnfinditems_advance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfinditems_advance.FlatAppearance.BorderSize = 0;
            this.btnfinditems_advance.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnfinditems_advance.ForeColor = System.Drawing.Color.White;
            this.btnfinditems_advance.Location = new System.Drawing.Point(920, 42);
            this.btnfinditems_advance.Name = "btnfinditems_advance";
            this.btnfinditems_advance.Size = new System.Drawing.Size(110, 28);
            this.btnfinditems_advance.TabIndex = 311;
            this.btnfinditems_advance.Text = "Show";
            this.btnfinditems_advance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnfinditems_advance.UseVisualStyleBackColor = false;
            this.btnfinditems_advance.Click += new System.EventHandler(this.btnfinditems_advance_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label8.Location = new System.Drawing.Point(680, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 17);
            this.label8.TabIndex = 53;
            this.label8.Text = "SELECT SECTION";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label5.Location = new System.Drawing.Point(450, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 52;
            this.label5.Text = "SELECT SHIFT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label3.Location = new System.Drawing.Point(200, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 51;
            this.label3.Text = "SELECT CLASS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label2.Location = new System.Drawing.Point(20, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "SESSION FROM";
            // 
            // cmbsessionfrom
            // 
            this.cmbsessionfrom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsessionfrom.FormattingEnabled = true;
            this.cmbsessionfrom.Location = new System.Drawing.Point(20, 42);
            this.cmbsessionfrom.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsessionfrom.Name = "cmbsessionfrom";
            this.cmbsessionfrom.Size = new System.Drawing.Size(170, 28);
            this.cmbsessionfrom.TabIndex = 49;
            // 
            // cmbsection
            // 
            this.cmbsection.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsection.FormattingEnabled = true;
            this.cmbsection.Location = new System.Drawing.Point(680, 42);
            this.cmbsection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsection.Name = "cmbsection";
            this.cmbsection.Size = new System.Drawing.Size(220, 28);
            this.cmbsection.TabIndex = 45;
            // 
            // cmbshift
            // 
            this.cmbshift.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbshift.FormattingEnabled = true;
            this.cmbshift.Location = new System.Drawing.Point(450, 42);
            this.cmbshift.Margin = new System.Windows.Forms.Padding(4);
            this.cmbshift.Name = "cmbshift";
            this.cmbshift.Size = new System.Drawing.Size(215, 28);
            this.cmbshift.TabIndex = 43;
            // 
            // cmbclassfrom
            // 
            this.cmbclassfrom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbclassfrom.FormattingEnabled = true;
            this.cmbclassfrom.Location = new System.Drawing.Point(200, 42);
            this.cmbclassfrom.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclassfrom.Name = "cmbclassfrom";
            this.cmbclassfrom.Size = new System.Drawing.Size(240, 28);
            this.cmbclassfrom.TabIndex = 41;
            // 
            // btntransfer
            // 
            this.btntransfer.BackColor = System.Drawing.Color.FromArgb(8, 120, 61);
            this.btntransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntransfer.FlatAppearance.BorderSize = 0;
            this.btntransfer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btntransfer.ForeColor = System.Drawing.Color.White;
            this.btntransfer.Location = new System.Drawing.Point(920, 42);
            this.btntransfer.Margin = new System.Windows.Forms.Padding(4);
            this.btntransfer.Name = "btntransfer";
            this.btntransfer.Size = new System.Drawing.Size(110, 28);
            this.btntransfer.TabIndex = 47;
            this.btntransfer.Text = "Transfer";
            this.btntransfer.UseVisualStyleBackColor = false;
            this.btntransfer.Click += new System.EventHandler(this.btntransfer_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
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
            this.ROLL_NO,
            this.ADMISSION_NO,
            this.NAME,
            this.FNAME,
            this.clmtype,
            this.section});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(1493, 362);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 60;
            // 
            // ROLL_NO
            // 
            this.ROLL_NO.HeaderText = "ROLL NO";
            this.ROLL_NO.Name = "ROLL_NO";
            this.ROLL_NO.ReadOnly = true;
            // 
            // ADMISSION_NO
            // 
            this.ADMISSION_NO.HeaderText = "ADMISSION NO";
            this.ADMISSION_NO.Name = "ADMISSION_NO";
            this.ADMISSION_NO.ReadOnly = true;
            this.ADMISSION_NO.Width = 120;
            // 
            // NAME
            // 
            this.NAME.HeaderText = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Width = 200;
            // 
            // FNAME
            // 
            this.FNAME.HeaderText = "FATHER\'SNAME";
            this.FNAME.Name = "FNAME";
            this.FNAME.ReadOnly = true;
            this.FNAME.Width = 200;
            // 
            // clmtype
            // 
            this.clmtype.DataSource = this.studentpromotionsBindingSource;
            this.clmtype.DisplayMember = "PROMO_TYPE_NAME";
            this.clmtype.HeaderText = "Type";
            this.clmtype.Name = "clmtype";
            this.clmtype.ValueMember = "PROMO_TYPE_ID";
            // 
            // studentpromotionsBindingSource
            // 
            this.studentpromotionsBindingSource.DataMember = "student_promotions";
            this.studentpromotionsBindingSource.DataSource = this.student_DataSet;
            // 
            // student_DataSet
            // 
            this.student_DataSet.DataSetName = "Student_DataSet";
            this.student_DataSet.EnforceConstraints = false;
            this.student_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // section
            // 
            this.section.DataSource = this.bindsectionsBindingSource;
            this.section.DisplayMember = "SECTION_NAME";
            this.section.HeaderText = "Section";
            this.section.Name = "section";
            this.section.ValueMember = "SECTION_ID";
            // 
            // bindsectionsBindingSource
            // 
            this.bindsectionsBindingSource.DataMember = "bind_sections";
            this.bindsectionsBindingSource.DataSource = this.dashboard;
            // 
            // dashboard
            // 
            this.dashboard.DataSetName = "Dashboard";
            this.dashboard.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(8, 120, 61);
            this.label4.Location = new System.Drawing.Point(20, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 26);
            this.label4.TabIndex = 50;
            this.label4.Text = "From:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(8, 120, 61);
            this.label6.Location = new System.Drawing.Point(20, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 26);
            this.label6.TabIndex = 52;
            this.label6.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label1.Location = new System.Drawing.Point(680, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 57;
            this.label1.Text = "SELECT SECTION";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label7.Location = new System.Drawing.Point(450, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "SELECT SHIFT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label9.Location = new System.Drawing.Point(200, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 17);
            this.label9.TabIndex = 55;
            this.label9.Text = "SELECT CLASS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.label10.Location = new System.Drawing.Point(20, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 17);
            this.label10.TabIndex = 54;
            this.label10.Text = "SESSION TO";
            // 
            // cmbsessionto
            // 
            this.cmbsessionto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsessionto.FormattingEnabled = true;
            this.cmbsessionto.Location = new System.Drawing.Point(20, 65);
            this.cmbsessionto.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsessionto.Name = "cmbsessionto";
            this.cmbsessionto.Size = new System.Drawing.Size(170, 28);
            this.cmbsessionto.TabIndex = 49;
            // 
            // cmbsectionto
            // 
            this.cmbsectionto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsectionto.FormattingEnabled = true;
            this.cmbsectionto.Location = new System.Drawing.Point(680, 65);
            this.cmbsectionto.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsectionto.Name = "cmbsectionto";
            this.cmbsectionto.Size = new System.Drawing.Size(220, 28);
            this.cmbsectionto.TabIndex = 45;
            // 
            // cmbshiftto
            // 
            this.cmbshiftto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbshiftto.FormattingEnabled = true;
            this.cmbshiftto.Location = new System.Drawing.Point(450, 65);
            this.cmbshiftto.Margin = new System.Windows.Forms.Padding(4);
            this.cmbshiftto.Name = "cmbshiftto";
            this.cmbshiftto.Size = new System.Drawing.Size(215, 28);
            this.cmbshiftto.TabIndex = 43;
            // 
            // cmbclassto
            // 
            this.cmbclassto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbclassto.FormattingEnabled = true;
            this.cmbclassto.Location = new System.Drawing.Point(200, 65);
            this.cmbclassto.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclassto.Name = "cmbclassto";
            this.cmbclassto.Size = new System.Drawing.Size(240, 28);
            this.cmbclassto.TabIndex = 41;
            // 
            // student_promotionsTableAdapter
            // 
            this.student_promotionsTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(390, 14);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 24);
            this.comboBox1.TabIndex = 53;
            this.comboBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(570, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 54;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sectionsBindingSource1
            // 
            this.sectionsBindingSource1.DataMember = "Sections";
            this.sectionsBindingSource1.DataSource = this.dashboard;
            // 
            // sectionsBindingSource
            // 
            this.sectionsBindingSource.DataMember = "Sections";
            this.sectionsBindingSource.DataSource = this.dashboard;
            // 
            // sectionsTableAdapter
            // 
            this.sectionsTableAdapter.ClearBeforeFill = true;
            // 
            // bind_sectionsTableAdapter
            // 
            this.bind_sectionsTableAdapter.ClearBeforeFill = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.pictureBox10);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1493, 58);
            this.panel4.TabIndex = 67;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(12, 9);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(31, 27);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 2;
            this.pictureBox10.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(8, 120, 61);
            this.label12.Location = new System.Drawing.Point(55, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(281, 27);
            this.label12.TabIndex = 0;
            this.label12.Text = "Student Shifting / Promotions";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnfinditems_advance);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cmbclassfrom);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbshift);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cmbsection);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cmbsessionfrom);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1493, 88);
            this.panel3.TabIndex = 91;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(250, 252, 250);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btntransfer);
            this.panel1.Controls.Add(this.cmbclassto);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbshiftto);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbsectionto);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbsessionto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1493, 105);
            this.panel1.TabIndex = 92;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 251);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1493, 427);
            this.panel2.TabIndex = 93;
            // 
            // frm_student_promotions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 246);
            this.ClientSize = new System.Drawing.Size(1493, 678);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_student_promotions";
            this.Text = "Student Promotions / Shifting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_student_promotions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentpromotionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindsectionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbshift;
        private System.Windows.Forms.ComboBox cmbclassfrom;
        private System.Windows.Forms.ComboBox cmbsection;
        private System.Windows.Forms.Button btntransfer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbsessionfrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbsessionto;
        private System.Windows.Forms.ComboBox cmbsectionto;
        private System.Windows.Forms.ComboBox cmbshiftto;
        private System.Windows.Forms.ComboBox cmbclassto;
        private Student_DataSet student_DataSet;
        private System.Windows.Forms.BindingSource studentpromotionsBindingSource;
        private Student_DataSetTableAdapters.student_promotionsTableAdapter student_promotionsTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource sectionsBindingSource;
        private Dashboard dashboard;
        private DashboardTableAdapters.SectionsTableAdapter sectionsTableAdapter;
        private System.Windows.Forms.BindingSource sectionsBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLL_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADMISSION_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmtype;
        private System.Windows.Forms.DataGridViewComboBoxColumn section;
        private System.Windows.Forms.BindingSource bindsectionsBindingSource;
        private DashboardTableAdapters.bind_sectionsTableAdapter bind_sectionsTableAdapter;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnfinditems_advance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}