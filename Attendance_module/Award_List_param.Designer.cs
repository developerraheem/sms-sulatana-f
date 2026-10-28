namespace School.Attendance_module
{
    partial class Award_List_param
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
            this.cmbclassfrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbsectionfrom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.frmclose = new Glass.GlassButton();
            this.btnSave = new Glass.GlassButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbsubject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtteachername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbclassfrom
            // 
            this.cmbclassfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclassfrom.FormattingEnabled = true;
            this.cmbclassfrom.Location = new System.Drawing.Point(177, 96);
            this.cmbclassfrom.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclassfrom.Name = "cmbclassfrom";
            this.cmbclassfrom.Size = new System.Drawing.Size(343, 28);
            this.cmbclassfrom.TabIndex = 71;
            this.cmbclassfrom.SelectedIndexChanged += new System.EventHandler(this.cmbclassfrom_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 21);
            this.label3.TabIndex = 70;
            this.label3.Text = "Select Class From : ";
            // 
            // cmbsectionfrom
            // 
            this.cmbsectionfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbsectionfrom.FormattingEnabled = true;
            this.cmbsectionfrom.Location = new System.Drawing.Point(177, 140);
            this.cmbsectionfrom.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsectionfrom.Name = "cmbsectionfrom";
            this.cmbsectionfrom.Size = new System.Drawing.Size(343, 28);
            this.cmbsectionfrom.TabIndex = 80;
            this.cmbsectionfrom.SelectedIndexChanged += new System.EventHandler(this.cmbsectionfrom_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 21);
            this.label6.TabIndex = 79;
            this.label6.Text = "Section From :";
            // 
            // frmclose
            // 
            this.frmclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmclose.Location = new System.Drawing.Point(437, 345);
            this.frmclose.Margin = new System.Windows.Forms.Padding(4);
            this.frmclose.Name = "frmclose";
            this.frmclose.Size = new System.Drawing.Size(83, 41);
            this.frmclose.TabIndex = 86;
            this.frmclose.Text = "Close";
            this.frmclose.Click += new System.EventHandler(this.frmclose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(297, 345);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 41);
            this.btnSave.TabIndex = 85;
            this.btnSave.Text = "Generate Report";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(127, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 25);
            this.label4.TabIndex = 87;
            this.label4.Text = "Award List / Attendance Sheet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 81;
            this.label1.Text = "Paper : ";
            // 
            // cmbsubject
            // 
            this.cmbsubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbsubject.FormattingEnabled = true;
            this.cmbsubject.Location = new System.Drawing.Point(177, 186);
            this.cmbsubject.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsubject.Name = "cmbsubject";
            this.cmbsubject.Size = new System.Drawing.Size(343, 28);
            this.cmbsubject.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 21);
            this.label2.TabIndex = 83;
            this.label2.Text = "Class Incharge : ";
            // 
            // txtteachername
            // 
            this.txtteachername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtteachername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtteachername.Location = new System.Drawing.Point(177, 234);
            this.txtteachername.Name = "txtteachername";
            this.txtteachername.Size = new System.Drawing.Size(343, 26);
            this.txtteachername.TabIndex = 88;
            // 
            // Award_List_param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(550, 412);
            this.ControlBox = false;
            this.Controls.Add(this.txtteachername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.frmclose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbsubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbsectionfrom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbclassfrom);
            this.Controls.Add(this.label3);
            this.Name = "Award_List_param";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Award List";
            this.Load += new System.EventHandler(this.Award_List_param_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbclassfrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbsectionfrom;
        private System.Windows.Forms.Label label6;
        private Glass.GlassButton frmclose;
        private Glass.GlassButton btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbsubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtteachername;
    }
}