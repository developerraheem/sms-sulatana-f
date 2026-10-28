using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class Frmattnd_Reprot : Form
    {
        public Frmattnd_Reprot()
        {
            InitializeComponent();
        }
        _class.clsODBC cls_Con = new School._class.clsODBC();

        private void Frmattnd_Reprot_Load(object sender, EventArgs e)
        {
            this.cls_Con.comboFill(this.cmbclass, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "'", "class", "c_name", "c_id");
            this.cls_Con.comboFill(this.cmbclass1, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "'", "class", "c_name", "c_id");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rpt_attnd_summary rpt = new Rpt_attnd_summary();
            rpt.dateto = dateto1.Text;
            rpt.datefrom = datefrom1.Text;
            rpt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rpt_attnd atnd = new Rpt_attnd();
            atnd.classid = cmbclass.SelectedValue.ToString();
            atnd.dateto = dateto.Text;
            atnd.datefrom = datefrom.Text;
            atnd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rpt_attnd atnd = new Rpt_attnd();
            atnd.classid = cmbclass.SelectedValue.ToString();
            atnd.dateto = dateto.Text;
            atnd.datefrom = datefrom.Text;
            atnd.str = "RollNo";
            atnd.rollno = txtrollno.Text;
            atnd.Show();
        }
    }
}
