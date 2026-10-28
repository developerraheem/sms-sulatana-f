using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class FrmUnpaidVoucher : Form
    {
        public FrmUnpaidVoucher()
        {
            InitializeComponent();
        }

        SYSTEMSETTING SYS = new SYSTEMSETTING();

        private void FrmUnpaidVoucher_Load(object sender, EventArgs e)
        {
            SYS.comboFill(this.cmbclass, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT] FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbsection, "select SECTION_NAME from sections where branch_id='" + SYSTEMSETTING.branch_ID + "'", "sections", "SECTION_NAME", "SECTION_NAME");
            SYS.comboFill(this.cmbsession, "select * from [Sessions] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sessions", "SessionName", "SessionID");
            cmbsession.SelectedValue = SYSTEMSETTING.sessionid.ToString();
            ThemeHelper.ApplyTheme(this);
        }

        private void cmbclass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtmonth.Focus();

            }
        }

        private void txtmonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnprint.Focus();

            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

            if (cmbtype.Text == "All")
            {
                VoucherslistReport frm = new VoucherslistReport();
                frm.param = "All";
                frm.month = txtmonth.Text;
                frm.classid = cmbclass.SelectedValue.ToString();
                frm.SHIFTID = cmbshift.SelectedValue.ToString();
                frm.section = cmbsection.SelectedValue.ToString();
                frm.sessionid = cmbsession.SelectedValue.ToString();
                frm.Show();

            }
            else if (cmbtype.Text == "Un-Posted Vouchers")
            {
                VoucherslistReport frm = new VoucherslistReport();
                frm.param = "Unpaid";
                frm.month = txtmonth.Text;
                frm.classid = cmbclass.SelectedValue.ToString();
                frm.SHIFTID = cmbshift.SelectedValue.ToString();
                frm.section = cmbsection.SelectedValue.ToString();
                frm.sessionid = cmbsession.SelectedValue.ToString();
                frm.Show();
            }
            else if (cmbtype.Text == "Posted Vouchers")
            {

                VoucherslistReport frm = new VoucherslistReport();
                frm.param = "paid";
                frm.month = txtmonth.Text;
                frm.classid = cmbclass.SelectedValue.ToString();
                frm.SHIFTID = cmbshift.SelectedValue.ToString();
                frm.section = cmbsection.SelectedValue.ToString();
                frm.sessionid = cmbsession.SelectedValue.ToString();
                frm.Show();

            }
            else if (cmbtype.Text == "Student Wise Voucher List")
            {
                VoucherslistReport frm = new VoucherslistReport();
                frm.param = "Studentwise";
                frm.month = txtmonth.Text;
                frm.classid = cmbclass.SelectedValue.ToString();
                frm.SHIFTID = cmbshift.SelectedValue.ToString();
                frm.section = cmbsection.SelectedValue.ToString();
                frm.sessionid = cmbsession.SelectedValue.ToString();
                frm.stdid = txtadmNo.Text;
                frm.Show();
            }
            else if (cmbtype.Text == "Defaulter Student List")
            {

            }
            else if (cmbtype.Text == "")
            {

            }
            else
            {
                SYS.setMessageBox("Invalid Type Selected", 3);
            }

        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        public string Student_ID
        {
            get { return txtadmNo.Text; }
            set { txtadmNo.Text = value; }
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            if (cmbtype.Text == "Student Wise Voucher List")
            {
                Frmfind_student frm = new Frmfind_student(this);
                frm.param = "Voucherlist";
                frm.Classid = cmbclass.SelectedValue.ToString();
                frm.Shift = cmbshift.SelectedValue.ToString();
                
                frm.ShowDialog();
            }
            else
            {
                SYS.setMessageBox("Invalid Report Type",3);
                cmbtype.Focus();
            }
        }
    }
}
