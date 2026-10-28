using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.Configuration;


namespace School.Fee_Summary_Reports
{
    public partial class STUCKOFF_LEAVE : Form
    {
        public string sessionid = "";

        public string datefrom = "";
        public string dateto = "";

        public string FROMCLASS = "0";
        public string TOCLASS = "0";

        public STUCKOFF_LEAVE()
        {
            InitializeComponent();
        }

        private void Head_Class_wise_feereport_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.sTUCKOFF_LEAVETableAdapter.FillBy2(this.dataSet_Fee_Summary_Reports.STUCKOFF_LEAVE,Convert.ToDecimal(SYSTEMSETTING.branch_ID),SYSTEMSETTING.sessionid,datefrom,dateto,Convert.ToDecimal(FROMCLASS), Convert.ToDecimal(TOCLASS));
                    
                    ReportParameter session = new ReportParameter("session", SYSTEMSETTING.sessionname);
                    this.reportViewer1.LocalReport.SetParameters(session);

                    ReportParameter startdate = new ReportParameter("startdate", datefrom);
                    this.reportViewer1.LocalReport.SetParameters(startdate);

                    ReportParameter enddate = new ReportParameter("enddate", dateto);
                    this.reportViewer1.LocalReport.SetParameters(enddate);

                    ReportParameter schoolname = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                    this.reportViewer1.LocalReport.SetParameters(schoolname);
                    
                    this.reportViewer1.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
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
