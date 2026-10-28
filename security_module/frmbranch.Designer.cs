namespace School._forms
{
    partial class frmbranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmbranch));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lstshift = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnsave = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.lblshiftid = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtshortcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbactive = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbranchname = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnupdatepicture = new System.Windows.Forms.Button();
            this.btnremove = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lstshift
            // 
            this.lstshift.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.IsActive,
            this.columnHeader4});
            this.lstshift.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstshift.FullRowSelect = true;
            this.lstshift.GridLines = true;
            this.lstshift.Location = new System.Drawing.Point(774, 92);
            this.lstshift.Margin = new System.Windows.Forms.Padding(4);
            this.lstshift.Name = "lstshift";
            this.lstshift.Size = new System.Drawing.Size(745, 609);
            this.lstshift.TabIndex = 7;
            this.lstshift.UseCompatibleStateImageBehavior = false;
            this.lstshift.View = System.Windows.Forms.View.Details;
            this.lstshift.SelectedIndexChanged += new System.EventHandler(this.lstshift_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Branch Name";
            this.columnHeader3.Width = 242;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Branch Address";
            this.columnHeader2.Width = 250;
            // 
            // IsActive
            // 
            this.IsActive.Width = 158;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Short code";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(392, 217);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(81, 28);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Visible = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(562, 217);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(73, 28);
            this.btnupdate.TabIndex = 4;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(322, 217);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(72, 28);
            this.btndelete.TabIndex = 5;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Visible = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // lblshiftid
            // 
            this.lblshiftid.AutoSize = true;
            this.lblshiftid.Location = new System.Drawing.Point(185, 11);
            this.lblshiftid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblshiftid.Name = "lblshiftid";
            this.lblshiftid.Size = new System.Drawing.Size(0, 17);
            this.lblshiftid.TabIndex = 27;
            this.lblshiftid.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(643, 217);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtshortcode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbactive);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtaddress);
            this.groupBox1.Controls.Add(this.btndelete);
            this.groupBox1.Controls.Add(this.btnupdate);
            this.groupBox1.Controls.Add(this.btnsave);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbranchname);
            this.groupBox1.Location = new System.Drawing.Point(19, 416);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(729, 285);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Branch Setup";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 134);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 17);
            this.label12.TabIndex = 35;
            this.label12.Text = "Short Code:";
            // 
            // txtshortcode
            // 
            this.txtshortcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtshortcode.Location = new System.Drawing.Point(154, 129);
            this.txtshortcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtshortcode.MaxLength = 5;
            this.txtshortcode.Name = "txtshortcode";
            this.txtshortcode.Size = new System.Drawing.Size(130, 22);
            this.txtshortcode.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "Select Orgnization";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(153, 57);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(444, 24);
            this.comboBox1.TabIndex = 32;
            this.comboBox1.Text = "Sultana Foundation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 204);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Active";
            // 
            // cmbactive
            // 
            this.cmbactive.FormattingEnabled = true;
            this.cmbactive.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbactive.Location = new System.Drawing.Point(152, 199);
            this.cmbactive.Margin = new System.Windows.Forms.Padding(4);
            this.cmbactive.Name = "cmbactive";
            this.cmbactive.Size = new System.Drawing.Size(101, 24);
            this.cmbactive.TabIndex = 2;
            this.cmbactive.Text = "Yes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Branch Address";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(153, 162);
            this.txtaddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(443, 22);
            this.txtaddress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Enter Branch Name";
            // 
            // txtbranchname
            // 
            this.txtbranchname.Location = new System.Drawing.Point(154, 93);
            this.txtbranchname.Margin = new System.Windows.Forms.Padding(4);
            this.txtbranchname.Name = "txtbranchname";
            this.txtbranchname.Size = new System.Drawing.Size(443, 22);
            this.txtbranchname.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panelHeader.Controls.Add(this.label9);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1528, 60);
            this.panelHeader.TabIndex = 51;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(20, 13);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(225, 31);
            this.label9.TabIndex = 50;
            this.label9.Text = "Organization Setup";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnupdatepicture);
            this.groupBox2.Controls.Add(this.btnremove);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Location = new System.Drawing.Point(19, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(729, 317);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Organization Setup";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 272);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 58;
            this.label8.Text = "Email:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(154, 268);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(229, 22);
            this.textBox4.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 236);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "Fax No:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(154, 233);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(229, 22);
            this.textBox3.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 201);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 54;
            this.label6.Text = "Phone No:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(154, 197);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(229, 22);
            this.textBox2.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 52;
            this.label2.Text = "Registerd Board:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(154, 161);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 22);
            this.textBox1.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 94);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 17);
            this.label10.TabIndex = 50;
            this.label10.Text = "Organization Address:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(154, 89);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(400, 64);
            this.textBox5.TabIndex = 48;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1, 58);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 17);
            this.label11.TabIndex = 49;
            this.label11.Text = "Organization Name:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(154, 53);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(400, 22);
            this.textBox6.TabIndex = 47;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(562, 32);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(145, 151);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 135;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "";
            // 
            // btnupdatepicture
            // 
            this.btnupdatepicture.Font = new System.Drawing.Font("Arial", 7F);
            this.btnupdatepicture.Location = new System.Drawing.Point(584, 227);
            this.btnupdatepicture.Margin = new System.Windows.Forms.Padding(4);
            this.btnupdatepicture.Name = "btnupdatepicture";
            this.btnupdatepicture.Size = new System.Drawing.Size(114, 33);
            this.btnupdatepicture.TabIndex = 139;
            this.btnupdatepicture.Text = "Upload Logo";
            this.btnupdatepicture.UseVisualStyleBackColor = true;
            this.btnupdatepicture.Click += new System.EventHandler(this.btnupdatepicture_Click);
            // 
            // btnremove
            // 
            this.btnremove.Font = new System.Drawing.Font("Arial", 7F);
            this.btnremove.Location = new System.Drawing.Point(584, 263);
            this.btnremove.Margin = new System.Windows.Forms.Padding(4);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(114, 33);
            this.btnremove.TabIndex = 140;
            this.btnremove.Text = "Remove Logo";
            this.btnremove.UseVisualStyleBackColor = true;
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(584, 189);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 34);
            this.button2.TabIndex = 138;
            this.button2.Text = "Browse Logo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmbranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 714);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstshift);
            this.Controls.Add(this.lblshiftid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmbranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Organization Setup";
            this.Load += new System.EventHandler(this.frmshift_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstshift;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Label lblshiftid;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader IsActive;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbactive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbranchname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtshortcode;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        internal System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnupdatepicture;
        private System.Windows.Forms.Button btnremove;
        internal System.Windows.Forms.Button button2;
    }
}