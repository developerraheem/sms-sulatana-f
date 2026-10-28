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
    public partial class concession_summary : Form
    {
        public string sessionid = "";
        public string feemonth = "";
        public string classfrom = "";
        public string classto = "";

        public concession_summary()
        {
            InitializeComponent();
        }

        private void Head_Class_wise_feereport_Load(object sender, EventArgs e)
        {
            try
            {
                this.cONCESSION_SUMMARYTableAdapter.FillBy(this.dataSet_Fee_Summary_Reports.CONCESSION_SUMMARY, SYSTEMSETTING.sessionid);
                ReportParameter schoolname = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                this.reportViewer1.LocalReport.SetParameters(schoolname);

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {


           
        }

      

       

      


        
    }
}
