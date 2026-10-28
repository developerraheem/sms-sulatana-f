using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class FrmVoucherPr : Form
    {
        public FrmVoucherPr()
        {
            InitializeComponent();
        }

        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        bool multitag = false;
        string query = "";
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select MULTITAG from FEE_MASTER where FEE_MONTH='" + txtmonth.Text + "' and SESSIONID='" + SYSTEMSETTING.sessionid + "'";
                rs = SYS.Show_Query(query);
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    if (RowDocument["MULTITAG"].ToString() == "Y")
                    {
                        multitag = true;
                    }
                    else
                    {
                        multitag = false;
                    }
                }
            }
            catch (Exception)
            {
                multitag = false;
            }


            multitag = true;
            if (checkBox1.Checked == true)
            {
                if (multitag == false)
                {
                    Frm_Vouchers frm = new Frm_Vouchers();
                    frm.classid = cmbclass.SelectedValue.ToString();
                    frm.feemonth = txtmonth.Text.ToString();
                    frm.param = "AdmissionNo";
                    frm.section = cmbsection.SelectedValue.ToString();
                    frm.admissionno = txtadmNo.Text;
                    frm.shift = cmbshift.SelectedValue.ToString();
                    frm.sessionid = cmbsession.SelectedValue.ToString();
                    frm.Show();
                }
                else
                {
                    Frm_Vouchers_multi frm = new Frm_Vouchers_multi();
                    frm.classid = cmbclass.SelectedValue.ToString();
                    frm.feemonth = txtmonth.Text.ToString();
                    frm.param = "AdmissionNo";
                    frm.section = cmbsection.SelectedValue.ToString();
                    frm.admissionno = txtadmNo.Text;
                    frm.shift = cmbshift.SelectedValue.ToString();
                    //frm.sessionid = cmbsession.SelectedValue.ToString();
                    frm.Show();
                }


            }
            else
            {
                try
                {
                    if (multitag == false)
                    {
                        Frm_Vouchers frm = new Frm_Vouchers();
                        frm.classid = cmbclass.SelectedValue.ToString();
                        frm.feemonth = txtmonth.Text.ToString();
                        frm.param = "month";
                        frm.section = cmbsection.SelectedValue.ToString();
                        frm.shift = cmbshift.SelectedValue.ToString();
                        frm.sessionid = cmbsession.SelectedValue.ToString();
                        frm.Show();
                    }
                    else
                    {
                        Frm_Vouchers_multi frm = new Frm_Vouchers_multi();
                        frm.classid = cmbclass.SelectedValue.ToString();
                        frm.feemonth = txtmonth.Text.ToString();
                        frm.param = "month";
                        frm.section = cmbsection.SelectedValue.ToString();
                        frm.shift = cmbshift.SelectedValue.ToString();
                        //frm.sessionid = cmbsession.SelectedValue.ToString();
                        frm.Show();
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }
            }


        }

        private void FrmVoucherPr_Load(object sender, EventArgs e)
        {
            this.SYS.comboFill(this.cmbclass, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbsection, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
            SYS.comboFill(this.cmbsession, "select * from [Sessions] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sessions", "SessionName", "SessionID");
            cmbsession.SelectedValue = SYSTEMSETTING.sessionid.ToString();
            ThemeHelper.ApplyTheme(this);
        }

        public string Student_ID
        {
            get { return txtadmNo.Text; }
            set { txtadmNo.Text = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtvoucherno.Text.Length > 0)
                {
                    Frm_Vouchers frm = new Frm_Vouchers();
                    frm.voucherno = txtvoucherno.Text;
                    frm.param = "voucherno";
                    frm.sessionid = cmbsession.SelectedValue.ToString();
                    frm.Show();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Frm_Vouchers frm = new Frm_Vouchers();
        //        frm.admissionno = txtadmNo.Text;
        //        frm.feemonth = txtmonth1.Text.ToString();
        //        frm.param = "AdmissionNo";
        //        frm.Show();
        //    }
        //    catch (Exception exp)
        //    {
        //        MessageBox.Show(exp.ToString());
        //    }
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                PrntUnpaidvoucher frm = new PrntUnpaidvoucher();
                frm.classid = cmbclass.Text.ToString();
                frm.month = txtmonth.Text.ToString();
                frm.SHIFTID = cmbshift.SelectedValue.ToString();
                frm.sessionid = cmbsession.SelectedValue.ToString();

                frm.Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtadmNo.Enabled = true;
                btnfind.Enabled = true;
            }
            else
            {
                txtadmNo.Enabled = false;
                btnfind.Enabled = false;
            }
        }

        private void btnfind_Click(object sender, EventArgs e)
        {

            Frmfind_student frm = new Frmfind_student(this);
            frm.param = "VoucherPrint";
            frm.Classid = cmbclass.SelectedValue.ToString();
            frm.Shift = cmbshift.SelectedValue.ToString();
            frm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtvoucherno.Text.Length > 0)
            {
                if (MessageBox.Show("Are you sure you want to Print Duplicate Voucher?", "Duplicate Voucher", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    try
                    {
                        string FEEMONTH = "";
                        string id = "";
                        bool a = false;

                        rs = SYS.Show_Query("select FEE_MONTH from FEE_MASTER where FEE_MASTER_ID='" + txtvoucherno.Text + "' AND SESSIONID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                        foreach (DataRow RowDocument in rs.Tables[0].Rows)
                        {
                            FEEMONTH = RowDocument[0].ToString();
                        }

                        rs = SYS.Show_Query("select FEE_MASTER_ID from FEE_DETAIL where FEE_MASTER_ID='" + txtvoucherno.Text + "' AND Fee_head_id='7' AND SESSIONID='" + SYSTEMSETTING.sessionid + "'");
                        foreach (DataRow RowDocument in rs.Tables[0].Rows)
                        {
                            id = RowDocument["FEE_MASTER_ID"].ToString();
                        }

                        if (id == txtvoucherno.Text)
                        {
                        }
                        else
                        {
                            a = SYS.Insert_Query("Insert into FEE_DETAIL(FEE_MASTER_ID,Fee_head_id,AMOUNT,FEE_MONTH,ISCURRENT,BALANCE,SESSIONID,branch_id) VALUES(" + txtvoucherno.Text + ",'7','25','" + FEEMONTH + "','Y','25','" + SYSTEMSETTING.sessionid + "','" + SYSTEMSETTING.branch_ID + "')");
                            _class.FEE fee = new _class.FEE();
                            fee.BalanceVoucher(txtvoucherno.Text);
                        }



                        if (a == true)
                        {
                            Frm_Vouchers frm = new Frm_Vouchers();
                            frm.voucherno = txtvoucherno.Text;
                            frm.param = "voucherno";
                            frm.Show();
                            SYS.setMessageBox("Duplicate Voucher Generated", 1);
                        }



                    }
                    catch (Exception exp)
                    {
                        SYS.setMessageBox(exp.ToString(), 3);

                    }

                }




            }
        }
    }
}
