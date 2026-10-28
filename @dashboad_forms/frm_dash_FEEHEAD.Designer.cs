namespace School._dashboad_forms
{
    partial class frm_dash_FEEHEAD
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fEEHEADBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dashboard = new School.Dashboard();
            this.sectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sectionsTableAdapter = new School.DashboardTableAdapters.SectionsTableAdapter();
            this.fEE_HEADTableAdapter = new School.DashboardTableAdapters.FEE_HEADTableAdapter();
            this.feeheadidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeheadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fEEHEADBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.feeheadidDataGridViewTextBoxColumn,
            this.feeheadDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fEEHEADBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(484, 429);
            this.dataGridView1.TabIndex = 1;
            // 
            // fEEHEADBindingSource
            // 
            this.fEEHEADBindingSource.DataMember = "FEE_HEAD";
            this.fEEHEADBindingSource.DataSource = this.dashboard;
            // 
            // dashboard
            // 
            this.dashboard.DataSetName = "Dashboard";
            this.dashboard.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sectionsBindingSource
            // 
            this.sectionsBindingSource.DataMember = "Sections";
            this.sectionsBindingSource.DataSource = this.dashboard;
            // 
            // sectionsTableAdapter
            // 
            this.sectionsTableAdapter.ClearBeforeFill = true;
            // 
            // fEE_HEADTableAdapter
            // 
            this.fEE_HEADTableAdapter.ClearBeforeFill = true;
            // 
            // feeheadidDataGridViewTextBoxColumn
            // 
            this.feeheadidDataGridViewTextBoxColumn.DataPropertyName = "Fee_head_id";
            this.feeheadidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.feeheadidDataGridViewTextBoxColumn.Name = "feeheadidDataGridViewTextBoxColumn";
            this.feeheadidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // feeheadDataGridViewTextBoxColumn
            // 
            this.feeheadDataGridViewTextBoxColumn.DataPropertyName = "Fee_head";
            this.feeheadDataGridViewTextBoxColumn.HeaderText = "Fee Head";
            this.feeheadDataGridViewTextBoxColumn.Name = "feeheadDataGridViewTextBoxColumn";
            this.feeheadDataGridViewTextBoxColumn.ReadOnly = true;
            this.feeheadDataGridViewTextBoxColumn.Width = 200;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frm_dash_FEEHEAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 429);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_dash_FEEHEAD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Head";
            this.Load += new System.EventHandler(this.frm_dash_sections_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fEEHEADBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource sectionsBindingSource;
        private Dashboard dashboard;
        private DashboardTableAdapters.SectionsTableAdapter sectionsTableAdapter;
        private System.Windows.Forms.BindingSource fEEHEADBindingSource;
        private DashboardTableAdapters.FEE_HEADTableAdapter fEE_HEADTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeheadidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeheadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
    }
}