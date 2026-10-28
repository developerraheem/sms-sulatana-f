using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.Fee_Summary_Reports
{
    public partial class BARCODETESTING : Form
    {
        public string sessionid = "";
        public string feemonth = "";
        public string classfrom = "";
        public string classto = "";

        public BARCODETESTING()
        {
            InitializeComponent();
        }

       

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void BARCODETESTING_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet_Fee_Summary_Reports.BARCODES' table. You can move, or remove it, as needed.
            this.bARCODESTableAdapter.Fill(this.dataSet_Fee_Summary_Reports.BARCODES);
            this.reportViewer1.RefreshReport();
        }

        
    }
}
