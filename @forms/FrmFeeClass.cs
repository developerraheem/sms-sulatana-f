using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace School._forms
{
    public partial class FrmFeeClass : Form
    {
        public FrmFeeClass()
        {
            InitializeComponent();
        }
        string newID, editID;// newID for New ID  and editID for Delete & Edit
        _class.clsODBC cls_Con = new School._class.clsODBC();
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        OleDbCommand cmdForm = new OleDbCommand();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        string Fee_Head_id = string.Empty;
        private void FrmFeeClass_Load(object sender, EventArgs e)
        {
            try
            {
                //cls_Con.comboFill(this.cmbclass, "select c_id,c_name from class order by c_id", "class", "c_name", "c_id");
                this.cls_Con.comboFill(this.cmbclass, "select * from class", "class", "c_name", "c_id");
               
            
                this.fee_HeadTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Head);

                this.fee_Class_EntryTableAdapter.FillBy2(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Class_Entry, cmbclass.SelectedValue.ToString());


            }
            catch (Exception exp)
            {

            }
            finally
            {

            }
        }



        private void cmbclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.fee_Class_EntryTableAdapter.FillBy2(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Class_Entry, cmbclass.SelectedValue.ToString());
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void Save()
        {
            int a = 0;
            OleDbCommand cmd = new OleDbCommand();
            this.cls_Con.cmdOpen(cmd);
            cmd.CommandText = "Select * from Fee_Class where c_id='" + cmbclass.SelectedValue.ToString() + "' and Fee_Head_id='" + cmbfeehead.SelectedValue.ToString() + "'";
            try
            {
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                }
                else
                {
                    Fee_class_ID();
                    if (txtamount.ToString() != "")
                    {

                        cmd.CommandText = "insert into Fee_Class(FEE_CLASS_ID,Fee_head_id,C_ID,AMOUNT) values(" + newID + ", " + cmbfeehead.SelectedValue.ToString() + ", " + this.cmbclass.SelectedValue + ", '" + txtamount.Text + "')";
                        a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            MessageBox.Show("Record Saved");
                            this.fee_Class_EntryTableAdapter.FillBy1(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Class_Entry, cmbclass.SelectedValue.ToString());
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                cls_Con.cn.Close();
            }

        }
        private void Fee_class_ID()
        {
            try
            {

                int myID;
                cls_Con.connCheck();
                OleDbCommand cmddr = new OleDbCommand("select max(VAL(FEE_CLASS_ID)) as ids from FEE_CLASS", cls_Con.cn);
                OleDbDataReader dr = cmddr.ExecuteReader();

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
                //cls_Con.cn.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }

        private void fee_Class_EntryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fee_Class_EntryDataGridView.SelectedRows.Count > 0)
            {
                txtfeeclassid.Text = fee_Class_EntryDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                txtamount.Text = fee_Class_EntryDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                cmbfeehead.Text = fee_Class_EntryDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {


        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {



        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtfeeclassid.Text != "")
            {
                OleDbCommand cmd = new OleDbCommand();
                this.cls_Con.cmdOpen(cmd);
                try
                {
                    cmd.CommandText = "Update Fee_Class set Fee_head_id ='" + cmbfeehead.SelectedValue.ToString() + "', AMOUNT=" + txtamount.Text.ToString() + " where C_ID='" + cmbclass.SelectedValue.ToString() + "' and FEE_CLASS_ID='" + txtfeeclassid.Text.ToString() + "'";
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {

                        MessageBox.Show("Record Saved!");
                        this.fee_Class_EntryTableAdapter.FillBy1(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Class_Entry, cmbclass.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Sorry Record Not Saved!");
                    }
                }
                catch (Exception exp)
                {

                    MessageBox.Show(exp.Message);
                }

                finally
                {
                    cls_Con.cn.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Select Record from Record List First!");
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtfeeclassid.Text != "")
            {

                OleDbCommand cmd = new OleDbCommand();
                this.cls_Con.cmdOpen(cmd);
                try
                {
                    cmd.CommandText = "Delete From Fee_Class where FEE_CLASS_ID='" + txtfeeclassid.Text.ToString() + "'";
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {

                        MessageBox.Show("Record Deleted!");
                        this.fee_Class_EntryTableAdapter.FillBy1(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Class_Entry, cmbclass.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Sorry Record Not Delete!");
                    }
                }
                catch (Exception exp)
                {

                    MessageBox.Show(exp.Message);
                }

                finally
                {
                    cls_Con.cn.Close();
                }

            }
            else
            {
                MessageBox.Show("Please Select Record from Record List First!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtamount.Text = "0";
            txtfeeclassid.Text = "";
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private void fee_Class_EntryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }













    }
}
