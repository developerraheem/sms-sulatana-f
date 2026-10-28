namespace School._forms
{
    partial class frm_manage_students
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_manage_students));
            this.com_Sclass = new System.Windows.Forms.ComboBox();
            this.rdo_Class = new System.Windows.Forms.RadioButton();
            this.rdobyadmission = new System.Windows.Forms.RadioButton();
            this.txtsadmissionno = new System.Windows.Forms.TextBox();
            this.cmbshift = new System.Windows.Forms.ComboBox();
            this.cmbsection = new System.Windows.Forms.ComboBox();
            this.rdobyname = new System.Windows.Forms.RadioButton();
            this.txtbyname = new System.Windows.Forms.TextBox();
            this.lstv_Student = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPhoto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbselection = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rdoinactive = new System.Windows.Forms.RadioButton();
            this.rdopromotion = new System.Windows.Forms.RadioButton();
            this.cmbpromot = new System.Windows.Forms.ComboBox();
            this.rdo_All = new System.Windows.Forms.RadioButton();
            this.RDOSCL = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSearchCard = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelSearchCard.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // com_Sclass
            // 
            this.com_Sclass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_Sclass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.com_Sclass.FormattingEnabled = true;
            this.com_Sclass.Location = new System.Drawing.Point(115, 14);
            this.com_Sclass.Margin = new System.Windows.Forms.Padding(4);
            this.com_Sclass.Name = "com_Sclass";
            this.com_Sclass.Size = new System.Drawing.Size(130, 29);
            this.com_Sclass.TabIndex = 65;
            this.com_Sclass.SelectedIndexChanged += new System.EventHandler(this.com_Sclass_SelectedIndexChanged);
            this.com_Sclass.Click += new System.EventHandler(this.com_Sclass_Click);
            // 
            // rdo_Class
            // 
            this.rdo_Class.AutoSize = true;
            this.rdo_Class.Checked = true;
            this.rdo_Class.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdo_Class.Location = new System.Drawing.Point(15, 16);
            this.rdo_Class.Margin = new System.Windows.Forms.Padding(4);
            this.rdo_Class.Name = "rdo_Class";
            this.rdo_Class.Size = new System.Drawing.Size(88, 25);
            this.rdo_Class.TabIndex = 64;
            this.rdo_Class.TabStop = true;
            this.rdo_Class.Text = "By Class";
            this.rdo_Class.UseVisualStyleBackColor = true;
            this.rdo_Class.CheckedChanged += new System.EventHandler(this.rdo_Class_CheckedChanged);
            this.rdo_Class.Click += new System.EventHandler(this.rdo_Class_Click);
            // 
            // rdobyadmission
            // 
            this.rdobyadmission.AutoSize = true;
            this.rdobyadmission.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdobyadmission.Location = new System.Drawing.Point(480, 16);
            this.rdobyadmission.Margin = new System.Windows.Forms.Padding(4);
            this.rdobyadmission.Name = "rdobyadmission";
            this.rdobyadmission.Size = new System.Drawing.Size(150, 25);
            this.rdobyadmission.TabIndex = 66;
            this.rdobyadmission.Text = "By Admission No";
            this.rdobyadmission.UseVisualStyleBackColor = true;
            this.rdobyadmission.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.rdobyadmission.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // txtsadmissionno
            // 
            this.txtsadmissionno.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtsadmissionno.Location = new System.Drawing.Point(640, 14);
            this.txtsadmissionno.Margin = new System.Windows.Forms.Padding(4);
            this.txtsadmissionno.Name = "txtsadmissionno";
            this.txtsadmissionno.Size = new System.Drawing.Size(140, 29);
            this.txtsadmissionno.TabIndex = 67;
            this.txtsadmissionno.TextChanged += new System.EventHandler(this.txtsadmissionno_TextChanged);
            // 
            // cmbshift
            // 
            this.cmbshift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbshift.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbshift.FormattingEnabled = true;
            this.cmbshift.Location = new System.Drawing.Point(255, 14);
            this.cmbshift.Margin = new System.Windows.Forms.Padding(4);
            this.cmbshift.Name = "cmbshift";
            this.cmbshift.Size = new System.Drawing.Size(100, 29);
            this.cmbshift.TabIndex = 68;
            this.cmbshift.SelectedIndexChanged += new System.EventHandler(this.cmbshift_SelectedIndexChanged);
            // 
            // cmbsection
            // 
            this.cmbsection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsection.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsection.FormattingEnabled = true;
            this.cmbsection.Location = new System.Drawing.Point(365, 14);
            this.cmbsection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsection.Name = "cmbsection";
            this.cmbsection.Size = new System.Drawing.Size(80, 29);
            this.cmbsection.TabIndex = 69;
            this.cmbsection.SelectedIndexChanged += new System.EventHandler(this.cmbsection_SelectedIndexChanged);
            // 
            // rdobyname
            // 
            this.rdobyname.AutoSize = true;
            this.rdobyname.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdobyname.Location = new System.Drawing.Point(15, 52);
            this.rdobyname.Margin = new System.Windows.Forms.Padding(4);
            this.rdobyname.Name = "rdobyname";
            this.rdobyname.Size = new System.Drawing.Size(94, 25);
            this.rdobyname.TabIndex = 70;
            this.rdobyname.Text = "By Name";
            this.rdobyname.UseVisualStyleBackColor = true;
            this.rdobyname.CheckedChanged += new System.EventHandler(this.rdobyname_CheckedChanged);
            this.rdobyname.Click += new System.EventHandler(this.rdobyname_Click);
            // 
            // txtbyname
            // 
            this.txtbyname.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtbyname.Location = new System.Drawing.Point(115, 50);
            this.txtbyname.Margin = new System.Windows.Forms.Padding(4);
            this.txtbyname.Name = "txtbyname";
            this.txtbyname.Size = new System.Drawing.Size(240, 29);
            this.txtbyname.TabIndex = 71;
            this.txtbyname.TextChanged += new System.EventHandler(this.txtbyname_TextChanged);
            // 
            // lstv_Student
            // 
            this.lstv_Student.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeaderPhoto,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lstv_Student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstv_Student.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstv_Student.FullRowSelect = true;
            this.lstv_Student.GridLines = true;
            this.lstv_Student.Location = new System.Drawing.Point(0, 0);
            this.lstv_Student.Margin = new System.Windows.Forms.Padding(4);
            this.lstv_Student.Name = "lstv_Student";
            this.lstv_Student.Size = new System.Drawing.Size(1546, 513);
            this.lstv_Student.TabIndex = 66;
            this.lstv_Student.UseCompatibleStateImageBehavior = false;
            this.lstv_Student.View = System.Windows.Forms.View.Details;
            this.lstv_Student.SelectedIndexChanged += new System.EventHandler(this.lstv_Student_SelectedIndexChanged);
            this.lstv_Student.DoubleClick += new System.EventHandler(this.lstv_Student_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 80;
            // 
            // columnHeaderPhoto
            // 
            this.columnHeaderPhoto.Text = "Photo";
            this.columnHeaderPhoto.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Admission No";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Student Name";
            this.columnHeader5.Width = 160;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Class Name";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Contact No";
            this.columnHeader8.Width = 110;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Father Name";
            this.columnHeader9.Width = 160;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Age";
            this.columnHeader10.Width = 50;
            // 
            // cmbselection
            // 
            this.cmbselection.Enabled = false;
            this.cmbselection.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbselection.FormattingEnabled = true;
            this.cmbselection.Location = new System.Drawing.Point(910, 14);
            this.cmbselection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbselection.Name = "cmbselection";
            this.cmbselection.Size = new System.Drawing.Size(120, 29);
            this.cmbselection.TabIndex = 81;
            this.cmbselection.SelectedIndexChanged += new System.EventHandler(this.cmbselection_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(490, 170);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 34);
            this.button1.TabIndex = 69;
            this.button1.Text = "Modify / Edit Student Record";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rdoinactive
            // 
            this.rdoinactive.AutoSize = true;
            this.rdoinactive.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdoinactive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.rdoinactive.Location = new System.Drawing.Point(810, 16);
            this.rdoinactive.Margin = new System.Windows.Forms.Padding(4);
            this.rdoinactive.Name = "rdoinactive";
            this.rdoinactive.Size = new System.Drawing.Size(92, 25);
            this.rdoinactive.TabIndex = 82;
            this.rdoinactive.Text = "In-Active";
            this.rdoinactive.UseVisualStyleBackColor = true;
            this.rdoinactive.CheckedChanged += new System.EventHandler(this.rdoinactive_CheckedChanged_1);
            this.rdoinactive.Click += new System.EventHandler(this.rdoinactive_Click);
            // 
            // rdopromotion
            // 
            this.rdopromotion.AutoSize = true;
            this.rdopromotion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdopromotion.Location = new System.Drawing.Point(520, 52);
            this.rdopromotion.Margin = new System.Windows.Forms.Padding(4);
            this.rdopromotion.Name = "rdopromotion";
            this.rdopromotion.Size = new System.Drawing.Size(141, 25);
            this.rdopromotion.TabIndex = 84;
            this.rdopromotion.Text = "Promotion Type";
            this.rdopromotion.UseVisualStyleBackColor = true;
            this.rdopromotion.CheckedChanged += new System.EventHandler(this.rdopromotion_CheckedChanged_1);
            this.rdopromotion.Click += new System.EventHandler(this.rdopromotion_Click);
            // 
            // cmbpromot
            // 
            this.cmbpromot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbpromot.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbpromot.FormattingEnabled = true;
            this.cmbpromot.Location = new System.Drawing.Point(660, 50);
            this.cmbpromot.Margin = new System.Windows.Forms.Padding(4);
            this.cmbpromot.Name = "cmbpromot";
            this.cmbpromot.Size = new System.Drawing.Size(120, 29);
            this.cmbpromot.TabIndex = 83;
            this.cmbpromot.SelectedIndexChanged += new System.EventHandler(this.cmbpromot_SelectedIndexChanged_1);
            // 
            // rdo_All
            // 
            this.rdo_All.AutoSize = true;
            this.rdo_All.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdo_All.Location = new System.Drawing.Point(440, 52);
            this.rdo_All.Margin = new System.Windows.Forms.Padding(4);
            this.rdo_All.Name = "rdo_All";
            this.rdo_All.Size = new System.Drawing.Size(87, 25);
            this.rdo_All.TabIndex = 79;
            this.rdo_All.Text = "View All";
            this.rdo_All.UseVisualStyleBackColor = true;
            this.rdo_All.CheckedChanged += new System.EventHandler(this.rdo_All_CheckedChanged_1);
            this.rdo_All.Click += new System.EventHandler(this.rdo_All_Click_1);
            // 
            // RDOSCL
            // 
            this.RDOSCL.AutoSize = true;
            this.RDOSCL.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.RDOSCL.ForeColor = System.Drawing.Color.Maroon;
            this.RDOSCL.Location = new System.Drawing.Point(380, 52);
            this.RDOSCL.Margin = new System.Windows.Forms.Padding(4);
            this.RDOSCL.Name = "RDOSCL";
            this.RDOSCL.Size = new System.Drawing.Size(57, 25);
            this.RDOSCL.TabIndex = 80;
            this.RDOSCL.Text = "SLC";
            this.RDOSCL.UseVisualStyleBackColor = true;
            this.RDOSCL.CheckedChanged += new System.EventHandler(this.RDOSCL_CheckedChanged_1);
            this.RDOSCL.Click += new System.EventHandler(this.RDOSCL_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(320, 170);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 34);
            this.button3.TabIndex = 76;
            this.button3.Text = "Activate Student";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(180, 170);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 34);
            this.button2.TabIndex = 73;
            this.button2.Text = "Print SLC";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnadd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnadd.Location = new System.Drawing.Point(20, 170);
            this.btnadd.Margin = new System.Windows.Forms.Padding(4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(150, 34);
            this.btnadd.TabIndex = 68;
            this.btnadd.Text = "Add Student";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1100, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 23);
            this.label1.TabIndex = 77;
            this.label1.Text = "Total Records:";
            // 
            // lbltotal
            // 
            this.lbltotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lbltotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbltotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.lbltotal.Location = new System.Drawing.Point(1230, 18);
            this.lbltotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(45, 24);
            this.lbltotal.TabIndex = 78;
            this.lbltotal.Text = "0";
            this.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lbltotal);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.btnadd);
            this.panel4.Controls.Add(this.panelSearchCard);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1546, 222);
            this.panel4.TabIndex = 78;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.label2.Location = new System.Drawing.Point(65, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "View / Search Students";
            // 
            // panelSearchCard
            // 
            this.panelSearchCard.BackColor = System.Drawing.Color.White;
            this.panelSearchCard.Controls.Add(this.rdo_Class);
            this.panelSearchCard.Controls.Add(this.com_Sclass);
            this.panelSearchCard.Controls.Add(this.cmbshift);
            this.panelSearchCard.Controls.Add(this.cmbsection);
            this.panelSearchCard.Controls.Add(this.rdobyadmission);
            this.panelSearchCard.Controls.Add(this.txtsadmissionno);
            this.panelSearchCard.Controls.Add(this.rdoinactive);
            this.panelSearchCard.Controls.Add(this.cmbselection);
            this.panelSearchCard.Controls.Add(this.rdobyname);
            this.panelSearchCard.Controls.Add(this.txtbyname);
            this.panelSearchCard.Controls.Add(this.RDOSCL);
            this.panelSearchCard.Controls.Add(this.rdo_All);
            this.panelSearchCard.Controls.Add(this.rdopromotion);
            this.panelSearchCard.Controls.Add(this.cmbpromot);
            this.panelSearchCard.Location = new System.Drawing.Point(20, 58);
            this.panelSearchCard.Name = "panelSearchCard";
            this.panelSearchCard.Size = new System.Drawing.Size(1250, 100);
            this.panelSearchCard.TabIndex = 85;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstv_Student);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1546, 513);
            this.panel1.TabIndex = 79;
            // 
            // frm_manage_students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1546, 735);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_manage_students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Students";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_manage_students_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelSearchCard.ResumeLayout(false);
            this.panelSearchCard.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox com_Sclass;
        private System.Windows.Forms.RadioButton rdo_Class;
        private System.Windows.Forms.RadioButton rdobyadmission;
        private System.Windows.Forms.TextBox txtsadmissionno;
        private System.Windows.Forms.ComboBox cmbshift;
        private System.Windows.Forms.ComboBox cmbsection;
        private System.Windows.Forms.RadioButton rdobyname;
        private System.Windows.Forms.TextBox txtbyname;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeaderPhoto;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ListView lstv_Student;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbselection;
        private System.Windows.Forms.RadioButton rdoinactive;
        private System.Windows.Forms.RadioButton rdopromotion;
        private System.Windows.Forms.ComboBox cmbpromot;
        private System.Windows.Forms.RadioButton rdo_All;
        private System.Windows.Forms.RadioButton RDOSCL;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelSearchCard;
    }
}