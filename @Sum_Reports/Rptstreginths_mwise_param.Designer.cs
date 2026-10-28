namespace School._Sum_Reports
{
    partial class Rptstreginths_mwise_param
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rptstreginths_mwise_param));
            this.label8 = new System.Windows.Forms.Label();
            this.cmbshift = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbsection = new System.Windows.Forms.ComboBox();
            this.txtmonth = new System.Windows.Forms.DateTimePicker();
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBoxCard = new System.Windows.Forms.GroupBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelContent.SuspendLayout();
            this.groupBoxCard.SuspendLayout();
            this.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(920, 65);
            this.panelHeader.TabIndex = 0;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
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
            this.lblHeaderTitle.Size = new System.Drawing.Size(315, 32);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Monthwise Strength Report";
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(63, 38);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(485, 20);
            this.lblHeaderSub.TabIndex = 2;
            this.lblHeaderSub.Text = "Generate and view student strength report by class, fee month, section, and shift";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.panelContent.Controls.Add(this.groupBoxCard);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 65);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(920, 589);
            this.panelContent.TabIndex = 1;
            // 
            // groupBoxCard
            // 
            this.groupBoxCard.BackColor = System.Drawing.Color.White;
            this.groupBoxCard.Controls.Add(this.label5);
            this.groupBoxCard.Controls.Add(this.cmbclass);
            this.groupBoxCard.Controls.Add(this.label4);
            this.groupBoxCard.Controls.Add(this.txtmonth);
            this.groupBoxCard.Controls.Add(this.label1);
            this.groupBoxCard.Controls.Add(this.cmbsection);
            this.groupBoxCard.Controls.Add(this.label8);
            this.groupBoxCard.Controls.Add(this.cmbshift);
            this.groupBoxCard.Controls.Add(this.btnprint);
            this.groupBoxCard.Controls.Add(this.btnclose);
            this.groupBoxCard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.groupBoxCard.Location = new System.Drawing.Point(20, 15);
            this.groupBoxCard.Name = "groupBoxCard";
            this.groupBoxCard.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxCard.Size = new System.Drawing.Size(875, 255);
            this.groupBoxCard.TabIndex = 0;
            this.groupBoxCard.TabStop = false;
            this.groupBoxCard.Text = "  MONTHWISE STRENGTH REPORT  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label5.Location = new System.Drawing.Point(30, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 81;
            this.label5.Text = "Select Class:";
            // 
            // cmbclass
            // 
            this.cmbclass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Location = new System.Drawing.Point(180, 32);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(460, 29);
            this.cmbclass.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(30, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 78;
            this.label4.Text = "Select Fee Month:";
            // 
            // txtmonth
            // 
            this.txtmonth.CustomFormat = "MM yyyy";
            this.txtmonth.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtmonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtmonth.Location = new System.Drawing.Point(180, 72);
            this.txtmonth.Name = "txtmonth";
            this.txtmonth.Size = new System.Drawing.Size(460, 29);
            this.txtmonth.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(30, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 82;
            this.label1.Text = "Select Section:";
            // 
            // cmbsection
            // 
            this.cmbsection.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbsection.FormattingEnabled = true;
            this.cmbsection.Location = new System.Drawing.Point(180, 112);
            this.cmbsection.Name = "cmbsection";
            this.cmbsection.Size = new System.Drawing.Size(460, 29);
            this.cmbsection.TabIndex = 79;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label8.Location = new System.Drawing.Point(30, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 83;
            this.label8.Text = "Select Shift:";
            // 
            // cmbshift
            // 
            this.cmbshift.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbshift.FormattingEnabled = true;
            this.cmbshift.Location = new System.Drawing.Point(180, 152);
            this.cmbshift.Name = "cmbshift";
            this.cmbshift.Size = new System.Drawing.Size(460, 29);
            this.cmbshift.TabIndex = 80;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Location = new System.Drawing.Point(380, 198);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(150, 34);
            this.btnprint.TabIndex = 74;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.White;
            this.btnclose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnclose.FlatAppearance.BorderSize = 1;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnclose.Location = new System.Drawing.Point(540, 198);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(100, 34);
            this.btnclose.TabIndex = 75;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // Rptstreginths_mwise_param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(920, 654);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Name = "Rptstreginths_mwise_param";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monthwise Strength Report";
            this.Load += new System.EventHandler(this.Rptstreginths_mwise_param_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.groupBoxCard.ResumeLayout(false);
            this.groupBoxCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbshift;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbsection;
        private System.Windows.Forms.DateTimePicker txtmonth;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox groupBoxCard;
    }
}