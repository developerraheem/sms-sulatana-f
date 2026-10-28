using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class FrmClasswisefee : Form
    {
        public FrmClasswisefee()
        {
            InitializeComponent();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrntClasswisefee prnt = new PrntClasswisefee();
            prnt.month = txtmonth.Text;
            prnt.Show();

        }
    }
}
