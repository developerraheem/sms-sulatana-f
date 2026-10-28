using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace School.Fee_Summary_Reports
{
    public partial class concession_detail : Form
    {
        public string sessionid = "";
        public string feemonth = "";
        public string classfrom = "";
        public string classto = "";

        public concession_detail()
        {
            InitializeComponent();
        }

        private void Head_Class_wise_feereport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet_Fee_Summary_Reports.SULTANA_CONCESSION' table. You can move, or remove it, as needed.
            this.sULTANA_CONCESSIONTableAdapter.Fill(this.dataSet_Fee_Summary_Reports.SULTANA_CONCESSION,Convert.ToDecimal(SYSTEMSETTING.branch_ID));
            

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {

                this.sULTANA_CONCESSIONTableAdapter.FillBy(this.dataSet_Fee_Summary_Reports.SULTANA_CONCESSION, ((decimal)(System.Convert.ChangeType(SYSTEMSETTING.branch_ID, typeof(decimal)))));


                ReportParameter schoolname1 = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                this.reportViewer1.LocalReport.SetParameters(schoolname1);

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
            
            //try
            //{
            //    this.fEE_ACCORDING_STRENGHTTableAdapter.FillBy(this.dataSet_Fee_Summary_Reports.FEE_ACCORDING_STRENGHT, dpAe.Text);
            //    this.reportViewer1.RefreshReport();
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.Message);
            //}
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
          

        }

      


        
    }
}
