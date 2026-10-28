using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class MDI_new_admin : Form
    {
        private int childFormNumber = 0;

        public MDI_new_admin()
        {
            InitializeComponent();
            this.Text = "School & College Management System |" + SYSTEMSETTING.schoolname;
            
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MDI_new_admin_Load(object sender, EventArgs e)
        {
            this.ControlBox = true;
            this.menuStrip1.AllowMerge = false;

            ThemeHelper.ApplyTheme(this);
            statusBar1.Panels[0].Text = statusBar1.Panels[0].Text + SYSTEMSETTING.sUserName;
            statusBar1.Panels[1].Text = statusBar1.Panels[1].Text + SYSTEMSETTING.sessionname;
            statusBar1.Panels[2].Text = statusBar1.Panels[2].Text + DateTime.Now.ToLongDateString();
            statusBar1.Panels[3].Text = statusBar1.Panels[3].Text + SYSTEMSETTING.schoolname;

            this.toolStrip.Visible = false;
            this.toolStrip1.Visible = false;
            this.menuStrip.Visible = false;

            dashbaord frm = new dashbaord();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void statusBar1_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {

        }

        private void mangeShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmshift frm = new frmshift();
            frm.MdiParent = this;
            frm.Show();
        }

        private void operationalReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void schoolSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbranch frm = new frmbranch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsection frm = new frmsection();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSession frm = new FrmSession();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClass frm = new frmClass();
            frm.MdiParent = this;
            frm.Show();
        }

        private void employeeSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();
            frm.MdiParent = this;
            frm.Show();
        }

        private void feeHeadSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmfee_head frm = new Frmfee_head();
            frm.MdiParent = this;
            frm.Show();
        }

        private void expenseHeadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExp frm = new frmExp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void expenseDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpDetail frm = new frmExpDetail();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageBanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBank frm = new FrmBank();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_manage_students frm = new frm_manage_students();
            frm.MdiParent = this;
            frm.Show();
        }

        private void admissionReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Student_Report frm = new Frm_Student_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void strengthReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClasswiseStregnthReport frm = new ClasswiseStregnthReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sLCStatusReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SLC FRM = new SLC();
            FRM.MdiParent = this;
            FRM.Show();
        }

        private void monthwiseStrengthReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Sum_Reports.Rptstreginths_mwise_param frm = new _Sum_Reports.Rptstreginths_mwise_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dateWiseAdmissionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.rpt_admission_datewise frm = new Reports.rpt_admission_datewise();
            frm.MdiParent = this;
            frm.Show();
        }

        private void classWiseFeeMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmclasswisefeesetup frm = new frmclasswisefeesetup();

            frm.MdiParent = this;
            frm.Show();
        }

        private void fineDiscountEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFine frm = new FrmFine();
            frm.MdiParent = this;
            frm.Show();
        }

        private void generateFeeSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_generatefee_multi frm = new Frm_generatefee_multi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void editFeeVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_editfee frm = new Frm_editfee();
            frm.MdiParent = this;
            frm.Show();
        }

        private void feeVoucherPostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_FeeEntry frm = new Frm_FeeEntry();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //SYS.setCreateError("You are not Allowed! Please contact Solution Provider");
            
        }

        private void classWiseSubjectsMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubject frm = new frmSubject();
            frm.MdiParent = this;
            frm.Show();
        }

        private void examsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExam frm = new frmExam();
            frm.MdiParent = this;
            frm.Show();
        }

        private void progressReportCompilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmexam_compile frm = new frmexam_compile();
            frm.MdiParent = this;
            frm.Show();
        }

        private void deleteVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeleteVoucher frm = new frmDeleteVoucher();
            frm.MdiParent = this;
            frm.Show();
        }

        private void unPostVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnpostVoucher frm = new frmUnpostVoucher();
            frm.MdiParent = this;
            frm.Show();
        }

        private void deActivateChangeShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeactivateStudent frm = new frmDeactivateStudent();
            frm.MdiParent = this;
            frm.Show();
        }

        private void studentShiftingPromotionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_student_promotions frm = new frm_student_promotions();
            frm.MdiParent = this;
            frm.Show();
        }

        private void feeVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVoucherPr frm = new FrmVoucherPr();
            frm.MdiParent = this;
            frm.Show();
        }

        private void voucherListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUnpaidVoucher frm = new FrmUnpaidVoucher();
            frm.MdiParent = this;
            frm.Show();
        }

        private void classWiseOutstandingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFeeHeadWIse frm = new FrmFeeHeadWIse();
            frm.MdiParent = this;
            frm.Show();

        }

        private void singleHeadWiseFeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeadWiseFeeReport frm = new HeadWiseFeeReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void studentLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLedger frm = new FrmLedger();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dateWisePostedVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void bankWisePostedVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dateWisePostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void monthWiseSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SummaryReport rpt = new SummaryReport();
            rpt.MdiParent = this;
            rpt.Show();
        }

        private void headClassWiseFeeSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            School.Fee_Summary_Reports.Head_Class_wise_feereport_param frm = new Fee_Summary_Reports.Head_Class_wise_feereport_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void headClassWiseFeeDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            School.Fee_Summary_Reports.Head_student_wise_fee_param frm = new Fee_Summary_Reports.Head_student_wise_fee_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bankWisePostedSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void unPostedVoucherSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            School.Fee_Summary_Reports.Summary_Defaulter_param frm = new Fee_Summary_Reports.Summary_Defaulter_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void defaulterForReAdmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.RPT_DEFAULTER_READMISSION rpt = new Reports.RPT_DEFAULTER_READMISSION();
            rpt.MdiParent = this;
            rpt.Show();
        }

        private void unPostedVoucherDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsNew.DefaulterStudents_monthselection frm = new ReportsNew.DefaulterStudents_monthselection();
            frm.MdiParent = this;
            frm.Show();
        }

        private void stuckOffLeaveStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Fee_Summary_Reports.school_profile frm = new Fee_Summary_Reports.school_profile();
            //frm.Show();

            //School.Fee_Summary_Reports.STUCKOFF_LEAVE_PARAM frm = new School.Fee_Summary_Reports.STUCKOFF_LEAVE_PARAM();

            Fee_Summary_Reports.STUCKOFF_LEAVE_PARAM_n frm1 = new Fee_Summary_Reports.STUCKOFF_LEAVE_PARAM_n();
            frm1.Show();

        }

        private void monthWiseStrengthReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _Sum_Reports.Rptstreginths_mwise_param frm = new _Sum_Reports.Rptstreginths_mwise_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void feeConcessionDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fee_Summary_Reports.concession_detail frm = new Fee_Summary_Reports.concession_detail();
            frm.MdiParent = this;
            frm.Show();
        }

        private void feeConcessionSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fee_Summary_Reports.concession_detail_summary frm = new Fee_Summary_Reports.concession_detail_summary();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmFindExp frm = new frmFindExp();
            //frm.ShowDialog();

            dashbaord frm = new dashbaord();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ReportsNew.DefaulterStudents_monthselection frm = new ReportsNew.DefaulterStudents_monthselection();
            //frm.feemonth = txtfeemonth.Text;
            frm.Show();
        }

        private void changeSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmchangesession frm = new frmchangesession();
            //frm.Show();
            //this.Close();

        }

        private void quarterlyFeeConcessionDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fee_Summary_Reports.concession_summary FRM = new Fee_Summary_Reports.concession_summary();
            FRM.Show();
        }

        private void markAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance_module.frm_std_attend_manually frm = new Attendance_module.frm_std_attend_manually();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dailyAttendanceSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SF_REPORTS.rpt_Attend_summary frm = new SF_REPORTS.rpt_Attend_summary();
            frm.MdiParent = this;
            frm.Show();
        }

        private void advanceSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsearch frm = new frmsearch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void studentShiftingPromotionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_student_promotions frm = new frm_student_promotions();
            frm.MdiParent = this;
            frm.Show();        }

        private void closeApplicationToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void changeSessionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmchangesession frm = new frmchangesession();
            frm.Show();
            this.Close();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmbranch frm = new frmbranch();
            //frm.ShowDialog();
            security_module.frmusers frm = new security_module.frmusers();
            frm.ShowDialog();
        }

       
        private void orgSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbranch frm = new frmbranch();
            frm.ShowDialog();
        }

        private void printAwardListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance_module.Award_List_param awr = new Attendance_module.Award_List_param();
            awr.ShowDialog();
        }

        private void cummulativeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance_module.rpt_class_wise_attendance_month_param frm = new Attendance_module.rpt_class_wise_attendance_month_param();
            frm.ShowDialog();
        }

        private void classWiseAttendanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance_module.rpt_class_wise_attendance_param frm = new Attendance_module.rpt_class_wise_attendance_param();
            frm.ShowDialog();

        }

        private void classWiseResultAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance_module.Award_List_analysis_param frm = new Attendance_module.Award_List_analysis_param();
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            frmexam_compile_classwise frm = new frmexam_compile_classwise();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dailyCashReconciliationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsNew.DateWisePostedReport_param frm = new ReportsNew.DateWisePostedReport_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bankWisePostedSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportsNew.BankwisePosted_param frm = new ReportsNew.BankwisePosted_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dateWisePostedVoucherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportsNew.DateWisePostedReport_param frm = new ReportsNew.DateWisePostedReport_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bankWisePostedVoucherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportsNew.BankwisePosted_param frm = new ReportsNew.BankwisePosted_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dateWisePostingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportsNew.Datewiseposting_param frm = new ReportsNew.Datewiseposting_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bankWisePostedSummaryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            School.Fee_Summary_Reports.Summary_bank_wise_posted_param frm = new Fee_Summary_Reports.Summary_bank_wise_posted_param();
            frm.MdiParent = this;
            frm.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            security_module.frmchangepassword frm = new security_module.frmchangepassword();
            frm.ShowDialog();
        }
    }
}
