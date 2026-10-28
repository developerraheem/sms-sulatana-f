using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.ReportsNew
{
    public partial class DefaulterStudents : Form
    {
        public DefaulterStudents()
        {
            InitializeComponent();
        }
        public string feemonth = "";


        private void DefaulterStudents_Load(object sender, EventArgs e)
        {
            try
            {
                this.fEE_HISTORYTableAdapter.FillBy(this.report_DataSet_new.FEE_HISTORY, feemonth, Convert.ToDecimal(SYSTEMSETTING.sessionid));
                this.reportViewer1.RefreshReport();   
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
