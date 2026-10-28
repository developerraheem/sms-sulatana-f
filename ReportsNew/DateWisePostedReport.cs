using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.ReportsNew
{
    public partial class DateWisePostedReport : Form
    {
        public DateWisePostedReport()
        {
            InitializeComponent();
        }

        public string datefrom = "";
        public string dateto = "";
        public string scrollno = null;

     

        private void DateWisePostedReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.fEE_HISTORYTableAdapter.DateWiseList(this.report_DataSet_new.FEE_HISTORY, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(datefrom, typeof(System.DateTime))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(dateto, typeof(System.DateTime))))), Convert.ToDecimal(SYSTEMSETTING.sessionid), scrollno);
                reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
