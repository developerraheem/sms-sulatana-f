using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class MDI_Admin : Form
    {

        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        public MDI_Admin()
        {
            InitializeComponent();

            try
            {
                rs = SYS.Show_Query("SELECT [branch_name] FROM [branch]");
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    this.Text = RowDocument[0].ToString();
                }
            }
                
            catch (Exception)
            {


            }
        }

        private void rbtnexpenserpt_Click(object sender, EventArgs e)
        {
            
        }

        private void rbtnbranch_Click(object sender, EventArgs e)
        {
            frmbranch frm = new frmbranch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnshift_Click(object sender, EventArgs e)
        {
            frmshift frm = new frmshift();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnsection_Click(object sender, EventArgs e)
        {
            frmsection frm = new frmsection();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnsession_Click(object sender, EventArgs e)
        {
            FrmSession frm = new FrmSession();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnclass_Click(object sender, EventArgs e)
        {
            frmClass frm = new frmClass();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnemployee_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnfeehead_Click(object sender, EventArgs e)
        {
            Frmfee_head frm = new Frmfee_head();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnexpensehead_Click(object sender, EventArgs e)
        {
            frmExp frm = new frmExp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnbanks_Click(object sender, EventArgs e)
        {
            FrmBank frm = new FrmBank();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnstudents_Click(object sender, EventArgs e)
        {
            frm_manage_students frm = new frm_manage_students();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnstudentreports_Click(object sender, EventArgs e)
        {
            Frm_Student_Report frm = new Frm_Student_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnclasswisefee_Click(object sender, EventArgs e)
        {
            frmclasswisefeesetup frm = new frmclasswisefeesetup();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnfineentry_Click(object sender, EventArgs e)
        {
            FrmFine frm = new FrmFine();
            frm.MdiParent = this;
            frm.Show();
        }

              

        private void rbtnfeentry_Click(object sender, EventArgs e)
        {
            Frm_FeeEntry frm = new Frm_FeeEntry();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnexpenseentry_Click(object sender, EventArgs e)
        {
            Fr_FeeEntry_Classwise frm = new Fr_FeeEntry_Classwise();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnvoucherprint_Click(object sender, EventArgs e)
        {
            
        }

        private void ribbonOrbOptionButton1_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
                //this.Close();
            }
            else
            {
                return;
            }
        }

        private void rbtnexitap_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
                //this.Close();
            }
            else
            {
                return;
            }
        }

        private void rbtnclose_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDI_Admin_Load(object sender, EventArgs e)
        {
            
        }

        private void rbtnfeegen_Click(object sender, EventArgs e)
        {
            Frm_generatefee frm = new Frm_generatefee();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtndelv_Click(object sender, EventArgs e)
        {
            frmDeleteVoucher frm = new frmDeleteVoucher();
            frm.MdiParent = this;
            frm.Show();

        }

        private void rbtneditvoucher_Click(object sender, EventArgs e)
        {
            Frm_editfee frm = new Frm_editfee();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rbtnoutstandingstd_Click(object sender, EventArgs e)
        {
           

        }

        private void ribbonLabel1_Click(object sender, EventArgs e)
        {
            //PrntClasswiseoutst frm = new PrntClasswiseoutst();
            //frm.Show();

            
        }

        private void ribbonLabel2_Click(object sender, EventArgs e)
        {
           
        }

        private void ribbonLabel3_Click(object sender, EventArgs e)
        {
           
        }

        private void ribbonLabel4_Click(object sender, EventArgs e)
        {
            
        }

        private void ribbonButton3_Click(object sender, EventArgs e)
        {
            frmUnpostVoucher frm = new frmUnpostVoucher();
            frm.ShowDialog();
        }

        private void ribbonButton6_Click(object sender, EventArgs e)
        {
            frmDeactivateStudent frm = new frmDeactivateStudent();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbonLabel5_Click(object sender, EventArgs e)
        {
            ClasswiseStregnthReport frm = new ClasswiseStregnthReport();
            frm.Show();
        }

        private void ribbonLabel8_Click(object sender, EventArgs e)
        {
          
        }

        private void ribbonLabel7_Click(object sender, EventArgs e)
        {
            SLC FRM = new SLC();
            FRM.Show();
        }

        private void ribbonLabel6_Click(object sender, EventArgs e)
        {
           
        }

        private void ribbonLabel9_Click(object sender, EventArgs e)
        {
            
        }

        private void ribbonLabel10_Click(object sender, EventArgs e)
        {
           
        }

        private void ribbonLabel11_Click(object sender, EventArgs e)
        {
            
        }

        private void RIBBON_MENU_Click(object sender, EventArgs e)
        {

        }

        private void ribbonLabel12_Click(object sender, EventArgs e)
        {
            FrmVoucherPr frm = new FrmVoucherPr();
            frm.Show();
        }

        private void ribbonLabel13_Click(object sender, EventArgs e)
        {
            FrmUnpaidVoucher frm = new FrmUnpaidVoucher();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbonLabel14_Click(object sender, EventArgs e)
        {
            FrmFeeHeadWIse frm = new FrmFeeHeadWIse();
            frm.Show();
        }

        private void ribbonLabel15_Click(object sender, EventArgs e)
        {
            //ReportsNew.DefaulterStudents_monthselection frm = new ReportsNew.DefaulterStudents_monthselection();
            //frm.Show();


            ReportsNew.DefaulterStudent_all frm = new ReportsNew.DefaulterStudent_all();
            frm.Show();
        }

        private void ribbonLabel16_Click(object sender, EventArgs e)
        {
            HeadWiseFeeReport frm = new HeadWiseFeeReport();
            frm.Show();
        }

        private void ribbonLabel17_Click(object sender, EventArgs e)
        {
            FrmLedger frm = new FrmLedger();
            frm.ShowDialog();
        }

        private void ribbonLabel18_Click(object sender, EventArgs e)
        {
            ReportsNew.DateWisePostedReport_param frm = new ReportsNew.DateWisePostedReport_param();
            frm.Show();
        }

       

        private void ribbonLabel20_Click(object sender, EventArgs e)
        {
            ReportsNew.BankwisePosted_param frm = new ReportsNew.BankwisePosted_param();
            frm.ShowDialog();
        }

        private void ribbonLabel21_Click(object sender, EventArgs e)
        {
            ReportsNew.Datewiseposting_param frm = new ReportsNew.Datewiseposting_param();
            frm.ShowDialog();
        }

        private void ribbonLabel22_Click(object sender, EventArgs e)
        {
            SummaryReport rpt = new SummaryReport();
            rpt.Show();
        }

        private void rbtnvoucherprint_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ribbonButton7_Click(object sender, EventArgs e)
        {
            Frm_generatefee_multi frm = new Frm_generatefee_multi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbonButton8_Click(object sender, EventArgs e)
        {
            SMSapplication.SMSapplication sms = new SMSapplication.SMSapplication();
            sms.Show();
            
        }

        private void ribbonButton13_Click(object sender, EventArgs e)
        {
            frm_student_promotions frm = new frm_student_promotions();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbonButton14_Click(object sender, EventArgs e)
        {
            frmchangesession frm = new frmchangesession();
            frm.Show();
            this.Close();
        }

        private void ribbonLabel1_Click_1(object sender, EventArgs e)
        {
            _Sum_Reports.Rptstreginths_mwise_param frm = new _Sum_Reports.Rptstreginths_mwise_param();
            frm.Show();
        }

        private void ribbonButton9_Click(object sender, EventArgs e)
        {
            //SYS.setCreateError("You are not Allowed! Please contact Solution Provider");
            Attendance_module.frm_std_attend_manually frm = new Attendance_module.frm_std_attend_manually();
            frm.Show();
        }

        private void ribbonButton10_Click(object sender, EventArgs e)
        {
            SYS.setCreateError("You are not Allowed! Please contact Solution Provider");
        }

       
      

        private void lblclassheadwisefee_Click(object sender, EventArgs e)
        {
         //D:\TSI\Projects\School Management System\POF Model School\Campus IV\Fee_Summary_Reports\Head_Class_wise_feereport_param.cs
            School.Fee_Summary_Reports.Head_Class_wise_feereport_param frm = new Fee_Summary_Reports.Head_Class_wise_feereport_param();
            frm.ShowDialog();
          
            

        }

        private void lblbankwisepostedsummary_Click(object sender, EventArgs e)
        {
            School.Fee_Summary_Reports.Summary_bank_wise_posted_param frm = new Fee_Summary_Reports.Summary_bank_wise_posted_param();
            frm.ShowDialog();
        }

        private void lbldefaultersummary_Click(object sender, EventArgs e)
        {
            School.Fee_Summary_Reports.Summary_Defaulter_param frm = new Fee_Summary_Reports.Summary_Defaulter_param();
            frm.ShowDialog();
        }

        private void lblheadstudentwisereport_Click(object sender, EventArgs e)
        {
            School.Fee_Summary_Reports.Head_student_wise_fee_param frm = new Fee_Summary_Reports.Head_student_wise_fee_param();
            frm.ShowDialog();
        }

        private void lbldatewiseadmission_Click(object sender, EventArgs e)
        {
            Reports.rpt_admission_datewise frm = new Reports.rpt_admission_datewise();
            frm.ShowDialog();
        }

        private void ribbonLabel2_Click_1(object sender, EventArgs e)
        {
            Reports.RPT_DEFAULTER_READMISSION rpt = new Reports.RPT_DEFAULTER_READMISSION();
            rpt.Show();
        }

        private void ribbonLabel3_Click_1(object sender, EventArgs e)
        {
            //Fee_Summary_Reports.Fee_according_strength frm = new Fee_Summary_Reports.Fee_according_strength();
            //frm.Show();

            ReportsNew.DefaulterStudents_monthselection frm = new ReportsNew.DefaulterStudents_monthselection();
            frm.Show();

        }

        private void ribbonLabel4_Click_1(object sender, EventArgs e)
        {
            //Fee_Summary_Reports.school_profile frm = new Fee_Summary_Reports.school_profile();
            //frm.Show();

            //School.Fee_Summary_Reports.STUCKOFF_LEAVE_PARAM frm = new School.Fee_Summary_Reports.STUCKOFF_LEAVE_PARAM();
            //frm.Show();
        }

        private void ribbonLabel6_Click_1(object sender, EventArgs e)
        {
            _Sum_Reports.Rptstreginths_mwise_param frm = new _Sum_Reports.Rptstreginths_mwise_param();
            frm.Show();
        }

        private void rbtnexpensedetail_Click(object sender, EventArgs e)
        {
            frmExpDetail frm = new frmExpDetail();
            frm.Show();
        }

        private void rbtnsubjects_Click(object sender, EventArgs e)
        {
            frmSubject frm = new frmSubject();
            frm.Show();
        }

        private void ribbonLabel8_Click_1(object sender, EventArgs e)
        {
            frmExam frm = new frmExam();
            frm.Show();

        }

        private void ribbonLabel27_Click(object sender, EventArgs e)
        {
            Fee_Summary_Reports.concession_detail frm = new Fee_Summary_Reports.concession_detail();
            frm.Show();
        }

        private void ribbonLabel28_Click(object sender, EventArgs e)
        {
            Fee_Summary_Reports.concession_detail_summary frm = new Fee_Summary_Reports.concession_detail_summary();
            frm.Show();
        }

        private void ribbonLabel9_Click_1(object sender, EventArgs e)
        {
            frmexam_compile frm = new frmexam_compile();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbonLabel29_Click(object sender, EventArgs e)
        {

        }

        private void ribbonButton12_Click(object sender, EventArgs e)
        {

        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
