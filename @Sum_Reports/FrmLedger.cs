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
    public partial class FrmLedger : Form
    {
        public FrmLedger()
        {
            InitializeComponent();
        }
        SYSTEMSETTING SYS = new SYSTEMSETTING();

        private void FrmLedger_Load(object sender, EventArgs e)
        {
            SYS.comboFill(this.cmbclass, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT] FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
           
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }

        private void btnprint_Click_1(object sender, EventArgs e)
        {
            VoucherslistReport frm = new VoucherslistReport();
            frm.param = "Studentwise";
            frm.classid = cmbclass.SelectedValue.ToString();
            frm.SHIFTID = cmbshift.SelectedValue.ToString();
            frm.stdid = txtadmNo.Text;
            frm.Show();
        }
        
        public string Student_ID
        {
            get { return txtadmNo.Text; }
            set { txtadmNo.Text = value; }
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            Frmfind_student frm = new Frmfind_student(this);
            frm.param = "StudentLedger";
            frm.Classid = cmbclass.SelectedValue.ToString();
            frm.Shift = cmbshift.SelectedValue.ToString();
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
      

  
    
 
     
      
    

    
    }
}
