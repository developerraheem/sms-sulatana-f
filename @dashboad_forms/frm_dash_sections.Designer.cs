namespace School._dashboad_forms
{
    partial class frm_dash_sections
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
            this.sECTIONNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dashboard = new School.Dashboard();
            this.sectionsTableAdapter = new School.DashboardTableAdapters.SectionsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboard)).BeginInit();
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
            this.sECTIONNAMEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sectionsBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(431, 429);
            this.dataGridView1.TabIndex = 1;
            // 
            // sECTIONNAMEDataGridViewTextBoxColumn
            // 
            this.sECTIONNAMEDataGridViewTextBoxColumn.DataPropertyName = "SECTION_NAME";
            this.sECTIONNAMEDataGridViewTextBoxColumn.HeaderText = "Section Name";
            this.sECTIONNAMEDataGridViewTextBoxColumn.Name = "sECTIONNAMEDataGridViewTextBoxColumn";
            this.sECTIONNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.sECTIONNAMEDataGridViewTextBoxColumn.Width = 300;
            // 
            // sectionsBindingSource
            // 
            this.sectionsBindingSource.DataMember = "Sections";
            this.sectionsBindingSource.DataSource = this.dashboard;
            // 
            // dashboard
            // 
            this.dashboard.DataSetName = "Dashboard";
            this.dashboard.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sectionsTableAdapter
            // 
            this.sectionsTableAdapter.ClearBeforeFill = true;
            // 
            // frm_dash_sections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 429);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_dash_sections";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sections";
            this.Load += new System.EventHandler(this.frm_dash_sections_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sECTIONNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sectionsBindingSource;
        private Dashboard dashboard;
        private DashboardTableAdapters.SectionsTableAdapter sectionsTableAdapter;
    }
}