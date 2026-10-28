using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace School._forms
{
    public partial class Frm_Vouchers : Form
    {
        public Frm_Vouchers()
        {
            InitializeComponent();
        }
        public string classid = "";
        public string feemonth = "";
        public string shift = "";
        public string admissionno = "";
        public string voucherno = "";
        public string section = "";
        public string param = "";
        public string sessionid = "0";
        public List<string> SelectedStudentIds = null;


        private void Frm_Vouchers_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            _class.FEE fee = new _class.FEE();
            if (param == "month")
            {
                try
                {
                    fee.RecalculateClassUnpostedArrears(classid != null ? classid.ToString() : "", feemonth != null ? feemonth.ToString() : "", shift != null ? shift.ToString() : "", section != null ? section.ToString() : "", sessionid, SYSTEMSETTING.branch_ID);
                    this.voucher_PrintTableAdapter.Fill(this.report_DataSet_new.Voucher_Print, classid.ToString(), feemonth.ToString(), shift.ToString(), section.ToString(), Convert.ToDecimal(sessionid));

                    if (SelectedStudentIds != null)
                    {
                        for (int i = this.report_DataSet_new.Voucher_Print.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow row = this.report_DataSet_new.Voucher_Print.Rows[i];
                            string sid = (row["s_id"] != DBNull.Value) ? row["s_id"].ToString() : "";
                            if (!SelectedStudentIds.Contains(sid))
                            {
                                row.Delete();
                            }
                        }
                        this.report_DataSet_new.Voucher_Print.AcceptChanges();
                    }
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
            else if (param == "voucherno")
            {
                try
                {
                    fee.RecalculateVoucherArrears(voucherno, sessionid);
                    this.voucher_PrintTableAdapter.FillByVoucherNo(this.report_DataSet_new.Voucher_Print, ((decimal)(System.Convert.ChangeType(voucherno, typeof(decimal)))), Convert.ToDecimal(sessionid));
            //        this.reportViewer1.RefreshReport();



                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            else if (param == "AdmissionNo")
            {
                try
                {
                    fee.RecalculateStudentArrears(admissionno, SYSTEMSETTING.branch_ID, sessionid);
                    this.voucher_PrintTableAdapter.FillByStudentID(this.report_DataSet_new.Voucher_Print, feemonth, Convert.ToDecimal(admissionno), Convert.ToDecimal(sessionid));
                   // this.reportViewer1.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }

            ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
            this.reportViewer1.LocalReport.SetParameters(rpm);
            
            this.reportViewer1.RefreshReport();

        }
        
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            {
                int Per_ID = Convert.ToInt32(e.Parameters["studentID"].Values[0].ToString());
                string feemonth = e.Parameters["feemonth"].Values[0].ToString();
                DataTable dtsubreport = GetSubReportData(Per_ID, feemonth);
                ReportDataSource ds = new ReportDataSource("DataSet1", dtsubreport);
                e.DataSources.Add(ds);
            }
        }

        private DataTable GetSubReportData(int StudentID, string feemonth)
        {
            DataTable dt = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["Sqlconn"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("select FEE_MONTH,RECEIVABLE_AMOUNT,BALANCE,s_id  from FEE_MASTER where s_id='" + StudentID + "' and FEE_MONTH <> '" + feemonth + "' order by FEE_MASTER_ID desc", con);
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

        private DataSet GetData11(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["Sqlconn"].ConnectionString.ToString();
            SqlCommand cmd = new SqlCommand(query);

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;

                    using (DataSet DataSet1 = new DataSet())
                    {
                        sda.Fill(DataSet1, "FEE_PREVIOUS");
                        return DataSet1;
                    }
                }
            }
        }


        private void fillByStudentIDToolStripButton_Click(object sender, EventArgs e)
        {


        }







    }
}
