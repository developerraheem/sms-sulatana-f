using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class Fr_FeeEntry_Classwise : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        public Fr_FeeEntry_Classwise()
        {
            InitializeComponent();
        }

        private void Fr_FeeEntry_Classwise_Load(object sender, EventArgs e)
        {
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.comboBox1, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            SYS.Filllist_DataView("SELECT FEE_MASTER.FEE_MASTER_ID, student.s_name, student.ADMISSION_NO,  student.TYPE, FEE_MASTER.RECEIVABLE_AMOUNT, FEE_MASTER.REC_AMOUNT, FEE_MASTER.BALANCE FROM FEE_MASTER INNER JOIN student ON FEE_MASTER.s_id = student.s_id WHERE FEE_MASTER.C_ID='" + comboBox1.SelectedValue + "' AND FEE_MASTER.SHIFT='" + cmbshift.SelectedValue + "' AND PAID IS NULL AND FEE_MASTER.FEE_MONTH='" + dpAe.Text + "'", lstv_feedetail);
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Receive fee of selected Class?", "Fee Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _class.FEE fee = new _class.FEE();
                bool a = false;
                string VoucherNo;
                string Amount = "0";


                if (lstv_feedetail.Items.Count > 0)
                {

                    foreach (ListViewItem lstItem in lstv_feedetail.Items)
                    {
                        VoucherNo = lstItem.SubItems[0].Text; ;
                        Amount = lstItem.SubItems[4].Text; ;
                        bool feetag = false;
                        a = fee.submitfeeSingle(Convert.ToDouble(Amount), VoucherNo, feetag, System.DateTime.Today, System.DateTime.Today,"","");
                    }

                    if (a == true)
                    {
                        SYS.setMessageBox("Fee Received Succesfully!", 1);
                        btnsubmit_Click(sender,e);
                    }

                }
                else
                {
                    SYS.setMessageBox("No Record Found!", 3);
                }

                
            }
        }

       
    }
}
