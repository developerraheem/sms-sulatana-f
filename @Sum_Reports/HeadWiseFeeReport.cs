using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class HeadWiseFeeReport : Form
    {
        public HeadWiseFeeReport()
        {
            InitializeComponent();
        }

        SYSTEMSETTING SYS = new SYSTEMSETTING();
        private void btnprint_Click(object sender, EventArgs e)
        {
            classwisefeeheadreport prnt = new classwisefeeheadreport();
            prnt.feemonth = txtfeemonth.Text;
            prnt.shift = cmbshift.SelectedValue.ToString();
            prnt.classid = cmbclass.SelectedValue.ToString();
            prnt.feeheadid = cmbfeehead.SelectedValue.ToString();
            prnt.sectionid = cmbsection.SelectedValue.ToString();
            

            if (chkdate.Checked == true)
            {
                prnt.param = "Bydate";
                prnt.todate = txtto.Text;
                prnt.fromdate = txtfrom.Text;
            }
            else
            {
                prnt.param = cmbType.Text;
            }

            prnt.Show();
        }

        private void FrmFeeHeadWIse_Load(object sender, EventArgs e)
        {
            SYS.comboFill(this.cmbclass, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT] FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbsection, "select SECTION_NAME from sections where branch_id='" + SYSTEMSETTING.branch_ID + "'", "sections", "SECTION_NAME", "SECTION_NAME");
            SYS.comboFill(this.cmbfeehead, "select Fee_head_id,Fee_Head from Fee_Head where branch_id='" + SYSTEMSETTING.branch_ID + "' order by Fee_head_id", "Fee_Head", "Fee_Head", "Fee_head_id");
            ThemeHelper.ApplyTheme(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chkdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdate.Checked  == true)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

       
    }
}
