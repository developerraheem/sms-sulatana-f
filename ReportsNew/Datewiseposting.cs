using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School.ReportsNew
{
    public partial class Datewiseposting : Form
    {
        public Datewiseposting()
        {
            InitializeComponent();
        }
        
        public string fromdate = "";
        public string todate = "";
        

        private void Datewiseposting_Load(object sender, EventArgs e)
        {
            try
            {
                this.datewisepostingTableAdapter.FillBy1(this.student_DataSet.Datewiseposting, fromdate, todate,Convert.ToDecimal(SYSTEMSETTING.sessionid));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
                
            }
            

        }

        
    }
}
