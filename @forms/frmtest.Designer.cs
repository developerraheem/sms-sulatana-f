namespace School._forms
{
    partial class frmtest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtest));
            this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet();
            this.fee_ClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fee_ClassTableAdapter = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.Fee_ClassTableAdapter();
            this.tableAdapterManager = new School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.TableAdapterManager();
            this.fee_ClassBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.fee_ClassBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.c_IDToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.c_IDToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fee_ClassDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fee_ClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fee_ClassBindingNavigator)).BeginInit();
            this.fee_ClassBindingNavigator.SuspendLayout();
            this.fillToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fee_ClassDataGridView)).BeginInit();
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
            this.tableAdapterManager.Fee_ClassTableAdapter = this.fee_ClassTableAdapter;
            this.tableAdapterManager.Fee_HeadTableAdapter = null;
            this.tableAdapterManager.Mark_AttndTableAdapter = null;
            this.tableAdapterManager.studentTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = School._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // fee_ClassBindingNavigator
            // 
            this.fee_ClassBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.fee_ClassBindingNavigator.BindingSource = this.fee_ClassBindingSource;
            this.fee_ClassBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.fee_ClassBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.fee_ClassBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.fee_ClassBindingNavigatorSaveItem});
            this.fee_ClassBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.fee_ClassBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.fee_ClassBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.fee_ClassBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.fee_ClassBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.fee_ClassBindingNavigator.Name = "fee_ClassBindingNavigator";
            this.fee_ClassBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.fee_ClassBindingNavigator.Size = new System.Drawing.Size(1088, 25);
            this.fee_ClassBindingNavigator.TabIndex = 0;
            this.fee_ClassBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 15);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // fee_ClassBindingNavigatorSaveItem
            // 
            this.fee_ClassBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fee_ClassBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("fee_ClassBindingNavigatorSaveItem.Image")));
            this.fee_ClassBindingNavigatorSaveItem.Name = "fee_ClassBindingNavigatorSaveItem";
            this.fee_ClassBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 20);
            this.fee_ClassBindingNavigatorSaveItem.Text = "Save Data";
            this.fee_ClassBindingNavigatorSaveItem.Click += new System.EventHandler(this.fee_ClassBindingNavigatorSaveItem_Click);
            // 
            // fillToolStrip
            // 
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.c_IDToolStripLabel,
            this.c_IDToolStripTextBox,
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(0, 25);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(1088, 25);
            this.fillToolStrip.TabIndex = 1;
            this.fillToolStrip.Text = "fillToolStrip";
            // 
            // c_IDToolStripLabel
            // 
            this.c_IDToolStripLabel.Name = "c_IDToolStripLabel";
            this.c_IDToolStripLabel.Size = new System.Drawing.Size(34, 22);
            this.c_IDToolStripLabel.Text = "C_ID:";
            // 
            // c_IDToolStripTextBox
            // 
            this.c_IDToolStripTextBox.Name = "c_IDToolStripTextBox";
            this.c_IDToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // fillToolStripButton
            // 
            this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillToolStripButton.Name = "fillToolStripButton";
            this.fillToolStripButton.Size = new System.Drawing.Size(26, 19);
            this.fillToolStripButton.Text = "Fill";
            this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripButton_Click);
            // 
            // fee_ClassDataGridView
            // 
            this.fee_ClassDataGridView.AutoGenerateColumns = false;
            this.fee_ClassDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fee_ClassDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewCheckBoxColumn1});
            this.fee_ClassDataGridView.DataSource = this.fee_ClassBindingSource;
            this.fee_ClassDataGridView.Location = new System.Drawing.Point(81, 115);
            this.fee_ClassDataGridView.Name = "fee_ClassDataGridView";
            this.fee_ClassDataGridView.Size = new System.Drawing.Size(563, 220);
            this.fee_ClassDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FEE_CLASS_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "FEE_CLASS_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Fee_head_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "Fee_head_id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "C_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "C_ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "AMOUNT";
            this.dataGridViewTextBoxColumn4.HeaderText = "AMOUNT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "ACTIVE";
            this.dataGridViewCheckBoxColumn1.HeaderText = "ACTIVE";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // frmtest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 562);
            this.Controls.Add(this.fee_ClassDataGridView);
            this.Controls.Add(this.fillToolStrip);
            this.Controls.Add(this.fee_ClassBindingNavigator);
            this.Name = "frmtest";
            this.Text = "frmtest";
            this.Load += new System.EventHandler(this.frmtest_Load);
            ((System.ComponentModel.ISupportInitialize)(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fee_ClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fee_ClassBindingNavigator)).EndInit();
            this.fee_ClassBindingNavigator.ResumeLayout(false);
            this.fee_ClassBindingNavigator.PerformLayout();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fee_ClassDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet;
        private System.Windows.Forms.BindingSource fee_ClassBindingSource;
        private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.Fee_ClassTableAdapter fee_ClassTableAdapter;
        private _C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator fee_ClassBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton fee_ClassBindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStrip fillToolStrip;
        private System.Windows.Forms.ToolStripLabel c_IDToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox c_IDToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        private System.Windows.Forms.DataGridView fee_ClassDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;




    }
}