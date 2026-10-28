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
    public partial class FrmVoucherTypes : Form
    {
        public FrmVoucherTypes()
        {
            InitializeComponent();
        }
        Cls_db db = new Cls_db();
        string newID, editID;// newID for New ID  and editID for Delete & Edit
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVoucherTypes_Load(object sender, EventArgs e)
        {
            lstv_Function();
        }
        private void lstv_Function()
        {
            this.db.list_DataView("select VCH_ID,VCH_TYPE,VCH_DESC from ACT_VOUCHER_TYPES order by VCH_ID", this.lstv_Vouchers);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (btnadd.Text == "Add")
            {
                txtvouchertype.Enabled = true;
                txtvouchertype.Focus();
                btnadd.Text = "Save";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (btnadd.Text == "Save")
            {
                if (txtvouchertype.TextLength > 0 && txtvouchertype.TextLength > 0)
                {
                    db.SaveVouchers(txtvouchertype.Text, txtvoucherdesc.Text);
                    clear();
                    lstv_Function();
                }
            }

        }

        private void clear()
        {
          
            txtvouchertype.Text = "";
            txtvoucherdesc.Text = "";
           btnadd.Text = "Add";
            btnadd.Focus();
            btnadd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void lstv_Vouchers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editID = (this.lstv_Vouchers.Items[lstv_Vouchers.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txtvouchertype.Text = (this.lstv_Vouchers.Items[lstv_Vouchers.FocusedItem.Index].SubItems[1].Text.Trim());
            this.txtvoucherdesc.Text = (this.lstv_Vouchers.Items[lstv_Vouchers.FocusedItem.Index].SubItems[2].Text.Trim());
            btnadd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult ret;
            ret = MessageBox.Show("Are you want to Delete!", "Delete".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                try
                {
                    db.connCheck();
                    OleDbCommand cmddr = new OleDbCommand("Delete *  from ACT_VOUCHER_TYPES where VCH_ID =" + int.Parse(editID) + "", db.cn);
                    int a = cmddr.ExecuteNonQuery();
                    if (a > 0)
                    {

                        MessageBox.Show("Record Deleted", "Delete");

                    }
                    db.cn.Close();
                    lstv_Function();
                }
                catch (Exception)
                {
                    
                    
                }
               
            }
            else
            {
                return;
            }
               

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            db.connCheck();
            try
            {


                OleDbCommand cmddr = new OleDbCommand("Update ACT_VOUCHER_TYPES set VCH_TYPE='" + txtvouchertype.Text + "',VCH_DESC='" + txtvoucherdesc.Text + "' where VCH_ID =" + int.Parse(editID) + "", db.cn);
                    int a = cmddr.ExecuteNonQuery();
                    if (a > 0)
                    {

                        MessageBox.Show("Record Updated", "Modify");


                    }
                
            }
            catch (Exception)
            {


            }
            finally
            {
                db.cn.Close();
                lstv_Function();
            }
        }


    }
}
