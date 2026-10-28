using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class frmUnpostVoucher : Form
    {
        public frmUnpostVoucher()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        List<string> myListofQueries = new List<string>();

        private void frmUnpostVoucher_Load(object sender, EventArgs e)
        {

        }

        private void fillFeehead()
        {
            SYS.Filllist_DataView("SELECT FEE_DETAIL.FEE_MONTH, Fee_Head.Fee_head, FEE_DETAIL.AMOUNT, FEE_DETAIL.RECEIVED_AMOUNT, FEE_DETAIL.BALANCE FROM  FEE_DETAIL INNER JOIN Fee_Head ON FEE_DETAIL.Fee_head_id = Fee_Head.Fee_head_id WHERE (FEE_DETAIL.FEE_MASTER_ID = '" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "')", lstv_feedetail);
            try
            {
                decimal qty = 0;
                foreach (ListViewItem Lstitem in lstv_feedetail.Items)
                {
                    qty += decimal.Parse(Lstitem.SubItems[2].Text);
                }
                lbltotalamount.Text = Convert.ToString(qty);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }

        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            if (txtvoucherno.Text.Length > 0)
            {
                rs = SYS.Show_Query("Select * from FEE_MASTER WHERE FEE_MASTER_ID='" + txtvoucherno.Text + "' and PAID IS not NULL AND SessionID='" + SYSTEMSETTING.sessionid + "'");
                if (rs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Row in rs.Tables[0].Rows)
                    {
                        fillFeehead();
                        btnupost.Enabled = true;


                    }
                }
                else
                {
                    SYS.setMessageBox("Invalid Voucher No or Voucher is not Posted",3);
                    btnupost.Enabled = false;
                }
                
                
            }
            else
            {
                SYS.setMessageBox("Please Enter Voucher No",1);
                txtvoucherno.Focus();
            }
        }

        private void btnupost_Click(object sender, EventArgs e)
        {
            if (txtvoucherno.Text.Length > 0)
            {

                if (MessageBox.Show("Are you sure you want to Unpost Selected Voucher?", "Voucher Unposting", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    bool a = false;
                    string query = "";

                    query = "Update FEE_MASTER set PAID=NULL, STATUS=NULL, REC_AMOUNT=0, SUBMIT_DATE='', BALANCE= RECEIVABLE_AMOUNT WHERE FEE_MASTER_ID='" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "'";
                    myListofQueries.Add(query);

                    query = "Update FEE_DETAIL SET RECEIVED_AMOUNT=0, BALANCE = AMOUNT WHERE FEE_MASTER_ID='" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "'";
                    myListofQueries.Add(query);

                    query = "Delete FROM FINE_HISTORY WHERE FEE_MASTER_ID='" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "'";
                    myListofQueries.Add(query);

                    query = "delete from fee_history where VOUCHER_NO='" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "'";
                    myListofQueries.Add(query);


                    string[] bulkqueries1 = myListofQueries.ToArray();
                    a = SYS.Insert_Query_manualcommit(bulkqueries1);
                    
                    if (a == true)
                    {
                        try
                        {
                            _class.FEE fee = new _class.FEE();
                            fee.RecalculateVoucherArrears(txtvoucherno.Text, SYSTEMSETTING.sessionid);
                        }
                        catch { }
                        SYS.setMessageBox("Voucher Unposted Successfuly!", 1);
                        btnupost.Enabled = false;
                    }
                    else
                    {
                        SYS.setMessageBox("Voucher is not unposted please try later",3);
                        btnupost.Enabled = true;
                    }


                }

            }
            else
            {
                SYS.setMessageBox("Please Enter Voucher No", 1);
                txtvoucherno.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtvoucherno.Text.Length > 0)
            {

                if (MessageBox.Show("Are you sure you want to Delete Selected Voucher?", "Voucher Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    bool a = false;
                    string query = "";

                    query = "Delete from FEE_MASTER WHERE FEE_MASTER_ID='" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "'";
                    myListofQueries.Add(query);

                    query = "Delete from FEE_DETAIL WHERE FEE_MASTER_ID='" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "'";
                    myListofQueries.Add(query);

                    query = "Delete FROM FINE_HISTORY WHERE FEE_MASTER_ID='" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "'";
                    myListofQueries.Add(query);

                    query = "delete from fee_history where VOUCHER_NO='" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "'";
                    myListofQueries.Add(query);

                    string[] bulkqueries1 = myListofQueries.ToArray();
                    a = SYS.Insert_Query_manualcommit(bulkqueries1);

                    if (a == true)
                    {
                        SYS.setMessageBox("Voucher Deleted Successfuly!", 1);
                        btnupost.Enabled = false;
                    }
                    else
                    {
                        SYS.setMessageBox("Voucher is not Deleted please try later", 3);
                        btnupost.Enabled = true;
                    }


                }

            }
            else
            {
                SYS.setMessageBox("Please Enter Voucher No", 1);
                txtvoucherno.Focus();
            }
        }
    }
}
