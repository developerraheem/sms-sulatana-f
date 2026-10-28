using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.security_module
{
    public partial class frmusers : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        public frmusers()
        {
            InitializeComponent();
        }

        private void frmusers_Load(object sender, EventArgs e)
        {
            this.SYS.comboFill(this.cmddept, "select branch_id,branch_name from branch where active='Y'", "branch", "branch_name", "branch_id");
            SYS.Filllist_DataView("SELECT [u_id],[u_name],[pw],[branch_id]  FROM [user_] where branch_id='"+ cmddept.SelectedValue.ToString() +"'", lst_users);
        }

        private void cmddept_SelectedIndexChanged(object sender, EventArgs e)
        {
            SYS.Filllist_DataView("SELECT [u_id],[u_name],[pw],[branch_id]  FROM [user_] where branch_id='" + cmddept.SelectedValue.ToString() + "'", lst_users);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lst_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtloginID.Text = (this.lst_users.Items[lst_users.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txtpassword.Text = (this.lst_users.Items[lst_users.FocusedItem.Index].SubItems[2].Text.Trim());
            txtloginID.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
            btnsave.Enabled = false;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            btnupdate.Enabled = false;
            btndelete.Enabled = false;
            btnsave.Enabled = true;
            txtloginID.Enabled = true;
            txtloginID.Text = string.Empty;
            txtpassword.Text = string.Empty;
            SYS.Filllist_DataView("SELECT [u_id],[u_name],[pw],[branch_id]  FROM [user_] where branch_id='" + cmddept.SelectedValue.ToString() + "'", lst_users);
            
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtloginID.Text.Length > 0)
            {
                bool chk = false;
                chk = SYS.Insert_Query("Update [user_] set [pw]='" + txtpassword.Text + "' where [u_id]='"+ txtloginID.Text  +"'");
                if (chk == true)
                {
                    SYS.setMessageBox("Record Updated!", 1);
                    SYS.Filllist_DataView("SELECT [u_id],[u_name],[pw],[branch_id]  FROM [user_] where branch_id='" + cmddept.SelectedValue.ToString() + "'", lst_users);
                }
                else
                {
                    SYS.setCreateError("Record not Updated!");
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtloginID.Text.Length > 0)
            {
                bool chk = false;
                chk = SYS.Insert_Query("insert into [user_]([u_id],[pw],[branch_id]) values ('" + txtloginID.Text + "', '" + txtpassword.Text + "','"+ cmddept.SelectedValue.ToString() +"')");
                if (chk == true)
                {
                    SYS.setMessageBox("Record Updated!", 1);
                    SYS.Filllist_DataView("SELECT [u_id],[u_name],[pw],[branch_id]  FROM [user_] where branch_id='" + cmddept.SelectedValue.ToString() + "'", lst_users);
                }
                else
                {
                    SYS.setCreateError("Record Added!");
                    txtloginID.Text = string.Empty;
                    txtpassword.Text = string.Empty;

                }
            }
            else
            {
                SYS.setCreateError("Enter Login ID!");
                txtloginID.Focus();
            }
        }
    }
}
