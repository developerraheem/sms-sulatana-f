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
    public partial class FrmChartofAccounts : Form
    {
        public FrmChartofAccounts()
        {
            InitializeComponent();
        }
        Cls_db db = new Cls_db();
        string newID, editID;// newID for New ID  and editID for Delete & Edit
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChartofAccounts_Load(object sender, EventArgs e)
        {
           
            lstv_Function();
            
        }
        private void Load_MainGroup()
        {
            this.db.comboFill(this.cmbmaingroup, "select MAIN_GROUP_CODE,MAIN_GROUP_CODE+ '-' +MAIN_GROUP_DESC as abc from ACT_MAINGROUP", "ACT_MAINGROUP", "abc", "MAIN_GROUP_CODE");
        }
        private void Load_SubGroup()
        {
            this.db.comboFill(this.cmbsubgroup, "select SUB_GROUP_CODE,SUB_GROUP_CODE+ '-' +SUB_GROUP_DESC as abc from ACT_SUBGROUP where MAIN_GROUP_CODE ='"+ cmbmaingroup.SelectedValue.ToString() +"'", "ACT_SUBGROUP", "abc", "SUB_GROUP_CODE");
        }

        private void cmbmaingroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_SubGroup();
            GetChartofAccCode();
        }

        private void GetChartofAccCode()
        {
            try
            {

                int myID;
                db.connCheck();
                OleDbCommand cmddr = new OleDbCommand("select max(COA_ID) as ids from ACT_MASTER where MAIN_GROUP_CODE='" + cmbmaingroup.SelectedValue.ToString() + "' and SUB_GROUP_CODE='"+ cmbsubgroup.SelectedValue.ToString() +"'", db.cn);
                OleDbDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        newID = "1";
                        txtacccode.Text = cmbmaingroup.SelectedValue.ToString()+ cmbsubgroup.SelectedValue.ToString() + newID.PadLeft(4, '0');
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                        newID = myID.ToString();
                        txtacccode.Text = cmbmaingroup.SelectedValue.ToString() + cmbsubgroup.SelectedValue.ToString() + newID.PadLeft(4, '0');
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

        private void cmbsubgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetChartofAccCode();
            txtaccdesc.Focus();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (btnadd.Text == "Add")
            {
               // txtgroupCode.Enabled = true;
                //txtgroupCode.Focus();
                btnadd.Text = "Save";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                Load_MainGroup();
                Load_SubGroup();
                GetChartofAccCode();
            }
            else if (btnadd.Text == "Save")
            {
                if (txtaccdesc.TextLength > 0)
                {
                    if (this.cmbmaingroup.SelectedIndex != -1 && this.cmbsubgroup.SelectedIndex != -1)
                    {
                        db.SaveChartofAccounts(int.Parse(newID), cmbmaingroup.SelectedValue.ToString(), cmbsubgroup.SelectedValue.ToString(), txtacccode.Text, txtaccdesc.Text, txtopbal.Text);
                        clear();
                        lstv_Function();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Group Code!");
                    }
                    
                   
                }
            }
        }
        private void clear()
        {
            btnadd.Text = "Add";
            btnadd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtaccdesc.Text = "";
            txtopbal.Text = "0";
            txtacccode.Text = "";


        }
        private void lstv_Function()
        {
            this.db.list_DataView("select ACCOUNT_CODE,ACCOUNT_DESC,OP_BALANCE from ACT_MASTER order by ACCOUNT_CODE", this.lstv_coa);
        }

        private void txtaccdesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtopbal.Focus();
            }
        }

        private void txtopbal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnadd.Focus();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reports.Form1 frm = new Reports.Form1();
            frm.Show();
        }





    }
}
