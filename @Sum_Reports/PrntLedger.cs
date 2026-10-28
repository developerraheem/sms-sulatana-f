using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class PrntLedger : Form
    {
        public PrntLedger()
        {
            InitializeComponent();
        }
        public string dateto = "";
        public string datefrom = "";
        public string admissionno = "";
        private void PrntLedger_Load(object sender, EventArgs e)
        {
            try
            {
                this.student_LedgerTableAdapter.FillBy(this.report_dataset.Student_Ledger, dateto.ToString(), datefrom.ToString(), admissionno.ToString());
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            this.reportViewer1.RefreshReport();
        }

        
    }
}
