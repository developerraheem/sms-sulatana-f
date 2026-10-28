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
    public partial class FrmSubGroup : Form
    {
        public FrmSubGroup()
        {
            InitializeComponent();
        }
        Cls_db db = new Cls_db();
        string newID, editID;// newID for New ID  and editID for Delete & Edit
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSubGroup_Load(object sender, EventArgs e)
        {
            Load_MainGroup();
            lstv_Function();
           
        }
        private void SubGroupCode()
        {
            try
            {

                int myID;
                db.connCheck();
                OleDbCommand cmddr = new OleDbCommand("select max(SUB_GROUP_ID) as ids from ACT_SUBGROUP where MAIN_GROUP_CODE='" + txtgroupCode.Text + "'", db.cn);
                OleDbDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        newID = "1";
                        txtsubgroupcode.Text = txtgroupCode.Text + newID.PadLeft(2, '0');
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                        newID = myID.ToString();
                        txtsubgroupcode.Text = txtgroupCode.Text + newID.PadLeft(2, '0');
                    }

                }
                dr.Close();
                db.cn.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void Load_MainGroup()
        {
            db.connCheck();

            try
            {
                OleDbCommand cmd = db.cn.CreateCommand();
                cmd.CommandText = "SELECT * from ACT_MAINGROUP";
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ACT_MAINGROUP");
                DataTable dt = ds.Tables["ACT_MAINGROUP"];
                lstmaingroup.DataSource = dt;
                lstmaingroup.DisplayMember = "MAIN_GROUP_DESC";
                lstmaingroup.ValueMember = "MAIN_GROUP_CODE";


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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PnlSearch.Hide();
        }

        private void txtgroupCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtgroupCode.Text =="")
            {
                PnlSearch.Visible = true;
                lstmaingroup.Focus();
            }
            else if (e.KeyChar == (char)13 && txtgroupCode.TextLength > 0)
            {
                searchgroupcode();
            }
        }
        private void searchgroupcode()
        {
            db.connCheck();
            try
            {
                OleDbCommand cmddr = new OleDbCommand("select * from ACT_MAINGROUP where MAIN_GROUP_CODE='"+ txtgroupCode.Text +"'", db.cn);
                OleDbDataReader dr = cmddr.ExecuteReader();
                if (dr.Read())
                {
                   // txtgroupCode.Text = dr["MAIN_GROUP_CODE"].ToString();
                    txtgroupdesc.Text = dr["MAIN_GROUP_DESC"].ToString();
                    txtsubgroupdesc.Focus();
                }
                else
                {
                    MessageBox.Show("Main Group Code Not Found!!");
                    txtgroupCode.Text = "";
                    txtgroupdesc.Text = "";
                }
            }
            catch (Exception)
            {


            }
            finally
            {
                db.cn.Close();
                SubGroupCode();
            }
        }

        private void lstmaingroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtgroupCode.Text = lstmaingroup.SelectedValue.ToString();
            txtgroupdesc.Text  = lstmaingroup.Text.ToString();
            txtsubgroupdesc.Focus();
            PnlSearch.Hide();
            SubGroupCode();
        }

        private void lstmaingroup_DoubleClick(object sender, EventArgs e)
        {
            txtgroupCode.Text = lstmaingroup.SelectedValue.ToString();
            txtgroupdesc.Text = lstmaingroup.Text.ToString();
            txtgroupCode.Focus();
            PnlSearch.Hide();
            SubGroupCode();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (btnadd.Text == "Add")
            {
                txtgroupCode.Enabled = true;
                txtgroupCode.Focus();
                btnadd.Text = "Save";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (btnadd.Text == "Save")
            {
                if (txtsubgroupdesc.TextLength > 0 && txtgroupCode.TextLength > 0 && txtsubgroupcode.TextLength > 0)
                {
                    db.SaveSubGroupCode(int.Parse(newID),txtsubgroupcode.Text, txtgroupCode.Text, txtsubgroupdesc.Text);
                    clear();
                    lstv_Function();
                }
            }
        }

        private void clear()
        {
            txtgroupCode.Enabled = false;
            txtgroupdesc.Text = "";
            txtgroupCode.Text = "";
            txtsubgroupcode.Text = "";
            txtsubgroupdesc.Text = "";
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

        private void lstv_Function()
        {
            this.db.list_DataView("select MAIN_GROUP_CODE,SUB_GROUP_CODE,SUB_GROUP_DESC from ACT_SUBGROUP order by MAIN_GROUP_CODE", this.lstv_sub);
        }

        private void txtsubgroupdesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtsubgroupdesc.TextLength>0)
            {
                btnadd.Focus();
            }
        }

        private void lstv_sub_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtgroupCode.Text = (this.lstv_sub.Items[lstv_sub.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txtsubgroupcode.Text = (this.lstv_sub.Items[lstv_sub.FocusedItem.Index].SubItems[1].Text.Trim());
            this.txtsubgroupdesc.Text = (this.lstv_sub.Items[lstv_sub.FocusedItem.Index].SubItems[2].Text.Trim());
          //  searchgroupcode();
            btnadd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            db.connCheck();
            try
            {
                if (txtsubgroupdesc.TextLength > 0)
                {
                    OleDbCommand cmddr = new OleDbCommand("Update ACT_SUBGROUP set SUB_GROUP_DESC='" + txtsubgroupdesc.Text + "' where SUB_GROUP_CODE ='" + txtsubgroupcode.Text + "'", db.cn);
                    int a = cmddr.ExecuteNonQuery();
                    if (a > 0)
                    {

                        MessageBox.Show("Record Updated", "Modify");


                    }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtsubgroupcode.Text.Length > 0)
            {
                db.connCheck();
                OleDbCommand cmddr = new OleDbCommand("Delete  from ACT_SUBGROUP where SUB_GROUP_CODE ='" + txtsubgroupcode.Text + "' and MAIN_GROUP_CODE='"+ txtgroupCode.Text +"'", db.cn);
                int a = cmddr.ExecuteNonQuery();
                if (a > 0)
                {

                    MessageBox.Show("Record Deleted", "Delete");

                }
                db.cn.Close();
                lstv_Function();

            }
        }

    }
}
