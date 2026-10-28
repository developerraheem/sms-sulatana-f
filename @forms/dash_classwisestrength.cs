using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class dash_classwisestrength : Form
    {
        DataSet rs = new DataSet();
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        public string classid = "";

        public dash_classwisestrength()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void dash_classwisestrength_Load(object sender, EventArgs e)
        {
            Fill_grid_outstanding();
            Fill_Students();
        }
        public void Fill_grid_outstanding()
        {
            string query = "";
            query = "select f.FEE_MASTER_ID,s.s_name,f.FEE_MONTH,f.REC_AMOUNT,f.RECEIVABLE_AMOUNT,f.BALANCE,f.ISSUE_DATE,";
            query = query + " f.SUBMIT_DATE from FEE_MASTER f, student s, class c";
            query = query + " where f.branch_id='" + SYSTEMSETTING.branch_ID + "' and f.SessionID='" + SYSTEMSETTING.sessionid + "' and f.C_ID='" + classid + "' and f.s_id= s.s_id and f.branch_id=s.branch_id and f.C_ID=c.c_id and f.branch_id=c.branch_id ORDER BY f.FEE_MASTER_ID";
            SYS.Filllist_DataView(query, this.lstv_outstandingfee);
        }

        public void Fill_Students()
        {
            string query = "";
            query = "select s_id,ADMISSION_NO,ADMISSION_DATE,s_name,f_name,sex,contact_no,SECTION_ID from student where SessionID='" + SYSTEMSETTING.sessionid + "' and c_id='" + classid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
            SYS.Filllist_DataView(query, this.lst_students);
        }

        private void lstv_outstandingfee_DoubleClick(object sender, EventArgs e)
        {

            if (lstv_outstandingfee.SelectedItems.Count > 0)
            {
                Frm_Vouchers_multi frm = new Frm_Vouchers_multi();
                frm.param = "voucherno";
                frm.voucherno = this.lstv_outstandingfee.Items[lstv_outstandingfee.FocusedItem.Index].SubItems[0].Text.Trim();
                frm.Show();


            }
            else
            {
                MessageBox.Show("Please Select Record");
            }

        }

        private void lst_students_DoubleClick(object sender, EventArgs e)
        {
            if (lst_students.SelectedItems.Count > 0)
            {
                dash_stdlist frm = new dash_stdlist();
                frm.STUDENT_ID = this.lst_students.Items[lst_students.FocusedItem.Index].SubItems[0].Text.Trim();
                frm.CLASS_ID = classid;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtsearch_voucherlist_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            query = "select f.FEE_MASTER_ID,s.s_name,f.FEE_MONTH,f.REC_AMOUNT,f.RECEIVABLE_AMOUNT,f.BALANCE,f.ISSUE_DATE,";
            query = query + " f.SUBMIT_DATE from FEE_MASTER f, student s, class c";
            query = query + " where f.branch_id='" + SYSTEMSETTING.branch_ID + "' and f.SessionID='" + SYSTEMSETTING.sessionid + "' and f.C_ID='" + classid + "' and s.s_name like '%" + txtsearch_voucherlist.Text + "%' and f.s_id= s.s_id and f.branch_id=s.branch_id and f.C_ID=c.c_id and f.branch_id=c.branch_id ORDER BY f.FEE_MASTER_ID";
            SYS.Filllist_DataView(query, this.lstv_outstandingfee);
        }

        private void txtsearch_stdlist_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            query = "select s_id,ADMISSION_NO,ADMISSION_DATE,s_name,f_name,sex,contact_no,SECTION_ID from student where  s_name like '%" + txtsearch_stdlist.Text + "%' and SessionID='" + SYSTEMSETTING.sessionid + "' and c_id='" + classid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
            SYS.Filllist_DataView(query, this.lst_students);
        }
    }
}
