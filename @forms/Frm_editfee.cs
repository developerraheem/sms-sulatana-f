using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class Frm_editfee : Form
    {
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        public Frm_editfee()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void Student_Detail(string StudentID)
        {

            try
            {

                rs = SYS.Show_Query("Select * from student where s_id='" + StudentID + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                if (rs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow Row in rs.Tables[0].Rows)
                    {
                        txtstdname.Text = Row["s_name"].ToString();
                        txtfname.Text = Row["f_name"].ToString();
                        txtrollno.Text = Row["roll_no"].ToString();
                        txtsection.Text = Row["SECTION_ID"].ToString();




                        txtadmissionno.Text = Row["ADMISSION_NO"].ToString();
                       // txtsession.Text = Row["SessionID"].ToString();
                        txtshift.Text = Row["SHIFT"].ToString();
                        txtcategory.Text = Row["TYPE"].ToString();
                       // txtdiscount.Text = Row["CONCESSION_FEE"].ToString();
                        txtamount.Focus();

                        rs = SYS.Show_Query("Select * from class where c_id='" + Row["c_id"].ToString() + "'");
                        foreach (DataRow Row1 in rs.Tables[0].Rows)
                        {
                            txtclass.Text = Row1["c_name"].ToString();
                        }

                    }
                }

            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.Message);


            }
            finally
            {

            }
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtvno.Text.Length > 0)
                {
                    this.eDIT_VOUCHERTableAdapter.FillBy1NEW(this.report_DataSet_new.EDIT_VOUCHER, ((decimal)(System.Convert.ChangeType(txtvno.Text, typeof(decimal)))), ((decimal)(System.Convert.ChangeType(SYSTEMSETTING.sessionid, typeof(decimal)))));
                    DataSet rs = new DataSet();
                    rs = SYS.Show_Query("select REMARKS, s_id from FEE_MASTER where FEE_MASTER_ID='" + txtvno.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                    foreach (DataRow RowDocument in rs.Tables[0].Rows)
                    {
                        txtremarks.Text = RowDocument[0].ToString();
                        Student_Detail(RowDocument[1].ToString());
                    }

                }
                else
                {
                    SYS.setCreateError("Please Enter Voucher Number");
                    txtvno.Focus();
                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void eDIT_VOUCHERBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.eDIT_VOUCHERBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.report_DataSet_new);
                SYS.setMessageBox("Record Updated", 1);
            }
            catch (Exception)
            {


            }
        }


        private void eDIT_VOUCHERBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            if (txtvno.Text.Length > 0)
            {

                this.Validate();
                this.eDIT_VOUCHERBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.report_DataSet_new);
                _class.FEE fee = new _class.FEE();
                fee.BalanceVoucher(txtvno.Text);
                SYS.setMessageBox("Record Updated", 1);

            }
            else
            {
                SYS.setCreateError("Please Enter Voucher Number");
                txtvno.Focus();
            }

        }

        private void Frm_editfee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'report_DataSet_new.Fee_Head' table. You can move, or remove it, as needed.
            this.fee_HeadTableAdapter.Fill(this.report_DataSet_new.Fee_Head);

        }

        private void btnprint_Click(object sender, EventArgs e)
        {

            if (txtvno.Text.Length > 0)
            {
                Frm_Vouchers frm = new Frm_Vouchers();
                frm.voucherno = txtvno.Text;
                frm.param = "voucherno";
                frm.sessionid = SYSTEMSETTING.sessionid;
                frm.Show();
            }
            else
            {
                SYS.setCreateError("Please Enter Voucher Number");
                txtvno.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtvno.Text.Length > 0)
            {
                this.eDIT_VOUCHERTableAdapter.FillBy1NEW(this.report_DataSet_new.EDIT_VOUCHER, ((decimal)(System.Convert.ChangeType(txtvno.Text, typeof(decimal)))), ((decimal)(System.Convert.ChangeType(SYSTEMSETTING.sessionid, typeof(decimal)))));
                // this.SYS.comboFill(this.cmbfine, "select Fee_head_id,FEE_HEAD from FEE_HEAD WHERE Category='FINE'", "FEE_HEAD", "FEE_HEAD", "Fee_head_id");
                this.SYS.comboFill(this.cmbfine, "select Fee_head_id,FEE_HEAD from FEE_HEAD where branch_id='" + SYSTEMSETTING.branch_ID + "'", "FEE_HEAD", "FEE_HEAD", "Fee_head_id");
                this.panel3.Visible = true;

            }
            else
            {
                SYS.setCreateError("Please Enter Voucher Number");
                txtvno.Focus();
            }
        }


        private void btncancel_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            DataSet rs = new DataSet();
            if (txtamount.Text.Length > 0)
            {

                bool a = false;
                string fineid = "";

                rs = SYS.Show_Query("select Fee_head_id from FEE_DETAIL where FEE_MASTER_ID='" + txtvno.Text + "' AND Fee_head_id='" + cmbfine.SelectedValue.ToString() + "'");

                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    fineid = RowDocument[0].ToString();
                }

                if (fineid == "")
                {
                    rs = SYS.Show_Query("select * from FEE_MASTER where FEE_MASTER_ID='" + txtvno.Text + "' AND PAID is NULL and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                    foreach (DataRow RowDocument in rs.Tables[0].Rows)
                    {
                        a = SYS.Insert_Query("insert into FEE_DETAIL(FEE_MASTER_ID,Fee_head_id,AMOUNT,FEE_MONTH,BALANCE,ISCURRENT,FEE_MONTH_FROM,SESSIONID,branch_id)values('" + txtvno.Text + "','" + cmbfine.SelectedValue + "','" + txtamount.Text + "','" + RowDocument["FEE_MONTH"] + "','" + txtamount.Text + "','Y','" + RowDocument["FEE_MONTH"] + "', '" + SYSTEMSETTING.sessionid + "','" + SYSTEMSETTING.branch_ID + "')");

                    }
                }
                else
                {
                    SYS.setCreateError("Fine Already exist!");
                }

                if (a == true)
                {
                    _class.FEE fee = new _class.FEE();
                    fee.BalanceVoucher(txtvno.Text);
                    SYS.setMessageBox("Record Updated", 1);
                    this.eDIT_VOUCHERTableAdapter.FillBy1NEW(this.report_DataSet_new.EDIT_VOUCHER, ((decimal)(System.Convert.ChangeType(txtvno.Text, typeof(decimal)))), ((decimal)(System.Convert.ChangeType(SYSTEMSETTING.sessionid, typeof(decimal)))));
                }
                else
                {
                    SYS.setCreateError("Record not updated please try again!");
                }

            }
            else
            {
                SYS.setCreateError("Please Enter Fine Amount!");
                txtamount.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool a = false;
            a = SYS.Insert_Query("Update FEE_MASTER SET REMARKS='" + txtremarks.Text + "' WHERE FEE_MASTER_ID='" + txtvno.Text + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
            if (a == true)
            {
                SYS.setMessageBox("Remarks Updated!", 1);
            }
            else
            {
                SYS.setMessageBox("Sorry Remarks Not Updated!", 3);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxCard_Enter(object sender, EventArgs e)
        {

        }

      




    }
}
