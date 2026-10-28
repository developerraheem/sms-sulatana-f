using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace GL_SCHOOL
{
    public partial class FrmAcc_Main : Form
    {
        public FrmAcc_Main()
        {
            InitializeComponent();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
          
          //  StripProcess.Visible = false;
            picSetup.Visible = true;
            picProcess.Visible = false;
            picReports.Visible = false;
            mnusetup.Visible = true; 
            mnuReprots.Visible = false;
           
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            mnusetup.Visible = false ;
            mnuReprots.Visible = true;
            picSetup.Visible = false;
            picProcess.Visible = true;
            //StripProcess.Visible = true;
            picReports.Visible = false;
           
        }

        private void FrmAcc_Main_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            FrmMainGroup frm = new FrmMainGroup();
            frm.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            FrmSubGroup frm = new FrmSubGroup();
            frm.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            FrmChartofAccounts frm = new FrmChartofAccounts();
            frm.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            FrmVoucherTypes frm = new FrmVoucherTypes();
            frm.ShowDialog();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
               // Application.Exit();
                this.Close();
            }
            else
            {
                return;
            }

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            //FrmVoucherEntry frm = new FrmVoucherEntry();
            //frm.ShowDialog();
        }

        private void chartOfAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.Form1 frm = new Reports.Form1();
            frm.Show();
        }

        private void generalLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.GENERAL_LEDGER frm = new Reports.GENERAL_LEDGER();
            frm.Show();
        }

        private void voucherEnquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVouchers frm = new FrmVouchers();
            frm.Show();
        }
    }
}
