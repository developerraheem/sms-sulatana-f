using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace School._forms
{
    public partial class FrmClasswiseOutstnd : Form
    {
        public FrmClasswiseOutstnd()
        {
            InitializeComponent();
        }
        _class.clsODBC cls_Con = new School._class.clsODBC();
      
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        private void FrmClasswiseOutstnd_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyTheme(this);
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrntClasswiseoutst prnt = new PrntClasswiseoutst();
            prnt.month = txtmonth.Text;
            prnt.Show();
        }
    }
}
