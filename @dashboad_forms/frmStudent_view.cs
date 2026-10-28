using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;


namespace School._dashboad_forms
{
    public partial class frmStudent_view : Form
    {
        public frmStudent_view()
        {
            InitializeComponent();
        }
        private string picPath = "";
        private string picName = "";
        public string sSY;
        string imageName;
        public string str, strEdit, str_sid;
        public string studentid = "";

        _class.clsODBC cls_Con = new School._class.clsODBC();
        OleDbCommand cmdForm = new OleDbCommand();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        SYSTEMSETTING SYS = new SYSTEMSETTING();

        private void frmStudent_Load(object sender, EventArgs e)
        {
            this.panel3.Visible = false;// hide the search panel 
            // =============== Load Tools ==================

            this.com_Sex.Items.Add("Male");
            this.com_Sex.Items.Add("Female");
            this.com_Sex.SelectedIndex = 0;
            //this.cmbsection.SelectedIndex = 0;
            this.dp_Student.Value = DateTime.Now;
            comboClass_Load();


            if (str == "Adding")
            {
                this.lbl_Mode.Text = str;
                btnUpdate.Enabled = false;
                btnDel.Enabled = false;

            }
            else
            {
                if (str == "Modifying")
                {
                    this.lbl_Mode.Text = str;
                    btnSave.Enabled = false;

                    // list_Load();

                    GetStudentData(studentid);
                }
            }
            // =========================================




        }


        private void list_Load()
        {
            //  SYS.Filllist_DataView("select s_id,ADMISSION_NO,s_name,c_name,address,contact_no,f_name,age,d_birth,sex,remarks from view_student ORDER BY ADMISSION_NO", this.lstv_Student);
        }
        private void tab_Index()
        {
            this.btn_Link.TabIndex = 0;
            this.com_cName.TabIndex = 1;
            this.txtadmissionno.TabIndex = 2;
            this.txt_Sname.TabIndex = 3;
            this.txt_Fname.TabIndex = 4;
            this.txtAge.TabIndex = 5;
            this.dp_Student.TabIndex = 6;
            this.com_Sex.TabIndex = 7;
            this.txtAddress.TabIndex = 8;
            this.txtContact.TabIndex = 9;
            this.txtcontact_office.TabIndex = 10;
            this.txtcontact_resi.TabIndex = 11;
            this.txtreligion.TabIndex = 12;
            this.txtRemarks.TabIndex = 13;
            this.txt_Mfee.TabIndex = 14;
            this.chk_Active.TabIndex = 15;
        }

        private void btn_Link_Click(object sender, EventArgs e)
        {
            //frmClass frm_Class = new frmClass();
            //frm_Class.Show();
        }

