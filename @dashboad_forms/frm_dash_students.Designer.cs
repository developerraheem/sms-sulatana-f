namespace School._dashboad_forms
{
    partial class frm_dash_students
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
            this.txtstdname = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDMISSIONNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewStudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dashboard = new School.Dashboard();
            this.view_StudentTableAdapter = new School.DashboardTableAdapters.view_StudentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStudentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboard)).BeginInit();
            this.SuspendLayout();
            // 
            // txtstdname
            // 
            this.txtstdname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstdname.Location = new System.Drawing.Point(8, 9);
            this.txtstdname.Name = "txtstdname";
            this.txtstdname.Size = new System.Drawing.Size(703, 29);
            this.txtstdname.TabIndex = 0;
            this.txtstdname.TextChanged += new System.EventHandler(this.txtstdname_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.cnameDataGridViewTextBoxColumn,
            this.sidDataGridViewTextBoxColumn,
            this.snameDataGridViewTextBoxColumn,
            this.fnameDataGridViewTextBoxColumn,
            this.sexDataGridViewTextBoxColumn,
            this.aDMISSIONNODataGridViewTextBoxColumn,
            this.contactnoDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.viewStudentBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(8, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(703, 478);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "View Profile";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Text = "View Profile";
            this.Column1.ToolTipText = "Click here to view student profile";
            this.Column1.UseColumnTextForButtonValue = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "c_name";
            this.Column2.HeaderText = "View  Ledger";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Text = "Ledger";
            this.Column2.ToolTipText = "Click here to view student ledger";
            this.Column2.UseColumnTextForButtonValue = true;
            // 
            // cnameDataGridViewTextBoxColumn
            // 
            this.cnameDataGridViewTextBoxColumn.DataPropertyName = "c_name";
            this.cnameDataGridViewTextBoxColumn.HeaderText = "Class";
            this.cnameDataGridViewTextBoxColumn.Name = "cnameDataGridViewTextBoxColumn";
            this.cnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sidDataGridViewTextBoxColumn
            // 
            this.sidDataGridViewTextBoxColumn.DataPropertyName = "s_id";
            this.sidDataGridViewTextBoxColumn.HeaderText = "Std ID";
            this.sidDataGridViewTextBoxColumn.Name = "sidDataGridViewTextBoxColumn";
            this.sidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // snameDataGridViewTextBoxColumn
            // 
            this.snameDataGridViewTextBoxColumn.DataPropertyName = "s_name";
            this.snameDataGridViewTextBoxColumn.HeaderText = "Student Name";
            this.snameDataGridViewTextBoxColumn.Name = "snameDataGridViewTextBoxColumn";
            this.snameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fnameDataGridViewTextBoxColumn
            // 
            this.fnameDataGridViewTextBoxColumn.DataPropertyName = "f_name";
            this.fnameDataGridViewTextBoxColumn.HeaderText = "Father Name";
            this.fnameDataGridViewTextBoxColumn.Name = "fnameDataGridViewTextBoxColumn";
            this.fnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sexDataGridViewTextBoxColumn
            // 
            this.sexDataGridViewTextBoxColumn.DataPropertyName = "sex";
            this.sexDataGridViewTextBoxColumn.HeaderText = "Gender";
            this.sexDataGridViewTextBoxColumn.Name = "sexDataGridViewTextBoxColumn";
            this.sexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aDMISSIONNODataGridViewTextBoxColumn
            // 
            this.aDMISSIONNODataGridViewTextBoxColumn.DataPropertyName = "ADMISSION_NO";
            this.aDMISSIONNODataGridViewTextBoxColumn.HeaderText = "Admission No";
            this.aDMISSIONNODataGridViewTextBoxColumn.Name = "aDMISSIONNODataGridViewTextBoxColumn";
            this.aDMISSIONNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contactnoDataGridViewTextBoxColumn
            // 
            this.contactnoDataGridViewTextBoxColumn.DataPropertyName = "contact_no";
            this.contactnoDataGridViewTextBoxColumn.HeaderText = "Contact No";
            this.contactnoDataGridViewTextBoxColumn.Name = "contactnoDataGridViewTextBoxColumn";
            this.contactnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // viewStudentBindingSource
            // 
            this.viewStudentBindingSource.DataMember = "view_Student";
            this.viewStudentBindingSource.DataSource = this.dashboard;
            // 
            // dashboard
            // 
            this.dashboard.DataSetName = "Dashboard";
            this.dashboard.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view_StudentTableAdapter
            // 
            this.view_StudentTableAdapter.ClearBeforeFill = true;
            // 
            // frm_dash_students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(718, 529);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtstdname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_dash_students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Students";
            this.Load += new System.EventHandler(this.frm_dash_students_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewStudentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtstdname;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource viewStudentBindingSource;
        private Dashboard dashboard;
        private DashboardTableAdapters.view_StudentTableAdapter view_StudentTableAdapter;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDMISSIONNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
    }
}