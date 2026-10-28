using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace School._forms
{
    public partial class Frmbackup : Form
    {
        public Frmbackup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand ocmd = new OleDbCommand();
 
string strConn = ConfigurationManager.ConnectionStrings["School.Properties.Settings.SchoolConnectionString"].ConnectionString.ToString();
OleDbConnection aConn = new OleDbConnection((strConn + ";Connection Timeout=300; pooling='true';Max Pool Size=300"));
aConn.Open();
string strQry = "backup database databasename to disk ='C:\\School.bak'";
try
{
   ocmd.CommandTimeout = 300;
   ocmd = new System.Data.OleDb.OleDbCommand(strQry, aConn);
   ocmd.ExecuteNonQuery();
}
catch (Exception exp)
{
    MessageBox.Show(exp.Message);
}
finally
{
   ocmd.Dispose();
   aConn.Close();
}
        }
    }
}
