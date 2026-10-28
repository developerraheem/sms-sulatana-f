using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for SYSTEMSETTING
/// </summary>
public class SYSTEMSETTING
{
    public static string sUserName;
    public static string sessionid;
    public static string sessionname;
    public static string schoolname;
    public static string branch_address;
    public static string branch_ID;
    public static string branch_name;
    public static string user_type;

	public SYSTEMSETTING()
	{
		//
		// TODO: Add constructor logic here
		//

	}
    
    public SqlConnection  db_connect()
    {
        string connectionString = null;
        SqlConnection connection = default(SqlConnection);
        if (ConfigurationManager.ConnectionStrings["Sqlconn"] != null)
        {
            connectionString = ConfigurationManager.ConnectionStrings["Sqlconn"].ConnectionString.ToString();
        }
        else
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;";
        }
        connection = new SqlConnection(connectionString);
        return connection;
    }

    public DataSet Show_Query(string query)
    {
        SqlConnection connection = db_connect();
        DataSet DataSet1 = new DataSet();
        using (connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            try
            {
                connection.Open();
                adapter.Fill(DataSet1);
                connection.Close();
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
        SqlConnection connection = db_connect();
        DataSet DataSet1 = new DataSet();
        using (connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            try
            {
                connection.Open();
                adapter.Fill(DataSet1);
                connection.Close();
                check = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        return check;
    }
    public SqlDataReader dr;
    public SqlCommand cmd;
    public SqlDataReader Get_Reader(string strQuery)
    {
        SqlConnection con = db_connect();

        try
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            cmd = new SqlCommand(strQuery, con);
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            // dr.Close();
            con.Close();
        }
        finally
        {
        }
        return dr;
        con.Close();
    }
    public bool Insert_Query_manualcommit(string[] queryDetails)
    {

        bool check = false;
        check = false;
        SqlConnection connection = db_connect();

        using (connection)
        {

            SqlCommand command = new SqlCommand();
            SqlTransaction transaction = default(SqlTransaction);
            command.Connection = connection;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;
                int i = 0;

                while (i < queryDetails.Length)
                {
               
                    //   System.Web.HttpContext.Current.Response.Write(queryDetails.GetValue(i));
                  //  MessageBox.Show(queryDetails.GetValue(i).ToString());
                  command.CommandText = queryDetails.GetValue(i).ToString();
                  command.ExecuteNonQuery();

                    i = i + 1;
                }
                transaction.Commit();
                check = true;

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
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

    public void FillDataGrid(string strQry, DataGridView dGV, string strTable)
    {
        try
        {
            SqlCommand cmdStock = new SqlCommand();
            SqlDataAdapter daStock;
            SqlConnection cn = db_connect();
            DataSet ds = new DataSet();
            ds.Clear();
            using (cn)
            {
                cmdStock = new SqlCommand();
                cn.Open();
                cmdStock.Connection = cn;
                cmdStock.CommandText = strQry;
                daStock = new SqlDataAdapter(strQry, cn);
                daStock.Fill(ds, strTable);
                dGV.DataSource = ds.Tables[strTable];
                cn.Close();
            }
        }
        catch (Exception exp)
        {
            MessageBox.Show(exp.Message);

        }

    }

    public void Filllist_DataView(string strSQL, ListView myList)
    {
        myList.Items.Clear();
        try
        {
            SqlConnection cn = db_connect();
            SqlCommand cmd = new SqlCommand(strSQL, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
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
          //  MessageBox.Show(exp.Message);
            
        }

    }
 
    public void comboFill(ComboBox cmb, string strSQL, string dTable, string dDisplay, string dValue)
    {
        try
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            SqlConnection cn = db_connect();
            DataSet ds = new DataSet();
            using (cn)
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, cn);
                da.Fill(ds, dTable);
                if (ds.Tables[dTable] != null && !string.IsNullOrEmpty(dDisplay) && ds.Tables[dTable].Columns.Contains(dDisplay))
                {
                    ds.Tables[dTable].DefaultView.RowFilter = string.Format("[{0}] IS NOT NULL AND [{0}] <> ''", dDisplay);
                }
                cmb.DataSource = ds.Tables[dTable].DefaultView;
                cmb.DisplayMember = dDisplay;
                cmb.ValueMember = dValue;
                cn.Close();
            }
        }
        catch (Exception exp)
        {
         //   MessageBox.Show(exp.Message);
        }

    }
    string sMessageBox = "[School Management System]";
    public void setMessageBox(string sMessage, int iWhich)
    {
        switch (iWhich)
        {
            case 1:
                MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                break;
            case 2:
                MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                break;
            case 3:
                MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
        }
    }

    public void setCreateError(string sErrorMessage)
    {
        try
        {
            MessageBox.Show(sErrorMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

}