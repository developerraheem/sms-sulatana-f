using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class PrntClasswisefee : Form
    {
        public PrntClasswisefee()
        {
            InitializeComponent();
        }

        public string month = "";
        private void RptClasswisefee_Load(object sender, EventArgs e)
        {
            try
            {
                this.vIEW_FEE_CLASS_WISETableAdapter.FillBy(this.report_dataset.VIEW_FEE_CLASS_WISE, month.ToString());
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            

        }
    }
}
