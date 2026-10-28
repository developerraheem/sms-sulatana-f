using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.ReportsNew
{
    public partial class MonthlyClassWiseReceiving_param : Form
    {
        public MonthlyClassWiseReceiving_param()
        {
            InitializeComponent();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            MonthlyClassWiseReceiving frm = new MonthlyClassWiseReceiving();
            frm.feemonth = txtfeemonth.Text;
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
