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
    public partial class Frmfee_head : Form
    {
        public Frmfee_head()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        public string str = "";//get the value for form what do Modify/Add
        string newID, editID;// newID for New ID  and editID for Delete & Edit
        SqlCommand cmdForm = new SqlCommand();
        //_class.clsODBC clsCon = new School._class.clsODBC();
        // _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        DataSet rs = new DataSet();
        SYSTEMSETTING SYS = new SYSTEMSETTING();


        private void btn_Add_Click(object sender, EventArgs e)
        {
            FeeID();
            save_Class();
            lstv_Function();
        }
        private void FeeID()
        {
            try
            {

                int myID;

                SqlConnection con = SYS.db_connect();
                con.Open();
                SqlCommand cmddr = new SqlCommand("select max(Fee_head_id) as ids from Fee_Head", con);
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
        private void save_Class()
        {
            if (this.txtdesc.Text == "")
            {
                MessageBox.Show("Fee Head Descriptionis required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //SqlConnection con = SYS.db_connect();
                    //con.Open();
                    //cmdForm.Connection = con;
                    //cmdForm.CommandText = "insert into Fee_Head(Fee_head_id,Fee_head,Type,Amount,Active_flag,Category) values (@Fee_head_id,@Fee_head,@Type,@Amount,@Active_flag,@Category)";
                    //cmdForm.Parameters.Add("@Fee_head_id", SqlDbType.Int).Value = this.newID;
                    //cmdForm.Parameters.Add("@Fee_head", SqlDbType.Char).Value = this.txtdesc.Text.Trim();
                    //cmdForm.Parameters.Add("@Type", SqlDbType.Char).Value = this.cmbtype.SelectedItem.ToString();
                    //cmdForm.Parameters.Add("@Amount", SqlDbType.Char).Value = this.txtamount.Text.Trim();
                    //cmdForm.Parameters.Add("@Active_flag", SqlDbType.Char).Value = this.cmbactive.SelectedItem.ToString();
                    //cmdForm.Parameters.Add("@Category", SqlDbType.Char).Value = this.cmbcate.SelectedItem.ToString();
                    //cmdForm.ExecuteNonQuery();
                    //con.Close();
                    //SYS.setMessageBox("Data Save Successfuly", 1);


                    SYS.Insert_Query("insert into Fee_Head(Fee_head_id,Fee_head,Type,Amount,Active_flag,Category,branch_id,sort_id) values ('" + this.newID + "','" + this.txtdesc.Text.Trim() + "','General','" + this.txtamount.Text.Trim() + "','" + this.cmbactive.SelectedItem.ToString() + "','" + this.cmbcate.SelectedItem.ToString() + "','" + SYSTEMSETTING.branch_ID + "','" + TXTSORTID.Text + "')");
                    SYS.setMessageBox("Data Save Successfuly", 1);
                    lstv_Function();
                }
                catch (Exception exp)
                {
                    SYS.setCreateError(exp.Message);

                }
                finally
                {

                }
            }
        }
        private void lstv_Function()
        {
            this.SYS.Filllist_DataView("select Fee_head_id,Fee_head,Type,Amount,Active_flag, sort_id from Fee_Head where branch_id='" + SYSTEMSETTING.branch_ID + "'", this.lstv_Class);
        }

        private void Frmfee_head_Load(object sender, EventArgs e)
        {
            lstv_Function();
        }

        private void lstv_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfeeheadid.Text = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[0].Text.Trim());
            this.editID = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txtdesc.Text = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[1].Text.Trim());
            this.txtamount.Text = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[3].Text.Trim());
            this.TXTSORTID.Text = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[5].Text.Trim());


            rs = SYS.Show_Query("select * from fee_head where Fee_head_id='" + editID + "'");
            if (rs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Row in rs.Tables[0].Rows)
                {

                    this.txtdesc.Text = Row["Fee_head"].ToString();
                    cmbcate.Text = Row["Category"].ToString();
                    cmbtype.Text = Row["Type"].ToString();
                    txtamount.Text = Row["Amount"].ToString();
                    cmbactive.Text = Row["Active_flag"].ToString();

                }
            }



            btnSave.Enabled = false;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lstv_Function();
            this.lstv_Class.Refresh();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.txtdesc.Text = "";
            txtamount.Text = "";
            lstv_Function();
            this.txtdesc.Focus();
            btnSave.Enabled = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you sure to delete record!", "Delete".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {

                if (this.txtdesc.Text == "")
                {
                    SYS.setCreateError("Select a Record for Delete");
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

                        cmdForm.CommandText = "delete * from FEE_HEAD where Fee_head_id=@idd";

                        cmdForm.Parameters.Add("@idd", SqlDbType.Int).Value = this.editID;

                        cmdForm.ExecuteNonQuery();
                        con.Close();

                        SYS.setMessageBox("Data Deleted Successfuly", 1);


                        this.txtdesc.Text = "";
                        txtamount.Text = "";


                    }
                    catch (Exception exp)
                    {
                        SYS.setCreateError(exp.Message);

                    }
                    finally
                    {

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FeeID();
            save_Class();
            lstv_Function();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you sure to delete record!", "Delete".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {

                if (this.txtdesc.Text == "")
                {
                    SYS.setCreateError("Select a Record for Delete");
                    return;
                }
                else
                {
                    try
                    {
                        //SqlConnection con = SYS.db_connect();
                        //con.Open();
                        //cmdForm.Connection = con;

                        //cmdForm.CommandText = "delete  from FEE_HEAD where Fee_head_id=@idd";

                        //cmdForm.Parameters.Add("@idd", SqlDbType.Int).Value = this.editID;
                        //cmdForm.ExecuteNonQuery();
                        //con.Close();
                        //SYS.setMessageBox("Data Deleted Successfuly", 1);
                        //this.txtdesc.Text = "";
                        //txtamount.Text = "";


                    }
                    catch (Exception exp)
                    {
                        SYS.setCreateError(exp.Message);

                    }
                    finally
                    {

                    }
                    lstv_Function();
                }


            }
            else
            {
                btnCancel_Click(sender, e);
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
            this.txtdesc.Text = "";
            txtamount.Text = "";
            lstv_Function();
            this.txtdesc.Focus();
            btnSave.Enabled = true;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtfeeheadid.Text.Length > 0)
            {
                SYS.Insert_Query("Update Fee_Head set Fee_head='" + txtdesc.Text + "', Amount='" + txtamount.Text + "', Active_flag='" + cmbactive.Text + "',Category='" + this.cmbcate.SelectedItem.ToString() + "', sort_id='"+ TXTSORTID.Text +"' where Fee_head_id='" + txtfeeheadid.Text + "'");
                lstv_Function();
                this.lstv_Class.Refresh();
            }
        }
    }
}
