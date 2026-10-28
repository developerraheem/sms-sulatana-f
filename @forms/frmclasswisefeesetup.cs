using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace School._forms
{
    public partial class frmclasswisefeesetup : Form
    {
        _class.clsODBC cls_Con = new School._class.clsODBC();
        OleDbCommand cmdForm = new OleDbCommand();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        public frmclasswisefeesetup()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void frmclasswisefeesetup_Load(object sender, EventArgs e)
        {
            FillClass();
            FillFeeHead();
            FillType();
            // fill_list();
        }
        public void FillClass()
        {
            //this.cls_Con.comboFill(this.cmbclass, "SELECT [c_id],[c_name]FROM [class] ", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbclass, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
        }

        public void FillFeeHead()
        {
            this.SYS.comboFill(this.cmbfeehead, "SELECT Fee_head_id, Fee_head FROM Fee_Head where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Fee_Head", "Fee_head", "Fee_head_id");
        }
        public void FillType()
        {
            this.SYS.comboFill(this.cmbtype, "select typecode from student_type where branch_id='" + SYSTEMSETTING.branch_ID + "'", "student_type", "typecode", "typecode");
        }
        public void fill_list()
        {
            SYS.Filllist_DataView("SELECT Fee_Class.FEE_CLASS_ID, Fee_Head.Fee_head, Fee_Class.AMOUNT, Fee_Class.TYPE FROM  Fee_Class INNER JOIN Fee_Head ON Fee_Class.Fee_head_id = Fee_Head.Fee_head_id WHERE (Fee_Class.C_ID = '" + this.cmbclass.SelectedValue + "' and  Fee_Class.branch_id='" + SYSTEMSETTING.branch_ID + "')", this.lstv_fee);
        }

        private void cmbclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fill_list();
        }

        private void lstv_fee_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblid.Text = (this.lstv_fee.Items[lstv_fee.FocusedItem.Index].SubItems[0].Text.Trim());

            try
            {
                rs = SYS.Show_Query("SELECT * FROM Fee_Class WHERE FEE_CLASS_ID='" + lblid.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    cmbclass.SelectedValue = RowDocument["C_ID"].ToString();
                    cmbfeehead.SelectedValue = RowDocument["Fee_head_id"].ToString();
                    txtamount.Text = RowDocument["AMOUNT"].ToString();
                    this.chk_Active.Checked = Convert.ToBoolean(RowDocument["ACTIVE"].ToString());
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            txtamount.Text = "0";
            chk_Active.Checked = false;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Boolean check = false;
            check = SYS.Insert_Query("Delete From Fee_Class where FEE_CLASS_ID='" + lblid.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
            if (check == true)
            {
                MessageBox.Show("Record Deleted!");
                fill_list();
            }
            else
            {
                MessageBox.Show("Record Not Deleted!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Boolean check = false;
            bool val;
            val = this.chk_Active.Checked;
            check = SYS.Insert_Query("Update Fee_Class set AMOUNT=" + txtamount.Text.ToString() + ", ACTIVE='" + val + "', TYPE='" + cmbtype.Text + "' where FEE_CLASS_ID='" + lblid.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
            if (check == true)
            {
                MessageBox.Show("Record Updated!");
                fill_list();
            }
            else
            {
                MessageBox.Show("Record Not Updated!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string FOUND = "";
            // Check Existing Record
            rs = SYS.Show_Query("select FEE_CLASS_ID from Fee_Class where C_ID='" + cmbclass.SelectedValue + "' AND Fee_head_id='" + cmbfeehead.SelectedValue + "' and TYPE='" + cmbtype.SelectedValue + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' ");

            if (rs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    FOUND = RowDocument["FEE_CLASS_ID"].ToString();
                }
            }
            else
            {
                FOUND = "";
            }

            if (FOUND == "")
            {
                Boolean check = false;
                bool val;
                val = this.chk_Active.Checked;

                check = SYS.Insert_Query("insert into Fee_Class(Fee_head_id,C_ID,AMOUNT,ACTIVE,TYPE,BRANCH_ID) values('" + cmbfeehead.SelectedValue.ToString() + "', " + this.cmbclass.SelectedValue + ", '" + txtamount.Text + "','" + val + "','" + cmbtype.Text + "','" + SYSTEMSETTING.branch_ID + "')");
                if (check == true)
                {
                    MessageBox.Show("Record Added!");
                    fill_list();
                }
                else
                {
                    MessageBox.Show("Record Not Added!");
                }
            }
            else
            {
                SYS.setCreateError("Fee head already mapped with this class");
            }



        }

        private void cmbclass_Click(object sender, EventArgs e)
        {
            fill_list();
        }

        private void cmbclass_SelectedValueChanged(object sender, EventArgs e)
        {
            //
        }

        private void cmbshift_Click(object sender, EventArgs e)
        {
            fill_list();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill_list();
        }

      
    }
}
