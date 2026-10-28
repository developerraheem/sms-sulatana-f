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
    public partial class frmDeleteVoucher : Form
    {

        SqlCommand cmdForm = new SqlCommand();
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        List<string> myListofQueries = new List<string>();
        DataSet rs = new DataSet();
        public frmDeleteVoucher()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void frmDeleteVoucher_Load(object sender, EventArgs e)
        {
            //lstv_Function();
            SYS.comboFill(this.comboBox1, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "'", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            SYS.comboFill(this.cmbsection, "SELECT [SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
        }

        private void lstv_Function()
        {
            this.SYS.Filllist_DataView("SELECT FEE_MASTER.FEE_MASTER_ID, FEE_MASTER.FEE_MONTH, class.c_name, student.s_name, student.ADMISSION_NO FROM student INNER JOIN (FEE_MASTER INNER JOIN class ON FEE_MASTER.C_ID = class.c_id) ON student.s_id = FEE_MASTER.s_id WHERE (((FEE_MASTER.STATUS) Is Null) and  FEE_MASTER.branch_id='" + SYSTEMSETTING.branch_ID + "' AND FEE_MASTER.SessionID= '" + SYSTEMSETTING.sessionid + "' AND ((FEE_MASTER.REC_AMOUNT) Is Null OR FEE_MASTER.REC_AMOUNT = 0))", this.lstv_Class);
        }

        private void lstv_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtvoucherno.Text = (this.lstv_Class.Items[lstv_Class.FocusedItem.Index].SubItems[0].Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtvoucherno.Text.Length > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this voucher ?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (MessageBox.Show("You are going to delete Voucher no '" + txtvoucherno.Text + "'", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        SqlConnection con = SYS.db_connect();
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        SqlTransaction trans = con.BeginTransaction();
                        cmd.Connection = con;
                        cmd.Transaction = trans;


                        try
                        {

                            string feemonth = "";
                            string STUDENTID = "";
                            string PAID = "";
                            string LASTVOUCHERNO = "";
                            rs = SYS.Show_Query("Select * from FEE_MASTER WHERE FEE_MASTER_ID='" + txtvoucherno.Text + "' and SessionID= '" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                            if (rs.Tables[0].Rows.Count > 0)
                            {

                                foreach (DataRow Row in rs.Tables[0].Rows)
                                {
                                    feemonth = Row["FEE_MONTH"].ToString();
                                    STUDENTID = Row["s_id"].ToString();
                                    PAID = Row["PAID"].ToString();
                                }
                            }

                            // GET LAST VOUCHER NUMBER
                            rs = SYS.Show_Query("Select FEE_MASTER_ID FROM FEE_MASTER WHERE s_id='" + STUDENTID + "' and FEE_MASTER_ID not in('" + txtvoucherno.Text + "') and SessionID= '" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' order by FEE_MASTER_ID");
                            foreach (DataRow Row in rs.Tables[0].Rows)
                            {
                                LASTVOUCHERNO = Row[0].ToString();
                            }

                            string STATUS = "";
                            if (LASTVOUCHERNO == "")
                            {
                                LASTVOUCHERNO = "0";
                            }


                            rs = SYS.Show_Query("Select FEE_MASTER_ID from FEE_MASTER WHERE FEE_MASTER_ID='" + LASTVOUCHERNO + "' AND PAID='N' and SessionID= '" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                            if (rs.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow Row in rs.Tables[0].Rows)
                                {
                                    STATUS = Row["FEE_MASTER_ID"].ToString();
                                }
                            }

                            if (STATUS == "")
                            {
                                // Last voucher not update

                            }
                            else
                            {
                                // Last voucher update

                                cmd.CommandText = "Update FEE_MASTER SET PAID=NULL WHERE FEE_MASTER_ID='" + LASTVOUCHERNO + "' AND PAID='N' and SessionID= '" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                                cmd.ExecuteNonQuery();

                            }
                            cmd.CommandText = "Delete from FEE_DETAIL where FEE_MASTER_ID='" + txtvoucherno.Text + "' and SessionID= '" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "Delete from FEE_MASTER where FEE_MASTER_ID='" + txtvoucherno.Text + "' and SessionID= '" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "Delete FROM FINE_HISTORY WHERE FEE_MASTER_ID='" + txtvoucherno.Text + "' and SessionID= '" + SYSTEMSETTING.sessionid + "'and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "delete from fee_history where VOUCHER_NO='" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "update FINE_HISTORY set active='Y' where branch_id='" + SYSTEMSETTING.branch_ID + "' and SessionID='" + SYSTEMSETTING.sessionid + "' and S_ID='" + STUDENTID + "' and FEE_MONTH='" + feemonth + "'";
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Voucher Deleted Successfuly");

                            trans.Commit();
                            con.Close();
                            txtvoucherno.Text = "";
                        }
                        catch (Exception exp)
                        {
                            trans.Rollback();
                            con.Close();

                        }

                    }

                }
            }
            else
            {
                MessageBox.Show("Please Select Voucher No from List");

            }

        }

        private void btndelall_Click(object sender, EventArgs e)
        {
            //where C_ID='" + comboBox1.SelectedValue + "' AND FEE_MONTH ='" + dpAe.Text + "'
            //SYS.Insert_Query("Delete from FEE_DETAIL ");
            //SYS.Insert_Query("Delete from FEE_MASTER ");

            string feemasterid = "";

            DataSet rs = new DataSet();
            string query = "select FEE_MASTER_ID from FEE_MASTER A, student B WHERE A.C_ID='" + comboBox1.SelectedValue + "' and A.FEE_MONTH='" + dpAe.Text + "' and A.SHIFT ='" + cmbshift.SelectedValue + "'  AND A.PAID IS NULL AND (A.REC_AMOUNT IS NULL OR A.REC_AMOUNT = 0) AND A.SessionID='" + SYSTEMSETTING.sessionid + "' and A.branch_id='" + SYSTEMSETTING.branch_ID + "' AND A.C_ID=B.c_id AND A.s_id=B.s_id AND A.SessionID=B.SessionID AND B.SECTION_ID='" + cmbsection.SelectedValue.ToString() + "'";
            rs = SYS.Show_Query(query);
            if (rs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    try
                    {
                        string feemonth = "";
                        string STUDENTID = "";
                        string PAID = "";
                        string LASTVOUCHERNO = "";
                        rs = SYS.Show_Query("Select * from FEE_MASTER WHERE FEE_MASTER_ID='" + RowDocument["FEE_MASTER_ID"].ToString() + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'");
                        if (rs.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow Row in rs.Tables[0].Rows)
                            {
                                feemonth = Row["FEE_MONTH"].ToString();
                                STUDENTID = Row["s_id"].ToString();
                                PAID = Row["PAID"].ToString();
                            }
                        }

                        // GET LAST VOUCHER NUMBER
                        query = "Select FEE_MASTER_ID FROM FEE_MASTER WHERE s_id='" + STUDENTID + "' and FEE_MASTER_ID not in('" + RowDocument["FEE_MASTER_ID"].ToString() + "') AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' order by FEE_MASTER_ID";
                        rs = SYS.Show_Query(query);
                        foreach (DataRow Row in rs.Tables[0].Rows)
                        {
                            LASTVOUCHERNO = Row[0].ToString();
                        }
                        string STATUS = "";
                        if (LASTVOUCHERNO == "")
                        {
                            LASTVOUCHERNO = "0";
                        }

                        query = "Select FEE_MASTER_ID from FEE_MASTER WHERE FEE_MASTER_ID='" + LASTVOUCHERNO + "' AND PAID='N' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                        rs = SYS.Show_Query(query);
                        if (rs.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow Row in rs.Tables[0].Rows)
                            {
                                STATUS = Row["FEE_MASTER_ID"].ToString();
                            }
                        }
                        if (STATUS == "")
                        {
                        }
                        else
                        {
                            query = "Update FEE_MASTER SET PAID=NULL WHERE FEE_MASTER_ID='" + LASTVOUCHERNO + "' AND PAID='N' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                            myListofQueries.Add(query);
                        }
                        query = "Delete from FEE_DETAIL where FEE_MASTER_ID='" + RowDocument["FEE_MASTER_ID"].ToString() + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                        myListofQueries.Add(query);

                        query = "Delete from FEE_MASTER where FEE_MASTER_ID='" + RowDocument["FEE_MASTER_ID"].ToString() + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                        myListofQueries.Add(query);

                        query = "Delete FROM FINE_HISTORY WHERE FEE_MASTER_ID='" + txtvoucherno.Text + "' AND SessionID='" + SYSTEMSETTING.sessionid + "' and branch_id='" + SYSTEMSETTING.branch_ID + "'";
                        myListofQueries.Add(query);

                    }
                    catch (Exception exp)
                    {

                    }
                }


                bool CHECK = false;
                string[] bulkqueries1 = myListofQueries.ToArray();
                CHECK = SYS.Insert_Query_manualcommit(bulkqueries1);
                if (CHECK == true)
                {
                    MessageBox.Show("Voucher Deleted Successfuly");
                }
                else
                {
                    SYS.setMessageBox("Voucher Not deleted", 3);
                }


            }


        }
    }
}
