using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace School._forms
{
    public class FrmClassStudentList : Form
    {
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private PictureBox picIcon;
        private Panel pnlFilter;
        private Label lblSearch;
        private TextBox txtSearch;
        private CheckBox chkSelectAll;
        private DataGridView dgvStudents;
        private Label lblEmpty;
        private Panel pnlBottom;
        private Label lblCount;
        private Button btnPrint;
        private Button btnClose;

        private DataTable dtStudents;
        private SYSTEMSETTING SYS = new SYSTEMSETTING();

        private string _sessionId;
        private string _sessionName;
        private string _shift;
        private string _classId;
        private string _className;
        private string _section;
        private Frm_generatefee_multi _callingForm;
        private bool _isUpdatingSelectAll = false;
        private bool _isLoadingData = false;

        // In-memory cache to preserve student checkbox states per student list during the application session
        private static readonly Dictionary<string, Dictionary<string, bool>> _savedSelectionsByList =
            new Dictionary<string, Dictionary<string, bool>>(StringComparer.OrdinalIgnoreCase);

        private string GetListKey()
        {
            string branchId = SYSTEMSETTING.branch_ID ?? "";
            return string.Format("{0}_{1}_{2}_{3}_{4}", branchId, _sessionId ?? "", _shift ?? "", _classId ?? "", _section ?? "");
        }

        public FrmClassStudentList(string sessionId, string sessionName, string shift, string classId, string className, string section, Frm_generatefee_multi callingForm = null)
        {
            _sessionId = sessionId ?? "";
            _sessionName = sessionName ?? "";
            _shift = shift ?? "";
            _classId = classId ?? "";
            _className = className ?? "";
            _section = section ?? "";
            _callingForm = callingForm;

            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
            LoadStudentData();
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.picIcon = new PictureBox();
            this.pnlFilter = new Panel();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.chkSelectAll = new CheckBox();
            this.dgvStudents = new DataGridView();
            this.lblEmpty = new Label();
            this.pnlBottom = new Panel();
            this.lblCount = new Label();
            this.btnPrint = new Button();
            this.btnClose = new Button();

            this.SuspendLayout();

            // ── Form Properties ──
            this.ClientSize = new Size(880, 560);
            this.MinimumSize = new Size(720, 420);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.Text = "Enrolled Students — " + _className + " (" + _section + ")";
            this.BackColor = Color.FromArgb(245, 247, 246);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // ── 1. Header Panel (EduCore Forest Green Identity) ──
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 68;
            this.pnlHeader.BackColor = ThemeHelper.PrimaryDarkGreen;
            this.pnlHeader.Padding = new Padding(16, 10, 16, 10);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(54, 10);
            this.lblTitle.Text = "Enrolled Students — " + _className + " (" + _section + ")";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblSubtitle.ForeColor = Color.FromArgb(209, 231, 221);
            this.lblSubtitle.Location = new Point(56, 38);
            this.lblSubtitle.Text = "Session: " + _sessionName + "  |  Shift: " + _shift + "  |  Class: " + _className + "  |  Section: " + _section;

            // Icon square
            this.picIcon.Location = new Point(16, 14);
            this.picIcon.Size = new Size(32, 32);
            this.picIcon.BackColor = ThemeHelper.ActiveGreen;
            this.picIcon.Paint += (s, pe) =>
            {
                using (Brush b = new SolidBrush(Color.White))
                using (Pen p = new Pen(Color.White, 2F))
                {
                    pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Point[] hat = { new Point(16, 4), new Point(4, 11), new Point(16, 18), new Point(28, 11) };
                    pe.Graphics.FillPolygon(b, hat);
                    pe.Graphics.DrawArc(p, 9, 13, 14, 12, 0, 180);
                    pe.Graphics.DrawLine(p, 28, 11, 28, 22);
                }
            };

            this.pnlHeader.Controls.Add(this.picIcon);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // ── 2. Filter Bar (Quick Search + Select All) ──
            this.pnlFilter.Dock = DockStyle.Top;
            this.pnlFilter.Height = 46;
            this.pnlFilter.BackColor = Color.White;
            this.pnlFilter.Padding = new Padding(16, 8, 16, 8);

            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSearch.ForeColor = ThemeHelper.DarkText;
            this.lblSearch.Location = new Point(16, 14);
            this.lblSearch.Text = "Filter Students:";

            this.txtSearch.Location = new Point(115, 11);
            this.txtSearch.Size = new Size(300, 25);
            this.txtSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);

            this.chkSelectAll.Location = new Point(435, 13);
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.chkSelectAll.ForeColor = ThemeHelper.PrimaryDarkGreen;
            this.chkSelectAll.Cursor = Cursors.Hand;
            this.chkSelectAll.CheckedChanged += new EventHandler(this.chkSelectAll_CheckedChanged);

            this.pnlFilter.Controls.Add(this.lblSearch);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.chkSelectAll);

            // ── 3. Bottom Panel (Counts & Action Buttons) ──
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Height = 52;
            this.pnlBottom.BackColor = Color.White;
            this.pnlBottom.Padding = new Padding(16, 10, 16, 10);

            this.lblCount.AutoSize = true;
            this.lblCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblCount.ForeColor = ThemeHelper.PrimaryDarkGreen;
            this.lblCount.Location = new Point(16, 16);
            this.lblCount.Text = "Total Students: 0";

            this.btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnPrint.Location = new Point(590, 10);
            this.btnPrint.Size = new Size(160, 32);
            this.btnPrint.Text = "Print Vouchers";
            this.btnPrint.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnPrint.BackColor = ThemeHelper.PrimaryDarkGreen;
            this.btnPrint.ForeColor = Color.White;
            this.btnPrint.FlatStyle = FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Cursor = Cursors.Hand;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);

            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(760, 10);
            this.btnClose.Size = new Size(94, 32);
            this.btnClose.Text = "Close";
            this.btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnClose.BackColor = Color.FromArgb(230, 235, 233);
            this.btnClose.ForeColor = ThemeHelper.DarkText;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += (s, e) =>
            {
                SaveSelectionState();
                this.Close();
            };

            this.pnlBottom.Controls.Add(this.lblCount);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnClose);

            // ── 4. Students DataGridView ──
            this.dgvStudents.Dock = DockStyle.Fill;
            this.dgvStudents.BackgroundColor = Color.White;
            this.dgvStudents.BorderStyle = BorderStyle.None;
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.ReadOnly = false;
            this.dgvStudents.EditMode = DataGridViewEditMode.EditOnEnter;
            this.dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.ColumnHeadersHeight = 36;
            this.dgvStudents.RowTemplate.Height = 30;

            this.dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = ThemeHelper.PrimaryDarkGreen;
            this.dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.dgvStudents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            this.dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244);
            this.dgvStudents.DefaultCellStyle.SelectionBackColor = ThemeHelper.ActiveGreen;
            this.dgvStudents.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvStudents.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.dgvStudents.GridColor = Color.FromArgb(220, 230, 225);

            this.dgvStudents.CellContentClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvStudents.Columns.Contains("Select") && e.ColumnIndex == dgvStudents.Columns["Select"].Index)
                {
                    dgvStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            this.dgvStudents.CellValueChanged += (s, e) =>
            {
                if (!_isLoadingData && e.RowIndex >= 0 && dgvStudents.Columns.Contains("Select") && e.ColumnIndex == dgvStudents.Columns["Select"].Index)
                {
                    UpdateSelectAllState();
                    UpdateCountLabel();
                    SaveSelectionState();
                }
            };

            this.dgvStudents.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvStudents.IsCurrentCellDirty && dgvStudents.CurrentCell != null && dgvStudents.Columns.Contains("Select") && dgvStudents.CurrentCell.ColumnIndex == dgvStudents.Columns["Select"].Index)
                {
                    dgvStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            // ── Empty State Label ──
            this.lblEmpty.Dock = DockStyle.Fill;
            this.lblEmpty.BackColor = Color.White;
            this.lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
            this.lblEmpty.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            this.lblEmpty.ForeColor = ThemeHelper.MutedText;
            this.lblEmpty.Text = "No students found for the selected class and section.";
            this.lblEmpty.Visible = false;

            // ── Add Controls in Proper Z-Order ──
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);

            this.CancelButton = this.btnClose;
            this.ResumeLayout(false);
        }

        private void LoadStudentData()
        {
            _isLoadingData = true;
            try
            {
                if (string.IsNullOrEmpty(_classId))
                {
                    ShowEmptyState("Please select a class first.");
                    return;
                }

                int cId = 0;
                int.TryParse(_classId, out cId);

                // Include Father Name (f_name) from student table
                string query = "SELECT student.s_id AS [Student ID], student.ADMISSION_NO AS [Admission No], student.s_name AS [Student Name], " +
                               "student.f_name AS [Father Name], " +
                               "student.TYPE AS [Type], student.SECTION_ID AS [Section], student.SHIFT AS [Shift] " +
                               "FROM student " +
                               "WHERE student.active='true' AND student.c_id='" + cId + "' ";

                if (!string.IsNullOrEmpty(_shift))
                {
                    query += "AND student.SHIFT='" + _shift.Replace("'", "''") + "' ";
                }

                if (!string.IsNullOrEmpty(_sessionId))
                {
                    query += "AND student.SessionID='" + _sessionId.Replace("'", "''") + "' ";
                }

                if (!string.IsNullOrEmpty(SYSTEMSETTING.branch_ID))
                {
                    query += "AND student.branch_id='" + SYSTEMSETTING.branch_ID.Replace("'", "''") + "' ";
                }

                if (!string.IsNullOrEmpty(_section))
                {
                    query += "AND student.SECTION_ID='" + _section.Replace("'", "''") + "' ";
                }

                query += "ORDER BY student.s_name ASC";

                DataSet ds = SYS.Show_Query(query);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dtStudents = ds.Tables[0];

                    // Add Checkbox column as the first column in the DataTable
                    DataColumn colSelect = new DataColumn("Select", typeof(bool));
                    colSelect.DefaultValue = true;
                    dtStudents.Columns.Add(colSelect);
                    colSelect.SetOrdinal(0);

                    string listKey = GetListKey();
                    Dictionary<string, bool> savedStates;
                    bool hasSavedSelection = _savedSelectionsByList.TryGetValue(listKey, out savedStates) && savedStates != null;

                    foreach (DataRow r in dtStudents.Rows)
                    {
                        string sid = (r["Student ID"] != null) ? r["Student ID"].ToString() : "";
                        if (hasSavedSelection && savedStates.ContainsKey(sid))
                        {
                            r["Select"] = savedStates[sid];
                        }
                        else
                        {
                            r["Select"] = true;
                        }
                    }

                    dgvStudents.DataSource = dtStudents;

                    // Configure columns: 1. Checkbox, 2. Student ID, 3. Admission No, 4. Student Name, 5. Father Name, 6. Type, 7. Section, 8. Shift
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

                    if (dgvStudents.Columns.Contains("Student ID")) dgvStudents.Columns["Student ID"].FillWeight = 16;
                    if (dgvStudents.Columns.Contains("Admission No")) dgvStudents.Columns["Admission No"].FillWeight = 20;
                    if (dgvStudents.Columns.Contains("Student Name")) dgvStudents.Columns["Student Name"].FillWeight = 34;
                    if (dgvStudents.Columns.Contains("Father Name")) dgvStudents.Columns["Father Name"].FillWeight = 34;
                    if (dgvStudents.Columns.Contains("Type")) dgvStudents.Columns["Type"].FillWeight = 16;
                    if (dgvStudents.Columns.Contains("Section")) dgvStudents.Columns["Section"].FillWeight = 14;
                    if (dgvStudents.Columns.Contains("Shift")) dgvStudents.Columns["Shift"].FillWeight = 14;

                    dgvStudents.Visible = true;
                    lblEmpty.Visible = false;

                    UpdateCountLabel();
                    UpdateSelectAllState();
                    SaveSelectionState();
                }
                else
                {
                    ShowEmptyState("No students found for the selected class and section.");
                }
            }
            catch (Exception ex)
            {
                ShowEmptyState("Could not load students: " + ex.Message);
            }
            finally
            {
                _isLoadingData = false;
            }
        }

        private void SaveSelectionState()
        {
            if (dtStudents == null) return;
            string listKey = GetListKey();
            Dictionary<string, bool> states = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
            foreach (DataRow r in dtStudents.Rows)
            {
                if (r["Student ID"] != DBNull.Value)
                {
                    string sid = r["Student ID"].ToString();
                    bool isChecked = (r["Select"] != DBNull.Value && Convert.ToBoolean(r["Select"]));
                    states[sid] = isChecked;
                }
            }
            _savedSelectionsByList[listKey] = states;

            if (_callingForm != null)
            {
                _callingForm.SelectedStudentIds = GetSelectedStudentIds();
            }
        }

        private void ShowEmptyState(string message)
        {
            dgvStudents.Visible = false;
            lblEmpty.Text = message;
            lblEmpty.Visible = true;
            lblEmpty.BringToFront();
            lblCount.Text = "Total Students: 0";
        }

        private void UpdateCountLabel()
        {
            if (dtStudents == null) return;
            int selectedCount = GetSelectedStudentIds().Count;
            int totalCount = dtStudents.Rows.Count;
            int visibleCount = dtStudents.DefaultView.Count;

            if (visibleCount < totalCount)
            {
                lblCount.Text = "Showing: " + visibleCount + " of " + totalCount + " Students  |  Selected: " + selectedCount;
            }
            else
            {
                lblCount.Text = "Total Students: " + totalCount + "  |  Selected: " + selectedCount;
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
            SaveSelectionState();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtStudents == null || dtStudents.Rows.Count == 0) return;

                string filterText = (txtSearch.Text ?? "").Trim().Replace("'", "''");
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
                    lblEmpty.Text = "No students match '" + txtSearch.Text + "'";
                    lblEmpty.Visible = true;
                    lblEmpty.BringToFront();
                    dgvStudents.Visible = false;
                }
                else
                {
                    lblEmpty.Visible = false;
                    dgvStudents.Visible = true;
                }
            }
            catch { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveSelectionState();
            List<string> selectedIds = GetSelectedStudentIds();
            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Please select at least one student to print vouchers.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_callingForm != null)
            {
                _callingForm.SelectedStudentIds = selectedIds;
                _callingForm.PrintVouchers(selectedIds);
            }
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
                        list.Add(row["Student ID"].ToString());
                    }
                }
            }
            return list;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            SaveSelectionState();
        }
    }
}
