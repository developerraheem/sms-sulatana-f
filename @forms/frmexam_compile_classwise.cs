using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class frmexam_compile_classwise : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        List<string> myListofQueries = new List<string>();


        public frmexam_compile_classwise()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void frmexam_compile_Load(object sender, EventArgs e)
        {
            Load_Dropdowns();


        }
        public void load_students()
        {
            try
            {
                SYS.comboFill(this.cmbstudents, "SELECT [s_id],[s_name] FROM student where active='true' and SessionID='" + cmbselection.SelectedValue.ToString() + "' AND SECTION_ID='" + cmbsection.SelectedValue.ToString() + "' and c_id='" + cmbclass.SelectedValue + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' order by s_name", "student", "s_name", "s_id");
            }
            catch (Exception x)
            {

            }

        }

        public void load_subjects()
        {
            try
            {
                SYS.comboFill(this.cmb_subjects, "SELECT ID,sub_name FROM  subject WHERE c_id='" + cmbclass.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "'", "subject", "sub_name", "ID");
            }
            catch (Exception x)
            {

            }

        }

        public void Load_Dropdowns()
        {


            cmbselection.SelectedValue = SYSTEMSETTING.sessionid.ToString();

            try
            {
                //
                this.SYS.comboFill(this.cmbselection, "select * from [Sessions] where branch_id='" + SYSTEMSETTING.branch_ID + "' order by SessionID desc", "Sessions", "SessionName", "SessionID");
                SYS.comboFill(this.cmbclass, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
                SYS.comboFill(this.cmbsection, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
                SYS.comboFill(this.cmbexamtype, "select * from exam where branch_id='" + SYSTEMSETTING.branch_ID + "' order by e_id", "exam", "e_name", "e_id");
                load_students();
            }
            catch (Exception ex)
            {

            }

        }
        private void cmbclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_students();
            load_subjects();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string QUERY = string.Empty;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string totalmarks = "";
            //QUERY = "SELECT * FROM  subject WHERE c_id='" + cmbclass.SelectedValue + "' ORDER BY ID";

            QUERY = "SELECT sub_marks FROM  subject WHERE c_id='" + cmbclass.SelectedValue + "' ORDER BY ID";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow RowMarks in rs.Tables[0].Rows)
            {
                totalmarks = RowMarks[0].ToString();
            }

            QUERY = "SELECT s_id, s_name,ADMISSION_NO FROM student WHERE active=1 AND C_ID='" + cmbclass.SelectedValue + "' AND SECTION_ID='" + cmbsection.SelectedValue + "' AND SessionID='" + cmbselection.SelectedValue.ToString() + "' ORDER BY s_id ";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow RowDocument in rs.Tables[0].Rows)
            {

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                //Student ID
                row.Cells[0].Value = RowDocument["s_id"];
                // Student name
                row.Cells[1].Value = RowDocument["s_name"];
                // Reg No
                row.Cells[2].Value = RowDocument["ADMISSION_NO"];
                // Marks
                row.Cells[3].Value = totalmarks;

                //row.Cells[0].Value = RowDocument["s_id"];
                //row.Cells[1].Value = RowDocument["s_name"];

                row.Cells[4].Value = "";
                row.Cells[5].Value = "";
                row.Cells[6].Value = "";
                dataGridView1.Rows.Add(row);
                btnSave.Enabled = true;
            }
            Fill();
        }

        public void Fill()
        {
            string ID = "";
            string STUDENT_ID = "";
            try
            {
                DataSet rs = new DataSet();
                string QUERY = "select * from RESULTS where CLASS_ID='" + cmbclass.SelectedValue + "' AND EXAM_ID='" + cmbexamtype.SelectedValue.ToString() + "' AND SUBJECT_ID='" + cmb_subjects.SelectedValue.ToString() + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY S_ID";
                rs = SYS.Show_Query(QUERY);
                foreach (DataRow Row in rs.Tables[0].Rows)
                {
                    STUDENT_ID = Row["S_ID"].ToString();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        ID = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                        if (ID == STUDENT_ID)
                        {

                            dataGridView1.Rows[i].Cells["OBT_MARKS"].Value = Row["OBT_MARKS"].ToString();
                            dataGridView1.Rows[i].Cells["Remarks"].Value = Row["REMARKS"].ToString();
                            dataGridView1.Rows[i].Cells["STATUS"].Value = Row["STATUS"].ToString();
                        }
                    }
                }
            }
            catch (Exception EX)
            {

                SYS.setCreateError(EX.Message);
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet rs = new DataSet();
            string QUERY = "select * from RESULTS where CLASS_ID='" + cmbclass.SelectedValue + "' AND EXAM_ID='" + cmbexamtype.SelectedValue.ToString() + "' AND SUBJECT_ID='" + cmb_subjects.SelectedValue.ToString() + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY S_ID";
            rs = SYS.Show_Query(QUERY);
            if (rs.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                submit();
            }



        }
        public void submit()
        {
            string QUERY = "";
            if (MessageBox.Show("Are you sure ?", "Progress Report", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string CLASS_ID = cmbclass.SelectedValue.ToString();
                string CLASS_NAME = cmbclass.Text;
                string EXAM_ID = cmbexamtype.SelectedValue.ToString();
                string EXAM_NAME = cmbexamtype.Text.ToString();
                string S_ID = cmbstudents.SelectedValue.ToString();
                string SUBJECT_ID = cmb_subjects.SelectedValue.ToString();
                string SUBJECT_CODE = string.Empty;
                string SUBJECT_NAME = cmb_subjects.Text;
                string TOTAL_MARKS = string.Empty;
                string OBT_MARKS = string.Empty;
                string STATUS = string.Empty;
                string REMARKS = string.Empty;


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    S_ID = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                    TOTAL_MARKS = dataGridView1.Rows[i].Cells["TOTAL_MARKS"].Value.ToString();
                    OBT_MARKS = dataGridView1.Rows[i].Cells["OBT_MARKS"].Value.ToString();
                    STATUS = dataGridView1.Rows[i].Cells["STATUS"].Value.ToString();

                    if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["Remarks"].Value.ToString()))
                    {
                        REMARKS = dataGridView1.Rows[i].Cells["Remarks"].Value.ToString();
                    }



                    QUERY = "INSERT INTO RESULTS([CLASS_ID],[CLASS_NAME],[EXAM_ID],[EXAM_NAME],[S_ID],[SUBJECT_ID],[SUBJECT_CODE],[SUBJECT_NAME],[TOTAL_MARKS],[OBT_MARKS],[STATUS],[REMARKS],[BRANCH_ID])";
                    QUERY = QUERY + " VALUES ('" + CLASS_ID + "','" + CLASS_NAME + "','" + EXAM_ID + "','" + EXAM_NAME + "','" + S_ID + "','" + SUBJECT_ID + "','" + SUBJECT_CODE + "','" + SUBJECT_NAME + "','" + TOTAL_MARKS + "','" + OBT_MARKS + "','" + STATUS + "','" + REMARKS + "','" + SYSTEMSETTING.branch_ID + "')";
                    myListofQueries.Add(QUERY);

                }

                bool CHECK = false;
                string[] bulkqueries1 = myListofQueries.ToArray();
                CHECK = SYS.Insert_Query_manualcommit(bulkqueries1);
                if (CHECK == true)
                {
                    SYS.setMessageBox("Record Saved succesfully", 1);
                    myListofQueries.Clear();
                    bulkqueries1 = null;
                }

                else
                {
                    SYS.setCreateError("Record not saved! Please try later!");
                    myListofQueries.Clear();
                    bulkqueries1 = null;
                }

            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            SF_REPORTS.RPT_RESULTS RPT = new SF_REPORTS.RPT_RESULTS();
            RPT.STUDENTID = cmbstudents.SelectedValue.ToString();
            RPT.EXAMID = cmbexamtype.SelectedValue.ToString();
            RPT.CLASSID = cmbclass.SelectedValue.ToString();

            RPT.Show();
        }

        private void cmbsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_students();
            //load_subjects();
        }

        private void cmbselection_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_students();
        }

        private void txtadmno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SYS.comboFill(this.cmbstudents, "SELECT [s_id],[s_name] FROM student where active='true' AND ADMISSION_NO LIKE '%" + txtadmno.Text + "%' and branch_id='" + SYSTEMSETTING.branch_ID + "' order by s_name", "student", "s_name", "s_id");
            }
            catch (Exception x)
            {

            }
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            SF_REPORTS.RPT_RESULTS_MULTIPLE RPT = new SF_REPORTS.RPT_RESULTS_MULTIPLE();
            RPT.STUDENTID = cmbstudents.SelectedValue.ToString();
            RPT.EXAMID = cmbexamtype.SelectedValue.ToString();
            RPT.CLASSID = cmbclass.SelectedValue.ToString();

            RPT.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Delete Result Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                bool CHK = false;
                CHK = SYS.Insert_Query("Delete from RESULTS where CLASS_ID='" + cmbclass.SelectedValue.ToString() + "' AND EXAM_ID='" + cmbexamtype.SelectedValue.ToString() + "' AND SUBJECT_ID='" + cmb_subjects.SelectedValue.ToString() + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                if (CHK == true)
                {
                    SYS.setMessageBox("Deleted!", 3);
                }
                else
                {
                    SYS.setCreateError("Not Deleted!");
                }

            }
        }
    }
}
