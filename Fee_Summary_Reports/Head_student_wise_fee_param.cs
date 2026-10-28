using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace School.Fee_Summary_Reports
{
    public partial class Head_student_wise_fee_param : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();

        public Head_student_wise_fee_param()
        {
            InitializeComponent();
        }

        private void frmclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                Head_student_wise_fee frm = new Head_student_wise_fee();
                frm.feemonth = cmbmonth.Text;
                frm.sessionid = SYSTEMSETTING.sessionid;
                frm.classfrom = cmbclassfrom.SelectedValue.ToString();
                frm.classto = cmbclassto.SelectedValue.ToString();
                frm.PAID_TAG = comboBox1.Text;
                frm.section_from = cmbsectionfrom.SelectedValue.ToString();
                frm.section_to = cmbsectionto.SelectedValue.ToString();
                frm.type_from = cmbtypefrom.SelectedValue.ToString();
                frm.type_to = cmbtypeto.SelectedValue.ToString();

                frm.Show();
            }
            else
            {
                Head_student_wise_fee_withouthead frm = new Head_student_wise_fee_withouthead();
                frm.feemonth = cmbmonth.Text;
                frm.sessionid = SYSTEMSETTING.sessionid;
                frm.classfrom = cmbclassfrom.SelectedValue.ToString();
                frm.classto = cmbclassto.SelectedValue.ToString();
                frm.PAID_TAG = comboBox1.Text;
                frm.section_from = cmbsectionfrom.SelectedValue.ToString();
                frm.section_to = cmbsectionto.SelectedValue.ToString();
                frm.type_from = cmbtypefrom.SelectedValue.ToString();
                frm.type_to = cmbtypeto.SelectedValue.ToString();
                frm.Show();
            }


        }

        private void Head_Class_wise_feereport_param_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyTheme(this);
            this.SYS.comboFill(this.cmbclassfrom, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            this.SYS.comboFill(this.cmbclassto, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");

            SYS.comboFill(this.cmbsectionfrom, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
            SYS.comboFill(this.cmbsectionto, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");

            SYS.comboFill(this.cmbtypefrom, "select typecode from student_type where branch_id='" + SYSTEMSETTING.branch_ID + "' order by typecode", "student_type", "typecode", "typecode");
            SYS.comboFill(this.cmbtypeto, "select typecode from student_type where branch_id='" + SYSTEMSETTING.branch_ID + "' order by typecode", "student_type", "typecode", "typecode");
        }
    }
}

