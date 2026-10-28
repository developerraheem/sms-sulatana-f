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
    public partial class rpt_attedance_monthwise : Form
    {
        public rpt_attedance_monthwise()
        {
            InitializeComponent();
        }

        public string SESSION = "";
        public string SHIFT = "";
        public string SECTION = "";
        public string MONTH = "0";
        public string CLASS = "0";

        private void rpt_class_wise_attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'attendance_ds.Class_wise_attendance' table. You can move, or remove it, as needed.
           // this.class_wise_attendanceTableAdapter.Fill(this.attendance_ds.Class_wise_attendance);

            this.class_wise_attendanceTableAdapter.FillBy(this.attendance_ds.Class_wise_attendance, SHIFT, SECTION.Trim(), MONTH, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(CLASS, typeof(decimal))))), new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(SESSION, typeof(decimal))))));
            ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
            this.reportViewer1.LocalReport.SetParameters(rpm);
            this.reportViewer1.RefreshReport();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
