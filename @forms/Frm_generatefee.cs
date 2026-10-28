using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School._forms
{
    public partial class Frm_generatefee : Form
    {
        public Frm_generatefee()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }


        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();

        SYSTEMSETTING SYS = new SYSTEMSETTING();

        SqlCommand cmdForm = new SqlCommand();
        int master_id, detail_id;
        private string _currentBranchId = null;
        private System.Windows.Forms.Timer _remarksSaveTimer = null;
        private bool _isLoadingRemarks = false;

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

                SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT]", "SHIFT", "SHIFT", "SHIFT");
                SYS.comboFill(this.cmbsection, "SELECT [SECTION_NAME] FROM [Sections]", "Sections", "SECTION_NAME", "SECTION_NAME");
                this.SYS.comboFill(this.cmbselection, "select * from [Sessions] order by SessionID desc", "Sessions", "SessionName", "SessionID");
                cmbselection.SelectedValue = SYSTEMSETTING.sessionid.ToString();
                combo_Emp();
                this.LoadFIne();

                // Dynamic Branch Voucher Remarks handling for all branches
                _currentBranchId = SYSTEMSETTING.branch_ID;
                if (!string.IsNullOrEmpty(_currentBranchId))
                {
                    LoadBranchVoucherNote(_currentBranchId);
                }

                InitRemarksSaveTimer();
                this.txtremarks.TextChanged += new EventHandler(this.txtremarks_TextChanged);
                this.txtremarks.Leave += (s, ev) => { SaveCurrentBranchVoucherNote(); };
                this.FormClosing += (s, ev) => { SaveCurrentBranchVoucherNote(); };
                this.Deactivate += (s, ev) => { SaveCurrentBranchVoucherNote(); };
                this.Activated += new EventHandler(this.Frm_generatefee_Activated);
                this.fee_Class_updateDataGridView.CurrentCellDirtyStateChanged += new EventHandler(this.fee_Class_updateDataGridView_CurrentCellDirtyStateChanged);

            }
            catch (Exception exp)
            {

            }

        }

        private void fee_Class_updateDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.fee_Class_updateDataGridView.IsCurrentCellDirty)
            {
                this.fee_Class_updateDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void LoadFIne()
        {


            //SYS.Filllist_DataView("SELECT Fee_Class.FEE_CLASS_ID, Fee_Head.Fee_head, Fee_Class.AMOUNT  FROM (Fee_Class INNER JOIN Fee_Head ON Fee_Class.Fee_head_id = Fee_Head.Fee_head_id) WHERE (Fee_Class.C_ID = '" + this.comboBox1.SelectedValue + "')", this.lstv_fee);



            try
            {
                this.SYS.Filllist_DataView("SELECT FINE_HISTORY.FINE_ID, student.s_name, student.ADMISSION_NO, Fee_Head.Fee_head, FINE_HISTORY.FINE_DATE, FINE_HISTORY.FINE_AMOUNT, FINE_HISTORY.FEE_MONTH FROM FINE_HISTORY INNER JOIN Fee_Head ON FINE_HISTORY.Fee_head_id = Fee_Head.Fee_head_id INNER JOIN student ON FINE_HISTORY.S_ID = student.s_id WHERE FINE_HISTORY.c_id=" + comboBox1.SelectedValue + " AND FINE_HISTORY.SessionID='" + SYSTEMSETTING.sessionid + "' AND FEE_MONTH='" + dpAe.Text + "'", this.lstv_Student);
                if (this.fee_Class_updateTableAdapter.Connection == null || this.fee_Class_updateTableAdapter.Connection.State == ConnectionState.Closed)
                {
                    this.fee_Class_updateTableAdapter.Connection = SYS.db_connect();
                }
                this.fee_Class_updateTableAdapter.Fill(this.report_DataSet_new.Fee_Class_update, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(comboBox1.SelectedValue.ToString(), typeof(decimal))))));
            }
            catch (System.Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void combo_Emp()
        {
            try
            {

                SYSTEMSETTING SYS = new SYSTEMSETTING();
                SYS.comboFill(this.comboBox1, "select * from class order by c_id", "class", "c_name", "c_id");
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
                    string branchId = SYSTEMSETTING.branch_ID ?? "";
                    string sessionId = SYSTEMSETTING.sessionid ?? "";

                    decimal branchNum = 0;
                    bool hasBranch = decimal.TryParse(branchId, out branchNum) && branchNum > 0;
                    decimal sessionNum = 0;
                    bool hasSession = decimal.TryParse(sessionId, out sessionNum) && sessionNum > 0;

                    string query = "Select * from student where c_id ='" + classId + "' and active='true' ";
                    if (!string.IsNullOrEmpty(shift))
                    {
                        query += "AND SHIFT ='" + shift.Replace("'", "''") + "' ";
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

                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter objAdptr1 = new SqlDataAdapter();
                    objAdptr1.SelectCommand = cmd;
                    DataSet objDtset1 = new DataSet();
                    objAdptr1.Fill(objDtset1, "student");
                    foreach (DataRow Student_ in objDtset1.Tables[0].Rows)
                    {
                        string fmQuery = "Select FEE_MONTH,C_ID,FEE_MASTER_ID,PAID,REC_AMOUNT from FEE_MASTER WHERE C_ID ='" + classId + "' and FEE_MONTH='" + dpAe.Text.Replace("'", "''") + "' and s_id ='" + Student_["s_id"].ToString() + "' ";
                        if (hasSession)
                        {
                            fmQuery += "and SESSIONID='" + sessionNum + "' ";
                        }
                        if (hasBranch)
                        {
                            fmQuery += "and branch_id='" + branchNum + "' ";
                        }
                        SqlCommand cmddr = new SqlCommand(fmQuery, con);
                        SqlDataReader dr = cmddr.ExecuteReader();
                        bool exists = false;
                        string existingMasterId = "";
                        string existingPaid = "";
                        decimal existingRecAmt = 0;
                        bool hasRecAmt = false;
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
                            bool isUnposted = hasRecAmt && existingRecAmt == 0 && string.IsNullOrEmpty(existingPaid);
                            if (isUnposted)
                            {
                                SqlCommand delDetail = new SqlCommand("DELETE FROM FEE_DETAIL WHERE FEE_MASTER_ID = '" + existingMasterId + "' AND branch_id = '" + branchNum + "' AND SessionID = '" + sessionNum + "'", con);
                                delDetail.ExecuteNonQuery();
                                SqlCommand delMaster = new SqlCommand("DELETE FROM FEE_MASTER WHERE FEE_MASTER_ID = '" + existingMasterId + "' AND branch_id = '" + branchNum + "' AND SessionID = '" + sessionNum + "'", con);
                                delMaster.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("Voucher already generated for this month.");
                                continue;
                            }
                        }

                        _class.FEE feeGen = new _class.FEE();
                        string studentid = "";
                        if (checkBox1.Checked == true)
                        {
                            studentid = txtstudentid.Text;
                        }
                        else
                        {
                            studentid = "";
                        }
                        feeGen.generatefee(comboBox1.SelectedValue.ToString(), dpAe.Text, cmbshift.SelectedValue.ToString(), studentid, txtduedate.Text, txtremarks.Text);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());

                    //clsCon.cn.Close();
                }
                finally
                {



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



        private void button3_Click(object sender, EventArgs e)
        {
                
            
            
            try
            {
                Frm_Vouchers frm = new Frm_Vouchers();
                frm.classid = comboBox1.SelectedValue.ToString();
                frm.feemonth = dpAe.Text.ToString();
                frm.param = "month";
                frm.section = cmbsection.SelectedValue.ToString();
                frm.shift = cmbshift.SelectedValue.ToString();

                frm.Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

           

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
            frm.param = "FeeGenerate";
            frm.Classid = comboBox1.SelectedValue.ToString();
            frm.Shift = cmbshift.SelectedValue.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFIne();
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

        private void txtremarks_TextChanged(object sender, EventArgs e)
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
                    SaveBranchVoucherNote(branchToSave, this.txtremarks.Text);
                }
            }
            catch { }
        }

        private void Frm_generatefee_Activated(object sender, EventArgs e)
        {
            try
            {
                string activeBranch = SYSTEMSETTING.branch_ID;
                if (!string.IsNullOrEmpty(activeBranch) && activeBranch != _currentBranchId)
                {
                    SaveCurrentBranchVoucherNote();
                    _currentBranchId = activeBranch;
                    LoadBranchVoucherNote(_currentBranchId);
                }
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
                            txtremarks.Text = result.ToString();
                            return;
                        }
                    }
                }

                txtremarks.Text = DefaultVoucherNote;
            }
            catch
            {
                txtremarks.Text = DefaultVoucherNote;
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
