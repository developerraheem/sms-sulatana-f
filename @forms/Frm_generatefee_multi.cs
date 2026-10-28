using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace School._forms
{
    public partial class Frm_generatefee_multi : Form
    {
        public Frm_generatefee_multi()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
            this.AutoValidate = AutoValidate.Disable;
        }


        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();

        SYSTEMSETTING SYS = new SYSTEMSETTING();

        SqlCommand cmdForm = new SqlCommand();
        int master_id, detail_id;
        public List<string> SelectedStudentIds = null;

        private DataTable dtStudents;
        private bool _isLoadingData = false;
        private bool _isUpdatingSelectAll = false;
        private bool _isInitializing = true;
        private string _currentBranchId = null;
        private System.Windows.Forms.Timer _remarksSaveTimer = null;
        private bool _isLoadingRemarks = false;
        private bool _isUpdatingDates = false;

        private static DateTime? _lastStartDate = null;
        private static DateTime? _lastEndDate = null;
        private static DateTime? _lastIssueDate = null;
        private static DateTime? _lastDueDate = null;

        private void Frm_generatefee_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'report_DataSet_new.Fee_Head' table. You can move, or remove it, as needed.
                this.fee_HeadTableAdapter.Fill(this.report_DataSet_new.Fee_Head);
            }
            catch { }

            try
            {

                SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
                SYS.comboFill(this.cmbsection, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
                this.SYS.comboFill(this.cmbselection, "select * from [Sessions] where branch_id='" + SYSTEMSETTING.branch_ID + "' order by SessionID desc", "Sessions", "SessionName", "SessionID");
                cmbselection.SelectedValue = SYSTEMSETTING.sessionid.ToString();
                combo_Emp();

                this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
                this.cmbsection.SelectedIndexChanged += new EventHandler(this.cmbFilter_SelectedIndexChanged);
                this.cmbshift.SelectedIndexChanged += new EventHandler(this.cmbFilter_SelectedIndexChanged);
                this.cmbselection.SelectedIndexChanged += new EventHandler(this.cmbFilter_SelectedIndexChanged);

                // Dynamic Branch Voucher Note handling for all branches
                _currentBranchId = SYSTEMSETTING.branch_ID;
                if (!string.IsNullOrEmpty(_currentBranchId))
                {
                    LoadBranchVoucherNote(_currentBranchId);
                }

                InitRemarksSaveTimer();
                this.txtnotes.TextChanged += new EventHandler(this.txtnotes_TextChanged);
                this.txtnotes.Leave += (s, ev) => { SaveCurrentBranchVoucherNote(); };
                this.FormClosing += (s, ev) =>
                {
                    this.AutoValidate = AutoValidate.Disable;
                    SaveCurrentBranchVoucherNote();
                    try
                    {
                        if (this.fee_Class_updateDataGridView != null)
                        {
                            this.fee_Class_updateDataGridView.CancelEdit();
                            this.fee_Class_updateDataGridView.DataSource = null;
                        }
                        if (this.dgvStudents != null)
                        {
                            this.dgvStudents.CancelEdit();
                            this.dgvStudents.DataSource = null;
                        }
                    }
                    catch { }
                };
                this.Deactivate += (s, ev) => { SaveCurrentBranchVoucherNote(); };
                this.Activated += new EventHandler(this.Frm_generatefee_multi_Activated);
                this.fee_Class_updateDataGridView.CurrentCellDirtyStateChanged += new EventHandler(this.fee_Class_updateDataGridView_CurrentCellDirtyStateChanged);
                this.fee_Class_updateDataGridView.DataError += new DataGridViewDataErrorEventHandler(this.DataGridView_DataError);
                this.fee_Class_updateDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(this.fee_Class_updateDataGridView_CellFormatting);
                this.fee_Class_updateDataGridView.CellParsing += new DataGridViewCellParsingEventHandler(this.fee_Class_updateDataGridView_CellParsing);
                this.dgvStudents.DataError += new DataGridViewDataErrorEventHandler(this.DataGridView_DataError);

                this.txtissuedate.ValueChanged += (s, ev) => { if (!_isInitializing) _lastIssueDate = txtissuedate.Value; };
                this.txtduedate.ValueChanged += (s, ev) => { if (!_isInitializing) _lastDueDate = txtduedate.Value; };

                // Preserve selected dates across visits or initialize
                if (_lastStartDate.HasValue)
                {
                    txtstartdate.Value = _lastStartDate.Value.Date;
                }
                else
                {
                    txtstartdate.Value = txtstartdate.Value.Date;
                    _lastStartDate = txtstartdate.Value.Date;
                }

                if (_lastEndDate.HasValue)
                {
                    txtenddate.Value = _lastEndDate.Value.Date;
                }
                else
                {
                    if (txtenddate.Value.Date < txtstartdate.Value.Date)
                    {
                        txtenddate.Value = txtstartdate.Value.Date;
                    }
                    else
                    {
                        txtenddate.Value = txtenddate.Value.Date;
                    }
                    _lastEndDate = txtenddate.Value.Date;
                }

                if (_lastIssueDate.HasValue)
                {
                    txtissuedate.Value = _lastIssueDate.Value.Date;
                }
                else
                {
                    _lastIssueDate = txtissuedate.Value.Date;
                }

                if (_lastDueDate.HasValue)
                {
                    txtduedate.Value = _lastDueDate.Value.Date;
                }
                else
                {
                    _lastDueDate = txtduedate.Value.Date;
                }

                txtdatefrom.Value = txtstartdate.Value.Date;
                txtdateto.Value = txtenddate.Value.Date;

                _isInitializing = false;
                UpdateDateRangeAndMonths();
                LoadClassFeeHeads();
                LoadEnrolledStudents();

            }
            catch (Exception exp)
            {

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            LoadClassFeeHeads();
            LoadEnrolledStudents();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializing) return;
            LoadEnrolledStudents();
        }

        private void fee_Class_updateDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.fee_Class_updateDataGridView.IsCurrentCellDirty)
            {
                this.fee_Class_updateDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = false;
        }

        private void fee_Class_updateDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= this.fee_Class_updateDataGridView.Rows.Count) return;
                if (e.Value == null || e.Value == DBNull.Value) return;

                if (this.fee_Class_updateDataGridView.Columns[e.ColumnIndex].DataPropertyName == "AMOUNT" ||
                    this.fee_Class_updateDataGridView.Columns[e.ColumnIndex].Name == "dataGridViewTextBoxColumn4")
                {
                    DataGridViewRow row = this.fee_Class_updateDataGridView.Rows[e.RowIndex];
                    string headName = "";
                    string headCat = "";

                    if (row.Cells["dataGridViewTextBoxColumn2"] != null && row.Cells["dataGridViewTextBoxColumn2"].Value != null)
                    {
                        string hId = row.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                        DataRow[] heads = this.report_DataSet_new.Fee_Head.Select("Fee_head_id = '" + hId.Replace("'", "''") + "'");
                        if (heads != null && heads.Length > 0)
                        {
                            if (heads[0]["Fee_head"] != DBNull.Value) headName = heads[0]["Fee_head"].ToString().Trim().ToUpper();
                            if (heads[0].Table.Columns.Contains("Category") && heads[0]["Category"] != DBNull.Value) headCat = heads[0]["Category"].ToString().Trim().ToUpper();
                        }
                    }

                    DataGridViewComboBoxCell comboCell = row.Cells["dataGridViewTextBoxColumn2"] as DataGridViewComboBoxCell;
                    if (string.IsNullOrEmpty(headName) && comboCell != null && comboCell.FormattedValue != null)
                    {
                        headName = comboCell.FormattedValue.ToString().Trim().ToUpper();
                    }

                    string rowType = (row.Cells["dataGridViewTextBoxColumn3"] != null && row.Cells["dataGridViewTextBoxColumn3"].Value != null)
                                     ? row.Cells["dataGridViewTextBoxColumn3"].Value.ToString().Trim().ToUpper() : "";

                    bool isConcession = (headCat == "DISCOUNT" || headCat == "CONCESSION" || headName.Contains("CONCESSION") || headName.Contains("DISCOUNT") || rowType.Contains("CONCESSION") || rowType.Contains("DISCOUNT"));

                    if (isConcession)
                    {
                        decimal amt = 0;
                        if (decimal.TryParse(e.Value.ToString(), out amt) && amt != 0)
                        {
                            e.Value = (-Math.Abs(amt)).ToString("0");
                            e.FormattingApplied = true;
                        }
                    }
                }
            }
            catch { }
        }

        private void fee_Class_updateDataGridView_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= this.fee_Class_updateDataGridView.Rows.Count) return;
                if (e.Value == null) return;

                if (this.fee_Class_updateDataGridView.Columns[e.ColumnIndex].DataPropertyName == "AMOUNT" ||
                    this.fee_Class_updateDataGridView.Columns[e.ColumnIndex].Name == "dataGridViewTextBoxColumn4")
                {
                    decimal val;
                    if (decimal.TryParse(e.Value.ToString(), out val))
                    {
                        e.Value = Convert.ToInt32(Math.Abs(val));
                        e.ParsingApplied = true;
                    }
                }
            }
            catch { }
        }

        private void LoadClassFeeHeads()
        {
            try
            {
                if (comboBox1.SelectedValue == null)
                {
                    this.report_DataSet_new.Fee_Class_update.Clear();
                    return;
                }

                decimal classId;
                if (decimal.TryParse(comboBox1.SelectedValue.ToString(), out classId) && classId > 0)
                {
                    if (this.fee_Class_updateTableAdapter.Connection == null || this.fee_Class_updateTableAdapter.Connection.State == ConnectionState.Closed)
                    {
                        this.fee_Class_updateTableAdapter.Connection = SYS.db_connect();
                    }
                    this.fee_Class_updateTableAdapter.Fill(this.report_DataSet_new.Fee_Class_update, new System.Nullable<decimal>(classId));
                }
                else
                {
                    this.report_DataSet_new.Fee_Class_update.Clear();
                }
            }
            catch (System.Exception)
            {
            }
        }

        private void LoadEnrolledStudents()
        {
            if (_isInitializing) return;
            _isLoadingData = true;

            try
            {
                if (comboBox1.SelectedValue == null)
                {
                    ShowEmptyState("Please select a class first.");
                    this.SelectedStudentIds = new List<string>();
                    return;
                }

                int classId = 0;
                if (!int.TryParse(comboBox1.SelectedValue.ToString(), out classId) || classId <= 0)
                {
                    ShowEmptyState("Please select a class first.");
                    this.SelectedStudentIds = new List<string>();
                    return;
                }

                string shift = (cmbshift.SelectedValue != null) ? cmbshift.SelectedValue.ToString() : (cmbshift.Text ?? "");
                string section = (cmbsection.SelectedValue != null) ? cmbsection.SelectedValue.ToString() : (cmbsection.Text ?? "");
                string sessionId = (cmbselection.SelectedValue != null) ? cmbselection.SelectedValue.ToString() : (SYSTEMSETTING.sessionid ?? "");
                string branchId = SYSTEMSETTING.branch_ID ?? "";

                string query = "SELECT student.s_id AS [Student ID], student.ADMISSION_NO AS [Admission No], student.s_name AS [Student Name], " +
                               "student.f_name AS [Father Name], " +
                               "student.SECTION_ID AS [Section], student.SHIFT AS [Shift], student.TYPE AS [Type] " +
                               "FROM student " +
                               "WHERE student.active='true' AND student.c_id='" + classId + "' ";

                if (!string.IsNullOrEmpty(shift))
                {
                    query += "AND student.SHIFT='" + shift.Replace("'", "''") + "' ";
                }
                if (!string.IsNullOrEmpty(sessionId))
                {
                    query += "AND student.SessionID='" + sessionId.Replace("'", "''") + "' ";
                }
                if (!string.IsNullOrEmpty(branchId))
                {
                    query += "AND student.branch_id='" + branchId.Replace("'", "''") + "' ";
                }
                if (!string.IsNullOrEmpty(section))
                {
                    query += "AND student.SECTION_ID='" + section.Replace("'", "''") + "' ";
                }

                query += "ORDER BY student.s_name ASC";

                DataSet ds = SYS.Show_Query(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dtStudents = ds.Tables[0];

                    DataColumn colSelect = new DataColumn("Select", typeof(bool));
                    colSelect.DefaultValue = true;
                    dtStudents.Columns.Add(colSelect);
                    colSelect.SetOrdinal(0);

                    foreach (DataRow r in dtStudents.Rows)
                    {
                        r["Select"] = true;
                    }

                    dgvStudents.DataSource = dtStudents;

                    foreach (DataGridViewColumn col in dgvStudents.Columns)
                    {
                        if (col.Name == "Select")
                        {
                            col.ReadOnly = false;
                            col.FillWeight = 8;
                            col.HeaderText = "";
                        }
                        else
                        {
                            col.ReadOnly = true;
                        }
                    }

                    if (dgvStudents.Columns.Contains("Student ID")) dgvStudents.Columns["Student ID"].FillWeight = 14;
                    if (dgvStudents.Columns.Contains("Admission No")) dgvStudents.Columns["Admission No"].FillWeight = 16;
                    if (dgvStudents.Columns.Contains("Student Name")) dgvStudents.Columns["Student Name"].FillWeight = 32;
                    if (dgvStudents.Columns.Contains("Father Name")) dgvStudents.Columns["Father Name"].FillWeight = 30;
                    if (dgvStudents.Columns.Contains("Section")) dgvStudents.Columns["Section"].FillWeight = 12;
                    if (dgvStudents.Columns.Contains("Shift")) dgvStudents.Columns["Shift"].FillWeight = 12;
                    if (dgvStudents.Columns.Contains("Type")) dgvStudents.Columns["Type"].FillWeight = 12;

                    dgvStudents.Visible = true;
                    lblEmptyStudents.Visible = false;

                    UpdateCountLabel();
                    UpdateSelectAllState();
                    UpdateSelectedStudentIdsList();
                }
                else
                {
                    ShowEmptyState("No students found for the selected criteria.");
                    this.SelectedStudentIds = new List<string>();
                }
            }
            catch (Exception ex)
            {
                ShowEmptyState("Error loading students: " + ex.Message);
                this.SelectedStudentIds = new List<string>();
            }
            finally
            {
                _isLoadingData = false;
            }
        }

        private void ShowEmptyState(string message)
        {
            if (dgvStudents != null)
            {
                dgvStudents.DataSource = null;
                dgvStudents.Visible = false;
            }
            if (lblEmptyStudents != null)
            {
                lblEmptyStudents.Text = message;
                lblEmptyStudents.Visible = true;
                lblEmptyStudents.BringToFront();
            }
            if (lblStudentCount != null)
            {
                lblStudentCount.Text = "Total Students: 0 | Selected: 0";
            }
        }

        private void UpdateCountLabel()
        {
            if (dtStudents == null || lblStudentCount == null) return;
            int selectedCount = GetSelectedStudentIds().Count;
            int totalCount = dtStudents.Rows.Count;
            int visibleCount = dtStudents.DefaultView.Count;

            if (visibleCount < totalCount)
            {
                lblStudentCount.Text = "Showing: " + visibleCount + " of " + totalCount + " | Selected: " + selectedCount;
            }
            else
            {
                lblStudentCount.Text = "Total Students: " + totalCount + " | Selected: " + selectedCount;
            }
        }

        private void UpdateSelectAllState()
        {
            if (dtStudents == null || chkSelectAll == null) return;
            int count = dtStudents.DefaultView.Count;
            if (count == 0) return;

            _isUpdatingSelectAll = true;
            try
            {
                int checkedCount = 0;
                foreach (DataRowView drv in dtStudents.DefaultView)
                {
                    if (drv["Select"] != DBNull.Value && Convert.ToBoolean(drv["Select"]))
                    {
                        checkedCount++;
                    }
                }

                if (checkedCount == count && count > 0)
                {
                    chkSelectAll.Checked = true;
                    chkSelectAll.Text = "Deselect All";
                }
                else
                {
                    chkSelectAll.Checked = false;
                    chkSelectAll.Text = "Select All";
                }
            }
            finally
            {
                _isUpdatingSelectAll = false;
            }
        }

        private void UpdateSelectedStudentIdsList()
        {
            this.SelectedStudentIds = GetSelectedStudentIds();
        }

        public List<string> GetSelectedStudentIds()
        {
            List<string> list = new List<string>();
            if (dtStudents != null)
            {
                foreach (DataRow row in dtStudents.Rows)
                {
                    if (row["Select"] != DBNull.Value && Convert.ToBoolean(row["Select"]))
                    {
                        if (row["Student ID"] != DBNull.Value)
                        {
                            list.Add(row["Student ID"].ToString());
                        }
                    }
                }
            }
            return list;
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_isUpdatingSelectAll || _isLoadingData || dtStudents == null) return;

            bool check = chkSelectAll.Checked;
            chkSelectAll.Text = check ? "Deselect All" : "Select All";

            foreach (DataRowView drv in dtStudents.DefaultView)
            {
                drv["Select"] = check;
            }

            if (dgvStudents != null)
            {
                dgvStudents.EndEdit();
                dgvStudents.Refresh();
            }
            UpdateCountLabel();
            UpdateSelectedStudentIdsList();
        }

        private void txtSearchStudents_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtStudents == null || dtStudents.Rows.Count == 0) return;

                string filterText = (txtSearchStudents.Text ?? "").Trim().Replace("'", "''");
                if (string.IsNullOrEmpty(filterText))
                {
                    dtStudents.DefaultView.RowFilter = "";
                }
                else
                {
                    dtStudents.DefaultView.RowFilter = string.Format(
                        "[Student Name] LIKE '%{0}%' OR [Father Name] LIKE '%{0}%' OR [Admission No] LIKE '%{0}%' OR Convert([Student ID], 'System.String') LIKE '%{0}%'",
                        filterText);
                }

                int visibleCount = dtStudents.DefaultView.Count;
                UpdateCountLabel();
                UpdateSelectAllState();

                if (visibleCount == 0)
                {
                    lblEmptyStudents.Text = "No students match '" + txtSearchStudents.Text + "'";
                    lblEmptyStudents.Visible = true;
                    lblEmptyStudents.BringToFront();
                    dgvStudents.Visible = false;
                }
                else
                {
                    lblEmptyStudents.Visible = false;
                    dgvStudents.Visible = true;
                }
            }
            catch { }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudents.Columns.Contains("Select") && e.ColumnIndex == dgvStudents.Columns["Select"].Index)
            {
                dgvStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvStudents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!_isLoadingData && e.RowIndex >= 0 && dgvStudents.Columns.Contains("Select") && e.ColumnIndex == dgvStudents.Columns["Select"].Index)
            {
                UpdateSelectAllState();
                UpdateCountLabel();
                UpdateSelectedStudentIdsList();
            }
        }

        private void dgvStudents_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvStudents.IsCurrentCellDirty && dgvStudents.CurrentCell != null && dgvStudents.Columns.Contains("Select") && dgvStudents.CurrentCell.ColumnIndex == dgvStudents.Columns["Select"].Index)
            {
                dgvStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void LoadFIne()
        {
            LoadClassFeeHeads();
        }

        private void combo_Emp()
        {
            try
            {

                SYSTEMSETTING SYS = new SYSTEMSETTING();
                SYS.comboFill(this.comboBox1, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            }
            catch (Exception exp)
            {

            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnproc_Click(object sender, EventArgs e)
        {

            DialogResult ret;
            ret = MessageBox.Show("You Want to Generate Fee?", "Confrim".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                SaveCurrentBranchVoucherNote();
                int newVouchersCount = 0;
                try
                {
                    SqlConnection con = SYS.db_connect();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    int classId = 0;
                    if (comboBox1.SelectedValue != null)
                    {
                        int.TryParse(comboBox1.SelectedValue.ToString(), out classId);
                    }
                    DataRowView drvClass = comboBox1.SelectedItem as DataRowView;
                    if (classId <= 0 && drvClass != null && drvClass.Row.Table.Columns.Contains("c_id"))
                    {
                        int.TryParse(drvClass["c_id"].ToString(), out classId);
                    }
                    if (classId <= 0)
                    {
                        MessageBox.Show("Please select a valid class first.", "Class Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string shift = (cmbshift.SelectedValue != null) ? cmbshift.SelectedValue.ToString() : (cmbshift.Text ?? "");
                    string section = (cmbsection.SelectedValue != null) ? cmbsection.SelectedValue.ToString() : (cmbsection.Text ?? "");
                    string sessionId = (cmbselection.SelectedValue != null) ? cmbselection.SelectedValue.ToString() : (SYSTEMSETTING.sessionid ?? "");
                    string branchId = _currentBranchId;
                    if (string.IsNullOrEmpty(branchId))
                    {
                        branchId = SYSTEMSETTING.branch_ID ?? "";
                    }

                    decimal branchNum = 0;
                    bool hasBranch = decimal.TryParse(branchId, out branchNum) && branchNum > 0;
                    decimal sessionNum = 0;
                    bool hasSession = decimal.TryParse(sessionId, out sessionNum) && sessionNum > 0;

                    if (hasBranch)
                    {
                        SYSTEMSETTING.branch_ID = branchNum.ToString();
                    }
                    if (hasSession)
                    {
                        SYSTEMSETTING.sessionid = sessionNum.ToString();
                    }

                    string query = "Select * from student where c_id ='" + classId + "' and active='true' ";
                    if (!string.IsNullOrEmpty(shift))
                    {
                        query += "AND SHIFT ='" + shift.Replace("'", "''") + "' ";
                    }
                    if (!string.IsNullOrEmpty(section))
                    {
                        query += "and SECTION_ID='" + section.Replace("'", "''") + "' ";
                    }
                    if (hasSession)
                    {
                        query += "AND SessionID='" + sessionNum + "' ";
                    }
                    if (hasBranch)
                    {
                        query += "and branch_id='" + branchNum + "' ";
                    }

                    if (checkBox1.Checked == true)
                    {
                        decimal singleStudentId = 0;
                        if (!decimal.TryParse(txtstudentid.Text.Trim(), out singleStudentId) || singleStudentId <= 0)
                        {
                            MessageBox.Show("Please enter a valid numeric Student ID.", "Invalid Student ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        query += "and s_id='" + singleStudentId + "' ";
                    }
                    else if (SelectedStudentIds != null)
                    {
                        List<string> validStudentIds = new List<string>();
                        foreach (string sid in SelectedStudentIds)
                        {
                            decimal parsedSid;
                            if (decimal.TryParse(sid, out parsedSid) && parsedSid > 0)
                            {
                                validStudentIds.Add(parsedSid.ToString());
                            }
                        }
                        if (validStudentIds.Count == 0)
                        {
                            MessageBox.Show("Please select at least one student to generate fee.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        query += "and s_id in (" + string.Join(",", validStudentIds.ToArray()) + ") ";
                    }

                    DateTime dtStart = txtstartdate.Value.Date;
                    DateTime dtEnd = txtenddate.Value.Date;
                    _lastStartDate = dtStart;
                    _lastEndDate = dtEnd;
                    _lastIssueDate = txtissuedate.Value.Date;
                    _lastDueDate = txtduedate.Value.Date;
                    DateTime startMonthDt = new DateTime(dtStart.Year, dtStart.Month, 1);
                    DateTime endMonthDt = new DateTime(dtEnd.Year, dtEnd.Month, 1);

                    if (dtStart > dtEnd && startMonthDt > endMonthDt)
                    {
                        MessageBox.Show("Start Date cannot be greater than End Date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    int totalMonths = GetMonths(dtStart, dtEnd);
                    if (totalMonths < 1)
                    {
                        totalMonths = 1;
                    }

                    string startMonthStr = txtdatefrom.Text.Trim();
                    string endMonthStr = txtdateto.Text.Trim();
                    if (string.IsNullOrEmpty(startMonthStr))
                    {
                        startMonthStr = startMonthDt.ToString("MM yyyy");
                    }
                    if (string.IsNullOrEmpty(endMonthStr))
                    {
                        endMonthStr = endMonthDt.ToString("MM yyyy");
                    }

                    // Check which heads user flagged as multiply in grid
                    List<string> gridMultiHeads = new List<string>();
                    try
                    {
                        foreach (DataGridViewRow gRow in fee_Class_updateDataGridView.Rows)
                        {
                            if (gRow.IsNewRow) continue;
                            string headId = (gRow.Cells[1].Value != null) ? gRow.Cells[1].Value.ToString().Trim() : "";
                            if (string.IsNullOrEmpty(headId) && gRow.Cells[0].Value != null) headId = gRow.Cells[0].Value.ToString().Trim();
                            bool isM = false;
                            if (gRow.Cells["ISMULTIPLY"] != null && gRow.Cells["ISMULTIPLY"].Value != null)
                            {
                                bool.TryParse(gRow.Cells["ISMULTIPLY"].Value.ToString(), out isM);
                                if (!isM)
                                {
                                    string sM = gRow.Cells["ISMULTIPLY"].Value.ToString().Trim();
                                    isM = (sM == "1" || sM.Equals("true", StringComparison.OrdinalIgnoreCase) || sM.Equals("Y", StringComparison.OrdinalIgnoreCase));
                                }
                            }
                            if (isM && !string.IsNullOrEmpty(headId) && !gridMultiHeads.Contains(headId))
                            {
                                gridMultiHeads.Add(headId);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }

                    newVouchersCount = 0;
                    int updatedVouchersCount = 0;

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter objAdptr1 = new SqlDataAdapter();
                    objAdptr1.SelectCommand = cmd;
                    DataSet objDtset1 = new DataSet();
                    objAdptr1.Fill(objDtset1, "student");
                    foreach (DataRow Student_ in objDtset1.Tables[0].Rows)
                    {
                        string studentid = Student_["s_id"].ToString();
                        string admNo = (Student_.Table.Columns.Contains("ADMISSION_NO") && Student_["ADMISSION_NO"] != DBNull.Value) ? Student_["ADMISSION_NO"].ToString() : "";
                        _class.FEE fee = new _class.FEE();

                        string existingMasterId = "";
                        string existingPaid = "";
                        decimal existingRecAmt = 0;
                        bool hasRecAmt = false;

                        string checkQuery = "Select FEE_MASTER_ID, PAID, REC_AMOUNT from FEE_MASTER WHERE C_ID ='" + classId + "' " +
                                            "and s_id ='" + studentid + "' ";
                        if (hasSession)
                        {
                            checkQuery += "and SESSIONID='" + sessionNum + "' ";
                        }
                        if (hasBranch)
                        {
                            checkQuery += "and branch_id='" + branchNum + "' ";
                        }
                        checkQuery += "and FEE_MONTH = '" + endMonthStr.Replace("'", "''") + "' ";

                        SqlCommand cmddr = new SqlCommand(checkQuery, con);
                        SqlDataReader dr = cmddr.ExecuteReader();
                        bool exists = false;
                        if (dr.Read())
                        {
                            exists = true;
                            existingMasterId = dr["FEE_MASTER_ID"].ToString();
                            existingPaid = (dr["PAID"] != DBNull.Value) ? dr["PAID"].ToString().Trim() : "";
                            if (dr["REC_AMOUNT"] != DBNull.Value)
                            {
                                hasRecAmt = true;
                                decimal.TryParse(dr["REC_AMOUNT"].ToString(), out existingRecAmt);
                            }
                        }
                        dr.Close();

                        if (exists)
                        {
                            // Check if explicitly unposted (PAID is null/empty and REC_AMOUNT == 0 per frmUnpostVoucher)
                            bool isUnposted = hasRecAmt && existingRecAmt == 0 && string.IsNullOrEmpty(existingPaid);
                            if (isUnposted)
                            {
                                // Explicitly unposted: allow regeneration by cleaning up stale unposted voucher
                                SqlCommand delDetail = new SqlCommand("DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + existingMasterId + "' AND branch_id = '" + branchNum + "' AND SessionID = '" + sessionNum + "'", con);
                                delDetail.ExecuteNonQuery();
                                SqlCommand delMaster = new SqlCommand("DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '" + existingMasterId + "' AND branch_id = '" + branchNum + "' AND SessionID = '" + sessionNum + "'", con);
                                delMaster.ExecuteNonQuery();

                                // Proceed to regenerate fresh voucher below
                            }
                            else
                            {
                                // Active voucher already exists: block regeneration and show message
                                MessageBox.Show("Voucher already generated for this month.");
                                continue;
                            }
                        }

                        // Clean up any stale unposted vouchers in intermediate months if regenerating multi-month
                        if (totalMonths > 1)
                        {
                            for (DateTime m = startMonthDt; m < endMonthDt; m = m.AddMonths(1))
                            {
                                string mStr = m.ToString("MM yyyy");
                                string cleanStale = "SELECT FEE_MASTER_ID, PAID, REC_AMOUNT FROM FEE_MASTER WHERE C_ID = '" + classId + "' AND s_id = '" + studentid + "' AND FEE_MONTH = '" + mStr.Replace("'", "''") + "' ";
                                if (hasSession) cleanStale += "AND SessionID = '" + sessionNum + "' ";
                                if (hasBranch) cleanStale += "AND branch_id = '" + branchNum + "' ";
                                using (SqlCommand stCmd = new SqlCommand(cleanStale, con))
                                using (SqlDataReader sDr = stCmd.ExecuteReader())
                                {
                                    if (sDr.Read())
                                    {
                                        string stMasterId = sDr["FEE_MASTER_ID"].ToString();
                                        string stPaid = (sDr["PAID"] != DBNull.Value) ? sDr["PAID"].ToString().Trim() : "";
                                        decimal stRec = -1;
                                        if (sDr["REC_AMOUNT"] != DBNull.Value) decimal.TryParse(sDr["REC_AMOUNT"].ToString(), out stRec);
                                        if (stRec == 0 && string.IsNullOrEmpty(stPaid))
                                        {
                                            sDr.Close();
                                            SqlCommand delD = new SqlCommand("DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + stMasterId + "' AND branch_id = '" + branchNum + "' AND SessionID = '" + sessionNum + "'", con);
                                            delD.ExecuteNonQuery();
                                            SqlCommand delM = new SqlCommand("DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '" + stMasterId + "' AND branch_id = '" + branchNum + "' AND SessionID = '" + sessionNum + "'", con);
                                            delM.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }

                        fee.generatefeeMulti(classId.ToString(), endMonthStr, shift, studentid, totalMonths, startMonthStr, txtduedate.Text, totalMonths.ToString(), txttfine.Text, txtnotes.Text, txtissuedate.Text, txtstartdate.Text, txtenddate.Text, section);
                        newVouchersCount++;

                        // Voucher adjustment for fee concessions, multi-month heads, and payable total
                        string getGenMaster = "SELECT TOP 1 FEE_MASTER_ID FROM FEE_MASTER WHERE C_ID = '" + classId + "' AND s_id = '" + studentid + "' AND FEE_MONTH = '" + endMonthStr.Replace("'", "''") + "' ";
                        if (hasSession) getGenMaster += "AND SessionID = '" + sessionNum + "' ";
                        if (hasBranch) getGenMaster += "AND branch_id = '" + branchNum + "' ";
                        getGenMaster += "ORDER BY FEE_MASTER_ID DESC";

                        string genMasterId = "";
                        using (SqlCommand gmCmd = new SqlCommand(getGenMaster, con))
                        {
                            object gmObj = gmCmd.ExecuteScalar();
                            if (gmObj != null && gmObj != DBNull.Value)
                            {
                                genMasterId = gmObj.ToString();
                            }
                        }

                        if (!string.IsNullOrEmpty(genMasterId))
                        {
                            string selectDetailsSql = @"
                                SELECT fd.FEE_DETAIL_ID, fd.Fee_head_id, fd.AMOUNT, fh.Fee_head, fh.Category, fc.AMOUNT AS BaseAmount, fc.ISMULTIPLY
                                FROM FEE_DETAIL fd
                                INNER JOIN Fee_Head fh ON fd.Fee_head_id = fh.Fee_head_id
                                LEFT JOIN FEE_CLASS fc ON fc.Fee_head_id = fd.Fee_head_id AND fc.C_ID = '" + classId + @"' AND (fc.branch_id = '" + branchNum + @"' OR fc.branch_id IS NULL)
                                WHERE fd.FEE_MASTER_ID = '" + genMasterId + @"' AND fd.branch_id = '" + branchNum + @"' AND fd.SessionID = '" + sessionNum + @"'";

                            DataTable dtDetails = new DataTable();
                            using (SqlDataAdapter daDet = new SqlDataAdapter(selectDetailsSql, con))
                            {
                                daDet.Fill(dtDetails);
                            }

                            foreach (DataRow dRow in dtDetails.Rows)
                            {
                                string detId = dRow["FEE_DETAIL_ID"].ToString();
                                string hId = dRow["Fee_head_id"].ToString();
                                string hName = (dRow["Fee_head"] != DBNull.Value) ? dRow["Fee_head"].ToString().Trim().ToUpper() : "";
                                string cat = (dRow["Category"] != DBNull.Value) ? dRow["Category"].ToString().Trim().ToUpper() : "";
                                decimal curAmt = 0;
                                decimal.TryParse(dRow["AMOUNT"].ToString(), out curAmt);

                                bool isConcession = (cat == "DISCOUNT" || cat == "CONCESSION" || hName.Contains("CONCESSION") || hName.Contains("DISCOUNT"));
                                bool isArrear = (cat == "ARREAR" || hName.Contains("ARREAR"));
                                bool isFine = (cat == "FINE" || hName.Contains("FINE"));

                                if (isArrear || isFine)
                                {
                                    continue; // Preserve arrears and fines
                                }

                                if (isConcession)
                                {
                                    decimal targetConc = curAmt;
                                    if (curAmt > 0)
                                    {
                                        decimal concUnit = 0;
                                        if (dRow["BaseAmount"] != DBNull.Value && decimal.TryParse(dRow["BaseAmount"].ToString(), out concUnit) && concUnit > 0)
                                        {
                                        }
                                        else
                                        {
                                            concUnit = curAmt;
                                        }
                                        targetConc = -(Math.Abs(concUnit) * totalMonths);
                                    }
                                    else if (curAmt < 0 && totalMonths > 1)
                                    {
                                        targetConc = curAmt * totalMonths;
                                    }

                                    if (curAmt != targetConc)
                                    {
                                        string updSql = "UPDATE FEE_DETAIL SET AMOUNT = " + targetConc + ", BALANCE = " + targetConc + " WHERE FEE_DETAIL_ID = " + detId;
                                        using (SqlCommand updCmd = new SqlCommand(updSql, con))
                                        {
                                            updCmd.ExecuteNonQuery();
                                        }
                                    }
                                    continue;
                                }

                                bool isMultiInClass = false;
                                if (dRow["ISMULTIPLY"] != DBNull.Value)
                                {
                                    string mStr = dRow["ISMULTIPLY"].ToString().Trim();
                                    isMultiInClass = (!string.IsNullOrEmpty(mStr) && mStr != "0" && !mStr.Equals("false", StringComparison.OrdinalIgnoreCase));
                                }

                                bool isMonthlyHead = (hName.Contains("MONTHLY") || hName.Contains("TUITION") || hName.Contains("TUTION") || isMultiInClass || gridMultiHeads.Contains(hId));

                                if (isMonthlyHead && totalMonths > 1)
                                {
                                    decimal baseAmt = 0;
                                    if (dRow["BaseAmount"] != DBNull.Value && decimal.TryParse(dRow["BaseAmount"].ToString(), out baseAmt) && baseAmt > 0)
                                    {
                                        // Exact base amount from FEE_CLASS
                                    }
                                    else
                                    {
                                        baseAmt = curAmt;
                                    }

                                    decimal targetAmt = baseAmt * totalMonths;
                                    if (curAmt != targetAmt)
                                    {
                                        string updSql = "UPDATE FEE_DETAIL SET AMOUNT = " + targetAmt + ", BALANCE = " + targetAmt + " WHERE FEE_DETAIL_ID = " + detId;
                                        using (SqlCommand updCmd = new SqlCommand(updSql, con))
                                        {
                                            updCmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                            string sumSql = "SELECT SUM(AMOUNT) FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + genMasterId + "' AND branch_id = '" + branchNum + "' AND SessionID = '" + sessionNum + "'";
                            using (SqlCommand sumCmd = new SqlCommand(sumSql, con))
                            {
                                object sObj = sumCmd.ExecuteScalar();
                                decimal totalRec = 0;
                                if (sObj != null && sObj != DBNull.Value)
                                {
                                    decimal.TryParse(sObj.ToString(), out totalRec);
                                }
                                string updMasterSql = "UPDATE FEE_MASTER SET RECEIVABLE_AMOUNT = '" + totalRec + "', BALANCE = '" + totalRec + "' WHERE FEE_MASTER_ID = '" + genMasterId + "' AND branch_id = '" + branchNum + "' AND SessionID = '" + sessionNum + "'";
                                using (SqlCommand updMasterCmd = new SqlCommand(updMasterSql, con))
                                {
                                    updMasterCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }
                finally
                {
                    if (newVouchersCount > 0)
                    {
                        SYS.setMessageBox("Fee Generation Completed.", 1);
                    }
                }
            }
            else
            {
                return;
            }

        }



        private void MASTER_ID()
        {
            try
            {

                int myID;
                SqlConnection con = SYS.db_connect();
                con.Open();
                SqlCommand cmddr = new SqlCommand("select max(FEE_MASTER_ID) as ids from FEE_MASTER", con);
                SqlDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        master_id = 1;
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                        master_id = myID;
                    }

                }
                dr.Close();
                con.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void DETAIL_ID()
        {
            try
            {

                int myID;
                SqlConnection con = SYS.db_connect();
                con.Open();
                SqlCommand cmddr = new SqlCommand("select max(FEE_DETAIL_ID) as ids from FEE_DETAIL", con);
                SqlDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        detail_id = 1;
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                        detail_id = myID;
                    }

                }
                dr.Close();
                con.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void fee_ClassBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Validate();
                //this.fee_ClassBindingSource.EndEdit();
                //this.tableAdapterManager.UpdateAll(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet);
                //MessageBox.Show("Updated");
            }
            catch (Exception exp)
            {

            }


        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {


        }



        public void PrintVouchers(List<string> studentIds = null)
        {
            List<string> targetIds = studentIds ?? this.SelectedStudentIds;
            if (this.SelectedStudentIds != null && (targetIds == null || targetIds.Count == 0))
            {
                MessageBox.Show("Please select at least one student to print vouchers.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SYSTEMSETTING SYS = new SYSTEMSETTING();
            DataSet rs = new DataSet();
            bool multitag = false;
            string query = "";

            int selMonths = GetMonths(txtstartdate.Value.Date, txtenddate.Value.Date);
            if (selMonths > 1)
            {
                multitag = true;
            }
            else
            {
                try
                {
                    query = "select MULTITAG from FEE_MASTER where FEE_MONTH='" + txtdateto.Text + "' and SESSIONID='" + SYSTEMSETTING.sessionid + "'";
                    rs = SYS.Show_Query(query);
                    foreach (DataRow RowDocument in rs.Tables[0].Rows)
                    {
                        if (RowDocument["MULTITAG"].ToString() == "Y")
                        {
                            multitag = true;
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    multitag = false;
                }
            }

            if (checkBox1.Checked == true)
            {
                if (multitag == false)
                {
                    Frm_Vouchers frm = new Frm_Vouchers();
                    frm.classid = comboBox1.SelectedValue.ToString();
                    frm.feemonth = txtdateto.Text.ToString();
                    frm.param = "AdmissionNo";
                    frm.section = cmbsection.SelectedValue.ToString();
                    frm.admissionno = txtstudentid.Text;
                    frm.shift = cmbshift.SelectedValue.ToString();
                    frm.sessionid = cmbselection.SelectedValue.ToString();
                    frm.Show();
                }
                else
                {
                    Frm_Vouchers_multi frm = new Frm_Vouchers_multi();
                    frm.classid = comboBox1.SelectedValue.ToString();
                    frm.feemonth = txtdateto.Text.ToString();
                    frm.param = "AdmissionNo";
                    frm.section = cmbsection.SelectedValue.ToString();
                    frm.admissionno = txtstudentid.Text;
                    frm.shift = cmbshift.SelectedValue.ToString();
                    frm.sessionid = cmbselection.SelectedValue.ToString();
                    frm.Show();
                }

            }

            else
            {
                try
                {
                    if (multitag == false)
                    {
                        Frm_Vouchers frm = new Frm_Vouchers();
                        frm.classid = comboBox1.SelectedValue.ToString();
                        frm.feemonth = txtdateto.Text.ToString();
                        frm.param = "month";
                        frm.section = cmbsection.SelectedValue.ToString();
                        frm.shift = cmbshift.SelectedValue.ToString();
                        frm.sessionid = cmbselection.SelectedValue.ToString();
                        frm.SelectedStudentIds = targetIds;
                        frm.Show();
                    }
                    else
                    {
                        Frm_Vouchers_multi frm = new Frm_Vouchers_multi();
                        frm.classid = comboBox1.SelectedValue.ToString();
                        frm.feemonth = txtdateto.Text.ToString();
                        frm.param = "month";
                        frm.section = cmbsection.SelectedValue.ToString();
                        frm.shift = cmbshift.SelectedValue.ToString();
                        frm.sessionid = cmbselection.SelectedValue.ToString();
                        frm.SelectedStudentIds = targetIds;
                        frm.Show();
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintVouchers(this.SelectedStudentIds);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtstudentid.Enabled = true;
                btnfindstd.Enabled = true;
            }
            else
            {
                txtstudentid.Enabled = false;
                btnfindstd.Enabled = false;
            }
        }

        public string Student_ID
        {
            get { return txtstudentid.Text; }
            set { txtstudentid.Text = value; }
        }

        private void btnfindstd_Click(object sender, EventArgs e)
        {
            Frmfind_student frm = new Frmfind_student(this);
            frm.param = "FeeGenerateMulti";
            frm.Classid = comboBox1.SelectedValue.ToString();
            frm.Shift = cmbshift.SelectedValue.ToString();
            frm.SectionID = cmbsection.SelectedValue.ToString();
            frm.ShowDialog();
        }

        private void txtstudentid_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            LoadFIne();
        }

        private void cmbshift_Click(object sender, EventArgs e)
        {
            LoadFIne();
        }

        private void fee_Class_updateBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.fee_Class_updateDataGridView.EndEdit();
                this.fee_Class_updateBindingSource.EndEdit();

                if (this.fee_Class_updateTableAdapter.Connection == null || this.fee_Class_updateTableAdapter.Connection.State == ConnectionState.Closed)
                {
                    this.fee_Class_updateTableAdapter.Connection = SYS.db_connect();
                }
                if (this.tableAdapterManager != null)
                {
                    this.tableAdapterManager.Connection = this.fee_Class_updateTableAdapter.Connection;
                    this.tableAdapterManager.Fee_Class_updateTableAdapter = this.fee_Class_updateTableAdapter;
                }

                try
                {
                    this.fee_Class_updateTableAdapter.Update(this.report_DataSet_new.Fee_Class_update);
                    this.tableAdapterManager.UpdateAll(this.report_DataSet_new);
                }
                catch (Exception)
                {
                    // Fallback direct update for modified rows if optimistic concurrency fails
                    using (SqlConnection con = SYS.db_connect())
                    {
                        con.Open();
                        foreach (DataRow row in this.report_DataSet_new.Fee_Class_update.Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                using (SqlCommand cmd = new SqlCommand("UPDATE [Fee_Class] SET [ACTIVE] = @ACTIVE, [AMOUNT] = @AMOUNT, [TYPE] = @TYPE WHERE [FEE_CLASS_ID] = @FEE_CLASS_ID", con))
                                {
                                    cmd.Parameters.AddWithValue("@ACTIVE", row["ACTIVE"]);
                                    cmd.Parameters.AddWithValue("@AMOUNT", row["AMOUNT"]);
                                    cmd.Parameters.AddWithValue("@TYPE", row["TYPE"]);
                                    cmd.Parameters.AddWithValue("@FEE_CLASS_ID", row["FEE_CLASS_ID"]);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    this.report_DataSet_new.Fee_Class_update.AcceptChanges();
                }

                // Persist current branch voucher remarks when saving
                SaveCurrentBranchVoucherNote();

                SYS.setMessageBox("Record Updated", 1);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error updating fee structure: " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmvprinting_Click(object sender, EventArgs e)
        {
            FrmVoucherPr frm = new FrmVoucherPr();
            frm.ShowDialog();
        }



        private void UpdateDateRangeAndMonths()
        {
            if (_isInitializing || _isUpdatingDates) return;
            try
            {
                _isUpdatingDates = true;
                DateTime sDate = txtstartdate.Value.Date;
                DateTime eDate = txtenddate.Value.Date;

                txtdatefrom.Value = sDate;
                txtdateto.Value = eDate;
                int month = GetMonths(sDate, eDate);
                lblmonth.Text = month.ToString();
                LoadFIne();
            }
            catch (Exception exp)
            {
                if (!_isInitializing)
                {
                    SYS.setCreateError(exp.Message);
                }
            }
            finally
            {
                _isUpdatingDates = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateRangeAndMonths();
        }
        public int GetMonths(DateTime startDate, DateTime endDate)
        {
            int months = 1;
            try
            {
                DateTime sDate = startDate.Date;
                DateTime eDate = endDate.Date;

                DateTime startMonth = new DateTime(sDate.Year, sDate.Month, 1);
                DateTime endMonth = new DateTime(eDate.Year, eDate.Month, 1);

                if (sDate > eDate && startMonth > endMonth)
                {
                    if (!_isInitializing)
                    {
                        SYS.setCreateError("Start Date is greater than the End Date");
                    }
                    return 1;
                }

                months = ((endMonth.Year * 12) + endMonth.Month) - ((startMonth.Year * 12) + startMonth.Month) + 1;
                if (months < 1)
                {
                    months = 1;
                }
            }
            catch (Exception exp)
            {
                if (!_isInitializing)
                {
                    SYS.setCreateError(exp.Message);
                }
            }
            return months;

        }

        private void txtstartdate_ValueChanged(object sender, EventArgs e)
        {
            if (!_isInitializing) _lastStartDate = txtstartdate.Value;
            UpdateDateRangeAndMonths();
        }

        private void txtdatefrom_ValueChanged(object sender, EventArgs e)
        {
            UpdateDateRangeAndMonths();
        }

        private void txtenddate_ValueChanged(object sender, EventArgs e)
        {
            if (!_isInitializing) _lastEndDate = txtenddate.Value;
            UpdateDateRangeAndMonths();
        }



        private void btnfinditems_advance_Click(object sender, EventArgs e)
        {
            LoadClassFeeHeads();
            LoadEnrolledStudents();
        }

        #region Branch Voucher Remarks Database Persistence

        private const string DefaultVoucherNote = "Note: The Challan must be deposited within due date to avoid late payment charges, of Rs. 500/-";

        private void InitRemarksSaveTimer()
        {
            if (_remarksSaveTimer == null)
            {
                _remarksSaveTimer = new System.Windows.Forms.Timer();
                _remarksSaveTimer.Interval = 500;
                _remarksSaveTimer.Tick += (s, e) =>
                {
                    _remarksSaveTimer.Stop();
                    SaveCurrentBranchVoucherNote();
                };
            }
        }

        private void txtnotes_TextChanged(object sender, EventArgs e)
        {
            if (_isLoadingRemarks || string.IsNullOrEmpty(_currentBranchId)) return;
            if (_remarksSaveTimer != null)
            {
                _remarksSaveTimer.Stop();
                _remarksSaveTimer.Start();
            }
        }

        public void SaveCurrentBranchVoucherNote()
        {
            try
            {
                if (_remarksSaveTimer != null)
                {
                    _remarksSaveTimer.Stop();
                }

                string branchToSave = _currentBranchId;
                if (string.IsNullOrEmpty(branchToSave))
                {
                    branchToSave = SYSTEMSETTING.branch_ID;
                }

                if (!string.IsNullOrEmpty(branchToSave) && !_isLoadingRemarks)
                {
                    SaveBranchVoucherNote(branchToSave, this.txtnotes.Text);
                }
            }
            catch { }
        }

        private void Frm_generatefee_multi_Activated(object sender, EventArgs e)
        {
            try
            {
                string activeBranch = SYSTEMSETTING.branch_ID;
                if (!string.IsNullOrEmpty(activeBranch) && activeBranch != _currentBranchId)
                {
                    // Save remarks for previous branch before switching
                    SaveCurrentBranchVoucherNote();

                    // Switch branch context and reload remarks
                    _currentBranchId = activeBranch;
                    LoadBranchVoucherNote(_currentBranchId);
                    ReloadBranchData();
                }
            }
            catch { }
        }

        private void ReloadBranchData()
        {
            try
            {
                _isInitializing = true;
                string branch = _currentBranchId ?? SYSTEMSETTING.branch_ID ?? "";
                SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + branch + "'", "SHIFT", "SHIFT", "SHIFT");
                SYS.comboFill(this.cmbsection, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + branch + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
                this.SYS.comboFill(this.cmbselection, "select * from [Sessions] where branch_id='" + branch + "' order by SessionID desc", "Sessions", "SessionName", "SessionID");
                if (SYSTEMSETTING.sessionid != null)
                {
                    cmbselection.SelectedValue = SYSTEMSETTING.sessionid.ToString();
                }
                combo_Emp();
                _isInitializing = false;
                LoadClassFeeHeads();
                LoadEnrolledStudents();
            }
            catch { }
        }

        private void LoadBranchVoucherNote(string branchId)
        {
            if (string.IsNullOrEmpty(branchId)) return;

            try
            {
                _isLoadingRemarks = true;
                string safeBranchId = branchId.Trim();
                string query = "SELECT TOP 1 Remarks FROM dbo.BranchVoucherRemarks WHERE Branch_ID = @Branch_ID";

                using (SqlConnection con = SYS.db_connect())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Branch_ID", SqlDbType.VarChar, 50) { Value = safeBranchId });

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            txtnotes.Text = result.ToString();
                            return;
                        }
                    }
                }

                // If no saved remarks exist in the database for this branch, use default remarks in UI
                txtnotes.Text = DefaultVoucherNote;
            }
            catch
            {
                // Fallback to default remarks on any exception
                txtnotes.Text = DefaultVoucherNote;
            }
            finally
            {
                _isLoadingRemarks = false;
            }
        }

        private void SaveBranchVoucherNote(string branchId, string noteText)
        {
            if (string.IsNullOrEmpty(branchId)) return;

            try
            {
                string safeBranchId = branchId.Trim();
                string textToSave = noteText ?? string.Empty;

                string query = @"
                    IF EXISTS (SELECT 1 FROM dbo.BranchVoucherRemarks WHERE Branch_ID = @Branch_ID)
                    BEGIN
                        UPDATE dbo.BranchVoucherRemarks
                        SET Remarks = @Remarks,
                            UpdatedAt = GETDATE()
                        WHERE Branch_ID = @Branch_ID;
                    END
                    ELSE
                    BEGIN
                        INSERT INTO dbo.BranchVoucherRemarks (Branch_ID, Remarks, UpdatedAt)
                        VALUES (@Branch_ID, @Remarks, GETDATE());
                    END";

                using (SqlConnection con = SYS.db_connect())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Branch_ID", SqlDbType.VarChar, 50) { Value = safeBranchId });
                        cmd.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, -1) { Value = textToSave });
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

    }
}
