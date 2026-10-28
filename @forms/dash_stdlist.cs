using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace School._forms
{
    public partial class dash_stdlist : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        public string STUDENT_ID = "";
        public string CLASS_ID = "";

        public dash_stdlist()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void BTN_PNL_CLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dash_stdlist_Load(object sender, EventArgs e)
        {
            GetstudentData();
            LodOutstanding();
            GetTotal();
        }
        public void GetstudentData()
        {
            rs = SYS.Show_Query("select ADMISSION_NO,s_name,f_name,Class.c_name + '-' + student.SECTION_ID as SECTION_ID,contact_no,image,address from student, class where class.c_id=student.c_id and s_id='" + STUDENT_ID + "'");

            if (rs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {

                    txtadmno.Text = RowDocument["ADMISSION_NO"].ToString();
                    txtstdname.Text = RowDocument["s_name"].ToString();
                    txtfname.Text = RowDocument["f_name"].ToString();
                    txtclass.Text = RowDocument["SECTION_ID"].ToString();
                    txthpone.Text = RowDocument["contact_no"].ToString();
                    txtaddress.Text = RowDocument["address"].ToString();

                    try
                    {
                        if (RowDocument["image"] != DBNull.Value)
                        {
                            byte[] img_arr1 = (byte[])RowDocument["image"];
                            using (MemoryStream ms1 = new MemoryStream(img_arr1))
                            {
                                pictureBox2.Image = Image.FromStream(ms1);
                            }
                        }
                        else
                        {
                            //  pictureBox2.Image = null;  // or set default image
                        }
                    }
                    catch (Exception exp)
                    {


                    }


                }
            }
        }


        public void GetTotal()
        {
            try
            {
                string query = "";
                query = "select SUM(f.REC_AMOUNT) AS RECEIVED_AMOUNT,SUM(f.RECEIVABLE_AMOUNT) AS RECEIVABLE,SUM(f.BALANCE) AS BALANCE from FEE_MASTER f, student s, class c  where f.branch_id='" + SYSTEMSETTING.branch_ID + "'   and f.SessionID='" + SYSTEMSETTING.sessionid + "'    and f.C_ID='" + CLASS_ID + "'    and f.s_id= s.s_id and f.branch_id=s.branch_id and f.C_ID=c.c_id   and f.branch_id=c.branch_id and f.s_id='" + STUDENT_ID + "'";
                rs = SYS.Show_Query(query);
                if (rs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow RowDocument in rs.Tables[0].Rows)
                    {
                        lbltotalfee.Text = RowDocument["RECEIVABLE"].ToString();
                        lblreceived.Text = RowDocument["RECEIVED_AMOUNT"].ToString();
                        lblbalance.Text = RowDocument["BALANCE"].ToString();

                        lbltotalfee.Text = Convert.ToDecimal(lbltotalfee.Text).ToString("N0");
                        lblreceived.Text = Convert.ToDecimal(lblreceived.Text).ToString("N0");
                        lblbalance.Text = Convert.ToDecimal(lblbalance.Text).ToString("N0");
                    }
                }
            }
            catch (Exception exp)
            {


            }
        }

        public void LodOutstanding()
        {
            try
            {


                string query = "select f.FEE_MASTER_ID,f.FEE_MONTH,f.REC_AMOUNT,f.RECEIVABLE_AMOUNT,f.BALANCE from FEE_MASTER f, student s, class c  where f.branch_id='" + SYSTEMSETTING.branch_ID + "'   and f.SessionID='" + SYSTEMSETTING.sessionid + "'    and f.C_ID='" + CLASS_ID + "'    and f.s_id= s.s_id and f.branch_id=s.branch_id and f.C_ID=c.c_id   and f.branch_id=c.branch_id and f.s_id='" + STUDENT_ID + "' ORDER BY f.FEE_MASTER_ID ";
                SYS.Filllist_DataView(query, this.lst_ledger);


                query = "SELECT FEE_MONTH AS [Month],COUNT(*) AS [Total Working Days],SUM(CASE WHEN ATTEND = 'A' THEN 1 ELSE 0 END) AS [Absent],SUM(CASE WHEN ATTEND = 'L' THEN 1 ELSE 0 END) AS [Leave],SUM(CASE WHEN ATTEND = 'P' THEN 1 ELSE 0 END) AS [Present],ROUND((SUM(CASE WHEN ATTEND = 'P' THEN 1 ELSE 0 END) * 100.0 / COUNT(*)), 2) AS [Percentage] FROM att_stu WHERE s_id = '" + STUDENT_ID + "' AND SESSION_ID = '" + SYSTEMSETTING.sessionid + "' AND C_ID = '" + CLASS_ID + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "' GROUP BY FEE_MONTH ORDER BY FEE_MONTH";
                SYS.Filllist_DataView(query, this.lst_attendance);

                // Attendance Percentage
                rs = SYS.Show_Query("SELECT  STUDENT_NAME, SUM(CASE WHEN ATTEND = 'P' THEN 1 ELSE 0 END) AS PresentDays, COUNT(*) AS TotalDays, ROUND(SUM(CASE WHEN ATTEND = 'P' THEN 1 ELSE 0 END) * 100.0 / COUNT(*), 2) AS AttendancePercentage FROM att_stu WHERE S_ID='" + STUDENT_ID + "' AND SESSION_ID = '" + SYSTEMSETTING.sessionid + "' AND C_ID = '" + CLASS_ID + "' AND branch_id = '" + SYSTEMSETTING.branch_ID + "'  GROUP BY STUDENT_NAME;");
                if (rs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow RowDocument in rs.Tables[0].Rows)
                    {
                        lbl_attend_percent.Text = RowDocument["AttendancePercentage"].ToString();
                    }
                    if (lbl_attend_percent.Text.Length > 0)
                    {
                        lbl_attend_percent.Text = Convert.ToDecimal(lbl_attend_percent.Text).ToString("N0");
                        lbl_attend_percent.Text = lbl_attend_percent.Text + "%";
                    }
                }


                //Progress Report Percentage
                rs = SYS.Show_Query("SELECT student.s_name,sum(RESULTS.TOTAL_MARKS) as TOTAL_MARKS,sum(RESULTS.OBT_MARKS) as OBT_MARKS, ROUND((sum(RESULTS.OBT_MARKS) * 100.0) / sum(RESULTS.TOTAL_MARKS), 2) AS Percentage FROM RESULTS INNER JOIN  student ON RESULTS.S_ID = student.s_id WHERE RESULTS.CLASS_ID = '" + CLASS_ID + "' AND RESULTS.S_ID = '" + STUDENT_ID + "' group by student.s_name");
                if (rs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow RowDocument in rs.Tables[0].Rows)
                    {
                        lbl_progress_percent.Text = RowDocument["Percentage"].ToString();
                    }
                    if (lbl_progress_percent.Text.Length > 0)
                    {
                        lbl_progress_percent.Text = Convert.ToDecimal(lbl_progress_percent.Text).ToString("N0");
                        lbl_progress_percent.Text = lbl_progress_percent.Text + "%";
                    }
                }


            }
            catch (Exception exp)
            {


            }
        }

    }
}
