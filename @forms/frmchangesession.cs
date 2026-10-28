using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class frmchangesession : Form
    {
        public frmchangesession()
        {
            InitializeComponent();
            this.Resize += new EventHandler(frmchangesession_Resize);
            this.Paint += new PaintEventHandler(frmchangesession_Paint);
            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panelCard.Paint += new PaintEventHandler(panelCard_Paint);
            this.pnlDeptBox.Paint += new PaintEventHandler(InputBox_Paint);
            this.pnlSessBox.Paint += new PaintEventHandler(InputBox_Paint);
        }

        private void frmchangesession_Resize(object sender, EventArgs e)
        {
            CenterInnerCard();
        }

        private void CenterInnerCard()
        {
            try
            {
                if (panelCard != null)
                {
                    // Mathematically center the inner card horizontally in dialog
                    panelCard.Left = Math.Max(0, (this.ClientSize.Width - panelCard.Width) / 2);

                    // Vertically center in remaining space below header
                    int topOffset = (panel1 != null) ? panel1.Bottom : 0;
                    int remainingH = this.ClientSize.Height - topOffset;
                    panelCard.Top = topOffset + Math.Max(6, (remainingH - panelCard.Height) / 2);

                    // Align labels and input boxes with equal side padding
                    int boxWidth = Math.Min(400, panelCard.ClientSize.Width - 40);
                    int boxLeft = (panelCard.ClientSize.Width - boxWidth) / 2;

                    if (pnlDeptBox != null)
                    {
                        pnlDeptBox.Width = boxWidth;
                        pnlDeptBox.Left = boxLeft;
                    }
                    if (label3 != null)
                    {
                        label3.Left = boxLeft;
                    }
                    if (pnlSessBox != null)
                    {
                        pnlSessBox.Width = boxWidth;
                        pnlSessBox.Left = boxLeft;
                    }
                    if (label1 != null)
                    {
                        label1.Left = boxLeft;
                    }

                    // Align dropdown combos inside input boxes
                    if (cmbdept != null && pnlDeptBox != null)
                    {
                        cmbdept.Width = pnlDeptBox.ClientSize.Width - 52;
                    }
                    if (cmbselection != null && pnlSessBox != null)
                    {
                        cmbselection.Width = pnlSessBox.ClientSize.Width - 52;
                    }

                    // Center Continue and Close buttons as a cohesive group inside panelCard
                    if (btnshow != null && btnexit != null)
                    {
                        int btnGap = 12;
                        int totalBtnWidth = btnshow.Width + btnGap + btnexit.Width;
                        int btnStartX = (panelCard.ClientSize.Width - totalBtnWidth) / 2;
                        btnshow.Left = btnStartX;
                        btnexit.Left = btnStartX + btnshow.Width + btnGap;
                    }
                }
            }
            catch { }
        }

        SYSTEMSETTING SYS = new SYSTEMSETTING();

        private void frmchangesession_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
            CenterInnerCard();

            ThemeHelper.ApplyTheme(this);
            string BRANCH_ID = "";
            try
            {
                BRANCH_ID = SYSTEMSETTING.branch_ID;
            }
            catch (Exception)
            {
                BRANCH_ID = "1";
            }

            if (SYSTEMSETTING.user_type == "1")
            {
                this.SYS.comboFill(this.cmbdept, "select branch_id,branch_name from branch where active='Y'", "branch", "branch_name", "branch_id");
            }
            else
            {
                this.SYS.comboFill(this.cmbdept, "select branch_id,branch_name from branch where active='Y' and  branch_id='" + BRANCH_ID + "'", "branch", "branch_name", "branch_id");
            }

            this.SYS.comboFill(this.cmbselection, "select * from [Sessions] where branch_id='" + cmbdept.SelectedValue.ToString() + "' and active='true' order by SessionID desc", "Sessions", "SessionName", "SessionID");
            cmbselection.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(8, 120, 61)))
                {
                    g.FillRectangle(brush, panel1.ClientRectangle);
                }

                // Accent bottom border on header
                using (Pen borderPen = new Pen(Color.FromArgb(163, 217, 165), 1.5F))
                {
                    g.DrawLine(borderPen, 0, panel1.Height - 1, panel1.Width, panel1.Height - 1);
                }
            }
            catch { }
        }

        private void frmchangesession_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Soft off-white canvas background
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(245, 247, 246)))
                {
                    g.FillRectangle(brush, this.ClientRectangle);
                }

                // Outer border around form window if borderless/dialog
                using (Pen pen = new Pen(Color.FromArgb(180, 195, 210), 1F))
                {
                    g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
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

                // Fill card with pure white and soft green border
                using (SolidBrush bgBrush = new SolidBrush(Color.White))
                {
                    using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, w - 1, h - 1), 12))
                    {
                        g.FillPath(bgBrush, path);
                        using (Pen pen = new Pen(Color.FromArgb(163, 217, 165), 1.5F))
                        {
                            g.DrawPath(pen, path);
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

            // top left
            path.AddArc(arc, 180, 90);

            // top right
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left
            arc.X = rect.X;
            path.AddArc(arc, 90, 90);

            path.CloseAllFigures();
            return path;
        }

        private void cmbselection_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void cmbdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SYS.comboFill(this.cmbselection, "select * from [Sessions] where branch_id='" + cmbdept.SelectedValue.ToString() + "' and active='true' order by SessionID desc", "Sessions", "SessionName", "SessionID");
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbselection.SelectedValue.ToString() == null)
                {
                    SYS.setMessageBox("Please Select Session to Continue", 1);
                    return;
                }
            }
            catch (Exception)
            {
                SYS.setMessageBox("Please Select Session to Continue", 1);
                return;
            }

            SYSTEMSETTING.sessionid = cmbselection.SelectedValue.ToString();
            SYSTEMSETTING.branch_ID = cmbdept.SelectedValue.ToString();
            SYSTEMSETTING.branch_name = cmbdept.SelectedItem.ToString();

            DataSet rs = new DataSet();
            rs = SYS.Show_Query("select * from branch where branch_id='" + cmbdept.SelectedValue.ToString() + "'");
            if (rs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    SYSTEMSETTING.branch_address = RowDocument["branch_address"].ToString();
                    SYSTEMSETTING.schoolname = RowDocument["branch_name"].ToString();
                }
            }

            rs = SYS.Show_Query("select SessionName from Sessions where SessionID='" + cmbselection.SelectedValue.ToString() + "'");
            if (rs.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    SYSTEMSETTING.sessionname = RowDocument["SessionName"].ToString();
                }
            }

            MDI_new_admin frm = new MDI_new_admin();
            frm.Show();
            this.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Frmlogin frm = new Frmlogin();
            frm.Show();
            this.Close();
        }
    }
}
