namespace School._forms
{
    partial class FrmMark_attnd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dpAe = new System.Windows.Forms.DateTimePicker();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnclose = new Glass.GlassButton();
            this.btnrefresh = new Glass.GlassButton();
            this.glassButton1 = new Glass.GlassButton();
            this.btnSave = new Glass.GlassButton();
            this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet();
            this.mark_AttndBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mark_AttndTableAdapter = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.Mark_AttndTableAdapter();
            this.tableAdapterManager = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.TableAdapterManager();
            this.mark_AttndDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aTTNDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aTTNDTableAdapter = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.ATTNDTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mark_AttndBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mark_AttndDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTTNDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.dpAe);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 205);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Date";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(29, 118);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(349, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Please Select Class";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dpAe
            // 
            this.dpAe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpAe.Location = new System.Drawing.Point(29, 73);
            this.dpAe.Name = "dpAe";
            this.dpAe.Size = new System.Drawing.Size(97, 20);
            this.dpAe.TabIndex = 11;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(162, 33);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(80, 20);
            this.txtTime.TabIndex = 1;
            this.txtTime.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select Class";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnclose);
            this.groupBox2.Controls.Add(this.btnrefresh);
            this.groupBox2.Controls.Add(this.glassButton1);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(31, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 67);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            // 
            // btnclose
            // 
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(271, 23);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(65, 30);
            this.btnclose.TabIndex = 24;
            this.btnclose.Text = "Close";
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnrefresh
            // 
            this.btnrefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefresh.Location = new System.Drawing.Point(198, 23);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(65, 30);
            this.btnrefresh.TabIndex = 21;
            this.btnrefresh.Text = "Print";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // glassButton1
            // 
            this.glassButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.glassButton1.Location = new System.Drawing.Point(127, 23);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.Size = new System.Drawing.Size(65, 30);
            this.glassButton1.TabIndex = 19;
            this.glassButton1.Text = "Update";
            this.glassButton1.Click += new System.EventHandler(this.glassButton1_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(10, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 30);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Mark Attandence";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet
            // 
            this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.DataSetName = "_C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet" +
                "";
            this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mark_AttndBindingSource
            // 
            this.mark_AttndBindingSource.DataMember = "Mark_Attnd";
            this.mark_AttndBindingSource.DataSource = this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet;
            // 
            // mark_AttndTableAdapter
            // 
            this.mark_AttndTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.ATTNDTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.classTableAdapter = null;
            this.tableAdapterManager.Fee_Class_EntryTableAdapter = null;
            this.tableAdapterManager.Fee_ClassTableAdapter = null;
            this.tableAdapterManager.FEE_DETAILTableAdapter = null;
            this.tableAdapterManager.Fee_HeadTableAdapter = null;
            this.tableAdapterManager.FEE_MASTERTableAdapter = null;
            this.tableAdapterManager.Mark_AttndTableAdapter = this.mark_AttndTableAdapter;
            this.tableAdapterManager.studentTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // mark_AttndDataGridView
            // 
            this.mark_AttndDataGridView.AllowUserToAddRows = false;
            this.mark_AttndDataGridView.AllowUserToDeleteRows = false;
            this.mark_AttndDataGridView.AutoGenerateColumns = false;
            this.mark_AttndDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mark_AttndDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.mark_AttndDataGridView.DataSource = this.mark_AttndBindingSource;
            this.mark_AttndDataGridView.Location = new System.Drawing.Point(427, 38);
            this.mark_AttndDataGridView.Name = "mark_AttndDataGridView";
            this.mark_AttndDataGridView.Size = new System.Drawing.Size(451, 404);
            this.mark_AttndDataGridView.TabIndex = 51;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ADMISSION_NO";
            this.dataGridViewTextBoxColumn7.HeaderText = "Admission No";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "s_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "s_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "att_date";
            this.dataGridViewTextBoxColumn2.HeaderText = "Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "c_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "c_id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "att_status";
            this.dataGridViewTextBoxColumn4.DataSource = this.aTTNDBindingSource;
            this.dataGridViewTextBoxColumn4.DisplayMember = "description";
            this.dataGridViewTextBoxColumn4.HeaderText = "Status";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn4.ValueMember = "ID";
            // 
            // aTTNDBindingSource
            // 
            this.aTTNDBindingSource.DataMember = "ATTND";
            this.aTTNDBindingSource.DataSource = this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "att_time";
            this.dataGridViewTextBoxColumn5.HeaderText = "Time";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "remarks";
            this.dataGridViewTextBoxColumn6.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // aTTNDTableAdapter
            // 
            this.aTTNDTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.label3.Font = new System.Drawing.Font("Calibri", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(7, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 27);
            this.label3.TabIndex = 52;
            this.label3.Text = "Student Attendance Form";
            // 
            // FrmMark_attnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(891, 454);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mark_AttndDataGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmMark_attnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attandance Management";
            this.Load += new System.EventHandler(this.FrmMark_attnd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mark_AttndBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mark_AttndDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTTNDBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dpAe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private Glass.GlassButton btnclose;
        private Glass.GlassButton btnrefresh;
        private Glass.GlassButton glassButton1;
        private Glass.GlassButton btnSave;
     //   private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet;
        private System.Windows.Forms.BindingSource mark_AttndBindingSource;
      //  private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.Mark_AttndTableAdapter mark_AttndTableAdapter;
      //  private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView mark_AttndDataGridView;
        private System.Windows.Forms.BindingSource aTTNDBindingSource;
       // private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.ATTNDTableAdapter aTTNDTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label3;
    }
}