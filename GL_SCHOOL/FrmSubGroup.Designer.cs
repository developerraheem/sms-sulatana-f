namespace GL_SCHOOL
{
    partial class FrmSubGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSubGroup));
            this.btnclear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnadd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtsubgroupdesc = new System.Windows.Forms.TextBox();
            this.txtsubgroupcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtgroupdesc = new System.Windows.Forms.TextBox();
            this.txtgroupCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstv_sub = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnexit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PnlSearch = new System.Windows.Forms.Panel();
            this.lstmaingroup = new System.Windows.Forms.ListBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.PnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(273, 304);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(80, 27);
            this.btnclear.TabIndex = 13;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(192, 304);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 27);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(111, 304);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 27);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 330;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(25, 304);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(80, 27);
            this.btnadd.TabIndex = 10;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtsubgroupdesc);
            this.groupBox1.Controls.Add(this.txtsubgroupcode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtgroupdesc);
            this.groupBox1.Controls.Add(this.txtgroupCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(7, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 205);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Group Definition";
            // 
            // txtsubgroupdesc
            // 
            this.txtsubgroupdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsubgroupdesc.Location = new System.Drawing.Point(124, 144);
            this.txtsubgroupdesc.Name = "txtsubgroupdesc";
            this.txtsubgroupdesc.Size = new System.Drawing.Size(322, 20);
            this.txtsubgroupdesc.TabIndex = 6;
            this.txtsubgroupdesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsubgroupdesc_KeyPress);
            // 
            // txtsubgroupcode
            // 
            this.txtsubgroupcode.Location = new System.Drawing.Point(11, 144);
            this.txtsubgroupcode.Name = "txtsubgroupcode";
            this.txtsubgroupcode.ReadOnly = true;
            this.txtsubgroupcode.Size = new System.Drawing.Size(105, 20);
            this.txtsubgroupcode.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sub Code";
            // 
            // txtgroupdesc
            // 
            this.txtgroupdesc.Location = new System.Drawing.Point(124, 75);
            this.txtgroupdesc.Name = "txtgroupdesc";
            this.txtgroupdesc.ReadOnly = true;
            this.txtgroupdesc.Size = new System.Drawing.Size(322, 20);
            this.txtgroupdesc.TabIndex = 3;
            // 
            // txtgroupCode
            // 
            this.txtgroupCode.Enabled = false;
            this.txtgroupCode.Location = new System.Drawing.Point(11, 75);
            this.txtgroupCode.Name = "txtgroupCode";
            this.txtgroupCode.Size = new System.Drawing.Size(105, 20);
            this.txtgroupCode.TabIndex = 2;
            this.txtgroupCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtgroupCode_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group Code";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Main Group Code";
            this.columnHeader1.Width = 90;
            // 
            // lstv_sub
            // 
            this.lstv_sub.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstv_sub.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstv_sub.FullRowSelect = true;
            this.lstv_sub.GridLines = true;
            this.lstv_sub.Location = new System.Drawing.Point(470, 70);
            this.lstv_sub.Name = "lstv_sub";
            this.lstv_sub.Size = new System.Drawing.Size(555, 261);
            this.lstv_sub.TabIndex = 9;
            this.lstv_sub.UseCompatibleStateImageBehavior = false;
            this.lstv_sub.View = System.Windows.Forms.View.Details;
            this.lstv_sub.SelectedIndexChanged += new System.EventHandler(this.lstv_sub_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sub Group Code";
            this.columnHeader2.Width = 120;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(384, 304);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(80, 27);
            this.btnexit.TabIndex = 14;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sub Group Code Information";
            // 
            // PnlSearch
            // 
            this.PnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PnlSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlSearch.BackgroundImage")));
            this.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlSearch.Controls.Add(this.lstmaingroup);
            this.PnlSearch.Controls.Add(this.linkLabel1);
            this.PnlSearch.Location = new System.Drawing.Point(359, 22);
            this.PnlSearch.Name = "PnlSearch";
            this.PnlSearch.Size = new System.Drawing.Size(236, 309);
            this.PnlSearch.TabIndex = 25;
            this.PnlSearch.Visible = false;
            // 
            // lstmaingroup
            // 
            this.lstmaingroup.FormattingEnabled = true;
            this.lstmaingroup.Location = new System.Drawing.Point(15, 20);
            this.lstmaingroup.Name = "lstmaingroup";
            this.lstmaingroup.Size = new System.Drawing.Size(206, 251);
            this.lstmaingroup.TabIndex = 55;
            this.lstmaingroup.DoubleClick += new System.EventHandler(this.lstmaingroup_DoubleClick);
            this.lstmaingroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstmaingroup_KeyPress);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Black;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.Red;
            this.linkLabel1.LinkColor = System.Drawing.Color.Yellow;
            this.linkLabel1.Location = new System.Drawing.Point(99, 274);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(42, 13);
            this.linkLabel1.TabIndex = 54;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Close";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // FrmSubGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 354);
            this.Controls.Add(this.PnlSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstv_sub);
            this.Controls.Add(this.btnexit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSubGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sub Group Code Information";
            this.Load += new System.EventHandler(this.FrmSubGroup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PnlSearch.ResumeLayout(false);
            this.PnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtgroupdesc;
        private System.Windows.Forms.TextBox txtgroupCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstv_sub;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.TextBox txtsubgroupdesc;
        private System.Windows.Forms.TextBox txtsubgroupcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel PnlSearch;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox lstmaingroup;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}