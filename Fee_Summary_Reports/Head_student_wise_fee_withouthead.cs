using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.Fee_Summary_Reports
{
    public partial class Head_student_wise_fee_withouthead : Form
    {
        public string sessionid = "";
        public string feemonth = "";
        public string classfrom = "";
        public string classto = "";
        public string PAID_TAG = "";
        public string HEAD_TAG = "";

        public string section_from = "";
        public string section_to = "";

        public string type_from = "";
        public string type_to = "";

        public Head_student_wise_fee_withouthead()
        {
            InitializeComponent();
        }

        private void Head_Class_wise_feereport_Load(object sender, EventArgs e)
        {
            try
            {
                //if (HEAD_TAG == "Y")
                //{
                //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Fee_Summary_Reports/Head_student_wise_fee.rdlc";
                //}
                //else
                //{
                //    this.reportViewer1.LocalReport.ReportEmbeddedResource = "School.Fee_Summary_Reports/Head_student_wise_fee.rdlc";
                //}
                

                if (PAID_TAG == "ALL")
                {
                    //this.hEAD_STUDENT_WISE_FEETableAdapter.FillBy_ALL(this.dataSet_Fee_Summary_Reports.HEAD_STUDENT_WISE_FEE, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(classfrom, typeof(decimal))))), new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(classto, typeof(decimal))))), sessionid, feemonth,section_from,section_to,type_from,type_to);
                    this.hEAD_STUDENT_WISE_FEETableAdapter.FillBy_ALL(this.dataSet_Fee_Summary_Reports.HEAD_STUDENT_WISE_FEE, sessionid, feemonth, section_from, section_to, type_from, type_to, Convert.ToDecimal(classfrom), Convert.ToDecimal(classto));
                }
                else if (PAID_TAG == "PAID")
                {
                    this.hEAD_STUDENT_WISE_FEETableAdapter.FillBy_PAID(this.dataSet_Fee_Summary_Reports.HEAD_STUDENT_WISE_FEE, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(classfrom, typeof(decimal))))), new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(classto, typeof(decimal))))), sessionid, feemonth, section_from, section_to, type_from, type_to);
                }
                else if (PAID_TAG == "NOT-PAID")
                {
                    this.hEAD_STUDENT_WISE_FEETableAdapter.FillBy_UNPAID(this.dataSet_Fee_Summary_Reports.HEAD_STUDENT_WISE_FEE, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(classfrom, typeof(decimal))))), new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(classto, typeof(decimal))))), sessionid, feemonth, section_from, section_to, type_from, type_to);
                }
                else
                {
                    MessageBox.Show("Invalid Paid Status!");
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
