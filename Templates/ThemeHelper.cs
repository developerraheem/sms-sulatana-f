using System;
using System.Drawing;
using System.Windows.Forms;

namespace School
{
    public static class ThemeHelper
    {
        // Fresh Leaf-Green Color Scheme for School/College Management System (EduCore Identity)
        public static readonly Color PrimaryDarkGreen = Color.FromArgb(15, 96, 48);     // #0F6030 - Leaf/Forest Green Header & Active State
        public static readonly Color EmeraldGreen     = Color.FromArgb(28, 162, 80);    // #1CA250 - Vibrant Leaf Green Action Color
        public static readonly Color HoverGreen       = Color.FromArgb(20, 122, 62);    // #147A3E - Hover State
        public static readonly Color LightGreenTint   = Color.FromArgb(232, 245, 233);  // #E8F5E9 - Soft Row/Card Accent
        public static readonly Color BorderColor      = Color.FromArgb(221, 231, 225);  // #DDE7E1 - Light Neutral Border
        public static readonly Color DarkText         = Color.FromArgb(31, 41, 55);     // #1F2937 - Dark Slate Typography
        public static readonly Color MutedText        = Color.FromArgb(100, 116, 139);  // #64748B - Subtitle Text
        public static readonly Color OffWhiteBg       = Color.FromArgb(245, 247, 246);  // #F5F7F6 - Canvas Background
        public static readonly Color CardBg           = Color.White;                    // Pure White Card Bg

        public static void ApplyTheme(Form form)
        {
            if (form == null) return;

            try
            {
                form.BackColor = OffWhiteBg;
                form.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                // Enable AutoScroll and calculate content bounding size for desktop screen responsiveness
                form.AutoScroll = true;

                int maxRight = 0;
                int maxBottom = 0;
                foreach (Control c in form.Controls)
                {
                    if (c != null && c.Visible && !(c is MdiClient) && !(c is MenuStrip) && !(c is StatusStrip) && !(c is ToolStrip))
                    {
                        if (c.Right > maxRight) maxRight = c.Right;
                        if (c.Bottom > maxBottom) maxBottom = c.Bottom;
                    }
                }
                if (maxRight > 0 && maxBottom > 0)
                {
                    form.AutoScrollMinSize = new Size(Math.Min(maxRight + 20, 1400), Math.Min(maxBottom + 20, 900));
                }

                // Colorize MDI Client background if form is MDI Parent
                foreach (Control c in form.Controls)
                {
                    if (c is MdiClient)
                    {
                        c.BackColor = OffWhiteBg;
                    }
                }

                // Register form paint handler for crisp outlines
                form.Paint -= InputContainer_Paint;
                form.Paint += InputContainer_Paint;

                // Recursively style controls
                foreach (Control control in form.Controls)
                {
                    StyleControl(control);
                }

                // Apply Form-specific layout refinements
                string formName = (form.Name ?? "").ToLower();
                if (formName.Contains("dash"))
                {
                    StyleDashboard(form);
                }
                else if (formName.Contains("login"))
                {
                    StyleLoginForm(form);
                }
                else if (formName.Contains("mdi_new_admin") || formName.Contains("main"))
                {
                    StyleMdiAdmin(form);
                }
                else
                {
                    // Style all other dialogs and forms as standard card-based setup forms
                    StyleClassForm(form);
                }
            }
            catch (Exception)
            {
                // Non-fatal UI styling guard
            }
        }

