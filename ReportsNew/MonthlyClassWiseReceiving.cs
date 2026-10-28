using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.ReportsNew
{
    public partial class MonthlyClassWiseReceiving : Form
    {
        public string feemonth = "";
        public MonthlyClassWiseReceiving()
        {
            InitializeComponent();
        }

        private void MonthlyClassWiseReceiving_Load(object sender, EventArgs e)
        {
            
            this.monthWiseFeeReceivingTableAdapter.Fill(this.student_DataSet.MonthWiseFeeReceiving,feemonth,Convert.ToDecimal(SYSTEMSETTING.sessionid));
            reportViewer1.RefreshReport();

        }
    }
}
