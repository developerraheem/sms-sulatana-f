using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._dashboad_forms
{
    public partial class frm_dash_FEEHEAD : Form
    {
        public frm_dash_FEEHEAD()
        {
            InitializeComponent();
        }
        public string BRANCHID;
        public string CLASSID;
        private void frm_dash_sections_Load(object sender, EventArgs e)
        {
            try
            {
                this.fEE_HEADTableAdapter.FillBy(this.dashboard.FEE_HEAD, ((decimal)(System.Convert.ChangeType(BRANCHID, typeof(decimal)))), new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(CLASSID, typeof(decimal))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            

        }

       
    }
}
