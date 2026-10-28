namespace School._forms
{
    partial class frmUnpostVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnpostVoucher));
            this.label1 = new System.Windows.Forms.Label();
            this.txtvoucherno = new System.Windows.Forms.TextBox();
            this.lstv_feedetail = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbltotalamount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnshow = new System.Windows.Forms.Button();
            this.btnupost = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter Voucher No";
            // 
            // txtvoucherno
            // 
            this.txtvoucherno.Location = new System.Drawing.Point(167, 86);
            this.txtvoucherno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtvoucherno.Name = "txtvoucherno";
            this.txtvoucherno.Size = new System.Drawing.Size(141, 22);
            this.txtvoucherno.TabIndex = 5;
            // 
            // lstv_feedetail
            // 
            this.lstv_feedetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lstv_feedetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstv_feedetail.FullRowSelect = true;
            this.lstv_feedetail.GridLines = true;
            this.lstv_feedetail.Location = new System.Drawing.Point(9, 161);
            this.lstv_feedetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstv_feedetail.Name = "lstv_feedetail";
            this.lstv_feedetail.Size = new System.Drawing.Size(765, 489);
            this.lstv_feedetail.TabIndex = 7;
            this.lstv_feedetail.UseCompatibleStateImageBehavior = false;
            this.lstv_feedetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Fee Month";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fee Head";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Amount Payable";
            this.columnHeader10.Width = 110;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Amount Received";
            this.columnHeader11.Width = 120;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Balance";
            this.columnHeader12.Width = 80;
            // 
            // lbltotalamount
            // 
            this.lbltotalamount.AutoSize = true;
            this.lbltotalamount.Location = new System.Drawing.Point(676, 137);
            this.lbltotalamount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotalamount.Name = "lbltotalamount";
            this.lbltotalamount.Size = new System.Drawing.Size(0, 17);
            this.lbltotalamount.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(571, 137);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Total Amount:";
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(312, 85);
            this.btnshow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(67, 28);
            this.btnshow.TabIndex = 10;
            this.btnshow.Text = "Show";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btnupost
            // 
            this.btnupost.Enabled = false;
            this.btnupost.Location = new System.Drawing.Point(387, 84);
            this.btnupost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnupost.Name = "btnupost";
            this.btnupost.Size = new System.Drawing.Size(164, 28);
            this.btnupost.TabIndex = 11;
            this.btnupost.Text = "Unpost Voucher";
            this.btnupost.UseVisualStyleBackColor = true;
            this.btnupost.Click += new System.EventHandler(this.btnupost_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(559, 84);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 28);
            this.button1.TabIndex = 12;
            this.button1.Text = "Delete Voucher";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panel4.Controls.Add(this.pictureBox10);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(785, 60);
            this.panel4.TabIndex = 70;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(60, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Un-Post Voucher";
            // 
            // frmUnpostVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(785, 660);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnupost);
            this.Controls.Add(this.btnshow);
            this.Controls.Add(this.lbltotalamount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstv_feedetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtvoucherno);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmUnpostVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher Unposting";
            this.Load += new System.EventHandler(this.frmUnpostVoucher_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtvoucherno;
        private System.Windows.Forms.ListView lstv_feedetail;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label lbltotalamount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Button btnupost;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label2;
    }
}