        private void comboClass_Load()
        {
            try
            {
                this.SYS.comboFill(this.com_cName, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY c_id", "class", "c_name", "c_id");
                this.SYS.comboFill(this.cmbsession, "select * from [Sessions] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sessions", "SessionName", "SessionID");
                cmbsession.SelectedValue = SYSTEMSETTING.sessionid.ToString();
                cmbsession.Enabled = false;
                this.SYS.comboFill(this.cmbsection, "select * from [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_ID");
                this.SYS.comboFill(this.cmbshift, "select * from [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
                this.SYS.comboFill(this.cmbtype, "select typecode from student_type where branch_id='" + SYSTEMSETTING.branch_ID + "'", "student_type", "typecode", "typecode");
                this.SYS.comboFill(this.cmbdiscount, "select DISCOUNT_ID,DISCOUNT_DESC from DISCOUNTS where branch_id='" + SYSTEMSETTING.branch_ID + "'", "DISCOUNTS", "DISCOUNT_DESC", "DISCOUNT_ID");
            }
            catch (Exception)
            {


            }


        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            comboClass_Load();
            list_Load();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            save_Student();
        }
        private void save_Student()
        {
            if (this.com_cName.SelectedIndex == -1 || this.txtadmissionno.Text == "" || this.txt_Sname.Text == "")
            {


                MessageBox.Show("Class, Admission No and Student Name must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool val, relativeexist;
                bool discount = false;
                bool busservice = false;
                string query = string.Empty;
                string discount_id = cmbdiscount.SelectedValue.ToString();

                val = this.chk_Active.Checked;
                relativeexist = this.isrelativeexist.Checked;
                busservice = this.chk_buscharges.Checked;

                if (isrelativeexist.Checked == true)
                {
                    discount = true;
                    discount_id = cmbdiscount.SelectedValue.ToString();
                }
                else
                {
                    discount = false;
                    discount_id = "";
                }



                student_s_id();


                SqlConnection con = SYS.db_connect();
                con.Open();
                SqlTransaction tran;
                SqlCommand cmd = new SqlCommand();
                tran = con.BeginTransaction();
                cmd.Connection = con;
                cmd.Transaction = tran;

                Guid guid = Guid.NewGuid();
                string strGUID = guid.ToString();

                try
                {
                    cmd.CommandText = "insert into student(c_id,roll_no,s_id,s_name,f_name,age,d_birth,sex,remarks,contact_no,address,active,m_fee,CONCESSION_FEE,RELATION,CONCESSION_REASON,ADMISSION_NO,SessionID,SECTION_ID,SecurityFee,SHIFT,TYPE,RELEGION,TEL_OFFICE,TEL_RESI,G_NAME,G_RELATION,G_MONTHLYINCOME,G_CNIC,G_MOBILE,G_PHONE,G_ADDRESS,P_EMPNAME,P_SECTION,P_PLNO,P_DESIGNATION,P_DEPARTMENT,P_AUTHNAME,P_SECTION1,P_PLNO1,P_DESIGNATION1,P_DEPARTMENT1,ADMISSION_DATE,CNIC_MOTHER,CNIC_FATHER,FATHER_OCCUPATION,buscharges,FORMB,WHATSAPP,EMAIL,NATIONALITY,DOMICILE,MARITAL_STATUS,FATHER_DESIG,branch_id) values (@c_id,@roll_no,@s_id,@s_name,@f_name,@age,@d_birth,@sex,@remarks,@contact_no,@address,@active,@m_fee,@CONCESSION_FEE,@RELATION,@CONCESSION_REASON,@ADMISSION_NO,@SessionID,@SECTION_ID,@SecurityFee,@SHIFT,@TYPE,@RELEGION,@TEL_OFFICE,@TEL_RESI,@G_NAME,@G_RELATION,@G_MONTHLYINCOME,@G_CNIC,@G_MOBILE,@G_PHONE,@G_ADDRESS,@P_EMPNAME,@P_SECTION,@P_PLNO,@P_DESIGNATION,@P_DEPARTMENT,@P_AUTHNAME,@P_SECTION1,@P_PLNO1,@P_DESIGNATION1,@P_DEPARTMENT1,@ADMISSION_DATE,@CNIC_MOTHER,@CNIC_FATHER,@FATHER_OCCUPATION,@buscharges,@FORMB,@WHATSAPP,@EMAIL,@NATIONALITY,@DOMICILE,@MARITAL_STATUS,@FATHER_DESIG,@branch_id)";
                    cmd.Parameters.Add("@c_id", SqlDbType.Int).Value = this.com_cName.SelectedValue;
                    cmd.Parameters.Add("@roll_no", SqlDbType.Char).Value = this.txt_Rollno.Text.Trim();
                    cmd.Parameters.Add("@s_id", SqlDbType.Char).Value = this.txts_id.Text;
                    cmd.Parameters.Add("@s_name", SqlDbType.Char).Value = this.txt_Sname.Text;
                    cmd.Parameters.Add("@f_name", SqlDbType.Char).Value = this.txt_Fname.Text;
                    cmd.Parameters.Add("@age", SqlDbType.Char).Value = this.txtAge.Text.Trim();
                    cmd.Parameters.Add("@d_birth", SqlDbType.Date).Value = this.dp_Student.Value.Date;
                    cmd.Parameters.Add("@sex", SqlDbType.Char).Value = this.com_Sex.Text.Trim();
                    cmd.Parameters.Add("@remarks", SqlDbType.Char).Value = this.txtRemarks.Text;
                    cmd.Parameters.Add("@contact_no", SqlDbType.Char).Value = this.txtContact.Text;
                    cmd.Parameters.Add("@address", SqlDbType.Char).Value = this.txtAddress.Text;
                    cmd.Parameters.Add("@active", SqlDbType.Bit).Value = val;
                    cmd.Parameters.Add("@m_fee", SqlDbType.Int).Value = this.txt_Mfee.Text.Trim();

                    cmd.Parameters.Add("@CONCESSION_FEE", SqlDbType.Int).Value = this.txtcon_fee.Text.Trim();
                    cmd.Parameters.Add("@RELATION", SqlDbType.Char).Value = this.txtrelation.Text;
                    cmd.Parameters.Add("@CONCESSION_REASON", SqlDbType.Char).Value = this.txtcon_reason.Text;
                    cmd.Parameters.Add("@ADMISSION_NO", SqlDbType.Char).Value = this.txtadmissionno.Text;
                    cmd.Parameters.Add("@SessionID", SqlDbType.Char).Value = this.cmbsession.SelectedValue.ToString();
                    cmd.Parameters.Add("@SECTION_ID", SqlDbType.Char).Value = this.cmbsection.SelectedValue.ToString();
                    cmd.Parameters.Add("@SecurityFee", SqlDbType.Int).Value = this.txtsecurityfee.Text.Trim();

                    cmd.Parameters.Add("@SHIFT", SqlDbType.Char).Value = this.cmbshift.Text.ToString();
                    cmd.Parameters.Add("@TYPE", SqlDbType.Char).Value = this.cmbtype.Text.ToString();
                    cmd.Parameters.Add("@RELEGION", SqlDbType.Char).Value = this.txtreligion.Text;
                    cmd.Parameters.Add("@TEL_OFFICE", SqlDbType.Char).Value = this.txtcontact_office.Text;
                    cmd.Parameters.Add("@TEL_RESI", SqlDbType.Char).Value = this.txtcontact_resi.Text;


                    cmd.Parameters.Add("@G_NAME", SqlDbType.Char).Value = this.txtg_name.Text;
                    cmd.Parameters.Add("@G_RELATION", SqlDbType.Char).Value = this.txtg_relation.Text;
                    cmd.Parameters.Add("@G_MONTHLYINCOME", SqlDbType.Char).Value = this.txtg_income.Text;
                    cmd.Parameters.Add("@G_CNIC", SqlDbType.Char).Value = this.txtg_cnic.Text;
                    cmd.Parameters.Add("@G_MOBILE", SqlDbType.Char).Value = this.txtg_mobile.Text;
                    cmd.Parameters.Add("@G_PHONE", SqlDbType.Char).Value = this.txtg_phone.Text;
                    cmd.Parameters.Add("@G_ADDRESS", SqlDbType.Char).Value = this.txtg_address.Text;


                    cmd.Parameters.Add("@P_EMPNAME", SqlDbType.Char).Value = this.txtp_empname.Text;
                    cmd.Parameters.Add("@P_SECTION", SqlDbType.Char).Value = this.txtp_section.Text;
                    cmd.Parameters.Add("@P_PLNO", SqlDbType.Char).Value = this.txtp_plno.Text;
                    cmd.Parameters.Add("@P_DESIGNATION", SqlDbType.Char).Value = this.txtp_designation.Text;
                    cmd.Parameters.Add("@P_DEPARTMENT", SqlDbType.Char).Value = this.txtp_dept.Text;
                    cmd.Parameters.Add("@P_AUTHNAME", SqlDbType.Char).Value = this.txtp_authname.Text;
                    cmd.Parameters.Add("@P_SECTION1", SqlDbType.Char).Value = this.txtp_section1.Text;
                    cmd.Parameters.Add("@P_PLNO1", SqlDbType.Char).Value = this.txtp_plno1.Text;
                    cmd.Parameters.Add("@P_DESIGNATION1", SqlDbType.Char).Value = this.txtp_designation1.Text;
                    cmd.Parameters.Add("@P_DEPARTMENT1", SqlDbType.Char).Value = this.txtp_dept1.Text;

                    cmd.Parameters.Add("@ADMISSION_DATE", SqlDbType.Date).Value = this.txtadmissiondate.Value.Date;
                    cmd.Parameters.Add("@CNIC_MOTHER", SqlDbType.Char).Value = this.txtcnic_mother.Text;
                    cmd.Parameters.Add("@CNIC_FATHER", SqlDbType.Char).Value = this.txtcnic_father.Text;
                    cmd.Parameters.Add("@FATHER_OCCUPATION", SqlDbType.Char).Value = this.txtoccupation.Text;
                    cmd.Parameters.Add("@buscharges", SqlDbType.Bit).Value = busservice;
                    cmd.Parameters.Add("@FORMB", SqlDbType.Char).Value = txtbform.Text;

                    //,,,,,,
                    cmd.Parameters.Add("@WHATSAPP", SqlDbType.Char).Value = txtwhatsapp.Text;
                    cmd.Parameters.Add("@EMAIL", SqlDbType.Char).Value = txtemail.Text;
                    cmd.Parameters.Add("@NATIONALITY", SqlDbType.Char).Value = txtnationality.Text;
                    cmd.Parameters.Add("@DOMICILE", SqlDbType.Char).Value = txtdomicile.Text;
                    cmd.Parameters.Add("@MARITAL_STATUS", SqlDbType.Char).Value = cmbmarital.Text;
                    cmd.Parameters.Add("@FATHER_DESIG", SqlDbType.Char).Value = txtfather_desgin.Text;

                    cmd.Parameters.Add("@branch_id", SqlDbType.Char).Value = SYSTEMSETTING.branch_ID;
                    cmd.Parameters.Add("@STUDENT_ID", SqlDbType.Char).Value = strGUID;


                    cmd.ExecuteNonQuery();
                    //STUDENT CLASS HISTORY
                    cmd.CommandText = "insert into student_class_history(s_id,c_id,ADMISSION_NO,section_id,session_id,branch_id) values('" + txts_id.Text + "', '" + com_cName.SelectedValue.ToString() + "','" + txtadmissionno.Text + "','" + cmbsection.SelectedValue.ToString() + "','" + cmbsession.SelectedValue.ToString() + "','" + SYSTEMSETTING.branch_ID + "')";
                    cmd.ExecuteNonQuery();
                    // SET STUDENT OPENING BALANCE                     
                    //cmd.CommandText = "Insert into OpeningBalance(S_ID,Balance,C_ID,Fee_head_id) values('" + txts_id.Text + "','0', '" + com_cName.SelectedValue.ToString() + "','1')";
                    //cmd.ExecuteNonQuery();
                    //  cls_Con.cmdClose(cmdForm);

                    query = "insert into PREVIOUS_ACADEMICS(s_id,c_id,ADMISSION_NO,session_id,branch_id,[SSC_year],[SSC_A_S],[SSC_Board],[SSC_Subject],[SSC_Totalmarks],[SSC_Makrsobt],[SSC_prcnt],[HSSC_Year],[HSSC_A_S],[HSSC_Board],[HSSC_Subjects],[HSSC_Total_marks],[HSSC_Marks_obt],[HSSC_Prcnt],[GRAD_Year],[GRAD_A_S],[GRAD_Board],[GRAD_Subjects] ,[GRAD_Total_marks] ,[GRAD_Marks_obt] ,[GRAD_Prcnt])";
                    query = query + " values(" + txts_id.Text + "," + com_cName.SelectedValue.ToString() + ",'" + txtadmissionno.Text + "','" + SYSTEMSETTING.sessionid + "','" + SYSTEMSETTING.branch_ID + "','" + SSC_year.Text + "','" + SSC_A_S.Text + "','" + SSC_Board.Text + "','" + SSC_Subject.Text + "','" + SSC_Totalmarks.Text + "','" + SSC_Makrsobt.Text + "','" + SSC_prcnt.Text + "','" + HSSC_Year.Text + "','" + HSSC_A_S.Text + "','" + HSSC_Board.Text + "','" + HSSC_Subjects.Text + "','" + HSSC_Total_marks.Text + "','" + HSSC_Marks_obt.Text + "','" + HSSC_Prcnt.Text + "','" + GRAD_Year.Text + "','" + GRAD_A_S.Text + "','" + GRAD_Board.Text + "','" + GRAD_Subjects.Text + "','" + GRAD_Total_marks.Text + "','" + GRAD_Marks_obt.Text + "','" + GRAD_Prcnt.Text + "')";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    tran.Commit();
                    uploadpicture(txts_id.Text);

                    clsmyFunction.setMessageBox("Data Save Successfuly", 1);
                    this.lbl_Mode.Text = str;
                    btnUpdate.Enabled = false;
                    btnDel.Enabled = false;

                    clearText();
                    student_ID();



                }
                catch (Exception exp)
                {

                    try
                    {
                        tran.Rollback();
                        con.Close();
                    }
                    catch (Exception)
                    {

                    }
                    clsmyFunction.setCreateError(exp.Message);

                }
                finally
                {
                    //this.con.Close();
                }
            }
        }

        private void btn_Add_Click_1(object sender, EventArgs e)
        {
            save_Student();
            list_Load();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clearText();
            list_Load();
        }
        private void clearText()
        {

            //this.com_cName.SelectedIndex = -1;
            this.txt_Rollno.Text = "";
            this.txt_Sname.Text = "";
            this.txt_Fname.Text = "";
            this.txtAge.Text = "";
            this.dp_Student.Text = "";
            //this.com_Sex.SelectedIndex = -1;
            this.txtAddress.Text = "";
            this.txtContact.Text = "";
            this.txtRemarks.Text = "";
            this.txt_Mfee.Text = "0";
            //this.chk_Active.Checked = false;
            this.txtcontact_resi.Text = "";
            this.txtcontact_office.Text = "";
            this.txtreligion.Text = "Islam";

            this.txtcon_fee.Text = "0";
            this.txtrel_admission.Text = "";
            this.txtrelation.Text = "";
            this.txtcon_reason.Text = "";
            //this.txtschoolname.Text = "";
            //this.txtprevclass.Text = "";
            //this.txtleavingstatus.Text = "";
            //this.txtleaving_remarks.Text = "";
            //this.txtschooladress.Text = "";
            this.txtg_name.Text = "";
            this.txtg_relation.Text = "";
            this.txtg_income.Text = "0";
            this.txtg_cnic.Text = "";
            this.txtcon_fee.Text = "0";

            this.txtg_mobile.Text = "";
            this.txtg_phone.Text = "";
            this.txtg_address.Text = "";
            this.txtp_empname.Text = "";
            this.txtp_section.Text = "";
            this.txtp_plno.Text = "";
            this.txtp_designation.Text = "";
            this.txtp_dept.Text = "";
            this.txtp_authname.Text = "";

            this.txtp_section1.Text = "";
            this.txtp_plno1.Text = "";
            this.txtp_designation1.Text = "";
            this.txtp_dept1.Text = "";


            txtadmissionno.Text = string.Empty;
            txtbform.Text = string.Empty;
            txtcnic_mother.Text = string.Empty;
            txtcnic_father.Text = string.Empty;
            txtoccupation.Text = string.Empty;

            txtwhatsapp.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtreligion.Text = "Islam";
            txtdomicile.Text = string.Empty;
            txtcnic_mother.Text = string.Empty;
            txtnationality.Text = "Pakistani";
            txtfather_desgin.Text = string.Empty;

            pictureBox2.Image = null;

        }



        private void com_cName_Enter(object sender, EventArgs e)
        {
            if (str == "Modifying")
            {
                this.com_cName.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                return;
            }
        }

        private void com_cName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Disable typing on combo Box
            e.Handled = true;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = true;
            this.txt_Find.Focus();
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panel3.Visible = false;
        }


        private void student_ID()
        {
            if (this.com_cName.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                try
                {

                    int myID;
                    SqlConnection con = SYS.db_connect();
                    con.Open();
                    SqlCommand cmddr = new SqlCommand("select max((roll_no)) as ids from student where c_id='" + this.com_cName.SelectedValue + "' AND SessionID='" + cmbsession.SelectedValue + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' and SECTION_ID='" + cmbsection.SelectedValue.ToString() + "'", con);
                    SqlDataReader dr = cmddr.ExecuteReader();

                    while (dr.Read())
                    {
                        string strid = dr["ids"].ToString();
                        if (strid == "")
                        {
                            this.txt_Rollno.Text = "1";
                        }
                        else
                        {
                            myID = Convert.ToInt32(dr["ids"]) + 1;
                            this.txt_Rollno.Text = myID.ToString();
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
            }

        }

        private void student_s_id()
        {
            if (this.com_cName.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                try
                {

                    int myID;
                    SqlConnection con = SYS.db_connect();
                    con.Open();
                    SqlCommand cmddr = new SqlCommand("select max((s_id)) as ids from student", con);
                    SqlDataReader dr = cmddr.ExecuteReader();

                    while (dr.Read())
                    {
                        string str_sid = dr["ids"].ToString();
                        if (str_sid == "")
                        {
                            this.txts_id.Text = "1";
                        }
                        else
                        {
                            myID = Convert.ToInt32(dr["ids"]) + 1;
                            this.txts_id.Text = myID.ToString();
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
            }

        }

        private void com_cName_Leave(object sender, EventArgs e)
        {
            //if (this.str == "Adding")
            //{
            //    student_ID();
            //}
            //else
            //{
            //    return;
            //}
        }

        private void btn_Refresh_Click_1(object sender, EventArgs e)
        {
            list_Load();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {



        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }
        private void student_Delete()
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you sure to delete record!", "Delete".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                if (this.txtadmissionno.Text == "")
                {


                    MessageBox.Show("Some required Fields are Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {


                    try
                    {
                        this.cls_Con.cmdOpen(cmdForm);
                        cmdForm.CommandText = "delete * from student where s_id=?";


                        cmdForm.Parameters.Add("@s_id", OleDbType.Char).Value = this.strEdit;


                        cls_Con.cmdClose(cmdForm);
                        clsmyFunction.setMessageBox("Data Deleted Successfuly", 1);

                    }
                    catch (Exception exp)
                    {
                        clsmyFunction.setCreateError(exp.Message);

                    }
                    finally
                    {
                        this.cls_Con.cn.Close();
                    }
                }
            }
            else
            {
                return;
            }
        }


        private void lstv_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (str == "Modifying")
            {
                this.com_cName.SelectedIndex = -1;
                this.com_Sex.SelectedIndex = -1;
                this.com_cName.Text = "";
                this.com_Sex.Text = "";
                this.com_cName.DropDownStyle = ComboBoxStyle.Simple;
                this.com_Sex.DropDownStyle = ComboBoxStyle.Simple;
                //this.lstv_Student.Items[lstv_Student.FocusedItem.Index].SubItems[0].Text.Trim()
                GetStudentData(studentid);


            }
            else
            {
                return;
            }
        }

        private void GetStudentData(string studentid)
        {
            SqlConnection con = SYS.db_connect();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from  view_student where s_id='" + (studentid) + "'", con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    strEdit = dr["s_id"].ToString();
                    txt_Rollno.Text = dr["roll_no"].ToString();
                    txt_Sname.Text = dr["s_name"].ToString();
                    this.com_cName.SelectedValue = dr["c_id"].ToString();
                    this.txtAddress.Text = dr["address"].ToString();
                    this.txtContact.Text = dr["contact_no"].ToString();
                    this.txt_Fname.Text = dr["f_name"].ToString();
                    this.txtAge.Text = dr["age"].ToString();

                    if (!string.IsNullOrEmpty(dr["d_birth"].ToString()))
                    {
                        this.dp_Student.Value = Convert.ToDateTime(dr["d_birth"]);
                    }

                    this.com_Sex.Text = dr["sex"].ToString();
                    this.txtRemarks.Text = dr["remarks"].ToString();
                    this.txt_Mfee.Text = dr["m_fee"].ToString();
                    this.chk_Active.Checked = Convert.ToBoolean(dr["active"]);
                    this.isrelativeexist.Checked = Convert.ToBoolean(dr["RELETIVE_EXIST_FLAG"]);
                    this.txtcon_fee.Text = dr["CONCESSION_FEE"].ToString();

                    if (txtcon_fee.Text == "")
                    {
                        txtcon_fee.Text = "0";
                    }

                    this.txtrelation.Text = dr["RELATION"].ToString();
                    this.txtcon_reason.Text = dr["CONCESSION_REASON"].ToString();
                    //this.cmbsection.SelectedText = dr["SECTION"].ToString();
                    this.txtadmissionno.Text = dr["ADMISSION_NO"].ToString();
                    this.txtsecurityfee.Text = dr["SecurityFee"].ToString();



                    this.cmbshift.Text = dr["SHIFT"].ToString();
                    this.cmbtype.Text = dr["TYPE"].ToString();
                    this.cmbsection.Text = dr["SECTION_ID"].ToString();
                    this.txtreligion.Text = dr["RELEGION"].ToString();
                    this.txtcontact_office.Text = dr["TEL_OFFICE"].ToString();
                    this.txtcontact_resi.Text = dr["TEL_RESI"].ToString();

                    this.txtg_name.Text = dr["G_NAME"].ToString();
                    this.txtg_relation.Text = dr["G_RELATION"].ToString();
                    this.txtg_income.Text = dr["G_MONTHLYINCOME"].ToString();
                    this.txtg_cnic.Text = dr["G_CNIC"].ToString();
                    this.txtg_mobile.Text = dr["G_MOBILE"].ToString();
                    this.txtg_phone.Text = dr["G_PHONE"].ToString();
                    this.txtg_address.Text = dr["G_ADDRESS"].ToString();

                    this.txtp_empname.Text = dr["P_EMPNAME"].ToString();
                    this.txtp_section.Text = dr["P_SECTION"].ToString();
                    this.txtp_plno.Text = dr["P_PLNO"].ToString();
                    this.txtp_designation.Text = dr["P_DESIGNATION"].ToString();
                    this.txtp_dept.Text = dr["P_DEPARTMENT"].ToString();
                    this.txtp_authname.Text = dr["P_AUTHNAME"].ToString();
                    this.txtp_section1.Text = dr["P_SECTION1"].ToString();
                    this.txtp_plno1.Text = dr["P_PLNO1"].ToString();
                    this.txtp_designation1.Text = dr["P_DESIGNATION1"].ToString();
                    this.txtp_dept1.Text = dr["P_DEPARTMENT1"].ToString();
                    this.txtcnic_mother.Text = dr["CNIC_MOTHER"].ToString();
                    this.txtcnic_father.Text = dr["CNIC_FATHER"].ToString();
                    this.txtoccupation.Text = dr["FATHER_OCCUPATION"].ToString();


                    //='" +  + "',='" + .Text + "',='" + .Text + "',='" + .Text + "',='" + .Text + "',='" + .Text + "'
                    txtwhatsapp.Text = dr["WHATSAPP"].ToString();
                    txtemail.Text = dr["EMAIL"].ToString();
                    txtnationality.Text = dr["NATIONALITY"].ToString();
                    txtdomicile.Text = dr["DOMICILE"].ToString();
                    cmbmarital.Text = dr["MARITAL_STATUS"].ToString();
                    txtfather_desgin.Text = dr["FATHER_DESIG"].ToString();



                    this.chk_buscharges.Checked = Convert.ToBoolean(dr["buscharges"]);

                    this.txtbform.Text = dr["FORMB"].ToString();
                    try
                    {
                        if (!string.IsNullOrEmpty(dr["d_birth"].ToString()))
                        {
                            this.txtadmissiondate.Value = Convert.ToDateTime(dr["ADMISSION_DATE"]);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    // View Image
                    try
                    {
                        GetImage(studentid);
                        //DataSet rs = new DataSet();

                        //rs = SYS.Show_Query("select image from student where s_id='" + studentid + "'");

                        //if (rs.Tables[0].Rows.Count > 0)
                        //{
                        //    foreach (DataRow RowDocument in rs.Tables[0].Rows)
                        //    {
                        //        byte[] img_arr1 = (byte[])RowDocument[0];
                        //        MemoryStream ms1 = new MemoryStream(img_arr1);
                        //        ms1.Seek(0, SeekOrigin.Begin);

                        //        pictureBox2.Image = Image.FromStream(ms1, true, true);

                        //    }
                        //}



                        //SqlConnection cona = SYS.db_connect();
                        //cona.Open();
                        //SqlCommand cmda = new SqlCommand("select image from student where s_id='" + studentid + "'", con);
                        //SqlDataReader dra = cmd.ExecuteReader();
                        //if (dra.Read())
                        //{
                        //    pictureBox2.Image = Image.FromStream(dra.GetStream[0]);

                        //}


                        DataSet rs = new DataSet();
                        rs = SYS.Show_Query("select * from PREVIOUS_ACADEMICS where s_id='" + studentid + "'");
                        if (rs.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow RowDocument in rs.Tables[0].Rows)
                            {
                                SSC_year.Text = RowDocument["SSC_year"].ToString();
                                SSC_A_S.Text = RowDocument["SSC_A_S"].ToString();
                                SSC_Board.Text = RowDocument["SSC_Board"].ToString();
                                SSC_Subject.Text = RowDocument["SSC_Subject"].ToString();
                                SSC_Totalmarks.Text = RowDocument["SSC_Totalmarks"].ToString();
                                SSC_Makrsobt.Text = RowDocument["SSC_Makrsobt"].ToString();
                                SSC_prcnt.Text = RowDocument["SSC_prcnt"].ToString();
                                HSSC_Year.Text = RowDocument["HSSC_Year"].ToString();
                                HSSC_A_S.Text = RowDocument["HSSC_A_S"].ToString();
                                HSSC_Board.Text = RowDocument["HSSC_Board"].ToString();
                                HSSC_Subjects.Text = RowDocument["HSSC_Subjects"].ToString();
                                HSSC_Total_marks.Text = RowDocument["HSSC_Total_marks"].ToString();
                                HSSC_Marks_obt.Text = RowDocument["HSSC_Marks_obt"].ToString();
                                HSSC_Prcnt.Text = RowDocument["HSSC_Prcnt"].ToString();
                                GRAD_Year.Text = RowDocument["GRAD_Year"].ToString();
                                GRAD_A_S.Text = RowDocument["GRAD_A_S"].ToString();
                                GRAD_Board.Text = RowDocument["GRAD_Board"].ToString();
                                GRAD_Subjects.Text = RowDocument["GRAD_Subjects"].ToString();
                                GRAD_Total_marks.Text = RowDocument["GRAD_Total_marks"].ToString();
                                GRAD_Marks_obt.Text = RowDocument["GRAD_Marks_obt"].ToString();
                                GRAD_Prcnt.Text = RowDocument["GRAD_Prcnt"].ToString();
                            }
                        }

                    }
                    catch (Exception d)
                    {


                    }



                }
                con.Close();
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
        }

        private void GetImage(string STUDENTID)
        {
            {
                try
                {
                    SqlConnection cn = SYS.db_connect();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select image from student where s_id = '" + STUDENTID + "'", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    //                    while (dr.Read())
                    if (dr.Read())
                    {
                        //textBox2.Text = dr[0].ToString();
                        pictureBox2.Image = Base64ToImage(dr[0].ToString());
                    }
                    cn.Close();
                }
                catch (Exception)
                {

                }

            }
        }

        private void com_Sex_Enter(object sender, EventArgs e)
        {
            if (str == "Modifying")
            {
                this.com_Sex.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                return;
            }
        }

        private void com_Sex_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private void txt_Mfee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
            if (e.KeyChar == (char)13)
            {
                btnSave.Focus();

            }
        }

        private void rdo_Class_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void com_cName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //student_ID();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.str == "Adding")
            {
                student_ID();
                save_Student();
                list_Load();
            }
            else
            {
                return;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            picName = (txtadmissionno.Text + ".jal");
            SqlConnection con = SYS.db_connect();
            con.Open();
            SqlCommand cmd = con.CreateCommand();


            try
            {
                if (this.com_cName.SelectedIndex != -1)
                {
                    bool val;
                    bool buscharges = false;
                    string query = "";
                    val = this.chk_Active.Checked;
                    buscharges = this.chk_buscharges.Checked;
                    string discountid = "";
                    bool discountapplied = false;
                    if (isrelativeexist.Checked == true)
                    {

                        discountid = cmbdiscount.SelectedValue.ToString();
                        discountapplied = true;
                        query = "Update student set s_name='" + txt_Sname.Text + "', f_name='" + txt_Fname.Text + "',d_birth='" + dp_Student.Text + "',contact_no='" + txtContact.Text + "', address='" + txtAddress.Text + "',m_fee='" + int.Parse(txt_Mfee.Text) + "',SECTION_ID = '" + cmbsection.SelectedValue.ToString().Trim() + "',c_id ='" + com_cName.SelectedValue.ToString() + "',ADMISSION_NO='" + txtadmissionno.Text + "', SessionID='" + cmbsession.SelectedValue.ToString() + "',sex='" + this.com_Sex.Text.Trim() + "',CONCESSION_FEE='" + int.Parse(txtcon_fee.Text) + "',RELATION='" + txtrelation.Text + "', CNIC_MOTHER='" + txtcnic_mother.Text + "', CNIC_FATHER='" + txtcnic_father.Text + "' , FATHER_OCCUPATION='" + txtoccupation.Text + "',ADMISSION_DATE='" + txtadmissiondate.Value + "',SHIFT='" + cmbshift.SelectedValue.ToString().Trim() + "',TYPE='" + cmbtype.Text + "', DISCOUNT_APPLIED='" + discountapplied + "', DISCOUNT_ID='" + discountid + "', buscharges='" + buscharges + "',FORMB='" + txtbform.Text + "',SecurityFee='" + txtsecurityfee.Text + "'  where s_id='" + strEdit + "'";
                    }
                    else
                    {
                        query = "Update student set s_name='" + txt_Sname.Text + "', f_name='" + txt_Fname.Text + "',d_birth='" + dp_Student.Text + "',contact_no='" + txtContact.Text + "', address='" + txtAddress.Text + "',m_fee='" + int.Parse(txt_Mfee.Text) + "',SECTION_ID = '" + cmbsection.SelectedValue.ToString().Trim() + "',c_id ='" + com_cName.SelectedValue.ToString() + "',ADMISSION_NO='" + txtadmissionno.Text + "', SessionID='" + cmbsession.SelectedValue.ToString() + "',sex='" + this.com_Sex.Text.Trim() + "',CONCESSION_FEE='" + int.Parse(txtcon_fee.Text) + "',RELATION='" + txtrelation.Text + "', CNIC_MOTHER='" + txtcnic_mother.Text + "', CNIC_FATHER='" + txtcnic_father.Text + "' , FATHER_OCCUPATION='" + txtoccupation.Text + "',ADMISSION_DATE='" + txtadmissiondate.Value + "',SHIFT='" + cmbshift.SelectedValue.ToString().Trim() + "',TYPE='" + cmbtype.Text + "', DISCOUNT_APPLIED='" + discountapplied + "',DISCOUNT_ID=NULL, buscharges='" + buscharges + "',FORMB='" + txtbform.Text + "',SecurityFee='" + txtsecurityfee.Text + "'  where s_id='" + strEdit + "'";
                        discountid = "NULL";
                        discountapplied = false;
                    }
                    //query = "Update student set s_name='" + txt_Sname.Text + "', f_name='" + txt_Fname.Text + "',d_birth='" + dp_Student.Text + "',contact_no='" + txtContact.Text + "', address='" + txtAddress.Text + "',m_fee='" + int.Parse(txt_Mfee.Text) + "',SECTION_ID = '" + cmbsection.SelectedValue.ToString() + "',c_id ='" + com_cName.SelectedValue.ToString() + "',ADMISSION_NO='" + txtadmissionno.Text + "', SessionID='" + cmbsession.SelectedValue.ToString() + "',sex='" + this.com_Sex.Text.Trim() + "',CONCESSION_FEE='" + int.Parse(txtcon_fee.Text) + "',RELATION='" + txtrelation.Text + "', CNIC_MOTHER='" + txtcnic_mother.Text + "', CNIC_FATHER='" + txtcnic_father.Text + "' , FATHER_OCCUPATION='" + txtoccupation.Text + "',ADMISSION_DATE='" + txtadmissiondate.Value + "',SHIFT='" + cmbshift.SelectedValue + "',TYPE='" + cmbtype.Text + "', DISCOUNT_APPLIED='" + discountapplied + "', DISCOUNT_ID='" + discountid + "'  where s_id='" + strEdit + "'"; 
                    cmd.CommandText = query;
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        query = "Update student_class_history SET ADMISSION_NO='" + txtadmissionno.Text + "', c_id='" + com_cName.SelectedValue.ToString() + "', SECTION_ID = '" + cmbsection.SelectedValue.ToString() + "',session_id='" + cmbsession.SelectedValue.ToString() + "' where s_id='" + strEdit + "'";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        // ---------- save image ------------


                        query = "Update student set G_NAME='" + this.txtg_name.Text + "',G_RELATION='" + this.txtg_relation.Text + "',G_MONTHLYINCOME='" + this.txtg_income.Text + "',G_CNIC='" + this.txtg_cnic.Text + "',G_MOBILE='" + this.txtg_mobile.Text + "',G_PHONE='" + this.txtg_phone.Text + "',G_ADDRESS='" + this.txtg_address.Text + "',WHATSAPP='" + txtwhatsapp.Text + "',EMAIL='" + txtemail.Text + "',NATIONALITY='" + txtnationality.Text + "',DOMICILE='" + txtdomicile.Text + "',MARITAL_STATUS='" + cmbmarital.Text + "',FATHER_DESIG='" + txtfather_desgin.Text + "'  where s_id='" + strEdit + "'";
                        SYS.Insert_Query(query);



                        query = "Update student set P_EMPNAME='" + this.txtp_empname.Text + "',P_SECTION='" + this.txtp_section.Text + "',P_PLNO='" + this.txtp_plno.Text + "',P_DESIGNATION='" + this.txtp_designation.Text + "',P_DEPARTMENT='" + this.txtp_dept.Text + "',P_AUTHNAME='" + this.txtp_authname.Text + "',P_SECTION1='" + this.txtp_section1.Text + "',P_PLNO1='" + txtp_plno1.Text + "',P_DESIGNATION1='" + txtp_designation1.Text + "',P_DEPARTMENT1='" + txtp_dept1.Text + "'  where s_id='" + strEdit + "'";
                        SYS.Insert_Query(query);

                        DataSet rs = new DataSet();
                        rs = SYS.Show_Query("select * from PREVIOUS_ACADEMICS where s_id='" + strEdit + "'");
                        if (rs.Tables[0].Rows.Count > 0)
                        {
                            query = "Update PREVIOUS_ACADEMICS set [SSC_year]='" + SSC_year.Text + "',[SSC_A_S]='" + SSC_A_S.Text + "',[SSC_Board]='" + SSC_Board.Text + "',[SSC_Subject]='" + SSC_Subject.Text + "',[SSC_Totalmarks]='" + SSC_Totalmarks.Text + "',[SSC_Makrsobt]='" + SSC_Makrsobt.Text + "',[SSC_prcnt]='" + SSC_prcnt.Text + "',[HSSC_Year]='" + HSSC_Year.Text + "',[HSSC_A_S]='" + HSSC_A_S.Text + "',[HSSC_Board]='" + HSSC_Board.Text + "',[HSSC_Subjects]='" + HSSC_Subjects.Text + "',[HSSC_Total_marks]='" + HSSC_Total_marks.Text + "',[HSSC_Marks_obt]='" + HSSC_Marks_obt.Text + "',[HSSC_Prcnt]='" + HSSC_Prcnt.Text + "',[GRAD_Year]='" + GRAD_Year.Text + "',[GRAD_A_S]='" + GRAD_A_S.Text + "',[GRAD_Board]='" + GRAD_Board.Text + "',[GRAD_Subjects]='" + GRAD_Subjects.Text + "' ,[GRAD_Total_marks]='" + GRAD_Total_marks.Text + "' ,[GRAD_Marks_obt]='" + GRAD_Marks_obt.Text + "' ,[GRAD_Prcnt]='" + GRAD_Prcnt.Text + "'  where s_id='" + strEdit + "'";
                            SYS.Insert_Query(query);
                        }
                        else
                        {
                            query = "insert into PREVIOUS_ACADEMICS(s_id,c_id,ADMISSION_NO,session_id,branch_id,[SSC_year],[SSC_A_S],[SSC_Board],[SSC_Subject],[SSC_Totalmarks],[SSC_Makrsobt],[SSC_prcnt],[HSSC_Year],[HSSC_A_S],[HSSC_Board],[HSSC_Subjects],[HSSC_Total_marks],[HSSC_Marks_obt],[HSSC_Prcnt],[GRAD_Year],[GRAD_A_S],[GRAD_Board],[GRAD_Subjects] ,[GRAD_Total_marks] ,[GRAD_Marks_obt] ,[GRAD_Prcnt])";
                            query = query + " values(" + strEdit + "," + com_cName.SelectedValue.ToString() + ",'" + txtadmissionno.Text + "','" + SYSTEMSETTING.sessionid + "','" + SYSTEMSETTING.branch_ID + "','" + SSC_year.Text + "','" + SSC_A_S.Text + "','" + SSC_Board.Text + "','" + SSC_Subject.Text + "','" + SSC_Totalmarks.Text + "','" + SSC_Makrsobt.Text + "','" + SSC_prcnt.Text + "','" + HSSC_Year.Text + "','" + HSSC_A_S.Text + "','" + HSSC_Board.Text + "','" + HSSC_Subjects.Text + "','" + HSSC_Total_marks.Text + "','" + HSSC_Marks_obt.Text + "','" + HSSC_Prcnt.Text + "','" + GRAD_Year.Text + "','" + GRAD_A_S.Text + "','" + GRAD_Board.Text + "','" + GRAD_Subjects.Text + "','" + GRAD_Total_marks.Text + "','" + GRAD_Marks_obt.Text + "','" + GRAD_Prcnt.Text + "')";
                            SYS.Insert_Query(query);
                        }

                       

                        MessageBox.Show("Record Updated");
                    }
                    else
                    {
                        MessageBox.Show("Sorry Record Not Updated");
                    }
                    con.Close();
                    list_Load();
                }
                else
                {
                    MessageBox.Show("Please Select Class");
                }
                //cmd.Transaction = tran;

            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.com_cName.DropDownStyle == ComboBoxStyle.Simple)
            {
                this.com_cName.DropDownStyle = ComboBoxStyle.DropDownList;

            }

            // student_Delete();
            MessageBox.Show("You do not have permission to Delete the Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            list_Load();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearText();
            list_Load();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtadmissionno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_Sname.Focus();

            }
        }

        private void txt_Sname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_Fname.Focus();

            }
        }

        private void txt_Fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtAddress.Focus();

            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtRemarks.Focus();

            }
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txt_Mfee.Focus();

            }
        }

        private void isrelativeexist_CheckedChanged(object sender, EventArgs e)
        {

            if (isrelativeexist.Checked == true)
            {
                cmbdiscount.Enabled = true;
                //txtrel_admission.Enabled = true;
                //btnverify.Enabled = true;
                //txtrelation.Enabled = true;
            }
            else
            {
                cmbdiscount.Enabled = false;
                ////txtrel_admission.Enabled = false;
                ////btnverify.Enabled = false;
                ////txtrelation.Enabled = false;
            }

        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbtype.Text == "NON-POF")
            //{
            //    tabControl1.TabPages.Remove(tabPage4);
            //}
            //else if (cmbtype.Text == "POF")
            //{

            //    {
            //        tabControl1.TabPages.Add(tabPage4);
            //    }

            //}
        }

