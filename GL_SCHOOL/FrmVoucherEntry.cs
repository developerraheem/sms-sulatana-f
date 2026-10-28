using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GL_SCHOOL
{
    public partial class FrmVoucherEntry : Form
    {
        public FrmVoucherEntry()
        {
            InitializeComponent();
        }
        Cls_db db = new Cls_db();
        string newID, editID;// newID for New ID  and editID for Delete & Edit
       
        private void Load_Accounts()
        {
            db.connCheck();

            try
            {
                OleDbCommand cmd = db.cn.CreateCommand();
                cmd.CommandText = "SELECT ACCOUNT_CODE,ACCOUNT_CODE+' - '+ACCOUNT_DESC as acc_desc from ACT_MASTER";
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ACT_MASTER");
                DataTable dt = ds.Tables["ACT_MASTER"];
                lstmaingroup.DataSource = dt;
                lstmaingroup.DisplayMember = "acc_desc";
                lstmaingroup.ValueMember = "ACCOUNT_CODE";


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {

                db.cn.Close();
            }
          


        }

        private void Search_Accounts()
        {
            db.connCheck();

            try
            {
                OleDbCommand cmd = db.cn.CreateCommand();
                cmd.CommandText = "SELECT ACCOUNT_CODE, ACCOUNT_DESC from ACT_MASTER where ACCOUNT_CODE='"+ txtacc_code.Text +"'";
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtacc_dsc.Text = dr["ACCOUNT_DESC"].ToString();
                    txtrefno.Focus();
                }
                else
                {
                    MessageBox.Show("No Account Found!");
                    txtacc_code.Text = "";
                    txtacc_dsc.Text = "";
                    txtacc_code.Focus();
                }
                dr.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {

                db.cn.Close();
            }
        }

        private void Load_VoucherTYpes()
        {
            this.db.comboFill(this.cmbvouchertype, "select VCH_TYPE,VCH_TYPE+ '-' +VCH_DESC as abc from ACT_VOUCHER_TYPES", "ACT_VOUCHER_TYPES", "abc", "VCH_TYPE");
        }

        private void FrmVoucherEntry_Load(object sender, EventArgs e)
        {
            Load_Accounts();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PnlSearch.Visible = false;
        }

        private void lstmaingroup_KeyPress(object sender, KeyPressEventArgs e)
        {
           txtacc_code.Text  = Convert.ToString(lstmaingroup.SelectedValue);
           txtacc_dsc.Text = lstmaingroup.Text;
           Search_Accounts();
           PnlSearch.Visible = false;
        }

        private void cmbvouchertype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtacc_code.Focus();
            }
        }

        private void txtacc_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtacc_code.Text =="")
            {
                PnlSearch.Visible = true;
                lstmaingroup.Focus();
            }
            else if (e.KeyChar == (char)13 && txtacc_code.Text != "")
            {
                Search_Accounts();

            }
        }

        private void txtrefno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtparticulars.Focus();
            }
        }

        private void txtparticulars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cmbtype.Focus();
            }
        }



        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Want to Add Amount ?", "Confirm Add", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int newstock;
                    string desc = "";
                    newstock = 0;
                    int totalamount = 0;
                    ListViewItem listitem = new ListViewItem();
                    listitem.Text = txtacc_code.Text;
                    listitem.SubItems.Add(txtacc_dsc.Text);
                    listitem.SubItems.Add(txtparticulars.Text);
                    if (cmbtype.Text == "Debit")
                    {
                        listitem.SubItems.Add(txtamount.Text);
                        listitem.SubItems.Add("0");
                    }
                    else if (cmbtype.Text == "Credit")
                    {
                        listitem.SubItems.Add("0");
                        listitem.SubItems.Add(txtamount.Text);
                    }
                    
                    ListView1.Items.Add(listitem);
                    txtacc_dsc.Text = "";
                    txtacc_code.Text = "";
                    txtacc_code.Focus();
                    

                }
                else
                {
                    
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
           
            try
            {
                decimal gtotal = 0;
                foreach (ListViewItem lstItem in ListView1.Items)
                {
                    gtotal += decimal.Parse(lstItem.SubItems[3].Text);
                }
                txtdr.Text = Convert.ToString(gtotal);
                txtdr.Text = string.Format("{0:0,0}", gtotal);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            // Calculate Total quatity
            try
            {
                decimal qty = 0;
                foreach (ListViewItem Lstitem in ListView1.Items)
                {
                    qty += decimal.Parse(Lstitem.SubItems[4].Text);
                }
                txtCR.Text = Convert.ToString(qty);
                txtCR.Text = string.Format("{0:0,0}", qty);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            try
            {
                string.Format("{0}", txtCR.Text);
                string.Format("{0}", txtdr.Text);
                txtdiffr.Text = (int.Parse(txtdr.Text) - int.Parse(txtCR.Text)).ToString();
            }
            catch (Exception exp)
            {
                //  MessageBox.Show(exp.ToString());

            }
        }

        private void cmbtype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtamount.Focus();
            }
        }

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnadd.Focus();
            }
        }

        private void lstmaingroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtacc_code.Text = Convert.ToString(lstmaingroup.SelectedValue);
            txtacc_dsc.Text = lstmaingroup.Text;
            Search_Accounts();
            PnlSearch.Visible = false;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            if (btnnew.Text == "Add")
            {
                // txtgroupCode.Enabled = true;
                //txtgroupCode.Focus();
                btnnew.Text = "Save";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                Load_VoucherTYpes();
                GetVoucherNo();
                cmbvouchertype.Focus();
            }
            else if (btnnew.Text == "Save")
            {
                if (txtvchno.TextLength > 0 && txtamount.TextLength > 0)
                {
                    try
                    {
                        decimal DRAmount = 0;
                        decimal CRAmount = 0;
                        foreach (ListViewItem lstItem in ListView1.Items)
                        {
                            DRAmount += decimal.Parse(lstItem.SubItems[3].Text);
                            CRAmount += decimal.Parse(lstItem.SubItems[4].Text);
                        }

                        if (DRAmount == CRAmount)
                        {
                            SaveVoucherMaster();
                        }
                        else
                        {
                            MessageBox.Show("Debit/Credit Amount Not Matched!");
                        }

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.ToString());
                    }

                }
                else
                {
                    MessageBox.Show("Not Enough Values");
                }

                
            }

        }
        private void SaveVoucherMaster()
        {
            db.cn.Open();
            db.connCheck();
            OleDbCommand cmd = db.cn.CreateCommand();
            OleDbTransaction trans = db.cn.BeginTransaction();
            cmd.Connection = db.cn;
            cmd.Transaction = trans;
            try
            {
                cmd.CommandText = "Insert into ACT_VOUCHER_MASTER(VCH_HEAD_ID,VOUCHER_NO,VCH_TYPE,VCH_DATE,ENTRY_DATE)VALUES('" + newID.ToString() + "','" + txtvchno.Text + "','" + cmbvouchertype.SelectedValue.ToString() + "','" + txtvchdate.Text + "','" + System.DateTime.Today.ToShortDateString() + "')";
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    foreach (ListViewItem lstItem in ListView1.Items)
                    {
                        cmd.CommandText = "Insert into ACT_VOUCHER_DETAIL(VCH_HEAD_ID,ACCOUNT_CODE,PARTICULAR,DABIT,CREDIT)VALUES('" + newID.ToString() + "','" + lstItem.SubItems[0].Text.ToString() + "','" + lstItem.SubItems[2].Text.ToString() + "','" + lstItem.SubItems[3].Text.ToString() + "','" + lstItem.SubItems[4].Text.ToString() + "')";
                        a = cmd.ExecuteNonQuery();
                        
                    }

                }
                trans.Commit();
                if (a > 0)
                        {
                            MessageBox.Show("Voucher No '"+ txtvchno.Text +"' Generated Succesfuly!" );
                            clear();
                        }
            }
            catch (Exception ex)
            {
                try
                {
                    trans.Rollback();
                    
                }
                catch (Exception)
                {
                   
                }

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                db.cn.Close();
            }
        }

        private void GetVoucherNo()
        {
            try
            {

                int myID;
                db.connCheck();
                OleDbCommand cmddr = new OleDbCommand("select max(VCH_HEAD_ID) as ids from ACT_VOUCHER_MASTER", db.cn);
                OleDbDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        newID = "1";
                        txtvchno.Text = cmbvouchertype.SelectedValue.ToString() + newID.PadLeft(5, '0');
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                        newID = myID.ToString();
                        txtvchno.Text = cmbvouchertype.SelectedValue.ToString() + newID.PadLeft(5, '0');
                    }

                }
                dr.Close();
                db.cn.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        private void cmbvouchertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetVoucherNo();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {

            clear();
            
        }
        private void clear()
        {
            txtvchno.Text = "";
            txtacc_code.Text = "";
            txtacc_dsc.Text = "";
            txtrefno.Text = "";
            txtparticulars.Text = "";
            txtamount.Text = "0";
            txtdr.Text = "0";
            txtCR.Text = "0";
            txtdiffr.Text = "0";
            txtcheqno.Text = "";
            btnnew.Text = "Add";
            ListView1.Items.Clear();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }




    }
}
