using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class classwisefeeheadreport : Form
    {
        public classwisefeeheadreport()
        {
            InitializeComponent();
        }

        public string feemonth = "";
        public string feeheadid = "";
        public string classid = "";
        public string shift = "";
        public string sectionid = "";
        public string param = "";
        public string fromdate = "";
        public string todate = "";


        private void ClasswiseStregnthReport_Load(object sender, EventArgs e)
        {
            try
            {
                if (param == "All")
                {
                    this.fee_head_wise_reportTableAdapter.FillBy(this.student_DataSet.Fee_head_wise_report, feeheadid, ((decimal)(System.Convert.ChangeType(classid, typeof(decimal)))), feemonth, shift, sectionid, SYSTEMSETTING.sessionid);
                }
                else if (param == "Paid")
                {
                    this.fee_head_wise_reportTableAdapter.FillByPaid(this.student_DataSet.Fee_head_wise_report, feeheadid, ((decimal)(System.Convert.ChangeType(classid, typeof(decimal)))), feemonth, shift, sectionid, SYSTEMSETTING.sessionid);
                }
                else if (param == "UnPaid")
                {
                    this.fee_head_wise_reportTableAdapter.FillByUnpaid(this.student_DataSet.Fee_head_wise_report, feeheadid, ((decimal)(System.Convert.ChangeType(classid, typeof(decimal)))), feemonth, shift, sectionid, SYSTEMSETTING.sessionid);
                }
                else if (param == "Bydate")
                {
                    this.fee_head_wise_reportTableAdapter.FillBy1dates(this.student_DataSet.Fee_head_wise_report, feeheadid, ((decimal)(System.Convert.ChangeType(classid, typeof(decimal)))), feemonth, shift, sectionid, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(fromdate, typeof(System.DateTime))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(todate, typeof(System.DateTime))))), SYSTEMSETTING.sessionid);
                }

                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            
        }

       
    }
}
