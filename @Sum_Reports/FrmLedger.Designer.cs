namespace School._forms
{
    partial class FrmLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLedger));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.panelCard = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbshift = new System.Windows.Forms.ComboBox();
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
            this.panelHeader.Size = new System.Drawing.Size(564, 55);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 16);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(185, 21);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Student Ledger Report";
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.label5);
            this.panelCard.Controls.Add(this.cmbclass);
            this.panelCard.Controls.Add(this.label8);
            this.panelCard.Controls.Add(this.cmbshift);
            this.panelCard.Controls.Add(this.label6);
            this.panelCard.Controls.Add(this.txtadmNo);
            this.panelCard.Controls.Add(this.btnfind);
            this.panelCard.Controls.Add(this.btnprint);
            this.panelCard.Location = new System.Drawing.Point(25, 75);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(514, 235);
            this.panelCard.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label5.Location = new System.Drawing.Point(35, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select Class:";
            // 
            // cmbclass
            // 
            this.cmbclass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbclass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Location = new System.Drawing.Point(165, 26);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(305, 25);
            this.cmbclass.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label8.Location = new System.Drawing.Point(35, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Select Shift:";
            // 
            // cmbshift
            // 
            this.cmbshift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbshift.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbshift.FormattingEnabled = true;
            this.cmbshift.Location = new System.Drawing.Point(165, 71);
            this.cmbshift.Name = "cmbshift";
            this.cmbshift.Size = new System.Drawing.Size(305, 25);
            this.cmbshift.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label6.Location = new System.Drawing.Point(35, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Enter Student ID:";
            // 
            // txtadmNo
            // 
            this.txtadmNo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtadmNo.Location = new System.Drawing.Point(165, 116);
            this.txtadmNo.Name = "txtadmNo";
            this.txtadmNo.Size = new System.Drawing.Size(210, 24);
            this.txtadmNo.TabIndex = 5;
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
            this.btnfind.Location = new System.Drawing.Point(385, 114);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(85, 28);
            this.btnfind.TabIndex = 6;
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
            this.btnprint.Location = new System.Drawing.Point(340, 172);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(130, 38);
            this.btnprint.TabIndex = 7;
            this.btnprint.Text = "  Print Preview";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click_1);
            // 
            // FrmLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(564, 335);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Ledger";
            this.Load += new System.EventHandler(this.FrmLedger_Load);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbshift;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtadmNo;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.Button btnprint;
    }
}