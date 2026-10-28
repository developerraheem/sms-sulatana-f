namespace School._forms
{
    partial class frmshift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmshift));
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBoxShiftInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtshiftname = new System.Windows.Forms.TextBox();
            this.lblshiftid = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxShiftList = new System.Windows.Forms.GroupBox();
            this.lstshift = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panelContent.SuspendLayout();
            this.groupBoxShiftInfo.SuspendLayout();
            this.groupBoxShiftList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panel4.Controls.Add(this.pictureBox10);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.lblHeaderSub);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1120, 60);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(60, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Shift Management";
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(300, 20);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(332, 20);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Configure and manage class shifts for the institution";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.panelContent.Controls.Add(this.groupBoxShiftInfo);
            this.panelContent.Controls.Add(this.groupBoxShiftList);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 65);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(1120, 515);
            this.panelContent.TabIndex = 1;
            // 
            // groupBoxShiftInfo
            // 
            this.groupBoxShiftInfo.BackColor = System.Drawing.Color.White;
            this.groupBoxShiftInfo.Controls.Add(this.label1);
            this.groupBoxShiftInfo.Controls.Add(this.txtshiftname);
            this.groupBoxShiftInfo.Controls.Add(this.lblshiftid);
            this.groupBoxShiftInfo.Controls.Add(this.btnsave);
            this.groupBoxShiftInfo.Controls.Add(this.btnupdate);
            this.groupBoxShiftInfo.Controls.Add(this.btndelete);
            this.groupBoxShiftInfo.Controls.Add(this.button1);
            this.groupBoxShiftInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxShiftInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.groupBoxShiftInfo.Location = new System.Drawing.Point(20, 20);
            this.groupBoxShiftInfo.Name = "groupBoxShiftInfo";
            this.groupBoxShiftInfo.Size = new System.Drawing.Size(480, 240);
            this.groupBoxShiftInfo.TabIndex = 0;
            this.groupBoxShiftInfo.TabStop = false;
            this.groupBoxShiftInfo.Text = "SHIFT INFORMATION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shift Name";
            // 
            // txtshiftname
            // 
            this.txtshiftname.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtshiftname.Location = new System.Drawing.Point(20, 62);
            this.txtshiftname.Name = "txtshiftname";
            this.txtshiftname.Size = new System.Drawing.Size(435, 29);
            this.txtshiftname.TabIndex = 1;
            // 
            // lblshiftid
            // 
            this.lblshiftid.AutoSize = true;
            this.lblshiftid.Location = new System.Drawing.Point(20, 100);
            this.lblshiftid.Name = "lblshiftid";
            this.lblshiftid.Size = new System.Drawing.Size(0, 23);
            this.lblshiftid.TabIndex = 2;
            this.lblshiftid.Visible = false;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(20, 160);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(100, 36);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnupdate.ForeColor = System.Drawing.Color.White;
            this.btnupdate.Location = new System.Drawing.Point(130, 160);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(100, 36);
            this.btnupdate.TabIndex = 4;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btndelete.Enabled = false;
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btndelete.ForeColor = System.Drawing.Color.White;
            this.btndelete.Location = new System.Drawing.Point(240, 160);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(100, 36);
            this.btndelete.TabIndex = 5;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.button1.FlatAppearance.BorderSize = 1;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.button1.Location = new System.Drawing.Point(355, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxShiftList
            // 
            this.groupBoxShiftList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxShiftList.BackColor = System.Drawing.Color.White;
            this.groupBoxShiftList.Controls.Add(this.lstshift);
            this.groupBoxShiftList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxShiftList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.groupBoxShiftList.Location = new System.Drawing.Point(520, 20);
            this.groupBoxShiftList.Name = "groupBoxShiftList";
            this.groupBoxShiftList.Size = new System.Drawing.Size(575, 465);
            this.groupBoxShiftList.TabIndex = 1;
            this.groupBoxShiftList.TabStop = false;
            this.groupBoxShiftList.Text = "SHIFT LIST";
            // 
            // lstshift
            // 
            this.lstshift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstshift.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.lstshift.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstshift.FullRowSelect = true;
            this.lstshift.GridLines = true;
            this.lstshift.Location = new System.Drawing.Point(15, 30);
            this.lstshift.Name = "lstshift";
            this.lstshift.Size = new System.Drawing.Size(545, 415);
            this.lstshift.TabIndex = 0;
            this.lstshift.UseCompatibleStateImageBehavior = false;
            this.lstshift.View = System.Windows.Forms.View.Details;
            this.lstshift.SelectedIndexChanged += new System.EventHandler(this.lstshift_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Shift ID";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Shift Name";
            this.columnHeader3.Width = 380;
            // 
            // frmshift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1120, 580);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel4);
            this.Name = "frmshift";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shift Management";
            this.Load += new System.EventHandler(this.frmshift_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.groupBoxShiftInfo.ResumeLayout(false);
            this.groupBoxShiftInfo.PerformLayout();
            this.groupBoxShiftList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox groupBoxShiftInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtshiftname;
        private System.Windows.Forms.Label lblshiftid;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxShiftList;
        private System.Windows.Forms.ListView lstshift;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}