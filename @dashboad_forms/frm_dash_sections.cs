using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._dashboad_forms
{
    public partial class frm_dash_sections : Form
    {
        public frm_dash_sections()
        {
            InitializeComponent();
        }
        public string BRANCHID;
        private void frm_dash_sections_Load(object sender, EventArgs e)
        {
            try
            {
                this.sectionsTableAdapter.FillBy(this.dashboard.Sections, ((decimal)(System.Convert.ChangeType(BRANCHID, typeof(decimal)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

       
    }
}
