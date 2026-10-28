using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class MDI_MAIN : Form
    {
        public MDI_MAIN()
        {
            InitializeComponent();
            this.Text = "School & College Management System |" + SYSTEMSETTING.schoolname;
            lblschoolname.Text = SYSTEMSETTING.schoolname;
        }

        private void MDI_MAIN_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStudent frm = new frmStudent();
            frm.ShowDialog();
        }

        private void manageStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_manage_students frm = new frm_manage_students();
            frm.Show();
        }
    }
}
