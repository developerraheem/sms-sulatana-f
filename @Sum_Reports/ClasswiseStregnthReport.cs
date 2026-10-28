using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace School._forms
{
    public partial class ClasswiseStregnthReport : Form
    {
        public ClasswiseStregnthReport()
        {
            InitializeComponent();
        }
        

        private void PrntUnpaidvoucher_Load(object sender, EventArgs e)
        {
            
        }

        private void ClasswiseStregnthReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.class_wise_stregnthTableAdapter.Fill(this.report_DataSet_new.Class_wise_stregnth,Convert.ToDecimal(SYSTEMSETTING.branch_ID) ,SYSTEMSETTING.sessionid.ToString());
                ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                this.reportViewer1.LocalReport.SetParameters(rpm);
            }
            catch (Exception ex)
            {
                
            }
           
            this.reportViewer1.RefreshReport();
        }

        

       
    }
}
