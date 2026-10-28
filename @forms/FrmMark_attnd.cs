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
    public partial class FrmMark_attnd : Form
    {
        public FrmMark_attnd()
        {
            InitializeComponent();
        }
        _class.clsODBC clsCon = new School._class.clsODBC();
        _class.cls_myFunctions clsmyFunction = new School._class.cls_myFunctions();
        _class.clsODBC cls_Con = new School._class.clsODBC();
        OleDbCommand cmdForm = new OleDbCommand();
        SYSTEMSETTING SYS = new SYSTEMSETTING();

         
        //private FrmMark_attnd mainForm = null;
        //  public RptDaily_attand(Form callingForm)
        //{
        //    mainForm = callingForm as FrmMark_attnd; 
        //    InitializeComponent();
        //}
        private void FrmMark_attnd_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.ATTND' table. You can move, or remove it, as needed.
            this.aTTNDTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.ATTND);
            combo_Emp();
            try
            {
                this.mark_AttndTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Mark_Attnd, comboBox1.SelectedValue.ToString(), dpAe.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void combo_Emp()
        {
            SYS.comboFill(this.comboBox1, "select c_id,c_name from class ORDER BY c_id", "class", "c_name", "c_id");

        }

        private void mark_AttndBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            

        }

               private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.mark_AttndTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Mark_Attnd, comboBox1.SelectedValue.ToString(), dpAe.Text);
            }
            catch (System.Exception ex)
            {
             //   System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            RptDaily_attand rpt = new RptDaily_attand(this);
            rpt.Show();
          
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string Classid
        {
            get { return comboBox1.SelectedValue.ToString(); }
            set { comboBox1.SelectedValue = value; }
        }
        public string Date
        {
            get { return dpAe.Text; }
            set { dpAe.Text = value; }
        }

        private void mark_AttndDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int a = 0;
            OleDbCommand cmd = new OleDbCommand();
            this.cls_Con.cmdOpen(cmd);
            string dto = Convert.ToDateTime(dpAe.Text).ToShortDateString();
            cmd.CommandText = "Select * from att_stu where c_id='" + comboBox1.SelectedValue.ToString() + "' and att_date='" + dpAe.Text + "'";
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Attandence of This Class already marked for the day");
                try
                {
                    this.mark_AttndTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Mark_Attnd, comboBox1.SelectedValue.ToString(), dpAe.Text);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }

            else
            {
                dr.Close();
                try
                {

                    cmd.CommandText = "select * from student where c_id='" + comboBox1.SelectedValue.ToString() + "' and active = 'true'";
                    OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
                    objAdapter1.SelectCommand = cmd;
                    DataSet objDataset1 = new DataSet();
                    objAdapter1.Fill(objDataset1, "student");
                    //If ds.Tables(0).Rows.Count > 0 Then
                    if (objDataset1.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow row in objDataset1.Tables[0].Rows)
                        {
                            cmd.CommandText = "insert into att_stu(s_id,c_id,att_status,att_date,remarks,ADMISSION_NO) values('" + row["s_id"].ToString() + "', '" + comboBox1.SelectedValue.ToString() + "','P','" + dpAe.Text + "','','" + row["ADMISSION_NO"].ToString() + "')";
                            a = cmd.ExecuteNonQuery();

                        }
                        if (a > 0)
                        {
                            MessageBox.Show("Attandence Marked");
                            try
                            {
                                this.mark_AttndTableAdapter.Fill(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet.Mark_Attnd, comboBox1.SelectedValue.ToString(), dpAe.Text);
                            }
                            catch (System.Exception ex)
                            {
                                //   System.Windows.Forms.MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Student Not Found in Selected Class");
                    }


                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString());
                }
                finally
                {

                }

            }
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.mark_AttndBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet);
                MessageBox.Show("Attandence Record Updated");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
               
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            RptDaily_attand rpt = new RptDaily_attand(this);
            rpt.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

               private void mark_AttndBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.mark_AttndBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._C__USERS_ADMINISTRATOR_DOWNLOADS_COMPRESSED_SMS_SMS_APP_DATA_DATABASE_MDFDataSet);

        }

        private void fillToolStripButton_Click_2(object sender, EventArgs e)
        {
            try
            {
            
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
