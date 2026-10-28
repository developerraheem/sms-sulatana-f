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

namespace School.SF_REPORTS
{
    public partial class award_list_analysis : Form
    {
        public award_list_analysis()
        {
            InitializeComponent();
        }

        public string CLASSID = "";
        public string SECTIONID = "";
        public string STUDENTID = "";

        public string FRM_EXAM = "";
        public string TO_EXM = "";



        private void RPT_RESULTS_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            try
            {

                //this.rESULTS_MULTIPLETableAdapter.FillBy1_MULTIPLE(this.dataSet1.RESULTS_MULTIPLE, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(CLASSID, typeof(decimal))))),Convert.ToDecimal(STUDENTID));
                this.rESULTS_MULTIPLETableAdapter.FillBy1_classwise_analysis(this.dataSet1.RESULTS_MULTIPLE, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(CLASSID, typeof(decimal))))), SECTIONID, Convert.ToDecimal(FRM_EXAM), Convert.ToDecimal(TO_EXM));

                ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                this.reportViewer1.LocalReport.SetParameters(rpm);
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            {
                int Per_ID = Convert.ToInt32(e.Parameters["S_ID"].Values[0].ToString());
                DataTable dtsubreport = GetSubReportData(Per_ID);
                ReportDataSource ds = new ReportDataSource("DataSet1", dtsubreport);
                e.DataSources.Add(ds);
            }
        }
        private DataTable GetSubReportData(int StudentID)
        {
            DataTable dt = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["Sqlconn"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("SELECT  FEE_MONTH, ATTEND, COUNT(*) AS Expr1 FROM  att_stu GROUP BY FEE_MONTH, ATTEND, S_ID HAVING  (S_ID = '" + STUDENTID + "') ORDER BY FEE_MONTH", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                con.Close();

            }

            return dt;
        }


    }
}
