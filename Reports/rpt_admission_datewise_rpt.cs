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
    public partial class rpt_admission_datewise_rpt : Form
    {
        public rpt_admission_datewise_rpt()
        {
            InitializeComponent();
        }
        public string datefrom = "";
        public string dateto="";
        
        private void PrntUnpaidvoucher_Load(object sender, EventArgs e)
        {

            try
            {
                this.aDMISSION_DATEWISETableAdapter.FillBy(this.student_DataSet.ADMISSION_DATEWISE, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(datefrom, typeof(System.DateTime))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(dateto, typeof(System.DateTime))))));
                ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                this.reportViewer1.LocalReport.SetParameters(rpm);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
        }

       
    }
}
