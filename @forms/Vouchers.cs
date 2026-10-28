using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class Vouchers : Form
    {
        public Vouchers()
        {
            InitializeComponent();
        }

        private void Vouchers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'report_dataset.Voucher' table. You can move, or remove it, as needed.
            this.voucherTableAdapter.Fill(this.report_dataset.Voucher);
            this.reportViewer1.RefreshReport();
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //this.voucherTableAdapter.FillBy1(this.report_dataset.Voucher, fEE_MASTER_IDToolStripTextBox.Text,Convert.ToDecimal(SYSTEMSETTING.sessionid));
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

       

     
    }
}
