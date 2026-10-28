namespace School.Reports
{
    partial class rpt_admission_datewise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpt_admission_datewise));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdatefrom = new System.Windows.Forms.DateTimePicker();
            this.txtdateto = new System.Windows.Forms.DateTimePicker();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
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
            this.panelHeader.Controls.Add(this.label1);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.label1.Location = new System.Drawing.Point(62, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date Wise Admission Report";
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(63, 38);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(395, 20);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Generate and view student admission report by date range";
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
            this.groupBoxCard.Controls.Add(this.label2);
            this.groupBoxCard.Controls.Add(this.txtdatefrom);
            this.groupBoxCard.Controls.Add(this.label3);
            this.groupBoxCard.Controls.Add(this.txtdateto);
            this.groupBoxCard.Controls.Add(this.btnprint);
            this.groupBoxCard.Controls.Add(this.btnclose);
            this.groupBoxCard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.groupBoxCard.Location = new System.Drawing.Point(20, 15);
            this.groupBoxCard.Name = "groupBoxCard";
            this.groupBoxCard.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxCard.Size = new System.Drawing.Size(875, 175);
            this.groupBoxCard.TabIndex = 0;
            this.groupBoxCard.TabStop = false;
            this.groupBoxCard.Text = "  DATE WISE ADMISSION REPORT  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(30, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date From:";
            // 
            // txtdatefrom
            // 
            this.txtdatefrom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtdatefrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdatefrom.Location = new System.Drawing.Point(150, 32);
            this.txtdatefrom.Name = "txtdatefrom";
            this.txtdatefrom.Size = new System.Drawing.Size(460, 29);
            this.txtdatefrom.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(30, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date To:";
            // 
            // txtdateto
            // 
            this.txtdateto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtdateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdateto.Location = new System.Drawing.Point(150, 72);
            this.txtdateto.Name = "txtdateto";
            this.txtdateto.Size = new System.Drawing.Size(460, 29);
            this.txtdateto.TabIndex = 4;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Location = new System.Drawing.Point(350, 118);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(150, 34);
            this.btnprint.TabIndex = 5;
            this.btnprint.Text = "Print Preview";
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
            this.btnclose.Location = new System.Drawing.Point(510, 118);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(100, 34);
            this.btnclose.TabIndex = 6;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // rpt_admission_datewise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(920, 654);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Name = "rpt_admission_datewise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Date Wise Admission Report";
            this.Load += new System.EventHandler(this.rpt_admission_datewise_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.groupBoxCard.ResumeLayout(false);
            this.groupBoxCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtdatefrom;
        private System.Windows.Forms.DateTimePicker txtdateto;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox groupBoxCard;
    }
}