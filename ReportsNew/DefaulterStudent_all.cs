using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.ReportsNew
{
    public partial class DefaulterStudent_all : Form
    {
        public DefaulterStudent_all()
        {
            InitializeComponent();
        }
       public string feemonth = "";


        private void BankwisePosted_Load(object sender, EventArgs e)
        {
           // this.bankwisePostedReportTableAdapter.Fill(this.report_DataSet_new.BankwisePostedReport, feemonth,Convert.ToDecimal(SYSTEMSETTING.sessionid));
          //  this.reportViewer1.RefreshReport();

        }

       

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.dEFAULTER_DETAILTableAdapter.FillBy(this.report_DataSet_new.DEFAULTER_DETAIL, dpAe.Text, ((decimal)(System.Convert.ChangeType(SYSTEMSETTING.sessionid, typeof(decimal)))));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception EXP)
            {
                
                
            }
          
        }

       
    }
}
