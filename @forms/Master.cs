using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace School._forms
{
    public partial class Master : Form
    {
        private int childFormNumber = 0;

        public Master()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            frmQclass frm = new frmQclass();
            frm.MdiParent = this;
            frm.Show();
            
        }

        private void OpenFile(object sender, EventArgs e)
        {
            frmsection frm = new frmsection();
            frm.MdiParent = this;
            frm.Show();
            //string Param = Microsoft.VisualBasic.Interaction.InputBox("Enter Admission No for Print Student Record ", "TechnoSpyre Inc", string.Empty, 100, 100);
            //if (!Param.Trim().Equals(""))
            //{
            //    Rpt_Student frm_Exam = new Rpt_Student();
            //    try
            //    {
            //        frm_Exam.str = "AdmissionNo";
            //        frm_Exam.searching_value = Param.ToString();
            //    }
            //    catch (Exception)
            //    {


            //    }
            //    frm_Exam.Show();
            //}
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FrmBank frmbank = new FrmBank();
            frmbank.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
           
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  statusBar1.Visible = statusBarToolStripMenuItem.Checked;
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

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQstudent frm_Qstudent = new frmQstudent();
            frm_Qstudent.ShowDialog();
        }

       
        private void employeeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQaEmp frm_QaEmp = new frmQaEmp();
            frm_QaEmp.ShowDialog();
        }

        private void markAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Old Form 
            //FrmMark_attnd frm_AttStu = new FrmMark_attnd();
            //Frmattnd frm_AttStu = new Frmattnd();
           // frm_AttStu.Show();   



        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Frmfee_head frm_feehead = new Frmfee_head();
            frm_feehead.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_generatefee frmfeegen = new Frm_generatefee();
            frmfeegen.Show();
        }

        private void studentFeeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_FeeEntry frnfeeebtrt = new Frm_FeeEntry();
            frnfeeebtrt.ShowDialog();
        }

        private void studentFineEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFine frmfine = new FrmFine();
            frmfine.Show();
        }

        private void printStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Student_Report frm = new Frm_Student_Report();
            frm.MdiParent = this;
            frm.Show();
            
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Frmattnd_Reprot childForm = new Frmattnd_Reprot();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmQexp frm = new frmQexp();
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //FrmFeeClass frm = new FrmFeeClass();
            frmclasswisefeesetup frm = new frmclasswisefeesetup();
            frm.Show();
        }

        private void expenseEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQexpD exp = new frmQexpD();
            exp.ShowDialog();
        }

        private void EmpSetup_Click(object sender, EventArgs e)
        {
            frmQemployee frm = new frmQemployee();
            frm.ShowDialog();
        }

        private void Session_Click(object sender, EventArgs e)
        {
            FrmSession frm = new FrmSession();
            frm.MdiParent = this;
            frm.Show();
            //frm.ShowDialog();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //FrmMark_attnd frm_AttStu = new FrmMark_attnd();
            //frm_AttStu.Show();   
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void expenseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptExpense frm = new rptExpense();
            frm.ShowDialog();
        }

        private void studentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Student_Report frm_feehead = new Frm_Student_Report();
            frm_feehead.ShowDialog();
        }

        private void attendanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmattnd_Reprot childForm = new Frmattnd_Reprot();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
             string Param = Microsoft.VisualBasic.Interaction.InputBox("Enter Admission No for Print Student Record ", "TechnoSpyre Inc", string.Empty, 100, 100);
             if (!Param.Trim().Equals(""))
             {
                 Rpt_Student frm_Exam = new Rpt_Student();
                 try
                 {
                     frm_Exam.str = "AdmissionNo";
                     frm_Exam.searching_value = Param.ToString();
                 }
                 catch (Exception)
                 {


                 }
                 frm_Exam.Show();
             }
        }

        
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            frmQstudent frm_Qstudent = new frmQstudent();
            frm_Qstudent.ShowDialog();
        }

        private void Master_Load(object sender, EventArgs e)
        {
            statusBar1.Panels[0].Text = statusBar1.Panels[0].Text + "Administrator";
            statusBar1.Panels[1].Text = statusBar1.Panels[1].Text + DateTime.Now.ToLongDateString();
        
        }
        
        private void btnContact_Click(object sender, EventArgs e)
        {

        }

        private void toolSelectedItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FrmVoucherPr vouh = new FrmVoucherPr();
            vouh.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FrmOutstanding frm = new FrmOutstanding();
            frm.ShowDialog();
        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void Setup_Click(object sender, EventArgs e)
        {

        }

        private void outstandingStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOutstanding frm = new FrmOutstanding();
            frm.ShowDialog();
        }

        private void classWiseOutstandingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClasswiseOutstnd frm = new FrmClasswiseOutstnd();
            frm.ShowDialog();
        }

        private void classWiseFeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClasswisefee frm = new FrmClasswisefee();
            frm.ShowDialog();
        }

        private void feeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void classWiseFeeHeadReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFeeHeadWIse frm = new FrmFeeHeadWIse();
            frm.ShowDialog();
        }

        private void studentLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLedger frm = new FrmLedger();
            frm.ShowDialog();
        }

        private void unpaidVouchersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUnpaidVoucher frm = new FrmUnpaidVoucher();
            frm.ShowDialog();
        }

        private void classFeeGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_generatefee frmfeegen = new Frm_generatefee();
            frmfeegen.Show();
        }

        private void singleStudentFeeGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frmsinglestudentfee frmfeegen = new Frmsinglestudentfee();
            frmfeegen.Show();
        }

        private void voucherReversalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void deleteVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeleteVoucher frmdel = new frmDeleteVoucher();
            frmdel.Show();
        }

        private void deActivateStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeactivateStudent frmdec = new frmDeactivateStudent();
            frmdec.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmshift fm = new frmshift();
            fm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmbranch frm = new frmbranch();
            frm.Show();
        }
        
    }
}
