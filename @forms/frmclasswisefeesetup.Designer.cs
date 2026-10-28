namespace School._forms
{
    partial class frmclasswisefeesetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmclasswisefeesetup));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnclose = new Glass.GlassButton();
            this.btnCancel = new Glass.GlassButton();
            this.btnDel = new Glass.GlassButton();
            this.btnUpdate = new Glass.GlassButton();
            this.btnSave = new Glass.GlassButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lstv_fee = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.lblid = new System.Windows.Forms.Label();
            this.chk_Active = new System.Windows.Forms.CheckBox();
            this.txtfeeclassid = new System.Windows.Forms.TextBox();
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.cmbfeehead = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnclose);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnDel);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(495, 479);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(448, 70);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // btnclose
            // 
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(352, 23);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(77, 36);
            this.btnclose.TabIndex = 24;
            this.btnclose.Text = "Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(267, 23);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 36);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDel
            // 
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(181, 23);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(77, 36);
            this.btnDel.TabIndex = 22;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(96, 23);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 36);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(11, 23);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 36);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.lstv_fee);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbtype);
            this.groupBox2.Controls.Add(this.lblid);
            this.groupBox2.Controls.Add(this.chk_Active);
            this.groupBox2.Controls.Add(this.txtfeeclassid);
            this.groupBox2.Controls.Add(this.cmbclass);
            this.groupBox2.Controls.Add(this.cmbfeehead);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtamount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 72);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(979, 557);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Records Entry";
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(443, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 31);
            this.button1.TabIndex = 48;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstv_fee
            // 
            this.lstv_fee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader14,
            this.columnHeader3});
            this.lstv_fee.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstv_fee.FullRowSelect = true;
            this.lstv_fee.GridLines = true;
            this.lstv_fee.Location = new System.Drawing.Point(8, 196);
            this.lstv_fee.Margin = new System.Windows.Forms.Padding(4);
            this.lstv_fee.Name = "lstv_fee";
            this.lstv_fee.Size = new System.Drawing.Size(935, 275);
            this.lstv_fee.TabIndex = 24;
            this.lstv_fee.UseCompatibleStateImageBehavior = false;
            this.lstv_fee.View = System.Windows.Forms.View.Details;
            this.lstv_fee.SelectedIndexChanged += new System.EventHandler(this.lstv_fee_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 65;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fee Head";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Amount";
            this.columnHeader14.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Category";
            this.columnHeader3.Width = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 102);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Category:";
            // 
            // cmbtype
            // 
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Location = new System.Drawing.Point(183, 98);
            this.cmbtype.Margin = new System.Windows.Forms.Padding(4);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(251, 24);
            this.cmbtype.TabIndex = 42;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(179, 20);
            this.lblid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(0, 17);
            this.lblid.TabIndex = 25;
            this.lblid.Visible = false;
            // 
            // chk_Active
            // 
            this.chk_Active.AutoSize = true;
            this.chk_Active.Checked = true;
            this.chk_Active.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Active.Location = new System.Drawing.Point(838, 141);
            this.chk_Active.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Active.Name = "chk_Active";
            this.chk_Active.Size = new System.Drawing.Size(68, 21);
            this.chk_Active.TabIndex = 23;
            this.chk_Active.Text = "Active";
            this.chk_Active.UseVisualStyleBackColor = true;
            // 
            // txtfeeclassid
            // 
            this.txtfeeclassid.Location = new System.Drawing.Point(696, 107);
            this.txtfeeclassid.Margin = new System.Windows.Forms.Padding(4);
            this.txtfeeclassid.Name = "txtfeeclassid";
            this.txtfeeclassid.Size = new System.Drawing.Size(132, 22);
            this.txtfeeclassid.TabIndex = 7;
            this.txtfeeclassid.Visible = false;
            // 
            // cmbclass
            // 
            this.cmbclass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Location = new System.Drawing.Point(183, 52);
            this.cmbclass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(251, 24);
            this.cmbclass.TabIndex = 0;
            this.cmbclass.SelectedIndexChanged += new System.EventHandler(this.cmbclass_SelectedIndexChanged);
            this.cmbclass.SelectedValueChanged += new System.EventHandler(this.cmbclass_SelectedValueChanged);
            this.cmbclass.Click += new System.EventHandler(this.cmbclass_Click);
            // 
            // cmbfeehead
            // 
            this.cmbfeehead.DisplayMember = "Fee_head";
            this.cmbfeehead.FormattingEnabled = true;
            this.cmbfeehead.Location = new System.Drawing.Point(183, 139);
            this.cmbfeehead.Margin = new System.Windows.Forms.Padding(4);
            this.cmbfeehead.Name = "cmbfeehead";
            this.cmbfeehead.Size = new System.Drawing.Size(325, 24);
            this.cmbfeehead.TabIndex = 1;
            this.cmbfeehead.ValueMember = "Fee_head_id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(516, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Enter Amount";
            // 
            // txtamount
            // 
            this.txtamount.Location = new System.Drawing.Point(644, 140);
            this.txtamount.Margin = new System.Windows.Forms.Padding(4);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(184, 22);
            this.txtamount.TabIndex = 2;
            this.txtamount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Fee Head";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Select Class";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panel4.Controls.Add(this.pictureBox10);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(995, 60);
            this.panel4.TabIndex = 68;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(60, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 31);
            this.label6.TabIndex = 0;
            this.label6.Text = "Class Wise Fee Mapping";
            // 
            // frmclasswisefeesetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(995, 675);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmclasswisefeesetup";
            this.Text = "Class Wise Fee Setup";
            this.Load += new System.EventHandler(this.frmclasswisefeesetup_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Glass.GlassButton btnclose;
        private Glass.GlassButton btnCancel;
        private Glass.GlassButton btnDel;
        private Glass.GlassButton btnUpdate;
        private Glass.GlassButton btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtfeeclassid;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.ComboBox cmbfeehead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstv_fee;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.CheckBox chk_Active;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label6;
    }
}