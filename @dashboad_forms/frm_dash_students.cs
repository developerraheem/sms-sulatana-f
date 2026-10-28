using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using School._forms;

namespace School._dashboad_forms
{
    public partial class frm_dash_students : Form
    {
        public frm_dash_students()
        {
            InitializeComponent();

        }
        public string branchid = "";
        public string sessionid = "";


        private void frm_dash_students_Load(object sender, EventArgs e)
        {
            //, "%" + txtstdname.Text + "%"
            if (txtstdname.Text.Length > 0)
            {
                try
                {
                    this.view_StudentTableAdapter.FillBy1byname(this.dashboard.view_Student, ((decimal)(System.Convert.ChangeType(branchid, typeof(decimal)))), sessionid, "%" + txtstdname.Text + "%");
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    this.view_StudentTableAdapter.FillBy(this.dashboard.view_Student, ((decimal)(System.Convert.ChangeType(branchid, typeof(decimal)))), sessionid);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }

        }

        private void txtstdname_TextChanged(object sender, EventArgs e)
        {
            if (txtstdname.Text.Length > 0)
            {
                string SEARCH = "%" + txtstdname.Text.ToUpper() + "%";
                try
                {
                    this.view_StudentTableAdapter.FillBy1byname(this.dashboard.view_Student, ((decimal)(System.Convert.ChangeType(branchid, typeof(decimal)))), sessionid, SEARCH);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    this.view_StudentTableAdapter.FillBy(this.dashboard.view_Student, ((decimal)(System.Convert.ChangeType(branchid, typeof(decimal)))), sessionid);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                try
                {
                    string STUDENT_ID = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    Rpt_Student frm_Exam = new Rpt_Student();
                    try
                    {
                        frm_Exam.str = "SID";
                        frm_Exam.class_id = SYSTEMSETTING.sessionid;
                        frm_Exam.studentID = Convert.ToDecimal(STUDENT_ID);
                    }
                    catch (Exception)
                    {


                    }

                    frm_Exam.Show();

                }
                catch (Exception)
                {

                }


            }
            else if (e.ColumnIndex == 1)
            {
                string STUDENT_ID = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                VoucherslistReport frm = new VoucherslistReport();
                frm.param = "Studentwise";
                frm.classid = "";
                frm.SHIFTID = "";
                frm.stdid = STUDENT_ID;
                frm.Show();

            }
        }


    }
}
