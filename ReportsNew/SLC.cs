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
    public partial class SLC : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();

        public SLC()
        {
            InitializeComponent();
        }
        public string month = "";

        private void PrntClasswiseoutst_Load(object sender, EventArgs e)
        {
            

           

            SYS.comboFill(this.com_cName, "select * from class ORDER BY c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT]", "SHIFT", "SHIFT", "SHIFT");
            //SYS.comboFill(this.cmbnewshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT]", "SHIFT", "SHIFT", "SHIFT");
            //SYS.comboFill(this.cmbnewsection, "SELECT [SECTION_NAME] FROM [Sections]", "Sections", "SECTION_NAME", "SECTION_NAME");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdotype.Checked == true)
                {
                    try
                    {
                        this.sLCTableAdapter.FillBy1(this.student_DataSet.SLC, Convert.ToDecimal(SYSTEMSETTING.sessionid));
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                     
                }
                else if (rdostudent.Checked == true)
                {
                    //this.sLCTableAdapter.FillBySTDID(this.student_DataSet.SLC, new System.Nullable<decimal>(Convert.ToDecimal(SYSTEMSETTING.sessionid)), ((decimal)(System.Convert.ChangeType(txtstudentid.Text, typeof(decimal)))));
                   // this.sLCTableAdapter.FillBySTDID(this.student_DataSet.SLC);
                    this.sLCTableAdapter.FillBySTDID(this.student_DataSet.SLC, Convert.ToDecimal(SYSTEMSETTING.sessionid), ((decimal)(System.Convert.ChangeType(txtstudentid.Text, typeof(decimal)))));
                }
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnfindstd_Click(object sender, EventArgs e)
        {
            if (rdostudent.Checked == true)
            {
                Frmfind_student frm = new Frmfind_student(this);
                frm.param = "SLC";
                frm.Classid = com_cName.SelectedValue.ToString();
                frm.Shift = cmbshift.SelectedValue.ToString();
                frm.ShowDialog();
            }
        }

        public string Student_ID
        {
            get { return txtstudentid.Text; }
            set { txtstudentid.Text = value; }
        }

        private void fillBySTDIDToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdostudent.Checked == true)
            {
                if (txtstudentid.Text.Length > 0)
                {
                    SLC_Certificate frm = new SLC_Certificate();
                    frm.param = "studentid";
                    frm.admissionno = txtstudentid.Text;
                    frm.Show();
                }
            }
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
           

        }

    }
}
