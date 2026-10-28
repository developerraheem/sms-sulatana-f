using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace School
{
    public enum NavIconType
    {
        Dashboard,
        Students,
        Classes,
        Fees,
        Attendance,
        Reports,
        Settings,
        Backup,
        Logout
    }

    public class SidebarTooltipForm : Form
    {
        private Label lblText;

        public SidebarTooltipForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.BackColor = Color.FromArgb(15, 96, 48); // Dark Green #0F6030
            this.DoubleBuffered = true;

            lblText = new Label();
            lblText.AutoSize = true;
            lblText.ForeColor = Color.White;
            lblText.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblText.Padding = new Padding(12, 7, 12, 7);
            lblText.Dock = DockStyle.Fill;
            lblText.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblText);

            this.Paint += SidebarTooltipForm_Paint;
        }

        private void SidebarTooltipForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen borderPen = new Pen(Color.FromArgb(165, 214, 167), 1.5F))
            {
                g.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        public void ShowTooltip(string text, Point screenLocation)
        {
            lblText.Text = text;
            Size sz = lblText.PreferredSize;
            this.Size = new Size(sz.Width + 4, sz.Height + 4);
            this.Location = screenLocation;

            if (!this.Visible)
            {
                this.Show();
            }
            else
            {
                this.BringToFront();
            }
        }

        public void HideTooltip()
        {
            this.Hide();
        }
    }

    public class SidebarNavButton : Button
    {
        public string TooltipText { get; set; }
        public NavIconType IconType { get; set; }
        private bool isHovered = false;
        private static SidebarTooltipForm tooltipWindow = new SidebarTooltipForm();

        public SidebarNavButton(NavIconType iconType, string tooltipText)
        {
            this.IconType = iconType;
            this.TooltipText = tooltipText;
            this.Size = new Size(48, 48);
            this.Margin = new Padding(6, 6, 6, 6);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;

            this.MouseEnter += SidebarNavButton_MouseEnter;
            this.MouseLeave += SidebarNavButton_MouseLeave;
        }

        private void SidebarNavButton_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            this.Invalidate();

            Point screenPt = this.PointToScreen(new Point(this.Width + 8, (this.Height - 32) / 2));
            tooltipWindow.ShowTooltip(TooltipText, screenPt);
        }

        private void SidebarNavButton_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            this.Invalidate();
            tooltipWindow.HideTooltip();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(3, 3, this.Width - 7, this.Height - 7);

            // Hover state highlight background
            if (isHovered)
            {
                using (SolidBrush hoverBrush = new SolidBrush(Color.FromArgb(28, 162, 80))) // #1CA250 Emerald Green
                using (GraphicsPath path = GetRoundedPath(rect, 8))
                {
                    g.FillPath(hoverBrush, path);
                }
            }

            // Draw Icon
            Color iconColor = isHovered ? Color.White : Color.FromArgb(220, 238, 225);
            DrawNavIcon(g, IconType, iconColor, this.Width, this.Height);
        }

        private void DrawNavIcon(Graphics g, NavIconType type, Color color, int w, int h)
        {
            using (Pen pen = new Pen(color, 2F))
            using (SolidBrush brush = new SolidBrush(color))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                int cx = w / 2;
                int cy = h / 2;

                switch (type)
                {
                    case NavIconType.Dashboard:
                        // 2x2 grid icon
                        g.FillRectangle(brush, cx - 10, cy - 10, 8, 8);
                        g.FillRectangle(brush, cx + 2, cy - 10, 8, 8);
                        g.FillRectangle(brush, cx - 10, cy + 2, 8, 8);
                        g.FillRectangle(brush, cx + 2, cy + 2, 8, 8);
                        break;

                    case NavIconType.Students:
                        // Graduation Cap Icon
                        Point[] cap = new Point[] {
                            new Point(cx, cy - 8),
                            new Point(cx + 12, cy - 2),
                            new Point(cx, cy + 4),
                            new Point(cx - 12, cy - 2)
                        };
                        g.FillPolygon(brush, cap);
                        g.DrawLine(pen, cx - 8, cy + 1, cx - 8, cy + 7);
                        g.DrawLine(pen, cx - 8, cy + 7, cx + 8, cy + 7);
                        g.DrawLine(pen, cx + 8, cy + 7, cx + 8, cy + 1);
                        break;

                    case NavIconType.Classes:
                        // Classroom / Stacked Layers Icon
                        g.DrawRectangle(pen, cx - 10, cy - 9, 20, 5);
                        g.DrawRectangle(pen, cx - 10, cy - 1, 20, 5);
                        g.DrawRectangle(pen, cx - 10, cy + 7, 20, 5);
                        break;

                    case NavIconType.Fees:
                        // Wallet / Dollar banknote icon
                        g.DrawRectangle(pen, cx - 11, cy - 7, 22, 14);
                        g.DrawEllipse(pen, cx - 4, cy - 4, 8, 8);
                        break;

                    case NavIconType.Attendance:
                        // Clock / Time Icon
                        g.DrawEllipse(pen, cx - 10, cy - 10, 20, 20);
                        g.DrawLine(pen, cx, cy - 5, cx, cy);
                        g.DrawLine(pen, cx, cy, cx + 4, cy);
                        break;

                    case NavIconType.Reports:
                        // Bar Chart Icon
                        g.FillRectangle(brush, cx - 9, cy, 4, 9);
                        g.FillRectangle(brush, cx - 2, cy - 6, 4, 15);
                        g.FillRectangle(brush, cx + 5, cy - 10, 4, 19);
                        g.DrawLine(pen, cx - 11, cy + 9, cx + 10, cy + 9);
                        break;

                    case NavIconType.Settings:
                        // Gear Cog Icon
                        g.DrawEllipse(pen, cx - 6, cy - 6, 12, 12);
                        g.FillEllipse(brush, cx - 2, cy - 2, 4, 4);
                        g.DrawLine(pen, cx, cy - 10, cx, cy + 10);
                        g.DrawLine(pen, cx - 10, cy, cx + 10, cy);
                        g.DrawLine(pen, cx - 7, cy - 7, cx + 7, cy + 7);
                        g.DrawLine(pen, cx - 7, cy + 7, cx + 7, cy - 7);
                        break;

                    case NavIconType.Backup:
                        // Database Cloud Icon
                        g.DrawEllipse(pen, cx - 9, cy - 8, 18, 6);
                        g.DrawArc(pen, cx - 9, cy - 4, 18, 8, 0, 180);
                        g.DrawArc(pen, cx - 9, cy + 2, 18, 8, 0, 180);
                        g.DrawLine(pen, cx - 9, cy - 5, cx - 9, cy + 6);
                        g.DrawLine(pen, cx + 9, cy - 5, cx + 9, cy + 6);
                        break;

                    case NavIconType.Logout:
                        // Power Switch / Exit Icon
                        g.DrawArc(pen, cx - 8, cy - 8, 16, 16, -60, 300);
                        g.DrawLine(pen, cx, cy - 10, cx, cy - 2);
                        break;
                }
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}
