namespace School._forms
{
    partial class FrmVoucherPr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVoucherPr));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.panelCard1 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbsession = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmonth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbsection = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbshift = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtadmNo = new System.Windows.Forms.TextBox();
            this.btnfind = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panelCard2 = new System.Windows.Forms.Panel();
            this.lblDupTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtvoucherno = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelCard1.SuspendLayout();
            this.panelCard2.SuspendLayout();
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(166, 21);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Fee Vouchers Report";
            // 
            // panelCard1
            // 
            this.panelCard1.BackColor = System.Drawing.Color.White;
            this.panelCard1.Controls.Add(this.label35);
            this.panelCard1.Controls.Add(this.cmbsession);
            this.panelCard1.Controls.Add(this.label5);
            this.panelCard1.Controls.Add(this.cmbclass);
            this.panelCard1.Controls.Add(this.label4);
            this.panelCard1.Controls.Add(this.txtmonth);
            this.panelCard1.Controls.Add(this.label1);
            this.panelCard1.Controls.Add(this.cmbsection);
            this.panelCard1.Controls.Add(this.label8);
            this.panelCard1.Controls.Add(this.cmbshift);
            this.panelCard1.Controls.Add(this.checkBox1);
            this.panelCard1.Controls.Add(this.label6);
            this.panelCard1.Controls.Add(this.txtadmNo);
            this.panelCard1.Controls.Add(this.btnfind);
            this.panelCard1.Controls.Add(this.button3);
            this.panelCard1.Controls.Add(this.button4);
            this.panelCard1.Location = new System.Drawing.Point(24, 70);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(495, 345);
            this.panelCard1.TabIndex = 1;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label35.Location = new System.Drawing.Point(30, 20);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(59, 17);
            this.label35.TabIndex = 0;
            this.label35.Text = "Session:";
            // 
            // cmbsession
            // 
            this.cmbsession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsession.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsession.FormattingEnabled = true;
            this.cmbsession.Location = new System.Drawing.Point(170, 16);
            this.cmbsession.Name = "cmbsession";
            this.cmbsession.Size = new System.Drawing.Size(285, 25);
            this.cmbsession.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label5.Location = new System.Drawing.Point(30, 60);
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
            this.cmbclass.Location = new System.Drawing.Point(170, 56);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(285, 25);
            this.cmbclass.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label4.Location = new System.Drawing.Point(30, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Select Fee Month:";
            // 
            // txtmonth
            // 
            this.txtmonth.CustomFormat = "MM yyyy";
            this.txtmonth.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtmonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtmonth.Location = new System.Drawing.Point(170, 96);
            this.txtmonth.Name = "txtmonth";
            this.txtmonth.Size = new System.Drawing.Size(285, 24);
            this.txtmonth.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(30, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Section:";
            // 
            // cmbsection
            // 
            this.cmbsection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsection.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsection.FormattingEnabled = true;
            this.cmbsection.Location = new System.Drawing.Point(170, 136);
            this.cmbsection.Name = "cmbsection";
            this.cmbsection.Size = new System.Drawing.Size(285, 25);
            this.cmbsection.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label8.Location = new System.Drawing.Point(30, 180);
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
            this.cmbshift.Location = new System.Drawing.Point(170, 176);
            this.cmbshift.Name = "cmbshift";
            this.cmbshift.Size = new System.Drawing.Size(285, 25);
            this.cmbshift.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.checkBox1.Location = new System.Drawing.Point(30, 220);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 21);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "By Admission No";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label6.Location = new System.Drawing.Point(30, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Enter Student ID:";
            // 
            // txtadmNo
            // 
            this.txtadmNo.Enabled = false;
            this.txtadmNo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtadmNo.Location = new System.Drawing.Point(170, 248);
            this.txtadmNo.Name = "txtadmNo";
            this.txtadmNo.Size = new System.Drawing.Size(195, 24);
            this.txtadmNo.TabIndex = 12;
            // 
            // btnfind
            // 
            this.btnfind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnfind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfind.Enabled = false;
            this.btnfind.FlatAppearance.BorderSize = 0;
            this.btnfind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnfind.ForeColor = System.Drawing.Color.White;
            this.btnfind.Image = ((System.Drawing.Image)(resources.GetObject("btnfind.Image")));
            this.btnfind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfind.Location = new System.Drawing.Point(370, 246);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(85, 28);
            this.btnfind.TabIndex = 13;
            this.btnfind.Text = "  Find";
            this.btnfind.UseVisualStyleBackColor = false;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(325, 292);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 38);
            this.button3.TabIndex = 14;
            this.button3.Text = "  Print Voucher";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(0, 0);
            this.button4.TabIndex = 15;
            this.button4.Visible = false;
            // 
            // panelCard2
            // 
            this.panelCard2.BackColor = System.Drawing.Color.White;
            this.panelCard2.Controls.Add(this.lblDupTitle);
            this.panelCard2.Controls.Add(this.label2);
            this.panelCard2.Controls.Add(this.txtvoucherno);
            this.panelCard2.Controls.Add(this.button2);
            this.panelCard2.Controls.Add(this.button1);
            this.panelCard2.Location = new System.Drawing.Point(24, 430);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Size = new System.Drawing.Size(495, 75);
            this.panelCard2.TabIndex = 2;
            // 
            // lblDupTitle
            // 
            this.lblDupTitle.AutoSize = true;
            this.lblDupTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDupTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.lblDupTitle.Location = new System.Drawing.Point(15, 6);
            this.lblDupTitle.Name = "lblDupTitle";
            this.lblDupTitle.Size = new System.Drawing.Size(161, 15);
            this.lblDupTitle.TabIndex = 0;
            this.lblDupTitle.Text = "Duplicate Voucher Printing";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label2.Location = new System.Drawing.Point(30, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Voucher No:";
            // 
            // txtvoucherno
            // 
            this.txtvoucherno.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtvoucherno.Location = new System.Drawing.Point(170, 28);
            this.txtvoucherno.Name = "txtvoucherno";
            this.txtvoucherno.Size = new System.Drawing.Size(140, 24);
            this.txtvoucherno.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(325, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "  Print Preview";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(0, 0);
            this.button1.TabIndex = 4;
            this.button1.Visible = false;
            // 
            // FrmVoucherPr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(544, 525);
            this.Controls.Add(this.panelCard2);
            this.Controls.Add(this.panelCard1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVoucherPr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Vouchers";
            this.Load += new System.EventHandler(this.FrmVoucherPr_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel panelCard1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbsession;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtmonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbsection;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbshift;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtadmNo;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panelCard2;
        private System.Windows.Forms.Label lblDupTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtvoucherno;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}