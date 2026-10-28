namespace School._forms
{
    partial class FrmFeeHeadWIse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFeeHeadWIse));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.panelCard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmonth = new System.Windows.Forms.DateTimePicker();
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
            this.panelHeader.Size = new System.Drawing.Size(500, 55);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 16);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(215, 21);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Fee Head Wise Fee Report";
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.label1);
            this.panelCard.Controls.Add(this.txtmonth);
            this.panelCard.Controls.Add(this.btnprint);
            this.panelCard.Location = new System.Drawing.Point(25, 75);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(450, 160);
            this.panelCard.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Month:";
            // 
            // txtmonth
            // 
            this.txtmonth.CustomFormat = "MM yyyy";
            this.txtmonth.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtmonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtmonth.Location = new System.Drawing.Point(145, 31);
            this.txtmonth.Name = "txtmonth";
            this.txtmonth.Size = new System.Drawing.Size(265, 24);
            this.txtmonth.TabIndex = 1;
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
            this.btnprint.Location = new System.Drawing.Point(280, 95);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(130, 38);
            this.btnprint.TabIndex = 2;
            this.btnprint.Text = "  Print Preview";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // FrmFeeHeadWIse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(500, 260);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFeeHeadWIse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Head Wise Fee Report";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.DateTimePicker txtmonth;
    }
}