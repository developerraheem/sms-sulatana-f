using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class Rpt_attnd : Form
    {
        public Rpt_attnd()
        {
            InitializeComponent();
        }
        public string classid = "";
        public string dateto = "";
        public string datefrom = "";
        public string str = "";
        public string rollno;

        private void Rpt_attnd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'report_dataset.Attendance_Dataset' table. You can move, or remove it, as needed.
            this.attendance_DatasetTableAdapter.Fill(this.report_dataset.Attendance_Dataset);
            txtclassid.Text = classid.ToString();
            txtdatefrom.Text = datefrom.ToString();
            txtdateto.Text = dateto.ToString();
          
            if (str == "RollNo")
            {
                try
                {
                    txtrollno.Text = rollno.ToString();
                    this.attendance_DatasetTableAdapter.FillBy2(this.report_dataset.Attendance_Dataset, txtdateto.Text, txtdatefrom.Text, txtrollno.Text,txtclassid.Text);
                    this.reportViewer1.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    this.attendance_DatasetTableAdapter.FillBy(this.report_dataset.Attendance_Dataset, txtdateto.Text, txtdatefrom.Text, txtclassid.Text);
                    this.reportViewer1.RefreshReport();
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            
            
            

        }

        
                
    }
}
