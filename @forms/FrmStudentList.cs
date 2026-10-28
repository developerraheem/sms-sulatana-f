using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace School._forms
{
    public partial class FrmStudentList : Form
    {
        public FrmStudentList()
        {
            InitializeComponent();
        }
        public string classid = "";
        public string sessionid = "";
        public string sectionid = "";
        public string shif = "";

        public string classid_to = "";
        //public string sessionid_to = "";
        //public string sectionid_to = "";
        //public string shif_to = "";
        public string busavailed = string.Empty;

        private void FrmStudentList_Load(object sender, EventArgs e)
        {
            try
            {
                if (busavailed == "Y")
                {
                    //this.view_StudentTableAdapter1.FillBy_buss(this.report_DataSet_new.view_Student, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(classid, typeof(decimal))))), new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(classidtoToolStripTextBox.Text, typeof(decimal))))), sessionidfromToolStripTextBox.Text, sessionidtoToolStripTextBox.Text, sectionidfromToolStripTextBox.Text, sectionidtoToolStripTextBox.Text, sHIFTIFromToolStripTextBox.Text, sHIFTTOToolStripTextBox.Text);
                   // txtclassid.Text = classid.ToString();
                    //txtsession.Text = sessionid.ToString();
                    //this.view_StudentTableAdapter1.FillBy_buss(this.report_DataSet_new.view_Student, new System.Nullable<decimal>(Convert.ToDecimal(classid)), Convert.ToDecimal(classid_to), txtsession.Text, txtsession.Text, sectionid, sectionid_to, shif.ToString(), shif_to.ToString());
                }
                else
                {
                    txtclassid.Text = classid.ToString();
                    txtsession.Text = sessionid.ToString();
                    //this.view_StudentTableAdapter1.FillByClass(this.report_DataSet_new.view_Student, new System.Nullable<decimal>(((decimal)(System.Convert.ChangeType(txtclassid.Text, typeof(decimal))))), txtsession.Text, sectionid, shif.ToString());
                    this.view_StudentTableAdapter1.FillByClass(this.report_DataSet_new.view_Student, new System.Nullable<decimal>(Convert.ToDecimal(classid)), Convert.ToDecimal(classid_to), txtsession.Text, txtsession.Text);
                    ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                    this.reportViewer1.LocalReport.SetParameters(rpm);
                    this.reportViewer1.RefreshReport();
                }
              
            }

            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }




            //// TODO: This line of code loads data into the 'report_dataset.view_Student' table. You can move, or remove it, as needed.
            //this.view_StudentTableAdapter.Fill(this.report_dataset.view_Student);
            //txtclassid.Text = classid.ToString();
            //txtsession.Text = sessionid.ToString();
            //try
            //{
            //this.view_StudentTableAdapter.studentlist(this.report_dataset.view_Student, txtclassid.Text, txtsession.Text);
            //this.reportViewer1.RefreshReport();
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

        }

        private void fillBy_bussToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



    }
}
