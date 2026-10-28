using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class VoucherslistReport : Form
    {
        public VoucherslistReport()
        {
            InitializeComponent();
        }

        public string month = "";
        public string stdid = "";
        public string classid = "";
        public string SHIFTID = "";
        public string section = "";
        public string param = "";
        public string sessionid = SYSTEMSETTING.sessionid;
        public string all_classwise = "0";


        private void ClasswiseStregnthReport_Load(object sender, EventArgs e)
        {
            try
            {
                if (param == "All")
                {
                   
                    
                    if (all_classwise == "0")
                    {
                      //  this.fEE_HISTORYTableAdapter.FillBy1_ALLL(this.report_DataSet_new.FEE_HISTORY, ((decimal)(System.Convert.ChangeType(sessionid, typeof(decimal)))));
                        this.fEE_HISTORYTableAdapter.Fill(this.report_DataSet_new.FEE_HISTORY, classid, SHIFTID, month, Convert.ToDecimal(sessionid));
                    }
                    else
                    {
                      //  this.fEE_HISTORYTableAdapter.FillBy1_ALLL(this.report_DataSet_new.FEE_HISTORY, ((decimal)(System.Convert.ChangeType(sessionid, typeof(decimal)))));
                        this.fEE_HISTORYTableAdapter.Fill(this.report_DataSet_new.FEE_HISTORY, classid, SHIFTID, month, Convert.ToDecimal(sessionid));
                    }
    

                }
                else if (param == "Unpaid")
                {
                    this.fEE_HISTORYTableAdapter.Unpaid(this.report_DataSet_new.FEE_HISTORY, classid, SHIFTID, month, section, Convert.ToDecimal(sessionid));
                }
                else if (param == "paid")
                {
                    this.fEE_HISTORYTableAdapter.Paid(this.report_DataSet_new.FEE_HISTORY, classid, SHIFTID, month, Convert.ToDecimal(sessionid));
                }
                else if (param == "Studentwise")
                {
                    this.fEE_HISTORYTableAdapter.StudentWiseList(this.report_DataSet_new.FEE_HISTORY, Convert.ToDecimal(stdid), Convert.ToDecimal(sessionid));
                }

                this.reportViewer1.RefreshReport();

            }
            catch (Exception)
            {
                
                
            }
            
        }

        private void studentWiseListToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

       

     

       

       

       
    }
}
