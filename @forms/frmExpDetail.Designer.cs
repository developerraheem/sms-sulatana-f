namespace School._forms
{
    partial class frmExpDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpDetail));
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btn_Link = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbexpensehea = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dp_expDetail = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEname = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAmtPaid = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new Glass.GlassButton();
            this.btnUpdate = new Glass.GlassButton();
            this.btnDel = new Glass.GlassButton();
            this.btnCancel = new Glass.GlassButton();
            this.btnclose = new Glass.GlassButton();
            this.groupBoxRecords = new System.Windows.Forms.GroupBox();
            this.lstv_ExpDetail = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panelContent.SuspendLayout();
            this.btn_Link.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxRecords.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panel4.Controls.Add(this.pictureBox10);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.lbl_Mode);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1180, 60);
            this.panel4.TabIndex = 0;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(18, 14);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(32, 32);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 2;
            this.pictureBox10.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expense Detail Entry";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.label2.Location = new System.Drawing.Point(310, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter and manage daily institutional expense records";
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lbl_Mode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.lbl_Mode.Location = new System.Drawing.Point(1030, 16);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(130, 28);
            this.lbl_Mode.TabIndex = 2;
            this.lbl_Mode.Text = "Add Mode";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.Visible = false;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.panelContent.Controls.Add(this.btn_Link);
            this.panelContent.Controls.Add(this.groupBoxRecords);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(1180, 560);
            this.panelContent.TabIndex = 1;
            // 
            // btn_Link
            // 
            this.btn_Link.BackColor = System.Drawing.Color.White;
            this.btn_Link.Controls.Add(this.label8);
            this.btn_Link.Controls.Add(this.cmbexpensehea);
            this.btn_Link.Controls.Add(this.label10);
            this.btn_Link.Controls.Add(this.dp_expDetail);
            this.btn_Link.Controls.Add(this.label5);
            this.btn_Link.Controls.Add(this.txtEname);
            this.btn_Link.Controls.Add(this.label11);
            this.btn_Link.Controls.Add(this.txtAmtPaid);
            this.btn_Link.Controls.Add(this.label12);
            this.btn_Link.Controls.Add(this.txtDes);
            this.btn_Link.Controls.Add(this.groupBox2);
            this.btn_Link.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Link.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btn_Link.Location = new System.Drawing.Point(20, 15);
            this.btn_Link.Name = "btn_Link";
            this.btn_Link.Size = new System.Drawing.Size(460, 510);
            this.btn_Link.TabIndex = 0;
            this.btn_Link.TabStop = false;
            this.btn_Link.Text = "EXPENSE ENTRY INFORMATION";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label8.Location = new System.Drawing.Point(20, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Select Expense Head";
            // 
            // cmbexpensehea
            // 
            this.cmbexpensehea.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbexpensehea.FormattingEnabled = true;
            this.cmbexpensehea.Location = new System.Drawing.Point(20, 58);
            this.cmbexpensehea.Name = "cmbexpensehea";
            this.cmbexpensehea.Size = new System.Drawing.Size(260, 29);
            this.cmbexpensehea.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label10.Location = new System.Drawing.Point(300, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Date";
            // 
            // dp_expDetail
            // 
            this.dp_expDetail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dp_expDetail.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_expDetail.Location = new System.Drawing.Point(300, 58);
            this.dp_expDetail.Name = "dp_expDetail";
            this.dp_expDetail.Size = new System.Drawing.Size(140, 29);
            this.dp_expDetail.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label5.Location = new System.Drawing.Point(20, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Expense Name";
            // 
            // txtEname
            // 
            this.txtEname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEname.Enabled = false;
            this.txtEname.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEname.Location = new System.Drawing.Point(20, 128);
            this.txtEname.Name = "txtEname";
            this.txtEname.Size = new System.Drawing.Size(420, 29);
            this.txtEname.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label11.Location = new System.Drawing.Point(20, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Amount Paid";
            // 
            // txtAmtPaid
            // 
            this.txtAmtPaid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmtPaid.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtAmtPaid.Location = new System.Drawing.Point(20, 198);
            this.txtAmtPaid.Name = "txtAmtPaid";
            this.txtAmtPaid.Size = new System.Drawing.Size(200, 29);
            this.txtAmtPaid.TabIndex = 7;
            this.txtAmtPaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmtPaid_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label12.Location = new System.Drawing.Point(20, 245);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Description";
            // 
            // txtDes
            // 
            this.txtDes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDes.Location = new System.Drawing.Point(20, 268);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(420, 80);
            this.txtDes.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnclose);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.groupBox2.Location = new System.Drawing.Point(20, 370);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 115);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(15, 26);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(113, 26);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 36);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(211, 26);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(88, 36);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(309, 26);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.White;
            this.btnclose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnclose.FlatAppearance.BorderSize = 1;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnclose.Location = new System.Drawing.Point(15, 68);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(382, 36);
            this.btnclose.TabIndex = 4;
            this.btnclose.Text = "Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // groupBoxRecords
            // 
            this.groupBoxRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRecords.BackColor = System.Drawing.Color.White;
            this.groupBoxRecords.Controls.Add(this.lstv_ExpDetail);
            this.groupBoxRecords.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.groupBoxRecords.Location = new System.Drawing.Point(500, 15);
            this.groupBoxRecords.Name = "groupBoxRecords";
            this.groupBoxRecords.Size = new System.Drawing.Size(660, 510);
            this.groupBoxRecords.TabIndex = 1;
            this.groupBoxRecords.TabStop = false;
            this.groupBoxRecords.Text = "DAILY EXPENSE RECORDS";
            // 
            // lstv_ExpDetail
            // 
            this.lstv_ExpDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstv_ExpDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader1});
            this.lstv_ExpDetail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstv_ExpDetail.FullRowSelect = true;
            this.lstv_ExpDetail.GridLines = true;
            this.lstv_ExpDetail.Location = new System.Drawing.Point(15, 30);
            this.lstv_ExpDetail.Name = "lstv_ExpDetail";
            this.lstv_ExpDetail.Size = new System.Drawing.Size(630, 465);
            this.lstv_ExpDetail.TabIndex = 0;
            this.lstv_ExpDetail.UseCompatibleStateImageBehavior = false;
            this.lstv_ExpDetail.View = System.Windows.Forms.View.Details;
            this.lstv_ExpDetail.SelectedIndexChanged += new System.EventHandler(this.lstv_Exp_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sr.No";
            this.columnHeader2.Width = 65;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Expense Name";
            this.columnHeader5.Width = 160;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Paid";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmExpDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1180, 620);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel4);
            this.MaximizeBox = false;
            this.Name = "frmExpDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expenses Detail";
            this.Load += new System.EventHandler(this.frmExpDetail_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.btn_Link.ResumeLayout(false);
            this.btn_Link.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxRecords.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox btn_Link;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbexpensehea;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dp_expDetail;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtEname;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAmtPaid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.GroupBox groupBox2;
        private Glass.GlassButton btnSave;
        private Glass.GlassButton btnUpdate;
        private Glass.GlassButton btnDel;
        private Glass.GlassButton btnCancel;
        private Glass.GlassButton btnclose;
        private System.Windows.Forms.GroupBox groupBoxRecords;
        private System.Windows.Forms.ListView lstv_ExpDetail;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}