using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace School._Sum_Reports
{
    public partial class rptstreginths_mwisee : Form
    {
        public rptstreginths_mwisee()
        {
            InitializeComponent();
        }
        
        public string feemonth = "";
        public string classid = "";
        public string shift = "";
        public string sectionid = "";
        public string sessionid = "";

        private void rptstreginths_mwisee_Load(object sender, EventArgs e)
        {
            try
            {


                //this.aDMISSION_STREGNTH_REPORTTableAdapter.GetData(this.student_DataSet.student_Stregnth_monthwise, classid, shift, feemonth, sectionid, ((decimal)(System.Convert.ChangeType(SYSTEMSETTING.sessionid, typeof(decimal)))));
                this.aDMISSION_STREGNTH_REPORTTableAdapter.FillBy(this.student_DataSet.ADMISSION_STREGNTH_REPORT, classid, shift, feemonth, sectionid, ((decimal)(System.Convert.ChangeType(SYSTEMSETTING.sessionid, typeof(decimal)))));

                ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                this.reportViewer1.LocalReport.SetParameters(rpm);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

       

    

           }
}
