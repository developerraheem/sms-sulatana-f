namespace School._forms
{
    partial class Frmfind_student
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
            this.txtclassid = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lst_std = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txtclassid
            // 
            this.txtclassid.Location = new System.Drawing.Point(287, 6);
            this.txtclassid.Name = "txtclassid";
            this.txtclassid.Size = new System.Drawing.Size(55, 20);
            this.txtclassid.TabIndex = 9;
            this.txtclassid.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(387, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lst_std
            // 
            this.lst_std.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader2,
            this.columnHeader5});
            this.lst_std.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_std.FullRowSelect = true;
            this.lst_std.GridLines = true;
            this.lst_std.Location = new System.Drawing.Point(6, 32);
            this.lst_std.Name = "lst_std";
            this.lst_std.Size = new System.Drawing.Size(644, 451);
            this.lst_std.TabIndex = 26;
            this.lst_std.UseCompatibleStateImageBehavior = false;
            this.lst_std.View = System.Windows.Forms.View.Details;
            this.lst_std.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lst_std_KeyPress);
            this.lst_std.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_std_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 65;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Admission No";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 180;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Father Name";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Section";
            // 
            // Frmfind_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(655, 487);
            this.Controls.Add(this.lst_std);
            this.Controls.Add(this.txtclassid);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frmfind_student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Student";
            this.Load += new System.EventHandler(this.Frmfind_student_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtclassid;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView lst_std;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}