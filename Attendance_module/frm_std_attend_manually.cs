using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School.Attendance_module
{
    public partial class frm_std_attend_manually : Form
    {

        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        List<string> myListofQueries = new List<string>();


        public frm_std_attend_manually()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void frm_std_attend_manually_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'attendance_ds.ATTND_TYPE' table. You can move, or remove it, as needed.
            this.aTTND_TYPETableAdapter.Fill(this.attendance_ds.ATTND_TYPE);
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT] from SHIFT where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbsection, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
            SYS.comboFill(this.cmbclass, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.comboBox1, "SELECT [id],[description] FROM [ATTND] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "ATTND", "description", "id");
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            string QUERY = string.Empty;


            //CHECK IF ATTENDANCE ALREADY MARKED OR NOT
            try
            {
                QUERY = "Select * from att_stu where C_ID='" + cmbclass.SelectedValue + "' and SESSION_ID='" + SYSTEMSETTING.sessionid + "' and SECTION_ID='" + cmbsection.SelectedValue + "' and SHIFT_ID='" + cmbshift.SelectedValue + "' and ATTEND_DATE='" + txtdate.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                SqlConnection con = SYS.db_connect();
                con.Open();
                SqlCommand cmddr = new SqlCommand(QUERY, con);
                SqlDataReader dr = cmddr.ExecuteReader();
                if (dr.Read())
                {
                    button1.Enabled = true;
                    btndelete.Enabled = true;

                }
                else
                {
                    button1.Enabled = true;
                    btndelete.Enabled = false;
                }
                dr.Close();
                con.Close();
                cmddr.Dispose();
            }
            catch (Exception ex)
            {

            }

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            QUERY = "SELECT s_id, s_name, roll_no, ADMISSION_NO, f_name FROM  student WHERE  (c_id = '" + cmbclass.SelectedValue + "') AND (SECTION_ID = '" + cmbsection.SelectedValue + "') AND (SessionID = '" + SYSTEMSETTING.sessionid + "') AND (SHIFT = '" + cmbshift.SelectedValue + "') AND ACTIVE='true' and branch_id='" + SYSTEMSETTING.branch_ID + "' order by pecent desc";


            if (RDOSSC.Checked == true)
            {
                QUERY = "SELECT a.s_id, a.s_name, a.roll_no, a.ADMISSION_NO, a.f_name ,SSC_prcnt as pecent FROM  student a  left outer join PREVIOUS_ACADEMICS b ";
                QUERY = QUERY + " on a.SessionID=b.session_id and a.c_id=b.c_id and a.s_id=b.s_id and a.branch_id=b.branch_id WHERE  (a.c_id = '" + cmbclass.SelectedValue + "') AND (a.SECTION_ID = '" + cmbsection.SelectedValue + "') AND (a.SessionID = '" + SYSTEMSETTING.sessionid + "') AND (a.SHIFT = '" + cmbshift.SelectedValue + "') AND ACTIVE='true' and a.branch_id='" + SYSTEMSETTING.branch_ID + "' order by pecent desc";

            }
            else if (rdohssc.Checked == true)
            {
                QUERY = "SELECT a.s_id, a.s_name, a.roll_no, a.ADMISSION_NO, a.f_name ,HSSC_Prcnt  as pecent FROM  student a  left outer join PREVIOUS_ACADEMICS b ";
                QUERY = QUERY + " on a.SessionID=b.session_id and a.c_id=b.c_id and a.s_id=b.s_id and a.branch_id=b.branch_id WHERE  (a.c_id = '" + cmbclass.SelectedValue + "') AND (a.SECTION_ID = '" + cmbsection.SelectedValue + "') AND (a.SessionID = '" + SYSTEMSETTING.sessionid + "') AND (a.SHIFT = '" + cmbshift.SelectedValue + "') AND ACTIVE='true' and a.branch_id='" + SYSTEMSETTING.branch_ID + "' order by pecent desc";

            }

            else if (rdograd.Checked == true)
            {
                QUERY = "SELECT a.s_id, a.s_name, a.roll_no, a.ADMISSION_NO, a.f_name ,GRAD_Prcnt  as pecent FROM  student a  left outer join PREVIOUS_ACADEMICS b ";
                QUERY = QUERY + " on a.SessionID=b.session_id and a.c_id=b.c_id and a.s_id=b.s_id and a.branch_id=b.branch_id WHERE  (a.c_id = '" + cmbclass.SelectedValue + "') AND (a.SECTION_ID = '" + cmbsection.SelectedValue + "') AND (a.SessionID = '" + SYSTEMSETTING.sessionid + "') AND (a.SHIFT = '" + cmbshift.SelectedValue + "') AND ACTIVE='true' and a.branch_id='" + SYSTEMSETTING.branch_ID + "' order by pecent desc";

            }


            //QUERY = "SELECT a.s_id, a.s_name, a.roll_no, a.ADMISSION_NO, a.f_name ,SSC_prcnt, HSSC_Prcnt, GRAD_Prcnt FROM  student a  left outer join PREVIOUS_ACADEMICS b ";
            //QUERY = QUERY + " on a.SessionID=b.session_id and a.c_id=b.c_id and a.s_id=b.s_id and a.branch_id=b.branch_id WHERE  (a.c_id = '" + cmbclass.SelectedValue + "') AND (a.SECTION_ID = '" + cmbsection.SelectedValue + "') AND (a.SessionID = '" + SYSTEMSETTING.sessionid + "') AND (a.SHIFT = '" + cmbshift.SelectedValue + "') AND ACTIVE='true' and a.branch_id='" + SYSTEMSETTING.branch_ID + "' order by pecent desc";



            rs = SYS.Show_Query(QUERY);
            foreach (DataRow RowDocument in rs.Tables[0].Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                row.Cells[0].Value = RowDocument["s_id"];
                row.Cells[1].Value = RowDocument["roll_no"];
                row.Cells[2].Value = RowDocument["ADMISSION_NO"];
                row.Cells[3].Value = RowDocument["s_name"];
                row.Cells[4].Value = RowDocument["f_name"];
                row.Cells[5].Value = comboBox1.SelectedValue;

                //row.Cells[6].Value = RowDocument["pecent"];
                row.Cells[6].Value = "0";


                dataGridView1.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are going to Update Attendance Dated :  " + txtdate.Text + ",   Fee Month   " + txtfeemonth.Text + "", "Mark Attendance", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                #region
                string query = "";
                string classid;
                string shift = "";
                string section = "";
                string sessionid = SYSTEMSETTING.sessionid;

                string abc = System.DateTime.Today.DayOfWeek.ToString();


                //Int64 studentid = student_s_id();
                //int rollno = 1;
                //int sno = 1;
                string ATTEND = string.Empty;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    classid = cmbclass.SelectedValue.ToString();
                    shift = cmbshift.SelectedValue.ToString();
                    section = cmbsection.SelectedValue.ToString();
                    try
                    {
                        if (string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["clmtype"].Value.ToString()))
                        {
                            ATTEND = "P";
                        }
                        else
                        {
                            ATTEND = dataGridView1.Rows[i].Cells["clmtype"].Value.ToString();
                        }
                    }
                    catch (Exception exp)
                    {
                        ATTEND = "P";
                    }

                    //if (dataGridView1.Rows[i].Cells["clmtype"].Value.ToString() == "" || dataGridView1.Rows[i].Cells["clmtype"].Value.ToString() == string.Empty)
                    //{
                    //    ATTEND = "P";
                    //}
                    //else
                    //{
                    //    ATTEND = dataGridView1.Rows[i].Cells["clmtype"].Value.ToString();
                    //}

                    string QUERY = "";
                    QUERY = "Select * from att_stu where C_ID='" + cmbclass.SelectedValue + "' and SESSION_ID='" + SYSTEMSETTING.sessionid + "' and SECTION_ID='" + cmbsection.SelectedValue + "' and SHIFT_ID='" + cmbshift.SelectedValue + "' and ATTEND_DATE='" + txtdate.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' AND S_ID='" + dataGridView1.Rows[i].Cells["ID"].Value.ToString() + "'";
                    SqlConnection con = SYS.db_connect();
                    con.Open();
                    SqlCommand cmddr = new SqlCommand(QUERY, con);
                    SqlDataReader dr = cmddr.ExecuteReader();
                    if (dr.Read())
                    {
                        //query = "insert into att_stu(C_ID,SESSION_ID,SECTION_ID,S_ID,ADM_NO,ROLL_NO,STUDENT_NAME,FATHER_NAME,ATTEND,FEE_MONTH,ATTEND_DATE,SHIFT_ID,branch_id,MARKS_PERCENT)";
                        //query = query + "VALUES('" + cmbclass.SelectedValue + "','" + SYSTEMSETTING.sessionid + "','" + cmbsection.SelectedValue.ToString().Trim() + "','" + dataGridView1.Rows[i].Cells["ID"].Value + "','" + dataGridView1.Rows[i].Cells["ADMISSION_NO"].Value + "','" + dataGridView1.Rows[i].Cells["ROLL_NO"].Value + "','" + dataGridView1.Rows[i].Cells["NAME"].Value + "','" + dataGridView1.Rows[i].Cells["FNAME"].Value + "','" + ATTEND + "','" + txtfeemonth.Text + "','" + txtdate.Text + "','" + cmbshift.SelectedValue.ToString().Trim() + "','" + SYSTEMSETTING.branch_ID + "','" + dataGridView1.Rows[i].Cells["SSC"].Value + "')";

                        query = "Update att_stu set ATTEND='" + ATTEND + "', MARKS_PERCENT='" + dataGridView1.Rows[i].Cells["SSC"].Value + "' where C_ID='" + cmbclass.SelectedValue + "' and SESSION_ID='" + SYSTEMSETTING.sessionid + "' and SECTION_ID='" + cmbsection.SelectedValue + "' and SHIFT_ID='" + cmbshift.SelectedValue + "' and ATTEND_DATE='" + txtdate.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' AND S_ID='" + dataGridView1.Rows[i].Cells["ID"].Value.ToString() + "'";
                        myListofQueries.Add(query);


                    }
                    else
                    {

                        query = "insert into att_stu(C_ID,SESSION_ID,SECTION_ID,S_ID,ADM_NO,ROLL_NO,STUDENT_NAME,FATHER_NAME,ATTEND,FEE_MONTH,ATTEND_DATE,SHIFT_ID,branch_id,MARKS_PERCENT)";
                        query = query + "VALUES('" + cmbclass.SelectedValue + "','" + SYSTEMSETTING.sessionid + "','" + cmbsection.SelectedValue.ToString().Trim() + "','" + dataGridView1.Rows[i].Cells["ID"].Value + "','" + dataGridView1.Rows[i].Cells["ADMISSION_NO"].Value + "','" + dataGridView1.Rows[i].Cells["ROLL_NO"].Value + "','" + dataGridView1.Rows[i].Cells["NAME"].Value + "','" + dataGridView1.Rows[i].Cells["FNAME"].Value + "','" + ATTEND + "','" + txtfeemonth.Text + "','" + txtdate.Text + "','" + cmbshift.SelectedValue.ToString().Trim() + "','" + SYSTEMSETTING.branch_ID + "','" + dataGridView1.Rows[i].Cells["SSC"].Value + "')";
                        myListofQueries.Add(query);

                    }
                    dr.Close();
                    con.Close();
                    cmddr.Dispose();



                    //query = "insert into att_stu(C_ID,SESSION_ID,SECTION_ID,S_ID,ADM_NO,ROLL_NO,STUDENT_NAME,FATHER_NAME,ATTEND,FEE_MONTH,ATTEND_DATE,SHIFT_ID,branch_id,MARKS_PERCENT)";
                    //query = query + "VALUES('" + cmbclass.SelectedValue + "','" + SYSTEMSETTING.sessionid + "','" + cmbsection.SelectedValue.ToString().Trim() + "','" + dataGridView1.Rows[i].Cells["ID"].Value + "','" + dataGridView1.Rows[i].Cells["ADMISSION_NO"].Value + "','" + dataGridView1.Rows[i].Cells["ROLL_NO"].Value + "','" + dataGridView1.Rows[i].Cells["NAME"].Value + "','" + dataGridView1.Rows[i].Cells["FNAME"].Value + "','" + ATTEND + "','" + txtfeemonth.Text + "','" + txtdate.Text + "','" + cmbshift.SelectedValue.ToString().Trim() + "','" + SYSTEMSETTING.branch_ID + "','" + dataGridView1.Rows[i].Cells["SSC"].Value + "')";

                    //myListofQueries.Add(query);
                    // }

                }

                bool CHECK = false;
                string[] bulkqueries1 = myListofQueries.ToArray();
                CHECK = SYS.Insert_Query_manualcommit(bulkqueries1);

                if (CHECK == true)
                {
                    SYS.setMessageBox("Attendance Marked Succesfully", 1);
                    myListofQueries.Clear();
                    bulkqueries1 = null;
                    button1.Enabled = false;
                }

                else
                {
                    SYS.setCreateError("Attendance Not Marked! Please try later!");
                    myListofQueries.Clear();
                    bulkqueries1 = null;
                }

                #endregion
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            rpt_class_wise_attendance rpt = new rpt_class_wise_attendance();
            rpt.CLASS = cmbclass.SelectedValue.ToString();
            rpt.SECTION = cmbsection.SelectedValue.ToString();
            rpt.SESSION = SYSTEMSETTING.sessionid.ToString();
            rpt.MONTH = txtfeemonth.Text;
            rpt.SHIFT = cmbshift.SelectedValue.ToString();
            rpt.Show();

        }

        private void btnshow_Click_1(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            bool chk = false;
            if (MessageBox.Show("You are going to Delete Attendance Dated :  " + txtdate.Text + ",   Fee Month   " + txtfeemonth.Text + "", "Delete Attendance", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

               chk= SYS.Insert_Query("Delete from att_stu where C_ID='" + cmbclass.SelectedValue + "' and SESSION_ID='" + SYSTEMSETTING.sessionid + "' and SECTION_ID='" + cmbsection.SelectedValue + "' and SHIFT_ID='" + cmbshift.SelectedValue + "' and ATTEND_DATE='" + txtdate.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
               if (chk == true)
               {
                   SYS.setMessageBox("Attendance Record Deleted!",1);
               }
               else

               {
                   SYS.setCreateError("Attendance Record Not Deleted Please try again!");
               }

            }
        }


    }
}
