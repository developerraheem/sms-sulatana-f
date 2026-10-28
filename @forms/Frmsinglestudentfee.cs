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
    public partial class Frmsinglestudentfee : Form
    {
        public Frmsinglestudentfee()
        {
            InitializeComponent();
        }
        _class.clsODBC clsCon = new School._class.clsODBC();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        _class.clsODBC cls_Con = new School._class.clsODBC();
        OleDbCommand cmdForm = new OleDbCommand();
        int master_id, detail_id;
        private void Frmsinglestudentfee_Load(object sender, EventArgs e)
        {
            try
            {
                combo_Emp();
                LoadStudents();
              //  this.fee_ClassTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Class, new System.Nullable<int>(((int)(System.Convert.ChangeType(comboBox1.SelectedValue.ToString(), typeof(int))))));
               // this.classTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet._class);
              //  this.fee_HeadTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Head);

                this.LoadFIne();

            }
            catch (Exception exp)
            {

            }
        }

        private void LoadFIne()
        {


            this.cls_Con.list_DataView("SELECT c.s_name, a.Fee_head, b.FINE_DATE, b.FEE_MONTH, b.FINE_AMOUNT, c.ADMISSION_NO, class.c_name FROM ((FINE_HISTORY AS b INNER JOIN Fee_Head AS a ON b.Fee_head_id = a.Fee_head_id) INNER JOIN student AS c ON b.S_ID = c.ADMISSION_NO) INNER JOIN class ON b.c_id = class.c_id where b.c_id='" + Convert.ToString(comboBox1.SelectedValue) + "' and FEE_MONTH='" + dpAe.Text + "' ORDER BY c.ADMISSION_NO", this.lstv_Student);

        }

        private void combo_Emp()
        {
            try
            {

                clsCon.comboFill(this.comboBox1, "select c_id,c_name from class order by c_id", "class", "c_name", "c_id");
            }
            catch (Exception exp)
            {

            }

        }
        private void LoadStudents()
        {
            try
            {


                clsCon.comboFill(this.cmbstudent, "Select s_id,ADMISSION_NO+ '-' +s_name as abc from student where c_id ='" + comboBox1.SelectedValue.ToString() + "' and active=true order by ADMISSION_NO", "class", "abc", "s_id");
            }
            catch (Exception exp)
            {

            }
        }

        private void btnproc_Click(object sender, EventArgs e)
        {


           

        }
        private void GenerateFee()
        {
            cls_Con.cn.Open();
            clsCon.connCheck();
            OleDbCommand cmd = cls_Con.cn.CreateCommand();
            OleDbTransaction trans = cls_Con.cn.BeginTransaction();
            cmd.Connection = cls_Con.cn;
            cmd.Transaction = trans;
            try
            {
                cmd.CommandText = "Select * from student where c_id ='" + comboBox1.SelectedValue.ToString() + "' and active=true and s_id='"+ cmbstudent.SelectedValue.ToString() +"'";
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                objAdapter1.SelectCommand = cmd;
                DataSet objDataset1 = new DataSet();
                objAdapter1.Fill(objDataset1, "Student");
                MASTER_ID();
                DETAIL_ID();

                foreach (DataRow row in objDataset1.Tables[0].Rows)
                {

                    //Fee master table entries of students

                    cmd.CommandText = ("Insert into FEE_MASTER(FEE_MASTER_ID,s_id,C_ID,FEE_MONTH) VALUES('" + master_id + "','" + row["s_id"].ToString() + "','" + comboBox1.SelectedValue.ToString() + "','" + dpAe.Text + "')");
                    cmd.ExecuteNonQuery();


                    // FEE CLASS HEADS TUTION FEE ENTRY --
                    // FEE_HEAD_ID = 2 FOR TUTION FEE

                    cmd.CommandText = ("Select * from FEE_CLASS WHERE C_ID='" + comboBox1.SelectedValue.ToString() + "' and ACTIVE=true and Fee_head_id ='2'");
                    OleDbDataAdapter dat = new OleDbDataAdapter();
                    dat.SelectCommand = cmd;
                    DataSet dst = new DataSet();
                    dat.Fill(dst, "FEE_CLASS");

                    foreach (DataRow row1 in dst.Tables[0].Rows)
                    {
                        cmd.CommandText = ("Insert into FEE_DETAIL(FEE_DETAIL_ID,FEE_MASTER_ID,Fee_head_id,AMOUNT) VALUES(" + detail_id + "," + master_id + ",'2'," + int.Parse(row["m_fee"].ToString()) + ")");
                        cmd.ExecuteNonQuery();
                        detail_id = Convert.ToInt32(detail_id + 1);
                    }




                    // FEE CLASS HEADS ENTRY CHILD RECORDS ENTRY

                    cmd.CommandText = ("Select * from FEE_CLASS WHERE C_ID='" + comboBox1.SelectedValue.ToString() + "' and ACTIVE=true and AMOUNT > 0  AND val(Fee_head_id) >2");
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "FEE_CLASS");

                    foreach (DataRow row1 in ds.Tables[0].Rows)
                    {
                        cmd.CommandText = ("Insert into FEE_DETAIL(FEE_DETAIL_ID,FEE_MASTER_ID,Fee_head_id,AMOUNT) VALUES(" + detail_id + "," + master_id + "," + row1["Fee_head_id"].ToString() + "," + row1["AMOUNT"].ToString() + ")");
                        cmd.ExecuteNonQuery();
                        detail_id = Convert.ToInt32(detail_id + 1);
                    }





                    // FINE TABLE LOOP

                    cmd.CommandText = ("Select * from FEE_CLASS WHERE C_ID='" + comboBox1.SelectedValue.ToString() + "' and ACTIVE=true");
                    OleDbDataAdapter dadapter = new OleDbDataAdapter();
                    dadapter.SelectCommand = cmd;
                    DataSet dset = new DataSet();
                    dadapter.Fill(dset, "FEE_CLASS");
                    foreach (DataRow Feerow in dset.Tables[0].Rows)
                    {

                        cmd.CommandText = ("SELECT * from FINE_HISTORY  where c_id='" + Convert.ToString(comboBox1.SelectedValue) + "' and FEE_MONTH='" + dpAe.Text + "' and s_id= '" + row["ADMISSION_NO"].ToString() + "' and Fee_head_id='" + Feerow["Fee_head_id"].ToString() + "'");
                        OleDbDataAdapter da1 = new OleDbDataAdapter();
                        da1.SelectCommand = cmd;
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1, "Fine_History");
                        foreach (DataRow row2 in ds1.Tables[0].Rows)
                        {
                            if (int.Parse(row2["FINE_AMOUNT"].ToString()) > 0)
                            {

                                cmd.CommandText = ("Insert into FEE_DETAIL(FEE_DETAIL_ID,FEE_MASTER_ID,Fee_head_id,AMOUNT) VALUES(" + detail_id + "," + master_id + "," + row2["Fee_head_id"].ToString() + "," + row2["FINE_AMOUNT"].ToString() + ")");
                                cmd.ExecuteNonQuery();
                                detail_id = Convert.ToInt32(detail_id + 1);
                            }
                        }

                    }



                    // Previous Balance Calculation hard code fee_head_id = 1

                    cmd.CommandText = ("Select * from FEE_CLASS WHERE C_ID='" + comboBox1.SelectedValue.ToString() + "' and ACTIVE=true ");
                    OleDbDataAdapter feeadapter = new OleDbDataAdapter();
                    feeadapter.SelectCommand = cmd;
                    DataSet feedset = new DataSet();
                    feeadapter.Fill(feedset, "FEE_CLASS");
                    foreach (DataRow classFeerow in feedset.Tables[0].Rows)
                    {

                        cmd.CommandText = "Select * from OpeningBalance where s_id='" + row["s_id"].ToString() + "' and Fee_head_id='" + classFeerow["Fee_head_id"].ToString() + "'";
                        OleDbDataAdapter da2 = new OleDbDataAdapter();
                        da2.SelectCommand = cmd;
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2, "OpeningBalance");
                        foreach (DataRow row3 in ds2.Tables[0].Rows)
                        {
                            if (int.Parse(row3["Balance"].ToString()) > 0)
                            {
                                cmd.CommandText = ("Insert into FEE_DETAIL(FEE_DETAIL_ID,FEE_MASTER_ID,Fee_head_id,AMOUNT) VALUES(" + detail_id + "," + master_id + ",'1'," + row3["Balance"].ToString() + ")");
                                cmd.ExecuteNonQuery();
                                detail_id = Convert.ToInt32(detail_id + 1);
                            }

                        }

                    }


                    master_id = Convert.ToInt32(master_id) + 1;
                }
                trans.Commit();
                MessageBox.Show("Fee Generated Successfuly");
                //  dr.Close();
                cmd.Dispose();


            }
            catch (Exception exp)
            {
                try
                {
                    trans.Rollback();
                    //                    clsCon.cn.Close();
                    clsCon.connCheck();
                }
                catch (Exception)
                {
                    clsCon.connCheck();
                }
                MessageBox.Show(exp.Message.ToString());
            }
            finally
            {
                clsCon.cn.Close();

            }


        }

        private void MASTER_ID()
        {
            try
            {

                int myID;
                clsCon.connCheck();
                OleDbCommand cmddr = new OleDbCommand("select max(val(FEE_MASTER_ID)) as ids from FEE_MASTER", clsCon.cn);
                OleDbDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        master_id = 1;
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                        master_id = myID;
                    }

                }
                dr.Close();
                clsCon.cn.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void DETAIL_ID()
        {
            try
            {

                int myID;
                clsCon.connCheck();
                OleDbCommand cmddr = new OleDbCommand("select max(val(FEE_DETAIL_ID)) as ids from FEE_DETAIL", clsCon.cn);
                OleDbDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        detail_id = 1;
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                        detail_id = myID;
                    }

                }
                dr.Close();
                clsCon.cn.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsCon.connCheck();
               // this.fee_ClassTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Fee_Class, new System.Nullable<int>(((int)(System.Convert.ChangeType(comboBox1.SelectedValue.ToString(), typeof(int))))));
                this.LoadFIne();
                LoadStudents();
               
            }
            catch (System.Exception ex)
            {
                //  System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnproc_Click_1(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("You Want to Generate Fee?", "Confrim".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                try
                {
                    clsCon.connCheck();
                    OleDbCommand cmddr = new OleDbCommand("Select FEE_MONTH,C_ID from FEE_MASTER WHERE C_ID ='" + comboBox1.SelectedValue.ToString() + "' and FEE_MONTH='" + dpAe.Text + "' and s_id='"+ cmbstudent.SelectedValue.ToString() +"'", clsCon.cn);
                    OleDbDataReader dr = cmddr.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Fee of Selected Student already generated for the selected Month");
                    }
                    else
                    {

                        GenerateFee();
                    }
                    dr.Close();

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());

                    //clsCon.cn.Close();
                }
                finally
                {

                    //clsCon.cn.Close();

                }
            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Vouchers frm = new Frm_Vouchers();
              //  frm.admissionno = txtadmNo.Text;
                frm.feemonth = dpAe.Text.ToString();
                frm.param = "AdmissionNo";
                frm.Show();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }


    }
}
