using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class PrntUnpaidvoucher : Form
    {
        public PrntUnpaidvoucher()
        {
            InitializeComponent();
        }
        public string month = "";
        public string classid="";
        public string SHIFTID = "";
        public string sessionid = "0";

        private void PrntUnpaidvoucher_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'report_DataSet_new.UnpaidVouchers' table. You can move, or remove it, as needed.
            this.unpaidVouchersTableAdapter.Fill(this.report_DataSet_new.UnpaidVouchers,month,classid,SHIFTID,Convert.ToDecimal(sessionid));
            this.reportViewer1.RefreshReport();
        }

       
    }
}
