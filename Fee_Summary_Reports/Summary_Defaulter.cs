using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.Fee_Summary_Reports
{
    public partial class Summary_Defaulter : Form
    {
        public string sessionid = "";
        public string feemonth = "";
        
        public Summary_Defaulter()
        {
            InitializeComponent();
        }

        private void Head_Class_wise_feereport_Load(object sender, EventArgs e)
        {
            try
            {
                this.sUMMARY_DEFAULTERTableAdapter.FillBy(this.dataSet_Fee_Summary_Reports.SUMMARY_DEFAULTER, sessionid, feemonth);
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
