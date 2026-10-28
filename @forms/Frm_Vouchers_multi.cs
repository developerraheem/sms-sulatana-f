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
using System.IO;


namespace School._forms
{
    public partial class Frm_Vouchers_multi : Form
    {
        public Frm_Vouchers_multi()
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
        public string sessionid = SYSTEMSETTING.sessionid;
        public List<string> SelectedStudentIds = null;


        private void Frm_Vouchers_Load(object sender, EventArgs e)
        {

            //this.voucherTableAdapter.Fill(this.report_dataset.Voucher);
            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);


            //if (SYSTEMSETTING.branch_ID == "15")
            //{
            //    //          reportViewer1.Reset();
            //    //          reportViewer1.LocalReport.ReportPath =
            //    //Application.StartupPath + @"\Reports\RptPrintAll_multi_BS.rdlc";
            //    //         reportViewer1.LocalReport.DataSources.Clear();


            //    Frm_Vouchers_multi_bs frm = new Frm_Vouchers_multi_bs();


            //    frm.classid = classid;
            //    frm.feemonth = feemonth;
            //    frm.param = param;
            //    frm.section = section;
            //    frm.admissionno = admissionno;
            //    frm.shift = shift;
            //    frm.sessionid = sessionid;

            //    frm.Show();

               



            //    this.Close();

            //}
            ////else if (SYSTEMSETTING.branch_ID == "15")
            ////{

            ////}
            //else
            //{
                
            //}

       
            //this.reportViewer1.RefreshReport();
            _class.FEE fee = new _class.FEE();
            if (param == "month")
            {
                try
                {
                    //this.voucher_PrintTableAdapter.Fill(this.report_DataSet_new.Voucher_Print, classid.ToString(), feemonth.ToString(), shift.ToString(), section.ToString());
                    fee.RecalculateClassUnpostedArrears(classid != null ? classid.ToString() : "", feemonth != null ? feemonth.ToString() : "", shift != null ? shift.ToString() : "", section != null ? section.ToString() : "", SYSTEMSETTING.sessionid, SYSTEMSETTING.branch_ID);
                    this.voucher_Print_multiTableAdapter.FillBy(this.report_DataSet_new.Voucher_Print_multi, classid.ToString(), feemonth, shift, section, Convert.ToDecimal(SYSTEMSETTING.sessionid));

                    if (SelectedStudentIds != null)
                    {
                        for (int i = this.report_DataSet_new.Voucher_Print_multi.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow row = this.report_DataSet_new.Voucher_Print_multi.Rows[i];
                            string sid = (row["s_id"] != DBNull.Value) ? row["s_id"].ToString() : "";
                            if (!SelectedStudentIds.Contains(sid))
                            {
                                row.Delete();
                            }
                        }
                        this.report_DataSet_new.Voucher_Print_multi.AcceptChanges();
                    }

                    ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                    this.reportViewer1.LocalReport.SetParameters(rpm);
                    this.reportViewer1.RefreshReport();
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
                    fee.RecalculateVoucherArrears(voucherno, SYSTEMSETTING.sessionid);
                    this.voucher_Print_multiTableAdapter.FillByVoucherNo(this.report_DataSet_new.Voucher_Print_multi, ((decimal)(System.Convert.ChangeType(voucherno, typeof(decimal)))), Convert.ToDecimal(SYSTEMSETTING.sessionid));
                    ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                    this.reportViewer1.LocalReport.SetParameters(rpm);
                    this.reportViewer1.RefreshReport();



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
                    fee.RecalculateStudentArrears(admissionno, SYSTEMSETTING.branch_ID, SYSTEMSETTING.sessionid);
                    //this.voucher_Print_multiTableAdapter.FillByStudentID(this.report_DataSet_new.Voucher_Print_multi, feemonth.ToString(), new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(admissionno, typeof(decimal))))), Convert.ToDecimal(SYSTEMSETTING.sessionid));
                    this.voucher_Print_multiTableAdapter.FillByStudentID(this.report_DataSet_new.Voucher_Print_multi, feemonth, Convert.ToDecimal(admissionno), Convert.ToDecimal(SYSTEMSETTING.sessionid));
                    ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                    this.reportViewer1.LocalReport.SetParameters(rpm);
                    this.reportViewer1.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }

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
