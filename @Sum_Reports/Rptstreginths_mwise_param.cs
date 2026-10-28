using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._Sum_Reports
{
    public partial class Rptstreginths_mwise_param : Form
    {
        public Rptstreginths_mwise_param()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        private void Rptstreginths_mwise_param_Load(object sender, EventArgs e)
        {

            SYS.comboFill(this.cmbclass, "select * from class  where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT] FROM [SHIFT]  where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbsection, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
            
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            rptstreginths_mwisee rpt = new rptstreginths_mwisee();
            rpt.classid = cmbclass.SelectedValue.ToString();
            rpt.shift = cmbshift.SelectedValue.ToString();
            rpt.feemonth = txtmonth.Text;
            rpt.sectionid = cmbsection.SelectedValue.ToString();
            rpt.sessionid = SYSTEMSETTING.sessionid;
            rpt.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
