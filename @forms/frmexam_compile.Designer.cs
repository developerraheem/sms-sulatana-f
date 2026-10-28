namespace School._forms
{
    partial class frmexam_compile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmexam_compile));
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbexamtype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbstudents = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUB_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_MARKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBT_MARKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new Glass.GlassButton();
            this.btnprint = new Glass.GlassButton();
            this.cmbsection = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbselection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtadmno = new System.Windows.Forms.TextBox();
            this.glassButton1 = new Glass.GlassButton();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbclass
            // 
            this.cmbclass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Location = new System.Drawing.Point(172, 40);
            this.cmbclass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(148, 30);
            this.cmbclass.TabIndex = 43;
            this.cmbclass.SelectedIndexChanged += new System.EventHandler(this.cmbclass_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(172, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 17);
            this.label11.TabIndex = 42;
            this.label11.Text = "Select Class:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Khaki;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1146, 38);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 32);
            this.button2.TabIndex = 49;
            this.button2.Text = "Search..";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmbexamtype
            // 
            this.cmbexamtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbexamtype.FormattingEnabled = true;
            this.cmbexamtype.Location = new System.Drawing.Point(943, 40);
            this.cmbexamtype.Margin = new System.Windows.Forms.Padding(4);
            this.cmbexamtype.Name = "cmbexamtype";
            this.cmbexamtype.Size = new System.Drawing.Size(199, 30);
            this.cmbexamtype.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(943, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "Select Exam Type:";
            // 
            // cmbstudents
            // 
            this.cmbstudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbstudents.FormattingEnabled = true;
            this.cmbstudents.Location = new System.Drawing.Point(665, 40);
            this.cmbstudents.Margin = new System.Windows.Forms.Padding(4);
            this.cmbstudents.Name = "cmbstudents";
            this.cmbstudents.Size = new System.Drawing.Size(270, 30);
            this.cmbstudents.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(665, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 52;
            this.label2.Text = "Select Student:";
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
            this.sub_code,
            this.SUB_NAME,
            this.TOTAL_MARKS,
            this.OBT_MARKS,
            this.STATUS,
            this.Remarks});
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
            this.dataGridView1.Size = new System.Drawing.Size(1428, 676);
            this.dataGridView1.TabIndex = 55;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 60;
            // 
            // sub_code
            // 
            this.sub_code.HeaderText = "Subject Code";
            this.sub_code.Name = "sub_code";
            this.sub_code.ReadOnly = true;
            // 
            // SUB_NAME
            // 
            this.SUB_NAME.HeaderText = "Name of Subject";
            this.SUB_NAME.Name = "SUB_NAME";
            this.SUB_NAME.ReadOnly = true;
            this.SUB_NAME.Width = 200;
            // 
            // TOTAL_MARKS
            // 
            this.TOTAL_MARKS.HeaderText = "Max Marks";
            this.TOTAL_MARKS.Name = "TOTAL_MARKS";
            this.TOTAL_MARKS.ReadOnly = true;
            this.TOTAL_MARKS.Width = 120;
            // 
            // OBT_MARKS
            // 
            this.OBT_MARKS.HeaderText = "Marks Obtd.";
            this.OBT_MARKS.Name = "OBT_MARKS";
            // 
            // STATUS
            // 
            this.STATUS.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.STATUS.HeaderText = "Pass / Fail";
            this.STATUS.Items.AddRange(new object[] {
            "Pass",
            "Fail"});
            this.STATUS.Name = "STATUS";
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 220;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(798, 96);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(164, 38);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "Save Result";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnprint
            // 
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(970, 96);
            this.btnprint.Margin = new System.Windows.Forms.Padding(4);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(112, 38);
            this.btnprint.TabIndex = 57;
            this.btnprint.Text = "Print";
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // cmbsection
            // 
            this.cmbsection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbsection.FormattingEnabled = true;
            this.cmbsection.ItemHeight = 22;
            this.cmbsection.Location = new System.Drawing.Point(327, 40);
            this.cmbsection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsection.Name = "cmbsection";
            this.cmbsection.Size = new System.Drawing.Size(155, 30);
            this.cmbsection.TabIndex = 58;
            this.cmbsection.SelectedIndexChanged += new System.EventHandler(this.cmbsection_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(327, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 59;
            this.label4.Text = "Select Section";
            // 
            // cmbselection
            // 
            this.cmbselection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbselection.FormattingEnabled = true;
            this.cmbselection.Location = new System.Drawing.Point(40, 40);
            this.cmbselection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbselection.Name = "cmbselection";
            this.cmbselection.Size = new System.Drawing.Size(124, 30);
            this.cmbselection.TabIndex = 77;
            this.cmbselection.SelectedIndexChanged += new System.EventHandler(this.cmbselection_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 78;
            this.label5.Text = "Select Session:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(490, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 14);
            this.label6.TabIndex = 79;
            this.label6.Text = "Search By Admission No";
            // 
            // txtadmno
            // 
            this.txtadmno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtadmno.Location = new System.Drawing.Point(490, 42);
            this.txtadmno.Margin = new System.Windows.Forms.Padding(4);
            this.txtadmno.Name = "txtadmno";
            this.txtadmno.Size = new System.Drawing.Size(167, 28);
            this.txtadmno.TabIndex = 80;
            this.txtadmno.TextChanged += new System.EventHandler(this.txtadmno_TextChanged);
            // 
            // glassButton1
            // 
            this.glassButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.glassButton1.Location = new System.Drawing.Point(1090, 96);
            this.glassButton1.Margin = new System.Windows.Forms.Padding(4);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.Size = new System.Drawing.Size(145, 38);
            this.glassButton1.TabIndex = 81;
            this.glassButton1.Text = "Print Multiple";
            this.glassButton1.Click += new System.EventHandler(this.glassButton1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1171, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 41);
            this.button1.TabIndex = 82;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panel4.Controls.Add(this.pictureBox10);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1428, 60);
            this.panel4.TabIndex = 83;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(60, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(480, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Student wise Progress Report Compilation";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.glassButton1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbclass);
            this.panel1.Controls.Add(this.txtadmno);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbexamtype);
            this.panel1.Controls.Add(this.cmbselection);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbstudents);
            this.panel1.Controls.Add(this.cmbsection);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1428, 153);
            this.panel1.TabIndex = 84;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1428, 676);
            this.panel2.TabIndex = 85;
            // 
            // frmexam_compile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 882);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmexam_compile";
            this.Text = "Progress Report Compilation";
            this.Load += new System.EventHandler(this.frmexam_compile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbexamtype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbstudents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Glass.GlassButton btnSave;
        private Glass.GlassButton btnprint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUB_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_MARKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBT_MARKS;
        private System.Windows.Forms.DataGridViewComboBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.ComboBox cmbsection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbselection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtadmno;
        private Glass.GlassButton glassButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}