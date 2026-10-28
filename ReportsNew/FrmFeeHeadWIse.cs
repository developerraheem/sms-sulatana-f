using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class FrmFeeHeadWIse : Form
    {
        public FrmFeeHeadWIse()
        {
            InitializeComponent();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrntClasswiseoutst prnt = new PrntClasswiseoutst();
            prnt.month = txtmonth.Text;
            prnt.Show();

        }
    }
}
