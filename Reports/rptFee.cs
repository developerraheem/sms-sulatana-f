using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class rptFee : Form
    {
        public rptFee()
        {
            InitializeComponent();
        }
        private Frm_FeeEntry mainForm = null;
          public rptFee(Form callingForm)
        {
            mainForm = callingForm as Frm_FeeEntry; 
            InitializeComponent();
        }
       

        private void rptFee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'report_dataset.Temp' table. You can move, or remove it, as needed.
          //  this.tempTableAdapter.Fill(this.report_dataset.Temp);

            txtclassid.Text = this.mainForm.Class_ID.ToString();
           // txtmonth.Text = this.mainForm.FeeMonth.ToString();
            txtrollno.Text = this.mainForm.RollNo.ToString();

            try
            {
                this.fee_VoucherTableAdapter.FillBy(this.report_dataset.Fee_Voucher, txtmonth.Text, txtclassid.Text, txtrollno.Text);
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        //    this.reportViewer1.RefreshReport();
           
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            

        }


        

        

       

       
       

       
    }
}
