using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace School.Attendance_module
{
    public partial class award_list : Form
    {
        public award_list()
        {
            InitializeComponent();
        }
        public string SECTION_ID = "";
        public string SUBJECT_ID = "0";
        public string CLASS_ID = "0";
        public string TEACHER_NAME = "";

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            
            

        }

        private void award_list_Load(object sender, EventArgs e)
        {
            try
            {
                this.award_ListTableAdapter.FillBy(this.dataSet1.Award_List, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(CLASS_ID, typeof(decimal))))), ((decimal)(System.Convert.ChangeType(SYSTEMSETTING.branch_ID, typeof(decimal)))), SYSTEMSETTING.sessionid, SECTION_ID, Convert.ToDecimal(SUBJECT_ID));
                ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                ReportParameter rpm1 = new ReportParameter("teachername", TEACHER_NAME.ToString());
                
                this.reportViewer1.LocalReport.SetParameters(rpm);
                this.reportViewer1.LocalReport.SetParameters(rpm1);
                this.reportViewer1.RefreshReport();

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
