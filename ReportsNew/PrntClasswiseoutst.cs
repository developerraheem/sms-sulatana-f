using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace School._forms
{
    public partial class PrntClasswiseoutst : Form
    {
        public PrntClasswiseoutst()
        {
            InitializeComponent();
        }
        public string month = "";
        
        private void PrntClasswiseoutst_Load(object sender, EventArgs e)
        {
            
           

            try
            {
                //this.month_wise_fee_statusTableAdapter.FillByMonth(this.report_DataSet_new.Month_wise_fee_status, month);
                this.monthlyFeeTableAdapter.FillByMonth(this.report_DataSet_new.MonthlyFee, month,Convert.ToDecimal(SYSTEMSETTING.sessionid));
                //this.month_wise_fee_statusTableAdapter.Fill(this.report_DataSet_new.Month_wise_fee_status);
                this.reportViewer1.RefreshReport();        
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        
        }

        
        
        

       
    }
}
