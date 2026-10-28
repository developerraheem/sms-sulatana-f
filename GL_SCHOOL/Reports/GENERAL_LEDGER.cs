using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GL_SCHOOL.Reports
{
    public partial class GENERAL_LEDGER : Form
    {
        public GENERAL_LEDGER()
        {
            InitializeComponent();
        }

        private void GENERAL_LEDGER_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.GENERAL_LEDGER' table. You can move, or remove it, as needed.
            this.gENERAL_LEDGERTableAdapter.Fill(this.dataSet1.GENERAL_LEDGER);
            this.reportViewer1.RefreshReport();

        }
    }
}
