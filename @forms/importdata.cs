using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School._forms
{
    public partial class importdata : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        public importdata()
        {
            InitializeComponent();
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            double STUDENT_ID = 0;
            rs = SYS.Show_Query("select max(s_id)+1 from [student]");

            foreach (DataRow RowMax in rs.Tables[0].Rows)
            {
                STUDENT_ID = Convert.ToDouble(RowMax[0].ToString());
            }

            string query = string.Empty;
            bool a = false;
            rs = SYS.Show_Query("SELECT *  FROM [SCMS_SF_LIVE].[dbo].['Dept-5$']");
            if (rs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    //					 							

                    //query = "INSERT INTO STUDENT (c_id,s_id,ADMISSION_NO,s_name,f_name,roll_no,m_fee,SECTION_ID,SessionID,SHIFT,TYPE,ACTIVE) VALUES(" + RowDocument["c_id"].ToString() + "," + RowDocument["s_id"].ToString() + ",'" + RowDocument["ADMISSION_NO"].ToString() + "','" + RowDocument["s_name"].ToString() + "','" + RowDocument["f_name"].ToString() + "','" + RowDocument["roll_no"].ToString() + "'," + RowDocument["m_fee"].ToString() + ",'" + RowDocument["SECTION_ID"] + "','" + RowDocument["SessionID"].ToString() + "','" + RowDocument["SHIFT"].ToString() + "','" + RowDocument["TYPE"].ToString() + "','true')";

                    //query = "INSERT INTO STUDENT (c_id,s_id,ADMISSION_NO,s_name,f_name,roll_no,m_fee,SECTION_ID,SessionID,SHIFT,TYPE,ACTIVE,CNIC_MOTHER,CNIC_FATHER,d_birth,sex,contact_no,RELEGION,FATHER_OCCUPATION,TEL_OFFICE,TEL_RESI,address,G_NAME,G_RELATION,G_MOBILE,G_PHONE,G_ADDRESS,branch_id)";
                    //query = query + " VALUES(" + RowDocument["c_id"].ToString() + "," + STUDENT_ID + ",'" + RowDocument["ADMISSION_NO"].ToString() + "','" + RowDocument["s_name"].ToString() + "','" + RowDocument["f_name"].ToString() + "','" + RowDocument["roll_no"].ToString() + "',0,'" + RowDocument["SECTION_ID"] + "','" + RowDocument["session_id"] + "','" + RowDocument["Shift "].ToString() + "','General','true'";
                    //query = query + ",'" + RowDocument["student_CNIC"].ToString() + "','" + RowDocument["CNIC_FATHER"].ToString() + "','" + RowDocument["DoB_student"].ToString() + "','" + RowDocument["GENDER"].ToString() + "','" + RowDocument["contact_no"].ToString() + "','" + RowDocument["RELIGION"].ToString() + "','" + RowDocument["FATHER_OCCUPATION"].ToString() + "','" + RowDocument["contact_father"].ToString() + "','" + RowDocument["contact_father_of"].ToString() + "','" + RowDocument["Mailing adress"].ToString() + "','" + RowDocument["Gardian_Name"].ToString() + "','" + RowDocument["Gradian_Relation"].ToString() + "','" + RowDocument["Gardian_Contact"].ToString() + "','" + RowDocument["Emergency_Contact"].ToString() + "','" + RowDocument["E_mail"].ToString() + "','4')";
                    Guid guid = Guid.NewGuid();
                    string strGUID = guid.ToString();


                    query = "INSERT INTO STUDENT ([s_id],[TYPE],[ACTIVE],[ADMISSION_NO],[roll_no],[c_id],[SECTION_ID],[SessionID],[SHIFT],[s_name],[f_name],[RELEGION],[sex],[CNIC_MOTHER],[FATHER_OCCUPATION],[address],[contact_no],[G_MOBILE],[TEL_OFFICE],[CNIC_FATHER],[EMAIL],[P_EMPNAME],[G_NAME],[G_PHONE],[G_RELATION],[branch_id],[STUDENT_ID])";
                    query = query + " Values ('" + STUDENT_ID + "','General','true','" + RowDocument["ADMISSION_NO"].ToString() + "','" + RowDocument["roll_no"].ToString() + "','" + RowDocument["c_id"].ToString() + "','" + RowDocument["SECTION_ID"].ToString() + "','" + RowDocument["SessionID"].ToString() + "','" + RowDocument["SHIFT"].ToString() + "','" + RowDocument["s_name"].ToString() + "','" + RowDocument["f_name"].ToString() + "','" + RowDocument["RELEGION"].ToString() + "','" + RowDocument["sex"].ToString() + "','" + RowDocument["CNIC_MOTHER"].ToString() + "','" + RowDocument["FATHER_OCCUPATION"].ToString() + "','','" + RowDocument["contact_no"].ToString() + "','" + RowDocument["G_MOBILE"].ToString() + "','" + RowDocument["TEL_OFFICE"].ToString() + "','" + RowDocument["CNIC_FATHER"].ToString() + "','','" + RowDocument["P_EMPNAME"].ToString() + "','" + RowDocument["G_NAME"].ToString() + "','" + RowDocument["G_PHONE"].ToString() + "','" + RowDocument["G_RELATION"].ToString() + "','5','" + strGUID + "')";

                    a = SYS.Insert_Query(query);
                    if (a == true)
                    {

                        query = "insert into student_class_history(s_id,ADMISSION_NO,c_id,section_id,session_id,branch_id)values(" + STUDENT_ID + ",'" + RowDocument["ADMISSION_NO"].ToString() + "'," + RowDocument["c_id"].ToString() + ",'" + RowDocument["SECTION_ID"] + "','" + RowDocument["SessionID"] + "','5')";
                        SYS.Insert_Query(query);


                        // SSC_year	 SSC_A_S	SSC_Board	SSC_Subject	SSC_Totalmarks	SSC_Makrsobt	SSC_prcnt	HSSC_Year	HSSC_A_S	HSSC_Board	HSSC_Subjects	HSSC_Total_marks	HSSC_Marks_obt	HSSC_Prcnt

                        //query = "insert into PREVIOUS_ACADEMICS(s_id,c_id,ADMISSION_NO,session_id,SSC_year,SSC_A_S,SSC_Board,SSC_Subject,SSC_Totalmarks,SSC_Makrsobt,SSC_prcnt,HSSC_Year,HSSC_A_S,HSSC_Board,HSSC_Subjects,HSSC_Total_marks,HSSC_Marks_obt,HSSC_Prcnt)";
                        //query = query + " values(" + RowDocument["s_id"].ToString() + "," + RowDocument["c_id"].ToString() + ",'" + RowDocument["ADMISSION_NO"].ToString() + "','" + RowDocument["session_id"] + "','" + RowDocument["SSC_year"].ToString() + "','" + RowDocument["SSC_A_S"].ToString() + "','" + RowDocument["SSC_Board"].ToString() + "','" + RowDocument["SSC_Subject"].ToString() + "','" + RowDocument["SSC_Totalmarks"].ToString() + "','" + RowDocument["SSC_Makrsobt"].ToString() + "','" + RowDocument["SSC_prcnt"].ToString() + "','" + RowDocument["HSSC_Year"].ToString() + "','" + RowDocument["HSSC_A_S"].ToString() + "','" + RowDocument["HSSC_Board"].ToString() + "','" + RowDocument["HSSC_Subjects"].ToString() + "','" + RowDocument["HSSC_Total_marks"].ToString() + "','" + RowDocument["HSSC_Marks_obt"].ToString() + "','" + RowDocument["HSSC_Prcnt"].ToString() + "')";
                        //SYS.Insert_Query(query);
                    }
                    STUDENT_ID = STUDENT_ID + 1;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = string.Empty;
            bool a = false;
            rs = SYS.Show_Query("SELECT *  FROM ['Classwise fee$']");
            if (rs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {

                    query = "INSERT INTO STUDENT (c_id,s_id,ADMISSION_NO,s_name,f_name,roll_no,m_fee,SECTION_ID,SessionID,SHIFT,TYPE,ACTIVE) VALUES(" + RowDocument["c_id"].ToString() + "," + RowDocument["s_id"].ToString() + ",'" + RowDocument["ADMISSION_NO"].ToString() + "','" + RowDocument["s_name"].ToString() + "','" + RowDocument["f_name"].ToString() + "','" + RowDocument["roll_no"].ToString() + "'," + RowDocument["m_fee"].ToString() + ",'" + RowDocument["SECTION_ID"] + "','" + RowDocument["SessionID"].ToString() + "','" + RowDocument["SHIFT"].ToString() + "','" + RowDocument["TYPE"].ToString() + "','true')";

                    a = SYS.Insert_Query(query);


                }

            }
        }
    }
}
