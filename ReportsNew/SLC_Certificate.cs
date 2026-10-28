using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace School._forms
{
    public partial class SLC_Certificate : Form
    {
        public SLC_Certificate()
        {
            InitializeComponent();
        }
        public string admissionno = "";
        public string param = "";

        private void PrntClasswiseoutst_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student_DataSet.SLC_CERTIFICATE' table. You can move, or remove it, as needed.
            if (param == "studentid")
            {
                this.sLC_CERTIFICATETableAdapter.FillBy_sid(this.student_DataSet.SLC_CERTIFICATE, ((decimal)(System.Convert.ChangeType(admissionno, typeof(decimal)))), SYSTEMSETTING.sessionid);
            }
            else
            {
                this.sLC_CERTIFICATETableAdapter.Fill(this.student_DataSet.SLC_CERTIFICATE, admissionno);
            }

            this.reportViewer1.RefreshReport();

        }


    }
}
