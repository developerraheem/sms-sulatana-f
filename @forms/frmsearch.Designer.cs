namespace School._forms
{
    partial class frmsearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsearch));
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.lstv_Student = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtsadmissionno = new System.Windows.Forms.TextBox();
            this.rdobyadmission = new System.Windows.Forms.RadioButton();
            this.txtbyname = new System.Windows.Forms.TextBox();
            this.rdobyname = new System.Windows.Forms.RadioButton();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.White;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btn_Close.FlatAppearance.BorderSize = 1;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btn_Close.Location = new System.Drawing.Point(875, 18);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 32);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btn_Modify.FlatAppearance.BorderSize = 0;
            this.btn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modify.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn_Modify.ForeColor = System.Drawing.Color.White;
            this.btn_Modify.Location = new System.Drawing.Point(725, 18);
            this.btn_Modify.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(140, 32);
            this.btn_Modify.TabIndex = 4;
            this.btn_Modify.Text = "Search Student";
            this.btn_Modify.UseVisualStyleBackColor = false;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // lstv_Student
            // 
            this.lstv_Student.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstv_Student.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lstv_Student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstv_Student.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstv_Student.FullRowSelect = true;
            this.lstv_Student.GridLines = true;
            this.lstv_Student.Location = new System.Drawing.Point(0, 0);
            this.lstv_Student.Margin = new System.Windows.Forms.Padding(4);
            this.lstv_Student.Name = "lstv_Student";
            this.lstv_Student.OwnerDraw = true;
            this.lstv_Student.Size = new System.Drawing.Size(1620, 586);
            this.lstv_Student.TabIndex = 0;
            this.lstv_Student.UseCompatibleStateImageBehavior = false;
            this.lstv_Student.View = System.Windows.Forms.View.Details;
            this.lstv_Student.DoubleClick += new System.EventHandler(this.lstv_Student_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Admission No";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Student Name";
            this.columnHeader5.Width = 180;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Class Name";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Address";
            this.columnHeader7.Width = 220;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Contact No";
            this.columnHeader8.Width = 110;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Father Name";
            this.columnHeader9.Width = 180;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Age";
            this.columnHeader10.Width = 60;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "D.O.B";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Sex";
            this.columnHeader12.Width = 70;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Remarks";
            this.columnHeader13.Width = 200;
            // 
            // txtsadmissionno
            // 
            this.txtsadmissionno.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtsadmissionno.Location = new System.Drawing.Point(175, 20);
            this.txtsadmissionno.Margin = new System.Windows.Forms.Padding(4);
            this.txtsadmissionno.Name = "txtsadmissionno";
            this.txtsadmissionno.Size = new System.Drawing.Size(180, 29);
            this.txtsadmissionno.TabIndex = 1;
            // 
            // rdobyadmission
            // 
            this.rdobyadmission.AutoSize = true;
            this.rdobyadmission.Checked = true;
            this.rdobyadmission.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdobyadmission.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.rdobyadmission.Location = new System.Drawing.Point(20, 22);
            this.rdobyadmission.Margin = new System.Windows.Forms.Padding(4);
            this.rdobyadmission.Name = "rdobyadmission";
            this.rdobyadmission.Size = new System.Drawing.Size(152, 25);
            this.rdobyadmission.TabIndex = 0;
            this.rdobyadmission.TabStop = true;
            this.rdobyadmission.Text = "By Admission No";
            this.rdobyadmission.UseVisualStyleBackColor = true;
            this.rdobyadmission.Click += new System.EventHandler(this.rdobyadmission_Click);
            // 
            // txtbyname
            // 
            this.txtbyname.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtbyname.Location = new System.Drawing.Point(480, 20);
            this.txtbyname.Margin = new System.Windows.Forms.Padding(4);
            this.txtbyname.Name = "txtbyname";
            this.txtbyname.Size = new System.Drawing.Size(220, 29);
            this.txtbyname.TabIndex = 3;
            // 
            // rdobyname
            // 
            this.rdobyname.AutoSize = true;
            this.rdobyname.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.rdobyname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.rdobyname.Location = new System.Drawing.Point(380, 22);
            this.rdobyname.Margin = new System.Windows.Forms.Padding(4);
            this.rdobyname.Name = "rdobyname";
            this.rdobyname.Size = new System.Drawing.Size(95, 25);
            this.rdobyname.TabIndex = 2;
            this.rdobyname.Text = "By Name";
            this.rdobyname.UseVisualStyleBackColor = true;
            this.rdobyname.Click += new System.EventHandler(this.rdobyname_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.pictureBoxIcon);
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Controls.Add(this.lblHeaderSub);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1620, 65);
            this.panelHeader.TabIndex = 0;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcon.Image")));
            this.pictureBoxIcon.Location = new System.Drawing.Point(18, 14);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(36, 36);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(62, 10);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(225, 32);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Search Students";
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(63, 38);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(430, 20);
            this.lblHeaderSub.TabIndex = 2;
            this.lblHeaderSub.Text = "Search and view student records by Admission Number or Student Name";
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.Controls.Add(this.rdobyadmission);
            this.panelSearch.Controls.Add(this.txtsadmissionno);
            this.panelSearch.Controls.Add(this.rdobyname);
            this.panelSearch.Controls.Add(this.txtbyname);
            this.panelSearch.Controls.Add(this.btn_Modify);
            this.panelSearch.Controls.Add(this.btn_Close);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 65);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1620, 70);
            this.panelSearch.TabIndex = 1;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.lstv_Student);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 135);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1620, 586);
            this.panelGrid.TabIndex = 2;
            // 
            // frmsearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1620, 721);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmsearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advance Student Search";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.ListView lstv_Student;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.TextBox txtsadmissionno;
        private System.Windows.Forms.RadioButton rdobyadmission;
        private System.Windows.Forms.TextBox txtbyname;
        private System.Windows.Forms.RadioButton rdobyname;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Panel panelGrid;
    }
}