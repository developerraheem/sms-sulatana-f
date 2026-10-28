namespace School._forms
{
    partial class importdata
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
            this.btnimport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnimport
            // 
            this.btnimport.Location = new System.Drawing.Point(37, 36);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(194, 23);
            this.btnimport.TabIndex = 0;
            this.btnimport.Text = "Import Students";
            this.btnimport.UseVisualStyleBackColor = true;
            this.btnimport.Click += new System.EventHandler(this.btnimport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Import Class Fee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // importdata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnimport);
            this.Name = "importdata";
            this.Text = "importdata";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.Button button1;
    }
}