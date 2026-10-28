using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class Frmlogin : Form
    {
        public Frmlogin()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Frmlogin_Paint);
            this.panelMainCard.Paint += new PaintEventHandler(panelMainCard_Paint);
            this.panelBranding.Paint += new PaintEventHandler(panelBranding_Paint);
            this.panelCard.Paint += new PaintEventHandler(panelCard_Paint);
            this.label3.Paint += new PaintEventHandler(label3_Paint);
            this.pnlUserBox.Paint += new PaintEventHandler(InputBox_Paint);
            this.pnlPassBox.Paint += new PaintEventHandler(InputBox_Paint);
        }

        SYSTEMSETTING SYS = new SYSTEMSETTING();

        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            importdata IMP = new importdata();
            IMP.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Frmlogin_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyTheme(this);
            try
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image = RecolorLogoToGreenAndWhite(pictureBox1.Image);
                }
            }
            catch { }
        }

        private Bitmap RecolorLogoToGreenAndWhite(Image srcImg)
        {
            if (srcImg == null) return null;

            Bitmap bmp = new Bitmap(srcImg);
            Bitmap result = new Bitmap(bmp.Width, bmp.Height);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    if (c.A < 20)
                    {
                        result.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {
                        // Transform blue/gray tones into White (#FFFFFF) and Light Green (#A5D6A7)
                        // If pixel is greenish accent -> Soft Light Green (#A5D6A7)
                        // Otherwise blue/gray strokes -> Crisp White (#FFFFFF)
                        if (c.G > c.B + 10 && c.G > c.R + 10)
                        {
                            result.SetPixel(x, y, Color.FromArgb(c.A, 165, 214, 167));
                        }
                        else
                        {
                            result.SetPixel(x, y, Color.FromArgb(c.A, 255, 255, 255));
                        }
                    }
                }
            }
            return result;
        }

        private void Frmlogin_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Soft background gradient from very light green to soft light green/gray
                using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    this.ClientRectangle,
                    Color.FromArgb(250, 252, 250),
                    Color.FromArgb(236, 245, 238),
                    45F))
                {
                    g.FillRectangle(brush, this.ClientRectangle);
                }

                // 1. Draw top-right subtle dot grid pattern
                using (SolidBrush dotBrush = new SolidBrush(Color.FromArgb(215, 233, 218)))
                {
                    int startX = this.Width - 90;
                    int startY = 70;
                    for (int row = 0; row < 6; row++)
                    {
                        for (int col = 0; col < 6; col++)
                        {
                            g.FillEllipse(dotBrush, startX + (col * 12), startY + (row * 12), 3, 3);
                        }
                    }
                }

                // 2. Draw layered waves in bottom-right corner
                int w = this.Width;
                int h = this.Height;

                // Outer Wave (Light)
                using (System.Drawing.Drawing2D.GraphicsPath wave1 = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    wave1.AddLine(w, h - 35, w - 450, h - 35);
                    wave1.AddBezier(w - 450, h - 35, w - 300, h - 180, w - 120, h - 280, w, h - 350);
                    wave1.AddLine(w, h - 350, w, h - 35);
                    wave1.CloseAllFigures();

                    using (SolidBrush wave1Brush = new SolidBrush(Color.FromArgb(228, 242, 230)))
                    {
                        g.FillPath(wave1Brush, wave1);
                    }
                }

                // Inner Accent Wave (Deeper Green)
                using (System.Drawing.Drawing2D.GraphicsPath wave2 = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    wave2.AddLine(w, h - 35, w - 320, h - 35);
                    wave2.AddBezier(w - 320, h - 35, w - 210, h - 130, w - 80, h - 210, w, h - 270);
                    wave2.AddLine(w, h - 270, w, h - 35);
                    wave2.CloseAllFigures();

                    using (SolidBrush wave2Brush = new SolidBrush(Color.FromArgb(180, 220, 186)))
                    {
                        g.FillPath(wave2Brush, wave2);
                    }
                }
            }
            catch { }
        }

        private void panelMainCard_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Soft outer shadow/outline around panelMainCard
                using (Pen pen = new Pen(Color.FromArgb(210, 225, 212), 2F))
                {
                    using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, panelMainCard.Width - 1, panelMainCard.Height - 1), 18))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
            catch { }
        }

        private void panelBranding_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int w = panelBranding.Width;
                int h = panelBranding.Height;

                // 1. Fill panel with green background & rounded left corners
                using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(21, 120, 58)))
                {
                    using (System.Drawing.Drawing2D.GraphicsPath path = GetLeftRoundedRectPath(new Rectangle(0, 0, w, h), 18))
                    {
                        g.FillPath(bgBrush, path);
                    }
                }

                // 2. Faint top-left dot grid matrix
                using (SolidBrush dotBrush = new SolidBrush(Color.FromArgb(37, 140, 75)))
                {
                    for (int r = 0; r < 5; r++)
                    {
                        for (int c = 0; c < 5; c++)
                        {
                            g.FillEllipse(dotBrush, 15 + (c * 10), 15 + (r * 10), 3, 3);
                        }
                    }
                }

                // 3. Subtle School Campus / Building & Trees Silhouette at bottom of left panel (strictly in bottom 80px)
                using (SolidBrush groundBrush = new SolidBrush(Color.FromArgb(17, 102, 49)))
                {
                    using (System.Drawing.Drawing2D.GraphicsPath groundPath = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        groundPath.AddBezier(0, h - 25, w / 2, h - 45, w, h - 25, w, h);
                        groundPath.AddLine(w, h, 0, h);
                        groundPath.CloseAllFigures();
                        g.FillPath(groundBrush, groundPath);
                    }
                }

                // Center Building & Tower
                using (SolidBrush bldBrush = new SolidBrush(Color.FromArgb(25, 125, 60)))
                {
                    // Center Tower
                    g.FillRectangle(bldBrush, w / 2 - 30, h - 85, 60, 60);

                    // Clock Tower Peak
                    Point[] roof = new Point[] {
                        new Point(w / 2 - 33, h - 85),
                        new Point(w / 2, h - 110),
                        new Point(w / 2 + 33, h - 85)
                    };
                    g.FillPolygon(bldBrush, roof);

                    // Left Wing
                    g.FillRectangle(bldBrush, w / 2 - 115, h - 60, 85, 35);
                    // Right Wing
                    g.FillRectangle(bldBrush, w / 2 + 30, h - 60, 85, 35);
                }

                // Building Details (Clock & Windows)
                using (SolidBrush detailBrush = new SolidBrush(Color.FromArgb(17, 102, 49)))
                {
                    // Clock Circle on Tower
                    g.FillEllipse(detailBrush, w / 2 - 10, h - 102, 20, 20);

                    // Windows
                    for (int i = 0; i < 3; i++)
                    {
                        g.FillRectangle(detailBrush, w / 2 - 108 + (i * 22), h - 52, 12, 14);
                        g.FillRectangle(detailBrush, w / 2 + 38 + (i * 22), h - 52, 12, 14);
                    }

                    // Main Entrance Arch
                    using (System.Drawing.Drawing2D.GraphicsPath doorPath = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        doorPath.AddArc(w / 2 - 10, h - 50, 20, 20, 180, 180);
                        doorPath.AddLine(w / 2 + 10, h - 40, w / 2 + 10, h - 25);
                        doorPath.AddLine(w / 2 + 10, h - 25, w / 2 - 10, h - 25);
                        doorPath.AddLine(w / 2 - 10, h - 25, w / 2 - 10, h - 40);
                        doorPath.CloseAllFigures();
                        g.FillPath(detailBrush, doorPath);
                    }
                }

                // Trees on Left & Right Sides
                using (SolidBrush treeBrush = new SolidBrush(Color.FromArgb(14, 90, 43)))
                {
                    g.FillEllipse(treeBrush, 15, h - 75, 40, 50);
                    g.FillEllipse(treeBrush, 45, h - 60, 35, 40);

                    g.FillEllipse(treeBrush, w - 55, h - 75, 40, 50);
                    g.FillEllipse(treeBrush, w - 80, h - 60, 35, 40);
                }
            }
            catch { }
        }

        private void label3_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // Custom render EduCore: "Edu" in White, "Core" in Light Green/Lime
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Font font = label3.Font;
                
                SizeF sizeEdu = g.MeasureString("Edu", font);
                SizeF sizeCore = g.MeasureString("Core", font);
                float totalWidth = sizeEdu.Width + sizeCore.Width - 12;

                float startX = (label3.Width - totalWidth) / 2;
                float startY = (label3.Height - sizeEdu.Height) / 2;

                using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                {
                    g.DrawString("Edu", font, whiteBrush, startX, startY);
                }

                using (SolidBrush limeBrush = new SolidBrush(Color.FromArgb(165, 214, 167)))
                {
                    g.DrawString("Core", font, limeBrush, startX + sizeEdu.Width - 12, startY);
                }
            }
            catch { }
        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int w = panelCard.Width;
                int h = panelCard.Height;

                // 1. Fill card with pure white and rounded right corners
                using (SolidBrush bgBrush = new SolidBrush(Color.White))
                {
                    using (System.Drawing.Drawing2D.GraphicsPath path = GetRightRoundedRectPath(new Rectangle(0, 0, w - 1, h - 1), 18))
                    {
                        g.FillPath(bgBrush, path);
                    }
                }

                // 2. Draw circular top green shield badge centered at X: (Width - 48)/2, Y: 14
                int circleX = (w - 48) / 2;
                int circleY = 14;
                using (SolidBrush circleBrush = new SolidBrush(Color.FromArgb(232, 245, 233)))
                {
                    g.FillEllipse(circleBrush, circleX, circleY, 48, 48);
                }

                // Draw shield inside circle
                using (SolidBrush shieldBrush = new SolidBrush(Color.FromArgb(21, 120, 58)))
                {
                    using (System.Drawing.Drawing2D.GraphicsPath shieldPath = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int sx = circleX + 13;
                        int sy = circleY + 11;
                        shieldPath.AddLine(sx, sy + 5, sx + 11, sy);
                        shieldPath.AddLine(sx + 11, sy, sx + 22, sy + 5);
                        shieldPath.AddLine(sx + 22, sy + 5, sx + 22, sy + 15);
                        shieldPath.AddBezier(sx + 22, sy + 15, sx + 22, sy + 23, sx + 11, sy + 27, sx + 11, sy + 27);
                        shieldPath.AddBezier(sx + 11, sy + 27, sx, sy + 23, sx, sy + 15, sx, sy + 15);
                        shieldPath.CloseAllFigures();
                        g.FillPath(shieldBrush, shieldPath);
                    }

                    // Draw inner white lock square inside shield
                    using (SolidBrush lockBrush = new SolidBrush(Color.White))
                    {
                        g.FillRectangle(lockBrush, circleX + 20, circleY + 28, 8, 7);
                        using (Pen lockPen = new Pen(Color.White, 1.5F))
                        {
                            g.DrawArc(lockPen, circleX + 21, circleY + 24, 6, 6, 180, 180);
                        }
                    }
                }
            }
            catch { }
        }

        private void InputBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Control box = (Control)sender;
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(Color.FromArgb(165, 214, 167), 1.5F))
                {
                    using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, box.Width - 1, box.Height - 1), 6))
                    {
                        g.DrawPath(pen, path);
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

        private System.Drawing.Drawing2D.GraphicsPath GetLeftRoundedRectPath(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.X, rect.Y, diameter, diameter);

            path.AddArc(arc, 180, 90);
            path.AddLine(rect.X + radius, rect.Y, rect.Right, rect.Y);
            path.AddLine(rect.Right, rect.Y, rect.Right, rect.Bottom);
            path.AddLine(rect.Right, rect.Bottom, rect.X + radius, rect.Bottom);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRightRoundedRectPath(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.Right - diameter, rect.Y, diameter, diameter);

            path.AddLine(rect.X, rect.Y, rect.Right - radius, rect.Y);
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            path.AddLine(rect.Right - radius, rect.Bottom, rect.X, rect.Bottom);
            path.CloseAllFigures();
            return path;
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtuser.Text.Length > 0 && txtPass.Text.Length > 0)
                {
                    DataSet rs = new DataSet();
                    rs = SYS.Show_Query("Select * from user_ where u_id='" + txtuser.Text.ToUpper() + "' and pw='" + txtPass.Text.ToUpper() + "'");
                    if (rs.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow RowDocument in rs.Tables[0].Rows)
                        {
                            frmchangesession frm = null;
                            if ((frm = (frmchangesession)IsFormAlreadyOpen(typeof(frmchangesession))) == null)
                            {
                                SYSTEMSETTING.sUserName = txtuser.Text;
                                SYSTEMSETTING.branch_ID = RowDocument["branch_id"].ToString();
                                SYSTEMSETTING.user_type = RowDocument["user_type"].ToString();

                                frm = new frmchangesession();
                                this.Hide();
                                frm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Application Already Open", "TSI Software");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name or Password !");
                    }
                }
                else
                {
                    MessageBox.Show("User Name or Password Must be filled!");
                }
            }
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtPass.Focus();
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Length > 0 && txtPass.Text.Length > 0)
            {
                if ((txtuser.Text.ToString() == "SUPER.USER" && txtPass.Text == "123"))
                {
                    _dashboad_forms.Form1 frm = null;
                    if ((frm = (_dashboad_forms.Form1)IsFormAlreadyOpen(typeof(_dashboad_forms.Form1))) == null)
                    {
                        frm = new _dashboad_forms.Form1();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Application Already Open", "TSI Software");
                    }
                }
                else
                {
                    DataSet rs = new DataSet();
                    rs = SYS.Show_Query("Select * from user_ where u_id='" + txtuser.Text.ToUpper() + "' and pw='" + txtPass.Text.ToUpper() + "'");
                    if (rs.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow RowDocument in rs.Tables[0].Rows)
                        {
                            frmchangesession frm = null;
                            if ((frm = (frmchangesession)IsFormAlreadyOpen(typeof(frmchangesession))) == null)
                            {
                                SYSTEMSETTING.sUserName = txtuser.Text;
                                SYSTEMSETTING.branch_ID = RowDocument["branch_id"].ToString();
                                SYSTEMSETTING.user_type = RowDocument["user_type"].ToString();
                                frm = new frmchangesession();
                                this.Hide();
                                frm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Application Already Open", "TSI Software");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name or Password !");
                    }
                }
            }
            else
            {
                MessageBox.Show("User Name or Password Must be filled!");
            }
        }
    }
}
