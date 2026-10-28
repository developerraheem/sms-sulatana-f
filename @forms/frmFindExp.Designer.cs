namespace School._forms
{
    partial class frmFindExp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbltotal_students = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbltotal_classes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbltotal_sections = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblbranch = new System.Windows.Forms.Label();
            this.lbladdress = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::School.Properties.Resources.top;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 98);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(745, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 21);
            this.button1.TabIndex = 48;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(206)))), ((int)(((byte)(104)))));
            this.label3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "SCMS Dashboard";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Controls.Add(this.lbltotal_students);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 263);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 71);
            this.panel2.TabIndex = 80;
            // 
            // lbltotal_students
            // 
            this.lbltotal_students.AutoSize = true;
            this.lbltotal_students.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal_students.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbltotal_students.Location = new System.Drawing.Point(201, 38);
            this.lbltotal_students.Name = "lbltotal_students";
            this.lbltotal_students.Size = new System.Drawing.Size(22, 24);
            this.lbltotal_students.TabIndex = 1;
            this.lbltotal_students.Text = "0";
            this.lbltotal_students.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enrolled Students";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Green;
            this.panel3.Controls.Add(this.lbltotal_classes);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(248, 263);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 71);
            this.panel3.TabIndex = 81;
            // 
            // lbltotal_classes
            // 
            this.lbltotal_classes.AutoSize = true;
            this.lbltotal_classes.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal_classes.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbltotal_classes.Location = new System.Drawing.Point(201, 38);
            this.lbltotal_classes.Name = "lbltotal_classes";
            this.lbltotal_classes.Size = new System.Drawing.Size(22, 24);
            this.lbltotal_classes.TabIndex = 1;
            this.lbltotal_classes.Text = "0";
            this.lbltotal_classes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Active Classes";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Navy;
            this.panel4.Controls.Add(this.lbltotal_sections);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(515, 263);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(261, 71);
            this.panel4.TabIndex = 82;
            // 
            // lbltotal_sections
            // 
            this.lbltotal_sections.AutoSize = true;
            this.lbltotal_sections.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal_sections.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbltotal_sections.Location = new System.Drawing.Point(201, 38);
            this.lbltotal_sections.Name = "lbltotal_sections";
            this.lbltotal_sections.Size = new System.Drawing.Size(22, 24);
            this.lbltotal_sections.TabIndex = 1;
            this.lbltotal_sections.Text = "0";
            this.lbltotal_sections.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total Sections";
            // 
            // lblbranch
            // 
            this.lblbranch.AutoSize = true;
            this.lblbranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbranch.Location = new System.Drawing.Point(12, 121);
            this.lblbranch.Name = "lblbranch";
            this.lblbranch.Size = new System.Drawing.Size(173, 24);
            this.lblbranch.TabIndex = 83;
            this.lblbranch.Text = "Sultana Foundation";
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladdress.Location = new System.Drawing.Point(23, 154);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(114, 15);
            this.lbladdress.TabIndex = 84;
            this.lbladdress.Text = "Sultana Foundation";
            // 
            // frmFindExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(788, 648);
            this.Controls.Add(this.lbladdress);
            this.Controls.Add(this.lblbranch);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFindExp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmFindExp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbltotal_students;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbltotal_classes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbltotal_sections;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblbranch;
        private System.Windows.Forms.Label lbladdress;
    }
}