using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School.Reports
{
    public partial class RPT_DEFAULTER_READMISSION : Form
    {
        public RPT_DEFAULTER_READMISSION()
        {
            InitializeComponent();
        }

        private void RPT_DEFAULTER_READMISSION_Load(object sender, EventArgs e)
        {
            // this.dEFAULTER_READMISSIONTableAdapter.Fill(this.dataSet_Fee_Summary_Reports.DEFAULTER_READMISSION);
            SYSTEMSETTING SYS = new SYSTEMSETTING();
            SYS.comboFill(this.cmbfeetype, "select Fee_head_id,Fee_head from Fee_Head where Category='FINE'", "Fee_Head", "Fee_head", "Fee_head_id");


        }

        private void btnmonth_Click(object sender, EventArgs e)
        {
            try
            {
                this.dEFAULTER_READMISSIONTableAdapter.FillBy1(this.dataSet_Fee_Summary_Reports.DEFAULTER_READMISSION, SYSTEMSETTING.sessionid, ((decimal)(System.Convert.ChangeType(txtmonths.Text, typeof(decimal)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            this.reportViewer1.RefreshReport();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SYSTEMSETTING SYS = new SYSTEMSETTING();
            DataSet rs = new DataSet();
            string query = string.Empty;
            int newID = 0;
            string HHISTORYID = string.Empty;

            rs = SYS.Show_Query("select max(CONVERT(INT, FINE_ID)) as ids from FINE_HISTORY WHERE sessionid='" + SYSTEMSETTING.sessionid + "'");
            foreach (DataRow RowDocument in rs.Tables[0].Rows)
            {
                HHISTORYID = RowDocument[0].ToString();
            }
            if (HHISTORYID == "")
            {
                HHISTORYID = "1";
            }

            newID = int.Parse(HHISTORYID);

            SqlConnection con = SYS.db_connect();
            con.Open();
            SqlCommand cmddr;
            SqlDataReader dr;
            //query = "select a.c_id,c.c_name,a.s_id, b.s_name,count(*) as totalmonths from FEE_MASTER a, student b, class c where (PAID is null or PAID='N') and a.s_id=b.s_id and a.C_ID=b.c_id and b.c_id=c.c_id";
            //query = query + " AND B.SessionID='" + SYSTEMSETTING.sessionid + "' group by a.c_id,c.c_name,a.s_id ,b.s_name having count(*)> '" + txtmonths.Text + "' order by c_id";

            query = "select a.c_id,c.c_name,a.s_id, b.s_name,count(*) as totalmonths from FEE_MASTER a, student b, class c where (PAID is null OR PAID='N') and a.s_id=b.s_id and a.C_ID=b.c_id AND A.C_ID=C.c_id  and a.SessionID=b.SessionID";
            query = query + " AND B.SessionID='" + SYSTEMSETTING.sessionid + "' AND A.FEE_MASTER_ID > (select MAX(FEE_MASTER_ID) from FEE_MASTER HH where s_id=a.s_id AND (STATUS='Y')) group by a.c_id,c.c_name,a.s_id ,b.s_name having count(*)='" + txtmonths.Text + "' order by c_id";
            
            rs = SYS.Show_Query(query);
            foreach (DataRow RowDocument in rs.Tables[0].Rows)
            {


                cmddr = new SqlCommand("select * from FINE_HISTORY WHERE sessionid='" + SYSTEMSETTING.sessionid + "' and S_ID='" + RowDocument["s_id"].ToString() + "' and FEE_MONTH='" + txtfeemonth.Text + "' and Fee_head_id='" + cmbfeetype.SelectedValue + "' ", con);
                dr = cmddr.ExecuteReader();

                if (dr.Read())
                {
                    //MessageBox.Show("Fine already saved");
                }
                else
                {
                    query = "insert into FINE_HISTORY(FINE_ID,S_ID,Fee_head_id,FINE_DATE,FINE_AMOUNT,FEE_MONTH,c_id,active,SessionID) values ('" + newID + "','" + RowDocument["s_id"].ToString() + "','" + cmbfeetype.SelectedValue + "','" + DateTime.Today.ToShortDateString() + "','" + txtamount.Text.Trim() + "','" + txtfeemonth.Text + "','" + RowDocument["c_id"].ToString() + "','Y','" + SYSTEMSETTING.sessionid + "')";
                    SYS.Insert_Query(query);
                    newID = newID + 1;
                }


            }
            MessageBox.Show("Fine Generated!");
            con.Close();

        }

        public void Fine_ID()
        {
            try
            {
                SYSTEMSETTING SYS = new SYSTEMSETTING();
                int myID;
                string newID;
                SqlConnection con = SYS.db_connect();
                con.Open();
                SqlCommand cmddr = new SqlCommand("select max(CONVERT(INT, FINE_ID)) as ids from FINE_HISTORY WHERE sessionid='" + SYSTEMSETTING.sessionid + "' ", con);
                SqlDataReader dr = cmddr.ExecuteReader();

                while (dr.Read())
                {
                    string strid = dr["ids"].ToString();
                    if (strid == "")
                    {
                        newID = "1";
                    }
                    else
                    {
                        myID = Convert.ToInt32(dr["ids"]) + 1;
                        newID = myID.ToString();
                    }

                }
                dr.Close();
                con.Close();
                cmddr.Dispose();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

    }
}
