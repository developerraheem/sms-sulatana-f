using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace School._forms
{
    public partial class FrmBank : Form
    {
        public FrmBank()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        public string str = "";//get the value for form what do Modify/Add
        string newID, editID;// newID for New ID  and editID for Delete & Edit
        SqlCommand cmdForm = new SqlCommand();
        _class.clsODBC clsCon = new School._class.clsODBC();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        SYSTEMSETTING SYS = new SYSTEMSETTING();

        private void btn_Add_Click(object sender, EventArgs e)
        {
            
        }
        private void bank_ID()
        {
            try
            {

                int myID;
                SqlConnection con = SYS.db_connect();
                con.Open();
                SqlCommand cmddr = new SqlCommand("select max(BANK_ID) as ids from BANKS", con);
                SqlDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        newID = "1";
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                        newID = myID.ToString();
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

        private void save_bank()
        {
            if (this.txt_Cname.Text == "")
            {
                MessageBox.Show("Bank Name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    SqlConnection con = SYS.db_connect();
                    con.Open();
                    //con.cmdOpen(cmdForm);
                    cmdForm.Connection = con;
                    cmdForm.CommandText = "insert into BANKS(BANK_ID,BANK_NAME,branch_id) values (@BANK_ID,@BANK_NAME,@branch_id)";
                    cmdForm.Parameters.Add("@BANK_ID", SqlDbType.Int).Value = this.newID;
                    cmdForm.Parameters.Add("@BANK_NAME", SqlDbType.Char).Value = this.txt_Cname.Text.Trim();
                    cmdForm.Parameters.Add("@branch_id", SqlDbType.Char).Value = SYSTEMSETTING.branch_ID;
                    cmdForm.ExecuteNonQuery();
                    clsmyFunction.setMessageBox("Data Save Successfuly", 1);
                    con.Close();
                }
                catch (Exception exp)
                {
                    clsmyFunction.setCreateError(exp.Message);

                }
                finally
                {
                    
                }
            }
        }

        private void lstv_Function()
        {
            //this.clsCon.list_DataView("select * from Banks", this.lstv_Class);
            SYS.Filllist_DataView("select * from Banks where branch_id='" + SYSTEMSETTING.branch_ID + "'", this.lstv_Class);
                
        }

        private void lstv_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editID = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txt_Cname.Text = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[1].Text.Trim());
        }

        private void txt_Cname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_Add_Click(sender, e);
            }
            else
            {
                return;
            }
        }

        private void FrmBank_Load(object sender, EventArgs e)
        {
            lstv_Function();
           
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            bank_ID();
            save_bank();
            lstv_Function();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (this.txt_Cname.Text == "")
            {
                clsmyFunction.setCreateError("Select a Bank Name for Edit");
                return;
            }
            else
            {
                try
                {
                    //clsCon.cmdOpen(cmdForm);
                    SqlConnection con = SYS.db_connect();
                    con.Open();
                    cmdForm.Connection = con;
                    cmdForm.CommandText = "update BANKS set BANK_NAME=@BANK_NAME where BANK_ID=@BANK_ID";
                    cmdForm.Parameters.Add("@BANK_NAME", SqlDbType.Char).Value = this.txt_Cname.Text;
                    cmdForm.Parameters.Add("@BANK_ID", SqlDbType.Int).Value = this.editID;
                    //clsCon.cmdClose(cmdForm);
                    cmdForm.ExecuteNonQuery();
                    clsmyFunction.setMessageBox("Data Edit Successfuly", 1);
                    this.txt_Cname.Text = "";
                    con.Close();

                }
                catch (Exception exp)
                {
                    clsmyFunction.setCreateError(exp.Message);

                }
                finally
                {
                    clsCon.cn.Close();
                }
                lstv_Function();
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you sure to delete record!", "Delete".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {

                if (this.txt_Cname.Text == "")
                {
                    clsmyFunction.setCreateError("Select a Record for Delete");
                    return;
                }
                else
                {
                    try
                    {
                        //clsCon.cmdOpen(cmdForm);
                        SqlConnection con = SYS.db_connect();
                        con.Open();

                        cmdForm.Connection = con;

                        cmdForm.CommandText = "delete from BANKS where BANK_ID=@BANKID";
                        cmdForm.Parameters.Add("@BANKID", SqlDbType.Int).Value = this.editID;
                        //clsCon.cmdClose(cmdForm);
                        cmdForm.ExecuteNonQuery();
                        clsmyFunction.setMessageBox("Data Deleted Successfuly", 1);
                        this.txt_Cname.Text = "";
                        con.Close();

                    }
                    catch (Exception exp)
                    {
                        clsmyFunction.setCreateError(exp.Message);

                    }
                    finally
                    {
                        clsCon.cn.Close();
                    }
                    lstv_Function();
                }


            }
            else
            {
                
                // return;
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            lstv_Function();
            this.lstv_Class.Refresh();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.txt_Cname.Text = "";
            lstv_Function();
            this.txt_Cname.Focus();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
