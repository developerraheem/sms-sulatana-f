using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.Reports
{
    public partial class rpt_admission_datewise : Form
    {
        public rpt_admission_datewise()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            _forms.rpt_admission_datewise_rpt frm = new _forms.rpt_admission_datewise_rpt();
            frm.datefrom = txtdatefrom.Text;
            frm.dateto = txtdateto.Text;
            frm.Show();

        }

        private void rpt_admission_datewise_Load(object sender, EventArgs e)
        {

        }
    }
}
