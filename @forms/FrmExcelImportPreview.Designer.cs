namespace School._forms
{
    partial class FrmExcelImportPreview
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.panelTopConfig = new System.Windows.Forms.Panel();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblFeeMonth = new System.Windows.Forms.Label();
            this.dtpFeeMonth = new System.Windows.Forms.DateTimePicker();
            this.lblFeeHead = new System.Windows.Forms.Label();
            this.cmbFeeHead = new System.Windows.Forms.ComboBox();
            this.panelSummaryCards = new System.Windows.Forms.Panel();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblValidCount = new System.Windows.Forms.Label();
            this.lblInvalidCount = new System.Windows.Forms.Label();
            this.lblDuplicateCount = new System.Windows.Forms.Label();
            this.chkShowErrorsOnly = new System.Windows.Forms.CheckBox();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.colRowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeeMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFeeHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnConfirm = new Glass.GlassButton();
            this.btnExportErrors = new Glass.GlassButton();
            this.btnCancel = new Glass.GlassButton();
            this.panelHeader.SuspendLayout();
            this.panelTopConfig.SuspendLayout();
            this.panelSummaryCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Controls.Add(this.lblHeaderSub);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1020, 56);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(18, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(270, 31);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Excel Import Preview";
            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(300, 20);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(430, 20);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Review student fee heads, fines, and concessions before importing into database";
            // 
            // panelTopConfig
            // 
            this.panelTopConfig.BackColor = System.Drawing.Color.White;
            this.panelTopConfig.Controls.Add(this.lblFile);
            this.panelTopConfig.Controls.Add(this.lblFeeMonth);
            this.panelTopConfig.Controls.Add(this.dtpFeeMonth);
            this.panelTopConfig.Controls.Add(this.lblFeeHead);
            this.panelTopConfig.Controls.Add(this.cmbFeeHead);
            this.panelTopConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopConfig.Location = new System.Drawing.Point(0, 56);
            this.panelTopConfig.Name = "panelTopConfig";
            this.panelTopConfig.Size = new System.Drawing.Size(1020, 50);
            this.panelTopConfig.TabIndex = 1;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFile.Location = new System.Drawing.Point(620, 15);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(70, 20);
            this.lblFile.TabIndex = 4;
            this.lblFile.Text = "File: None";
            // 
            // lblFeeMonth
            // 
            this.lblFeeMonth.AutoSize = true;
            this.lblFeeMonth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFeeMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblFeeMonth.Location = new System.Drawing.Point(18, 15);
            this.lblFeeMonth.Name = "lblFeeMonth";
            this.lblFeeMonth.Size = new System.Drawing.Size(83, 20);
            this.lblFeeMonth.TabIndex = 0;
            this.lblFeeMonth.Text = "Default Month";
            // 
            // dtpFeeMonth
            // 
            this.dtpFeeMonth.CustomFormat = "MM yyyy";
            this.dtpFeeMonth.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFeeMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFeeMonth.Location = new System.Drawing.Point(115, 11);
            this.dtpFeeMonth.Name = "dtpFeeMonth";
            this.dtpFeeMonth.Size = new System.Drawing.Size(125, 29);
            this.dtpFeeMonth.TabIndex = 1;
            this.dtpFeeMonth.ValueChanged += new System.EventHandler(this.dtpFeeMonth_ValueChanged);
            // 
            // lblFeeHead
            // 
            this.lblFeeHead.AutoSize = true;
            this.lblFeeHead.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFeeHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblFeeHead.Location = new System.Drawing.Point(255, 15);
            this.lblFeeHead.Name = "lblFeeHead";
            this.lblFeeHead.Size = new System.Drawing.Size(130, 20);
            this.lblFeeHead.TabIndex = 2;
            this.lblFeeHead.Text = "Default Fee Head";
            // 
            // cmbFeeHead
            // 
            this.cmbFeeHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFeeHead.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFeeHead.FormattingEnabled = true;
            this.cmbFeeHead.Location = new System.Drawing.Point(425, 11);
            this.cmbFeeHead.Name = "cmbFeeHead";
            this.cmbFeeHead.Size = new System.Drawing.Size(180, 29);
            this.cmbFeeHead.TabIndex = 3;
            this.cmbFeeHead.SelectedIndexChanged += new System.EventHandler(this.cmbFeeHead_SelectedIndexChanged);
            // 
            // panelSummaryCards
            // 
            this.panelSummaryCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.panelSummaryCards.Controls.Add(this.lblTotalCount);
            this.panelSummaryCards.Controls.Add(this.lblValidCount);
            this.panelSummaryCards.Controls.Add(this.lblInvalidCount);
            this.panelSummaryCards.Controls.Add(this.lblDuplicateCount);
            this.panelSummaryCards.Controls.Add(this.chkShowErrorsOnly);
            this.panelSummaryCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummaryCards.Location = new System.Drawing.Point(0, 106);
            this.panelSummaryCards.Name = "panelSummaryCards";
            this.panelSummaryCards.Size = new System.Drawing.Size(1020, 44);
            this.panelSummaryCards.TabIndex = 2;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblTotalCount.Location = new System.Drawing.Point(18, 12);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(104, 21);
            this.lblTotalCount.TabIndex = 0;
            this.lblTotalCount.Text = "Total Rows: 0";
            // 
            // lblValidCount
            // 
            this.lblValidCount.AutoSize = true;
            this.lblValidCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblValidCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.lblValidCount.Location = new System.Drawing.Point(160, 12);
            this.lblValidCount.Name = "lblValidCount";
            this.lblValidCount.Size = new System.Drawing.Size(117, 21);
            this.lblValidCount.TabIndex = 1;
            this.lblValidCount.Text = "Valid (Ready): 0";
            // 
            // lblInvalidCount
            // 
            this.lblInvalidCount.AutoSize = true;
            this.lblInvalidCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblInvalidCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblInvalidCount.Location = new System.Drawing.Point(320, 12);
            this.lblInvalidCount.Name = "lblInvalidCount";
            this.lblInvalidCount.Size = new System.Drawing.Size(115, 21);
            this.lblInvalidCount.TabIndex = 2;
            this.lblInvalidCount.Text = "Invalid / Fail: 0";
            // 
            // lblDuplicateCount
            // 
            this.lblDuplicateCount.AutoSize = true;
            this.lblDuplicateCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDuplicateCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblDuplicateCount.Location = new System.Drawing.Point(480, 12);
            this.lblDuplicateCount.Name = "lblDuplicateCount";
            this.lblDuplicateCount.Size = new System.Drawing.Size(108, 21);
            this.lblDuplicateCount.TabIndex = 3;
            this.lblDuplicateCount.Text = "Duplicates: 0";
            // 
            // chkShowErrorsOnly
            // 
            this.chkShowErrorsOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowErrorsOnly.AutoSize = true;
            this.chkShowErrorsOnly.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkShowErrorsOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.chkShowErrorsOnly.Location = new System.Drawing.Point(830, 11);
            this.chkShowErrorsOnly.Name = "chkShowErrorsOnly";
            this.chkShowErrorsOnly.Size = new System.Drawing.Size(175, 24);
            this.chkShowErrorsOnly.TabIndex = 4;
            this.chkShowErrorsOnly.Text = "Show Errors Only";
            this.chkShowErrorsOnly.UseVisualStyleBackColor = true;
            this.chkShowErrorsOnly.CheckedChanged += new System.EventHandler(this.chkShowErrorsOnly_CheckedChanged);
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPreview.ColumnHeadersHeight = 32;
            this.dgvPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRowNum,
            this.colStudentId,
            this.colStudentName,
            this.colClass,
            this.colFeeMonth,
            this.colFeeHead,
            this.colAmount,
            this.colReason,
            this.colStatus,
            this.colNotes});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(234)))), ((int)(((byte)(189)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPreview.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreview.EnableHeadersVisualStyles = false;
            this.dgvPreview.Location = new System.Drawing.Point(0, 150);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.RowHeadersVisible = false;
            this.dgvPreview.RowTemplate.Height = 26;
            this.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreview.Size = new System.Drawing.Size(1020, 410);
            this.dgvPreview.TabIndex = 3;
            // 
            // colRowNum
            // 
            this.colRowNum.HeaderText = "Row #";
            this.colRowNum.Name = "colRowNum";
            this.colRowNum.ReadOnly = true;
            this.colRowNum.Width = 55;
            // 
            // colStudentId
            // 
            this.colStudentId.HeaderText = "Student ID";
            this.colStudentId.Name = "colStudentId";
            this.colStudentId.ReadOnly = true;
            this.colStudentId.Width = 95;
            // 
            // colStudentName
            // 
            this.colStudentName.HeaderText = "Student Name (DB)";
            this.colStudentName.Name = "colStudentName";
            this.colStudentName.ReadOnly = true;
            this.colStudentName.Width = 150;
            // 
            // colClass
            // 
            this.colClass.HeaderText = "Class";
            this.colClass.Name = "colClass";
            this.colClass.ReadOnly = true;
            this.colClass.Width = 90;
            // 
            // colFeeMonth
            // 
            this.colFeeMonth.HeaderText = "Fee Month";
            this.colFeeMonth.Name = "colFeeMonth";
            this.colFeeMonth.ReadOnly = true;
            this.colFeeMonth.Width = 90;
            // 
            // colFeeHead
            // 
            this.colFeeHead.HeaderText = "Fee Head";
            this.colFeeHead.Name = "colFeeHead";
            this.colFeeHead.ReadOnly = true;
            this.colFeeHead.Width = 140;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 85;
            // 
            // colReason
            // 
            this.colReason.HeaderText = "Reason";
            this.colReason.Name = "colReason";
            this.colReason.ReadOnly = true;
            this.colReason.Width = 130;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 85;
            // 
            // colNotes
            // 
            this.colNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNotes.HeaderText = "Validation Notes";
            this.colNotes.Name = "colNotes";
            this.colNotes.ReadOnly = true;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Controls.Add(this.btnConfirm);
            this.panelBottom.Controls.Add(this.btnExportErrors);
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 560);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1020, 60);
            this.panelBottom.TabIndex = 4;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(120)))), ((int)(((byte)(61)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(540, 12);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(260, 36);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm & Import Valid Records";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnExportErrors
            // 
            this.btnExportErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportErrors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnExportErrors.FlatAppearance.BorderSize = 0;
            this.btnExportErrors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportErrors.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExportErrors.ForeColor = System.Drawing.Color.White;
            this.btnExportErrors.Location = new System.Drawing.Point(18, 12);
            this.btnExportErrors.Name = "btnExportErrors";
            this.btnExportErrors.Size = new System.Drawing.Size(200, 36);
            this.btnExportErrors.TabIndex = 1;
            this.btnExportErrors.Text = "Download Error Report";
            this.btnExportErrors.Click += new System.EventHandler(this.btnExportErrors_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(820, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmExcelImportPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1020, 620);
            this.Controls.Add(this.dgvPreview);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelSummaryCards);
            this.Controls.Add(this.panelTopConfig);
            this.Controls.Add(this.panelHeader);
            this.Name = "FrmExcelImportPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Excel Import Preview";
            this.Load += new System.EventHandler(this.FrmExcelImportPreview_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelTopConfig.ResumeLayout(false);
            this.panelTopConfig.PerformLayout();
            this.panelSummaryCards.ResumeLayout(false);
            this.panelSummaryCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSub;
        private System.Windows.Forms.Panel panelTopConfig;
        private System.Windows.Forms.Label lblFeeMonth;
        private System.Windows.Forms.DateTimePicker dtpFeeMonth;
        private System.Windows.Forms.Label lblFeeHead;
        private System.Windows.Forms.ComboBox cmbFeeHead;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Panel panelSummaryCards;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblValidCount;
        private System.Windows.Forms.Label lblInvalidCount;
        private System.Windows.Forms.Label lblDuplicateCount;
        private System.Windows.Forms.CheckBox chkShowErrorsOnly;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFeeHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
        private System.Windows.Forms.Panel panelBottom;
        private Glass.GlassButton btnConfirm;
        private Glass.GlassButton btnExportErrors;
        private Glass.GlassButton btnCancel;
    }
}
