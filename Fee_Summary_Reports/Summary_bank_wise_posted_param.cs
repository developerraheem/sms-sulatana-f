using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace School.Fee_Summary_Reports
{
    public partial class Summary_bank_wise_posted_param : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();

        public Summary_bank_wise_posted_param()
        {
            InitializeComponent();
        }

        private void frmclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Summary_bank_wise_posted frm = new Summary_bank_wise_posted();
            frm.feemonth = cmbmonth.Text;
            frm.sessionid = SYSTEMSETTING.sessionid;
            frm.bankfrom = cmb_bankfrom.SelectedValue.ToString();
            frm.bankto = cmb_bankto.SelectedValue.ToString();
            frm.Show();
        }

        private void Head_Class_wise_feereport_param_Load(object sender, EventArgs e)
        {
            this.SYS.comboFill(this.cmb_bankfrom, "select BANK_ID,BANK_NAME from banks order by BANK_ID", "banks", "BANK_NAME", "BANK_ID");
            this.SYS.comboFill(this.cmb_bankto, "select BANK_ID,BANK_NAME from banks order by BANK_ID", "banks", "BANK_NAME", "BANK_ID");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
