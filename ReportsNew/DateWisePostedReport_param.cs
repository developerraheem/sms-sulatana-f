using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.ReportsNew
{
    public partial class DateWisePostedReport_param : Form
    {
        public DateWisePostedReport_param()
        {
            InitializeComponent();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            DateWisePostedReport frm = new DateWisePostedReport();
            frm.datefrom = txtfromdate.Text;
            frm.dateto = txtdateto.Text;
            if (txtscrollno.Text.Length > 0)
            {
                frm.scrollno = txtscrollno.Text;
            }
            frm.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DefaulterStudents_monthselection_Load(object sender, EventArgs e)
        {

        }
    }
}
