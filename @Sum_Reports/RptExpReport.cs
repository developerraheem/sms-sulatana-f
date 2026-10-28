using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class RptExpReport : Form
    {
        public RptExpReport()
        {
            InitializeComponent();
        }
        public string dto = "";
        public string dfrom = "";
       
        private void RptExpReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'report_dataset.Expense_Detail' table. You can move, or remove it, as needed.
            txtdto.Text = dto.ToString();
            txtdfrom.Text = dfrom.ToString();
            try
            {
                this.expense_DetailTableAdapter.FillBy(this.report_dataset.Expense_Detail, new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(txtdto.Text, typeof(System.DateTime))))), new System.Nullable<System.DateTime>(((System.DateTime)(System.Convert.ChangeType(txtdfrom.Text, typeof(System.DateTime))))));
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


        }
    }
}
