namespace School._forms
{
    partial class FrmFeeClass
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
            this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet();
            this.fee_ClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fee_ClassTableAdapter = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.Fee_ClassTableAdapter();
            this.tableAdapterManager = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.TableAdapterManager();
            this.feeHeadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fee_Class_EntryDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fee_Class_EntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.fee_HeadTableAdapter = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.Fee_HeadTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtfeeclassid = new System.Windows.Forms.TextBox();
            this.cmbfeehead = new System.Windows.Forms.ComboBox();
            this.feeHeadBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fee_Class_EntryTableAdapter = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.Fee_Class_EntryTableAdapter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnclose = new Glass.GlassButton();
            this.btnCancel = new Glass.GlassButton();
            this.btnDel = new Glass.GlassButton();
            this.btnUpdate = new Glass.GlassButton();
            this.btnSave = new Glass.GlassButton();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fee_ClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeHeadBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fee_Class_EntryDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fee_Class_EntryBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feeHeadBindingSource1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet
            // 
            this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.DataSetName = "_C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet" +
                "";
            this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fee_ClassBindingSource
            // 
            this.fee_ClassBindingSource.DataMember = "Fee_Class";
            this.fee_ClassBindingSource.DataSource = this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet;
            // 
            // fee_ClassTableAdapter
            // 
            this.fee_ClassTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ATTNDTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.classTableAdapter = null;
            this.tableAdapterManager.Fee_Class_EntryTableAdapter = null;
            this.tableAdapterManager.Fee_ClassTableAdapter = this.fee_ClassTableAdapter;
            this.tableAdapterManager.FEE_DETAILTableAdapter = null;
            this.tableAdapterManager.Fee_HeadTableAdapter = null;
            this.tableAdapterManager.FEE_MASTERTableAdapter = null;
            this.tableAdapterManager.Mark_AttndTableAdapter = null;
            this.tableAdapterManager.studentTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // feeHeadBindingSource
            // 
            this.feeHeadBindingSource.DataMember = "Fee_Head";
            this.feeHeadBindingSource.DataSource = this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.fee_Class_EntryDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(428, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 388);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // fee_Class_EntryDataGridView
            // 
            this.fee_Class_EntryDataGridView.AllowUserToAddRows = false;
            this.fee_Class_EntryDataGridView.AllowUserToDeleteRows = false;
            this.fee_Class_EntryDataGridView.AutoGenerateColumns = false;
            this.fee_Class_EntryDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.fee_Class_EntryDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fee_Class_EntryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fee_Class_EntryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn1});
            this.fee_Class_EntryDataGridView.DataSource = this.fee_Class_EntryBindingSource;
            this.fee_Class_EntryDataGridView.Location = new System.Drawing.Point(6, 17);
            this.fee_Class_EntryDataGridView.Name = "fee_Class_EntryDataGridView";
            this.fee_Class_EntryDataGridView.ReadOnly = true;
            this.fee_Class_EntryDataGridView.Size = new System.Drawing.Size(497, 365);
            this.fee_Class_EntryDataGridView.TabIndex = 0;
            this.fee_Class_EntryDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fee_Class_EntryDataGridView_CellClick);
            this.fee_Class_EntryDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fee_Class_EntryDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FEE_CLASS_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Fee_head";
            this.dataGridViewTextBoxColumn2.HeaderText = "Fee Head";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "AMOUNT";
            this.dataGridViewTextBoxColumn1.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "ACTIVE";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Active";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // fee_Class_EntryBindingSource
            // 
            this.fee_Class_EntryBindingSource.DataMember = "Fee_Class_Entry";
            this.fee_Class_EntryBindingSource.DataSource = this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet;
            // 
            // cmbclass
            // 
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Location = new System.Drawing.Point(137, 53);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(266, 21);
            this.cmbclass.TabIndex = 0;
            this.cmbclass.SelectedIndexChanged += new System.EventHandler(this.cmbclass_SelectedIndexChanged);
            // 
            // fee_HeadTableAdapter
            // 
            this.fee_HeadTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtfeeclassid);
            this.groupBox2.Controls.Add(this.cmbclass);
            this.groupBox2.Controls.Add(this.cmbfeehead);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtamount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(4, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 248);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Records Entry";
            // 
            // txtfeeclassid
            // 
            this.txtfeeclassid.Location = new System.Drawing.Point(137, 151);
            this.txtfeeclassid.Name = "txtfeeclassid";
            this.txtfeeclassid.Size = new System.Drawing.Size(100, 20);
            this.txtfeeclassid.TabIndex = 7;
            this.txtfeeclassid.Visible = false;
            // 
            // cmbfeehead
            // 
            this.cmbfeehead.DataSource = this.feeHeadBindingSource1;
            this.cmbfeehead.DisplayMember = "Fee_head";
            this.cmbfeehead.FormattingEnabled = true;
            this.cmbfeehead.Location = new System.Drawing.Point(137, 91);
            this.cmbfeehead.Name = "cmbfeehead";
            this.cmbfeehead.Size = new System.Drawing.Size(266, 21);
            this.cmbfeehead.TabIndex = 1;
            this.cmbfeehead.ValueMember = "Fee_head_id";
            // 
            // feeHeadBindingSource1
            // 
            this.feeHeadBindingSource1.DataMember = "Fee_Head";
            this.feeHeadBindingSource1.DataSource = this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fee Head Amount";
            // 
            // txtamount
            // 
            this.txtamount.Location = new System.Drawing.Point(137, 125);
            this.txtamount.Name = "txtamount";
            this.txtamount.Size = new System.Drawing.Size(139, 20);
            this.txtamount.TabIndex = 2;
            this.txtamount.Text = "0";
            this.txtamount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtamount_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Fee Head";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-10, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Select Class";
            // 
            // fee_Class_EntryTableAdapter
            // 
            this.fee_Class_EntryTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnclose);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnDel);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(4, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(410, 67);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // btnclose
            // 
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(317, 25);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(65, 30);
            this.btnclose.TabIndex = 24;
            this.btnclose.Text = "Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(246, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 30);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDel
            // 
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(175, 25);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(65, 30);
            this.btnDel.TabIndex = 22;
            this.btnDel.Text = "Delete";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(99, 25);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(65, 30);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(28, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 30);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.label3.Font = new System.Drawing.Font("Calibri", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 27);
            this.label3.TabIndex = 21;
            this.label3.Text = "Class Wise Fee Setup";
            // 
            // FrmFeeClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(947, 448);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmFeeClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class Fee Entry";
            this.Load += new System.EventHandler(this.FrmFeeClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fee_ClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeHeadBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fee_Class_EntryDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fee_Class_EntryBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feeHeadBindingSource1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet;
        private System.Windows.Forms.BindingSource fee_ClassBindingSource;
        private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.Fee_ClassTableAdapter fee_ClassTableAdapter;
        private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.BindingSource feeHeadBindingSource;
        private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.Fee_HeadTableAdapter fee_HeadTableAdapter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbfeehead;
        private System.Windows.Forms.BindingSource feeHeadBindingSource1;
        private System.Windows.Forms.BindingSource fee_Class_EntryBindingSource;
        private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.Fee_Class_EntryTableAdapter fee_Class_EntryTableAdapter;
        private System.Windows.Forms.DataGridView fee_Class_EntryDataGridView;
        private System.Windows.Forms.TextBox txtfeeclassid;
        private System.Windows.Forms.GroupBox groupBox3;
        private Glass.GlassButton btnclose;
        private Glass.GlassButton btnCancel;
        private Glass.GlassButton btnDel;
        private Glass.GlassButton btnUpdate;
        private Glass.GlassButton btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.Label label3;

    }
}