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
    public partial class FrmFee_class : Form
    {
        public FrmFee_class()
        {
            InitializeComponent();
        }
        string newID, editID;// newID for New ID  and editID for Delete & Edit
        _class.clsODBC cls_Con = new School._class.clsODBC();
        OleDbCommand cmdForm = new OleDbCommand();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        string Fee_Head_id = string.Empty;
        private void FrmFee_class_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the '_C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Head' table. You can move, or remove it, as needed.
              
                cls_Con.comboFill(this.cmbclass, "select * from class", "class", "c_name", "c_id");
                // cls_Con.Fee_Head(grdfeehead);
               // cls_Con.Fee_Class(dataGridView1);
            }
            catch (Exception exp)
            {

            }
            finally
            {
 
            }

            
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            this.cls_Con.cmdOpen(cmd);
            cmd.CommandText = "Select * from Fee_Class where c_id='" + cmbclass.SelectedValue.ToString() + "'";
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string Amount = string.Empty;
                        string Active = string.Empty;

                        Fee_Head_id = Convert.ToString(row.Cells["Column6"].Value);
                        Amount = Convert.ToString(row.Cells["dataGridViewTextBoxColumn4"].Value);
                        this.cls_Con.cmdOpen(cmdForm);
                        cmdForm.CommandText = "Select Fee_head_id from Fee_Class where C_ID='" + cmbclass.SelectedValue.ToString() + "' and Fee_head_id='" + Fee_Head_id + "'";
                        OleDbDataReader dr1 = cmdForm.ExecuteReader();
                        if (dr1.Read())
                        {
                          //  MessageBox.Show("No Insertion");

                        }
                        else
                        {
                            this.cls_Con.cmdOpen(cmdForm);
                            //  MessageBox.Show("Record Not Match Insert new record hrere ");
                            if (Amount.ToString() != "")
                            Fee_class_ID();
                            cmd.CommandText = "insert into Fee_Class(FEE_CLASS_ID,Fee_head_id,C_ID,AMOUNT) values(" + newID + ", " + Fee_Head_id + ", " + this.cmbclass.SelectedValue + ", '" + Amount + "')";
                            int a = cmd.ExecuteNonQuery();
                            if (a > 0)
                            {
                                MessageBox.Show("Ok");
                                cls_Con.Fee_Class(dataGridView1, cmbclass.SelectedValue.ToString());
                                this.fee_HeadTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Head);
                                cls_Con.cn.Close();

                            }
                            else
                            {
                                MessageBox.Show("Not Ok");

                            }
                          //  this.cls_Con.cmdClose(cmdForm);
                        }

                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                    //cls_Con.cn.Close();
                 //   cls_Con.cmdClose(cmdForm);
                }
                finally
                {
                    cls_Con.cn.Close();
                }

            }
            else
            {
                int a = 0;
                string id = string.Empty;
                string Fee_Head_id = string.Empty;
                string Amount = string.Empty;
                string Active = string.Empty;
                string Remarks = string.Empty;
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Fee_class_ID();
                        id = Convert.ToString(row.Cells["dataGridViewTextBoxColumn1"].Value);
                        Fee_Head_id = Convert.ToString(row.Cells["Column6"].Value);
                        Amount = Convert.ToString(row.Cells["dataGridViewTextBoxColumn4"].Value);
                        this.cls_Con.cmdOpen(cmdForm);
                        if (Amount.ToString() != "")
                        {
                           
                            cmdForm.CommandText = "insert into Fee_Class(FEE_CLASS_ID,Fee_head_id,C_ID,AMOUNT) values(" + newID + ", " + Fee_Head_id + ", " + this.cmbclass.SelectedValue + ", '" + Amount + "')";
                            a = cmdForm.ExecuteNonQuery();
                                                   }
                     
                    }
                    if (a > 0)
                    {
                        MessageBox.Show("Record Save!!");
                        cls_Con.cn.Close();
                   }
                }
                catch (Exception exp)
                {
                    
                    MessageBox.Show(exp.ToString());
                }
                finally
                {
                    cls_Con.cn.Close();
                    // cls_Con.cmdClose(cmdForm);
                }

            }
            dr.Close();
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                MessageBox.Show("del");
                dataGridView1.Rows.RemoveAt(item.Index);
               // cls_Con.Fee_Class(dataGridView1);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                string id = string.Empty;
                string Fee_Head_id = string.Empty;
                string Amount = string.Empty;
                string Active = string.Empty;
                string Remarks = string.Empty;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    id = Convert.ToString(row.Cells["dataGridViewTextBoxColumn1"].Value);
                    Fee_Head_id = Convert.ToString(row.Cells["Column6"].Value);
                    Amount = Convert.ToString(row.Cells["dataGridViewTextBoxColumn4"].Value);
                    this.cls_Con.cmdOpen(cmdForm);
                    cmdForm.CommandText = "Update Fee_Class set Fee_head_id ='" + Fee_Head_id.ToString() + "', AMOUNT=" + Amount.ToString() + " where C_ID='" + cmbclass.SelectedValue.ToString() + "' and FEE_CLASS_ID='" + id.ToString() + "'";
                    int a = cmdForm.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Record Updated");

                    }
                    else
                    {
                        MessageBox.Show("Sorry Record Not Updated");
                    }

                    this.cls_Con.cmdClose(cmdForm);

                }
                cls_Con.Fee_Class(dataGridView1, cmbclass.SelectedValue.ToString());
            }
            catch (Exception exp)
            {
             //   MessageBox.Show(exp.Message);
            }
            finally
            {
                cls_Con.cn.Close();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                cls_Con.Fee_Class(dataGridView1, (cmbclass.SelectedValue.ToString()));
                this.dataGridView1.Refresh();
                this.Refresh();
            }
            catch (Exception exp)
            {

            }
            finally
            {

            }
                      
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.fee_HeadTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Head);
                cls_Con.Fee_Class(dataGridView1, cmbclass.SelectedValue.ToString());
            }
            catch (Exception exp)
            {

            }
            finally
            {
 
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                cls_Con.Fee_Class(dataGridView1, (cmbclass.SelectedValue.ToString()));
                this.dataGridView1.Refresh();
                this.Refresh();
            }
            catch (Exception exp)
            {

            }
            finally
            {

            }
        }

       

       
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.fee_ClassBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet);
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.fee_Class_EntryTableAdapter.FillBy(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Class_Entry, c_IDToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

       

      

        

       

       
    }
}
