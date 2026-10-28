using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace School._forms
{
    public partial class frmDeactivateStudent : Form
    {
        public frmDeactivateStudent()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        string query = "";
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            bool val = false;
            if (cmbtype.Text == "Change Shift")
            {
                query = "INSERT INTO [STUDENT_SHIFTING] ([c_id],[shift],[section_id],[s_id],[admission_no],[shifting_type],[shifting_date],[new_admission_no],[new_shift],[new_section],[reason],[sessionid],[branch_id])";
                query = query + "values('" + com_cName.SelectedValue + "','" + cmbshift.SelectedValue + "','" + txtsectionid.Text + "','" + txtstudentid.Text + "','" + txtadmissionno.Text + "','" + cmbtype.Text + "', '" + txtdate.Text + "','" + txtnewadmission.Text + "','" + cmbnewshift.SelectedValue + "','" + cmbnewsection.SelectedValue + "','" + txtreason.Text + "','" + SYSTEMSETTING.sessionid + "','"+ SYSTEMSETTING.branch_ID +"')";
                bool a = SYS.Insert_Query(query);
                if (a == true)
                {
                    val = true;
                    SYS.Insert_Query("Update student set active='" + val + "', ADMISSION_NO='" + txtnewadmission.Text + "', SECTION_ID='" + cmbnewsection.SelectedValue + "', SHIFT='" + cmbnewshift.SelectedValue + "' where s_id='" + txtstudentid.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                    SYS.setMessageBox("Shift Changed Successfuly", 1);
                    
                    
                    txtstudentid.Text = string.Empty;
                    txtadmissionno.Text = string.Empty;
                    txt_Sname.Text = string.Empty;
                    txtreason.Text = string.Empty;
                    txtstudentid.Text = string.Empty;





                }
            }

            else
            {
                query = "INSERT INTO [STUDENT_SHIFTING] ([c_id],[shift],[section_id],[s_id],[admission_no],[shifting_type],[shifting_date],[reason],[sessionid],[branch_id])";
                query = query + "values('" + com_cName.SelectedValue + "','" + cmbshift.SelectedValue + "','" + txtsectionid.Text + "','" + txtstudentid.Text + "','" + txtadmissionno.Text + "','" + cmbtype.Text + "', '" + txtdate.Text + "','" + txtreason.Text + "','"+ SYSTEMSETTING.sessionid +"','"+ SYSTEMSETTING.branch_ID +"')";
                bool a = SYS.Insert_Query(query);

                if (a == true)
                {
                    val = false;
                    SYS.Insert_Query("Update student set active='" + val + "' where s_id='" + txtstudentid.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                    SYS.setMessageBox("Student status changed Successfuly", 1);
                    txtstudentid.Text = string.Empty;
                    txtadmissionno.Text = string.Empty;
                    txt_Sname.Text = string.Empty;
                    txtreason.Text = string.Empty;
                    txtstudentid.Text = string.Empty;
                }

            }
        }

        private void frmDeactivateStudent_Load(object sender, EventArgs e)
        {
            SYS.comboFill(this.com_cName, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbnewshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbnewsection, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");

        }

        public string Student_ID
        {
            get { return txtstudentid.Text; }
            set { txtstudentid.Text = value; }
        }

        private void btnfindstd_Click(object sender, EventArgs e)
        {
            if (txtstudentid.Text.Length > 0)
            {

                rs = SYS.Show_Query("Select * from student where s_id='" + txtstudentid.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                foreach (DataRow Row in rs.Tables[0].Rows)
                {
                    txt_Sname.Text = Row["s_name"].ToString();
                    txtsectionid.Text = Row["SECTION_ID"].ToString();
                    this.txtadmissionno.Text = Row["ADMISSION_NO"].ToString();
                    button1.Enabled = true;
                }
            }
            else
            {

                button1.Enabled = false;
                Frmfind_student frm = new Frmfind_student(this);
                frm.param = "De-Active";
                frm.Classid = com_cName.SelectedValue.ToString();
                frm.Shift = cmbshift.SelectedValue.ToString();
                frm.ShowDialog();

            }

        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtype.Text == "Change Shift")
            {
                txtnewadmission.Enabled = true;
                cmbnewsection.Enabled = true;
                cmbnewshift.Enabled = true;
                txtnewadmission.Text = "";
            }
            else
            {
                txtnewadmission.Enabled = false;
                cmbnewsection.Enabled = false;
                cmbnewshift.Enabled = false;
                txtnewadmission.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SLC_Certificate frm = new SLC_Certificate();
            frm.admissionno = txtadmissionno.Text;
            frm.Show();
        }

        private void com_cName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
