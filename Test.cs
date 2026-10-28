using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _forms.Frm_editfee frm = new _forms.Frm_editfee();
           // frm.MdiParent = this;
            frm.Show();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
                //this.Close();
            }
            else
            {
                return;
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }
    }
}
