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
    public partial class frmSubject : Form
    {
        public frmSubject()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        public string str, strEdit;
        _class.clsODBC cls_Con = new School._class.clsODBC();
        OleDbCommand cmdForm = new OleDbCommand();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        SYSTEMSETTING SYS = new SYSTEMSETTING();

        private void frmSubject_Load(object sender, EventArgs e)
        {
            try
            {

                this.SYS.comboFill(this.cmb_class, "select * from class WHERE branch_id='"+ SYSTEMSETTING.branch_ID +"' ORDER BY c_id", "class", "c_name", "c_id");
                this.SYS.comboFill(this.cmb_class_find, "select * from class WHERE branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY c_id", "class", "c_name", "c_id");

                list_Data();
            }
            catch (Exception ex)
            {


            }

        }
        private void list_Data()
        {
            //cls_Con.list_DataView("select sub_id,sub_name,c_name,emp_name,sub_marks,remarks,is_active,is_teacher from view_subject where is_teacher=true and is_active='true'", this.lstv_Subject);
            try
            {
                if (rdo_Class.Checked == true)
                {
                    if (cmb_class_find.SelectedValue.ToString() != "")
                    {
                        SYS.Filllist_DataView("SELECT [ID],[sub_id],[sub_name],[sub_marks],[remarks] FROM [subject] WHERE c_id='" + cmb_class_find.SelectedValue + "' AND branch_id='" + SYSTEMSETTING.branch_ID + "'", this.lstv_Subject);
                    }
                }
            }

            catch (Exception exp)
            {

            }


        }
        private void text_Clear()
        {

            txtsubjectcode.Text = string.Empty;
            txtsubjectname.Text = string.Empty;
            txtMarks.Text = "0";
            txtremarks.Text = string.Empty;
        }

        private void teacher_Combo()
        {
          //  cls_Con.comboFill(this.cmbteacher, "select * from employee where is_teacher=true and active='true' order by employee.emp_name", "employee", "emp_name", "emp_id");
        }
        private void set_TabIndex()
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {

        }




        private void btn_Refresh_Click(object sender, EventArgs e)
        {


        }

        private void txtMarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }

        private void save_Subject()
        {
            if (this.cmb_class.SelectedIndex == -1 || this.txtsubjectcode.Text == "" || this.txtsubjectname.Text == "")
            {

                MessageBox.Show("Some required Fields are Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool val;
                try
                {
                    string QUERY = "insert into subject(c_id,sub_id,sub_name,sub_marks,remarks,branch_id) values ('" + cmb_class.SelectedValue + "','" + txtsubjectcode.Text + "','" + txtsubjectname.Text + "','" + txtMarks.Text + "','" + txtremarks.Text + "','"+ SYSTEMSETTING.branch_ID +"')";
                    val = SYS.Insert_Query(QUERY);
                    if (val == true)
                    {
                        SYS.setMessageBox("New Subject Added!", 1);
                        text_Clear();
                    }

                }
                catch (Exception exp)
                {
                    SYS.setCreateError(exp.Message);

                }
                finally
                {

                }
            }
        }

        private void rdo_All_Click(object sender, EventArgs e)
        {
            if (rdo_All.Checked == true)
            {
                list_Data();
            }
            else
            {
                return;
            }
        }

        private void rdo_Class_Click(object sender, EventArgs e)
        {
            if (rdo_Class.Checked == true)
            {
                list_Data();
            }
        }

        private void com_Sclass_SelectedValueChanged(object sender, EventArgs e)
        {
            //list_Data();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            txt_Find.Focus();
        }

        private void txt_Find_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }
        private void delete_Subject()
        {

        }

        private void lstv_Subject_SelectedIndexChanged(object sender, EventArgs e)
        {

        }






        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save_Subject();
            list_Data();
        }




        private void btnrefresh_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            text_Clear();
            //Frmsubjectoffering frm = new Frmsubjectoffering();
            //frm.Show();
        }

        private void rdo_Class_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdo_All_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmb_class_find_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdo_Class.Checked == true)
            {
                list_Data();
            }
        }

        private void lstv_Subject_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstv_Subject.SelectedItems.Count > 0)
            {
                lblid.Text = this.lstv_Subject.Items[lstv_Subject.FocusedItem.Index].SubItems[0].Text.Trim();


                DataSet rs = new DataSet();
                rs = SYS.Show_Query("Select * from subject  where ID='" + lblid.Text + "'");
                if (rs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow RowDocument in rs.Tables[0].Rows)
                    {
                        txtsubjectcode.Text = RowDocument["sub_id"].ToString();
                        txtsubjectname.Text = RowDocument["sub_name"].ToString();
                        txtMarks.Text = RowDocument["sub_marks"].ToString();
                        txtremarks.Text = RowDocument["remarks"].ToString();
                        cmb_class.SelectedValue = RowDocument["c_id"].ToString();

                    }
                }


            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblid.Text.Length > 0)
            {
                try
                {
                    SYS.Insert_Query("Update subject set sub_id='" + txtsubjectcode.Text + "', sub_name='" + txtsubjectname.Text + "', sub_marks='" + txtMarks.Text + "', remarks='" + txtremarks.Text + "' where ID='" + lblid.Text + "'");
                    list_Data();
                }
                catch (Exception exp)
                {
                    
                     list_Data();
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lblid.Text.Length > 0)
            {
                try
                {
                    SYS.Insert_Query("Delete from subject where ID='" + lblid.Text + "'");
                    list_Data();
                }
                catch (Exception exp)
                {

                    list_Data();
                }
            }
        }


    }
}
