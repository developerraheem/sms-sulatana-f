using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class PrntFeeHeadWise : Form
    {
        public PrntFeeHeadWise()
        {
            InitializeComponent();
        }
        public string mont = "";
        private void PrntFeeHeadWise_Load(object sender, EventArgs e)
        {
            
            try
            {
                this.vIEW_CLASS_MONTH_HEAD_WISETableAdapter.FillBy(this.report_dataset.VIEW_CLASS_MONTH_HEAD_WISE, mont.ToString());
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();

        }

       
        
    }
}
