using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class frmsearch : Form
    {
        public frmsearch()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Searchby_admno()
        {

            if (rdobyadmission.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,ADMISSION_NO,s_name,c_name,address,contact_no,f_name,age,d_birth,sex,SessionName from view_student where active='true' and  ADMISSION_NO like'%" + this.txtsadmissionno.Text.Trim() + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)", this.lstv_Student);
            }

        }
        public void Searchby_name()
        {

            if (rdobyname.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,ADMISSION_NO,s_name,c_name,address,contact_no,f_name,age,d_birth,sex,SessionName from view_student where active='true' and  s_name like'%" + this.txtbyname.Text.Trim() + "%'  and branch_id='" + SYSTEMSETTING.branch_ID + "'  ORDER BY (ADMISSION_NO)", this.lstv_Student);
            
            }

        }
        private void rdobyname_Click(object sender, EventArgs e)
        {
            //Searchby_name();
        }

        private void rdobyadmission_Click(object sender, EventArgs e)
        {
         //   Searchby_admno();
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if (rdobyadmission.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,ADMISSION_NO,s_name,c_name,address,contact_no,f_name,age,d_birth,sex,SessionName from view_student where active='true' and  ADMISSION_NO like'%" + this.txtsadmissionno.Text.Trim() + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)", this.lstv_Student);
            }
            else if (rdobyname.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,ADMISSION_NO,s_name,c_name,address,contact_no,f_name,age,d_birth,sex,SessionName from view_student where active='true' and  s_name like'%" + this.txtbyname.Text.Trim() + "%'  and branch_id='" + SYSTEMSETTING.branch_ID + "'  ORDER BY (ADMISSION_NO)", this.lstv_Student);

            }
        }

        private void lstv_Student_DoubleClick(object sender, EventArgs e)
        {
            if (lstv_Student.SelectedItems.Count > 0)
            {
                _forms.frmStudent frm_Student = new frmStudent();
                frm_Student.str = "Modifying";
                frm_Student.studentid = this.lstv_Student.Items[lstv_Student.FocusedItem.Index].SubItems[0].Text.Trim();

                frm_Student.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }
    }
}
