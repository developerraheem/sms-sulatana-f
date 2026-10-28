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
    public partial class frm_student_promotions : Form
    {
        public frm_student_promotions()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        List<string> myListofQueries = new List<string>();

        private void frm_student_promotions_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student_DataSet.student_promotions' table. You can move, or remove it, as needed.
            this.student_promotionsTableAdapter.Fill(this.student_DataSet.student_promotions);
            SYS.comboFill(this.cmbclassfrom, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbsection, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
            SYS.comboFill(this.cmbsessionfrom, "select SessionID,SessionName from Sessions where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sessions", "SessionName", "SessionID");

            SYS.comboFill(this.comboBox1, "SELECT [PROMO_TYPE_ID],[PROMO_TYPE_NAME] FROM [PROMO_TYPE]", "PROMO_TYPE", "PROMO_TYPE_NAME", "PROMO_TYPE_ID");


            SYS.comboFill(this.cmbclassto, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshiftto, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbsectionto, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
            SYS.comboFill(this.cmbsessionto, "select SessionID,SessionName from Sessions where branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY SessionID DESC", "Sessions", "SessionName", "SessionID");



        }

      
        private void btntransfer_Click(object sender, EventArgs e)
        {
            //if (cmbsessionfrom.SelectedValue.ToString() != cmbsessionto.SelectedValue.ToString())
            //{
            //    SYS.setCreateError("Transfer from Session and Transfer to Session cant be same");
            //}
            //else
            //{
            if (cmbclassfrom.SelectedValue.ToString() == "0980898798")
            {

                // for class 5th (last lass) students transfered to new session whose status is failed
                //if (cmbclassfrom.SelectedValue.ToString() == "777790")
                //{
                //if (MessageBox.Show("You are going to Transfer students from " + cmbclassfrom.Text.ToString() + "   To   " + cmbclassto.Text.ToString() + "", "Confirm Transfer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                //    #region
                //    string query = "";
                //    string classid;
                //    string shift = "";
                //    string section = "";
                //    string sessionid = cmbsessionto.SelectedValue.ToString();
                //    Int64 studentid = student_s_id();
                //    int rollno = 1;
                //    int sno = 1;

                //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //    {
                //        if (Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmtype"].Value) == 1)
                //        {

                //            classid = cmbclassfrom.SelectedValue.ToString();
                //            shift = cmbshift.SelectedValue.ToString();
                //            section = cmbsection.SelectedValue.ToString();

                //            query = "INSERT INTO [student]([c_id],[s_id],[s_name],[f_name],[age],[d_birth],[sex],[remarks],[contact_no],[active],[roll_no],[address],[m_fee],[RELETIVE_EXIST_FLAG]";
                //            query = query + " ,[CONCESSION_FEE],[RELATION],[CONCESSION_REASON],[PRV_SCHOOL_NAME],[PRV_SCHOOL_CLASS],[LEAVING_CERTIFICATE_REMARKS],[LEAVING_STATUS],[SCHOOL_ADDRESS]";
                //            query = query + " ,[SECTION_ID],[ADMISSION_NO],[SessionID],[SecurityFee],[SHIFT],[TYPE],[RELEGION],[TEL_OFFICE],[TEL_RESI],[G_NAME],[G_RELATION],[G_MONTHLYINCOME]";
                //            query = query + " ,[G_CNIC],[G_MOBILE],[G_PHONE],[G_ADDRESS],[P_EMPNAME],[P_SECTION],[P_PLNO],[P_DESIGNATION],[P_DEPARTMENT],[P_AUTHNAME],[P_SECTION1],[P_PLNO1],[P_DESIGNATION1]";
                //            query = query + " ,[P_DEPARTMENT1],[ADMISSION_DATE],[CNIC_MOTHER],[CNIC_FATHER],[FATHER_OCCUPATION],[PRV_CLASS],[branch_id],[buscharges])";
                //            query = query + " (select '" + classid + "','" + studentid + "',[s_name],[f_name],[age],[d_birth],[sex],[remarks],[contact_no],[active],'" + sno + "',[address],[m_fee],[RELETIVE_EXIST_FLAG]";
                //            query = query + " ,[CONCESSION_FEE],[RELATION],[CONCESSION_REASON],[PRV_SCHOOL_NAME],[PRV_SCHOOL_CLASS],[LEAVING_CERTIFICATE_REMARKS],[LEAVING_STATUS],[SCHOOL_ADDRESS]";
                //            query = query + " ,'" + section + "',[ADMISSION_NO],'" + sessionid + "',[SecurityFee],'" + shift + "',[TYPE],[RELEGION],[TEL_OFFICE],[TEL_RESI],[G_NAME],[G_RELATION],[G_MONTHLYINCOME]";
                //            query = query + " ,[G_CNIC],[G_MOBILE],[G_PHONE],[G_ADDRESS],[P_EMPNAME],[P_SECTION],[P_PLNO],[P_DESIGNATION],[P_DEPARTMENT],[P_AUTHNAME],[P_SECTION1],[P_PLNO1],[P_DESIGNATION1]";
                //            query = query + " ,[P_DEPARTMENT1],[ADMISSION_DATE],[CNIC_MOTHER],[CNIC_FATHER],[FATHER_OCCUPATION],'" + cmbclassfrom.SelectedValue + "',[branch_id],[buscharges]";
                //            query = query + " from student where s_id='" + dataGridView1.Rows[i].Cells["ID"].Value + "' and ADMISSION_NO='" + dataGridView1.Rows[i].Cells["ADMISSION_NO"].Value + "')";

                //            sno = sno + 1;
                //            studentid = studentid + 1;
                //            myListofQueries.Add(query);

                //        }
                //        else
                //        {

                //        }
                //        if (Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmtype"].Value) == 1 || Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmtype"].Value) == 2 || Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmtype"].Value) == 3)
                //        {
                //            classid = cmbclassfrom.SelectedValue.ToString();
                //            shift = cmbshift.SelectedValue.ToString();
                //            section = cmbsection.SelectedValue.ToString();

                //            query = "Update student set active='false',PROMO_TYPE_ID='" + dataGridView1.Rows[i].Cells["clmtype"].Value + "' where s_id='" + dataGridView1.Rows[i].Cells["ID"].Value + "'";
                //            myListofQueries.Add(query);
                //        }

                //    }

                //    bool CHECK = false;
                //    string[] bulkqueries1 = myListofQueries.ToArray();
                //    CHECK = SYS.Insert_Query_manualcommit(bulkqueries1);

                //    if (CHECK == true)
                //    {
                //        SYS.setMessageBox("Student transffered succesfully", 1);
                //        myListofQueries.Clear();
                //        bulkqueries1 = null;
                //    }

                //    else
                //    {
                //        SYS.setCreateError("Student not transferred Please try later!");
                //        myListofQueries.Clear();
                //        bulkqueries1 = null;
                //    }

                //    #endregion
                //}
                //}
                //else
                //{
                //    SYS.setCreateError("Transfer from Class and Transfer to Class cant be same");
                //}


            }
            else
            {
                if (MessageBox.Show("You are going to Transfer students from " + cmbclassfrom.Text.ToString() + "   To   " + cmbclassto.Text.ToString() + "", "Confirm Transfer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    #region
                    string query = "";
                    string classid;
                    string shift = "";
                    string section = "";
                    string sessionid = cmbsessionto.SelectedValue.ToString();
                    Int64 studentid = student_s_id();
                    int rollno = 1;
                    int sno = 1;

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //Left and Graduated
                        if (Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmtype"].Value) == 3 || Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmtype"].Value) == 2)
                        {

                            shift = cmbshift.SelectedValue.ToString();
                            section = cmbsection.SelectedValue.ToString();

                            query = "Update student set active='false',PROMO_TYPE_ID='" + dataGridView1.Rows[i].Cells["clmtype"].Value + "' where s_id='" + dataGridView1.Rows[i].Cells["ID"].Value + "'";
                            myListofQueries.Add(query);

                        }
                        //Pass or Promoted
                        else if (Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmtype"].Value) == 1)
                        {
                            classid = cmbclassto.SelectedValue.ToString();
                            shift = cmbshiftto.SelectedValue.ToString();
                            section = cmbsectionto.SelectedValue.ToString();
                            section = dataGridView1.Rows[i].Cells["section"].Value.ToString();

                            query = "INSERT INTO [student]([c_id],[s_id],[s_name],[f_name],[age],[d_birth],[sex],[remarks],[contact_no],[active],[roll_no],[address],[m_fee],[RELETIVE_EXIST_FLAG]";
                            query = query + " ,[CONCESSION_FEE],[RELATION],[CONCESSION_REASON],[PRV_SCHOOL_NAME],[PRV_SCHOOL_CLASS],[LEAVING_CERTIFICATE_REMARKS],[LEAVING_STATUS],[SCHOOL_ADDRESS]";
                            query = query + " ,[SECTION_ID],[ADMISSION_NO],[SessionID],[SecurityFee],[SHIFT],[TYPE],[RELEGION],[TEL_OFFICE],[TEL_RESI],[G_NAME],[G_RELATION],[G_MONTHLYINCOME]";
                            query = query + " ,[G_CNIC],[G_MOBILE],[G_PHONE],[G_ADDRESS],[P_EMPNAME],[P_SECTION],[P_PLNO],[P_DESIGNATION],[P_DEPARTMENT],[P_AUTHNAME],[P_SECTION1],[P_PLNO1],[P_DESIGNATION1]";
                            query = query + " ,[P_DEPARTMENT1],[ADMISSION_DATE],[CNIC_MOTHER],[CNIC_FATHER],[FATHER_OCCUPATION],[PRV_CLASS],[branch_id],[buscharges],[STUDENT_ID],[image],[Isconfirm],[DISCOUNT_ID])";
                            query = query + " (select '" + classid + "','" + studentid + "',[s_name],[f_name],[age],[d_birth],[sex],[remarks],[contact_no],[active],'" + rollno + "',[address],[m_fee],[RELETIVE_EXIST_FLAG]";
                            query = query + " ,[CONCESSION_FEE],[RELATION],[CONCESSION_REASON],[PRV_SCHOOL_NAME],[PRV_SCHOOL_CLASS],[LEAVING_CERTIFICATE_REMARKS],[LEAVING_STATUS],[SCHOOL_ADDRESS]";
                            query = query + " ,'" + section + "',[ADMISSION_NO],'" + sessionid + "',[SecurityFee],'" + shift + "',[TYPE],[RELEGION],[TEL_OFFICE],[TEL_RESI],[G_NAME],[G_RELATION],[G_MONTHLYINCOME]";
                            query = query + " ,[G_CNIC],[G_MOBILE],[G_PHONE],[G_ADDRESS],[P_EMPNAME],[P_SECTION],[P_PLNO],[P_DESIGNATION],[P_DEPARTMENT],[P_AUTHNAME],[P_SECTION1],[P_PLNO1],[P_DESIGNATION1]";
                            query = query + " ,[P_DEPARTMENT1],[ADMISSION_DATE],[CNIC_MOTHER],[CNIC_FATHER],[FATHER_OCCUPATION],'" + cmbclassfrom.SelectedValue + "',[branch_id],[buscharges],[STUDENT_ID],[image],[Isconfirm],[DISCOUNT_ID]";
                            query = query + " from student where s_id='" + dataGridView1.Rows[i].Cells["ID"].Value + "' and ADMISSION_NO='" + dataGridView1.Rows[i].Cells["ADMISSION_NO"].Value + "')";

                            myListofQueries.Add(query);
                            query = "Update student set active='false',PROMO_TYPE_ID='" + dataGridView1.Rows[i].Cells["clmtype"].Value + "' where s_id='" + dataGridView1.Rows[i].Cells["ID"].Value + "'";

                            rollno = rollno + 1;
                            myListofQueries.Add(query);

                        }

                        //Fail Shifted to next session with same class
                        else if (Convert.ToDecimal(dataGridView1.Rows[i].Cells["clmtype"].Value) == 4)
                        {
                            classid = cmbclassfrom.SelectedValue.ToString();
                            section = dataGridView1.Rows[i].Cells["section"].Value.ToString();
                            shift = cmbshift.SelectedValue.ToString();
                            sessionid = cmbsessionto.SelectedValue.ToString();

                            query = "INSERT INTO [student]([c_id],[s_id],[s_name],[f_name],[age],[d_birth],[sex],[remarks],[contact_no],[active],[roll_no],[address],[m_fee],[RELETIVE_EXIST_FLAG]";
                            query = query + " ,[CONCESSION_FEE],[RELATION],[CONCESSION_REASON],[PRV_SCHOOL_NAME],[PRV_SCHOOL_CLASS],[LEAVING_CERTIFICATE_REMARKS],[LEAVING_STATUS],[SCHOOL_ADDRESS]";
                            query = query + " ,[SECTION_ID],[ADMISSION_NO],[SessionID],[SecurityFee],[SHIFT],[TYPE],[RELEGION],[TEL_OFFICE],[TEL_RESI],[G_NAME],[G_RELATION],[G_MONTHLYINCOME]";
                            query = query + " ,[G_CNIC],[G_MOBILE],[G_PHONE],[G_ADDRESS],[P_EMPNAME],[P_SECTION],[P_PLNO],[P_DESIGNATION],[P_DEPARTMENT],[P_AUTHNAME],[P_SECTION1],[P_PLNO1],[P_DESIGNATION1]";
                            query = query + " ,[P_DEPARTMENT1],[ADMISSION_DATE],[CNIC_MOTHER],[CNIC_FATHER],[FATHER_OCCUPATION],[PRV_CLASS],[branch_id],[buscharges],[STUDENT_ID])";
                            query = query + " (select '" + classid + "','" + studentid + "',[s_name],[f_name],[age],[d_birth],[sex],[remarks],[contact_no],[active],'" + rollno + "',[address],[m_fee],[RELETIVE_EXIST_FLAG]";
                            query = query + " ,[CONCESSION_FEE],[RELATION],[CONCESSION_REASON],[PRV_SCHOOL_NAME],[PRV_SCHOOL_CLASS],[LEAVING_CERTIFICATE_REMARKS],[LEAVING_STATUS],[SCHOOL_ADDRESS]";
                            query = query + " ,'" + section + "',[ADMISSION_NO],'" + sessionid + "',[SecurityFee],'" + shift + "',[TYPE],[RELEGION],[TEL_OFFICE],[TEL_RESI],[G_NAME],[G_RELATION],[G_MONTHLYINCOME]";
                            query = query + " ,[G_CNIC],[G_MOBILE],[G_PHONE],[G_ADDRESS],[P_EMPNAME],[P_SECTION],[P_PLNO],[P_DESIGNATION],[P_DEPARTMENT],[P_AUTHNAME],[P_SECTION1],[P_PLNO1],[P_DESIGNATION1]";
                            query = query + " ,[P_DEPARTMENT1],[ADMISSION_DATE],[CNIC_MOTHER],[CNIC_FATHER],[FATHER_OCCUPATION],'" + cmbclassfrom.SelectedValue + "',[branch_id],[buscharges],[STUDENT_ID]";
                            query = query + " from student where s_id='" + dataGridView1.Rows[i].Cells["ID"].Value + "' and ADMISSION_NO='" + dataGridView1.Rows[i].Cells["ADMISSION_NO"].Value + "')";

                            myListofQueries.Add(query);
                            query = "Update student set active='false',PROMO_TYPE_ID='" + dataGridView1.Rows[i].Cells["clmtype"].Value + "' where s_id='" + dataGridView1.Rows[i].Cells["ID"].Value + "'";

                            rollno = rollno + 1;
                            myListofQueries.Add(query);
                        }

                        studentid = studentid + 1;

                    }

                    bool CHECK = false;
                    string[] bulkqueries1 = myListofQueries.ToArray();
                    CHECK = SYS.Insert_Query_manualcommit(bulkqueries1);

                    if (CHECK == true)
                    {
                        SYS.setMessageBox("Student transffered succesfully", 1);
                    }

                    else
                    {
                        SYS.setCreateError("Student not transferred Please try later!");
                    }

                    #endregion

                }
            }

            //}
        }

        private Int64 student_s_id()
        {
            Int64 myID = 0;
            try
            {


                SqlConnection con = SYS.db_connect();
                con.Open();
                SqlCommand cmddr = new SqlCommand("select max(convert(int,s_id)) as ids from student", con);
                SqlDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string str_sid = dr["ids"].ToString();
                    if (str_sid == "")
                    {
                        myID = 1;
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                    }

                }

                dr.Close();
                con.Close();
                cmddr.Dispose();


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            return myID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int64 studentid = 0;
            rs = SYS.Show_Query("select s_id from student where SessionID=3 and s_id<1332");
            foreach (DataRow RowDocument in rs.Tables[0].Rows)
            {
                studentid = student_s_id();
                SYS.Insert_Query("UPDATE STUDENT SET s_id =" + studentid + " where s_id ='" + RowDocument["s_id"].ToString() + "' and SessionID='3'");
            }

        }

        //    public virtual int Fill(Dashboard.SectionsDataTable dataTable, int BRANCH_ID);

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            //try
            //{
            //    if (dataGridView1.CurrentCell.OwningColumn.Name == "section" && e.Control is ComboBox)
            //    {
            //        ComboBox comboBox = (ComboBox)e.Control;

            //        string branchId = SYSTEMSETTING.branch_ID;
            //        MessageBox.Show("BranchId = " + branchId); // Debug

            //        // Try with correct type
            //        this.bind_sectionsTableAdapter.Fill(this.dashboard.bind_sections, Convert.ToDecimal(branchId));

            //        comboBox.DataSource = this.dashboard.bind_sections;
            //        comboBox.DisplayMember = "SECTION_NAME";
            //        comboBox.ValueMember = "SECTION_ID";
            //    }
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}


        }

       

        private void btnfinditems_advance_Click(object sender, EventArgs e)
        {
            string QUERY = string.Empty;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            try
            {
                int branchId = Convert.ToInt32(SYSTEMSETTING.branch_ID);
                this.bind_sectionsTableAdapter.Fill(this.dashboard.bind_sections, Convert.ToDecimal(branchId));
                // Get your combo column (the one you added in designer or code)
                DataGridViewComboBoxColumn comboCol = (DataGridViewComboBoxColumn)dataGridView1.Columns["section"];
                comboCol.DataSource = this.dashboard.bind_sections;
                comboCol.DisplayMember = "SECTION_NAME";
                comboCol.ValueMember = "SECTION_ID";
            }
            catch (Exception ex)
            {

            }

            QUERY = "SELECT s_id, s_name, roll_no, ADMISSION_NO, f_name,SECTION_ID FROM  student WHERE  (c_id = '" + cmbclassfrom.SelectedValue + "') AND (SECTION_ID = '" + cmbsection.SelectedValue + "') AND (SessionID = '" + cmbsessionfrom.SelectedValue + "') AND (SHIFT = '" + cmbshift.SelectedValue + "') AND ACTIVE='true' and branch_id='" + SYSTEMSETTING.branch_ID + "' order by s_id";
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
                // row.Cells[6].Value = RowDocument["SECTION_ID"];
                row.Cells[6].Value = cmbsectionto.SelectedValue.ToString();
                dataGridView1.Rows.Add(row);
            }



            //try
            //{
            //    if (dataGridView1.CurrentCell.OwningColumn.Name == "section" && e.Control is ComboBox)
            //    {
            //        ComboBox comboBox = (ComboBox)e.Control;

            //        string branchId = SYSTEMSETTING.branch_ID;
            //        MessageBox.Show("BranchId = " + branchId); // Debug

            //        // Try with correct type
            //        this.bind_sectionsTableAdapter.Fill(this.dashboard.bind_sections, Convert.ToDecimal(branchId));

            //        comboBox.DataSource = this.dashboard.bind_sections;
            //        comboBox.DisplayMember = "SECTION_NAME";
            //        comboBox.ValueMember = "SECTION_ID";
            //    }
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            
        }
    }
}
