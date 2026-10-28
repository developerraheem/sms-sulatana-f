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
    public partial class Frm_FeeEntry : Form
    {
        public Frm_FeeEntry()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        _class.clsODBC clsCon = new School._class.clsODBC();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        _class.clsODBC cls_Con = new School._class.clsODBC();
        SqlCommand cmdForm = new SqlCommand();

        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        List<string> myListofQueries = new List<string>();
        string Query = null;
        Boolean CHECK = false;
        Boolean finetag = false;
        Boolean fine_remove_tag = false;
        private bool isFullyPosted = false;
        private double previousRecAmt = 0;

        private void btnsearch_Click(object sender, EventArgs e)
        {

            if (cmbsearchby.Text == "Voucher No")
            {
                txtreceiptno.Text = "";
                txtreceiptno.Text = txtsearchvalue.Text;
                FeeList_Detail();
                Student_Detail();
                fillFeehead();
                lblfinehead.Text = "";
                finetag = false;
                fine_remove_tag = false;
                this.panel3.Visible = false;
            }

            else if (cmbsearchby.Text == "Admission No")
            {
                DataSet dsAdm = SYS.Show_Query("Select s_id from student where ADMISSION_NO='" + txtsearchvalue.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                if (dsAdm != null && dsAdm.Tables.Count > 0 && dsAdm.Tables[0].Rows.Count > 0)
                {
                    txtstdid.Text = dsAdm.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    SYS.setMessageBox("No Record Found!", 3);
                }

                DataSet dsVoucher = SYS.Show_Query("Select TOP 1 FEE_MASTER_ID from FEE_MASTER where s_id='" + txtstdid.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' and SessionID='" + SYSTEMSETTING.sessionid + "' ORDER BY FEE_MASTER_ID DESC");
                if (dsVoucher != null && dsVoucher.Tables.Count > 0 && dsVoucher.Tables[0].Rows.Count > 0)
                {
                    txtreceiptno.Text = dsVoucher.Tables[0].Rows[0][0].ToString();
                }
                FeeList_Detail();
                Student_Detail();
                fillFeehead();
                lblfinehead.Text = "";
                finetag = false;
                this.panel3.Visible = false;
            }
            else if (cmbsearchby.Text == "BARCODE")
            {
                DataSet dsBc = SYS.Show_Query("Select FEE_MASTER_ID from FEE_MASTER where BARCODE='*" + txtsearchvalue.Text + "*' and branch_id='" + SYSTEMSETTING.branch_ID + "' and SessionID='" + SYSTEMSETTING.sessionid + "'");
                if (dsBc != null && dsBc.Tables.Count > 0 && dsBc.Tables[0].Rows.Count > 0)
                {
                    txtreceiptno.Text = dsBc.Tables[0].Rows[0][0].ToString();
                }
                if (txtreceiptno.Text == "")
                {
                    txtreceiptno.Text = "0";
                }
                FeeList_Detail();
                Student_Detail();
                fillFeehead();
                lblfinehead.Text = "";
                finetag = false;
                this.panel3.Visible = false;
                txtsearchvalue.Text = "";
            }
            else
            {
                SYS.setMessageBox("Please Select Valid Value", 3);
            }
            try
            {
                if (!isFullyPosted)
                {
                    DateTime date = Convert.ToDateTime(txtdate.Text);
                    DateTime enddate = Convert.ToDateTime(txtduedate.Text);

                    if (date > enddate)
                    {
                        double fine = 0;
                        double.TryParse(txttfine.Text, out fine);
                        if (fine > 0)
                        {
                            txtamountpayable.Text = (Convert.ToDouble(txtamountpayable.Text) + fine).ToString();
                        }
                        double rec = 0;
                        double.TryParse(txtamount.Text, out rec);
                        double bal = 0;
                        double.TryParse(txtbalance.Text, out bal);
                        if (bal <= 0 && rec > 0 && rec == Convert.ToDouble(txtamountpayable.Text) - fine)
                        {
                            txtamount.Text = txtamountpayable.Text;
                        }
                        else if (rec <= 0)
                        {
                            txtamount.Text = txtamountpayable.Text;
                        }
                    }
                }

                if (isFullyPosted)
                {
                    btnSave.Enabled = false;
                    txtamount.Enabled = false;
                    SYS.setCreateError("Voucher Already Posted");
                }
                else
                {
                    btnSave.Enabled = true;
                    txtamount.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Fill_Class()
        {
            try
            {
                SYS.comboFill(this.cmbbank, "SELECT BANK_ID,BANK_NAME FROM BANKS", "BANKS", "BANK_NAME", "BANK_ID");
            }
            catch (Exception exp)
            {

            }

        }

        private void Frm_FeeEntry_Load(object sender, EventArgs e)
        {
            Fill_Class();

        }

        private void fillFeehead()
        {
            string qHeads = "SELECT FEE_DETAIL.FEE_MONTH, ISNULL(Fee_Head.Fee_head, 'Fee Head') AS Fee_head, FEE_DETAIL.AMOUNT, FEE_DETAIL.RECEIVED_AMOUNT, FEE_DETAIL.BALANCE " +
                            "FROM FEE_DETAIL LEFT JOIN Fee_Head ON FEE_DETAIL.Fee_head_id = Fee_Head.Fee_head_id " +
                            "WHERE (FEE_DETAIL.FEE_MASTER_ID = '" + txtreceiptno.Text + "') " +
                            "  AND (FEE_DETAIL.SESSIONID = '" + SYSTEMSETTING.sessionid + "' OR FEE_DETAIL.SESSIONID IS NULL) " +
                            "  AND (FEE_DETAIL.branch_id = '" + SYSTEMSETTING.branch_ID + "' OR FEE_DETAIL.branch_id IS NULL) " +
                            "ORDER BY FEE_DETAIL.FEE_DETAIL_ID";
            SYS.Filllist_DataView(qHeads, lstv_feedetail);
            try
            {
                decimal qty = 0;
                foreach (ListViewItem Lstitem in lstv_feedetail.Items)
                {
                    decimal d = 0;
                    if (decimal.TryParse(Lstitem.SubItems[2].Text, out d))
                    {
                        qty += d;
                    }
                }
                lbltotalamount.Text = Convert.ToString(qty);
            }
            catch (Exception exp)
            {
                //  MessageBox.Show(exp.ToString());
            }

        }

        public string Class_ID
        {
            get { return txtclassid.Text; }
            set { txtclassid.Text = value; }
        }
        //public string FeeMonth
        //{
        //    get { return txtmonth.Text; }
        //    set { txtmonth.Text = value; }
        //}
        public string RollNo
        {
            get { return txtrollno.Text; }
            set { txtrollno.Text = value; }
        }
        private void FeeList_Detail()
        {
            isFullyPosted = false;
            previousRecAmt = 0;
            try
            {
                DataSet dsFM = SYS.Show_Query("Select * from Fee_Master where FEE_MASTER_ID='" + txtreceiptno.Text + "' AND SESSIONID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                if (dsFM != null && dsFM.Tables.Count > 0 && dsFM.Tables[0].Rows.Count > 0)
                {
                    DataRow Row = dsFM.Tables[0].Rows[0];
                    txtstdid.Text = Row["s_id"].ToString();
                    txtclassid.Text = Row["c_id"].ToString();
                    txtreceiptno.Text = Row["FEE_MASTER_ID"].ToString();

                    double recAmt = 0;
                    if (Row["REC_AMOUNT"] != DBNull.Value && !string.IsNullOrEmpty(Row["REC_AMOUNT"].ToString()))
                    {
                        double.TryParse(Row["REC_AMOUNT"].ToString(), out recAmt);
                    }

                    // Check actual payments from FEE_HISTORY if REC_AMOUNT is 0
                    string qHist = "SELECT SUM(CONVERT(FLOAT, PAID_AMOUNT)) FROM FEE_HISTORY WHERE VOUCHER_NO = '" + txtreceiptno.Text + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' AND BRANCH_ID = '" + SYSTEMSETTING.branch_ID + "'";
                    DataSet dsHist = SYS.Show_Query(qHist);
                    if (dsHist != null && dsHist.Tables.Count > 0 && dsHist.Tables[0].Rows.Count > 0)
                    {
                        object hVal = dsHist.Tables[0].Rows[0][0];
                        if (hVal != DBNull.Value && !string.IsNullOrEmpty(hVal.ToString()))
                        {
                            double hAmt = 0;
                            if (double.TryParse(hVal.ToString(), out hAmt) && hAmt > recAmt)
                            {
                                recAmt = hAmt;
                            }
                        }
                    }

                    double recvAmt = 0;
                    if (Row["RECEIVABLE_AMOUNT"] != DBNull.Value && !string.IsNullOrEmpty(Row["RECEIVABLE_AMOUNT"].ToString()))
                    {
                        double.TryParse(Row["RECEIVABLE_AMOUNT"].ToString(), out recvAmt);
                    }

                    double balAmt = 0;
                    if (Row["BALANCE"] != DBNull.Value && !string.IsNullOrEmpty(Row["BALANCE"].ToString()))
                    {
                        double.TryParse(Row["BALANCE"].ToString(), out balAmt);
                    }
                    else
                    {
                        balAmt = recvAmt - recAmt;
                    }

                    previousRecAmt = recAmt;
                    txtamountpayable.Text = recvAmt.ToString();

                    string paidTag = Row["PAID"] != DBNull.Value ? Row["PAID"].ToString().Trim() : "";
                    string statusTag = Row["STATUS"] != DBNull.Value ? Row["STATUS"].ToString().Trim() : "";

                    // A voucher is genuinely already fully posted only when balance is zero and recAmt >= recvAmt
                    isFullyPosted = (balAmt <= 0 && recAmt >= recvAmt && recvAmt > 0 && (paidTag == "Y" || statusTag == "Y"));

                    if (isFullyPosted)
                    {
                        txtamount.Text = recAmt.ToString();
                        txtbalance.Text = "0";
                        btnSave.Enabled = false;
                        txtamount.Enabled = false;
                    }
                    else if (recAmt > 0)
                    {
                        // Partially paid voucher: Cash Received defaults to the remaining unpaid balance to settle
                        txtamount.Text = balAmt.ToString();
                        txtbalance.Text = "0";
                        btnSave.Enabled = true;
                        txtamount.Enabled = true;
                    }
                    else
                    {
                        // Unpaid voucher: Cash Received defaults to the full receivable amount
                        txtamount.Text = recvAmt.ToString();
                        txtbalance.Text = "0";
                        btnSave.Enabled = true;
                        txtamount.Enabled = true;
                    }

                    txtstatus.Text = paidTag;
                    txttag.Text = Row["MULTITAG"] != DBNull.Value ? Row["MULTITAG"].ToString() : "";
                    txtduedate.Text = Row["DUE_DATE"] != DBNull.Value ? Row["DUE_DATE"].ToString() : "";
                    txttfine.Text = Row["FINE_AFTER_DUE_DATE"] != DBNull.Value ? Row["FINE_AFTER_DUE_DATE"].ToString() : "0";
                    txtamount.Focus();
                    txtfeemonth.Text = Row["FEE_MONTH"] != DBNull.Value ? Row["FEE_MONTH"].ToString() : "";
                }
                else
                {
                    MessageBox.Show("No Record Found or Invalid Voucher No");
                }

            }
            catch (Exception exp)
            {
            }
        }

        private void Student_Detail()
        {
            try
            {
                if (string.IsNullOrEmpty(txtstdid.Text)) return;
                string qStd = "Select * from student where s_id='" + txtstdid.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY CASE WHEN SessionID = '" + SYSTEMSETTING.sessionid + "' THEN 1 ELSE 2 END, s_id";
                DataSet dsStd = SYS.Show_Query(qStd);
                if (dsStd != null && dsStd.Tables.Count > 0 && dsStd.Tables[0].Rows.Count > 0)
                {
                    DataRow Row = dsStd.Tables[0].Rows[0];
                    txtstdname.Text = Row["s_name"] != DBNull.Value ? Row["s_name"].ToString() : "";
                    txtfname.Text = Row["f_name"] != DBNull.Value ? Row["f_name"].ToString() : "";
                    txtrollno.Text = Row["roll_no"] != DBNull.Value ? Row["roll_no"].ToString() : "";
                    txtsection.Text = Row["SECTION_ID"] != DBNull.Value ? Row["SECTION_ID"].ToString() : "";
                    txtadmissionno.Text = Row["ADMISSION_NO"] != DBNull.Value ? Row["ADMISSION_NO"].ToString() : "";
                    txtsession.Text = Row["SessionID"] != DBNull.Value ? Row["SessionID"].ToString() : "";
                    txtshift.Text = Row["SHIFT"] != DBNull.Value ? Row["SHIFT"].ToString() : "";
                    txtcategory.Text = Row["TYPE"] != DBNull.Value ? Row["TYPE"].ToString() : "";
                    txtdiscount.Text = Row["CONCESSION_FEE"] != DBNull.Value ? Row["CONCESSION_FEE"].ToString() : "";

                    string cid = Row["c_id"] != DBNull.Value ? Row["c_id"].ToString() : txtclassid.Text;
                    if (!string.IsNullOrEmpty(cid))
                    {
                        DataSet dsClass = SYS.Show_Query("Select c_name from class where c_id='" + cid + "'");
                        if (dsClass != null && dsClass.Tables.Count > 0 && dsClass.Tables[0].Rows.Count > 0)
                        {
                            txtclass.Text = dsClass.Tables[0].Rows[0]["c_name"].ToString();
                        }
                    }
                }
            }
            catch (Exception exp)
            {
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            rptFee rpt = new rptFee(this);
            rpt.Show();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                //this.dataGridView1.Refresh();
                this.Refresh();
            }
            catch (Exception exp)
            {

            }
            finally
            {

            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double payable = 0;
                double.TryParse(txtamountpayable.Text, out payable);
                double entered = 0;
                double.TryParse(txtamount.Text, out entered);

                double totalRec = 0;
                if (entered > (payable - previousRecAmt) && entered <= payable && previousRecAmt > 0)
                {
                    totalRec = entered;
                }
                else
                {
                    totalRec = previousRecAmt + entered;
                }
                double rem = payable - totalRec;
                if (rem < 0) rem = 0;
                txtbalance.Text = rem.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Frm_Vouchers frm = new Frm_Vouchers();
            frm.voucherno = txtreceiptno.Text;
            frm.param = "voucherno";
            frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                rs = SYS.Show_Query("Select * from Fee_Master where FEE_MASTER_ID='" + txtreceiptno.Text + "' AND SESSIONID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                if (rs.Tables[0].Rows.Count > 0)
                {
                    DataRow Row = rs.Tables[0].Rows[0];
                    double recAmt = 0;
                    if (Row["REC_AMOUNT"] != DBNull.Value) double.TryParse(Row["REC_AMOUNT"].ToString(), out recAmt);
                    double recvAmt = 0;
                    if (Row["RECEIVABLE_AMOUNT"] != DBNull.Value) double.TryParse(Row["RECEIVABLE_AMOUNT"].ToString(), out recvAmt);
                    double balAmt = 0;
                    if (Row["BALANCE"] != DBNull.Value) double.TryParse(Row["BALANCE"].ToString(), out balAmt);
                    else balAmt = recvAmt - recAmt;
                    string paidTag = Row["PAID"] != DBNull.Value ? Row["PAID"].ToString().Trim() : "";
                    string statusTag = Row["STATUS"] != DBNull.Value ? Row["STATUS"].ToString().Trim() : "";

                    bool isPosted = (balAmt <= 0 && recAmt >= recvAmt && recvAmt > 0 && (paidTag == "Y" || statusTag == "Y"));
                    if (isPosted)
                    {
                        SYS.setCreateError("Voucher Already Posted");
                        btnSave.Enabled = false;
                        txtamount.Enabled = false;
                        return;
                    }
                }

                if (txtamount.Text.Length > 0)
                {
                    //if (int.Parse(txtamountpayable.Text) == int.Parse(lbltotalamount.Text))
                    //{

                    //}
                    //else
                    //{
                    //    SYS.setMessageBox("Voucher is Unbalance! Please try later.", 3);
                    //    return;

                    //}


                    // Late Fee Fine

                    DateTime date = Convert.ToDateTime(txtdate.Text);
                    DateTime dbmonth = Convert.ToDateTime(txtfeemonth.Text);
                    int tdays = 0;
                    int day = ((int)date.Day);
                    int month = ((int)date.Month);
                    dbmonth = dbmonth.AddMonths(1);

                    if (txttag.Text == "Y")
                    {
                        // in multiple fee fine will be charged according to DUEDATE 

                        DateTime enddate = Convert.ToDateTime(txtduedate.Text);

                        #region MultipleMonthFee

                        if (date > enddate && finetag == false)
                        {
                            //this.panel3.Visible = true;
                            //cmbfeetype.Focus();
                            //SYS.comboFill(this.cmbfeetype, "select Fee_head_id,Fee_head from Fee_Head where Category='FINE' and branch_id='" + SYSTEMSETTING.branch_ID + "'", "Fee_Head", "Fee_head", "Fee_head_id");
                           // txtamountpayable.Text = (Convert.ToDouble(txtamountpayable.Text) + Convert.ToDouble(txttfine.Text)).ToString();

                        }
                        //else
                        //{

                        if (MessageBox.Show("You are going to receive  '" + txtamount.Text + "/-' amount. Are you sure? ", "Fee Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            _class.FEE fee = new _class.FEE();
                            bool a = false;
                            double Amountpayable = Convert.ToDouble(txtamountpayable.Text);
                            double amountreceiable = Convert.ToDouble(txtamount.Text);

                            finetag = false;
                            a = fee.submitfeeSingle(Convert.ToDouble(txtamount.Text), txtreceiptno.Text, finetag, Convert.ToDateTime(txtdate.Text), Convert.ToDateTime(txtduedate.Text), cmbbank.SelectedValue.ToString(), txtscrollno.Text);
                            if (a == true)
                            {
                                SYS.setMessageBox("Fee Received Succesfully!", 1);
                                txtsearchvalue.Text = "";
                                btnSave.Enabled = false;
                                txtsearchvalue.Focus();

                            }


                            //if (Amountpayable - amountreceiable != 0)
                            //{
                            //    SYS.setMessageBox("InCorrect Amount", 3);
                            //    txtamount.Focus();
                            //    return;
                            //}
                            //else
                            //{
                            //}

                        }
                        // }
                        #endregion


                    }
                    else
                    {
                        // single moth fee days. fine will be charged after 15 days. 5 rs per day
                        tdays = 15;

                        #region SingleMonthFee

                        //if (day > tdays && finetag == false)
                        if (day > tdays && fine_remove_tag == false && finetag == false)
                        {
                            this.panel3.Visible = true;
                            cmbfeetype.Focus();
                            SYS.comboFill(this.cmbfeetype, "select Fee_head_id,Fee_head from Fee_Head where Category='FINE'", "Fee_Head", "Fee_head", "Fee_head_id");
                        }
                        else
                        {

                            if (MessageBox.Show("You are going to receive  '" + txtamount.Text + "/-' amount. Are you sure? ", "Fee Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                _class.FEE fee = new _class.FEE();
                                bool a = false;
                                double Amountpayable = Convert.ToDouble(txtamountpayable.Text);
                                double amountreceiable = Convert.ToDouble(txtamount.Text);
                                finetag = false;
                                a = fee.submitfeeSingle(Convert.ToDouble(txtamount.Text), txtreceiptno.Text, finetag, Convert.ToDateTime(txtdate.Text), Convert.ToDateTime(txtduedate.Text), cmbbank.SelectedValue.ToString(), txtscrollno.Text);
                                if (a == true)
                                {
                                    SYS.setMessageBox("Fee Received Succesfully!", 1);
                                    txtsearchvalue.Text = "";
                                    btnSave.Enabled = false;
                                    txtsearchvalue.Focus();
                                }

                                //if (Amountpayable - amountreceiable != 0)
                                //{
                                //    SYS.setMessageBox("InCorrect Amount", 3);
                                //    txtamount.Focus();
                                //    return;
                                //}
                                //else
                                //{
                                //    a = fee.submitfeeSingle(Convert.ToDouble(txtamount.Text), txtreceiptno.Text, finetag, Convert.ToDateTime(txtdate.Text), Convert.ToDateTime(txtduedate.Text), cmbbank.SelectedValue.ToString(), txtscrollno.Text);
                                //    if (a == true)
                                //    {
                                //        SYS.setMessageBox("Fee Received Succesfully!", 1);
                                //        txtsearchvalue.Text = "";
                                //        btnSave.Enabled = false;
                                //        txtsearchvalue.Focus();
                                //    }
                                //}

                            }
                        }
                        #endregion


                    }

                    fillFeehead();

                    // }

                }

                else
                {
                    MessageBox.Show("Please Enter Paid Amount!");
                    txtamount.Focus();

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);


            }
            finally
            {


            }
        }

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
            if (e.KeyChar == (char)13 && txtamount.TextLength > 0)
            {
                btnSave.Focus();

            }

        }

        private void txtsearchvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbsearchby.Text == "Voucher No" && e.KeyChar == (char)13)
            //if (e.KeyChar == (char)13)
            {
                btnsearch.Focus();
            }
            else if (cmbsearchby.Text == "Admission No" && e.KeyChar == (char)13 && txtsearchvalue.Text.Length > 0)
            {
                //Frmfind_student frm = new Frmfind_student(this);
                //frm.param = "VoucherPrint";
                //frm.Classid = cmbclass.SelectedValue.ToString();
                //frm.Shift = cmbshift.SelectedValue.ToString();
                //frm.ShowDialog();
                btnsearch.Focus();
            }
            else if (cmbsearchby.Text == "BARCODE" && e.KeyChar == (char)13 && txtsearchvalue.Text.Length > 0)
            {
                rs = SYS.Show_Query("Select FEE_MASTER_ID from FEE_MASTER where BARCODE='*" + txtsearchvalue.Text + "*' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                if (rs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Row in rs.Tables[0].Rows)
                    {
                        txtreceiptno.Text = Row[0].ToString();
                    }
                }
                FeeList_Detail();
                fillFeehead();
                Student_Detail();
                lblfinehead.Text = "";
                finetag = false;
                this.panel3.Visible = false;
            }
            else
            {
                //   btnsearch.Focus();
            }



        }

        private void txtamount_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtamount_Leave(object sender, EventArgs e)
        {
            try
            {
                double payable = 0;
                double.TryParse(txtamountpayable.Text, out payable);
                double entered = 0;
                double.TryParse(txtamount.Text, out entered);

                double totalRec = 0;
                if (entered > (payable - previousRecAmt) && entered <= payable && previousRecAmt > 0)
                {
                    totalRec = entered;
                }
                else
                {
                    totalRec = previousRecAmt + entered;
                }
                double rem = payable - totalRec;
                if (rem < 0) rem = 0;
                txtbalance.Text = rem.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtype.Text == "School")
            {
                cmbbank.Enabled = false;
            }
            else
            {
                cmbbank.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panel3.Visible = false;
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            lblfinehead.Text = cmbfeetype.Text.ToString();
            finetag = true;
            fine_remove_tag = false;
            this.panel3.Visible = false;
            btnSave.Focus();
        }

        private void cmbfeetype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                lblfinehead.Text = cmbfeetype.Text.ToString();
                finetag = true;
                fine_remove_tag = false;
                this.panel3.Visible = false;
                btnSave.Focus();

            }
        }

        private void lnknofine_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //Remove Tag if new admission
            finetag = false;
            fine_remove_tag = true;
            this.panel3.Visible = false;
            btnSave.Focus();
        }

        private void txtdate_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(txtdate.Text);
            DateTime enddate = Convert.ToDateTime(txtduedate.Text);


            if (date > enddate)
            {
                txtamountpayable.Text = (Convert.ToDouble(txtamountpayable.Text) + Convert.ToDouble(txttfine.Text)).ToString();
                txtamount.Text = txtamountpayable.Text;
            }
            else
            {
                FeeList_Detail();
            }
        }

        

    }
}
