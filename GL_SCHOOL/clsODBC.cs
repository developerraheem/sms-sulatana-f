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
        OleDbDataAdapter  daStock;
        //public static  OdbcDataReader drStock;
        /*================================================================
         * **************************************************************/



        public OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\School\App_Data\School.mdb;Persist Security Info=False;Jet OLEDB:Database Password=allah786");
       //public OleDbConnection cn = new OleDbConnection(@"Provider=SQLOLEDB;Data Source=HARRIS-PC;Initial Catalog=C:\USERS\ADMINISTRATOR\DOWNLOADS\COMPRESSED\SMS\SMS\APP_DATA\DATABASE.MDF;Integrated Security=SSPI;Encrypt=False");
              

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
                daStock = new OleDbDataAdapter (strQry, cn);
                daStock.Fill(ds, strTable);
                dGV.DataSource = ds.Tables[strTable];
                cn.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);

            }

        }
        public void cmdOpen(OleDbCommand  cmdFunction)
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
                cmb.DataSource = ds.Tables[dTable].DefaultView;
                cmb.DisplayMember = dDisplay;
                cmb.ValueMember = dValue;
            }
            catch (Exception exp)
            {
               // MessageBox.Show(exp.Message);
            }

        }
        public  void list_DataView(string strSQL, ListView myList)
        {
            myList.Items.Clear();
            try
            {
                OleDbCommand cmd = new OleDbCommand(strSQL, cn);
                cn.Open();
                OleDbDataReader  dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem lItem = new ListViewItem(dr[0].ToString());
                    for (int i = 1; i <= dr.FieldCount - 1; i++)
                    {
                        lItem.SubItems.Add(dr[i].ToString());
                    }
                    myList.Items.Add(lItem);
                    int rCount = myList.Items.Count;
                    if (rCount % 2 == 1)
                    {
                        //lItem.BackColor = Color.WhiteSmoke;
                        lItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(234)))), ((int)(((byte)(189))))); 
                    }
                    else
                    {
                        lItem.BackColor = Color.White;
                    }
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

        public void attd_students(DataGridView datagrid,double class_id)
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
           catch(Exception exp)
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
                command.CommandText = "Select FEE_CLASS_ID,Fee_head_id,AMOUNT,ACTIVE from Fee_Class where c_id='"+ classid +"'";
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


        public void SaveMainGroupCode(int USERID, string NAME, string PASSWORD, int USERTYPE, string EMAIL)
        {
            connCheck();
            try
            {
                OleDbCommand cmd = cn.CreateCommand();
                cmd.CommandText = "insert into USERS(USER_ID,USER_NAME,PASSWORD,USER_TYPE,EMAIL) VALUES('" + USERID + "','" + NAME + "','" + PASSWORD + "','" + USERTYPE + "','" + EMAIL + "')";
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Save Successfully");
                }
                else
                {
                    MessageBox.Show("Sorry Not saved");
                }
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

        public OleDbDataReader GetMaxNo(string Param)
        {
            OleDbDataReader objDataReader;
            connCheck();
            
                          
                string strQuery = "";
                if (Param.Equals("MainGroupCode"))
                {
                    strQuery = "select max(val(MAIN_GROUP_CODE)) as ids from ACT_MAINGROUP";
                }
                if (Param.Equals("SubGroupCode"))
                {
                    strQuery = "select max(USER_ID)+1 AS MAXIMUM FROM USERS";
                }
                OleDbCommand objcmd = new OleDbCommand(strQuery, cn);
                objDataReader = objcmd.ExecuteReader(CommandBehavior.CloseConnection);
               


                 return objDataReader;
        }


    }
}
