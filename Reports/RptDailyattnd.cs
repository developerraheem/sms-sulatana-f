using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.Reports
{
    public partial class RptDailyattnd : Form
    {
        public RptDailyattnd()
        {
            InitializeComponent();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //this.daily_attndTableAdapter.FillBy(this.report_dataset.daily_attnd, c_idToolStripTextBox.Text, att_dateToolStripTextBox.Text);
                //this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void RptDailyattnd_Load(object sender, EventArgs e)
        {
           
        }
    }
}
