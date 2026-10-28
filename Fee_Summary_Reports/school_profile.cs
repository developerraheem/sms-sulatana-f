using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.Fee_Summary_Reports
{
    public partial class school_profile : Form
    {
        public school_profile()
        {
            InitializeComponent();
        }

        private void school_profile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.fEE_ACCORDING_STRENGHTTableAdapter.FillBy(this.dataSet_Fee_Summary_Reports.FEE_ACCORDING_STRENGHT, dpAe.Text);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
