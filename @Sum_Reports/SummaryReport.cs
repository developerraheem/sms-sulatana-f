using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class SummaryReport : Form
    {
        public SummaryReport()
        {
            InitializeComponent();
        }
        public string str = "";
        public string class_id = "";
        public string searching_value = "";
        public string sessionid = "";
        private void Rpt_Student_Load(object sender, EventArgs e)
        {
            //this.vIEW_CLASS_MONTH_HEAD_WISETableAdapter.Fill(this.student_DataSet.VIEW_CLASS_MONTH_HEAD_WISE,SYSTEMSETTING.sessionid);
            this.sUMMARY_REPORTTableAdapter.FillBy(this.student_DataSet.SUMMARY_REPORT, SYSTEMSETTING.sessionid);


            this.reportViewer1.RefreshReport();


        }

       
    }
}
