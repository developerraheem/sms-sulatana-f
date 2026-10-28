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
    public partial class Rpt_Student : Form
    {
        public Rpt_Student()
        {
            InitializeComponent();
        }
        public string str = "";
        public string class_id = "";
        public string searching_value = "";
        public string sessionid = "";
        public decimal studentID = 0;
        private void Rpt_Student_Load(object sender, EventArgs e)
        {
            txtclassid.Text = class_id.ToString();
            txtsearchingvalue.Text = str.ToString();
            txtvalue.Text = searching_value.ToString();
            if (str == "SID")
            {
                try
                {

                    this.view_StudentTableAdapter.FillBy4(this.report_dataset.view_Student, studentID, SYSTEMSETTING.sessionid);
                    ReportParameter rpm = new ReportParameter("schoolname", SYSTEMSETTING.schoolname);
                    this.reportViewer1.LocalReport.SetParameters(rpm);
                    this.reportViewer1.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            //else if (str == "Registration No")
            //{
            //    try
            //    {

            //        this.view_StudentTableAdapter.FillBy2(this.report_dataset.view_Student, txtvalue.Text);
            //        this.reportViewer1.RefreshReport();
            //    }
            //    catch (System.Exception ex)
            //    {
            //        System.Windows.Forms.MessageBox.Show(ex.Message);
            //    }
            //}
            //else if (str == "Registration No")
            //{
            //    try
            //    {

            //        this.view_StudentTableAdapter.FillBy2(this.report_dataset.view_Student, txtvalue.Text);
            //        this.reportViewer1.RefreshReport();
            //    }
            //    catch (System.Exception ex)
            //    {
            //        System.Windows.Forms.MessageBox.Show(ex.Message);
            //    }
            //}
            //else if (str == "AdmissionNo")
            //{
            //    try
            //    {
            //        this.view_StudentTableAdapter.FillBy4(this.report_dataset.view_Student, txtvalue.Text);
            //        this.reportViewer1.RefreshReport();
            //    }
            //    catch (System.Exception ex)
            //    {
            //        System.Windows.Forms.MessageBox.Show(ex.Message);
            //    }
                
            //}
            else
            {
                MessageBox.Show("Invalid Selection");
                this.Close();
            }




        }

     
       
       
    }
}
