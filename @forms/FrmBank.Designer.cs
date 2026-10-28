namespace School._forms
{
    partial class FrmBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBank));
            this.txt_Cname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSave = new Glass.GlassButton();
            this.btnupdate = new Glass.GlassButton();
            this.btndel = new Glass.GlassButton();
            this.btnrefresh = new Glass.GlassButton();
            this.btncancel = new Glass.GlassButton();
            this.btnclose = new Glass.GlassButton();
            this.lstv_Class = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Cname
            // 
            this.txt_Cname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Cname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cname.Location = new System.Drawing.Point(190, 26);
            this.txt_Cname.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Cname.Name = "txt_Cname";
            this.txt_Cname.Size = new System.Drawing.Size(445, 30);
            this.txt_Cname.TabIndex = 1;
            this.txt_Cname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Cname_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(85, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bank Name";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(393, 100);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 33);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdate.Location = new System.Drawing.Point(469, 100);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(69, 33);
            this.btnupdate.TabIndex = 54;
            this.btnupdate.Text = "Update";
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndel
            // 
            this.btndel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndel.Location = new System.Drawing.Point(543, 100);
            this.btndel.Margin = new System.Windows.Forms.Padding(4);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(69, 33);
            this.btndel.TabIndex = 55;
            this.btndel.Text = "Delete";
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefresh.Location = new System.Drawing.Point(616, 100);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(69, 33);
            this.btnrefresh.TabIndex = 56;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // btncancel
            // 
            this.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancel.Location = new System.Drawing.Point(691, 100);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(69, 33);
            this.btncancel.TabIndex = 57;
            this.btncancel.Text = "Cancel";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnclose
            // 
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(764, 100);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(69, 33);
            this.btnclose.TabIndex = 58;
            this.btnclose.Text = "Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lstv_Class
            // 
            this.lstv_Class.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.lstv_Class.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstv_Class.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstv_Class.FullRowSelect = true;
            this.lstv_Class.GridLines = true;
            this.lstv_Class.Location = new System.Drawing.Point(0, 0);
            this.lstv_Class.Margin = new System.Windows.Forms.Padding(4);
            this.lstv_Class.Name = "lstv_Class";
            this.lstv_Class.Size = new System.Drawing.Size(863, 456);
            this.lstv_Class.TabIndex = 1;
            this.lstv_Class.UseCompatibleStateImageBehavior = false;
            this.lstv_Class.View = System.Windows.Forms.View.Details;
            this.lstv_Class.SelectedIndexChanged += new System.EventHandler(this.lstv_Class_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sr No";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Bank Name";
            this.columnHeader3.Width = 350;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.panel4.Controls.Add(this.pictureBox10);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(863, 53);
            this.panel4.TabIndex = 68;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(12, 9);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(31, 27);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 2;
            this.pictureBox10.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank Entry Form";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txt_Cname);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnupdate);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btndel);
            this.panel1.Controls.Add(this.btnrefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 156);
            this.panel1.TabIndex = 69;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstv_Class);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 209);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 456);
            this.panel2.TabIndex = 70;
            // 
            // FrmBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(863, 665);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank";
            this.Load += new System.EventHandler(this.FrmBank_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Cname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Glass.GlassButton btnSave;
        private Glass.GlassButton btnupdate;
        private Glass.GlassButton btndel;
        private Glass.GlassButton btnrefresh;
        private Glass.GlassButton btncancel;
        private Glass.GlassButton btnclose;
        private System.Windows.Forms.ListView lstv_Class;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}