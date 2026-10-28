using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.ReportsNew
{
    public partial class BankwisePosted : Form
    {
        public BankwisePosted()
        {
            InitializeComponent();
        }
       public string feemonth = "";


        private void BankwisePosted_Load(object sender, EventArgs e)
        {
            this.bankwisePostedReportTableAdapter.Fill(this.report_DataSet_new.BankwisePostedReport, feemonth,Convert.ToDecimal(SYSTEMSETTING.sessionid));
            this.reportViewer1.RefreshReport();

        }
    }
}
