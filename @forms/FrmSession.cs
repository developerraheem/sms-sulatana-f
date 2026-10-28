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
    public partial class FrmSession : Form
    {
        public FrmSession()
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


        private void FrmSession_Load(object sender, EventArgs e)
        {
            this.SYS.comboFill(this.cmddept, "select branch_id,branch_name from branch where active='Y'", "branch", "branch_name", "branch_id");
            //this.clsCon.list_DataView("select * from [Sessions]", this.lstv_Class);
            SYS.Filllist_DataView("select SessionID,SessionName , (select count(*) from student where student.SessionID =Sessions.SessionID ) as total_stds, active from [Sessions]  where branch_id='" + cmddept.SelectedValue.ToString() + "'", this.lstv_Class);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {


        }
        private void session_ID()
        {
            try
            {

                int myID;

                SqlConnection con = SYS.db_connect();
                con.Open();

                SqlCommand cmddr = new SqlCommand("select max(SessionID) as ids from [Sessions]", con);
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

        private void save_Session()
        {
            if (this.txtsessionname.Text == "")
            {
                MessageBox.Show("Session Name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {


                    SqlConnection con = SYS.db_connect();
                    con.Open();
                    cmdForm.Connection = con;

                    //cmdForm.CommandText = "insert into Sessions(SessionID,SessionName,branch_id) values (@SessionID,@SessionName,@branch_id)";
                    //cmdForm.Parameters.Add("@SessionID", SqlDbType.Char).Value = this.newID.ToString();
                    //cmdForm.Parameters.Add("@SessionName", SqlDbType.Char).Value = this.txtsessionname.Text.Trim();
                    //cmdForm.Parameters.Add("@branch_id", SqlDbType.Char).Value =  cmddept.SelectedValue.ToString() ;

                    //cmdForm.ExecuteNonQuery();
                    bool CHK = false;
                    CHK = SYS.Insert_Query("insert into Sessions(SessionID,SessionName,branch_id) values ('" + this.newID.ToString() + "','" + this.txtsessionname.Text.Trim() + "','" + cmddept.SelectedValue.ToString() + "')");

                    if (CHK == true)
                    {
                        clsmyFunction.setMessageBox("Session Saved Successfuly", 1);
                    }
                    else
                    {
                        clsmyFunction.setMessageBox("Record not Saved, Please try again", 3);
                    }

                    con.Close();

                    SYS.Filllist_DataView("select SessionID,SessionName , (select count(*) from student where student.SessionID =Sessions.SessionID ) as total_stds, active from [Sessions]  where branch_id='" + cmddept.SelectedValue.ToString() + "'", this.lstv_Class);


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

        private void lstv_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtsessionid.Text = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txtsessionname.Text = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[1].Text.Trim());


            btnupdate.Enabled = true;
            btndelete.Enabled = true;
            btnsave.Enabled = false;

            if ((this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[3].Text.Trim().ToString()) == "True")
            {
                chkactive.Checked = true;
            }
            else

            {
                chkactive.Checked = false;
            }


        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.txtsessionid.Text == "")
            {
                MessageBox.Show("Select Session from List!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //SqlConnection con = SYS.db_connect();
                    //con.Open();
                    //cmdForm.Connection = con;

                    //cmdForm.CommandText = "Delete from Sessions where SessionID='" + txtsessionid.Text + "' and branch_id='" +  cmddept.SelectedValue.ToString()  + "'";
                    //cmdForm.ExecuteNonQuery();
                    //con.Close();
                    //clsmyFunction.setMessageBox("Data Delete Successfuly", 1);

                    //SYS.Filllist_DataView("select * from [Sessions] where branch_id='" +  cmddept.SelectedValue.ToString()  + "'", this.lstv_Class);
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
            if (txtsessionid.Text.Length > 0)
            {
                SYS.Insert_Query("Update Sessions set SessionName='" + txtsessionname.Text + "' where SessionID='" + txtsessionid.Text + "'");
                SYS.Filllist_DataView("select SessionID,SessionName , (select count(*) from student where student.SessionID =Sessions.SessionID ) as total_stds, active from [Sessions]  where branch_id='" + cmddept.SelectedValue.ToString() + "'", this.lstv_Class);
            }
        }

        private void cmddept_SelectedIndexChanged(object sender, EventArgs e)
        {
            SYS.Filllist_DataView("select SessionID,SessionName , (select count(*) from student where student.SessionID =Sessions.SessionID ) as total_stds,active from [Sessions]  where branch_id='" + cmddept.SelectedValue.ToString() + "'", this.lstv_Class);
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            btnupdate.Enabled = false;
            btndelete.Enabled = false;
            btnsave.Enabled = true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //  session_ID();
            // save_Session();
            DataSet rs = new DataSet();
            bool active = false;
            string sessionid = "1";
            string QUERY = "";
            QUERY = "select max(SessionID)+1 as ids from [Sessions]";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow Row_Fine in rs.Tables[0].Rows)
            {
                sessionid = Row_Fine[0].ToString();
            }
            if (sessionid == "")
            {
                sessionid = "1";
            }



            if (txtsessionname.Text.Length > 0)
            {
                if (chkactive.Checked == true)
                {
                    active = true;
                }
                else
                {
                    active = false;
                }
                bool chk = false;
                chk = SYS.Insert_Query("insert into Sessions(SessionID,SessionName,branch_id,active) values ('" + sessionid.ToString() + "','" + this.txtsessionname.Text.Trim() + "','" + cmddept.SelectedValue.ToString() + "','" + active + "')");
                if (chk == true)
                {
                    SYS.setMessageBox("Record Updated!", 1);
                    SYS.Filllist_DataView("select SessionID,SessionName , (select count(*) from student where student.SessionID =Sessions.SessionID ) as total_stds, active from [Sessions]  where branch_id='" + cmddept.SelectedValue.ToString() + "'", this.lstv_Class);
                }
                else
                {
                    SYS.setCreateError("Record Added!");
                    txtsessionname.Text = string.Empty;

                }
            }
            else
            {
                SYS.setCreateError("Enter Session!");
                txtsessionname.Focus();
            }






        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            DataSet rs = new DataSet();
            bool active = false;
            string sessionid = "1";
            string QUERY = "";

            if (txtsessionid.Text.Length > 0)
            {
                if (chkactive.Checked == true)
                {
                    active = true;
                }
                else
                {
                    active = false;
                }
                bool chk = false;
                chk = SYS.Insert_Query("Update Sessions set SessionName='" + txtsessionname.Text + "',active='" + active + "' where SessionID='" + txtsessionid.Text + "'");
                if (chk == true)
                {
                    SYS.setMessageBox("Record Updated!", 1);
                    SYS.Filllist_DataView("select SessionID,SessionName , (select count(*) from student where student.SessionID =Sessions.SessionID ) as total_stds, active from [Sessions]  where branch_id='" + cmddept.SelectedValue.ToString() + "'", this.lstv_Class);
                }
                else
                {
                    SYS.setCreateError("Record Added!");
                    txtsessionname.Text = string.Empty;

                }
            }
            else
            {
                SYS.setCreateError("Enter Session!");
                txtsessionname.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
