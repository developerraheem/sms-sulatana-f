using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class PrintTest : Form
    {
        public PrintTest()
        {
            InitializeComponent();
        }

        private void PrintTest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'report_dataset.Attendance_Dataset' table. You can move, or remove it, as needed.
            this.attendance_DatasetTableAdapter.Fill(this.report_dataset.Attendance_Dataset);
           
            this.reportViewer1.RefreshReport();
        }
    }
}
