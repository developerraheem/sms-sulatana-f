using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class Rpt_attnd_summary : Form
    {
        public Rpt_attnd_summary()
        {
            InitializeComponent();
        }
        public string dateto="";
        public string datefrom="";
        private void Rpt_attnd_summary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'report_dataset.Attendance_Dataset' table. You can move, or remove it, as needed.
            this.attendance_DatasetTableAdapter.Fill(this.report_dataset.Attendance_Dataset);
            try
            {
                txtdatefrom.Text = datefrom.ToString();
                txtdateto.Text = dateto.ToString();
                this.attendance_DatasetTableAdapter.FillBy1(this.report_dataset.Attendance_Dataset, txtdateto.Text, txtdatefrom.Text);
                this.reportViewer1.RefreshReport();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

       
    }
}
