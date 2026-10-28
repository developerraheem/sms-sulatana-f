namespace School.Fee_Summary_Reports
{
    partial class STUCKOFF_LEAVE_PARAM_n
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
            this.txtdateto = new System.Windows.Forms.DateTimePicker();
            this.txtdatefrom = new System.Windows.Forms.DateTimePicker();
            this.frmclose = new Glass.GlassButton();
            this.btnSave = new Glass.GlassButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbclassto = new System.Windows.Forms.ComboBox();
            this.cmbclassfrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtdateto
            // 
            this.txtdateto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdateto.Location = new System.Drawing.Point(181, 169);
            this.txtdateto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdateto.Name = "txtdateto";
            this.txtdateto.Size = new System.Drawing.Size(265, 27);
            this.txtdateto.TabIndex = 81;
            // 
            // txtdatefrom
            // 
            this.txtdatefrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdatefrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdatefrom.Location = new System.Drawing.Point(181, 119);
            this.txtdatefrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtdatefrom.Name = "txtdatefrom";
            this.txtdatefrom.Size = new System.Drawing.Size(265, 27);
            this.txtdatefrom.TabIndex = 80;
            // 
            // frmclose
            // 
            this.frmclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmclose.Location = new System.Drawing.Point(363, 368);
            this.frmclose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.frmclose.Name = "frmclose";
            this.frmclose.Size = new System.Drawing.Size(83, 33);
            this.frmclose.TabIndex = 79;
            this.frmclose.Text = "Close";
            this.frmclose.Click += new System.EventHandler(this.frmclose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(218, 368);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 33);
            this.btnSave.TabIndex = 78;
            this.btnSave.Text = "Generate Report";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 77;
            this.label4.Text = "Select End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 76;
            this.label3.Text = "Select Start Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 25);
            this.label2.TabIndex = 75;
            this.label2.Text = "STUCK OFF / LEAVE Students Detail";
            // 
            // cmbclassto
            // 
            this.cmbclassto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclassto.FormattingEnabled = true;
            this.cmbclassto.Location = new System.Drawing.Point(181, 268);
            this.cmbclassto.Name = "cmbclassto";
            this.cmbclassto.Size = new System.Drawing.Size(265, 28);
            this.cmbclassto.TabIndex = 85;
            // 
            // cmbclassfrom
            // 
            this.cmbclassfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclassfrom.FormattingEnabled = true;
            this.cmbclassfrom.Location = new System.Drawing.Point(181, 225);
            this.cmbclassfrom.Name = "cmbclassfrom";
            this.cmbclassfrom.Size = new System.Drawing.Size(265, 28);
            this.cmbclassfrom.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 83;
            this.label1.Text = "Class To : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 229);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 82;
            this.label5.Text = "Class From : ";
            // 
            // STUCKOFF_LEAVE_PARAM_n
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 477);
            this.Controls.Add(this.cmbclassto);
            this.Controls.Add(this.cmbclassfrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtdateto);
            this.Controls.Add(this.txtdatefrom);
            this.Controls.Add(this.frmclose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "STUCKOFF_LEAVE_PARAM_n";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stuck off/ Leave Student ";
            this.Load += new System.EventHandler(this.school_profile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker txtdateto;
        private System.Windows.Forms.DateTimePicker txtdatefrom;
        private Glass.GlassButton frmclose;
        private Glass.GlassButton btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbclassto;
        private System.Windows.Forms.ComboBox cmbclassfrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;

    }
}