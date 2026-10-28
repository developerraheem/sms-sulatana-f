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
    public partial class frmExpDetail : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        public frmExpDetail()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        public string str = "";//get the value for form what do Modify/Add
        int idVal, editVal;
        DateTime editDate;
        OleDbCommand cmdForm = new OleDbCommand();
        _class.clsODBC clsCon = new School._class.clsODBC();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        private void frmExpDetail_Load(object sender, EventArgs e)
        {
            //if (str == "Adding")
            //{
            //    this.lbl_Mode.Text = str;
            //    btnUpdate.Enabled = false;
            //    btnDel.Enabled = false;

            //    //exp_ID();
            //}
            //else
            //{
            //    if (str == "Modifying")
            //    {
            //        this.lbl_Mode.Text = str;
            //        btnSave.Enabled= false;

            //    }
            //}
            //tab_Index();
            list_Data();
            SYS.comboFill(this.cmbexpensehea, "select * from class ORDER BY c_id", "class", "c_name", "c_id");
        }
        private void list_Data()
        {

            //clsCon.list_DataView("select sr_no,e_date,exp_name,e_paid,e_des from view_expdetail where e_date='" + this.dp_expDetail.Value.Date + "' order by sr_no", this.lstv_ExpDetail);
            SYS.Filllist_DataView("select sr_no,e_date,exp_name,e_paid,e_des from view_expdetail where e_date='" + this.dp_expDetail.Value.Date + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'", this.lstv_ExpDetail);
        }
        private void tab_Index()
        {

            txtEname.TabIndex = 2;
            dp_expDetail.TabIndex = 3;
            txtAmtPaid.TabIndex = 4;
            txtDes.TabIndex = 5;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtEid_Leave(object sender, EventArgs e)
        {
            try
            {

                clsCon.connCheck();
                OleDbCommand cmd = new OleDbCommand("select * from exp_head where exp_id='" + this.cmbexpensehea.SelectedValue.ToString() + "'", clsCon.cn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    this.txtEname.Text = dr["exp_name"].ToString();

                }

                clsCon.cn.Close();
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {

            frmFindExp frm_FindExp = new frmFindExp();
            frm_FindExp.str_Find = lbl_Mode.Text.Trim();
            // this.Close();
            frm_FindExp.ShowDialog();
        }

        private void txtAmtPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }
        private void text_Clear()
        {

            txtEname.Text = "";
            txtAmtPaid.Text = "";
            txtDes.Text = "";

        }
        private void save_ExpDetail()
        {
            if (txtEname.Text == "" || txtAmtPaid.Text == "")
            {
                MessageBox.Show("Some required Data is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //clsCon.cmdOpen(cmdForm);
                    //cmdForm.CommandText = "insert into exp_detail(e_id,e_date,e_paid,e_des,sr_no) values (?,?,?,?,?)";
                    //cmdForm.Parameters.Add("@e_id", OleDbType.Char).Value = cmbexpensehea.SelectedValue.ToString();
                    //cmdForm.Parameters.Add("@e_date", OleDbType.Date).Value = this.dp_expDetail.Value.Date;
                    //cmdForm.Parameters.Add("@e_paid", OleDbType.Numeric).Value = txtAmtPaid.Text;
                    //cmdForm.Parameters.Add("@e_des", OleDbType.Char).Value = txtDes.Text;
                    //cmdForm.Parameters.Add("@sr_no", OleDbType.Numeric).Value = this.idVal;
                    //clsCon.cmdClose(cmdForm);
                    //clsmyFunction.setMessageBox("Data Save Successfuly", 1);
                    bool check = false;
                    check = SYS.Insert_Query("insert into exp_detail(e_id,e_date,e_paid,e_des,sr_no,brach_id) values ('" + cmbexpensehea.SelectedValue + "','" + dp_expDetail.Text + "','" + txtAmtPaid.Text + "','" + txtDes.Text + "','" + this.idVal + "','"+ SYSTEMSETTING.branch_ID +"')");
                    if (check == true)
                    {
                        clsmyFunction.setMessageBox("Data Save Successfuly", 1);
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
            }
        }

        private void serial_NO()
        {
            try
            {


                SqlConnection con = SYS.db_connect();
                SqlCommand cmddr = new SqlCommand("select max(sr_no) as ids from exp_detail where e_date='" + this.dp_expDetail.Value.Date + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'", con);
                SqlDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        ;
                        idVal = 1;
                    }
                    else
                    {
                        idVal = Convert.ToInt32(dr["ids"]) + 1;
                        /// newID = myID.ToString();
                    }

                }
                dr.Close();
                clsCon.cn.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            this.lstv_ExpDetail.Refresh();
            list_Data();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

        }
        private void edit_ExpDetail()
        {

            

        }

        private void lstv_Exp_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*  this.editID = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[0].Text.Trim());
              this.txt_Cname.Text = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[1].Text.Trim());*/

            try
            {


                clsCon.connCheck();
                OleDbCommand cmddr = new OleDbCommand("select e_id,exp_name,e_date,e_paid,e_des,sr_no from view_expdetail where branch_id='" + SYSTEMSETTING.branch_ID + "' and  e_date=#"
                    + Convert.ToDateTime(this.lstv_ExpDetail.Items[lstv_ExpDetail.FocusedItem.Index].SubItems[1].Text)
                    + "# and sr_no=" + (this.lstv_ExpDetail.Items[lstv_ExpDetail.FocusedItem.Index].SubItems[0].Text.Trim()), clsCon.cn);
                OleDbDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {

            
                    txtEname.Text = dr["exp_name"].ToString();
                    dp_expDetail.Value = Convert.ToDateTime(dr["e_date"].ToString());
                    txtAmtPaid.Text = dr["e_paid"].ToString();
                    txtDes.Text = dr["e_des"].ToString();
                    //Sending Value to Variables For Edit & Delete Process

                    editDate = Convert.ToDateTime(dr["e_date"].ToString());
                    editVal = Convert.ToInt16(dr["sr_no"]);
                    //=====================================================
                }
                dr.Close();
                clsCon.cn.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

        private void delete_ExpDetail()
        {
            if (txtEname.Text == "" || txtAmtPaid.Text == "")
            {
                MessageBox.Show("Some required Data is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult ret;
                ret = MessageBox.Show("Are you sure to delete record!", "Delete".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (ret == DialogResult.Yes)
                {

                    try
                    {
                        clsCon.cmdOpen(cmdForm);
                        cmdForm.CommandText = "delete *  from exp_detail where sr_no=" + editVal + " and e_date=#" + editDate + "#";


                        clsCon.cmdClose(cmdForm);
                        clsmyFunction.setMessageBox("Data Deleted Successfuly", 1);

                    }
                    catch (Exception exp)
                    {
                        clsmyFunction.setCreateError(exp.Message);

                    }
                    finally
                    {
                        clsCon.cn.Close();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            serial_NO();
            save_ExpDetail();
            list_Data();
            text_Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           // serial_NO();
            edit_ExpDetail();
            list_Data();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            delete_ExpDetail();
            list_Data();
            text_Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            list_Data();
            text_Clear();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}