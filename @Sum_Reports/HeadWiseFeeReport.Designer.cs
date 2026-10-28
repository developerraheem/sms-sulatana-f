namespace School._forms
{
    partial class HeadWiseFeeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeadWiseFeeReport));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.panelCard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfeemonth = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbshift = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbsection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbfeehead = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.chkdate = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtfrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtto = new System.Windows.Forms.DateTimePicker();
            this.btnprint = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(544, 55);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 16);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(225, 21);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Single Head Wise Fee Report";
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.label1);
            this.panelCard.Controls.Add(this.txtfeemonth);
            this.panelCard.Controls.Add(this.label5);
            this.panelCard.Controls.Add(this.cmbclass);
            this.panelCard.Controls.Add(this.label8);
            this.panelCard.Controls.Add(this.cmbshift);
            this.panelCard.Controls.Add(this.label3);
            this.panelCard.Controls.Add(this.cmbsection);
            this.panelCard.Controls.Add(this.label2);
            this.panelCard.Controls.Add(this.cmbfeehead);
            this.panelCard.Controls.Add(this.label4);
            this.panelCard.Controls.Add(this.cmbType);
            this.panelCard.Controls.Add(this.chkdate);
            this.panelCard.Controls.Add(this.groupBox2);
            this.panelCard.Controls.Add(this.btnprint);
            this.panelCard.Location = new System.Drawing.Point(24, 70);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(495, 400);
            this.panelCard.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Month:";
            // 
            // txtfeemonth
            // 
            this.txtfeemonth.CustomFormat = "MM yyyy";
            this.txtfeemonth.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtfeemonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtfeemonth.Location = new System.Drawing.Point(160, 18);
            this.txtfeemonth.Name = "txtfeemonth";
            this.txtfeemonth.Size = new System.Drawing.Size(290, 24);
            this.txtfeemonth.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label5.Location = new System.Drawing.Point(30, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Select Class:";
            // 
            // cmbclass
            // 
            this.cmbclass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbclass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Location = new System.Drawing.Point(160, 58);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(290, 25);
            this.cmbclass.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label8.Location = new System.Drawing.Point(30, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Select Shift:";
            // 
            // cmbshift
            // 
            this.cmbshift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbshift.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbshift.FormattingEnabled = true;
            this.cmbshift.Location = new System.Drawing.Point(160, 98);
            this.cmbshift.Name = "cmbshift";
            this.cmbshift.Size = new System.Drawing.Size(290, 25);
            this.cmbshift.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label3.Location = new System.Drawing.Point(30, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select Section:";
            // 
            // cmbsection
            // 
            this.cmbsection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsection.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsection.FormattingEnabled = true;
            this.cmbsection.Location = new System.Drawing.Point(160, 138);
            this.cmbsection.Name = "cmbsection";
            this.cmbsection.Size = new System.Drawing.Size(290, 25);
            this.cmbsection.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label2.Location = new System.Drawing.Point(30, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Fee Head:";
            // 
            // cmbfeehead
            // 
            this.cmbfeehead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfeehead.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbfeehead.FormattingEnabled = true;
            this.cmbfeehead.Location = new System.Drawing.Point(160, 178);
            this.cmbfeehead.Name = "cmbfeehead";
            this.cmbfeehead.Size = new System.Drawing.Size(290, 25);
            this.cmbfeehead.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label4.Location = new System.Drawing.Point(30, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Type:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Paid",
            "UnPaid",
            "All"});
            this.cmbType.Location = new System.Drawing.Point(160, 218);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(160, 25);
            this.cmbType.TabIndex = 11;
            // 
            // chkdate
            // 
            this.chkdate.AutoSize = true;
            this.chkdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkdate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.chkdate.Location = new System.Drawing.Point(30, 260);
            this.chkdate.Name = "chkdate";
            this.chkdate.Size = new System.Drawing.Size(131, 21);
            this.chkdate.TabIndex = 12;
            this.chkdate.Text = "DateWise Report";
            this.chkdate.UseVisualStyleBackColor = true;
            this.chkdate.CheckedChanged += new System.EventHandler(this.chkdate_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtfrom);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtto);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.groupBox2.Location = new System.Drawing.Point(30, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 55);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Dates";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label6.Location = new System.Drawing.Point(15, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "From:";
            // 
            // txtfrom
            // 
            this.txtfrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfrom.Location = new System.Drawing.Point(60, 20);
            this.txtfrom.Name = "txtfrom";
            this.txtfrom.Size = new System.Drawing.Size(130, 23);
            this.txtfrom.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label7.Location = new System.Drawing.Point(215, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "To:";
            // 
            // txtto
            // 
            this.txtto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtto.Location = new System.Drawing.Point(250, 20);
            this.txtto.Name = "txtto";
            this.txtto.Size = new System.Drawing.Size(130, 23);
            this.txtto.TabIndex = 3;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(320, 352);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(130, 38);
            this.btnprint.TabIndex = 14;
            this.btnprint.Text = "  Print Preview";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // HeadWiseFeeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(544, 490);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeadWiseFeeReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Single Head Wise Fee Report";
            this.Load += new System.EventHandler(this.FrmFeeHeadWIse_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtfeemonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbshift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbsection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbfeehead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.CheckBox chkdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker txtfrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker txtto;
        private System.Windows.Forms.Button btnprint;
    }
}