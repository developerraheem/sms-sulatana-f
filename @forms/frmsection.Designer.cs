namespace School._forms
{
    partial class frmsection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsection));
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBoxSectionInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsectionname = new System.Windows.Forms.TextBox();
            this.lblshiftid = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxSectionList = new System.Windows.Forms.GroupBox();
            this.lstshift = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panelContent.SuspendLayout();
            this.groupBoxSectionInfo.SuspendLayout();
            this.groupBoxSectionList.SuspendLayout();
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
            this.panel4.Size = new System.Drawing.Size(900, 60);
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
            this.label2.Size = new System.Drawing.Size(248, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Add / Modify Sections";
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(320, 20);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(315, 20);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Manage school class sections and room divisions";
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.panelContent.Controls.Add(this.groupBoxSectionInfo);
            this.panelContent.Controls.Add(this.groupBoxSectionList);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20);
            this.panelContent.Size = new System.Drawing.Size(900, 500);
            this.panelContent.TabIndex = 1;
            // 
            // groupBoxSectionInfo
            // 
            this.groupBoxSectionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSectionInfo.BackColor = System.Drawing.Color.White;
            this.groupBoxSectionInfo.Controls.Add(this.label1);
            this.groupBoxSectionInfo.Controls.Add(this.txtsectionname);
            this.groupBoxSectionInfo.Controls.Add(this.lblshiftid);
            this.groupBoxSectionInfo.Controls.Add(this.btnsave);
            this.groupBoxSectionInfo.Controls.Add(this.btnupdate);
            this.groupBoxSectionInfo.Controls.Add(this.btndelete);
            this.groupBoxSectionInfo.Controls.Add(this.button1);
            this.groupBoxSectionInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxSectionInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.groupBoxSectionInfo.Location = new System.Drawing.Point(20, 20);
            this.groupBoxSectionInfo.Name = "groupBoxSectionInfo";
            this.groupBoxSectionInfo.Size = new System.Drawing.Size(860, 140);
            this.groupBoxSectionInfo.TabIndex = 0;
            this.groupBoxSectionInfo.TabStop = false;
            this.groupBoxSectionInfo.Text = "SECTION INFORMATION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Section Name";
            // 
            // txtsectionname
            // 
            this.txtsectionname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsectionname.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtsectionname.Location = new System.Drawing.Point(180, 34);
            this.txtsectionname.Name = "txtsectionname";
            this.txtsectionname.Size = new System.Drawing.Size(660, 29);
            this.txtsectionname.TabIndex = 1;
            // 
            // lblshiftid
            // 
            this.lblshiftid.AutoSize = true;
            this.lblshiftid.Location = new System.Drawing.Point(20, 80);
            this.lblshiftid.Name = "lblshiftid";
            this.lblshiftid.Size = new System.Drawing.Size(0, 23);
            this.lblshiftid.TabIndex = 2;
            this.lblshiftid.Visible = false;
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(400, 80);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(100, 36);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnupdate.ForeColor = System.Drawing.Color.White;
            this.btnupdate.Location = new System.Drawing.Point(510, 80);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(100, 36);
            this.btnupdate.TabIndex = 4;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btndelete.Enabled = false;
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btndelete.ForeColor = System.Drawing.Color.White;
            this.btndelete.Location = new System.Drawing.Point(620, 80);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(100, 36);
            this.btndelete.TabIndex = 5;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(730, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxSectionList
            // 
            this.groupBoxSectionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSectionList.BackColor = System.Drawing.Color.White;
            this.groupBoxSectionList.Controls.Add(this.lstshift);
            this.groupBoxSectionList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxSectionList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.groupBoxSectionList.Location = new System.Drawing.Point(20, 175);
            this.groupBoxSectionList.Name = "groupBoxSectionList";
            this.groupBoxSectionList.Size = new System.Drawing.Size(860, 305);
            this.groupBoxSectionList.TabIndex = 1;
            this.groupBoxSectionList.TabStop = false;
            this.groupBoxSectionList.Text = "SECTION LIST";
            // 
            // lstshift
            // 
            this.lstshift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstshift.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lstshift.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstshift.FullRowSelect = true;
            this.lstshift.GridLines = true;
            this.lstshift.Location = new System.Drawing.Point(15, 30);
            this.lstshift.Name = "lstshift";
            this.lstshift.Size = new System.Drawing.Size(830, 260);
            this.lstshift.TabIndex = 0;
            this.lstshift.UseCompatibleStateImageBehavior = false;
            this.lstshift.View = System.Windows.Forms.View.Details;
            this.lstshift.SelectedIndexChanged += new System.EventHandler(this.lstshift_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Section";
            this.columnHeader3.Width = 800;
            // 
            // frmsection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel4);
            this.Name = "frmsection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Section";
            this.Load += new System.EventHandler(this.frmshift_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.groupBoxSectionInfo.ResumeLayout(false);
            this.groupBoxSectionInfo.PerformLayout();
            this.groupBoxSectionList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.GroupBox groupBoxSectionInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsectionname;
        private System.Windows.Forms.Label lblshiftid;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxSectionList;
        private System.Windows.Forms.ListView lstshift;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}