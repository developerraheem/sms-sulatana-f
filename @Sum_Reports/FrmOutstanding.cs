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
    public partial class FrmOutstanding : Form
    {
        public FrmOutstanding()
        {
            InitializeComponent();
        }
        _class.clsODBC cls_Con = new School._class.clsODBC();
        OleDbCommand cmdForm = new OleDbCommand();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();

        private void FrmOutstanding_Load(object sender, EventArgs e)
        {
            cls_Con.comboFill(this.comboBox1, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "'", "class", "c_name", "c_id");
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            //PrntOutstandingStudents print = new PrntOutstandingStudents();
            //print.classid = comboBox1.SelectedValue.ToString();
            //print.Show();
        }

       
    }
}
