namespace GL_SCHOOL
{
    partial class FrmChartofAccounts
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
            this.btnclear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnadd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbsubgroup = new System.Windows.Forms.ComboBox();
            this.cmbmaingroup = new System.Windows.Forms.ComboBox();
            this.txtopbal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtaccdesc = new System.Windows.Forms.TextBox();
            this.txtacccode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstv_coa = new System.Windows.Forms.ListView();
            this.Obbal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnexit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(263, 344);
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
            this.btnDelete.Location = new System.Drawing.Point(182, 344);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 27);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(101, 344);
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
            this.columnHeader3.Width = 300;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(21, 344);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(80, 27);
            this.btnadd.TabIndex = 10;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbsubgroup);
            this.groupBox1.Controls.Add(this.cmbmaingroup);
            this.groupBox1.Controls.Add(this.txtopbal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtaccdesc);
            this.groupBox1.Controls.Add(this.txtacccode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(14, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 251);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Group Information";
            // 
            // cmbsubgroup
            // 
            this.cmbsubgroup.FormattingEnabled = true;
            this.cmbsubgroup.Location = new System.Drawing.Point(12, 107);
            this.cmbsubgroup.Name = "cmbsubgroup";
            this.cmbsubgroup.Size = new System.Drawing.Size(488, 21);
            this.cmbsubgroup.TabIndex = 13;
            this.cmbsubgroup.Text = "Select Sub Group Code . . ";
            this.cmbsubgroup.SelectedIndexChanged += new System.EventHandler(this.cmbsubgroup_SelectedIndexChanged);
            // 
            // cmbmaingroup
            // 
            this.cmbmaingroup.FormattingEnabled = true;
            this.cmbmaingroup.Location = new System.Drawing.Point(12, 49);
            this.cmbmaingroup.Name = "cmbmaingroup";
            this.cmbmaingroup.Size = new System.Drawing.Size(488, 21);
            this.cmbmaingroup.TabIndex = 12;
            this.cmbmaingroup.Text = "Select Main Group Code. .";
            this.cmbmaingroup.SelectedIndexChanged += new System.EventHandler(this.cmbmaingroup_SelectedIndexChanged);
            // 
            // txtopbal
            // 
            this.txtopbal.Location = new System.Drawing.Point(12, 216);
            this.txtopbal.Name = "txtopbal";
            this.txtopbal.Size = new System.Drawing.Size(133, 20);
            this.txtopbal.TabIndex = 11;
            this.txtopbal.Text = "0";
            this.txtopbal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtopbal_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Opening Balance";
            // 
            // txtaccdesc
            // 
            this.txtaccdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtaccdesc.Location = new System.Drawing.Point(156, 158);
            this.txtaccdesc.Name = "txtaccdesc";
            this.txtaccdesc.Size = new System.Drawing.Size(344, 20);
            this.txtaccdesc.TabIndex = 9;
            this.txtaccdesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaccdesc_KeyPress);
            // 
            // txtacccode
            // 
            this.txtacccode.Location = new System.Drawing.Point(12, 158);
            this.txtacccode.Name = "txtacccode";
            this.txtacccode.ReadOnly = true;
            this.txtacccode.Size = new System.Drawing.Size(133, 20);
            this.txtacccode.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Account #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sub Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Group";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Account Code";
            this.columnHeader1.Width = 100;
            // 
            // lstv_coa
            // 
            this.lstv_coa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.Obbal});
            this.lstv_coa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstv_coa.FullRowSelect = true;
            this.lstv_coa.GridLines = true;
            this.lstv_coa.Location = new System.Drawing.Point(536, 66);
            this.lstv_coa.Name = "lstv_coa";
            this.lstv_coa.Size = new System.Drawing.Size(519, 312);
            this.lstv_coa.TabIndex = 9;
            this.lstv_coa.UseCompatibleStateImageBehavior = false;
            this.lstv_coa.View = System.Windows.Forms.View.Details;
            // 
            // Obbal
            // 
            this.Obbal.Text = "Op Balance";
            this.Obbal.Width = 100;
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(435, 344);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(80, 27);
            this.btnexit.TabIndex = 14;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(17, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Chart of Account Definition";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 17;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmChartofAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 394);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstv_coa);
            this.Controls.Add(this.btnexit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmChartofAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chart of Account Definition";
            this.Load += new System.EventHandler(this.FrmChartofAccounts_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstv_coa;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtaccdesc;
        private System.Windows.Forms.TextBox txtacccode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtopbal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader Obbal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbmaingroup;
        private System.Windows.Forms.ComboBox cmbsubgroup;
        private System.Windows.Forms.Button button1;
    }
}