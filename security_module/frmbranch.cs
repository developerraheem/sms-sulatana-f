using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace School._forms
{
    public partial class frmbranch : Form
    {

        SYSTEMSETTING SYS = new SYSTEMSETTING();
        DataSet rs = new DataSet();
        bool check = false;

        public frmbranch()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtbranchname.Text.Length > 0)
            {
                check = SYS.Insert_Query("Insert into branch(branch_name,branch_address,active,SHORT_CODE)VALUES('" + txtbranchname.Text + "','" + txtaddress.Text + "','" + cmbactive.Text + "','" + txtshortcode.Text + "')");

                if (check == true)
                {
                    txtbranchname.Text = "";
                    SYS.Filllist_DataView("SELECT [branch_id],[branch_name],[branch_address],[active], [SHORT_CODE] FROM [branch]", lstshift);
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Enter Section Name");
                txtbranchname.Focus();
            }
        }

        private void frmshift_Load(object sender, EventArgs e)
        {
            SYS.Filllist_DataView("SELECT [branch_id],[branch_name],[branch_address],[active],[SHORT_CODE] FROM [branch]", lstshift);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (lblshiftid.Text.Length > 0)
            {
                check = SYS.Insert_Query("Update branch set branch_name='" + txtbranchname.Text + "',branch_address='" + txtaddress.Text + "',SHORT_CODE='" + txtshortcode.Text + "' WHERE branch_id='" + lblshiftid.Text + "'");

                if (check == true)
                {
                    txtbranchname.Text = "";
                    SYS.Filllist_DataView("SELECT [branch_id],[branch_name],[branch_address],[active],[SHORT_CODE] FROM [branch]", lstshift);
                    SYS.setMessageBox("Department Updated Successfuly!", 1);
                    lblshiftid.Text = string.Empty;
                    txtshortcode.Text = string.Empty;
                    txtbranchname.Text = string.Empty;
                    txtaddress.Text = string.Empty;
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record");
                txtbranchname.Focus();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lblshiftid.Text.Length > 0)
            {
                check = SYS.Insert_Query("Delete from branch WHERE branch_id='" + lblshiftid.Text + "'");

                if (check == true)
                {
                    txtbranchname.Text = "";
                    SYS.Filllist_DataView("SELECT [branch_id],[branch_name],[branch_address],[active]FROM [branch]", lstshift);
                }
                else
                {

                }

            }
            else
            {
                MessageBox.Show("Please Select Record");
                txtbranchname.Focus();
            }
        }

        private void lstshift_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblshiftid.Text = (this.lstshift.Items[lstshift.FocusedItem.Index].SubItems[0].Text.Trim());
            this.txtbranchname.Text = (this.lstshift.Items[lstshift.FocusedItem.Index].SubItems[1].Text.Trim());
            this.txtaddress.Text = (this.lstshift.Items[lstshift.FocusedItem.Index].SubItems[2].Text.Trim());
            this.txtshortcode.Text = (this.lstshift.Items[lstshift.FocusedItem.Index].SubItems[4].Text.Trim());
            GetImage(lblshiftid.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        OpenFileDialog fd1 = new OpenFileDialog();
        OpenFileDialog fd2 = new OpenFileDialog();
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
                DialogResult dres1 = fd1.ShowDialog();
                if (dres1 == DialogResult.Abort)
                    return;
                if (dres1 == DialogResult.Cancel)
                    return;


                pictureBox2.Image = Image.FromFile(fd1.FileName);
                MemoryStream ms1 = new MemoryStream();
                pictureBox2.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                //MessageBox.Show(ms1.Length.ToString()); calculate image length
                pictureBox2.Image = Image.FromFile(fd1.FileName);


            }
            catch (Exception exp)
            {

            }
        }

        private void uploadpicture(string studentid)
        {
            try
            {

                if (pictureBox2.Image == null)
                {
                    SYS.setCreateError("Please Select Image");
                }
                else
                {
                    bool chk = false;
                    string query = string.Empty;
                    query = "Update branch set BranchLogo='" + ImageToBase64(pictureBox2.Image,
              System.Drawing.Imaging.ImageFormat.Png) + "'  where branch_id='" + studentid + "'";
                    chk = SYS.Insert_Query(query);
                    if (chk == true)
                    {
                        SYS.setMessageBox("Picture Uploaded!", 1);
                    }
                    else
                    {
                        SYS.setCreateError("Picture not Uploaded please try again");
                    }
                }

            }
            catch (Exception ex)
            {


            }

        }
        public string ImageToBase64(Image image,
         System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you sure you want to Remove Picture?", "Confrim".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {

                bool chk = false;
                string query = string.Empty;
                query = "Update student set BranchLogo='' where BranchLogo='" + lblshiftid.Text + "'";
                chk = SYS.Insert_Query(query);
                if (chk == true)
                {
                    SYS.setMessageBox("Logo Removed!", 1);
                    pictureBox2.Image = null;
                }
                else
                {
                    SYS.setCreateError("Picture not Removed please try again");
                }
            }
        }

        private void btnupdatepicture_Click(object sender, EventArgs e)
        {
            uploadpicture(lblshiftid.Text);
        }
        private void GetImage(string STUDENTID)
        {
            {
                try
                {
                    SqlConnection cn = SYS.db_connect();
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select BranchLogo from branch where branch_id = '" + STUDENTID + "'", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    //                    while (dr.Read())
                    if (dr.Read())
                    {
                        //textBox2.Text = dr[0].ToString();
                        pictureBox2.Image = Base64ToImage(dr[0].ToString());
                        //txt_student_id.Text = dr[1].ToString();

                        if (string.IsNullOrEmpty(dr[0].ToString()))
                        {
                            pictureBox2.Image = null;
                        }

                    }
                    else
                    {
                        pictureBox2.Image = null;
                    }
                    cn.Close();
                }
                catch (Exception)
                {
                    pictureBox2.Image = null;
                }

            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }



    }
}
