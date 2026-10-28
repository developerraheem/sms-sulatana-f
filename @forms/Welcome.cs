using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }
        public string user= "";
        int z;//Variable for Progressbar Value
        //frm_login frmlogin = new frm_login();
        private void Welcome_Load(object sender, EventArgs e)
        {
            lbluser.Text = user.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void btnacedamics_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
               
            MDI_Admissions frm = null;
            if ((frm = (MDI_Admissions)IsFormAlreadyOpen(typeof(MDI_Admissions))) == null)
            {
                frm = new MDI_Admissions();
                frm.Show();
            }
            else
                MessageBox.Show("Application Already Open", "TSI Software");
        }
        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            GL_SCHOOL.FrmAcc_Main frm = null;
            if ((frm = (GL_SCHOOL.FrmAcc_Main)IsFormAlreadyOpen(typeof(GL_SCHOOL.FrmAcc_Main))) == null)
            {
                frm = new GL_SCHOOL.FrmAcc_Main();
                frm.Show();
            }
            else
                MessageBox.Show("Application Already Open", "TSI Software");
          
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Welcome_Resize(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Information!";
            notifyIcon1.BalloonTipText = "Application is Running. .";

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Maximized == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            MDI_Fee frm = null;
            if ((frm = (MDI_Fee)IsFormAlreadyOpen(typeof(MDI_Fee))) == null)
            {
                frm = new MDI_Fee();
                frm.Show();
            }
            else
                MessageBox.Show("Application Already Open", "TSI Software");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            MDI_Attendance frm = null;
            if ((frm = (MDI_Attendance)IsFormAlreadyOpen(typeof(MDI_Attendance))) == null)
            {
                frm = new MDI_Attendance();
                frm.Show();
            }
            else
                MessageBox.Show("Application Already Open", "TSI Software");
        }

      

        
        }

        
    }
