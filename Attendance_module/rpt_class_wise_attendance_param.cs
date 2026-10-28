using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.Attendance_module
{
    public partial class rpt_class_wise_attendance_param : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        public rpt_class_wise_attendance_param()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void frmclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rpt_class_wise_attendance_param_Load(object sender, EventArgs e)
        {
            this.SYS.comboFill(this.cmbclassfrom, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbsectionfrom, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT] from SHIFT where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
        }

        private void cmbclassfrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SYS.comboFill(this.cmbsectionfrom, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            rpt_class_wise_attendance rpt = new rpt_class_wise_attendance();
            rpt.CLASS = cmbclassfrom.SelectedValue.ToString();
            rpt.SECTION = cmbsectionfrom.SelectedValue.ToString();
            rpt.SESSION = SYSTEMSETTING.sessionid.ToString();
            rpt.MONTH = txtfeemonth.Text;
            rpt.SHIFT = cmbshift.SelectedValue.ToString();
            rpt.Show();
        }
    }
}
