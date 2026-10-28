using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace School.STUCKOFF_LEAVE_PARAM
{
    public partial class STUCKOFF_LEAVE_PARAM : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();

        public STUCKOFF_LEAVE_PARAM()
        {
            InitializeComponent();
        }

        private void frmclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            School.Fee_Summary_Reports.STUCKOFF_LEAVE frm = new School.Fee_Summary_Reports.STUCKOFF_LEAVE();
            frm.sessionid = SYSTEMSETTING.sessionid;
            frm.datefrom = txtdatefrom.Text;
            frm.dateto =txtdateto.Text;
            frm.FROMCLASS = cmbclassfrom.SelectedValue.ToString();
            frm.TOCLASS = cmbclassto.SelectedValue.ToString();
            frm.Show();
        }

        private void Head_Class_wise_feereport_param_Load(object sender, EventArgs e)
        {
            this.SYS.comboFill(this.cmbclassfrom, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            this.SYS.comboFill(this.cmbclassto, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id desc", "class", "c_name", "c_id");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
