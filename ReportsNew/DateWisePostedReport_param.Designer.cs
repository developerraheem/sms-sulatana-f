namespace School.ReportsNew
{
    partial class DateWisePostedReport_param
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.txtfromdate = new System.Windows.Forms.DateTimePicker();
            this.txtdateto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtscrollno = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 24);
            this.label2.TabIndex = 63;
            this.label2.Text = "Date Wise Posted Report";
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(184, 183);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 30);
            this.btnprint.TabIndex = 64;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(261, 183);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 30);
            this.btnclose.TabIndex = 65;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // txtfromdate
            // 
            this.txtfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfromdate.Location = new System.Drawing.Point(129, 72);
            this.txtfromdate.Name = "txtfromdate";
            this.txtfromdate.Size = new System.Drawing.Size(224, 20);
            this.txtfromdate.TabIndex = 66;
            // 
            // txtdateto
            // 
            this.txtdateto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtdateto.Location = new System.Drawing.Point(129, 107);
            this.txtdateto.Name = "txtdateto";
            this.txtdateto.Size = new System.Drawing.Size(224, 20);
            this.txtdateto.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Date From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Date To";
            // 
            // txtscrollno
            // 
            this.txtscrollno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtscrollno.Location = new System.Drawing.Point(128, 137);
            this.txtscrollno.MaxLength = 5;
            this.txtscrollno.Name = "txtscrollno";
            this.txtscrollno.Size = new System.Drawing.Size(103, 20);
            this.txtscrollno.TabIndex = 71;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(52, 141);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 13);
            this.label21.TabIndex = 70;
            this.label21.Text = "Scroll No:";
            // 
            // DateWisePostedReport_param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(395, 237);
            this.Controls.Add(this.txtscrollno);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdateto);
            this.Controls.Add(this.txtfromdate);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "DateWisePostedReport_param";
            this.Text = "Parameter Form";
            this.Load += new System.EventHandler(this.DefaulterStudents_monthselection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.DateTimePicker txtfromdate;
        private System.Windows.Forms.DateTimePicker txtdateto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtscrollno;
        private System.Windows.Forms.Label label21;
    }
}