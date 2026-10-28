using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace School._forms
{
    public partial class frmFindExp : Form
    {
        public frmFindExp()
        {
            InitializeComponent();
        }
        public string str_Find;
        DataSet rs = new DataSet();
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        _class.clsODBC cls_Con = new School._class.clsODBC();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFindExp_Load(object sender, EventArgs e)
        {
            try
            {
                lblbranch.Text = SYSTEMSETTING.schoolname;
                lbladdress.Text = SYSTEMSETTING.branch_address;

                rs = SYS.Show_Query("select count(c_id) from class where branch_id='" + SYSTEMSETTING.branch_ID + "'");
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                   lbltotal_classes.Text = RowDocument[0].ToString();
                }

                rs = SYS.Show_Query("select count(*) from Sections where branch_id='" + SYSTEMSETTING.branch_ID + "'");
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    lbltotal_sections.Text = RowDocument[0].ToString();
                }

                rs = SYS.Show_Query("select count(*) from view_Student where SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    lbltotal_students.Text = RowDocument[0].ToString();
                }
            }
            catch (Exception exp)
            {

            }
        }





    }
}