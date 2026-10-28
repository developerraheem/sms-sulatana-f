using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._dashboad_forms
{
    public partial class frm_dash_classes : Form
    {
        public frm_dash_classes()
        {
            InitializeComponent();
        }
        public string BRANCHID;
        private void frm_dash_classes_Load(object sender, EventArgs e)
        {
            try
            {
                this.classTableAdapter.FillBy(this.dashboard._class, ((decimal)(System.Convert.ChangeType(BRANCHID, typeof(decimal)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                try
                {
                    string STUDENT_ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    frm_dash_FEEHEAD frm_Exam = new frm_dash_FEEHEAD();
                    try
                    {

                        frm_Exam.BRANCHID = BRANCHID;
                        frm_Exam.CLASSID = STUDENT_ID;
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
        }

        
    }
}
