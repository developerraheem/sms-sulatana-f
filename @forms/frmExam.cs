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
    public partial class frmExam : Form
    {
        public frmExam()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        public string str = "";//get the value for form what do Modify/Add
        string newID, editID;// newID for New ID  and editID for Delete & Edit
        OleDbCommand cmdForm = new OleDbCommand();
        _class.clsODBC clsCon = new School._class.clsODBC();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        SYSTEMSETTING SYS = new SYSTEMSETTING();

        private void frmExam_Load(object sender, EventArgs e)
        {
            list_Data();
        }
        private void list_Data()
        {
            SYS.Filllist_DataView("SELECT [e_id],[e_name] FROM [exam] WHERE branch_id='" + SYSTEMSETTING.branch_ID + "'", this.lstv_Exam);

        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exam_ID()
        {
            try
            {

                int myID;
                //clsCon.connCheck();
                //OleDbCommand cmddr = new OleDbCommand("select max(e_id) as ids from exam", clsCon.cn);
                //OleDbDataReader dr = cmddr.ExecuteReader();

                //while (dr.Read())
                //{
                //    string strid = dr["ids"].ToString();
                //    if (strid == "")
                //    {
                //        newID = "1";
                //    }
                //    else
                //    {
                //        myID = Convert.ToInt32(dr["ids"]) + 1;
                //        newID = myID.ToString();
                //    }

                //}
                //dr.Close();
                //clsCon.cn.Close();
                //cmddr.Dispose();


                SYSTEMSETTING SYS = new SYSTEMSETTING();
                DataSet rs = new DataSet();

                string QUERY = "select max(e_id) as ids from exam";
                rs = SYS.Show_Query(QUERY);
                if (rs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Row in rs.Tables[0].Rows)
                    {
                        newID = Row["ids"].ToString();
                    }
                }
                else
                {
                    newID = "1";
                }
                if (newID == "")
                {
                    newID = "1";
                }

                newID = (Convert.ToInt32(newID) + 1).ToString();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            if (txtEname.Text.Length > 0)
            {
                bool VAL = false;
                exam_ID();
                VAL = SYS.Insert_Query("INSERT INTO exam(e_id,e_name,branch_id) VALUES('" + newID + "','" + txtEname.Text + "','"+ SYSTEMSETTING.branch_ID +"')");

                if (VAL == true)
                {
                    SYS.setMessageBox("New Exam Added!", 1);
                    txtEname.Text = "";
                    list_Data();
                }


            }




        }
        private void save_Exam()
        {
            if (this.txtEname.Text == "")
            {
                MessageBox.Show("Exam Name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    clsCon.cmdOpen(cmdForm);
                    cmdForm.CommandText = "insert into exam(e_id,e_name) values (?,?)";
                    cmdForm.Parameters.Add("@e_id", OleDbType.Numeric).Value = this.newID;
                    cmdForm.Parameters.Add("@e_name", OleDbType.Char).Value = this.txtEname.Text.Trim();
                    clsCon.cmdClose(cmdForm);
                    clsmyFunction.setMessageBox("Data Save Successfuly", 1);

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

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (this.txtEname.Text == "")
            {
                clsmyFunction.setCreateError("Select a Exam Name for Edit");
                return;
            }
            else
            {
                try
                {

                    SYS.Insert_Query("Update exam set e_name='" + txtEname.Text + "' where e_id='" + this.editID + "'");


                }
                catch (Exception exp)
                {
                    clsmyFunction.setCreateError(exp.Message);

                }
                finally
                {
                   
                }

            }
            list_Data();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you sure to delete record!", "Delete".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {

                if (this.txtEname.Text == "")
                {
                    clsmyFunction.setCreateError("Select a Record for Delete");
                    return;
                }
                else
                {
                    try
                    {
                        //clsCon.cmdOpen(cmdForm);
                        //cmdForm.CommandText = "delete from exam where e_id=?";

                        //cmdForm.Parameters.Add("@e_id", OleDbType.Numeric).Value = this.editID;
                        //clsCon.cmdClose(cmdForm);
                        //clsmyFunction.setMessageBox("Data Deleted Successfuly", 1);
                        //txtEname.Text = "";


                        SYS.Insert_Query("delete from  exam where e_id='" + this.editID + "'");


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
                list_Data();
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtEname.Text = "";
            list_Data();

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            lstv_Exam.Refresh();
            btn_Cancel_Click(sender, e);
        }

        private void lstv_Exam_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editID = (this.lstv_Exam.Items[lstv_Exam.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txtEname.Text = (this.lstv_Exam.Items[lstv_Exam.FocusedItem.Index].SubItems[1].Text.Trim());

            
        }
    }
}