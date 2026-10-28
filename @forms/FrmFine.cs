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
    public partial class FrmFine : Form
    {
        public FrmFine()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private SYSTEMSETTING SYS = new SYSTEMSETTING();
        private string newID = "";
        private string editID = "";
        private bool isEditMode = false;

        private void FrmFine_Load(object sender, EventArgs e)
        {
            try
            {
                SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT] FROM [SHIFT] WHERE branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
                SYS.comboFill(this.cmbclass, "select c_id, c_name from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
                SYS.comboFill(this.cmbfeetype, "select Fee_head_id, Fee_head from Fee_Head where branch_id='" + SYSTEMSETTING.branch_ID + "' order by Fee_head", "Fee_Head", "Fee_head", "Fee_head_id");
                SYS.comboFill(this.com_Sclass, "select c_id, c_name from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");

                // Initialize Filter Combos
                this.cmbHeadFilter.Items.Clear();
                this.cmbHeadFilter.Items.Add("All Heads");
                this.cmbHeadFilter.Items.Add("Fines Only");
                this.cmbHeadFilter.Items.Add("Concessions Only");
                this.cmbHeadFilter.SelectedIndex = 0;

                this.cmbStatusFilter.Items.Clear();
                this.cmbStatusFilter.Items.Add("Pending Only");
                this.cmbStatusFilter.Items.Add("Applied Only");
                this.cmbStatusFilter.Items.Add("All Status");
                this.cmbStatusFilter.SelectedIndex = 0;

                // Dates
                this.txtdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                this.txtfeemonth.Value = DateTime.Today;
                this.dateTimePicker1.Value = DateTime.Today;
                this.rdobymonth.Checked = true;

                fill_bydate();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error initializing Fine / Discount module: " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Student Lookup & Auto-Population

        private bool LookupStudent(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            try
            {
                using (SqlConnection con = SYS.db_connect())
                {
                    con.Open();
                    string selectedCid = (cmbclass.SelectedValue != null) ? cmbclass.SelectedValue.ToString() : "";
                    string query = @"SELECT TOP 1 s.s_id, s.ADMISSION_NO, s.roll_no, s.s_name, s.c_id, s.SHIFT, s.active
                                     FROM student s
                                     WHERE (s.s_id = @id OR s.ADMISSION_NO = @id OR s.STUDENT_ID = @id" +
                                     (!string.IsNullOrEmpty(selectedCid) ? " OR (s.roll_no = @id AND s.c_id = @cid)" : "") + @")
                                       AND s.branch_id = @bid
                                     ORDER BY CASE WHEN s.SessionID = @sid THEN 0 ELSE 1 END,
                                              CASE WHEN s.active = 1 THEN 0 ELSE 1 END";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", input);
                        cmd.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);
                        cmd.Parameters.AddWithValue("@sid", SYSTEMSETTING.sessionid);
                        if (!string.IsNullOrEmpty(selectedCid))
                        {
                            cmd.Parameters.AddWithValue("@cid", selectedCid);
                        }

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txts_id.Text = dr["s_id"].ToString();
                                txtstdname.Text = dr["s_name"].ToString();
                                if (dr["c_id"] != DBNull.Value && cmbclass.Items.Count > 0)
                                {
                                    try { cmbclass.SelectedValue = dr["c_id"].ToString(); } catch { }
                                }
                                if (dr["SHIFT"] != DBNull.Value && cmbshift.Items.Count > 0)
                                {
                                    try { cmbshift.Text = dr["SHIFT"].ToString(); } catch { }
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                // Silently handle lookup error
            }

            return false;
        }

        private void txts_id_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txts_id.Text.Trim()) && string.IsNullOrEmpty(txtstdname.Text.Trim()))
            {
                LookupStudent(txts_id.Text.Trim());
            }
        }

        private void txts_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (string.IsNullOrEmpty(txts_id.Text.Trim()))
                {
                    OpenStudentSearch();
                }
                else
                {
                    if (LookupStudent(txts_id.Text.Trim()))
                    {
                        cmbfeetype.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Student ID/Roll No '" + txts_id.Text.Trim() + "' not found.", "Student Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OpenStudentSearch();
                    }
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            OpenStudentSearch();
        }

        private void OpenStudentSearch()
        {
            Frmfind_student frm = new Frmfind_student(this);
            frm.param = "Fine";
            frm.Classid = (cmbclass.SelectedValue != null) ? cmbclass.SelectedValue.ToString() : "";
            frm.Shift = (cmbshift.SelectedValue != null) ? cmbshift.SelectedValue.ToString() : "";
            frm.ShowDialog();

            if (!string.IsNullOrEmpty(txts_id.Text.Trim()))
            {
                LookupStudent(txts_id.Text.Trim());
            }
        }

        public string Class_ID
        {
            get { return cmbclass.SelectedValue != null ? cmbclass.SelectedValue.ToString() : ""; }
            set { cmbclass.SelectedValue = value; }
        }

        public string Student_ID
        {
            get { return txts_id.Text; }
            set
            {
                txts_id.Text = value;
                LookupStudent(value);
            }
        }

        public string Student_Name
        {
            get { return txtstdname.Text; }
            set { txtstdname.Text = value; }
        }

        #endregion

        #region Record Operations (Save, Edit, Delete, Clear)

        private void Fine_ID()
        {
            try
            {
                using (SqlConnection con = SYS.db_connect())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(CAST(FINE_ID AS BIGINT)), 0) + 1 AS ids FROM FINE_HISTORY", con))
                    {
                        object res = cmd.ExecuteScalar();
                        newID = (res != null && res != DBNull.Value) ? res.ToString() : "1";
                    }
                }
            }
            catch (Exception)
            {
                newID = "1";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save_Fine();
        }

        private void save_Fine()
        {
            // Validations
            if (string.IsNullOrEmpty(txts_id.Text.Trim()) || string.IsNullOrEmpty(txtstdname.Text.Trim()))
            {
                MessageBox.Show("Please select or enter a valid Student!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txts_id.Focus();
                return;
            }

            if (cmbfeetype.SelectedValue == null)
            {
                MessageBox.Show("Please select a Fine Type / Fee Head!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbfeetype.Focus();
                return;
            }

            int amount;
            if (!int.TryParse(txtamount.Text.Trim(), out amount) || amount <= 0)
            {
                MessageBox.Show("Amount must be a numeric value greater than zero!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtamount.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtfeemonth.Text.Trim()))
            {
                MessageBox.Show("Fee Month is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtfeemonth.Focus();
                return;
            }

            string headId = cmbfeetype.SelectedValue.ToString();
            string feeMonth = txtfeemonth.Text.Trim();
            string classId = (cmbclass.SelectedValue != null) ? cmbclass.SelectedValue.ToString() : "0";
            string active = chkactive.Checked ? "Y" : "N";
            string remarks = txtremarks.Text.Trim();

            try
            {
                if (isEditMode && !string.IsNullOrEmpty(editID))
                {
                    // Check if record is already applied
                    using (SqlConnection con = SYS.db_connect())
                    {
                        con.Open();
                        using (SqlCommand chkCmd = new SqlCommand("SELECT FEE_MASTER_ID FROM FINE_HISTORY WHERE FINE_ID = @editId AND SessionID = @session AND branch_id = @bid", con))
                        {
                            chkCmd.Parameters.AddWithValue("@editId", editID);
                            chkCmd.Parameters.AddWithValue("@session", SYSTEMSETTING.sessionid);
                            chkCmd.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);
                            object mId = chkCmd.ExecuteScalar();
                            if (mId != null && mId != DBNull.Value && !string.IsNullOrEmpty(mId.ToString().Trim()))
                            {
                                MessageBox.Show("This entry has already been applied to Fee Voucher #" + mId.ToString().Trim() + " and cannot be modified directly.", "Record Already Applied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Update existing record
                        string updQuery = @"UPDATE FINE_HISTORY 
                                            SET S_ID = @sid, Fee_head_id = @headId, FINE_AMOUNT = @amt, 
                                                FEE_MONTH = @month, c_id = @cid, active = @active, REMARKS = @rem
                                            WHERE FINE_ID = @editId AND SessionID = @session AND branch_id = @bid";

                        using (SqlCommand cmd = new SqlCommand(updQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@sid", txts_id.Text.Trim());
                            cmd.Parameters.AddWithValue("@headId", headId);
                            cmd.Parameters.AddWithValue("@amt", amount);
                            cmd.Parameters.AddWithValue("@month", feeMonth);
                            cmd.Parameters.AddWithValue("@cid", classId);
                            cmd.Parameters.AddWithValue("@active", active);
                            cmd.Parameters.AddWithValue("@rem", remarks);
                            cmd.Parameters.AddWithValue("@editId", editID);
                            cmd.Parameters.AddWithValue("@session", SYSTEMSETTING.sessionid);
                            cmd.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearform();
                                fill_bydate();
                            }
                            else
                            {
                                MessageBox.Show("Failed to update record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    // Check duplicate entry for the same student, month, and fee head
                    using (SqlConnection con = SYS.db_connect())
                    {
                        con.Open();
                        string chkQuery = @"SELECT FINE_ID, FINE_AMOUNT FROM FINE_HISTORY 
                                            WHERE S_ID = @sid AND Fee_head_id = @headId AND FEE_MONTH = @month 
                                              AND active = 'Y' AND SessionID = @session AND branch_id = @bid";

                        using (SqlCommand cmdChk = new SqlCommand(chkQuery, con))
                        {
                            cmdChk.Parameters.AddWithValue("@sid", txts_id.Text.Trim());
                            cmdChk.Parameters.AddWithValue("@headId", headId);
                            cmdChk.Parameters.AddWithValue("@month", feeMonth);
                            cmdChk.Parameters.AddWithValue("@session", SYSTEMSETTING.sessionid);
                            cmdChk.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);

                            using (SqlDataReader dr = cmdChk.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    string existingId = dr["FINE_ID"].ToString();
                                    string existingAmt = dr["FINE_AMOUNT"].ToString();
                                    dr.Close();

                                    DialogResult dres = MessageBox.Show(
                                        "An active entry for Fee Head '" + cmbfeetype.Text + "' (Rs. " + existingAmt + ") already exists for this student in " + feeMonth + ".\n\nWould you like to update the existing record with this new amount?",
                                        "Duplicate Entry Detected",
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question);

                                    if (dres == DialogResult.Yes)
                                    {
                                        string updExisting = @"UPDATE FINE_HISTORY 
                                                               SET FINE_AMOUNT = @amt, REMARKS = @rem, active = @active, c_id = @cid
                                                               WHERE FINE_ID = @eid AND SessionID = @session AND branch_id = @bid";
                                        using (SqlCommand cmdUpd = new SqlCommand(updExisting, con))
                                        {
                                            cmdUpd.Parameters.AddWithValue("@amt", amount);
                                            cmdUpd.Parameters.AddWithValue("@rem", remarks);
                                            cmdUpd.Parameters.AddWithValue("@active", active);
                                            cmdUpd.Parameters.AddWithValue("@cid", classId);
                                            cmdUpd.Parameters.AddWithValue("@eid", existingId);
                                            cmdUpd.Parameters.AddWithValue("@session", SYSTEMSETTING.sessionid);
                                            cmdUpd.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);
                                            cmdUpd.ExecuteNonQuery();
                                        }

                                        MessageBox.Show("Existing entry updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        clearform();
                                        fill_bydate();
                                        return;
                                    }
                                    else if (dres == DialogResult.Cancel)
                                    {
                                        return;
                                    }
                                }
                            }
                        }

                        // Insert new record
                        Fine_ID();
                        string insQuery = @"INSERT INTO FINE_HISTORY(FINE_ID, S_ID, Fee_head_id, FINE_DATE, FINE_AMOUNT, FEE_MONTH, c_id, active, SessionID, branch_id, REMARKS) 
                                            VALUES (@id, @sid, @headId, @date, @amt, @month, @cid, @active, @session, @bid, @rem)";

                        using (SqlCommand cmdIns = new SqlCommand(insQuery, con))
                        {
                            cmdIns.Parameters.AddWithValue("@id", newID);
                            cmdIns.Parameters.AddWithValue("@sid", txts_id.Text.Trim());
                            cmdIns.Parameters.AddWithValue("@headId", headId);
                            cmdIns.Parameters.AddWithValue("@date", DateTime.Today);
                            cmdIns.Parameters.AddWithValue("@amt", amount);
                            cmdIns.Parameters.AddWithValue("@month", feeMonth);
                            cmdIns.Parameters.AddWithValue("@cid", classId);
                            cmdIns.Parameters.AddWithValue("@active", active);
                            cmdIns.Parameters.AddWithValue("@session", SYSTEMSETTING.sessionid);
                            cmdIns.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);
                            cmdIns.Parameters.AddWithValue("@rem", remarks);

                            int rows = cmdIns.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearform();
                                fill_bydate();
                            }
                            else
                            {
                                MessageBox.Show("Failed to add record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error saving record: " + exp.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(editID))
            {
                MessageBox.Show("Please select a record from the list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check if record is already applied
            try
            {
                using (SqlConnection con = SYS.db_connect())
                {
                    con.Open();
                    using (SqlCommand chkCmd = new SqlCommand("SELECT FEE_MASTER_ID FROM FINE_HISTORY WHERE FINE_ID = @id AND SessionID = @sid AND branch_id = @bid", con))
                    {
                        chkCmd.Parameters.AddWithValue("@id", editID);
                        chkCmd.Parameters.AddWithValue("@sid", SYSTEMSETTING.sessionid);
                        chkCmd.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);
                        object mId = chkCmd.ExecuteScalar();
                        if (mId != null && mId != DBNull.Value && !string.IsNullOrEmpty(mId.ToString().Trim()))
                        {
                            MessageBox.Show("This entry has already been applied to Fee Voucher #" + mId.ToString().Trim() + " and cannot be deleted.", "Record Already Applied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            catch { }

            DialogResult ret = MessageBox.Show("Are you sure you want to delete this Fine / Discount entry for " + txtstdname.Text + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = SYS.db_connect())
                    {
                        con.Open();
                        string delQuery = "DELETE FROM FINE_HISTORY WHERE FINE_ID = @id AND SessionID = @sid AND branch_id = @bid";
                        using (SqlCommand cmd = new SqlCommand(delQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@id", editID);
                            cmd.Parameters.AddWithValue("@sid", SYSTEMSETTING.sessionid);
                            cmd.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("Record deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearform();
                                fill_bydate();
                            }
                            else
                            {
                                MessageBox.Show("Could not delete record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error deleting record: " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearform();
        }

        public void clearform()
        {
            isEditMode = false;
            editID = "";
            btnSave.Text = "Save";
            txts_id.Text = string.Empty;
            txtstdname.Text = string.Empty;
            txtamount.Text = "0";
            txtremarks.Text = string.Empty;
            chkactive.Checked = true;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Grid Selection & Row Binding

        private void lstv_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstv_Student.SelectedItems.Count > 0)
            {
                ListViewItem item = lstv_Student.SelectedItems[0];
                DataRow row = item.Tag as DataRow;

                if (row != null)
                {
                    this.editID = row["FINE_ID"].ToString();
                    this.txts_id.Text = row["S_ID"].ToString();
                    this.txtstdname.Text = row["s_name"].ToString();
                    this.txtamount.Text = row["FINE_AMOUNT"].ToString();
                    this.txtremarks.Text = row["REMARKS"] != DBNull.Value ? row["REMARKS"].ToString() : "";

                    if (row["c_id"] != DBNull.Value)
                    {
                        try { this.cmbclass.SelectedValue = row["c_id"].ToString(); } catch { }
                    }

                    if (row["Fee_head_id"] != DBNull.Value)
                    {
                        try { this.cmbfeetype.SelectedValue = row["Fee_head_id"].ToString(); } catch { }
                    }

                    if (row["FEE_MONTH"] != DBNull.Value)
                    {
                        try
                        {
                            DateTime dt;
                            if (DateTime.TryParseExact(row["FEE_MONTH"].ToString().Trim(), "MM yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                this.txtfeemonth.Value = dt;
                            }
                        }
                        catch { }
                    }

                    this.chkactive.Checked = (row["active"] != DBNull.Value && row["active"].ToString().Trim() == "Y");
                    this.isEditMode = true;
                    this.btnSave.Text = "Update";
                }
            }
        }

        #endregion

        #region Bulk Active / In-Active

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Are you sure you want to Activate all entries for " + txtfeemonth.Text + "?", "Confirm Active All", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = SYS.db_connect())
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE FINE_HISTORY SET active='Y' WHERE branch_id=@bid AND SessionID=@sid AND FEE_MONTH=@month AND (FEE_MASTER_ID IS NULL OR FEE_MASTER_ID = '')", con))
                        {
                            cmd.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);
                            cmd.Parameters.AddWithValue("@sid", SYSTEMSETTING.sessionid);
                            cmd.Parameters.AddWithValue("@month", txtfeemonth.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }

                    clearform();
                    MessageBox.Show("All pending entries for " + txtfeemonth.Text + " have been activated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fill_bydate();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error updating records: " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Are you sure you want to Deactivate all entries for " + txtfeemonth.Text + "?", "Confirm In-Active All", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = SYS.db_connect())
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("UPDATE FINE_HISTORY SET active='N' WHERE branch_id=@bid AND SessionID=@sid AND FEE_MONTH=@month AND (FEE_MASTER_ID IS NULL OR FEE_MASTER_ID = '')", con))
                        {
                            cmd.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);
                            cmd.Parameters.AddWithValue("@sid", SYSTEMSETTING.sessionid);
                            cmd.Parameters.AddWithValue("@month", txtfeemonth.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }

                    clearform();
                    MessageBox.Show("All entries for " + txtfeemonth.Text + " have been deactivated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fill_bydate();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error updating records: " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Search, Filtering & Summary Reporting

        public void fill_bydate()
        {
            LoadRecords();
        }

        private void rdobymonth_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void rdo_All_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void rdo_Class_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void com_Sclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rdo_Class.Checked)
            {
                LoadRecords();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (this.rdobymonth.Checked)
            {
                LoadRecords();
            }
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void txtSearchRecords_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void LoadRecords()
        {
            try
            {
                using (SqlConnection con = SYS.db_connect())
                {
                    con.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"SELECT b.FINE_ID, b.S_ID, c.s_name, c.ADMISSION_NO, class.c_name, b.c_id,
                                       a.Fee_head_id, a.Fee_head, a.Category, b.FINE_DATE, b.FINE_AMOUNT,
                                       b.FEE_MONTH, b.REMARKS, b.active, b.FEE_MASTER_ID
                                FROM FINE_HISTORY b
                                INNER JOIN Fee_Head a ON b.Fee_head_id = a.Fee_head_id
                                LEFT JOIN student c ON b.S_ID = c.s_id
                                LEFT JOIN class ON b.c_id = class.c_id
                                WHERE b.SessionID = @sid AND b.branch_id = @bid ");

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@sid", SYSTEMSETTING.sessionid);
                    cmd.Parameters.AddWithValue("@bid", SYSTEMSETTING.branch_ID);

                    // Month or Class or All
                    if (this.rdobymonth.Checked)
                    {
                        sb.Append(" AND b.FEE_MONTH = @month ");
                        cmd.Parameters.AddWithValue("@month", this.dateTimePicker1.Text.Trim());
                    }
                    else if (this.rdo_Class.Checked && this.com_Sclass.SelectedValue != null)
                    {
                        sb.Append(" AND b.c_id = @cid ");
                        cmd.Parameters.AddWithValue("@cid", this.com_Sclass.SelectedValue.ToString());
                    }

                    // Fee Head Filter
                    if (cmbHeadFilter.SelectedIndex == 1) // Fines Only
                    {
                        sb.Append(" AND a.Category = 'FINE' ");
                    }
                    else if (cmbHeadFilter.SelectedIndex == 2) // Concessions Only
                    {
                        sb.Append(" AND a.Category IN ('DISCOUNT', 'CONCESSION') ");
                    }

                    // Status Filter
                    if (cmbStatusFilter.SelectedIndex == 0) // Pending Only (Default)
                    {
                        sb.Append(" AND (b.FEE_MASTER_ID IS NULL OR b.FEE_MASTER_ID = '') AND (b.active = 'Y' OR b.active LIKE 'Y%') ");
                    }
                    else if (cmbStatusFilter.SelectedIndex == 1) // Applied Only
                    {
                        sb.Append(" AND ((b.FEE_MASTER_ID IS NOT NULL AND b.FEE_MASTER_ID <> '') OR b.active = 'N') ");
                    }
                    // SelectedIndex == 2 is All Status (Shows both Pending and Applied)

                    // Text Search
                    string search = txtSearchRecords.Text.Trim();
                    if (!string.IsNullOrEmpty(search))
                    {
                        sb.Append(" AND (c.s_name LIKE @term OR c.ADMISSION_NO LIKE @term OR b.S_ID LIKE @term OR b.REMARKS LIKE @term) ");
                        cmd.Parameters.AddWithValue("@term", "%" + search + "%");
                    }

                    sb.Append(" ORDER BY b.FINE_DATE DESC, b.FINE_ID DESC");
                    cmd.CommandText = sb.ToString();

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    lstv_Student.BeginUpdate();
                    lstv_Student.Items.Clear();

                    long totalFines = 0;
                    long totalConcessions = 0;
                    Dictionary<string, bool> studentSet = new Dictionary<string, bool>();

                    foreach (DataRow row in dt.Rows)
                    {
                        string sName = row["s_name"] != DBNull.Value ? row["s_name"].ToString() : "(Unknown)";
                        string admNo = row["ADMISSION_NO"] != DBNull.Value ? row["ADMISSION_NO"].ToString() : row["S_ID"].ToString();
                        string cName = row["c_name"] != DBNull.Value ? row["c_name"].ToString() : "";
                        string feeHead = row["Fee_head"] != DBNull.Value ? row["Fee_head"].ToString() : "";
                        string category = row["Category"] != DBNull.Value ? row["Category"].ToString() : "FINE";
                        string amountStr = row["FINE_AMOUNT"] != DBNull.Value ? row["FINE_AMOUNT"].ToString() : "0";
                        string feeMonth = row["FEE_MONTH"] != DBNull.Value ? row["FEE_MONTH"].ToString() : "";
                        string remarks = row["REMARKS"] != DBNull.Value ? row["REMARKS"].ToString() : "";
                        string fineDate = "";
                        if (row["FINE_DATE"] != DBNull.Value)
                        {
                            try { fineDate = Convert.ToDateTime(row["FINE_DATE"]).ToString("dd/MM/yyyy"); } catch { }
                        }
                        string active = row["active"] != DBNull.Value ? row["active"].ToString().Trim() : "Y";
                        string feeMasterId = row["FEE_MASTER_ID"] != DBNull.Value ? row["FEE_MASTER_ID"].ToString().Trim() : "";
                        bool isApplied = (!string.IsNullOrEmpty(feeMasterId) || active == "N");
                        string appliedStatus = isApplied ? (!string.IsNullOrEmpty(feeMasterId) ? "Applied (#" + feeMasterId + ")" : "Applied") : "Pending";
                        string fineId = row["FINE_ID"].ToString();

                        int amt;
                        int.TryParse(amountStr, out amt);

                        if (category.ToUpper() == "FINE" || category.ToUpper() == "LATE FEE FINE")
                        {
                            totalFines += amt;
                        }
                        else
                        {
                            totalConcessions += amt;
                        }

                        string stdId = row["S_ID"].ToString();
                        if (!string.IsNullOrEmpty(stdId))
                        {
                            studentSet[stdId] = true;
                        }

                        ListViewItem lvi = new ListViewItem(sName);
                        lvi.SubItems.Add(admNo);
                        lvi.SubItems.Add(cName);
                        lvi.SubItems.Add(feeHead);
                        lvi.SubItems.Add(category);
                        lvi.SubItems.Add(amt.ToString("N0"));
                        lvi.SubItems.Add(feeMonth);
                        lvi.SubItems.Add(remarks);
                        lvi.SubItems.Add(fineDate);
                        lvi.SubItems.Add(active);
                        lvi.SubItems.Add(appliedStatus);
                        lvi.SubItems.Add(fineId);
                        lvi.Tag = row;

                        if (active == "N")
                        {
                            lvi.ForeColor = Color.FromArgb(156, 163, 175);
                        }

                        lstv_Student.Items.Add(lvi);
                    }

                    lstv_Student.EndUpdate();

                    long net = totalFines - totalConcessions;
                    lblSummary.Text = string.Format("Total Fines: Rs. {0:N0}  |  Total Concessions: Rs. {1:N0}  |  Net: Rs. {2:N0}  |  Students: {3}",
                        totalFines, totalConcessions, net, studentSet.Count);
                }
            }
            catch (Exception exp)
            {
                // Silently prevent UI freeze
            }
        }

        #endregion

        #region Excel Import & Download Template

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Excel File for Fee / Fine Import";
                ofd.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls|CSV Files (*.csv)|*.csv|All Supported Files (*.xlsx;*.xls;*.csv)|*.xlsx;*.xls;*.csv";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        DataTable dt = ExcelHelper.ReadFile(ofd.FileName);

                        if (dt == null || dt.Rows.Count == 0)
                        {
                            MessageBox.Show("The selected file contains no data rows.", "Empty File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string defaultHeadId = (cmbfeetype.SelectedValue != null) ? cmbfeetype.SelectedValue.ToString() : "";
                        string defaultHeadName = cmbfeetype.Text;
                        string defaultMonth = txtfeemonth.Text.Trim();
                        string defaultCid = (cmbclass.SelectedValue != null) ? cmbclass.SelectedValue.ToString() : "";

                        using (FrmExcelImportPreview preview = new FrmExcelImportPreview(dt, defaultMonth, defaultHeadId, defaultHeadName, defaultCid))
                        {
                            if (preview.ShowDialog() == DialogResult.OK)
                            {
                                fill_bydate();
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Error reading Excel file: " + exp.Message, "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }

        private void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save Fee Import Template";
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx|CSV File (*.csv)|*.csv";
                sfd.FileName = "Fee_Import_Template.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string ext = Path.GetExtension(sfd.FileName).ToLower();
                        if (ext == ".csv")
                        {
                            ExcelHelper.GenerateTemplateCsv(sfd.FileName);
                        }
                        else
                        {
                            ExcelHelper.GenerateTemplateXlsx(sfd.FileName);
                        }

                        DialogResult res = MessageBox.Show(
                            "Excel Template generated successfully at:\n" + sfd.FileName + "\n\nWould you like to open it now?",
                            "Template Created",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (res == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(sfd.FileName);
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Error generating template: " + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Key Navigation Handlers

        private void cmbclass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txts_id.Focus();
            }
        }

        private void cmbfeetype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtamount.Focus();
            }
        }

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {
                txtremarks.Focus();
            }
        }

        #endregion
    }
}
