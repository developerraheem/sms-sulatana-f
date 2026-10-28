using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
namespace School._class
{

    class clsODBC
    {
        //  public string str = "";//get the value for form what do Modify/Add

        /*================================================================
          * ***************************************************************/
        OleDbCommand cmdStock = new OleDbCommand();
        OleDbDataAdapter daStock;
        //public static  OdbcDataReader drStock;
        /*================================================================
         * **************************************************************/


        public OleDbConnection cn = new OleDbConnection(@"Provider=SQLOLEDB;Data Source=.;Integrated Security=SSPI;Initial Catalog=CAMPUS4;User ID=USERCIV;Password=ALLAH92*");
        //public OleDbConnection cn = new OleDbConnection(@"Provider=SQLOLEDB;Data Source=192.168.1.3;Integrated Security=SSPI;Initial Catalog=SchoolSQL;Password=pakistan2010;User ID=school_user");


        public void connCheck()
        {

            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Open();


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
        public void dataGridFill(string strQry, DataGridView dGV, string strTable)
        {
            try
            {


                connCheck();
                DataSet ds = new DataSet();
                ds.Clear();
                cmdStock = new OleDbCommand();
                cmdStock.Connection = cn;
                cmdStock.CommandText = strQry;
                daStock = new OleDbDataAdapter(strQry, cn);
                daStock.Fill(ds, strTable);
                dGV.DataSource = ds.Tables[strTable];
                cn.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);

            }

        }
        public void cmdOpen(OleDbCommand cmdFunction)
        {

            connCheck();
            cmdFunction.Connection = cn;

        }
        public void cmdClose(OleDbCommand cmdFunction)
        {

            cmdFunction.ExecuteNonQuery();
            cmdFunction.Parameters.Clear();
            cmdFunction.Connection.Close();
            cn.Close();

        }

        public void comboFill(ComboBox cmb, string strSQL, string dTable, string dDisplay, string dValue)
        {
            try
            {
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                //OleDbCommand cmd = new OleDbCommand();
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(strSQL, cn);
                da.Fill(ds, dTable);
                if (ds.Tables[dTable] != null && !string.IsNullOrEmpty(dDisplay) && ds.Tables[dTable].Columns.Contains(dDisplay))
                {
                    ds.Tables[dTable].DefaultView.RowFilter = string.Format("[{0}] IS NOT NULL AND [{0}] <> ''", dDisplay);
                }
                cmb.DataSource = ds.Tables[dTable].DefaultView;
                cmb.DisplayMember = dDisplay;
                cmb.ValueMember = dValue;
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }

        }
        public void list_DataView(string strSQL, ListView myList)
        {
            myList.Items.Clear();
            try
            {
                OleDbCommand cmd = new OleDbCommand(strSQL, cn);
                cn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem lItem = new ListViewItem(dr[0].ToString());
                    for (int i = 1; i <= dr.FieldCount - 1; i++)
                    {
                        lItem.SubItems.Add(dr[i].ToString());
                    }
                    myList.Items.Add(lItem);
                    int rCount = myList.Items.Count;
                    //if (rCount % 2 == 1)
                    //{
                    //    //lItem.BackColor = Color.WhiteSmoke;#6ABF10
                    //    lItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(234)))), ((int)(((byte)(189))))); 
                    //}
                    //else
                    //{
                    //    lItem.BackColor = Color.White;
                    //}
                }
                cn.Close();
                cmd.Dispose();
                dr.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                cn.Close();
            }

        }

        public void attd_students(DataGridView datagrid, double class_id)
        {
            cn.Open();
            OleDbDataReader reader;
            try
            {
                OleDbCommand command = cn.CreateCommand();
                command.CommandText = "Select c_id,s_id,roll_no,s_name from student where c_id='" + class_id + "'";
                reader = command.ExecuteReader();
                datagrid.Rows.Clear();
                while (reader.Read())
                {
                    datagrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
                reader.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {
                cn.Close();
            }


        }
        public void Fee_Head(DataGridView datagrid)
        {
            cn.Open();
            OleDbDataReader reader;
            try
            {
                OleDbCommand command = cn.CreateCommand();
                //OleDbTransaction trans = new OleDbTransaction();
                //trans = cn.BeginTransaction();
                //command.Connection = cn;
                //command.Transaction = trans;

                command.CommandText = "Select Fee_head_id,Fee_head,Type,Amount from Fee_Head where Active_flag ='Yes'";
                reader = command.ExecuteReader();
                datagrid.Rows.Clear();
                while (reader.Read())
                {
                    datagrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
                reader.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {
                cn.Close();
            }


        }
        public void Fee_Class(DataGridView datagrid, string classid)
        {
            cn.Open();
            OleDbDataReader reader;
            try
            {
                OleDbCommand command = cn.CreateCommand();
                command.CommandText = "Select FEE_CLASS_ID,Fee_head_id,AMOUNT,ACTIVE from Fee_Class where c_id='" + classid + "'";
                reader = command.ExecuteReader();
                datagrid.Rows.Clear();
                while (reader.Read())
                {
                    datagrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
                reader.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            finally
            {
                cn.Close();
            }


        }
        public void textClear(Form frm)
        {
            foreach (Control ctl in frm.Controls)
            {
                if (ctl is TextBox)
                    ctl.Text = "";
            }
        }

        public DataSet Show_Query(string query)
        {

            DataSet DataSet1 = new DataSet();
            using (cn)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, cn);
                try
                {
                    connCheck();
                    adapter.Fill(DataSet1);
                    cn.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            return DataSet1;
        }

        public bool Insert_Query(string query)
        {
            bool check = false;
            check = false;
            DataSet DataSet1 = new DataSet();
            using (cn)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, cn);
                try
                {
                    cn.Open();
                    adapter.Fill(DataSet1);
                    cn.Close();
                    check = true;
                }
                catch (Exception ex)
                {

                    check = false;
                }
            }
            return check;
        }


        public bool Insert_Query_manualcommit(string[] queryDetails)
        {

            bool check = false;
            check = false;
            using (cn)
            {

                OleDbCommand command = new OleDbCommand();
                OleDbTransaction transaction = default(OleDbTransaction);
                command.Connection = cn;
                try
                {
                    cn.Open();
                    transaction = cn.BeginTransaction();
                    command.Connection = cn;
                    command.Transaction = transaction;
                    int i = 0;

                    while (i < queryDetails.Length)
                    {
                        command.CommandText = queryDetails.GetValue(i).ToString();
                        command.ExecuteNonQuery();

                        i = i + 1;
                    }
                    transaction.Commit();
                    check = true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    check = false;
                    try
                    {
                        transaction.Rollback();

                    }
                    catch
                    {
                    }
                }

            }

            return check;
        }



    }
}