        private static void StyleLoginForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;
                StyleLoginControlRecursive(form);
            }
            catch (Exception)
            {
                // Non-fatal
            }
        }

        private static void StyleLoginControlRecursive(Control parent)
        {
            if (parent == null) return;

            foreach (Control c in parent.Controls)
            {
                if (c.Name == "panel1") // Header panel
                {
                    c.BackgroundImage = null;
                    c.BackColor = PrimaryDarkGreen;
                }
                else if (c.Name == "label23")
                {
                    c.ForeColor = Color.White;
                    c.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                }
                else if (c.Name == "panelCard" || c.Name == "panelBranding" || c.Name == "panelMainCard")
                {
                    c.BackColor = Color.Transparent;
                }
                else if (c.Name == "labelWelcome")
                {
                    c.ForeColor = PrimaryDarkGreen;
                    c.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
                }
                else if (c.Name == "label4")
                {
                    c.ForeColor = MutedText;
                    c.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                }
                else if (c.Name == "pnlDivider")
                {
                    c.BackColor = EmeraldGreen;
                }
                else if (c.Name == "label1" || c.Name == "label2")
                {
                    c.ForeColor = DarkText;
                    c.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
                else if (c.Name == "txtuser" || c.Name == "txtPass")
                {
                    c.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    c.BackColor = Color.White;
                }
                else if (c.Name == "label3") // EduCore Title
                {
                    c.ForeColor = Color.White;
                    c.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
                }
                else if (c.Name == "lblschoolname") // Tagline
                {
                    c.ForeColor = Color.White;
                    c.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                }
                else if (c.Name == "btnshow") // Login button
                {
                    Button btn = (Button)c;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = PrimaryDarkGreen;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;
                }
                else if (c.Name == "btnexit") // Close button
                {
                    Button btn = (Button)c;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                    btn.BackColor = Color.White;
                    btn.ForeColor = PrimaryDarkGreen;
                    btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;
                }
                else if (c.Name == "label5") // Footer
                {
                    c.ForeColor = PrimaryDarkGreen;
                    c.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }

                if (c.HasChildren)
                {
                    StyleLoginControlRecursive(c);
                }
            }
        }

        private static void StyleDashboard(Form form)
        {
            try
            {
                foreach (Control c in form.Controls)
                {
                    if (c.Name == "label3") // "Dashboard" Title
                    {
                        c.BackColor = Color.Transparent;
                        c.ForeColor = PrimaryDarkGreen;
                        c.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                    }
                    else if (c.Name == "panel1") // Top Header Bar
                    {
                        c.BackColor = Color.White;
                        foreach (Control child in c.Controls)
                        {
                            if (child.Name == "label18")
                            {
                                child.ForeColor = PrimaryDarkGreen;
                                child.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
                            }
                            else if (child.Name == "LBLCAMPUSNAME")
                            {
                                child.ForeColor = MutedText;
                                child.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                            }
                        }
                    }
                    else if (c.Name == "panel2" || c.Name == "panel8" || c.Name == "panel7" || c.Name == "panel4")
                    {
                        // Stat Cards 1..4 (White Cards with Green Accent)
                        c.BackColor = CardBg;
                        foreach (Control child in c.Controls)
                        {
                            child.BackColor = Color.Transparent;
                            if (child is Label)
                            {
                                string name = child.Name;
                                if (name == "lbl_total_strength" || name == "lbl_total_classes" || name == "lbltotal_earning" || name == "lblreceived")
                                {
                                    child.ForeColor = PrimaryDarkGreen;
                                    child.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
                                }
                                else if (name.StartsWith("lblSub"))
                                {
                                    child.ForeColor = MutedText;
                                    child.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
                                }
                                else
                                {
                                    child.ForeColor = PrimaryDarkGreen;
                                    child.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                }
                            }
                        }
                    }
                    else if (c.Name == "panel9")
                    {
                        // Stat Card 5 (Balance - Dark Green Card)
                        c.BackColor = PrimaryDarkGreen;
                        foreach (Control child in c.Controls)
                        {
                            child.BackColor = Color.Transparent;
                            if (child is Label)
                            {
                                string name = child.Name;
                                if (name == "lblbalance")
                                {
                                    child.ForeColor = Color.White;
                                    child.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
                                }
                                else if (name.StartsWith("lblSub"))
                                {
                                    child.ForeColor = Color.FromArgb(232, 245, 233);
                                    child.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
                                }
                                else
                                {
                                    child.ForeColor = Color.White;
                                    child.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                }
                            }
                        }
                    }
                    else if (c.Name == "panel5" || c.Name == "panel6" || c.Name == "panel3")
                    {
                        // Middle & Lower Cards
                        c.BackColor = CardBg;
                        foreach (Control child in c.Controls)
                        {
                            if (child is Label && (child.Name == "label10" || child.Name == "label11"))
                            {
                                child.BackColor = Color.Transparent;
                                child.ForeColor = PrimaryDarkGreen;
                                child.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
                            }
                            else if (child is ListView)
                            {
                                ListView lst = (ListView)child;
                                lst.BackColor = Color.White;
                                lst.ForeColor = DarkText;
                                lst.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Non-fatal
            }
        }

        private static void StyleMdiAdmin(Form form)
        {
            try
            {
                foreach (Control c in form.Controls)
                {
                    if (c is MenuStrip && c.Name == "menuStrip1")
                    {
                        MenuStrip ms = (MenuStrip)c;
                        ms.BackgroundImage = null;
                        ms.BackColor = PrimaryDarkGreen;
                        ms.ForeColor = Color.White;
                        ms.AutoSize = true; // Show both icons and text labels clearly
                        ms.ImageScalingSize = new Size(24, 24);
                        ms.Renderer = new GreenToolStripRenderer();

                        foreach (ToolStripItem item in ms.Items)
                        {
                            item.ForeColor = Color.White;
                            item.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private static void StyleClassForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                foreach (Control c in form.Controls)
                {
                    // Generic detection of top-docked header panel
                    if (c is Panel && c.Dock == DockStyle.Top && c.Height <= 85)
                    {
                        Panel pnlHeader = (Panel)c;
                        pnlHeader.BackColor = Color.White;
                        foreach (Control child in pnlHeader.Controls)
                        {
                            child.BackColor = Color.Transparent;
                            if (child is Label)
                            {
                                Label lbl = (Label)child;
                                string lblText = (lbl.Text ?? "").ToLower();
                                if (lbl.Font.Size >= 11 || lbl.Name == "label4" || lbl.Name == "label2" || lbl.Name == "label18")
                                {
                                    lbl.ForeColor = PrimaryDarkGreen;
                                    lbl.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                                }
                                else if (lbl.Name.Contains("mode") || lblText.Contains("mode"))
                                {
                                    lbl.ForeColor = Color.FromArgb(220, 38, 38);
                                    lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                }
                                else
                                {
                                    lbl.ForeColor = MutedText;
                                    lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                }
                            }
                        }

                        // Handle divider painting
                        pnlHeader.Paint -= HeaderPanel_Paint;
                        pnlHeader.Paint += HeaderPanel_Paint;
                    }
                    else if (c.Name == "groupBox1" || c.Name == "panelCard")
                    {
                        c.BackColor = CardBg;
                        foreach (Control child in c.Controls)
                        {
                            if (child.Name == "label5" || child.Name == "label1")
                            {
                                child.ForeColor = DarkText;
                                child.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private static void HeaderPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Control c = (Control)sender;
                using (Pen p = new Pen(Color.FromArgb(200, 220, 205), 1.5F))
                {
                    e.Graphics.DrawLine(p, 16, c.Height - 2, c.Width - 16, c.Height - 2);
                }
            }
            catch { }
        }

        private static void StyleControl(Control control)
        {
            if (control == null) return;

            // Handle MenuStrip / ToolStrip
            if (control is MenuStrip)
            {
                MenuStrip menuStrip = (MenuStrip)control;
                if (menuStrip.Name != "menuStrip1")
                {
                    menuStrip.Renderer = new GreenToolStripRenderer();
                    menuStrip.BackColor = PrimaryDarkGreen;
                    menuStrip.ForeColor = Color.White;
                    menuStrip.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    foreach (ToolStripItem item in menuStrip.Items)
                    {
                        StyleToolStripItem(item);
                    }
                }
                return;
            }

            if (control is ToolStrip)
            {
                ToolStrip toolStrip = (ToolStrip)control;
                toolStrip.Renderer = new GreenToolStripRenderer();
                toolStrip.BackColor = EmeraldGreen;
                toolStrip.ForeColor = Color.White;
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    StyleToolStripItem(item);
                }
                return;
            }

            if (control is StatusStrip)
            {
                StatusStrip statusStrip = (StatusStrip)control;
                statusStrip.BackColor = PrimaryDarkGreen;
                statusStrip.ForeColor = Color.White;
                statusStrip.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                return;
            }

            if (control is StatusBar)
            {
                StatusBar statusBar = (StatusBar)control;
                statusBar.BackColor = PrimaryDarkGreen;
                statusBar.ForeColor = Color.White;
                statusBar.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                return;
            }

            // Handle Buttons
            if (control is Button)
            {
                Button btn = (Button)control;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                string nameLower = (btn.Name ?? "").ToLower();
                string textLower = (btn.Text ?? "").ToLower();

                if (nameLower.Contains("save") || textLower.Contains("save"))
                {
                    btn.BackColor = PrimaryDarkGreen;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                    btn.FlatAppearance.MouseOverBackColor = EmeraldGreen;
                }
                else if (nameLower.Contains("update") || textLower.Contains("update"))
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = PrimaryDarkGreen;
                    btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                    btn.FlatAppearance.MouseOverBackColor = LightGreenTint;
                }
                else if (nameLower.Contains("delete") || textLower.Contains("delete") || nameLower.Contains("del") || textLower.Contains("del"))
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(220, 38, 38);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(220, 38, 38);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 242, 242);
                }
                else if (nameLower.Contains("exit") || textLower.Contains("exit") || nameLower.Contains("close") || textLower.Contains("close") || nameLower.Contains("cancel") || textLower.Contains("cancel"))
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(100, 116, 139);
                    btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 250, 252);
                }
                else
                {
                    btn.BackColor = PrimaryDarkGreen;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                    btn.FlatAppearance.MouseOverBackColor = EmeraldGreen;
                }
                btn.Cursor = Cursors.Hand;
                StyleGlassButton(btn, btn.BackColor, btn.ForeColor, btn.FlatAppearance.MouseOverBackColor);
            }

            // Handle Panels
            else if (control is Panel)
            {
                Panel pnl = (Panel)control;
                string pnlName = (pnl.Name ?? "").ToLower();
                bool isHeader = pnl.Dock == DockStyle.Top && (pnlName.Contains("header") || pnlName.Contains("top") || pnlName == "panel1");

                if (isHeader)
                {
                    pnl.BackColor = PrimaryDarkGreen;
                    foreach (Control child in pnl.Controls)
                    {
                        if (child is Label)
                        {
                            child.ForeColor = Color.White;
                        }
                    }
                }
                else if (pnlName.Contains("card") || pnlName.Contains("box") || pnlName.Contains("panel") || pnlName.Contains("pnl"))
                {
                    if (pnl.BackColor != PrimaryDarkGreen && pnl.BackColor != EmeraldGreen)
                    {
                        pnl.BackColor = CardBg;
                    }
                }
            }

            // Handle DataGridView
            else if (control is DataGridView)
            {
                DataGridView dgv = (DataGridView)control;
                dgv.EnableHeadersVisualStyles = false;
                dgv.BackgroundColor = CardBg;
                dgv.BorderStyle = BorderStyle.FixedSingle;
                dgv.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDarkGreen;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgv.AlternatingRowsDefaultCellStyle.BackColor = LightGreenTint;
                dgv.DefaultCellStyle.SelectionBackColor = EmeraldGreen;
                dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                dgv.GridColor = BorderColor;
            }

            // Handle ListView
            else if (control is ListView)
            {
                ListView lst = (ListView)control;
                lst.BackColor = Color.White;
                lst.ForeColor = DarkText;
                lst.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                StyleListView(lst);
            }

            // Handle TextBoxes, ComboBoxes & DateTimePickers
            else if (control is TextBox)
            {
                TextBox tb = (TextBox)control;
                tb.BorderStyle = BorderStyle.FixedSingle;
                tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            }
            else if (control is ComboBox)
            {
                ComboBox cb = (ComboBox)control;
                cb.FlatStyle = FlatStyle.Flat;
                cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                cb.BackColor = Color.White;
            }
            else if (control is DateTimePicker)
            {
                DateTimePicker dtp = (DateTimePicker)control;
                dtp.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            }

            // Handle RadioButton & CheckBox
            else if (control is RadioButton)
            {
                RadioButton rdo = (RadioButton)control;
                rdo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                rdo.ForeColor = DarkText;
                rdo.Cursor = Cursors.Hand;
                rdo.CheckedChanged -= Radio_CheckedChanged;
                rdo.CheckedChanged += Radio_CheckedChanged;
                if (rdo.Checked) rdo.ForeColor = PrimaryDarkGreen;
            }
            else if (control is CheckBox)
            {
                CheckBox chk = (CheckBox)control;
                chk.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                chk.ForeColor = DarkText;
                chk.Cursor = Cursors.Hand;
            }

            // Handle GroupBox
            else if (control is GroupBox)
            {
                GroupBox gb = (GroupBox)control;
                gb.BackColor = Color.White;
                gb.ForeColor = PrimaryDarkGreen;
                gb.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                
                gb.Paint -= GroupBox_Paint;
                gb.Paint += GroupBox_Paint;
            }

            // Handle Panel
            else if (control is Panel)
            {
                Panel pnl = (Panel)control;
                if (pnl.Name != "panelSearchCard")
                {
                    pnl.Paint -= InputContainer_Paint;
                    pnl.Paint += InputContainer_Paint;
                }
            }

            // Handle Label
            else if (control is Label)
            {
                Label lbl = (Label)control;
                if (lbl.ForeColor == Color.Black || lbl.ForeColor == SystemColors.ControlText)
                {
                    lbl.ForeColor = DarkText;
                }
            }

            // Recursively process child controls
            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    StyleControl(child);
                }
            }
        }

        private static void Radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rdo = sender as RadioButton;
                if (rdo != null)
                {
                    rdo.ForeColor = rdo.Checked ? PrimaryDarkGreen : DarkText;
                }
            }
            catch { }
        }

        private static void InputContainer_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Control parent = (Control)sender;
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (Pen outlinePen = new Pen(Color.FromArgb(16, 185, 129), 1.5F))
                {
                    foreach (Control c in parent.Controls)
                    {
                        if (c != null && c.Visible && (c is ComboBox || c is TextBox || c is DateTimePicker))
                        {
                            if (c is TextBox && ((TextBox)c).Multiline && c.Height > 45) continue;

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

        private static void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                GroupBox gb = (GroupBox)sender;
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Fill background with pure white
                g.Clear(Color.White);

                // Draw a thin subtle rounded border around the groupbox bounds
                Rectangle borderRect = new Rectangle(0, 0, gb.Width - 1, gb.Height - 1);
                using (Pen borderPen = new Pen(Color.FromArgb(209, 231, 221), 1.5F))
                {
                    g.DrawRectangle(borderPen, borderRect);
                }

                // Draw the text header inside the groupbox top left
                if (!string.IsNullOrEmpty(gb.Text))
                {
                    using (Brush textBrush = new SolidBrush(PrimaryDarkGreen))
                    using (Font font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                    {
                        g.DrawString(gb.Text, font, textBrush, 12, 6);
                    }
                }

                // Draw outlines on child input controls
                using (Pen outlinePen = new Pen(Color.FromArgb(16, 185, 129), 1.5F))
                {
                    foreach (Control c in gb.Controls)
                    {
                        if (c != null && c.Visible && (c is ComboBox || c is TextBox || c is DateTimePicker))
                        {
                            if (c is TextBox && ((TextBox)c).Multiline && c.Height > 45) continue;

                            Rectangle rect = new Rectangle(c.Left - 1, c.Top - 1, c.Width + 1, c.Height + 1);
                            using (System.Drawing.Drawing2D.GraphicsPath p = GetRoundedRectPath(rect, 3))
                            {
                                g.DrawPath(outlinePen, p);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private static void StyleListView(ListView lst)
        {
            lst.OwnerDraw = true;
            lst.DrawColumnHeader += (s, e) =>
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                using (Font headerFont = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                using (Brush textBrush = new SolidBrush(PrimaryDarkGreen))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont, textBrush, e.Bounds.X + 8, e.Bounds.Y + 6);
                }
                using (Pen borderPen = new Pen(BorderColor, 1F))
                {
                    e.Graphics.DrawLine(borderPen, e.Bounds.X, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
            };

            lst.DrawItem += (s, e) =>
            {
                e.DrawDefault = false;
            };

            lst.DrawSubItem += (s, e) =>
            {
                bool isSelected = e.Item.Selected;
                Rectangle bounds = e.Bounds;

                if (isSelected)
                {
                    using (SolidBrush bgBrush = new SolidBrush(LightGreenTint))
                    {
                        e.Graphics.FillRectangle(bgBrush, bounds);
                    }
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, bounds);
                }

                using (Font cellFont = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                using (Brush textBrush = new SolidBrush(DarkText))
                {
                    e.Graphics.DrawString(e.SubItem.Text, cellFont, textBrush, bounds.X + 8, bounds.Y + 6);
                }

                using (Pen separatorPen = new Pen(Color.FromArgb(240, 240, 240), 1F))
                {
                    e.Graphics.DrawLine(separatorPen, bounds.X, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
                }
            };
        }

        private static void StyleGlassButton(Button btn, Color bg, Color fg, Color hoverBg)
        {
            try
            {
                Type type = btn.GetType();
                if (type.FullName == "Glass.GlassButton")
                {
                    var propInnerBorder = type.GetProperty("InnerBorderColor");
                    if (propInnerBorder != null) propInnerBorder.SetValue(btn, Color.Transparent, null);

                    var propOuterBorder = type.GetProperty("OuterBorderColor");
                    if (propOuterBorder != null) propOuterBorder.SetValue(btn, Color.Transparent, null);

                    var propShine = type.GetProperty("ShineColor");
                    if (propShine != null) propShine.SetValue(btn, Color.Transparent, null);

                    var propGlow = type.GetProperty("GlowColor");
                    if (propGlow != null) propGlow.SetValue(btn, hoverBg, null);
                }
            }
            catch { }
        }

        private static void StyleToolStripItem(ToolStripItem item)
        {
            if (item == null) return;
            item.ForeColor = Color.White;
            item.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            if (item is ToolStripDropDownItem)
            {
                ToolStripDropDownItem dropDownItem = (ToolStripDropDownItem)item;
                if (dropDownItem.HasDropDownItems)
                {
                    foreach (ToolStripItem child in dropDownItem.DropDownItems)
                    {
                        StyleSubMenuItem(child);
                    }
                }
            }
        }

        private static void StyleSubMenuItem(ToolStripItem item)
        {
            if (item == null) return;
            item.ForeColor = DarkText;
            item.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            if (item is ToolStripDropDownItem)
            {
                ToolStripDropDownItem dropDownItem = (ToolStripDropDownItem)item;
                if (dropDownItem.HasDropDownItems)
                {
                    foreach (ToolStripItem child in dropDownItem.DropDownItems)
                    {
                        StyleSubMenuItem(child);
                    }
                }
            }
        }
    }

    public class GreenColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin { get { return ThemeHelper.PrimaryDarkGreen; } }
        public override Color MenuStripGradientEnd { get { return ThemeHelper.PrimaryDarkGreen; } }

        public override Color ToolStripGradientBegin { get { return ThemeHelper.PrimaryDarkGreen; } }
        public override Color ToolStripGradientMiddle { get { return ThemeHelper.PrimaryDarkGreen; } }
        public override Color ToolStripGradientEnd { get { return ThemeHelper.PrimaryDarkGreen; } }

        public override Color MenuItemSelected { get { return ThemeHelper.EmeraldGreen; } }
        public override Color MenuItemSelectedGradientBegin { get { return ThemeHelper.EmeraldGreen; } }
        public override Color MenuItemSelectedGradientEnd { get { return ThemeHelper.EmeraldGreen; } }
        public override Color MenuItemBorder { get { return ThemeHelper.BorderColor; } }

        public override Color MenuItemPressedGradientBegin { get { return ThemeHelper.PrimaryDarkGreen; } }
        public override Color MenuItemPressedGradientEnd { get { return ThemeHelper.PrimaryDarkGreen; } }

        public override Color ToolStripDropDownBackground { get { return Color.White; } }
        public override Color ImageMarginGradientBegin { get { return ThemeHelper.LightGreenTint; } }
        public override Color ImageMarginGradientMiddle { get { return ThemeHelper.LightGreenTint; } }
        public override Color ImageMarginGradientEnd { get { return ThemeHelper.LightGreenTint; } }

        public override Color MenuBorder { get { return ThemeHelper.BorderColor; } }
    }

    public class GreenToolStripRenderer : ToolStripProfessionalRenderer
    {
        public GreenToolStripRenderer() : base(new GreenColorTable()) { }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.IsOnDropDown)
            {
                e.TextColor = e.Item.Selected ? Color.White : ThemeHelper.DarkText;
            }
            else
            {
                e.TextColor = Color.White;
            }
            base.OnRenderItemText(e);
        }
    }
}
