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
    
    public partial class FrmMainGroup : Form
    {
        Cls_db db = new Cls_db();
        string newID, editID;// newID for New ID  and editID for Delete & Edit
        
        public FrmMainGroup()
        {
            InitializeComponent();
        }
        
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMainGroup_Load(object sender, EventArgs e)
        {
            lstv_Function();
        }
        private void lstv_Function()
        {
            this.db.list_DataView("select MAIN_GROUP_CODE,MAIN_GROUP_DESC from ACT_MAINGROUP", this.lstv_maingroup);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (btnadd.Text == "Add")
            {
                txtgroupdesc.Focus();
                MainGroupCode();
                btnadd.Text = "Save";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (btnadd.Text == "Save")
            {
                MainGroupCode();
                if (txtgroupdesc.TextLength > 0)
                {
                    db.SaveMainGroupCode(txtgroupCode.Text, txtgroupdesc.Text); lstv_Function();
                    txtgroupdesc.Text = "";
                    txtgroupCode.Text = "";
                    btnadd.Text = "Add";
                    btnadd.Focus();
                }
                else
                {
                    MessageBox.Show("Description Must be Filled!");
                    txtgroupdesc.Focus();
                }
                
            }

        }
        private void MainGroupCode()
        {
            try
            {

                int myID;
                db.connCheck();
                OleDbCommand cmddr = new OleDbCommand("select max(MAIN_GROUP_CODE) as ids from ACT_MAINGROUP", db.cn);
                OleDbDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        newID = "01";
                        txtgroupCode.Text = "01";
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                        newID = "0" + myID.ToString();
                        txtgroupCode.Text = newID.ToString();
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

        private void lstv_maingroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtgroupCode.Text  = (this.lstv_maingroup.Items[lstv_maingroup.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txtgroupdesc.Text = (this.lstv_maingroup.Items[lstv_maingroup.FocusedItem.Index].SubItems[1].Text.Trim());
            btnadd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            btnadd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtgroupdesc.Text = "";
            txtgroupCode.Text = "";
            btnadd.Text = "Add";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtgroupCode.Text.Length > 0)
            {
                db.connCheck();
                OleDbCommand cmddr = new OleDbCommand("Delete  from ACT_MAINGROUP where MAIN_GROUP_CODE ='"+ txtgroupCode.Text +"'", db.cn);
                int a =cmddr.ExecuteNonQuery();
                if (a > 0)
                {

                    MessageBox.Show("Record Deleted","Delete");
                   
                }
                db.cn.Close();
                lstv_Function();
                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            db.connCheck();
            try
            {
                if (txtgroupdesc.TextLength > 0)
                {
                    OleDbCommand cmddr = new OleDbCommand("Update ACT_MAINGROUP set MAIN_GROUP_DESC='" + txtgroupdesc.Text + "' where MAIN_GROUP_CODE ='" + txtgroupCode.Text + "'", db.cn);
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

    }
}
