using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class rptExpense : Form
    {
        public rptExpense()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RptExpReport frm = new RptExpReport();
            try
            {
                frm.dto = dto.Text;
                frm.dfrom = dfrom.Text;
                
            }
            catch (Exception)
            {


            }

            frm.Show();
        }

        private void rptExpense_Load(object sender, EventArgs e)
        {

        }
    }
}
