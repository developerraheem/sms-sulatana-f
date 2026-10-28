namespace School._forms
{
    partial class frmExam
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExam));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstv_Exam = new System.Windows.Forms.ListView();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblid = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Add = new System.Windows.Forms.ToolStripButton();
            this.side1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Edit = new System.Windows.Forms.ToolStripButton();
            this.side2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Delete = new System.Windows.Forms.ToolStripButton();
            this.side3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Refresh = new System.Windows.Forms.ToolStripButton();
            this.side4 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_close = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtEname);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(13, 99);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(601, 75);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // txtEname
            // 
            this.txtEname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEname.Location = new System.Drawing.Point(116, 28);
            this.txtEname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEname.Name = "txtEname";
            this.txtEname.Size = new System.Drawing.Size(445, 22);
            this.txtEname.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Exam Name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Examination Name";
            this.columnHeader3.Width = 350;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Exam ID";
            // 
            // lstv_Exam
            // 
            this.lstv_Exam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.lstv_Exam.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstv_Exam.FullRowSelect = true;
            this.lstv_Exam.GridLines = true;
            this.lstv_Exam.Location = new System.Drawing.Point(13, 182);
            this.lstv_Exam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstv_Exam.Name = "lstv_Exam";
            this.lstv_Exam.Size = new System.Drawing.Size(601, 346);
            this.lstv_Exam.TabIndex = 1;
            this.lstv_Exam.UseCompatibleStateImageBehavior = false;
            this.lstv_Exam.View = System.Windows.Forms.View.Details;
            this.lstv_Exam.SelectedIndexChanged += new System.EventHandler(this.lstv_Exam_SelectedIndexChanged);
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.AutoSize = true;
            this.lbl_Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.lbl_Mode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Mode.ForeColor = System.Drawing.Color.Red;
            this.lbl_Mode.Location = new System.Drawing.Point(551, 16);
            this.lbl_Mode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(61, 17);
            this.lbl_Mode.TabIndex = 7;
            this.lbl_Mode.Text = "Mode :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(478, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mode :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(453, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "|";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(199, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter All Your Exam Here";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(484, 68);
            this.lblid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(0, 17);
            this.lblid.TabIndex = 21;
            this.lblid.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panel4.Controls.Add(this.pictureBox10);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lbl_Mode);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(634, 60);
            this.panel4.TabIndex = 69;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(18, 14);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(31, 31);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 2;
            this.pictureBox10.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(60, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Exams Setup";
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.AutoSize = false;
            this.lbl_Mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lbl_Mode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.lbl_Mode.Location = new System.Drawing.Point(480, 16);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(130, 28);
            this.lbl_Mode.TabIndex = 10;
            this.lbl_Mode.Text = "Mode";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Visible = false;
            // 
            // label6
            // 
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Add,
            this.side1,
            this.btn_Edit,
            this.side2,
            this.btn_Delete,
            this.side3,
            this.btn_Refresh,
            this.side4,
            this.btn_Cancel,
            this.toolStripSeparator7,
            this.btn_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 53);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(634, 31);
            this.toolStrip1.TabIndex = 70;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Add
            // 
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(68, 28);
            this.btn_Add.Text = "&Save";
            // 
            // side1
            // 
            this.side1.Name = "side1";
            this.side1.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Edit.Image")));
            this.btn_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(86, 28);
            this.btn_Edit.Text = "&Update";
            // 
            // side2
            // 
            this.side2.Name = "side2";
            this.side2.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(81, 28);
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.ToolTipText = "Delete";
            // 
            // side3
            // 
            this.side3.Name = "side3";
            this.side3.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(86, 28);
            this.btn_Refresh.Text = "&Refresh";
            // 
            // side4
            // 
            this.side4.Name = "side4";
            this.side4.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(81, 28);
            this.btn_Cancel.Text = "&Cancel";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
            // 
            // btn_close
            // 
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(73, 28);
            this.btn_close.Text = "&Close";
            // 
            // frmExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(634, 544);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.lstv_Exam);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmExam";
            this.Text = "Examniation";
            this.Load += new System.EventHandler(this.frmExam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstv_Exam;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Add;
        private System.Windows.Forms.ToolStripSeparator side1;
        private System.Windows.Forms.ToolStripButton btn_Edit;
        private System.Windows.Forms.ToolStripSeparator side2;
        private System.Windows.Forms.ToolStripButton btn_Delete;
        private System.Windows.Forms.ToolStripSeparator side3;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.ToolStripSeparator side4;
        private System.Windows.Forms.ToolStripButton btn_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btn_close;

    }
}