using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.Fee_Summary_Reports
{
    public partial class Summary_bank_wise_posted : Form
    {
        public string sessionid = "";
        public string feemonth = "";
        public string bankfrom = "";
        public string bankto = "";

        public Summary_bank_wise_posted()
        {
            InitializeComponent();
        }

        private void Head_Class_wise_feereport_Load(object sender, EventArgs e)
        {
            try
            {
                this.sUMMARY_BANKWISEPOSTEDTableAdapter.FillBy(this.dataSet_Fee_Summary_Reports.SUMMARY_BANKWISEPOSTED, feemonth, ((decimal)(System.Convert.ChangeType(sessionid, typeof(decimal)))), new System.Nullable<int>(((int)(System.Convert.ChangeType(bankfrom, typeof(int))))), new System.Nullable<int>(((int)(System.Convert.ChangeType(bankto, typeof(int))))));
                this.reportViewer1.RefreshReport();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }


    }
}
