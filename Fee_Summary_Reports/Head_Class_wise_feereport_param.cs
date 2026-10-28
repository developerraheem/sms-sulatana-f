using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace School.Fee_Summary_Reports
{
    public partial class Head_Class_wise_feereport_param : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();

        public Head_Class_wise_feereport_param()
        {
            InitializeComponent();
        }

        private void frmclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Head_Class_wise_feereport frm = new Head_Class_wise_feereport();
            frm.feemonth = cmbmonth.Text;
            frm.feemonthto = dateTimePicker1.Text;

            frm.datefrom = cmbmonth.Text;
            frm.dateto = dateTimePicker1.Text;

            frm.sessionid = SYSTEMSETTING.sessionid;
            frm.classfrom = cmbclassfrom.SelectedValue.ToString();
            frm.classto = cmbclassto.SelectedValue.ToString();

            frm.startdate = txtstartdate.Text;
            frm.enddate = txtenddate.Text;
            if (checkBox1.Checked == true)
            {
                frm.isdatewise = "Y";
            }
            

            frm.Show();
        }

        private void Head_Class_wise_feereport_param_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyTheme(this);
            this.SYS.comboFill(this.cmbclassfrom, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            this.SYS.comboFill(this.cmbclassto, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
        }

        private void cmbmonth_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtenddate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = txtenddate.Text;
        }

        private void txtstartdate_ValueChanged(object sender, EventArgs e)
        {
            cmbmonth.Text = txtstartdate.Text;
        }
    }
}
