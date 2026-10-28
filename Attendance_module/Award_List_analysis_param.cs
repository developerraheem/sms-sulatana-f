using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.Attendance_module
{
    public partial class Award_List_analysis_param : Form
    {
        public Award_List_analysis_param()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        private void Award_List_param_Load(object sender, EventArgs e)
        {
            this.SYS.comboFill(this.cmbclassfrom, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbsectionfrom, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
            SYS.comboFill(this.cmbsubject, "select ID,sub_name from [subject] where c_id='" + cmbclassfrom.SelectedValue.ToString() + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'", "subject", "sub_name", "ID");
            SYS.comboFill(this.cmb_examfrom, "SELECT [e_id],[e_name] FROM  [exam] where branch_id='" + SYSTEMSETTING.branch_ID + "'  order by e_id", "exam", "e_name", "e_id");
            SYS.comboFill(this.cmb_examto, "SELECT [e_id],[e_name] FROM  [exam] where branch_id='" + SYSTEMSETTING.branch_ID + "'  order by e_id desc", "exam", "e_name", "e_id");
            //
        }

        private void frmclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbclassfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SYS.comboFill(this.cmbsubject, "select ID,sub_name from [subject] where c_id='" + cmbclassfrom.SelectedValue.ToString() + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'", "subject", "sub_name", "ID");
        }

        private void cmbsectionfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SYS.comboFill(this.cmbsubject, "select ID,sub_name from [subject] where c_id='" + cmbclassfrom.SelectedValue.ToString() + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'", "subject", "sub_name", "ID");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Attendance_module.award_list FRM = new award_list();
            //FRM.CLASS_ID = cmbclassfrom.SelectedValue.ToString();
            //FRM.SECTION_ID = cmbsectionfrom.SelectedValue.ToString();
            //FRM.SUBJECT_ID = cmbsubject.SelectedValue.ToString();
            //FRM.Show();

            SF_REPORTS.award_list_analysis RPT = new SF_REPORTS.award_list_analysis();
            //RPT.STUDENTID = cmbstudents.SelectedValue.ToString();
            RPT.SECTIONID = cmbsectionfrom.SelectedValue.ToString();
            RPT.CLASSID = cmbclassfrom.SelectedValue.ToString();

            RPT.FRM_EXAM = cmb_examfrom.SelectedValue.ToString();
            RPT.TO_EXM = cmb_examto.SelectedValue.ToString();


            RPT.Show();



        }
    }
}
