namespace School._forms
{
    partial class FrmUnpaidVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUnpaidVoucher));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.panelCard = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbsession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmonth = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbshift = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbsection = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtadmNo = new System.Windows.Forms.TextBox();
            this.btnfind = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelCard.SuspendLayout();
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(160, 21);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Voucher List Report";
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.label2);
            this.panelCard.Controls.Add(this.cmbtype);
            this.panelCard.Controls.Add(this.label35);
            this.panelCard.Controls.Add(this.cmbsession);
            this.panelCard.Controls.Add(this.label1);
            this.panelCard.Controls.Add(this.txtmonth);
            this.panelCard.Controls.Add(this.label5);
            this.panelCard.Controls.Add(this.cmbclass);
            this.panelCard.Controls.Add(this.label8);
            this.panelCard.Controls.Add(this.cmbshift);
            this.panelCard.Controls.Add(this.label3);
            this.panelCard.Controls.Add(this.cmbsection);
            this.panelCard.Controls.Add(this.label6);
            this.panelCard.Controls.Add(this.txtadmNo);
            this.panelCard.Controls.Add(this.btnfind);
            this.panelCard.Controls.Add(this.btnprint);
            this.panelCard.Location = new System.Drawing.Point(24, 70);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(495, 400);
            this.panelCard.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label2.Location = new System.Drawing.Point(30, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Report Type:";
            // 
            // cmbtype
            // 
            this.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtype.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            "All",
            "Un-Posted Vouchers",
            "Posted Vouchers",
            "Student Wise Voucher List"});
            this.cmbtype.Location = new System.Drawing.Point(170, 18);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(285, 25);
            this.cmbtype.TabIndex = 1;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label35.Location = new System.Drawing.Point(30, 62);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(59, 17);
            this.label35.TabIndex = 2;
            this.label35.Text = "Session:";
            // 
            // cmbsession
            // 
            this.cmbsession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsession.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsession.FormattingEnabled = true;
            this.cmbsession.Location = new System.Drawing.Point(170, 58);
            this.cmbsession.Name = "cmbsession";
            this.cmbsession.Size = new System.Drawing.Size(285, 25);
            this.cmbsession.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(30, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Month:";
            // 
            // txtmonth
            // 
            this.txtmonth.CustomFormat = "MM yyyy";
            this.txtmonth.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtmonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtmonth.Location = new System.Drawing.Point(170, 98);
            this.txtmonth.Name = "txtmonth";
            this.txtmonth.Size = new System.Drawing.Size(285, 24);
            this.txtmonth.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label5.Location = new System.Drawing.Point(30, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Select Class:";
            // 
            // cmbclass
            // 
            this.cmbclass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbclass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Location = new System.Drawing.Point(170, 138);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(285, 25);
            this.cmbclass.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label8.Location = new System.Drawing.Point(30, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Select Shift:";
            // 
            // cmbshift
            // 
            this.cmbshift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbshift.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbshift.FormattingEnabled = true;
            this.cmbshift.Location = new System.Drawing.Point(170, 178);
            this.cmbshift.Name = "cmbshift";
            this.cmbshift.Size = new System.Drawing.Size(285, 25);
            this.cmbshift.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label3.Location = new System.Drawing.Point(30, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Select Section:";
            // 
            // cmbsection
            // 
            this.cmbsection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsection.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsection.FormattingEnabled = true;
            this.cmbsection.Location = new System.Drawing.Point(170, 218);
            this.cmbsection.Name = "cmbsection";
            this.cmbsection.Size = new System.Drawing.Size(285, 25);
            this.cmbsection.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label6.Location = new System.Drawing.Point(30, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Enter Student ID:";
            // 
            // txtadmNo
            // 
            this.txtadmNo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtadmNo.Location = new System.Drawing.Point(170, 268);
            this.txtadmNo.Name = "txtadmNo";
            this.txtadmNo.Size = new System.Drawing.Size(195, 24);
            this.txtadmNo.TabIndex = 13;
            // 
            // btnfind
            // 
            this.btnfind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnfind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfind.FlatAppearance.BorderSize = 0;
            this.btnfind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnfind.ForeColor = System.Drawing.Color.White;
            this.btnfind.Image = ((System.Drawing.Image)(resources.GetObject("btnfind.Image")));
            this.btnfind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfind.Location = new System.Drawing.Point(370, 266);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(85, 28);
            this.btnfind.TabIndex = 14;
            this.btnfind.Text = "  Find";
            this.btnfind.UseVisualStyleBackColor = false;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click);
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
            this.btnprint.Location = new System.Drawing.Point(325, 345);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(130, 38);
            this.btnprint.TabIndex = 15;
            this.btnprint.Text = "  Print Preview";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // FrmUnpaidVoucher
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
            this.Name = "FrmUnpaidVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher List";
            this.Load += new System.EventHandler(this.FrmUnpaidVoucher_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbsession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtmonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbshift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbsection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtadmNo;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.Button btnprint;
    }
}