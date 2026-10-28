namespace School._forms
{
    partial class Master
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Master));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.popupTask = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TaskAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.PopUpMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Update = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.PopUpNotes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotesAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.NotesUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.NotesDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.NotesRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Read = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.popupTask.SuspendLayout();
            this.PopUpMenu.SuspendLayout();
            this.PopUpNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // popupTask
            // 
            this.popupTask.BackColor = System.Drawing.Color.Gray;
            this.popupTask.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TaskAdd,
            this.TaskUpdate,
            this.TaskDelete,
            this.TaskRefresh});
            this.popupTask.Name = "PopUpMenu";
            this.popupTask.Size = new System.Drawing.Size(131, 92);
            // 
            // TaskAdd
            // 
            this.TaskAdd.ForeColor = System.Drawing.Color.White;
            this.TaskAdd.Name = "TaskAdd";
            this.TaskAdd.Size = new System.Drawing.Size(130, 22);
            this.TaskAdd.Text = "Add New";
            // 
            // TaskUpdate
            // 
            this.TaskUpdate.ForeColor = System.Drawing.Color.White;
            this.TaskUpdate.Name = "TaskUpdate";
            this.TaskUpdate.Size = new System.Drawing.Size(130, 22);
            this.TaskUpdate.Text = "Update";
            // 
            // TaskDelete
            // 
            this.TaskDelete.ForeColor = System.Drawing.Color.White;
            this.TaskDelete.Name = "TaskDelete";
            this.TaskDelete.Size = new System.Drawing.Size(130, 22);
            this.TaskDelete.Text = "Delete";
            // 
            // TaskRefresh
            // 
            this.TaskRefresh.ForeColor = System.Drawing.Color.White;
            this.TaskRefresh.Name = "TaskRefresh";
            this.TaskRefresh.Size = new System.Drawing.Size(130, 22);
            this.TaskRefresh.Text = "Refresh";
            // 
            // PopUpMenu
            // 
            this.PopUpMenu.BackColor = System.Drawing.Color.Gray;
            this.PopUpMenu.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PopUpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Add,
            this.Update,
            this.Delete,
            this.Refresh});
            this.PopUpMenu.Name = "PopUpMenu";
            this.PopUpMenu.Size = new System.Drawing.Size(131, 92);
            // 
            // Add
            // 
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(130, 22);
            this.Add.Text = "Add New";
            // 
            // Update
            // 
            this.Update.ForeColor = System.Drawing.Color.White;
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(130, 22);
            this.Update.Text = "Update";
            // 
            // Delete
            // 
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(130, 22);
            this.Delete.Text = "Delete";
            // 
            // Refresh
            // 
            this.Refresh.ForeColor = System.Drawing.Color.White;
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(130, 22);
            this.Refresh.Text = "Refresh";
            // 
            // PopUpNotes
            // 
            this.PopUpNotes.BackColor = System.Drawing.Color.Gray;
            this.PopUpNotes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PopUpNotes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotesAdd,
            this.NotesUpdate,
            this.NotesDelete,
            this.NotesRefresh});
            this.PopUpNotes.Name = "PopUpMenu";
            this.PopUpNotes.Size = new System.Drawing.Size(131, 92);
            // 
            // NotesAdd
            // 
            this.NotesAdd.ForeColor = System.Drawing.Color.White;
            this.NotesAdd.Name = "NotesAdd";
            this.NotesAdd.Size = new System.Drawing.Size(130, 22);
            this.NotesAdd.Text = "Add New";
            // 
            // NotesUpdate
            // 
            this.NotesUpdate.ForeColor = System.Drawing.Color.White;
            this.NotesUpdate.Name = "NotesUpdate";
            this.NotesUpdate.Size = new System.Drawing.Size(130, 22);
            this.NotesUpdate.Text = "Update";
            // 
            // NotesDelete
            // 
            this.NotesDelete.ForeColor = System.Drawing.Color.White;
            this.NotesDelete.Name = "NotesDelete";
            this.NotesDelete.Size = new System.Drawing.Size(130, 22);
            this.NotesDelete.Text = "Delete";
            // 
            // NotesRefresh
            // 
            this.NotesRefresh.ForeColor = System.Drawing.Color.White;
            this.NotesRefresh.Name = "NotesRefresh";
            this.NotesRefresh.Size = new System.Drawing.Size(130, 22);
            this.NotesRefresh.Text = "Refresh";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // To
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.To.DefaultCellStyle = dataGridViewCellStyle1;
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.Visible = false;
            // 
            // From
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.From.DefaultCellStyle = dataGridViewCellStyle2;
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.Width = 345;
            // 
            // Cc
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Cc.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cc.HeaderText = "Cc";
            this.Cc.Name = "Cc";
            this.Cc.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "Subject";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 344;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.Date.DefaultCellStyle = dataGridViewCellStyle5;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "t";
            dataGridViewCellStyle6.NullValue = null;
            this.Time.DefaultCellStyle = dataGridViewCellStyle6;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // Size
            // 
            this.Size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.Size.DefaultCellStyle = dataGridViewCellStyle7;
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            // 
            // Folder
            // 
            this.Folder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Folder.DefaultCellStyle = dataGridViewCellStyle8;
            this.Folder.HeaderText = "Folder";
            this.Folder.Name = "Folder";
            this.Folder.Visible = false;
            // 
            // Read
            // 
            this.Read.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Read.DefaultCellStyle = dataGridViewCellStyle9;
            this.Read.HeaderText = "Read";
            this.Read.Name = "Read";
            // 
            // Priority
            // 
            this.Priority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Priority.DefaultCellStyle = dataGridViewCellStyle10;
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            // 
            // Days
            // 
            this.Days.HeaderText = "Days";
            this.Days.Name = "Days";
            this.Days.Visible = false;
            // 
            // statusBar1
            // 
            this.statusBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.statusBar1.Location = new System.Drawing.Point(0, 431);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(942, 22);
            this.statusBar1.TabIndex = 5;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel1.Icon")));
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "Username: ";
            this.statusBarPanel1.Width = 300;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel2.Icon = ((System.Drawing.Icon)(resources.GetObject("statusBarPanel2.Icon")));
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "Time Log-in: ";
            this.statusBarPanel2.Width = 625;
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(942, 453);
            this.ControlBox = false;
            this.Controls.Add(this.statusBar1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Management System ver 1.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Master_Load);
            this.popupTask.ResumeLayout(false);
            this.PopUpMenu.ResumeLayout(false);
            this.PopUpNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip PopUpMenu;
        private System.Windows.Forms.ToolStripMenuItem Add;
        private System.Windows.Forms.ToolStripMenuItem Update;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripMenuItem Refresh;
        private System.Windows.Forms.ContextMenuStrip popupTask;
        private System.Windows.Forms.ToolStripMenuItem TaskAdd;
        private System.Windows.Forms.ToolStripMenuItem TaskUpdate;
        private System.Windows.Forms.ToolStripMenuItem TaskDelete;
        private System.Windows.Forms.ToolStripMenuItem TaskRefresh;
        private System.Windows.Forms.ContextMenuStrip PopUpNotes;
        private System.Windows.Forms.ToolStripMenuItem NotesAdd;
        private System.Windows.Forms.ToolStripMenuItem NotesUpdate;
        private System.Windows.Forms.ToolStripMenuItem NotesDelete;
        private System.Windows.Forms.ToolStripMenuItem NotesRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Read;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Days;
        public System.Windows.Forms.StatusBar statusBar1;
        public System.Windows.Forms.StatusBarPanel statusBarPanel1;
        public System.Windows.Forms.StatusBarPanel statusBarPanel2;
    }
}



