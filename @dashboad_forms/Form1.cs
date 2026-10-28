using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School._dashboad_forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        string QUERY = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyTheme(this);
            this.SYS.comboFill(this.cmbdept, "select branch_id,branch_name from branch where active='Y'", "branch", "branch_name", "branch_id");
            this.SYS.comboFill(this.cmbselection, "select * from [Sessions] where branch_id='" + cmbdept.SelectedValue.ToString() + "' order by SessionID desc", "Sessions", "SessionName", "SessionID");
            cmbselection.Focus();

            // cmbdept.SelectedValue = SYSTEMSETTING.branch_ID.ToString();
            // cmbselection.SelectedValue = SYSTEMSETTING.sessionid.ToString()();
            GetStudents();
        }

        private void cmbdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SYS.comboFill(this.cmbselection, "select * from [Sessions] where branch_id='" + cmbdept.SelectedValue.ToString() + "' order by SessionID desc", "Sessions", "SessionName", "SessionID");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetStudents();
        }
        public void GetStudents()
        {
            QUERY = "select count(*) from view_Student where branch_id='" + cmbdept.SelectedValue + "' and SessionID='" + cmbselection.SelectedValue + "'";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow Row in rs.Tables[0].Rows)
            {
                lbltotal_students.Text = Row[0].ToString();
            }

            QUERY = "select count(*) from view_Student where branch_id='" + cmbdept.SelectedValue + "' and SessionID='" + cmbselection.SelectedValue + "' and sex='Male'";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow Row in rs.Tables[0].Rows)
            {
                lblmale.Text = Row[0].ToString();
            }

            QUERY = "select count(*) from view_Student where branch_id='" + cmbdept.SelectedValue + "' and SessionID='" + cmbselection.SelectedValue + "' and sex='Female'";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow Row in rs.Tables[0].Rows)
            {
                lblfemale.Text = Row[0].ToString();
            }

            QUERY = "select count(*) from class where branch_id='" + cmbdept.SelectedValue.ToString() + "'";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow Row in rs.Tables[0].Rows)
            {
                lbltotal_classes.Text = Row[0].ToString();
            }

            QUERY = "select count(*) from Sections where BRANCH_ID='" + cmbdept.SelectedValue.ToString() + "'";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow Row in rs.Tables[0].Rows)
            {
                lbltotal_sections.Text = Row[0].ToString();
            }

            QUERY = "select count(*) from employee where branch_id='" + cmbdept.SelectedValue.ToString() + "'";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow Row in rs.Tables[0].Rows)
            {
                lblemployees.Text = Row[0].ToString();
            }

            QUERY = "select count(*) from employee where branch_id='" + cmbdept.SelectedValue.ToString() + "'";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow Row in rs.Tables[0].Rows)
            {
                lblemployees.Text = Row[0].ToString();
            }

            QUERY = "select count(*) from subject where branch_id='" + cmbdept.SelectedValue.ToString() + "'";
            rs = SYS.Show_Query(QUERY);
            foreach (DataRow Row in rs.Tables[0].Rows)
            {
                lblsubjects.Text = Row[0].ToString();
            }





        }

        private void lbltotal_students_Click(object sender, EventArgs e)
        {
            frm_dash_students frm = new frm_dash_students();
            SYSTEMSETTING.sessionid = cmbselection.SelectedValue.ToString();
            SYSTEMSETTING.schoolname = cmbselection.SelectedValue.ToString();

            DataSet rs = new DataSet();
            rs = SYS.Show_Query("select * from branch where branch_id='" + cmbdept.SelectedValue.ToString() + "'");
            if (rs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    SYSTEMSETTING.branch_address = RowDocument["branch_address"].ToString();
                    SYSTEMSETTING.schoolname = RowDocument["branch_name"].ToString();
                }
            }


            rs = SYS.Show_Query("select SessionName from Sessions where SessionID='" + cmbselection.SelectedValue.ToString() + "'");
            if (rs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    SYSTEMSETTING.sessionname = RowDocument["SessionName"].ToString();
                }
            }



            frm.branchid = cmbdept.SelectedValue.ToString();
            frm.sessionid = cmbselection.SelectedValue.ToString();
            frm.ShowDialog();
        }

        private void lbltotal_classes_Click(object sender, EventArgs e)
        {
            frm_dash_classes frm = new frm_dash_classes();
            frm.BRANCHID = cmbdept.SelectedValue.ToString();
            frm.ShowDialog();
        }

        private void lbltotal_sections_Click(object sender, EventArgs e)
        {
            frm_dash_sections frm = new frm_dash_sections();
            frm.BRANCHID = cmbdept.SelectedValue.ToString();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnl_advancesearch.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnl_advancesearch.Visible = false;
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                frmStudent_view frm = new frmStudent_view();
                frm.ShowDialog();

            }
            else
            {
                textBox1.Focus();
            }
            
         
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
                //this.Close();
            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _forms.frmbranch frm = new _forms.frmbranch();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _forms.FrmSession frm = new _forms.FrmSession();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //frmbranch frm = new frmbranch();
            //frm.ShowDialog();
            security_module.frmusers frm = new security_module.frmusers();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _forms.frmbranch frm = new _forms.frmbranch();
            frm.ShowDialog();
        }





    }
}
