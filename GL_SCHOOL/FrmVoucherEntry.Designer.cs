namespace GL_SCHOOL
{
    partial class FrmVoucherEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVoucherEntry));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtvchdate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtvchno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbvouchertype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txttotalamount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PnlSearch = new System.Windows.Forms.Panel();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lstmaingroup = new System.Windows.Forms.ListBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdiffr = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtcheqno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtparticulars = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtrefno = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtacc_dsc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtacc_code = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.PnlSearch.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtvchdate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtvchno);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbvouchertype);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(32, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Voucher Information";
            // 
            // txtvchdate
            // 
            this.txtvchdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtvchdate.Location = new System.Drawing.Point(375, 25);
            this.txtvchdate.Name = "txtvchdate";
            this.txtvchdate.Size = new System.Drawing.Size(116, 23);
            this.txtvchdate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(289, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Voucher Date:";
            // 
            // txtvchno
            // 
            this.txtvchno.Location = new System.Drawing.Point(575, 25);
            this.txtvchno.Name = "txtvchno";
            this.txtvchno.ReadOnly = true;
            this.txtvchno.Size = new System.Drawing.Size(116, 23);
            this.txtvchno.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(498, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Voucher No:";
            // 
            // cmbvouchertype
            // 
            this.cmbvouchertype.FormattingEnabled = true;
            this.cmbvouchertype.Location = new System.Drawing.Point(96, 24);
            this.cmbvouchertype.Name = "cmbvouchertype";
            this.cmbvouchertype.Size = new System.Drawing.Size(180, 24);
            this.cmbvouchertype.TabIndex = 1;
            this.cmbvouchertype.SelectedIndexChanged += new System.EventHandler(this.cmbvouchertype_SelectedIndexChanged);
            this.cmbvouchertype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbvouchertype_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voucher Type:";
            // 
            // txttotalamount
            // 
            this.txttotalamount.Location = new System.Drawing.Point(497, 15);
            this.txttotalamount.Name = "txttotalamount";
            this.txttotalamount.Size = new System.Drawing.Size(110, 20);
            this.txttotalamount.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(409, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "Total Amount:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ListView1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(32, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 247);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // PnlSearch
            // 
            this.PnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlSearch.Controls.Add(this.txtsearch);
            this.PnlSearch.Controls.Add(this.lstmaingroup);
            this.PnlSearch.Controls.Add(this.linkLabel1);
            this.PnlSearch.Location = new System.Drawing.Point(253, 74);
            this.PnlSearch.Name = "PnlSearch";
            this.PnlSearch.Size = new System.Drawing.Size(276, 393);
            this.PnlSearch.TabIndex = 26;
            this.PnlSearch.Visible = false;
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(4, 7);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(266, 20);
            this.txtsearch.TabIndex = 56;
            // 
            // lstmaingroup
            // 
            this.lstmaingroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstmaingroup.FormattingEnabled = true;
            this.lstmaingroup.ItemHeight = 15;
            this.lstmaingroup.Location = new System.Drawing.Point(4, 32);
            this.lstmaingroup.Name = "lstmaingroup";
            this.lstmaingroup.Size = new System.Drawing.Size(266, 289);
            this.lstmaingroup.TabIndex = 55;
            this.lstmaingroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstmaingroup_KeyPress);
            this.lstmaingroup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstmaingroup_MouseDoubleClick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Black;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.Red;
            this.linkLabel1.LinkColor = System.Drawing.Color.Yellow;
            this.linkLabel1.Location = new System.Drawing.Point(115, 326);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(42, 13);
            this.linkLabel1.TabIndex = 54;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Close";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ListView1
            // 
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.ListView1.FullRowSelect = true;
            this.ListView1.GridLines = true;
            this.ListView1.Location = new System.Drawing.Point(54, 14);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(613, 175);
            this.ListView1.TabIndex = 11;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            this.ListView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Account Code";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Particulars";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "DR Amount";
            this.columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "CR Amount";
            this.columnHeader12.Width = 80;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCR);
            this.groupBox3.Controls.Add(this.txttotalamount);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtdr);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(50, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(613, 45);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // txtCR
            // 
            this.txtCR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCR.Location = new System.Drawing.Point(274, 15);
            this.txtCR.Name = "txtCR";
            this.txtCR.Size = new System.Drawing.Size(66, 20);
            this.txtCR.TabIndex = 3;
            this.txtCR.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Credit Amount";
            // 
            // txtdr
            // 
            this.txtdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtdr.Location = new System.Drawing.Point(89, 15);
            this.txtdr.Name = "txtdr";
            this.txtdr.Size = new System.Drawing.Size(66, 20);
            this.txtdr.TabIndex = 1;
            this.txtdr.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Debit Amount";
            // 
            // txtdiffr
            // 
            this.txtdiffr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtdiffr.Location = new System.Drawing.Point(444, 12);
            this.txtdiffr.Name = "txtdiffr";
            this.txtdiffr.Size = new System.Drawing.Size(56, 20);
            this.txtdiffr.TabIndex = 5;
            this.txtdiffr.Text = "0";
            this.txtdiffr.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtamount);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cmbtype);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.btnadd);
            this.groupBox4.Controls.Add(this.txtcheqno);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtparticulars);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtrefno);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtacc_dsc);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtacc_code);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(34, 352);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(701, 189);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Voucher Detail";
            // 
            // txtamount
            // 
            this.txtamount.Location = new System.Drawing.Point(240, 142);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(101, 23);
            this.txtamount.TabIndex = 96;
            this.txtamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtamount_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(240, 124);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 15);
            this.label13.TabIndex = 95;
            this.label13.Text = "Amount:";
            // 
            // cmbtype
            // 
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            "Debit",
            "Credit"});
            this.cmbtype.Location = new System.Drawing.Point(48, 141);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(187, 24);
            this.cmbtype.TabIndex = 94;
            this.cmbtype.Text = "Credit";
            this.cmbtype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbtype_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(50, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 15);
            this.label12.TabIndex = 93;
            this.label12.Text = "Type (Debit/Credit):";
            // 
            // btnadd
            // 
            this.btnadd.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.Image")));
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.Location = new System.Drawing.Point(534, 138);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(59, 27);
            this.btnadd.TabIndex = 91;
            this.btnadd.Text = "Add";
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtcheqno
            // 
            this.txtcheqno.Location = new System.Drawing.Point(346, 142);
            this.txtcheqno.Name = "txtcheqno";
            this.txtcheqno.Size = new System.Drawing.Size(182, 23);
            this.txtcheqno.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(346, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Cheaque No:";
            // 
            // txtparticulars
            // 
            this.txtparticulars.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtparticulars.Location = new System.Drawing.Point(240, 92);
            this.txtparticulars.Name = "txtparticulars";
            this.txtparticulars.Size = new System.Drawing.Size(418, 23);
            this.txtparticulars.TabIndex = 11;
            this.txtparticulars.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtparticulars_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(240, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Particulars";
            // 
            // txtrefno
            // 
            this.txtrefno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtrefno.Location = new System.Drawing.Point(48, 92);
            this.txtrefno.Name = "txtrefno";
            this.txtrefno.Size = new System.Drawing.Size(187, 23);
            this.txtrefno.TabIndex = 9;
            this.txtrefno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtrefno_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(48, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Vr. Ref #";
            // 
            // txtacc_dsc
            // 
            this.txtacc_dsc.Location = new System.Drawing.Point(240, 44);
            this.txtacc_dsc.Name = "txtacc_dsc";
            this.txtacc_dsc.ReadOnly = true;
            this.txtacc_dsc.Size = new System.Drawing.Size(418, 23);
            this.txtacc_dsc.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(240, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Description";
            // 
            // txtacc_code
            // 
            this.txtacc_code.Location = new System.Drawing.Point(48, 44);
            this.txtacc_code.Name = "txtacc_code";
            this.txtacc_code.Size = new System.Drawing.Size(187, 23);
            this.txtacc_code.TabIndex = 5;
            this.txtacc_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtacc_code_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(48, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Account Code";
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(328, 576);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(80, 27);
            this.btnclear.TabIndex = 30;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(247, 576);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 27);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(166, 576);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 27);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(86, 576);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(80, 27);
            this.btnnew.TabIndex = 27;
            this.btnnew.Text = "Add";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(500, 576);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(80, 27);
            this.btnexit.TabIndex = 31;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // FrmVoucherEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 618);
            this.Controls.Add(this.PnlSearch);
            this.Controls.Add(this.txtdiffr);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnnew);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmVoucherEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voucher Entry Form";
            this.Load += new System.EventHandler(this.FrmVoucherEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.PnlSearch.ResumeLayout(false);
            this.PnlSearch.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbvouchertype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtvchno;
        private System.Windows.Forms.DateTimePicker txtvchdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtdr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdiffr;
        private System.Windows.Forms.TextBox txtCR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtacc_code;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtacc_dsc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtparticulars;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtrefno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtcheqno;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel PnlSearch;
        private System.Windows.Forms.ListBox lstmaingroup;
        private System.Windows.Forms.LinkLabel linkLabel1;
        internal System.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.TextBox txttotalamount;
        private System.Windows.Forms.Label label14;
    }
}