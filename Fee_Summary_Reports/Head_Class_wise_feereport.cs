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
    public partial class Head_Class_wise_feereport : Form
    {

        public string isdatewise = "N";
        public string startdate = "";
        public string enddate = "";

        public string sessionid = "";
        public string feemonth = "";
        public string feemonthto = "";
        public string classfrom = "";

        public string datefrom = "";
        public string dateto = "";

        public string classto = "";

        public Head_Class_wise_feereport()
        {
            InitializeComponent();
        }

        private void Head_Class_wise_feereport_Load(object sender, EventArgs e)
        {
            if (isdatewise == "N")
            {
                try
                {
                    this.head_Class_wise_FeereportTableAdapter1.FillBy1(this.dataSet_Fee_Summary_Reports.Head_Class_wise_Feereport, sessionid, ((decimal)(System.Convert.ChangeType(classfrom, typeof(decimal)))), ((decimal)(System.Convert.ChangeType(classto, typeof(decimal)))), feemonth, feemonth);
                    //this.head_Class_wise_FeereportTableAdapter1.FillBy1(this.dataSet_Fee_Summary_Reports.Head_Class_wise_Feereport, sessionid, ((decimal)(System.Convert.ChangeType(classfrom, typeof(decimal)))), ((decimal)(System.Convert.ChangeType(classto, typeof(decimal)))));

                    ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                    this.reportViewer1.LocalReport.SetParameters(rpm);

                    ReportParameter rpm1 = new ReportParameter("session", SYSTEMSETTING.sessionname);
                    this.reportViewer1.LocalReport.SetParameters(rpm1);

                    ReportParameter dfrom = new ReportParameter("datefrom", datefrom);
                    this.reportViewer1.LocalReport.SetParameters(dfrom);

                    ReportParameter dto = new ReportParameter("dateto", dateto);
                    this.reportViewer1.LocalReport.SetParameters(dto);


                    this.reportViewer1.RefreshReport();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                try
                {
                    this.head_Class_wise_FeereportTableAdapter1.Datewise(this.dataSet_Fee_Summary_Reports.Head_Class_wise_Feereport, sessionid, ((decimal)(System.Convert.ChangeType(classfrom, typeof(decimal)))), ((decimal)(System.Convert.ChangeType(classto, typeof(decimal)))), startdate, enddate);
                    //this.head_Class_wise_FeereportTableAdapter1.FillBy1(this.dataSet_Fee_Summary_Reports.Head_Class_wise_Feereport, sessionid, ((decimal)(System.Convert.ChangeType(classfrom, typeof(decimal)))), ((decimal)(System.Convert.ChangeType(classto, typeof(decimal)))));

                    ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                    this.reportViewer1.LocalReport.SetParameters(rpm);

                    ReportParameter rpm1 = new ReportParameter("session", SYSTEMSETTING.sessionname);
                    this.reportViewer1.LocalReport.SetParameters(rpm1);

                    ReportParameter dfrom = new ReportParameter("datefrom", datefrom);
                    this.reportViewer1.LocalReport.SetParameters(dfrom);

                    ReportParameter dto = new ReportParameter("dateto", dateto);
                    this.reportViewer1.LocalReport.SetParameters(dto);


                    this.reportViewer1.RefreshReport();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
