namespace School._forms
{
    partial class frmchangesession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmchangesession));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelCard = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDeptBox = new System.Windows.Forms.Panel();
            this.pnlDeptIcon = new System.Windows.Forms.Panel();
            this.picDept = new System.Windows.Forms.PictureBox();
            this.cmbdept = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSessBox = new System.Windows.Forms.Panel();
            this.pnlSessIcon = new System.Windows.Forms.Panel();
            this.picSess = new System.Windows.Forms.PictureBox();
            this.cmbselection = new System.Windows.Forms.ComboBox();
            this.btnshow = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelCard.SuspendLayout();
            this.pnlDeptBox.SuspendLayout();
            this.pnlDeptIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDept)).BeginInit();
            this.pnlSessBox.SuspendLayout();
            this.pnlSessIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSess)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 55);
            this.panel1.TabIndex = 72;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(52, 13);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(161, 30);
            this.label23.TabIndex = 0;
            this.label23.Text = "Select Session";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.label3);
            this.panelCard.Controls.Add(this.pnlDeptBox);
            this.panelCard.Controls.Add(this.label1);
            this.panelCard.Controls.Add(this.pnlSessBox);
            this.panelCard.Controls.Add(this.btnshow);
            this.panelCard.Controls.Add(this.btnexit);
            this.panelCard.Location = new System.Drawing.Point(30, 68);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(440, 226);
            this.panelCard.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.label3.Location = new System.Drawing.Point(20, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Department";
            // 
            // pnlDeptBox
            // 
            this.pnlDeptBox.BackColor = System.Drawing.Color.White;
            this.pnlDeptBox.Controls.Add(this.pnlDeptIcon);
            this.pnlDeptBox.Controls.Add(this.cmbdept);
            this.pnlDeptBox.Location = new System.Drawing.Point(20, 36);
            this.pnlDeptBox.Name = "pnlDeptBox";
            this.pnlDeptBox.Size = new System.Drawing.Size(400, 38);
            this.pnlDeptBox.TabIndex = 310;
            // 
            // pnlDeptIcon
            // 
            this.pnlDeptIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.pnlDeptIcon.Controls.Add(this.picDept);
            this.pnlDeptIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDeptIcon.Location = new System.Drawing.Point(0, 0);
            this.pnlDeptIcon.Name = "pnlDeptIcon";
            this.pnlDeptIcon.Size = new System.Drawing.Size(38, 38);
            this.pnlDeptIcon.TabIndex = 0;
            // 
            // picDept
            // 
            this.picDept.BackColor = System.Drawing.Color.Transparent;
            this.picDept.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.picDept.Location = new System.Drawing.Point(10, 10);
            this.picDept.Name = "picDept";
            this.picDept.Size = new System.Drawing.Size(18, 18);
            this.picDept.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDept.TabIndex = 306;
            this.picDept.TabStop = false;
            // 
            // cmbdept
            // 
            this.cmbdept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbdept.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbdept.FormattingEnabled = true;
            this.cmbdept.Location = new System.Drawing.Point(44, 4);
            this.cmbdept.Name = "cmbdept";
            this.cmbdept.Size = new System.Drawing.Size(348, 31);
            this.cmbdept.TabIndex = 3;
            this.cmbdept.SelectedIndexChanged += new System.EventHandler(this.cmbdept_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.label1.Location = new System.Drawing.Point(20, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Session";
            // 
            // pnlSessBox
            // 
            this.pnlSessBox.BackColor = System.Drawing.Color.White;
            this.pnlSessBox.Controls.Add(this.pnlSessIcon);
            this.pnlSessBox.Controls.Add(this.cmbselection);
            this.pnlSessBox.Location = new System.Drawing.Point(20, 108);
            this.pnlSessBox.Name = "pnlSessBox";
            this.pnlSessBox.Size = new System.Drawing.Size(400, 38);
            this.pnlSessBox.TabIndex = 311;
            // 
            // pnlSessIcon
            // 
            this.pnlSessIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.pnlSessIcon.Controls.Add(this.picSess);
            this.pnlSessIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSessIcon.Location = new System.Drawing.Point(0, 0);
            this.pnlSessIcon.Name = "pnlSessIcon";
            this.pnlSessIcon.Size = new System.Drawing.Size(38, 38);
            this.pnlSessIcon.TabIndex = 0;
            // 
            // picSess
            // 
            this.picSess.BackColor = System.Drawing.Color.Transparent;
            this.picSess.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.picSess.Location = new System.Drawing.Point(10, 10);
            this.picSess.Name = "picSess";
            this.picSess.Size = new System.Drawing.Size(18, 18);
            this.picSess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSess.TabIndex = 307;
            this.picSess.TabStop = false;
            // 
            // cmbselection
            // 
            this.cmbselection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbselection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbselection.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbselection.FormattingEnabled = true;
            this.cmbselection.Location = new System.Drawing.Point(44, 4);
            this.cmbselection.Name = "cmbselection";
            this.cmbselection.Size = new System.Drawing.Size(348, 31);
            this.cmbselection.TabIndex = 1;
            this.cmbselection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbselection_KeyPress);
            // 
            // btnshow
            // 
            this.btnshow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnshow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnshow.FlatAppearance.BorderSize = 0;
            this.btnshow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnshow.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnshow.ForeColor = System.Drawing.Color.White;
            this.btnshow.Location = new System.Drawing.Point(91, 168);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(125, 38);
            this.btnshow.TabIndex = 74;
            this.btnshow.Text = "&Continue";
            this.btnshow.UseVisualStyleBackColor = false;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.White;
            this.btnexit.Location = new System.Drawing.Point(228, 168);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(120, 38);
            this.btnexit.TabIndex = 75;
            this.btnexit.Text = "&Close";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // frmchangesession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(500, 310);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmchangesession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Session";
            this.Load += new System.EventHandler(this.frmchangesession_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.pnlDeptBox.ResumeLayout(false);
            this.pnlDeptIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDept)).EndInit();
            this.pnlSessBox.ResumeLayout(false);
            this.pnlSessIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlDeptBox;
        private System.Windows.Forms.Panel pnlDeptIcon;
        private System.Windows.Forms.PictureBox picDept;
        private System.Windows.Forms.ComboBox cmbdept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSessBox;
        private System.Windows.Forms.Panel pnlSessIcon;
        private System.Windows.Forms.PictureBox picSess;
        private System.Windows.Forms.ComboBox cmbselection;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Button btnexit;
    }
}