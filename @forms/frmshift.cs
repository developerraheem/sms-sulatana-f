using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class frmshift : Form
    {

        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        bool check = false;

        public frmshift()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtshiftname.Text.Length > 0)
            {
                check = SYS.Insert_Query("Insert into SHIFT(SHIFT,branch_id)VALUES('" + txtshiftname.Text + "','"+ SYSTEMSETTING.branch_ID +"')");

                if (check == true)
                {
                    txtshiftname.Text = "";
                    SYS.Filllist_DataView("Select * from SHIFT where branch_id='"+ SYSTEMSETTING.branch_ID +"'", lstshift);
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Enter Shift Name");
                txtshiftname.Focus();
            }
        }

        private void frmshift_Load(object sender, EventArgs e)
        {
            SYS.Filllist_DataView("Select * from SHIFT where branch_id='" + SYSTEMSETTING.branch_ID + "'", lstshift);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (lblshiftid.Text.Length > 0)
            {
                check = SYS.Insert_Query("Update Shift set SHIFT='"+ txtshiftname.Text +"' WHERE SHIFT_ID='"+ lblshiftid.Text +"'");

                if (check == true)
                {
                    txtshiftname.Text = "";
                    SYS.Filllist_DataView("Select * from SHIFT where branch_id='" + SYSTEMSETTING.branch_ID + "'", lstshift);
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record");
                txtshiftname.Focus();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lblshiftid.Text.Length > 0)
            {
                check = SYS.Insert_Query("Delete from Shift WHERE SHIFT_ID='" + lblshiftid.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");

                if (check == true)
                {
                    txtshiftname.Text = "";
                    SYS.Filllist_DataView("Select * from SHIFT where branch_id='"+ SYSTEMSETTING.branch_ID + "'", lstshift);
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record");
                txtshiftname.Focus();
            }
        }

        private void lstshift_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblshiftid.Text = (this.lstshift.Items[lstshift.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txtshiftname.Text = (this.lstshift.Items[lstshift.FocusedItem.Index].SubItems[1].Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
