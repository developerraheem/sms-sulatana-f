using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace School._forms
{
    public partial class Frm_Student_Report : Form
    {
        public Frm_Student_Report()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        _class.clsODBC cls_Con = new School._class.clsODBC();
       
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        private void button2_Click(object sender, EventArgs e)
        {
            Rpt_Student frm_Exam = new Rpt_Student();
            try
            {
                frm_Exam.str = comboBox1.SelectedItem.ToString();
                frm_Exam.class_id = cmbclass.SelectedValue.ToString();
                frm_Exam.searching_value = txtvalue.Text;
            }
            catch (Exception)
            {
                
               
            }
           
            frm_Exam.Show();
        }

        private void Frm_Student_Report_Load(object sender, EventArgs e)
        {
            //this.cls_Con.comboFill(this.cmbclass, "select * from class", "class", "c_name", "c_id");
            //cls_Con.comboFill(this.cmbclass, "select * from class", "class", "c_name", "c_id");
            //this.cls_Con.comboFill(this.comboBox2, "select * from class", "class", "c_name", "c_id");
            //this.cls_Con.comboFill(this.cmbsession, "select * from [Sessions]", "Sessions", "SessionName", "SessionID");
            //this.cls_Con.comboFill(this.cmbsess, "select * from [Sessions]", "Sessions", "SessionName", "SessionID");

            SYSTEMSETTING SYS = new SYSTEMSETTING();
            SYS.comboFill(this.cmbclass, "select * from class  where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "Class", "c_name", "c_id");
            SYS.comboFill(this.cmbclass_to, "select * from class  where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.comboBox2, "select * from class  where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");



            SYS.comboFill(this.cmbsession, "select * from [Sessions]  where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sessions", "SessionName", "SessionID");
            cmbsession.SelectedValue = SYSTEMSETTING.sessionid.ToString();
            SYS.comboFill(this.cmbsess, "select * from [Sessions]  where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sessions", "SessionName", "SessionID");
            cmbsess.SelectedValue = SYSTEMSETTING.sessionid.ToString();

            SYS.comboFill(this.cmbsection, "SELECT [SECTION_ID],[SECTION_NAME] FROM [Sections]  where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_ID");
            SYS.comboFill(this.cmbsection_to, "SELECT [SECTION_ID],[SECTION_NAME] FROM [Sections]  where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_ID");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT]  where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT_ID");
            SYS.comboFill(this.cmbshift_to, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT]  where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT_ID");
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmStudentList frm_Exam = new FrmStudentList();
            frm_Exam.classid = comboBox2.SelectedValue.ToString();
            frm_Exam.sessionid = cmbsession.SelectedValue.ToString();
            frm_Exam.sectionid = cmbsection.SelectedValue.ToString();
            frm_Exam.shif = cmbshift.Text.ToString();


            frm_Exam.classid_to = cmbclass_to.SelectedValue.ToString();
            //frm_Exam.sectionid_to = cmbsection_to.SelectedValue.ToString();
            //frm_Exam.shif_to = cmbshift_to.SelectedValue.ToString();

            if (checkBox1.Checked == true)
            {
                frm_Exam.busavailed = "Y";
            }

             frm_Exam.Show();
         
        }
    }
}
