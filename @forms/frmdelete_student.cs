using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace School._forms
{
    public partial class frmdelete_student : Form
    {
        SqlCommand cmdForm = new SqlCommand();
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        List<string> myListofQueries = new List<string>();
        DataSet rs = new DataSet();

        public frmdelete_student()
        {
            InitializeComponent();
        }

        private void frmdelete_student_Load(object sender, EventArgs e)
        {
            SYS.comboFill(this.comboBox1, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "'", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbsection, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
        }
    }
}
