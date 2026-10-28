using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School._forms
{
    public partial class frm_manage_students : Form
    {
        public frm_manage_students()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
            ConfigureStudentListView();
            ApplyModernFilterStyles();
        }

        SYSTEMSETTING SYS = new SYSTEMSETTING();

        private void ApplyModernFilterStyles()
        {
            this.panel4.Height = 222;
            this.panelSearchCard.BackColor = Color.White;
            this.panelSearchCard.Paint += panelSearchCard_Paint;
            this.Resize += (s, e) => LayoutFilterArea();

            // Radio buttons styling
            RadioButton[] rdos = new RadioButton[] { rdo_Class, rdobyname, rdobyadmission, rdo_All, rdoinactive, RDOSCL, rdopromotion };
            foreach (RadioButton rdo in rdos)
            {
                rdo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                rdo.ForeColor = Color.FromArgb(30, 41, 59);
                rdo.Cursor = Cursors.Hand;
                rdo.CheckedChanged += (s, e) => {
                    RadioButton rb = s as RadioButton;
                    if (rb != null && rb.Checked)
                    {
                        rb.ForeColor = Color.FromArgb(8, 120, 61);
                    }
                    else if (rb != null)
                    {
                        rb.ForeColor = Color.FromArgb(71, 85, 105);
                    }
                    panelSearchCard.Invalidate();
                };
            }

            rdo_Class.Text = "By Class";
            rdobyname.Text = "By Name";
            rdobyadmission.Text = "By Admission No";
            rdo_All.Text = "View All";
            rdoinactive.Text = "In-Active";
            RDOSCL.Text = "SLC";
            rdopromotion.Text = "Promotion Type";

            // Action Buttons styling
            btnadd.FlatStyle = FlatStyle.Flat;
            btnadd.FlatAppearance.BorderSize = 0;
            btnadd.BackColor = Color.FromArgb(8, 120, 61);
            btnadd.ForeColor = Color.White;
            btnadd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnadd.Cursor = Cursors.Hand;

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.FromArgb(8, 120, 61);
            button1.FlatAppearance.BorderSize = 1;
            button1.BackColor = Color.FromArgb(240, 253, 244);
            button1.ForeColor = Color.FromArgb(8, 120, 61);
            button1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button1.Cursor = Cursors.Hand;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            button2.FlatAppearance.BorderSize = 1;
            button2.BackColor = Color.FromArgb(248, 250, 252);
            button2.ForeColor = Color.FromArgb(51, 65, 85);
            button2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button2.Cursor = Cursors.Hand;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            button3.FlatAppearance.BorderSize = 1;
            button3.BackColor = Color.FromArgb(248, 250, 252);
            button3.ForeColor = Color.FromArgb(51, 65, 85);
            button3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button3.Cursor = Cursors.Hand;

            // Total Badge
            lbltotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbltotal.BackColor = Color.FromArgb(232, 245, 233);
            lbltotal.ForeColor = Color.FromArgb(8, 120, 61);

            LayoutFilterArea();
        }

        private void LayoutFilterArea()
        {
            try
            {
                int pad = 20;
                int cardW = Math.Max(950, panel4.Width - (pad * 2));
                panelSearchCard.Location = new Point(pad, 58);
                panelSearchCard.Size = new Size(cardW, 100);

                // Row 1: By Class (with dropdowns), By Admission No (with textbox), In-Active, Session
                int rdo1Y = 8;
                int in1Y = 6;

                rdo_Class.Location = new Point(14, rdo1Y);
                com_Sclass.Location = new Point(92, in1Y);
                com_Sclass.Size = new Size(110, 26);
                com_Sclass.Visible = true;

                cmbshift.Location = new Point(207, in1Y);
                cmbshift.Size = new Size(95, 26);
                cmbshift.Visible = true;

                cmbsection.Location = new Point(307, in1Y);
                cmbsection.Size = new Size(65, 26);
                cmbsection.Visible = true;

                rdobyadmission.Location = new Point(385, rdo1Y);
                txtsadmissionno.Location = new Point(515, in1Y);
                txtsadmissionno.Size = new Size(110, 26);
                txtsadmissionno.Visible = true;

                rdoinactive.Location = new Point(635, rdo1Y);

                // Session dropdown (safely padded on far right)
                cmbselection.Location = new Point(cardW - 145, in1Y);
                cmbselection.Size = new Size(130, 26);

                // Row 2: By Name (with textbox), View All, SLC, Promotion Type (with dropdown)
                int rdo2Y = 56;
                int in2Y = 54;

                rdobyname.Location = new Point(14, rdo2Y);
                txtbyname.Location = new Point(92, in2Y);
                txtbyname.Size = new Size(280, 26);
                txtbyname.Visible = true;

                rdo_All.Location = new Point(385, rdo2Y);
                RDOSCL.Location = new Point(470, rdo2Y);

                rdopromotion.Location = new Point(530, rdo2Y);
                cmbpromot.Location = new Point(655, in2Y);
                cmbpromot.Size = new Size(110, 26);
                cmbpromot.Visible = true;

                // Row 3: Action Buttons (Y = 172)
                int btnY = 172;
                btnadd.Location = new Point(pad, btnY);
                btnadd.Size = new Size(140, 36);

                button2.Location = new Point(pad + 150, btnY);
                button2.Size = new Size(125, 36);

                button3.Location = new Point(pad + 285, btnY);
                button3.Size = new Size(150, 36);

                button1.Location = new Point(pad + 445, btnY);
                button1.Size = new Size(230, 36);

                // Total counter aligned safely relative to panelSearchCard.Right
                int rBound = panelSearchCard.Right;
                lbltotal.Location = new Point(rBound - 60, 15);
                lbltotal.Size = new Size(55, 26);
                label1.Location = new Point(lbltotal.Left - 110, 18);
            }
            catch { }
        }

        private void panelSearchCard_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                int w = panelSearchCard.Width;
                int h = panelSearchCard.Height;

                // 1. Card Outline
                using (Pen borderPen = new Pen(Color.FromArgb(209, 231, 221), 1.5F))
                using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, w - 1, h - 1), 8))
                {
                    g.DrawPath(borderPen, path);
                }

                // 2. Top filter strip background
                using (SolidBrush stripBrush = new SolidBrush(Color.FromArgb(248, 250, 252)))
                using (System.Drawing.Drawing2D.GraphicsPath topStrip = GetTopRoundedRectPath(new Rectangle(1, 1, w - 2, 38), 8))
                {
                    g.FillPath(stripBrush, topStrip);
                }

                // 3. Horizontal dividing line
                using (Pen divPen = new Pen(Color.FromArgb(235, 240, 237), 1))
                {
                    g.DrawLine(divPen, 1, 39, w - 2, 39);
                }

                // 4. Session label on right side of strip
                using (Font lblFont = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                using (SolidBrush lblBrush = new SolidBrush(Color.FromArgb(71, 85, 105)))
                {
                    g.DrawString("Session:", lblFont, lblBrush, cmbselection.Left - 56, 10);
                }

                // 5. Outlines around ALL input controls & dropdowns
                using (Pen outlinePen = new Pen(Color.FromArgb(16, 185, 129), 1.5F))
                {
                    Control[] controlsToOutline = new Control[] { com_Sclass, cmbshift, cmbsection, txtsadmissionno, cmbselection, txtbyname, cmbpromot };
                    foreach (Control c in controlsToOutline)
                    {
                        if (c != null && c.Visible)
                        {
                            Rectangle borderRect = new Rectangle(c.Left - 1, c.Top - 1, c.Width + 1, c.Height + 1);
                            using (System.Drawing.Drawing2D.GraphicsPath p = GetRoundedRectPath(borderRect, 3))
                            {
                                g.DrawPath(outlinePen, p);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.X, rect.Y, diameter, diameter);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.X;
            path.AddArc(arc, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        private System.Drawing.Drawing2D.GraphicsPath GetTopRoundedRectPath(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.X, rect.Y, diameter, diameter);

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            path.AddLine(rect.Right, rect.Bottom, rect.Left, rect.Bottom);
            path.CloseAllFigures();
            return path;
        }

        private void ConfigureStudentListView()
        {
            this.lstv_Student.OwnerDraw = true;
            this.lstv_Student.SmallImageList = new ImageList { ImageSize = new Size(1, 46) };
            this.lstv_Student.DrawColumnHeader += lstv_Student_DrawColumnHeader;
            this.lstv_Student.DrawItem += lstv_Student_DrawItem;
            this.lstv_Student.DrawSubItem += lstv_Student_DrawSubItem;
        }

        private void lstv_Student_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(8, 120, 61)))
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            using (Font font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                e.Graphics.FillRectangle(bgBrush, e.Bounds);
                using (Pen borderPen = new Pen(Color.FromArgb(5, 90, 45), 1))
                {
                    e.Graphics.DrawRectangle(borderPen, e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1);
                }
                e.Graphics.DrawString(e.Header.Text, font, textBrush, e.Bounds, sf);
            }
        }

        private void lstv_Student_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;
        }

        private void lstv_Student_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            bool isSelected = e.Item.Selected;
            Color bgColor = isSelected ? Color.FromArgb(232, 245, 233) : ((e.ItemIndex % 2 == 1) ? Color.FromArgb(244, 253, 245) : Color.White);
            Color textColor = isSelected ? Color.FromArgb(8, 120, 61) : Color.FromArgb(30, 41, 59);

            using (SolidBrush bgBrush = new SolidBrush(bgColor))
            {
                g.FillRectangle(bgBrush, e.Bounds);
            }

            using (Pen linePen = new Pen(Color.FromArgb(230, 235, 232), 1))
            {
                g.DrawLine(linePen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            }

            int columnIndex = e.ColumnIndex;

            if (columnIndex == 1) // Photo Column
            {
                string imgData = e.SubItem.Text;
                string studentId = (e.Item.SubItems.Count > 0) ? e.Item.SubItems[0].Text.Trim() : "";
                string admissionNo = (e.Item.SubItems.Count > 2) ? e.Item.SubItems[2].Text.Trim() : "";

                int photoSize = 40;
                int cx = e.Bounds.X + (e.Bounds.Width - photoSize) / 2;
                int cy = e.Bounds.Y + (e.Bounds.Height - photoSize) / 2;
                Rectangle imgRect = new Rectangle(cx, cy, photoSize, photoSize);

                Image img = GetStudentImage(imgData, studentId, admissionNo);

                using (System.Drawing.Drawing2D.GraphicsPath clipPath = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    clipPath.AddEllipse(imgRect);
                    g.SetClip(clipPath);

                    if (img != null)
                    {
                        DrawImageCover(g, img, imgRect);
                    }
                    else
                    {
                        DrawDefaultAvatar(g, imgRect);
                    }
                    g.ResetClip();
                }

                using (Pen borderPen = new Pen(Color.FromArgb(160, 210, 175), 1.5F))
                {
                    g.DrawEllipse(borderPen, imgRect);
                }
            }
            else
            {
                using (SolidBrush textBrush = new SolidBrush(textColor))
                using (Font font = isSelected ? new Font("Segoe UI", 9.5F, FontStyle.Bold) : new Font("Segoe UI", 9.5F, FontStyle.Regular))
                using (StringFormat sf = new StringFormat())
                {
                    sf.LineAlignment = StringAlignment.Center;
                    if (columnIndex == 0 || columnIndex == 7 || columnIndex == 9)
                        sf.Alignment = StringAlignment.Center;
                    else
                        sf.Alignment = StringAlignment.Near;

                    Rectangle textRect = new Rectangle(e.Bounds.X + 6, e.Bounds.Y, e.Bounds.Width - 12, e.Bounds.Height);
                    g.DrawString(e.SubItem.Text, font, textBrush, textRect, sf);
                }
            }
        }

        private static readonly Dictionary<string, Image> _imageCache = new Dictionary<string, Image>();

        private Image GetStudentImage(string imgData, string studentId, string admissionNo)
        {
            string cacheKey = !string.IsNullOrEmpty(studentId) ? ("SID_" + studentId) : ("IMG_" + (imgData ?? ""));

            Image cachedImg = null;
            if (_imageCache.TryGetValue(cacheKey, out cachedImg))
            {
                return cachedImg;
            }

            // 1. Try decoding imgData directly if supplied by the grid query
            Image img = TryDecodeImage(imgData);

            // 2. If null, fetch from student table using studentId (exact field used by frmStudent)
            if (img == null && !string.IsNullOrEmpty(studentId))
            {
                try
                {
                    using (SqlConnection cn = SYS.db_connect())
                    {
                        cn.Open();
                        string query = "select top 1 image from student where s_id = '" + studentId.Replace("'", "''") + "'";
                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                img = TryDecodeImage(result.ToString());
                            }
                        }
                    }
                }
                catch { }
            }

            // 3. If still null, try finding by admissionNo
            if (img == null && !string.IsNullOrEmpty(admissionNo))
            {
                try
                {
                    using (SqlConnection cn = SYS.db_connect())
                    {
                        cn.Open();
                        string query = "select top 1 image from student where ADMISSION_NO = '" + admissionNo.Replace("'", "''") + "'";
                        using (SqlCommand cmd = new SqlCommand(query, cn))
                        {
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                img = TryDecodeImage(result.ToString());
                            }
                        }
                    }
                }
                catch { }

                if (img == null)
                {
                    img = TryDecodeImage(admissionNo + ".jpg");
                    if (img == null) img = TryDecodeImage(admissionNo + ".png");
                    if (img == null) img = TryDecodeImage(admissionNo + ".jal");
                }
            }

            _imageCache[cacheKey] = img;
            return img;
        }

        private static Image TryDecodeImage(string data)
        {
            if (string.IsNullOrEmpty(data) || data.Trim().Length == 0) return null;
            data = data.Trim();

            try
            {
                // 1. Check if it's an existing physical file path on disk
                if (File.Exists(data))
                {
                    using (Image tempImg = Image.FromFile(data))
                    {
                        return new Bitmap(tempImg);
                    }
                }

                string appPath = Path.Combine(Path.Combine(Application.StartupPath, "Students Pictures"), data);
                if (File.Exists(appPath))
                {
                    using (Image tempImg = Image.FromFile(appPath))
                    {
                        return new Bitmap(tempImg);
                    }
                }

                // 2. Clean and decode Base64 data (Base64 strings contain '/', '+', '=')
                if (data.Contains("base64,"))
                {
                    data = data.Substring(data.IndexOf("base64,") + 7);
                }

                data = data.Replace("\r", "").Replace("\n", "").Replace("\"", "").Replace("'", "").Replace(" ", "").Trim();

                if (data.Length > 20)
                {
                    byte[] imageBytes = Convert.FromBase64String(data);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    using (Image tempImg = Image.FromStream(ms))
                    {
                        return new Bitmap(tempImg);
                    }
                }
            }
            catch { }
            return null;
        }

        private static void DrawImageCover(Graphics g, Image img, Rectangle dest)
        {
            try
            {
                float srcAspect = (float)img.Width / img.Height;
                float destAspect = (float)dest.Width / dest.Height;

                RectangleF srcRect;
                if (srcAspect > destAspect)
                {
                    float cropWidth = img.Height * destAspect;
                    srcRect = new RectangleF((img.Width - cropWidth) / 2f, 0, cropWidth, img.Height);
                }
                else
                {
                    float cropHeight = img.Width / destAspect;
                    srcRect = new RectangleF(0, (img.Height - cropHeight) / 2f, img.Width, cropHeight);
                }

                g.DrawImage(img, dest, srcRect, GraphicsUnit.Pixel);
            }
            catch
            {
                DrawDefaultAvatar(g, dest);
            }
        }

        private static void DrawDefaultAvatar(Graphics g, Rectangle rect)
        {
            using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(220, 238, 225)))
            {
                g.FillEllipse(bgBrush, rect);
            }

            int headSize = 14;
            int headX = rect.X + (rect.Width - headSize) / 2;
            int headY = rect.Y + 8;
            using (SolidBrush headBrush = new SolidBrush(Color.FromArgb(8, 120, 61)))
            {
                g.FillEllipse(headBrush, headX, headY, headSize, headSize);
            }

            int bodyW = 26;
            int bodyH = 18;
            int bodyX = rect.X + (rect.Width - bodyW) / 2;
            int bodyY = rect.Y + 23;
            using (SolidBrush bodyBrush = new SolidBrush(Color.FromArgb(8, 120, 61)))
            {
                g.FillEllipse(bodyBrush, bodyX, bodyY, bodyW, bodyH);
            }
        }

        private void frm_manage_students_Load(object sender, EventArgs e)
        {
            SYS.comboFill(this.com_Sclass, "select * from class where branch_id='" + SYSTEMSETTING.branch_ID + "' order by c_id", "class", "c_name", "c_id");
            SYS.comboFill(this.cmbsection, "SELECT [SECTION_ID],[SECTION_NAME] FROM [Sections] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "Sections", "SECTION_NAME", "SECTION_NAME");
            SYS.comboFill(this.cmbshift, "SELECT [SHIFT_ID],[SHIFT]FROM [SHIFT] where branch_id='" + SYSTEMSETTING.branch_ID + "'", "SHIFT", "SHIFT", "SHIFT");
            this.SYS.comboFill(this.cmbselection, "select * from [Sessions] where branch_id='" + SYSTEMSETTING.branch_ID + "' order by SessionID desc", "Sessions", "SessionName", "SessionID");
            this.SYS.comboFill(this.cmbpromot, "select * from [PROMO_TYPE] order by PROMO_TYPE_ID desc", "PROMO_TYPE", "PROMO_TYPE_NAME", "PROMO_TYPE_ID");
            cmbselection.SelectedValue = SYSTEMSETTING.sessionid.ToString();
            //list_Load();
            Fillclass();
        }

        private void list_Load()
        {
            SYS.Filllist_DataView("select s_id,(select top 1 image from student where student.s_id=view_student.s_id) as image,ADMISSION_NO,s_name,c_name,contact_no,f_name,age,d_birth,sex from view_student WHERE active='true' and SessionID='" + cmbselection.SelectedValue + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY c_name", this.lstv_Student);
            GetTotal();
        }

        private void rdo_All_Click(object sender, EventArgs e)
        {
            if (this.rdo_All.Checked == true)
                this.list_Load();

            else
            {
                return;
            }
        }

        private void rdo_Class_Click(object sender, EventArgs e)
        {
            Fillclass();
        }
        public void Fillclass()
        {
            try
            {
                SYS.Filllist_DataView("select s_id,(select top 1 image from student where student.s_id=view_student.s_id) as image,ADMISSION_NO,s_name,c_name,contact_no,f_name,age,d_birth,sex from view_student where active='true' and  c_id='" + this.com_Sclass.SelectedValue + "' AND SECTION_ID='" + cmbsection.SelectedValue.ToString() + "' and SHIFT='" + cmbshift.SelectedValue.ToString() + "' and SessionID='" + cmbselection.SelectedValue + "' and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)", this.lstv_Student);
                GetTotal();
                button3.Enabled = false;
            }
            catch (Exception)
            {


            }

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (rdobyadmission.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,(select top 1 image from student where student.s_id=view_student.s_id) as image,ADMISSION_NO,s_name,c_name,contact_no,f_name,age,d_birth,sex from view_student where active='true' and  ADMISSION_NO like'%" + this.txtsadmissionno.Text.Trim() + "' and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)", this.lstv_Student);
                GetTotal();
                button3.Enabled = false;
            }
        }

        private void com_Sclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fillclass();
        }

        private void cmbshift_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fillclass();
        }

        private void cmbsection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fillclass();
        }

        private void com_Sclass_Click(object sender, EventArgs e)
        {
            Fillclass();
        }

        private void RefreshCurrentGrid()
        {
            _imageCache.Clear();
            if (this.rdo_All.Checked)
                list_Load();
            else if (this.rdobyadmission.Checked)
                txtsadmissionno_TextChanged(null, null);
            else if (this.rdobyname.Checked)
                txtbyname_TextChanged(null, null);
            else if (this.RDOSCL.Checked)
                RDOSCL_CheckedChanged(null, null);
            else if (this.rdoinactive.Checked)
                rdoinactive_CheckedChanged(null, null);
            else if (this.rdopromotion.Checked)
                rdopromotion_CheckedChanged(null, null);
            else
                Fillclass();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            _forms.frmStudent frm_Student = new frmStudent();
            frm_Student.str = "Adding";
            frm_Student.ShowDialog();
            RefreshCurrentGrid();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lstv_Student.SelectedItems.Count > 0)
            {
                _forms.frmStudent frm_Student = new frmStudent();
                frm_Student.str = "Modifying";
                frm_Student.studentid = this.lstv_Student.Items[lstv_Student.FocusedItem.Index].SubItems[0].Text.Trim();
                frm_Student.ShowDialog();
                RefreshCurrentGrid();
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }

        }

        private void lstv_Student_DoubleClick(object sender, EventArgs e)
        {
            if (lstv_Student.SelectedItems.Count > 0)
            {
                _forms.frmStudent frm_Student = new frmStudent();
                frm_Student.str = "Modifying";
                frm_Student.studentid = this.lstv_Student.Items[lstv_Student.FocusedItem.Index].SubItems[0].Text.Trim();

                frm_Student.Show();
              
                RefreshCurrentGrid();
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }


        private void rdo_All_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtsadmissionno_TextChanged(object sender, EventArgs e)
        {
            if (rdobyadmission.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,(select top 1 image from student where student.s_id=view_student.s_id) as image,ADMISSION_NO,s_name,c_name,contact_no,f_name,age,d_birth,sex from view_student where active='true' and  ADMISSION_NO like'%" + this.txtsadmissionno.Text.Trim() + "' and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)", this.lstv_Student);
                GetTotal();
            }
        }

        private void rdobyname_Click(object sender, EventArgs e)
        {
            if (rdobyname.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,(select top 1 image from student where student.s_id=view_student.s_id) as image,ADMISSION_NO,s_name,c_name,contact_no,f_name,age,d_birth,sex from view_student where active='true' and  s_name like'%" + this.txtbyname.Text.Trim() + "%' and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "'  ORDER BY (ADMISSION_NO)", this.lstv_Student);
                GetTotal();
                button3.Enabled = false;
            }

        }

        private void txtbyname_TextChanged(object sender, EventArgs e)
        {
            if (rdobyname.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,(select top 1 image from student where student.s_id=view_student.s_id) as image,ADMISSION_NO,s_name,c_name,contact_no,f_name,age,d_birth,sex from view_student where active='true' and  s_name like'%" + this.txtbyname.Text.Trim() + "%' and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "'  ORDER BY (ADMISSION_NO)", this.lstv_Student);
                GetTotal(); ;
            }
        }

        private void GetTotal()
        {
            try
            {
                int a = lstv_Student.Items.Count + 1;
                for (int i = 0; i < a; i++)
                {

                    lbltotal.Text = Convert.ToString(i);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void RDOSCL_CheckedChanged(object sender, EventArgs e)
        {
            if (RDOSCL.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,(select top 1 image from student where student.s_id=view_student.s_id) as image,ADMISSION_NO,s_name,c_name,contact_no,f_name,age,d_birth,sex from view_student where active='true' and  s_id in(select s_id from STUDENT_SHIFTING WHERE shifting_type='SLC')  and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)", this.lstv_Student);
                GetTotal();
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RDOSCL.Checked == true)
            {
                if (lstv_Student.SelectedItems.Count > 0)
                {
                    SLC_Certificate frm = new SLC_Certificate();
                    frm.admissionno = this.lstv_Student.Items[lstv_Student.FocusedItem.Index].SubItems[2].Text.Trim();
                    frm.Show();
                }
                else
                {
                    SYS.setCreateError("Please select Record!");
                }
            }
            else
            {
                SYS.setCreateError("Please select SLC Type");
            }
        }

        private void rdo_Class_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoinactive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoinactive.Checked == true)
            {
                button3.Enabled = true;
                string qeury = "select s_id,image,ADMISSION_NO,s_name,(select c_name from class where c_id= student.c_id) as c_name,contact_no,f_name,age,d_birth,sex from student where active='false'  and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)";

                SYS.Filllist_DataView(qeury, this.lstv_Student);
                GetTotal(); ;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void lstv_Student_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rdoinactive.Checked == true)
            {
                if (lstv_Student.SelectedItems.Count > 0)
                {
                    string stdname = this.lstv_Student.Items[lstv_Student.FocusedItem.Index].SubItems[3].Text.Trim();
                    DialogResult ret;
                    ret = MessageBox.Show("Do you Want to Active Selected Student: " + stdname.ToString() + " ?", "Activate Student".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (ret == DialogResult.Yes)
                    {
                        bool chk = false;
                        string query = string.Empty;
                        query = "Update student set active=1 where s_id='" + this.lstv_Student.Items[lstv_Student.FocusedItem.Index].SubItems[0].Text.Trim() + "'";
                        chk = SYS.Insert_Query(query);
                        if (chk == true)
                        {
                            SYS.setMessageBox("Student:" + stdname + "  Activated!", 1);
                            string qeury = "select s_id,image,ADMISSION_NO,s_name,(select c_name from class where c_id= student.c_id) as c_name,contact_no,f_name,age,d_birth,sex from student where active='false'  and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)";
                            SYS.Filllist_DataView(qeury, this.lstv_Student);
                            GetTotal();

                        }
                        else
                        {
                            SYS.setCreateError("Student not Activated please try again");
                        }
                    }
                }
                else
                {
                    SYS.setCreateError("Please select Record!");
                }
            }
            else
            {
                SYS.setCreateError("Please select In-Active Students List to proceed.");
            }
        }

        private void rdopromotion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdopromotion.Checked == true)
            {
                button3.Enabled = true;
                string qeury = "select s_id,image,ADMISSION_NO,s_name,(select c_name from class where class.c_id=student.c_id) as c_name,contact_no,f_name,age,d_birth,sex from student where PROMO_TYPE_ID= '" + cmbpromot.SelectedValue.ToString() + "' and SessionID='" + cmbselection.SelectedValue.ToString() + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "'";

                SYS.Filllist_DataView(qeury, this.lstv_Student);
                GetTotal(); ;
            }
            else
            {
                button3.Enabled = false;
            }

        }

        private void cmbpromot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdopromotion.Checked == true)
            {
                button3.Enabled = true;
                string qeury = "select s_id,image,ADMISSION_NO,s_name,(select c_name from class where class.c_id=student.c_id) as c_name,contact_no,f_name,age,d_birth,sex from student where PROMO_TYPE_ID= '" + cmbpromot.SelectedValue.ToString() + "' and SessionID='" + cmbselection.SelectedValue.ToString() + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "'";

                SYS.Filllist_DataView(qeury, this.lstv_Student);
                GetTotal(); ;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void rdobyname_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobyname.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,(select top 1 image from student where student.s_id=view_student.s_id) as image,ADMISSION_NO,s_name,c_name,contact_no,f_name,age,d_birth,sex from view_student where active='true' and  s_name like'%" + this.txtbyname.Text.Trim() + "%' and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "'  ORDER BY (ADMISSION_NO)", this.lstv_Student);
                GetTotal(); ;
            }
        }

        private void rdo_All_CheckedChanged_1(object sender, EventArgs e)
        {
            if (this.rdo_All.Checked == true)
                this.list_Load();
        }

        private void rdo_All_Click_1(object sender, EventArgs e)
        {
            if (this.rdo_All.Checked == true)
                this.list_Load();
        }

        private void rdopromotion_Click(object sender, EventArgs e)
        {

        }

        private void cmbpromot_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (rdopromotion.Checked == true)
            {
                button3.Enabled = true;
                string qeury = "select s_id,image,ADMISSION_NO,s_name,(select c_name from class where class.c_id=student.c_id) as c_name,contact_no,f_name,age,d_birth,sex from student where PROMO_TYPE_ID= '" + cmbpromot.SelectedValue.ToString() + "' and SessionID='" + cmbselection.SelectedValue.ToString() + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "'";

                SYS.Filllist_DataView(qeury, this.lstv_Student);
                GetTotal(); ;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void RDOSCL_CheckedChanged_1(object sender, EventArgs e)
        {
            if (RDOSCL.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,(select top 1 image from student where student.s_id=view_student.s_id) as image,ADMISSION_NO,s_name,c_name,contact_no,f_name,age,d_birth,sex from view_student where active='true' and  s_id in(select s_id from STUDENT_SHIFTING WHERE shifting_type='SLC')  and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)", this.lstv_Student);
                GetTotal();
                button3.Enabled = false;
            }
        }

        private void RDOSCL_Click(object sender, EventArgs e)
        {
            if (RDOSCL.Checked == true)
            {
                SYS.Filllist_DataView("select s_id,(select top 1 image from student where student.s_id=view_student.s_id) as image,ADMISSION_NO,s_name,c_name,contact_no,f_name,age,d_birth,sex from view_student where active='true' and  s_id in(select s_id from STUDENT_SHIFTING WHERE shifting_type='SLC')  and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)", this.lstv_Student);
                GetTotal();
                button3.Enabled = false;
            }
        }

        private void rdopromotion_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdopromotion.Checked == true)
            {
                button3.Enabled = true;
                string qeury = "select s_id,image,ADMISSION_NO,s_name,(select c_name from class where class.c_id=student.c_id) as c_name,contact_no,f_name,age,d_birth,sex from student where PROMO_TYPE_ID= '" + cmbpromot.SelectedValue.ToString() + "' and SessionID='" + cmbselection.SelectedValue.ToString() + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "'";

                SYS.Filllist_DataView(qeury, this.lstv_Student);
                GetTotal(); ;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void rdoinactive_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rdoinactive.Checked == true)
            {
                button3.Enabled = true;
                string qeury = "select s_id,image,ADMISSION_NO,s_name,(select c_name from class where c_id= student.c_id) as c_name,contact_no,f_name,age,d_birth,sex from student where active='false'  and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)";

                SYS.Filllist_DataView(qeury, this.lstv_Student);
                GetTotal(); ;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void rdoinactive_Click(object sender, EventArgs e)
        {
            if (rdoinactive.Checked == true)
            {
                button3.Enabled = true;
                string qeury = "select s_id,image,ADMISSION_NO,s_name,(select c_name from class where c_id= student.c_id) as c_name,contact_no,f_name,age,d_birth,sex from student where active='false'  and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)";

                SYS.Filllist_DataView(qeury, this.lstv_Student);
                GetTotal(); ;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void cmbselection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (rdoinactive.Checked == true)
            {
                if (lstv_Student.SelectedItems.Count > 0)
                {
                    string stdname = this.lstv_Student.Items[lstv_Student.FocusedItem.Index].SubItems[3].Text.Trim();
                    DialogResult ret;
                    ret = MessageBox.Show("Do you Want to Active Selected Student: " + stdname.ToString() + " ?", "Activate Student".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (ret == DialogResult.Yes)
                    {
                        bool chk = false;
                        string query = string.Empty;
                        query = "Update student set active=1 where s_id='" + this.lstv_Student.Items[lstv_Student.FocusedItem.Index].SubItems[0].Text.Trim() + "'";
                        chk = SYS.Insert_Query(query);
                        if (chk == true)
                        {
                            SYS.setMessageBox("Student:" + stdname + "  Activated!", 1);
                            string qeury = "select s_id,image,ADMISSION_NO,s_name,(select c_name from class where c_id= student.c_id) as c_name,contact_no,f_name,age,d_birth,sex from student where active='false'  and SessionID='" + cmbselection.SelectedValue + "'  and branch_id='" + SYSTEMSETTING.branch_ID + "' ORDER BY (ADMISSION_NO)";
                            SYS.Filllist_DataView(qeury, this.lstv_Student);
                            GetTotal();

                        }
                        else
                        {
                            SYS.setCreateError("Student not Activated please try again");
                        }
                    }
                }
                else
                {
                    SYS.setCreateError("Please select Record!");
                }
            }
            else
            {
                SYS.setCreateError("Please select In-Active Students List to proceed.");
            }
        }

       
    }
}
