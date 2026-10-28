namespace School.ReportsNew
{
    partial class Datewiseposting_param
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtfromdate = new System.Windows.Forms.DateTimePicker();
            this.txttodate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnprint.Location = new System.Drawing.Point(170, 181);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 30);
            this.btnprint.TabIndex = 64;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(247, 181);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 30);
            this.btnclose.TabIndex = 65;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "From Date:";
            // 
            // txtfromdate
            // 
            this.txtfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfromdate.Location = new System.Drawing.Point(120, 75);
            this.txtfromdate.Name = "txtfromdate";
            this.txtfromdate.Size = new System.Drawing.Size(202, 20);
            this.txtfromdate.TabIndex = 72;
            // 
            // txttodate
            // 
            this.txttodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txttodate.Location = new System.Drawing.Point(120, 115);
            this.txttodate.Name = "txttodate";
            this.txttodate.Size = new System.Drawing.Size(202, 20);
            this.txttodate.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "To Date:";
            // 
            // Datewiseposting_param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(395, 254);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttodate);
            this.Controls.Add(this.txtfromdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "Datewiseposting_param";
            this.Text = "Parameter Form";
            this.Load += new System.EventHandler(this.DefaulterStudents_monthselection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtfromdate;
        private System.Windows.Forms.DateTimePicker txttodate;
        private System.Windows.Forms.Label label1;
    }
}