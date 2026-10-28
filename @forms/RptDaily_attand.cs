using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class RptDaily_attand : Form
    {
        public RptDaily_attand()
        {
            InitializeComponent();
        }
         private FrmMark_attnd mainForm = null;
          public RptDaily_attand(Form callingForm)
        {
            mainForm = callingForm as FrmMark_attnd; 
            InitializeComponent();
        }
      

        private void RptDaily_attand_Load(object sender, EventArgs e)
        {
            txtclassid.Text = this.mainForm.Classid.ToString();
            txtdate.Text = this.mainForm.Date.ToString();
            try
            {
                this.daily_attndTableAdapter.FillBy1(this.report_dataset.daily_attnd, txtclassid.Text, txtdate.Text);
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
