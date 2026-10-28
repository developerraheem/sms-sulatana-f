using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class frmschool_setup : Form
    {
        public frmschool_setup()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {

        }
    }
}
