using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace School._forms
{
    public partial class Frmfind_student : Form
    {
        public Frmfind_student()
        {
            InitializeComponent();
        }
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        public string param = "";
        public string Classid = "";
        public string Shift = "";
        public string SectionID = "";

        private FrmFine mainForm = null;
        private Frm_generatefee frmgeneratefee = null;
        private Frm_generatefee_multi frmgeneratefeeMulti = null;
        private FrmVoucherPr fmrvoucher = null;
        private FrmUnpaidVoucher fmrvoucherlist = null;
        private FrmLedger frmledger = null;
        private frmDeactivateStudent frmDeactivate = null;
        private SLC FRMSLC = null;


        public Frmfind_student(Form callingForm)
        {
            mainForm = callingForm as FrmFine;
            frmgeneratefee = callingForm as Frm_generatefee;
            frmgeneratefeeMulti = callingForm as Frm_generatefee_multi;
            fmrvoucher = callingForm as FrmVoucherPr;
            fmrvoucherlist = callingForm as FrmUnpaidVoucher;
            frmledger = callingForm as FrmLedger;
            frmDeactivate = callingForm as frmDeactivateStudent;
            FRMSLC = callingForm as SLC;

            InitializeComponent();
        }

        private void Frmfind_student_Load(object sender, EventArgs e)
        {
            try
            {
                //txtclassid.Text = this.mainForm.Class_ID.ToString();
                Load_students();
            }
            catch (Exception exp)
            {

            }
        }
        private void Load_students()
        {
            try
            {
                int parsedCid;
                string cidFilter = int.TryParse(Classid, out parsedCid) ? " and c_id='" + parsedCid + "'" : "";
                string shiftFilter = !string.IsNullOrEmpty(Shift) ? " and SHIFT='" + Shift.ToString() + "'" : "";
                string secFilter = !string.IsNullOrEmpty(SectionID) ? " and SECTION_ID='" + SectionID + "'" : "";
                string QUERY = "Select s_id,ADMISSION_NO,s_name,f_name,TYPE,SECTION_ID FROM student where active='true'" + cidFilter + shiftFilter + secFilter + " AND SessionID='" + SYSTEMSETTING.sessionid + "' and  branch_id='" + SYSTEMSETTING.branch_ID + "' order by SECTION_ID";
                SYS.Filllist_DataView(QUERY, this.lst_std);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {
            }
        }



        private void getvalue()
        {
            if (param == "FeeGenerate")
            {
                if (lst_std.SelectedItems.Count > 0)
                {
                    frmgeneratefee.Student_ID = this.lst_std.Items[lst_std.FocusedItem.Index].SubItems[0].Text.Trim();
                    this.Close();
                }
            }
            else if (param == "FeeGenerateMulti")
            {
                if (lst_std.SelectedItems.Count > 0)
                {
                    frmgeneratefeeMulti.Student_ID = this.lst_std.Items[lst_std.FocusedItem.Index].SubItems[0].Text.Trim();
                    this.Close();
                }
            }
            else if (param == "Fine")
            {
                mainForm.Student_ID = this.lst_std.Items[lst_std.FocusedItem.Index].SubItems[0].Text.Trim();
                mainForm.Student_Name = this.lst_std.Items[lst_std.FocusedItem.Index].SubItems[2].Text.Trim();
                this.Close();
            }
            else if (param == "VoucherPrint")
            {
                fmrvoucher.Student_ID = this.lst_std.Items[lst_std.FocusedItem.Index].SubItems[0].Text.Trim();
                this.Close();
            }
            else if (param == "Voucherlist")
            {
                fmrvoucherlist.Student_ID = this.lst_std.Items[lst_std.FocusedItem.Index].SubItems[0].Text.Trim();
                this.Close();
            }
            else if (param == "StudentLedger")
            {
                frmledger.Student_ID = this.lst_std.Items[lst_std.FocusedItem.Index].SubItems[0].Text.Trim();
                this.Close();
            }
            else if (param == "De-Active")
            {
                frmDeactivate.Student_ID = this.lst_std.Items[lst_std.FocusedItem.Index].SubItems[0].Text.Trim();
                this.Close();
            }
            else if (param == "SLC")
            {
                FRMSLC.Student_ID = this.lst_std.Items[lst_std.FocusedItem.Index].SubItems[0].Text.Trim();
                this.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                int parsedCid;
                string cidFilter = int.TryParse(Classid, out parsedCid) ? " and c_id='" + parsedCid + "'" : "";
                string shiftFilter = !string.IsNullOrEmpty(Shift) ? " and SHIFT='" + Shift.ToString() + "'" : "";
                string secFilter = !string.IsNullOrEmpty(SectionID) ? " and SECTION_ID='" + SectionID + "'" : "";
                string term = textBox1.Text.Trim().Replace("'", "''");
                SYS.Filllist_DataView("Select s_id,ADMISSION_NO,s_name,f_name,TYPE,SECTION_ID FROM student where active='true'" + cidFilter + shiftFilter + secFilter + " and (s_name like '%" + term + "%' or ADMISSION_NO like '%" + term + "%' or s_id like '%" + term + "%') AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' order by SECTION_ID", this.lst_std);
            }
            else
            {
                Load_students();
            }
        }

        private void lst_std_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            getvalue();
        }

        private void lst_std_KeyPress(object sender, KeyPressEventArgs e)
        {
            getvalue();
        }


    }
}