        private void cmbsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            student_ID();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        OpenFileDialog fd1 = new OpenFileDialog();
        OpenFileDialog fd2 = new OpenFileDialog();
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;


                pictureBox2.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                pictureBox2.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                //MessageBox.Show(ms1.Length.ToString()); calculate image length
                pictureBox2.Image = Image.FromFile(fd1.FileName);

                //if (ms1.Length > 25600)
                //    MessageBox.Show("Please upload less than 25 kb image");
                //else
                //    if (pictureBox2.Image != null)
                //    {
                //        pictureBox2.Image.Dispose();
                //        pictureBox2.Image = null;
                //    }
            }
            catch (Exception exp)
            {

            }
        }

        private void btnupdatepicture_Click(object sender, EventArgs e)
        {
            //try
            //{
            uploadpicture(strEdit);
            //    bool chk = false;
            //    string query = string.Empty;
            //    MemoryStream ms1 = new MemoryStream();
            //    pictureBox2.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    byte[] img_arr1 = new byte[ms1.Length];
            //    ms1.Read(img_arr1, 0, img_arr1.Length);

            //    query = "Update student set image='" + img_arr1 + "'  where s_id='" + strEdit + "'";
            //    chk = SYS.Insert_Query(query);
            //    if (chk == true)
            //    {
            //        SYS.setMessageBox("Picture Uploaded!", 1);
            //    }
            //    else
            //    {
            //        SYS.setCreateError("Picture not Uploaded please try again");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    SYS.setCreateError(ex.Message);
            //}
        }

        private void uploadpicture(string studentid)
        {

            //  SqlConnection cn = new SqlConnection("data source=localhost;initial catalog=notitest;user id=sa;password=cos123");
            //  cn.Open();

            //  SqlCommand cmd = new SqlCommand("insert imgtest values(" + textBox1.Text + ",'" + ImageToBase64(pictureBox2.Image,
            //System.Drawing.Imaging.ImageFormat.Png) + "')", cn);
            //  SqlDataReader dr = cmd.ExecuteReader();
            //  cn.Close();

            try
            {

                if (pictureBox2.Image == null)
                {
                    SYS.setCreateError("Please Select Image");
                }
                else
                {
                    bool chk = false;
                    string query = string.Empty;
                    query = "Update student set image='" + ImageToBase64(pictureBox2.Image,
              System.Drawing.Imaging.ImageFormat.Png) + "'  where s_id='" + studentid + "'";
                    chk = SYS.Insert_Query(query);
                    if (chk == true)
                    {
                        SYS.setMessageBox("Picture Uploaded!", 1);
                    }
                    else
                    {
                        SYS.setCreateError("Picture not Uploaded please try again");
                    }
                }

            }
            catch (Exception ex)
            {


            }




        }
        public string ImageToBase64(Image image,
          System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void btnremove_Click(object sender, EventArgs e)
        {


            DialogResult ret;
            ret = MessageBox.Show("Are you sure you want to Remove Picture?", "Confrim".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                bool chk = false;
                string query = string.Empty;
                query = "Update student set image='' where s_id='" + strEdit + "'";
                chk = SYS.Insert_Query(query);
                if (chk == true)
                {
                    SYS.setMessageBox("Picture Removed!", 1);
                    pictureBox2.Image = null;
                }
                else
                {
                    SYS.setCreateError("Picture not Removed please try again");
                }
            }



        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            //Rpt_Student frm_Exam = new Rpt_Student();
            //try
            //{
            //    frm_Exam.str = "SID";
            //    frm_Exam.class_id = com_cName.SelectedValue.ToString();
            //    frm_Exam.studentID = Convert.ToDecimal(studentid);
            //}
            //catch (Exception)
            //{


            //}

            //frm_Exam.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;
                img1.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img1.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img1.Image = Image.FromFile(fd1.FileName);

            }
            else
            {
                img1.Image = null;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;
                img2.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img2.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img2.Image = Image.FromFile(fd1.FileName);
            }
            else
            {
                img2.Image = null;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;
                img3.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img3.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img3.Image = Image.FromFile(fd1.FileName);
            }
            else
            {
                img3.Image = null;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;

                img4.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img4.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img4.Image = Image.FromFile(fd1.FileName);
            }
            else
            {
                img4.Image = null;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;
                img5.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img5.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img5.Image = Image.FromFile(fd1.FileName);
            }
            else
            {
                img5.Image = null;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;
                img8.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img8.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img8.Image = Image.FromFile(fd1.FileName);
            }
            else
            {
                img8.Image = null;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;

                img6.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img6.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img6.Image = Image.FromFile(fd1.FileName);
            }
            else
            {
                img6.Image = null;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;

                img7.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img7.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img7.Image = Image.FromFile(fd1.FileName);

            }
            else
            {
                img7.Image = null;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;

                img9.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img9.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img9.Image = Image.FromFile(fd1.FileName);

            }
            else
            {
                img9.Image = null;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;

                img10.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img10.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img10.Image = Image.FromFile(fd1.FileName);

            }
            else
            {
                img10.Image = null;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;

                img11.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img11.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img11.Image = Image.FromFile(fd1.FileName);

            }
            else
            {
                img11.Image = null;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;

                img12.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                img12.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                img12.Image = Image.FromFile(fd1.FileName);

            }
            else
            {
                img12.Image = null;
            }
        }

    }

}
