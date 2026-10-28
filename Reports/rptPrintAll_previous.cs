using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.Reports
{
    public partial class rptPrintAll_previous : Form
    {
        public rptPrintAll_previous()
        {
            InitializeComponent();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void rptPrintAll_previous_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'attendance_ds.ATTEND_SUB_REPORT' table. You can move, or remove it, as needed.
           // this.aTTEND_SUB_REPORTTableAdapter.Fill(this.attendance_ds.ATTEND_SUB_REPORT);

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.aTTEND_SUB_REPORTTableAdapter.FillBy(this.attendance_ds.ATTEND_SUB_REPORT, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(s_IDToolStripTextBox.Text, typeof(decimal))))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.reportViewer1.RefreshReport();
            
        }
    }
}
