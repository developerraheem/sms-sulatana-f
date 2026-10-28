using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace School.Fee_Summary_Reports
{
    public partial class Summary_Defaulter_param : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();

        public Summary_Defaulter_param()
        {
            InitializeComponent();
        }

        private void frmclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Summary_Defaulter frm = new Summary_Defaulter();
            frm.feemonth = cmbmonth.Text;
            frm.sessionid = SYSTEMSETTING.sessionid;
            frm.Show();
        }

        private void Head_Class_wise_feereport_param_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyTheme(this);
        }
    }
}
