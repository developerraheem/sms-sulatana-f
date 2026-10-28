namespace GL_SCHOOL
{
    partial class FrmVoucherTypes
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
            this.txtvoucherdesc = new System.Windows.Forms.TextBox();
            this.txtvouchertype = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstv_Vouchers = new System.Windows.Forms.ListView();
            this.btnexit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(263, 320);
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
            this.btnDelete.Location = new System.Drawing.Point(182, 320);
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
            this.btnUpdate.Location = new System.Drawing.Point(101, 320);
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
            this.columnHeader3.Width = 350;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(20, 320);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(80, 27);
            this.btnadd.TabIndex = 10;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtvoucherdesc);
            this.groupBox1.Controls.Add(this.txtvouchertype);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(25, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 97);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Voucher Definition";
            // 
            // txtvoucherdesc
            // 
            this.txtvoucherdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtvoucherdesc.Location = new System.Drawing.Point(114, 63);
            this.txtvoucherdesc.Name = "txtvoucherdesc";
            this.txtvoucherdesc.Size = new System.Drawing.Size(482, 20);
            this.txtvoucherdesc.TabIndex = 3;
            // 
            // txtvouchertype
            // 
            this.txtvouchertype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtvouchertype.Location = new System.Drawing.Point(114, 26);
            this.txtvouchertype.Name = "txtvouchertype";
            this.txtvouchertype.Size = new System.Drawing.Size(204, 20);
            this.txtvouchertype.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voucher Type";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            this.columnHeader1.Width = 90;
            // 
            // lstv_Vouchers
            // 
            this.lstv_Vouchers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.lstv_Vouchers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstv_Vouchers.FullRowSelect = true;
            this.lstv_Vouchers.GridLines = true;
            this.lstv_Vouchers.Location = new System.Drawing.Point(25, 48);
            this.lstv_Vouchers.Name = "lstv_Vouchers";
            this.lstv_Vouchers.Size = new System.Drawing.Size(634, 140);
            this.lstv_Vouchers.TabIndex = 9;
            this.lstv_Vouchers.UseCompatibleStateImageBehavior = false;
            this.lstv_Vouchers.View = System.Windows.Forms.View.Details;
            this.lstv_Vouchers.SelectedIndexChanged += new System.EventHandler(this.lstv_Vouchers_SelectedIndexChanged);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(579, 320);
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
            this.label5.Location = new System.Drawing.Point(21, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "Voucher Types Definition";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Code";
            // 
            // FrmVoucherTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 363);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstv_Vouchers);
            this.Controls.Add(this.btnexit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVoucherTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Voucher Types Definition";
            this.Load += new System.EventHandler(this.FrmVoucherTypes_Load);
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
        private System.Windows.Forms.TextBox txtvoucherdesc;
        private System.Windows.Forms.TextBox txtvouchertype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstv_Vouchers;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}