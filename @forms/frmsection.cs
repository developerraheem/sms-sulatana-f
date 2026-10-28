using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class frmsection : Form
    {

        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        bool check = false;

        public frmsection()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtsectionname.Text.Length > 0)
            {
                check = SYS.Insert_Query("Insert into Sections(SECTION_ID,SECTION_NAME,branch_id)VALUES('" + txtsectionname.Text.Trim() + "','" + txtsectionname.Text.Trim() + "','"+ SYSTEMSETTING.branch_ID +"')");

                if (check == true)
                {
                    txtsectionname.Text = "";
                    SYS.Filllist_DataView("Select SECTION_ID from Sections where  branch_id='" + SYSTEMSETTING.branch_ID + "'", lstshift);
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Enter Section Name");
                txtsectionname.Focus();
            }
        }

        private void frmshift_Load(object sender, EventArgs e)
        {
            SYS.Filllist_DataView("Select SECTION_ID from Sections where branch_id='"+ SYSTEMSETTING.branch_ID +"'", lstshift);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (lblshiftid.Text.Length > 0)
            {
                check = SYS.Insert_Query("Update Sections set SECTION_ID='" + txtsectionname.Text.Trim() + "' WHERE SECTION_ID='" + lblshiftid.Text + "' and  branch_id='"+ SYSTEMSETTING.branch_ID +"'");

                if (check == true)
                {
                    txtsectionname.Text = "";
                    SYS.Filllist_DataView("Select SECTION_ID from Sections where branch_id='" + SYSTEMSETTING.branch_ID + "'", lstshift);
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record");
                txtsectionname.Focus();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lblshiftid.Text.Length > 0)
            {
                check = SYS.Insert_Query("Delete from Sections WHERE SECTION_ID='" + lblshiftid.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");

                if (check == true)
                {
                    txtsectionname.Text = "";
                    SYS.Filllist_DataView("Select SECTION_ID from Sections where branch_id='" + SYSTEMSETTING.branch_ID + "'", lstshift);
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record");
                txtsectionname.Focus();
            }
        }

        private void lstshift_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblshiftid.Text = (this.lstshift.Items[lstshift.FocusedItem.Index].SubItems[0].Text);
            this.txtsectionname.Text = (this.lstshift.Items[lstshift.FocusedItem.Index].SubItems[0].Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
