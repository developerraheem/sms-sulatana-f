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
    public partial class frmClass : Form
    {
        public frmClass()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        public string str = "";//get the value for form what do Modify/Add
        string newID, editID;// newID for New ID  and editID for Delete & Edit
        SqlCommand cmdForm = new SqlCommand();
        _class.clsODBC clsCon = new School._class.clsODBC();
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.txt_Cname.Text = "";
            lstv_Function();
            this.txt_Cname.Focus();

        }
        private void lstv_Function()
        {
            //this.clsCon.list_DataView("select * from class", this.lstv_Class);
            SYS.Filllist_DataView("select * from class WHERE branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", this.lstv_Class);
        }
        private void save_Class()
        {
            if (this.txt_Cname.Text == "")
            {
                MessageBox.Show("Class Name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //clsCon.cmdOpen(cmdForm);

                    //SqlConnection con = SYS.db_connect();
                    //con.Open();
                    //cmdForm.Connection = con;
                    //cmdForm.CommandText = "insert into class(c_id,c_name,branch_id) values (@c_id,@c_name,@branch_id)";
                    //cmdForm.Parameters.Add("@c_id", SqlDbType.Int).Value = this.newID;
                    //cmdForm.Parameters.Add("@c_name", SqlDbType.Char).Value = this.txt_Cname.Text.Trim();
                    //cmdForm.Parameters.Add("@branch_id", SqlDbType.Int).Value = ;
                    //cmdForm.ExecuteNonQuery();

                    SYS.Insert_Query("insert into class(c_id,c_name,branch_id)values('" + this.newID + "','" + this.txt_Cname.Text.Trim() + "','"+ SYSTEMSETTING.branch_ID +"')");
                    //clsCon.cmdClose(cmdForm);
                    //con.Close();
                    clsmyFunction.setMessageBox("Data Save Successfuly", 1);

                }
                catch (Exception exp)
                {
                    clsmyFunction.setCreateError(exp.Message);

                }
                finally
                {
                    //clsCon.cn.Close();
                }
            }
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lstv_Function();
            this.lstv_Class.Refresh();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            class_ID();
            save_Class();
            lstv_Function();
            this.txt_Cname.Text = "";
        }
        private void class_ID()
        {
            try
            {

                int myID;
                //clsCon.connCheck();

                SqlConnection con = SYS.db_connect();
                con.Open();

                SqlCommand cmddr = new SqlCommand("select max(c_id) as ids from class", con);
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

        private void frmClass_Load(object sender, EventArgs e)
        {
            this.lbl_Mode.TextChanged += (s, ev) => {
                if (this.lbl_Mode.Text == "Adding") {
                    this.lbl_ModeVisual.Text = "Add Mode";
                } else if (this.lbl_Mode.Text == "Modifying") {
                    this.lbl_ModeVisual.Text = "Modify Mode";
                } else {
                    this.lbl_ModeVisual.Text = this.lbl_Mode.Text;
                }
            };

            if (str == "Adding")
            {
                this.lbl_Mode.Text = str;
                this.lbl_ModeVisual.Text = "Add Mode";
                btnUpdate.Enabled = false;
                btnDel.Enabled = false;
            }
            else
            {
                if (str == "Modifying")
                {
                    this.lbl_Mode.Text = str;
                    this.lbl_ModeVisual.Text = "Modify Mode";
                    btnSave.Enabled = false;
                }
            }

            lstv_Function();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (this.txt_Cname.Text == "")
            {
                clsmyFunction.setCreateError("Select a Class Name for Edit");
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

                    cmdForm.CommandText = "update class set c_name=@c_name where c_id=@c_id";
                    cmdForm.Parameters.Add("@c_name", SqlDbType.Char).Value = this.txt_Cname.Text;
                    cmdForm.Parameters.Add("@c_id", SqlDbType.Int).Value = this.editID;
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



        private void btn_Delete_Click(object sender, EventArgs e)
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

                        SqlConnection con = SYS.db_connect();
                        con.Open();
                        cmdForm.Connection = con;

                        cmdForm.CommandText = "delete * from class where c_id=@cid";

                        cmdForm.Parameters.Add("@cid", SqlDbType.Int).Value = this.editID;
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
                btn_Cancel_Click(sender, e);
                // return;
            }


        }

        private void txt_Cname_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.lbl_Mode.Text == "Adding")
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
            else
            {
                return;
            }

        }

        private void lstv_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editID = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txt_Cname.Text = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[1].Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            class_ID();
            save_Class();
            lstv_Function();
            this.txt_Cname.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txt_Cname.Text == "")
            {
                clsmyFunction.setCreateError("Select a Class Name for Edit");
                return;
            }
            else
            {
                try
                {

                    //cmdForm.CommandText = "update class set c_name=? where c_id=?";
                    //cmdForm.Parameters.Add("@c_name", OleDbType.Char).Value = this.txt_Cname.Text;
                    //cmdForm.Parameters.Add("@c_id", OleDbType.Numeric).Value = this.editID;
                    //clsCon.cmdClose(cmdForm);
                    bool check = false;
                    check = SYS.Insert_Query("UPDATE CLASS SET c_name='" + this.txt_Cname.Text + "' where c_id=" + this.editID + "");
                    if (check == true)
                    {
                        clsmyFunction.setMessageBox("Data Edit Successfuly", 1);
                        this.txt_Cname.Text = "";
                    }

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

        private void btnDel_Click(object sender, EventArgs e)
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
                        //cmdForm.CommandText = "delete * from class where c_id=?";

                        //cmdForm.Parameters.Add("@c_id", OleDbType.Numeric).Value = this.editID;
                        //clsCon.cmdClose(cmdForm);
                        //clsmyFunction.setMessageBox("Data Deleted Successfuly", 1);
                        //this.txt_Cname.Text = "";

                        bool check = false;
                        string query = "delete from class where c_id='" + this.editID + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                        check = SYS.Insert_Query(query);
                        if (check == true)
                        {
                            clsmyFunction.setMessageBox("Data Deleted Successfuly", 1);
                            this.txt_Cname.Text = "";
                        }



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
                btn_Cancel_Click(sender, e);
                // return;
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            lstv_Function();
            this.lstv_Class.Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
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