using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace School
{
    public static class ThemeHelper
    {
        // Fresh Leaf-Green Color Scheme for School/College Management System (EduCore Identity)
        public static readonly Color PrimaryDarkGreen = Color.FromArgb(8, 120, 61);      // #08783D - Deep Forest Green background for Sidebar
        public static readonly Color EmeraldGreen     = Color.FromArgb(28, 162, 80);    // #1CA250 - Vibrant Action Color
        public static readonly Color HoverGreen       = Color.FromArgb(20, 122, 62);    // #147A3E - Hover Color
        public static readonly Color ActiveGreen      = Color.FromArgb(21, 148, 71);    // #159447 - Active Sidebar Highlight
        public static readonly Color LightGreenTint   = Color.FromArgb(232, 245, 233);  // #E8F5E9 - Soft Row/Card Accent
        public static readonly Color BorderColor      = Color.FromArgb(221, 231, 225);  // #DDE7E1 - Light Neutral Border
        public static readonly Color DarkText         = Color.FromArgb(31, 41, 55);     // #1F2937 - Dark Slate Typography
        public static readonly Color MutedText        = Color.FromArgb(100, 116, 139);  // #64748B - Subtitle Text
        public static readonly Color OffWhiteBg       = Color.FromArgb(245, 247, 246);  // #F5F7F6 - Canvas Background
        public static readonly Color CardBg           = Color.White;                    // Pure White Card Bg
        public static readonly Color DangerRed        = Color.FromArgb(220, 38, 38);   // #DC2626 - Danger Red Color

        public static void ApplyTheme(Form form)
        {
            if (form == null) return;

            try
            {
                form.BackColor = OffWhiteBg;
                form.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                // Colorize MDI Client background if form is MDI Parent
                foreach (Control c in form.Controls)
                {
                    if (c is MdiClient)
                    {
                        c.BackColor = OffWhiteBg;
                    }
                }

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
                else if (formName == "frm_manage_students" || formName.Contains("manage_student"))
                {
                    StyleManageStudentsForm(form);
                }
                else if (formName.Contains("promotion") || formName.Contains("shifting"))
                {
                    StyleStudentPromotionsForm(form);
                }
                else if (formName == "frmdeletevoucher" || formName.Contains("deletevoucher") || formName == "frmunpostvoucher" || formName.Contains("unpostvoucher") || formName == "frmdeactivatestudent" || formName.Contains("deactivatestudent"))
                {
                    StyleProcessForm(form);
                }
                else if (formName == "frmchangesession" || formName.Contains("changesession"))
                {
                    StyleSessionSelectForm(form);
                }
                else if (formName == "frmsearch" || formName.Contains("search"))
                {
                    StyleSearchStudentForm(form);
                }
                else if (formName == "frmemployee" || formName.Contains("employee"))
                {
                    StyleEmployeeForm(form);
                }
                else if (formName == "frmshift" || formName.Contains("shift"))
                {
                    StyleShiftForm(form);
                }
                else if (formName == "frmfine" || formName.Contains("fine"))
                {
                    StyleFineForm(form);
                }
                else if (formName == "frmexpdetail" || formName.Contains("expdetail"))
                {
                    StyleExpenseDetailForm(form);
                }
                else if (formName == "frmfee_head" || formName.Contains("fee_head") || formName.Contains("feehead"))
                {
                    StyleFeeHeadForm(form);
                }
                else if (formName == "frm_generatefee_multi" || formName.Contains("generatefee") || formName == "frm_generatefee")
                {
                    StyleGenerateFeeForm(form);
                }
                else if (formName == "frm_editfee" || formName.Contains("editfee"))
                {
                    StyleEditFeeForm(form);
                }
                else if (formName.Contains("attend") || formName.Contains("award"))
                {
                    StyleAttendanceForm(form);
                }
                else if (formName.Contains("subject") || formName.Contains("exam") || formName.Contains("compile"))
                {
                    StyleAcademicsForm(form);
                }
                else if (formName.Contains("datewise") || formName.Contains("admission_datewise"))
                {
                    StyleDatewiseAdmissionReportForm(form);
                }
                else if (formName.Contains("_param") || formName.Contains("feereport") || formName.Contains("concession") || formName.Contains("stuckoff") || formName.Contains("defaulter"))
                {
                    StyleSummaryReportParamForm(form);
                }
                else if (formName == "frm_student_report" || formName.Contains("student_report"))
                {
                    StyleStudentReportForm(form);
                }
                else if (formName.Contains("student"))
                {
                    StyleStudentForm(form);
                }
                else
                {
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

        private static void CardContainer_Paint(object sender, PaintEventArgs e)
        {
            Control parent = sender as Control;
            if (parent == null) return;

            using (Pen borderPen = new Pen(Color.FromArgb(180, 195, 210), 1))
            using (Pen greenFocusPen = new Pen(Color.FromArgb(8, 120, 61), 1.5f))
            {
                foreach (Control child in parent.Controls)
                {
                    if ((child is ComboBox || child is TextBox || child is DateTimePicker) && child.Visible)
                    {
                        Rectangle r = new Rectangle(child.Left - 1, child.Top - 1, child.Width + 1, child.Height + 1);
                        Pen penToUse = child.Focused ? greenFocusPen : borderPen;
                        e.Graphics.DrawRectangle(penToUse, r);
                    }
                }
            }
        }

        private static void PanelSearchCard_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;
            using (Pen pen = new Pen(Color.FromArgb(163, 217, 165), 1.5f))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(pen, 1, 1, pnl.Width - 3, pnl.Height - 3);
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
                    else if (c is Panel && (c.Name == "panel2" || c.Name == "panel8" || c.Name == "panel7" || c.Name == "panel4"))
                    {
                        // Stat Cards 1..4 (White Cards with Green Accent)
                        Panel pnl = (Panel)c;
                        StyleDashboardPanel(pnl, false);
                        foreach (Control child in pnl.Controls)
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
                    else if (c is Panel && c.Name == "panel9")
                    {
                        // Stat Card 5 (Balance - Dark Green Card)
                        Panel pnl = (Panel)c;
                        StyleDashboardPanel(pnl, true);
                        foreach (Control child in pnl.Controls)
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
                    else if (c is Panel && (c.Name == "panel5" || c.Name == "panel6" || c.Name == "panel3"))
                    {
                        // Middle & Lower Cards
                        Panel pnl = (Panel)c;
                        StyleDashboardPanel(pnl, false);
                        foreach (Control child in pnl.Controls)
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

        private static void StyleDashboardPanel(Panel pnl, bool isDarkGreenCard)
        {
            pnl.BackColor = isDarkGreenCard ? PrimaryDarkGreen : CardBg;
            pnl.Paint -= DashboardPanel_Paint;
            pnl.Paint += (s, e) =>
            {
                using (Pen borderPen = new Pen(isDarkGreenCard ? PrimaryDarkGreen : Color.FromArgb(220, 230, 222), 1F))
                {
                    e.Graphics.DrawRectangle(borderPen, 0, 0, pnl.Width - 1, pnl.Height - 1);
                }
            };
        }

        private static void DashboardPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        public static ToolStripItem ActiveSidebarItem { get; set; }

        private static void StyleMdiAdmin(Form form)
        {
            try
            {
                form.ControlBox = true;

                foreach (Control c in form.Controls)
                {
                    if (c is MenuStrip && c.Name == "menuStrip1")
                    {
                        MenuStrip ms = (MenuStrip)c;
                        ms.AllowMerge = false;
                        ms.CanOverflow = false;
                        ms.BackgroundImage = null;
                        ms.BackColor = PrimaryDarkGreen;
                        ms.ForeColor = Color.White;
                        ms.AutoSize = false;
                        ms.Width = 125;
                        ms.GripStyle = ToolStripGripStyle.Hidden;
                        ms.Padding = new Padding(0, 4, 0, 4);
                        ms.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                        ms.ShowItemToolTips = false;
                        ms.Renderer = new GreenToolStripRenderer();

                        if (ActiveSidebarItem == null && ms.Items.Count > 0)
                        {
                            ActiveSidebarItem = ms.Items[0];
                        }

                        ms.ItemClicked -= MenuStrip1_ItemClicked;
                        ms.ItemClicked += MenuStrip1_ItemClicked;

                        UpdateSidebarItemSizes(ms);

                        form.Resize -= MdiAdmin_Resize;
                        form.Resize += MdiAdmin_Resize;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private static void MdiAdmin_Resize(object sender, EventArgs e)
        {
            try
            {
                Form f = sender as Form;
                if (f != null)
                {
                    MenuStrip ms = f.Controls["menuStrip1"] as MenuStrip;
                    if (ms != null)
                    {
                        UpdateSidebarItemSizes(ms);
                    }
                }
            }
            catch { }
        }

        private static void UpdateSidebarItemSizes(MenuStrip ms)
        {
            try
            {
                Form parentForm = ms.FindForm();
                int statusBarH = 24;
                if (parentForm != null)
                {
                    Control sb = parentForm.Controls["statusBar1"];
                    if (sb != null) statusBarH = sb.Height;
                }

                int availH = parentForm != null && parentForm.ClientSize.Height > 100
                    ? parentForm.ClientSize.Height - statusBarH - ms.Padding.Vertical - 4
                    : (ms.ClientSize.Height > 100 ? ms.ClientSize.Height - ms.Padding.Vertical - 4 : 700);

                int totalCount = 0;
                foreach (ToolStripItem it in ms.Items)
                {
                    if (it.Available) totalCount++;
                }
                if (totalCount == 0) totalCount = 9;

                // Responsive item height to guarantee all 9 buttons (including Exit) are permanently visible on any resolution
                int slotH = availH / totalCount;
                int marginV = slotH < 60 ? 1 : 2;
                int itemH = Math.Min(70, Math.Max(42, slotH - (marginV * 2)));

                foreach (ToolStripItem item in ms.Items)
                {
                    item.AutoSize = false;
                    item.Size = new Size(118, itemH);
                    item.Margin = new Padding(3, marginV, 3, marginV);
                    item.Padding = new Padding(0, 0, 0, 0);
                    item.BackColor = Color.Transparent;
                    item.ForeColor = Color.White;
                    item.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
                    item.TextImageRelation = TextImageRelation.ImageAboveText;

                    if (item is ToolStripMenuItem)
                    {
                        ToolStripMenuItem mi = (ToolStripMenuItem)item;
                        mi.DropDown.Renderer = new GreenToolStripRenderer();
                        mi.DropDownOpened -= MenuItem_DropDownOpened;
                        mi.DropDownOpened += MenuItem_DropDownOpened;
                        StyleSubMenuItems(mi);
                    }
                }

                ms.PerformLayout();
            }
            catch { }
        }

        private static void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null && !e.ClickedItem.IsOnDropDown)
            {
                ActiveSidebarItem = e.ClickedItem;
                MenuStrip ms = sender as MenuStrip;
                if (ms != null) ms.Invalidate();
            }
        }

        private static void MenuItem_DropDownOpened(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            if (mi != null)
            {
                ActiveSidebarItem = mi;
                if (mi.Owner != null) mi.Owner.Invalidate();
            }
        }

        private static void StyleSubMenuItems(ToolStripMenuItem parent)
        {
            try
            {
                ToolStripDropDown dropDown = parent.DropDown;
                dropDown.BackColor = Color.White;
                dropDown.DropShadowEnabled = true;
                dropDown.Padding = new Padding(6, 6, 6, 6);
                dropDown.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

                ToolStripDropDownMenu dropDownMenu = dropDown as ToolStripDropDownMenu;
                if (dropDownMenu != null)
                {
                    dropDownMenu.ShowImageMargin = true;
                    dropDownMenu.ShowCheckMargin = false;
                    dropDownMenu.ImageScalingSize = new Size(16, 16);
                }

                dropDown.Paint -= DropDown_Paint;
                dropDown.Paint += DropDown_Paint;

                foreach (ToolStripItem sub in parent.DropDownItems)
                {
                    if (sub is ToolStripMenuItem)
                    {
                        ToolStripMenuItem subMi = (ToolStripMenuItem)sub;
                        subMi.AutoSize = false;
                        subMi.Height = 36;
                        subMi.Width = 230;
                        subMi.Margin = new Padding(2, 1, 2, 1);
                        subMi.Padding = new Padding(8, 0, 8, 0);
                        subMi.ForeColor = Color.FromArgb(30, 41, 59);
                        subMi.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                        if (subMi.HasDropDownItems)
                        {
                            subMi.DropDown.Renderer = new GreenToolStripRenderer();
                            StyleSubMenuItems(subMi);
                        }
                    }
                    else if (sub is ToolStripSeparator)
                    {
                        ToolStripSeparator sep = (ToolStripSeparator)sub;
                        sep.Margin = new Padding(12, 3, 12, 3);
                    }
                }
            }
            catch { }
        }

        private static void DropDown_Paint(object sender, PaintEventArgs e)
        {
            ToolStripDropDown dropDown = sender as ToolStripDropDown;
            if (dropDown == null) return;
            try
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Pen borderPen = new Pen(Color.FromArgb(180, 215, 190), 1.2F))
                {
                    using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRect(new Rectangle(0, 0, dropDown.Width - 1, dropDown.Height - 1), 10))
                    {
                        dropDown.Region = new Region(path);
                        e.Graphics.DrawPath(borderPen, path);
                    }
                }
            }
            catch { }
        }

        public static System.Drawing.Drawing2D.GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(bounds.X, bounds.Y, diameter, diameter);

            path.AddArc(arc, 180, 90);

            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private static void StyleClassForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panel4) ───────────────────────────────────
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.BackColor = PrimaryDarkGreen;
                    panel4.Height = 60;
                    panel4.Paint -= PanelBottomBorder_Paint;

                    foreach (Control c in panel4.Controls)
                    {
                        if (c.Name == "label4" || c.Name == "label3" || c.Name == "label9")
                        {
                            c.ForeColor = Color.White;
                            c.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
                            c.Location = new Point(60, 13);
                        }
                        else if (c.Name == "label2")
                        {
                            c.ForeColor = Color.FromArgb(232, 245, 233);
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                            c.Location = new Point(310, 20);
                        }
                        else if (c.Name == "lbl_ModeVisual")
                        {
                            c.BackColor = Color.FromArgb(232, 245, 233);
                            c.ForeColor = PrimaryDarkGreen;
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            c.Location = new Point(form.Width - 160, 16);
                            c.Size = new Size(130, 28);
                        }
                        else if (c.Name == "label6" || c.Name == "label7")
                        {
                            c.Visible = false;
                        }
                    }
                }

                foreach (Control c in form.Controls)
                {
                    if (c.Name == "groupBox1" || c.Name == "panelCard")
                    {
                        c.BackColor = Color.White;
                        c.ForeColor = PrimaryDarkGreen;
                        c.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private static void StyleControl(Control control)
        {
            if (control == null) return;

            // Paint border on search panel card
            if (control.Name == "panelSearchCard")
            {
                control.BackColor = CardBg;
                control.Paint -= CardPanel_Paint;
                control.Paint += CardPanel_Paint;
            }

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

            if (control is BindingNavigator)
            {
                BindingNavigator bn = (BindingNavigator)control;
                bn.Renderer = new GreenToolStripRenderer();
                bn.BackColor = Color.White;
                bn.ForeColor = DarkText;
                bn.GripStyle = ToolStripGripStyle.Hidden;
                foreach (ToolStripItem item in bn.Items)
                {
                    item.ForeColor = DarkText;
                    item.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
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
                btn.FlatAppearance.BorderColor = BorderColor;
                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                string nameLower = (btn.Name ?? "").ToLower();
                string textLower = (btn.Text ?? "").ToLower();
                var parentForm = btn.FindForm();
                string formName = (parentForm != null ? parentForm.Name : "").ToLower();

                if (formName.Contains("manage_students"))
                {
                    if (nameLower == "btnadd")
                    {
                        btn.BackColor = PrimaryDarkGreen;
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                        btn.FlatAppearance.MouseOverBackColor = HoverGreen;
                    }
                    else if (nameLower == "button3" && !btn.Enabled)
                    {
                        btn.BackColor = Color.FromArgb(243, 244, 246);
                        btn.ForeColor = Color.FromArgb(156, 163, 175);
                        btn.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
                    }
                    else
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = PrimaryDarkGreen;
                        btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                        btn.FlatAppearance.MouseOverBackColor = LightGreenTint;
                    }
                }
                else if (nameLower.Contains("exit") || nameLower.Contains("close") || nameLower.Contains("delete") || textLower.Contains("close") || textLower.Contains("exit") || textLower.Contains("delete"))
                {
                    btn.BackColor = Color.FromArgb(220, 38, 38);
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 28, 28);
                }
                else if (nameLower.Contains("cancel") || nameLower.Contains("reset") || textLower.Contains("cancel") || textLower.Contains("reset"))
                {
                    btn.BackColor = Color.FromArgb(100, 116, 139);
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(71, 85, 105);
                }
                else
                {
                    btn.BackColor = PrimaryDarkGreen;
                    btn.ForeColor = Color.White;
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
                var parentForm = pnl.FindForm();
                string formName = (parentForm != null ? parentForm.Name : "").ToLower();

                bool isHeader = pnl.Dock == DockStyle.Top && (pnlName.Contains("header") || pnlName.Contains("top") || (pnlName == "panel4" && !formName.Contains("manage_students")));

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
                else if (pnlName == "panelsearchcard" || pnlName.Contains("searchcard") || pnlName.Contains("headpanel"))
                {
                    pnl.BackColor = Color.FromArgb(232, 245, 233);
                    pnl.Paint -= PanelSearchCard_Paint;
                    pnl.Paint += PanelSearchCard_Paint;
                }
                else if (pnlName.Contains("card") || pnlName.Contains("box") || pnlName.Contains("panel") || pnlName.Contains("pnl"))
                {
                    if (pnl.BackColor != PrimaryDarkGreen && pnl.BackColor != EmeraldGreen && pnl.BackColor != Color.FromArgb(232, 245, 233) && pnl.BackColor != Color.FromArgb(238, 247, 240))
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

                if (lst.View == View.Details)
                {
                    lst.OwnerDraw = true;
                    lst.DrawColumnHeader -= ListView_DrawColumnHeader;
                    lst.DrawColumnHeader += ListView_DrawColumnHeader;
                    lst.DrawItem -= ListView_DrawItem;
                    lst.DrawItem += ListView_DrawItem;
                    lst.DrawSubItem -= ListView_DrawSubItem;
                    lst.DrawSubItem += ListView_DrawSubItem;
                }
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
            }
            else if (control is DateTimePicker)
            {
                DateTimePicker dtp = (DateTimePicker)control;
                dtp.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            }

            // Handle GroupBox
            else if (control is GroupBox)
            {
                GroupBox gb = (GroupBox)control;
                gb.ForeColor = PrimaryDarkGreen;
                gb.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                var parentForm = gb.FindForm();
                if (parentForm != null && parentForm.Name.ToLower().Contains("student") && gb.Name == "groupBox1")
                {
                    gb.Text = "";
                }
            }
            // Handle TabControl
            else if (control is TabControl)
            {
                TabControl tab = (TabControl)control;
                tab.DrawMode = TabDrawMode.OwnerDrawFixed;
                tab.ItemSize = new Size(160, 32);
                tab.SizeMode = TabSizeMode.Fixed;
                tab.DrawItem -= TabControl_DrawItem;
                tab.DrawItem += TabControl_DrawItem;
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

        private static void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                using (Pen borderPen = new Pen(Color.FromArgb(220, 230, 222), 1F))
                {
                    e.Graphics.DrawRectangle(borderPen, 0, 0, control.Width - 1, control.Height - 1);
                }
            }
            catch { }
        }

        private static void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            try
            {
                using (Brush brush = new SolidBrush(PrimaryDarkGreen))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }

                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
                using (Font font = new Font("Segoe UI", 9.5F, FontStyle.Bold))
                {
                    TextRenderer.DrawText(e.Graphics, " " + e.Header.Text, font, e.Bounds, Color.White, flags);
                }

                using (Pen pen = new Pen(Color.FromArgb(20, 122, 62), 1F))
                {
                    e.Graphics.DrawLine(pen, e.Bounds.Right - 1, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom);
                }
            }
            catch { }
        }

        private static void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
        }

        private static void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                ListView lst = e.Item.ListView;
                bool isSelected = e.Item.Selected;

                if (isSelected)
                {
                    using (Brush brush = new SolidBrush(LightGreenTint))
                    {
                        e.Graphics.FillRectangle(brush, e.Bounds);
                    }
                }
                else
                {
                    Color bg = (e.ItemIndex % 2 == 0) ? Color.White : Color.FromArgb(249, 251, 249);
                    using (Brush brush = new SolidBrush(bg))
                    {
                        e.Graphics.FillRectangle(brush, e.Bounds);
                    }
                }

                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
                Color textColor = isSelected ? PrimaryDarkGreen : DarkText;
                TextRenderer.DrawText(e.Graphics, " " + e.SubItem.Text, lst.Font, e.Bounds, textColor, flags);

                using (Pen pen = new Pen(BorderColor, 1F))
                {
                    e.Graphics.DrawRectangle(pen, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                }
            }
            catch { }
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

        // ═══════════════════════════════════════════════════════════════════
        //  Promotion Form — column constants (shared between FROM and TO rows)
        // ═══════════════════════════════════════════════════════════════════
        private const int P_SESSION_X = 20;   private const int P_SESSION_W  = 162;
        private const int P_CLASS_X   = 197;  private const int P_CLASS_W    = 225;
        private const int P_SHIFT_X   = 437;  private const int P_SHIFT_W    = 170;
        private const int P_SECTION_X = 622;  private const int P_SECTION_W  = 190;
        private const int P_BTN_X     = 828;  private const int P_BTN_W      = 118;
        private const int P_CARD_HDR  = 36;   // height of green header stripe per card
        private const int P_LBL_Y     = 44;   // label row Y inside card
        private const int P_CTRL_Y    = 64;   // control row Y inside card
        private const int P_CTRL_H    = 28;   // control height
        private const int P_CARD_H    = 102;  // total card panel height

        private static void StyleStudentPromotionsForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panel4) ───────────────────────────────────────
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.Height = 76;
                    panel4.BackColor = Color.White;
                    panel4.Paint -= PanelBottomBorder_Paint;
                    panel4.Paint += PanelBottomBorder_Paint;

                    // Icon
                    Control pic = panel4.Controls["pictureBox10"];
                    if (pic != null) { pic.Location = new Point(20, 18); pic.Size = new Size(38, 38); }

                    // Title
                    Control title = panel4.Controls["label12"];
                    if (title != null)
                    {
                        title.Text = "Student Shifting / Promotions";
                        title.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                        title.ForeColor = PrimaryDarkGreen;
                        title.Location = new Point(68, 12);
                    }

                    // Subtitle (add once)
                    if (panel4.Controls["lbl_promo_sub"] == null)
                    {
                        Label sub = new Label();
                        sub.Name = "lbl_promo_sub";
                        sub.Text = "Transfer or promote students between classes, sections and sessions";
                        sub.Font = new Font("Segoe UI", 9F);
                        sub.ForeColor = MutedText;
                        sub.AutoSize = true;
                        sub.Location = new Point(68, 44);
                        sub.BackColor = Color.Transparent;
                        panel4.Controls.Add(sub);
                    }
                }

                // ── 2. FROM CARD (panel3) ─────────────────────────────────────────
                Panel panel3 = form.Controls["panel3"] as Panel;
                if (panel3 != null)
                {
                    panel3.Height = P_CARD_H;
                    panel3.BackColor = Color.White;
                    panel3.Paint -= PromoFromCard_Paint;
                    panel3.Paint += PromoFromCard_Paint;

                    // Section title
                    Control lbl4 = panel3.Controls["label4"];
                    if (lbl4 != null)
                    {
                        lbl4.Text = "FROM  —  Source";
                        lbl4.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                        lbl4.ForeColor = Color.White;
                        lbl4.BackColor = Color.Transparent;
                        lbl4.Location = new Point(P_SESSION_X, 10);
                        lbl4.AutoSize = true;
                    }

                    // Labels
                    foreach (Control c in panel3.Controls)
                    {
                        switch (c.Name)
                        {
                            case "label2": PromoLabel(c, "Session",  P_SESSION_X, P_LBL_Y); break;
                            case "label3": PromoLabel(c, "Class",    P_CLASS_X,   P_LBL_Y); break;
                            case "label5": PromoLabel(c, "Shift",    P_SHIFT_X,   P_LBL_Y); break;
                            case "label8": PromoLabel(c, "Section",  P_SECTION_X, P_LBL_Y); break;
                        }
                    }

                    // Dropdowns
                    PromoCombo(panel3.Controls["cmbsessionfrom"] as ComboBox, P_SESSION_X, P_CTRL_Y, P_SESSION_W);
                    PromoCombo(panel3.Controls["cmbclassfrom"]   as ComboBox, P_CLASS_X,   P_CTRL_Y, P_CLASS_W);
                    PromoCombo(panel3.Controls["cmbshift"]       as ComboBox, P_SHIFT_X,   P_CTRL_Y, P_SHIFT_W);
                    PromoCombo(panel3.Controls["cmbsection"]     as ComboBox, P_SECTION_X, P_CTRL_Y, P_SECTION_W);

                    // Show button (sits in FROM card)
                    PromoButton(panel3.Controls["btnfinditems_advance"] as Button,
                                P_BTN_X, P_CTRL_Y, P_BTN_W, P_CTRL_H,
                                "  Show", false);
                }

                // ── 3. TO CARD (panel1) ───────────────────────────────────────────
                Panel panel1 = form.Controls["panel1"] as Panel;
                if (panel1 != null)
                {
                    panel1.Height = P_CARD_H;
                    panel1.BackColor = Color.White;
                    panel1.Paint -= PromoToCard_Paint;
                    panel1.Paint += PromoToCard_Paint;

                    // Section title
                    Control lbl6 = panel1.Controls["label6"];
                    if (lbl6 != null)
                    {
                        lbl6.Text = "TO  —  Destination";
                        lbl6.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                        lbl6.ForeColor = Color.White;
                        lbl6.BackColor = Color.Transparent;
                        lbl6.Location = new Point(P_SESSION_X, 10);
                        lbl6.AutoSize = true;
                    }

                    // Labels
                    foreach (Control c in panel1.Controls)
                    {
                        switch (c.Name)
                        {
                            case "label10": PromoLabel(c, "Session",  P_SESSION_X, P_LBL_Y); break;
                            case "label9":  PromoLabel(c, "Class",    P_CLASS_X,   P_LBL_Y); break;
                            case "label7":  PromoLabel(c, "Shift",    P_SHIFT_X,   P_LBL_Y); break;
                            case "label1":  PromoLabel(c, "Section",  P_SECTION_X, P_LBL_Y); break;
                        }
                    }

                    // Dropdowns
                    PromoCombo(panel1.Controls["cmbsessionto"]  as ComboBox, P_SESSION_X, P_CTRL_Y, P_SESSION_W);
                    PromoCombo(panel1.Controls["cmbclassto"]    as ComboBox, P_CLASS_X,   P_CTRL_Y, P_CLASS_W);
                    PromoCombo(panel1.Controls["cmbshiftto"]    as ComboBox, P_SHIFT_X,   P_CTRL_Y, P_SHIFT_W);
                    PromoCombo(panel1.Controls["cmbsectionto"]  as ComboBox, P_SECTION_X, P_CTRL_Y, P_SECTION_W);

                    // Transfer button (primary action)
                    PromoButton(panel1.Controls["btntransfer"] as Button,
                                P_BTN_X, P_CTRL_Y, P_BTN_W, P_CTRL_H,
                                "  Transfer", true);
                }

                // ── 4. STUDENT GRID (panel2) ──────────────────────────────────────
                Panel panel2 = form.Controls["panel2"] as Panel;
                if (panel2 != null)
                {
                    panel2.BackColor = OffWhiteBg;

                    // Add section header once
                    if (panel2.Controls["pnl_grid_hdr"] == null)
                    {
                        Panel gridHdr = new Panel();
                        gridHdr.Name = "pnl_grid_hdr";
                        gridHdr.Height = 44;
                        gridHdr.Dock = DockStyle.Top;
                        gridHdr.BackColor = Color.White;
                        gridHdr.Paint += (s, e) =>
                        {
                            Control ctrl = (Control)s;
                            // Top separator line
                            using (Pen p = new Pen(BorderColor, 1))
                            {
                                e.Graphics.DrawLine(p, 0, 0, ctrl.Width, 0);
                                e.Graphics.DrawLine(p, 0, ctrl.Height - 1, ctrl.Width, ctrl.Height - 1);
                            }
                        };

                        Label gridTitle = new Label();
                        gridTitle.Name = "lbl_promo_grid";
                        gridTitle.Text = "STUDENTS TO BE PROMOTED";
                        gridTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        gridTitle.ForeColor = PrimaryDarkGreen;
                        gridTitle.AutoSize = true;
                        gridTitle.Location = new Point(20, 13);
                        gridTitle.BackColor = Color.Transparent;
                        gridHdr.Controls.Add(gridTitle);

                        panel2.Controls.Add(gridHdr);
                        gridHdr.SendToBack();
                    }

                    // Style the DataGridView
                    DataGridView grid = panel2.Controls["dataGridView1"] as DataGridView;
                    if (grid != null)
                    {
                        grid.BackgroundColor = Color.White;
                        grid.BorderStyle = BorderStyle.None;
                        grid.GridColor = BorderColor;
                        grid.Dock = DockStyle.Fill;
                        grid.BringToFront();
                        grid.Font = new Font("Segoe UI", 9F);
                        grid.RowTemplate.Height = 30;
                        grid.RowHeadersVisible = false;
                        grid.EnableHeadersVisualStyles = false;
                        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                        grid.ColumnHeadersHeight = 36;
                        grid.ScrollBars = ScrollBars.Both;

                        // Column header: forest green
                        grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDarkGreen;
                        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = PrimaryDarkGreen;
                        grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

                        // Cell styles
                        grid.DefaultCellStyle.BackColor = Color.White;
                        grid.DefaultCellStyle.ForeColor = DarkText;
                        grid.DefaultCellStyle.SelectionBackColor = LightGreenTint;
                        grid.DefaultCellStyle.SelectionForeColor = PrimaryDarkGreen;
                        grid.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

                        // Alternating rows: very subtle green tint
                        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 252, 249);
                        grid.AlternatingRowsDefaultCellStyle.ForeColor = DarkText;
                        grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = LightGreenTint;
                        grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = PrimaryDarkGreen;
                    }
                }
            }
            catch (Exception) { }
        }

        // ── Promo helpers ──────────────────────────────────────────────────────
        private static void PromoLabel(Control c, string text, int x, int y)
        {
            c.Text = text;
            c.Location = new Point(x, y);
            c.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            c.ForeColor = Color.FromArgb(148, 163, 184);
            c.AutoSize = true;
            c.BackColor = Color.Transparent;
        }

        private static void PromoCombo(ComboBox cmb, int x, int y, int w)
        {
            if (cmb == null) return;
            cmb.Location = new Point(x, y);
            cmb.Size = new Size(w, P_CTRL_H);
            cmb.Font = new Font("Segoe UI", 9.5F);
            cmb.BackColor = Color.White;
            cmb.ForeColor = DarkText;
        }

        private static void PromoButton(Button btn, int x, int y, int w, int h, string text, bool isPrimary)
        {
            if (btn == null) return;
            btn.Location = new Point(x, y);
            btn.Size = new Size(w, h);
            btn.Text = text;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
            btn.TextAlign = ContentAlignment.MiddleCenter;

            if (isPrimary)
            {
                // Transfer: solid green
                btn.BackColor = PrimaryDarkGreen;
                btn.ForeColor = Color.White;
            }
            else
            {
                // Show: slightly lighter green
                btn.BackColor = Color.FromArgb(28, 162, 80);
                btn.ForeColor = Color.White;
            }
        }

        // Card header stripe painters
        private static void PromoFromCard_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p == null) return;
            using (Brush b = new SolidBrush(PrimaryDarkGreen))
                e.Graphics.FillRectangle(b, 0, 0, p.Width, P_CARD_HDR);
            using (Pen pen = new Pen(BorderColor, 1))
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
        }

        private static void PromoToCard_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p == null) return;
            // Slightly lighter shade for TO card to visually differentiate
            using (Brush b = new SolidBrush(Color.FromArgb(20, 148, 72)))
                e.Graphics.FillRectangle(b, 0, 0, p.Width, P_CARD_HDR);
            using (Pen pen = new Pen(BorderColor, 1))
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
        }

        private static void StyleSearchStudentForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panelHeader) ──────────────────────────────
                Panel panelHeader = form.Controls["panelHeader"] as Panel;
                if (panelHeader != null)
                {
                    panelHeader.BackColor = Color.White;
                    panelHeader.Height = 65;
                    panelHeader.Paint -= PanelBottomBorder_Paint;
                    panelHeader.Paint += PanelBottomBorder_Paint;

                    foreach (Control c in panelHeader.Controls)
                    {
                        if (c.Name == "lblHeaderTitle")
                        {
                            c.ForeColor = PrimaryDarkGreen;
                            c.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                        }
                        else if (c.Name == "lblHeaderSub")
                        {
                            c.ForeColor = MutedText;
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        }
                    }
                }

                // ── 2. SEARCH PANEL (panelSearch) ─────────────────────────────
                Panel panelSearch = form.Controls["panelSearch"] as Panel;
                if (panelSearch != null)
                {
                    panelSearch.BackColor = Color.White;
                    panelSearch.Height = 70;
                    panelSearch.Paint -= PanelBottomBorder_Paint;
                    panelSearch.Paint += PanelBottomBorder_Paint;

                    foreach (Control c in panelSearch.Controls)
                    {
                        if (c is RadioButton)
                        {
                            c.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            c.ForeColor = DarkText;
                        }
                        else if (c is TextBox)
                        {
                            c.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                            c.BackColor = Color.White;
                            c.ForeColor = DarkText;
                        }
                        else if (c is Button)
                        {
                            Button btn = (Button)c;
                            if (btn.Name == "btn_Modify")
                            {
                                btn.BackColor = PrimaryDarkGreen;
                                btn.ForeColor = Color.White;
                                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                btn.FlatStyle = FlatStyle.Flat;
                                btn.FlatAppearance.BorderSize = 0;
                                btn.Cursor = Cursors.Hand;
                            }
                            else if (btn.Name == "btn_Close")
                            {
                                btn.BackColor = Color.White;
                                btn.ForeColor = PrimaryDarkGreen;
                                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                btn.FlatStyle = FlatStyle.Flat;
                                btn.FlatAppearance.BorderSize = 1;
                                btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                                btn.Cursor = Cursors.Hand;
                            }
                        }
                    }
                }

                // ── 3. DATA GRID / LISTVIEW CONTAINER (panelGrid) ────────────
                Panel panelGrid = form.Controls["panelGrid"] as Panel;
                if (panelGrid != null)
                {
                    panelGrid.BackColor = OffWhiteBg;
                    ListView lst = panelGrid.Controls["lstv_Student"] as ListView;
                    if (lst != null)
                    {
                        lst.BackColor = Color.White;
                        lst.ForeColor = DarkText;
                        lst.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        lst.OwnerDraw = true;
                        lst.DrawColumnHeader -= ListView_DrawColumnHeader;
                        lst.DrawColumnHeader += ListView_DrawColumnHeader;
                        lst.DrawItem -= ListView_DrawItem;
                        lst.DrawItem += ListView_DrawItem;
                        lst.DrawSubItem -= ListView_DrawSubItem;
                        lst.DrawSubItem += ListView_DrawSubItem;
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleStudentReportForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panel4) ───────────────────────────────────
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.BackColor = Color.White;
                    panel4.Height = 65;
                    panel4.Paint -= PanelBottomBorder_Paint;
                    panel4.Paint += PanelBottomBorder_Paint;

                    foreach (Control c in panel4.Controls)
                    {
                        if (c.Name == "label12")
                        {
                            c.ForeColor = PrimaryDarkGreen;
                            c.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                        }
                        else if (c.Name == "lblHeaderSub")
                        {
                            c.ForeColor = MutedText;
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        }
                    }
                }

                // ── 2. CONTENT AREA & CARDS ───────────────────────────────────
                Panel panelContent = form.Controls["panelContent"] as Panel;
                Control parentContainer = panelContent != null ? (Control)panelContent : form;

                foreach (Control c in parentContainer.Controls)
                {
                    if (c is GroupBox)
                    {
                        GroupBox gb = (GroupBox)c;
                        gb.BackColor = Color.White;
                        gb.ForeColor = PrimaryDarkGreen;
                        gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                        gb.Paint -= GroupBoxCard_Paint;
                        gb.Paint += GroupBoxCard_Paint;

                        foreach (Control child in gb.Controls)
                        {
                            if (child is Label)
                            {
                                Label lbl = (Label)child;
                                lbl.ForeColor = MutedText;
                                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                            else if (child is ComboBox)
                            {
                                ComboBox cb = (ComboBox)child;
                                cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                cb.BackColor = Color.White;
                                cb.ForeColor = DarkText;
                            }
                            else if (child is TextBox)
                            {
                                TextBox tb = (TextBox)child;
                                tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                tb.BackColor = Color.White;
                                tb.ForeColor = DarkText;
                            }
                            else if (child is CheckBox)
                            {
                                CheckBox chk = (CheckBox)child;
                                chk.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                chk.ForeColor = DarkText;
                            }
                            else if (child is Button)
                            {
                                Button btn = (Button)child;
                                btn.BackColor = PrimaryDarkGreen;
                                btn.ForeColor = Color.White;
                                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                btn.FlatStyle = FlatStyle.Flat;
                                btn.FlatAppearance.BorderSize = 0;
                                btn.Cursor = Cursors.Hand;
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private static void GroupBoxCard_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                GroupBox gb = sender as GroupBox;
                if (gb == null) return;
                using (Pen pen = new Pen(BorderColor, 1F))
                {
                    e.Graphics.DrawRectangle(pen, 0, 10, gb.Width - 1, gb.Height - 11);
                }
            }
            catch { }
        }

        private static void StyleSummaryReportParamForm(Form form)
        {
            if (form == null) return;

            try
            {
                form.BackColor = OffWhiteBg;
                form.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                // 1. Title Extraction & Header Panel
                string titleText = form.Text;
                Control oldTitle = form.Controls["label2"];
                if (oldTitle == null) oldTitle = form.Controls["label12"];
                if (oldTitle == null) oldTitle = form.Controls["lblTitle"];
                if (oldTitle != null && !string.IsNullOrEmpty(oldTitle.Text))
                {
                    titleText = oldTitle.Text;
                    oldTitle.Visible = false;
                }

                if (string.IsNullOrEmpty(titleText) || titleText == "Parameters" || titleText == "Form1")
                {
                    titleText = "Fee Summary Report Parameters";
                }

                Panel pnlHeader = form.Controls["panelHeader"] as Panel;
                if (pnlHeader == null)
                {
                    pnlHeader = new Panel();
                    pnlHeader.Name = "panelHeader";
                    pnlHeader.Height = 55;
                    pnlHeader.Dock = DockStyle.Top;
                    pnlHeader.BackColor = PrimaryDarkGreen;
                    form.Controls.Add(pnlHeader);
                    pnlHeader.SendToBack();

                    Label lblHeaderTitle = new Label();
                    lblHeaderTitle.Name = "lblHeaderTitle";
                    lblHeaderTitle.Text = titleText;
                    lblHeaderTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    lblHeaderTitle.ForeColor = Color.White;
                    lblHeaderTitle.AutoSize = true;
                    lblHeaderTitle.Location = new Point(20, 16);
                    lblHeaderTitle.BackColor = Color.Transparent;
                    pnlHeader.Controls.Add(lblHeaderTitle);
                }

                // 2. Card Container Panel
                Panel pnlCard = form.Controls["panelCard"] as Panel;
                if (pnlCard == null)
                {
                    pnlCard = new Panel();
                    pnlCard.Name = "panelCard";
                    pnlCard.BackColor = Color.White;

                    List<Control> controlsToMove = new List<Control>();
                    foreach (Control c in form.Controls)
                    {
                        if (c != pnlHeader && !(c is MenuStrip) && !(c is StatusStrip) && !(c is ToolStrip) && c.Name != "panelHeader")
                        {
                            controlsToMove.Add(c);
                        }
                    }

                    foreach (Control c in controlsToMove)
                    {
                        form.Controls.Remove(c);
                        pnlCard.Controls.Add(c);
                    }

                    form.Controls.Add(pnlCard);
                    pnlCard.BringToFront();
                }

                // 3. Card Position & Auto Resizing
                bool isHeadStudentWise = form.Name.ToLower().Contains("head_student_wise") || pnlCard.Controls["cmbtypefrom"] != null;

                int maxRowY = 25; // default row 1
                foreach (Control c in pnlCard.Controls)
                {
                    string name = (c.Name ?? "").ToLower();
                    if (name == "cmbclass" || name == "cmbclassfrom" || name == "cmbclassto" || name == "label3" || name == "label4")
                    {
                        if (142 > maxRowY) maxRowY = 142;
                    }
                    else if (name == "txtstartdate" || name == "txtenddate" || name == "dtpfrom" || name == "dtpto" || name == "label7" || name == "label6")
                    {
                        if (102 > maxRowY) maxRowY = 102;
                    }
                    else if (name == "cmbshift" || name == "cmbsection" || name == "cmbsectionfrom" || name == "checkbox1" || name == "label8" || name == "cmb_bankfrom" || name == "cmb_bankto")
                    {
                        if (62 > maxRowY) maxRowY = 62;
                    }
                }

                int baseCardH = 155;
                if (isHeadStudentWise) baseCardH = 310;
                else if (maxRowY >= 142) baseCardH = 275;
                else if (maxRowY >= 102) baseCardH = 235;
                else if (maxRowY >= 62) baseCardH = 195;
                else baseCardH = 155;

                int cardW = Math.Min(Math.Max(form.ClientSize.Width - 48, 500), 720);
                int cardH = baseCardH;
                if (form.ClientSize.Height >= 70 + baseCardH + 35)
                {
                    cardH = Math.Min(Math.Max(form.ClientSize.Height - 85, baseCardH), 450);
                }

                // Ensure form client size can comfortably show the card and buttons
                int neededFormW = Math.Max(form.ClientSize.Width, cardW + 40);
                int neededFormH = Math.Max(form.ClientSize.Height, 70 + cardH + 25);
                if (form.ClientSize.Width < neededFormW || form.ClientSize.Height < neededFormH)
                {
                    form.ClientSize = new Size(Math.Max(form.ClientSize.Width, neededFormW), Math.Max(form.ClientSize.Height, neededFormH));
                }

                pnlCard.Size = new Size(cardW, cardH);
                pnlCard.Location = new Point((form.ClientSize.Width - cardW) / 2, 70);

                form.Resize += (s, e) =>
                {
                    try
                    {
                        int w = Math.Min(Math.Max(form.ClientSize.Width - 48, 500), 720);
                        int h = Math.Min(Math.Max(form.ClientSize.Height - 85, baseCardH), 450);
                        pnlCard.Size = new Size(w, h);
                        pnlCard.Location = new Point((form.ClientSize.Width - w) / 2, 70);
                    }
                    catch { }
                };

                pnlCard.Paint -= CardContainer_Paint;
                pnlCard.Paint += CardContainer_Paint;

                // 4. Align and Style Controls inside pnlCard
                if (isHeadStudentWise)
                {
                    StyleHeadStudentWiseCardControls(pnlCard);
                }
                else
                {
                    StyleSummaryCardControls(pnlCard);
                }
            }
            catch (Exception) { }
        }

        private static void StyleHeadStudentWiseCardControls(Panel pnlCard)
        {
            if (pnlCard == null) return;

            int col1LabelX = 35;
            int col1CtrlX  = 175;
            int col1Width  = 145;

            int col2LabelX = 360;
            int col2CtrlX  = 490;
            int col2Width  = 145;

            int row1Y = 25;
            int row2Y = 67;
            int row3Y = 109;
            int row4Y = 151;
            int row5Y = 195;
            int row6Y = 245;

            foreach (Control c in pnlCard.Controls)
            {
                string name = (c.Name ?? "").ToLower();
                if (name == "label2" || name == "label12" || name == "lbltitle")
                {
                    c.Visible = false;
                    continue;
                }

                // ── Labels ──────────────────────────────────────────
                if (c is Label)
                {
                    Label lbl = (Label)c;
                    lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    lbl.ForeColor = DarkText;
                    lbl.AutoSize = true;

                    // Row 1: Fee Month & Paid Status
                    if (name == "label1") { lbl.Location = new Point(col1LabelX, row1Y + 3); }
                    else if (name == "label5") { lbl.Location = new Point(col2LabelX, row1Y + 3); }

                    // Row 2: Class From & Class To
                    else if (name == "label3") { lbl.Location = new Point(col1LabelX, row2Y + 3); }
                    else if (name == "label4") { lbl.Location = new Point(col2LabelX, row2Y + 3); }

                    // Row 3: Section From & Section To
                    else if (name == "label6") { lbl.Location = new Point(col1LabelX, row3Y + 3); }
                    else if (name == "label7") { lbl.Location = new Point(col2LabelX, row3Y + 3); }

                    // Row 4: Student Type From & Student Type To
                    else if (name == "label8") { lbl.Location = new Point(col1LabelX, row4Y + 3); }
                    else if (name == "label9") { lbl.Location = new Point(col2LabelX, row4Y + 3); }
                }

                // ── Inputs ──────────────────────────────────────────
                else if (c is ComboBox || c is DateTimePicker || c is TextBox)
                {
                    c.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    c.BackColor = Color.White;

                    // Row 1
                    if (name == "cmbmonth")
                    {
                        c.Location = new Point(col1CtrlX, row1Y);
                        c.Size = new Size(col1Width, 26);
                    }
                    else if (name == "combobox1")
                    {
                        c.Location = new Point(col2CtrlX, row1Y);
                        c.Size = new Size(col2Width, 26);
                    }

                    // Row 2
                    else if (name == "cmbclassfrom")
                    {
                        c.Location = new Point(col1CtrlX, row2Y);
                        c.Size = new Size(col1Width, 26);
                    }
                    else if (name == "cmbclassto")
                    {
                        c.Location = new Point(col2CtrlX, row2Y);
                        c.Size = new Size(col2Width, 26);
                    }

                    // Row 3
                    else if (name == "cmbsectionfrom")
                    {
                        c.Location = new Point(col1CtrlX, row3Y);
                        c.Size = new Size(col1Width, 26);
                    }
                    else if (name == "cmbsectionto")
                    {
                        c.Location = new Point(col2CtrlX, row3Y);
                        c.Size = new Size(col2Width, 26);
                    }

                    // Row 4
                    else if (name == "cmbtypefrom")
                    {
                        c.Location = new Point(col1CtrlX, row4Y);
                        c.Size = new Size(col1Width, 26);
                    }
                    else if (name == "cmbtypeto")
                    {
                        c.Location = new Point(col2CtrlX, row4Y);
                        c.Size = new Size(col2Width, 26);
                    }
                }

                // ── CheckBoxes ──────────────────────────────────────
                else if (c is CheckBox)
                {
                    CheckBox chk = (CheckBox)c;
                    chk.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    chk.ForeColor = DarkText;
                    chk.Cursor = Cursors.Hand;
                    chk.AutoSize = true;

                    if (name == "checkbox1")
                    {
                        chk.Location = new Point(col1LabelX, row5Y);
                    }
                }

                // ── Buttons ─────────────────────────────────────────
                else if (c is Button || c.GetType().Name.Contains("GlassButton"))
                {
                    Control btn = c;
                    string btnText = (btn.Text ?? "").ToLower();

                    if (btnText.Contains("generate") || btnText.Contains("save") || name == "btnsave")
                    {
                        btn.BackColor = PrimaryDarkGreen;
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        btn.Size = new Size(145, 36);
                        btn.Location = new Point(col2CtrlX + col2Width - 100 - 15 - 145, row6Y);
                        btn.Cursor = Cursors.Hand;
                    }
                    else if (btnText.Contains("close") || name == "frmclose")
                    {
                        btn.BackColor = Color.FromArgb(241, 245, 249);
                        btn.ForeColor = DarkText;
                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        btn.Size = new Size(100, 36);
                        btn.Location = new Point(col2CtrlX + col2Width - 100, row6Y);
                        btn.Cursor = Cursors.Hand;
                    }
                }
            }
        }

        private static void StyleSummaryCardControls(Panel pnlCard)
        {
            int col1LabelX = 30;
            int col1CtrlX  = 165;
            int col1Width  = 165;

            int col2LabelX = 355;
            int col2CtrlX  = 490;
            int col2Width  = 165;

            int row1Y = 22;
            int row2Y = 62;
            int row3Y = 102;
            int row4Y = 142;

            foreach (Control c in pnlCard.Controls)
            {
                string name = (c.Name ?? "").ToLower();

                // Skip header title labels that were migrated to panelHeader
                if (name == "label2" || name == "label12" || name == "lbltitle")
                {
                    c.Visible = false;
                    continue;
                }

                // ── Labels ──────────────────────────────────────────
                if (c is Label)
                {
                    Label lbl = (Label)c;
                    lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    lbl.ForeColor = DarkText;
                    lbl.Visible = true;

                    if (name == "label1") { lbl.Location = new Point(col1LabelX, row1Y + 4); }
                    else if (name == "label5") { lbl.Location = new Point(col2LabelX, row1Y + 4); }
                    else if (name == "label7") { lbl.Location = new Point(col1LabelX, row3Y + 4); }
                    else if (name == "label6") { lbl.Location = new Point(col2LabelX, row3Y + 4); }
                    else if (name == "label3")
                    {
                        if (pnlCard.Controls["cmb_bankfrom"] != null)
                            lbl.Location = new Point(col1LabelX, row2Y + 4);
                        else
                            lbl.Location = new Point(col1LabelX, row4Y + 4);
                    }
                    else if (name == "label4")
                    {
                        if (pnlCard.Controls["cmb_bankto"] != null)
                            lbl.Location = new Point(col2LabelX, row2Y + 4);
                        else
                            lbl.Location = new Point(col2LabelX, row4Y + 4);
                    }
                    else if (name == "label8") { lbl.Location = new Point(col1LabelX, row2Y + 4); }
                }

                // ── Inputs ──────────────────────────────────────────
                else if (c is ComboBox || c is DateTimePicker || c is TextBox)
                {
                    c.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    c.BackColor = Color.White;
                    c.Visible = true;

                    if (name == "cmbmonth" || name == "cmbmonthfrom" || name == "cmbsession" || name == "cmbsessionfrom" || name == "txtmonth" || name == "txtdatefrom")
                    {
                        c.Location = new Point(col1CtrlX, row1Y);
                        c.Size = new Size(col1Width, 25);
                    }
                    else if (name == "datetimepicker1" || name == "cmbmonthto" || name == "cmbsessionto" || name == "txtdateto")
                    {
                        c.Location = new Point(col2CtrlX, row1Y);
                        c.Size = new Size(col2Width, 25);
                    }
                    else if (name == "cmb_bankfrom")
                    {
                        c.Location = new Point(col1CtrlX, row2Y);
                        c.Size = new Size(col1Width, 25);
                    }
                    else if (name == "cmb_bankto")
                    {
                        c.Location = new Point(col2CtrlX, row2Y);
                        c.Size = new Size(col2Width, 25);
                    }
                    else if (name == "txtstartdate" || name == "dtpfrom")
                    {
                        c.Location = new Point(col1CtrlX, row3Y);
                        c.Size = new Size(col1Width, 25);
                    }
                    else if (name == "txtenddate" || name == "dtpto")
                    {
                        c.Location = new Point(col2CtrlX, row3Y);
                        c.Size = new Size(col2Width, 25);
                    }
                    else if (name == "cmbclass" || name == "cmbclassfrom")
                    {
                        c.Location = new Point(col1CtrlX, row4Y);
                        c.Size = new Size(col1Width, 25);
                    }
                    else if (name == "cmbclassto")
                    {
                        c.Location = new Point(col2CtrlX, row4Y);
                        c.Size = new Size(col2Width, 25);
                    }
                    else if (name == "cmbshift")
                    {
                        c.Location = new Point(col1CtrlX, row2Y);
                        c.Size = new Size(col1Width, 25);
                    }
                    else if (name == "cmbsection" || name == "cmbsectionfrom")
                    {
                        c.Location = new Point(col2CtrlX, row2Y);
                        c.Size = new Size(col2Width, 25);
                    }
                }

                // ── CheckBoxes ──────────────────────────────────────
                else if (c is CheckBox)
                {
                    CheckBox chk = (CheckBox)c;
                    chk.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    chk.ForeColor = DarkText;
                    chk.Cursor = Cursors.Hand;
                    chk.Visible = true;

                    if (name == "checkbox1")
                    {
                        chk.Location = new Point(col1LabelX, row2Y + 4);
                    }
                }

                // ── Buttons ─────────────────────────────────────────
                else if (c is Button || c.GetType().Name.Contains("GlassButton"))
                {
                    Control btn = c;
                    string btnText = (btn.Text ?? "").ToLower();
                    btn.Visible = true;
                    btn.BringToFront();

                    if (btnText.Contains("save") || btnText.Contains("generate") || btnText.Contains("preview") || btnText.Contains("print") || btnText.Contains("show") || name.Contains("save") || name.Contains("print"))
                    {
                        btn.BackColor = PrimaryDarkGreen;
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        btn.Size = new Size(145, 36);
                        btn.Location = new Point(pnlCard.Width - 275, pnlCard.Height - 52);
                        btn.Cursor = Cursors.Hand;
                        btn.BringToFront();
                    }
                    else if (btnText.Contains("close") || btnText.Contains("cancel") || btnText.Contains("exit") || name.Contains("close"))
                    {
                        btn.BackColor = Color.FromArgb(241, 245, 249);
                        btn.ForeColor = DarkText;
                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        btn.Size = new Size(100, 36);
                        btn.Location = new Point(pnlCard.Width - 120, pnlCard.Height - 52);
                        btn.Cursor = Cursors.Hand;
                        btn.BringToFront();
                    }
                }
            }
        }

        private static void StyleMonthwiseStrengthReportForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panelHeader) ──────────────────────────────
                Panel panelHeader = form.Controls["panelHeader"] as Panel;
                if (panelHeader != null)
                {
                    panelHeader.BackColor = Color.White;
                    panelHeader.Height = 65;
                    panelHeader.Paint -= PanelBottomBorder_Paint;
                    panelHeader.Paint += PanelBottomBorder_Paint;

                    foreach (Control c in panelHeader.Controls)
                    {
                        if (c.Name == "lblHeaderTitle")
                        {
                            c.ForeColor = PrimaryDarkGreen;
                            c.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                        }
                        else if (c.Name == "lblHeaderSub")
                        {
                            c.ForeColor = MutedText;
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        }
                    }
                }

                // ── 2. CONTENT AREA & CARD ────────────────────────────────────
                Panel panelContent = form.Controls["panelContent"] as Panel;
                Control parentContainer = panelContent != null ? (Control)panelContent : form;

                foreach (Control c in parentContainer.Controls)
                {
                    if (c is GroupBox)
                    {
                        GroupBox gb = (GroupBox)c;
                        gb.BackColor = Color.White;
                        gb.ForeColor = PrimaryDarkGreen;
                        gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                        gb.Paint -= GroupBoxCard_Paint;
                        gb.Paint += GroupBoxCard_Paint;

                        foreach (Control child in gb.Controls)
                        {
                            if (child is Label)
                            {
                                Label lbl = (Label)child;
                                lbl.ForeColor = MutedText;
                                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                            else if (child is ComboBox)
                            {
                                ComboBox cb = (ComboBox)child;
                                cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                cb.BackColor = Color.White;
                                cb.ForeColor = DarkText;
                            }
                            else if (child is DateTimePicker)
                            {
                                DateTimePicker dtp = (DateTimePicker)child;
                                dtp.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                            }
                            else if (child is Button)
                            {
                                Button btn = (Button)child;
                                if (btn.Name == "btnprint")
                                {
                                    btn.BackColor = PrimaryDarkGreen;
                                    btn.ForeColor = Color.White;
                                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                    btn.FlatStyle = FlatStyle.Flat;
                                    btn.FlatAppearance.BorderSize = 0;
                                    btn.Cursor = Cursors.Hand;
                                }
                                else if (btn.Name == "btnclose")
                                {
                                    btn.BackColor = Color.White;
                                    btn.ForeColor = PrimaryDarkGreen;
                                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                    btn.FlatStyle = FlatStyle.Flat;
                                    btn.FlatAppearance.BorderSize = 1;
                                    btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                                    btn.Cursor = Cursors.Hand;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleDatewiseAdmissionReportForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panelHeader) ──────────────────────────────
                Panel panelHeader = form.Controls["panelHeader"] as Panel;
                if (panelHeader != null)
                {
                    panelHeader.BackColor = Color.White;
                    panelHeader.Height = 65;
                    panelHeader.Paint -= PanelBottomBorder_Paint;
                    panelHeader.Paint += PanelBottomBorder_Paint;

                    foreach (Control c in panelHeader.Controls)
                    {
                        if (c.Name == "label1")
                        {
                            c.ForeColor = PrimaryDarkGreen;
                            c.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                        }
                        else if (c.Name == "lblHeaderSub")
                        {
                            c.ForeColor = MutedText;
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        }
                    }
                }

                // ── 2. CONTENT AREA & CARD ────────────────────────────────────
                Panel panelContent = form.Controls["panelContent"] as Panel;
                Control parentContainer = panelContent != null ? (Control)panelContent : form;

                foreach (Control c in parentContainer.Controls)
                {
                    if (c is GroupBox)
                    {
                        GroupBox gb = (GroupBox)c;
                        gb.BackColor = Color.White;
                        gb.ForeColor = PrimaryDarkGreen;
                        gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                        gb.Paint -= GroupBoxCard_Paint;
                        gb.Paint += GroupBoxCard_Paint;

                        foreach (Control child in gb.Controls)
                        {
                            if (child is Label)
                            {
                                Label lbl = (Label)child;
                                lbl.ForeColor = MutedText;
                                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                            else if (child is DateTimePicker)
                            {
                                DateTimePicker dtp = (DateTimePicker)child;
                                dtp.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                            }
                            else if (child is Button)
                            {
                                Button btn = (Button)child;
                                if (btn.Name == "btnprint")
                                {
                                    btn.BackColor = PrimaryDarkGreen;
                                    btn.ForeColor = Color.White;
                                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                    btn.FlatStyle = FlatStyle.Flat;
                                    btn.FlatAppearance.BorderSize = 0;
                                    btn.Cursor = Cursors.Hand;
                                }
                                else if (btn.Name == "btnclose")
                                {
                                    btn.BackColor = Color.White;
                                    btn.ForeColor = PrimaryDarkGreen;
                                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                    btn.FlatStyle = FlatStyle.Flat;
                                    btn.FlatAppearance.BorderSize = 1;
                                    btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                                    btn.Cursor = Cursors.Hand;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleEmployeeForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panel4) ───────────────────────────────────
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.BackColor = Color.White;
                    panel4.Height = 65;
                    panel4.Paint -= PanelBottomBorder_Paint;
                    panel4.Paint += PanelBottomBorder_Paint;

                    foreach (Control c in panel4.Controls)
                    {
                        if (c.Name == "label23")
                        {
                            c.ForeColor = PrimaryDarkGreen;
                            c.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                        }
                        else if (c.Name == "lblHeaderSub")
                        {
                            c.ForeColor = MutedText;
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        }
                        else if (c.Name == "label15" || c.Name == "label3")
                        {
                            c.ForeColor = MutedText;
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        }
                        else if (c.Name == "lbl_Mode")
                        {
                            c.ForeColor = DangerRed;
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        }
                        else if (c is RadioButton)
                        {
                            RadioButton rdo = (RadioButton)c;
                            rdo.ForeColor = PrimaryDarkGreen;
                            rdo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        }
                        else if (c is Button)
                        {
                            Button btn = (Button)c;
                            btn.BackColor = PrimaryDarkGreen;
                            btn.ForeColor = Color.White;
                            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderSize = 0;
                            btn.Cursor = Cursors.Hand;
                        }
                    }
                }

                // ── 2. CONTENT AREA & CARD (groupBox1 inside panelContent) ───
                Panel panelContent = form.Controls["panelContent"] as Panel;
                Control parentContainer = panelContent != null ? (Control)panelContent : form;

                GroupBox gb = parentContainer.Controls["groupBox1"] as GroupBox;
                if (gb != null)
                {
                    gb.BackColor = Color.White;
                    gb.ForeColor = PrimaryDarkGreen;
                    gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

                    gb.Paint -= GroupBoxCard_Paint;
                    gb.Paint += GroupBoxCard_Paint;

                    foreach (Control child in gb.Controls)
                    {
                        if (child is Label)
                        {
                            Label lbl = (Label)child;
                            lbl.ForeColor = MutedText;
                            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        }
                        else if (child is TextBox)
                        {
                            TextBox tb = (TextBox)child;
                            tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                            tb.BackColor = Color.White;
                            tb.ForeColor = DarkText;
                        }
                        else if (child is ComboBox)
                        {
                            ComboBox cb = (ComboBox)child;
                            cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                            cb.BackColor = Color.White;
                            cb.ForeColor = DarkText;
                        }
                        else if (child is DateTimePicker)
                        {
                            DateTimePicker dtp = (DateTimePicker)child;
                            dtp.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                        }
                        else if (child is CheckBox)
                        {
                            CheckBox chk = (CheckBox)child;
                            chk.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            chk.ForeColor = PrimaryDarkGreen;
                        }
                        else if (child is GroupBox) // groupBox2 (Buttons bar)
                        {
                            GroupBox gbBtns = (GroupBox)child;
                            gbBtns.BackColor = Color.White;
                            foreach (Control btnCtrl in gbBtns.Controls)
                            {
                                if (btnCtrl is Button || btnCtrl is Glass.GlassButton)
                                {
                                    Control btn = btnCtrl;
                                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                    btn.Cursor = Cursors.Hand;

                                    if (btn.Name == "btnSave" || btn.Name == "btnUpdate" || btn.Name == "btnrefresh")
                                    {
                                        btn.BackColor = PrimaryDarkGreen;
                                        btn.ForeColor = Color.White;
                                    }
                                    else if (btn.Name == "btnDel")
                                    {
                                        btn.BackColor = DangerRed;
                                        btn.ForeColor = Color.White;
                                    }
                                    else if (btn.Name == "btnCancel")
                                    {
                                        btn.BackColor = Color.FromArgb(107, 114, 128);
                                        btn.ForeColor = Color.White;
                                    }
                                    else if (btn.Name == "btnclose")
                                    {
                                        btn.BackColor = Color.White;
                                        btn.ForeColor = PrimaryDarkGreen;
                                    }
                                }
                            }
                        }
                    }
                }

                // ── 3. SEARCH PANEL (panel3) ──────────────────────────────────
                Panel panel3 = parentContainer.Controls["panel3"] as Panel;
                if (panel3 != null)
                {
                    panel3.BackColor = Color.White;
                    foreach (Control child in panel3.Controls)
                    {
                        if (child.Name == "label20")
                        {
                            child.ForeColor = PrimaryDarkGreen;
                            child.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                        }
                        else if (child.Name == "label18")
                        {
                            child.ForeColor = MutedText;
                            child.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        }
                        else if (child.Name == "linkLabel1")
                        {
                            child.ForeColor = DangerRed;
                            child.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        }
                        else if (child is ListView)
                        {
                            ListView lst = (ListView)child;
                            lst.BackColor = Color.White;
                            lst.ForeColor = DarkText;
                            lst.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                            lst.OwnerDraw = true;
                            lst.DrawColumnHeader -= ListView_DrawColumnHeader;
                            lst.DrawColumnHeader += ListView_DrawColumnHeader;
                            lst.DrawItem -= ListView_DrawItem;
                            lst.DrawItem += ListView_DrawItem;
                            lst.DrawSubItem -= ListView_DrawSubItem;
                            lst.DrawSubItem += ListView_DrawSubItem;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleShiftForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panel4) ───────────────────────────────────
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.BackColor = PrimaryDarkGreen;
                    panel4.Height = 60;
                    panel4.Paint -= PanelBottomBorder_Paint;

                    foreach (Control c in panel4.Controls)
                    {
                        if (c.Name == "label2" || c.Name == "label3" || c.Name == "label4" || c.Name == "label6" || c.Name == "label9")
                        {
                            c.ForeColor = Color.White;
                            c.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
                        }
                        else if (c.Name == "lblHeaderSub")
                        {
                            c.ForeColor = Color.FromArgb(232, 245, 233);
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        }
                    }
                }

                // ── 2. CONTENT CONTAINER & CARDS ─────────────────────────────
                Panel panelContent = form.Controls["panelContent"] as Panel;
                Control parentContainer = panelContent != null ? (Control)panelContent : form;

                foreach (Control c in parentContainer.Controls)
                {
                    if (c is GroupBox)
                    {
                        GroupBox gb = (GroupBox)c;
                        gb.BackColor = Color.White;
                        gb.ForeColor = PrimaryDarkGreen;
                        gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        gb.Paint -= GroupBoxCard_Paint;
                        gb.Paint += GroupBoxCard_Paint;

                        foreach (Control child in gb.Controls)
                        {
                            if (child is Label)
                            {
                                Label lbl = (Label)child;
                                lbl.ForeColor = MutedText;
                                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                            else if (child is TextBox)
                            {
                                TextBox tb = (TextBox)child;
                                tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                tb.BackColor = Color.White;
                                tb.ForeColor = DarkText;
                            }
                            else if (child is Button)
                            {
                                Button btn = (Button)child;
                                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                btn.Cursor = Cursors.Hand;

                                if (btn.Name == "btnsave" || btn.Name == "btnupdate")
                                {
                                    btn.BackColor = PrimaryDarkGreen;
                                    btn.ForeColor = Color.White;
                                    btn.FlatStyle = FlatStyle.Flat;
                                    btn.FlatAppearance.BorderSize = 0;
                                }
                                else if (btn.Name == "btndelete")
                                {
                                    btn.BackColor = DangerRed;
                                    btn.ForeColor = Color.White;
                                    btn.FlatStyle = FlatStyle.Flat;
                                    btn.FlatAppearance.BorderSize = 0;
                                }
                                else if (btn.Name == "button1")
                                {
                                    btn.BackColor = Color.White;
                                    btn.ForeColor = PrimaryDarkGreen;
                                    btn.FlatStyle = FlatStyle.Flat;
                                    btn.FlatAppearance.BorderSize = 1;
                                    btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                                }
                            }
                            else if (child is ListView)
                            {
                                ListView lst = (ListView)child;
                                lst.BackColor = Color.White;
                                lst.ForeColor = DarkText;
                                lst.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                lst.OwnerDraw = true;
                                lst.DrawColumnHeader -= ListView_DrawColumnHeader;
                                lst.DrawColumnHeader += ListView_DrawColumnHeader;
                                lst.DrawItem -= ListView_DrawItem;
                                lst.DrawItem += ListView_DrawItem;
                                lst.DrawSubItem -= ListView_DrawSubItem;
                                lst.DrawSubItem += ListView_DrawSubItem;
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleFineForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panel4) ───────────────────────────────────
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.BackColor = PrimaryDarkGreen;
                    panel4.Height = 60;
                    panel4.Paint -= PanelBottomBorder_Paint;

                    foreach (Control c in panel4.Controls)
                    {
                        if (c.Name == "label3")
                        {
                            c.ForeColor = Color.White;
                            c.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
                        }
                        else if (c.Name == "lblHeaderSub")
                        {
                            c.ForeColor = Color.FromArgb(232, 245, 233);
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        }
                    }
                }

                // ── 2. CONTENT AREA & CARDS ───────────────────────────────────
                Panel panelContent = form.Controls["panelContent"] as Panel;
                Control parentContainer = panelContent != null ? (Control)panelContent : form;

                foreach (Control c in parentContainer.Controls)
                {
                    if (c is GroupBox)
                    {
                        GroupBox gb = (GroupBox)c;
                        gb.BackColor = Color.White;
                        gb.ForeColor = PrimaryDarkGreen;
                        gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        gb.Paint -= GroupBoxCard_Paint;
                        gb.Paint += GroupBoxCard_Paint;

                        foreach (Control child in gb.Controls)
                        {
                            if (child is Label)
                            {
                                Label lbl = (Label)child;
                                lbl.ForeColor = MutedText;
                                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                            else if (child is TextBox)
                            {
                                TextBox tb = (TextBox)child;
                                tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                tb.BackColor = Color.White;
                                tb.ForeColor = DarkText;
                            }
                            else if (child is ComboBox)
                            {
                                ComboBox cb = (ComboBox)child;
                                cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                cb.BackColor = Color.White;
                                cb.ForeColor = DarkText;
                            }
                            else if (child is DateTimePicker)
                            {
                                DateTimePicker dtp = (DateTimePicker)child;
                                dtp.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                            }
                            else if (child is CheckBox)
                            {
                                CheckBox chk = (CheckBox)child;
                                chk.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                chk.ForeColor = PrimaryDarkGreen;
                            }
                            else if (child is RadioButton)
                            {
                                RadioButton rdo = (RadioButton)child;
                                rdo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                rdo.ForeColor = DarkText;
                            }
                            else if (child is Button || child is Glass.GlassButton)
                            {
                                Control btn = child;
                                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                btn.Cursor = Cursors.Hand;

                                if (btn.Name == "btnSave" || btn.Name == "btnrefresh")
                                {
                                    btn.BackColor = PrimaryDarkGreen;
                                    btn.ForeColor = Color.White;
                                }
                                else if (btn.Name == "btnDel" || btn.Name == "btnUpdate")
                                {
                                    btn.BackColor = DangerRed;
                                    btn.ForeColor = Color.White;
                                }
                                else if (btn.Name == "btnCancel")
                                {
                                    btn.BackColor = Color.FromArgb(107, 114, 128);
                                    btn.ForeColor = Color.White;
                                }
                                else if (btn.Name == "btnclose")
                                {
                                    btn.BackColor = Color.White;
                                    btn.ForeColor = PrimaryDarkGreen;
                                }
                                else if (btn.Name == "search")
                                {
                                    btn.BackColor = PrimaryDarkGreen;
                                    btn.ForeColor = Color.White;
                                }
                            }
                            else if (child is ListView)
                            {
                                ListView lst = (ListView)child;
                                lst.BackColor = Color.White;
                                lst.ForeColor = DarkText;
                                lst.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                lst.OwnerDraw = true;
                                lst.DrawColumnHeader -= ListView_DrawColumnHeader;
                                lst.DrawColumnHeader += ListView_DrawColumnHeader;
                                lst.DrawItem -= ListView_DrawItem;
                                lst.DrawItem += ListView_DrawItem;
                                lst.DrawSubItem -= ListView_DrawSubItem;
                                lst.DrawSubItem += ListView_DrawSubItem;
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleExpenseDetailForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panel4) ───────────────────────────────────
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.BackColor = PrimaryDarkGreen;
                    panel4.Height = 60;
                    panel4.Paint -= PanelBottomBorder_Paint;

                    foreach (Control c in panel4.Controls)
                    {
                        if (c.Name == "label1")
                        {
                            c.ForeColor = Color.White;
                            c.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
                        }
                        else if (c.Name == "label2")
                        {
                            c.ForeColor = Color.FromArgb(232, 245, 233);
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        }
                        else if (c.Name == "lbl_Mode")
                        {
                            c.BackColor = Color.FromArgb(232, 245, 233);
                            c.ForeColor = PrimaryDarkGreen;
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                        }
                        else if (c.Name == "label6" || c.Name == "label7")
                        {
                            c.Visible = false;
                        }
                    }
                }

                // ── 2. CONTENT AREA & CARDS ───────────────────────────────────
                Panel panelContent = form.Controls["panelContent"] as Panel;
                Control parentContainer = panelContent != null ? (Control)panelContent : form;

                foreach (Control c in parentContainer.Controls)
                {
                    if (c is GroupBox)
                    {
                        GroupBox gb = (GroupBox)c;
                        gb.BackColor = Color.White;
                        gb.ForeColor = PrimaryDarkGreen;
                        gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        gb.Paint -= CardContainer_Paint;
                        gb.Paint += CardContainer_Paint;

                        foreach (Control child in gb.Controls)
                        {
                            if (child is Label)
                            {
                                Label lbl = (Label)child;
                                lbl.ForeColor = MutedText;
                                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                            else if (child is TextBox)
                            {
                                TextBox tb = (TextBox)child;
                                tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                tb.BackColor = Color.White;
                                tb.ForeColor = DarkText;
                            }
                            else if (child is ComboBox)
                            {
                                ComboBox cb = (ComboBox)child;
                                cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                cb.BackColor = Color.White;
                                cb.ForeColor = DarkText;
                                cb.FlatStyle = FlatStyle.Popup;
                            }
                            else if (child is DateTimePicker)
                            {
                                DateTimePicker dtp = (DateTimePicker)child;
                                dtp.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                            }
                            else if (child is Button || child is Glass.GlassButton)
                            {
                                Control btn = child;
                                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                btn.Cursor = Cursors.Hand;

                                if (btn.Name == "btnSave" || btn.Name == "btnUpdate")
                                {
                                    btn.BackColor = PrimaryDarkGreen;
                                    btn.ForeColor = Color.White;
                                }
                                else if (btn.Name == "btnDel")
                                {
                                    btn.BackColor = DangerRed;
                                    btn.ForeColor = Color.White;
                                }
                                else if (btn.Name == "btnCancel")
                                {
                                    btn.BackColor = Color.FromArgb(107, 114, 128);
                                    btn.ForeColor = Color.White;
                                }
                                else if (btn.Name == "btnclose")
                                {
                                    btn.BackColor = Color.White;
                                    btn.ForeColor = PrimaryDarkGreen;
                                }
                            }
                            else if (child is ListView)
                            {
                                ListView lst = (ListView)child;
                                lst.BackColor = Color.White;
                                lst.ForeColor = DarkText;
                                lst.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                lst.OwnerDraw = true;
                                lst.DrawColumnHeader -= ListView_DrawColumnHeader;
                                lst.DrawColumnHeader += ListView_DrawColumnHeader;
                                lst.DrawItem -= ListView_DrawItem;
                                lst.DrawItem += ListView_DrawItem;
                                lst.DrawSubItem -= ListView_DrawSubItem;
                                lst.DrawSubItem += ListView_DrawSubItem;
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleFeeHeadForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panel4) ───────────────────────────────────
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.BackColor = PrimaryDarkGreen;
                    panel4.Height = 60;
                    panel4.Paint -= PanelBottomBorder_Paint;

                    foreach (Control c in panel4.Controls)
                    {
                        if (c.Name == "label3")
                        {
                            c.ForeColor = Color.White;
                            c.Font = new Font("Segoe UI", 13.5F, FontStyle.Bold);
                        }
                        else if (c.Name == "lblHeaderSub")
                        {
                            c.ForeColor = Color.FromArgb(232, 245, 233);
                            c.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                        }
                        else if (c.Name == "label4" || c.Name == "label6" || c.Name == "label7" || c.Name == "lbl_Mode")
                        {
                            c.Visible = false;
                        }
                    }
                }

                // ── 2. CONTENT AREA & CARDS ───────────────────────────────────
                Panel panelContent = form.Controls["panelContent"] as Panel;
                Control parentContainer = panelContent != null ? (Control)panelContent : form;

                foreach (Control c in parentContainer.Controls)
                {
                    if (c is GroupBox)
                    {
                        GroupBox gb = (GroupBox)c;
                        gb.BackColor = Color.White;
                        gb.ForeColor = PrimaryDarkGreen;
                        gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        gb.Paint -= CardContainer_Paint;
                        gb.Paint += CardContainer_Paint;

                        foreach (Control child in gb.Controls)
                        {
                            if (child is Label)
                            {
                                Label lbl = (Label)child;
                                lbl.ForeColor = MutedText;
                                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                            else if (child is TextBox)
                            {
                                TextBox tb = (TextBox)child;
                                tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                tb.BackColor = Color.White;
                                tb.ForeColor = DarkText;
                            }
                            else if (child is ComboBox)
                            {
                                ComboBox cb = (ComboBox)child;
                                cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                cb.BackColor = Color.White;
                                cb.ForeColor = DarkText;
                                cb.FlatStyle = FlatStyle.Popup;
                            }
                            else if (child is Button || child is Glass.GlassButton)
                            {
                                Control btn = child;
                                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                btn.Cursor = Cursors.Hand;

                                if (btn.Name == "btnSave" || btn.Name == "btnrefresh" || btn.Name == "btnupdate")
                                {
                                    btn.BackColor = PrimaryDarkGreen;
                                    btn.ForeColor = Color.White;
                                }
                                else if (btn.Name == "btnDel")
                                {
                                    btn.BackColor = DangerRed;
                                    btn.ForeColor = Color.White;
                                }
                                else if (btn.Name == "btnCancel")
                                {
                                    btn.BackColor = Color.FromArgb(107, 114, 128);
                                    btn.ForeColor = Color.White;
                                }
                                else if (btn.Name == "btnclose")
                                {
                                    btn.BackColor = Color.White;
                                    btn.ForeColor = PrimaryDarkGreen;
                                }
                            }
                            else if (child is ListView)
                            {
                                ListView lst = (ListView)child;
                                lst.BackColor = Color.White;
                                lst.ForeColor = DarkText;
                                lst.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                lst.OwnerDraw = true;
                                lst.DrawColumnHeader -= ListView_DrawColumnHeader;
                                lst.DrawColumnHeader += ListView_DrawColumnHeader;
                                lst.DrawItem -= ListView_DrawItem;
                                lst.DrawItem += ListView_DrawItem;
                                lst.DrawSubItem -= ListView_DrawSubItem;
                                lst.DrawSubItem += ListView_DrawSubItem;
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }




        private static void StyleManageStudentsForm(Form form)
        {
            try
            {
                // SAFE: Only apply visual styling. Do NOT touch Dock, Location, Size or Parent of any control.
                form.BackColor = OffWhiteBg;

                // Style panel4 (header + filters + buttons) — keep DockStyle.Top intact
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.BackColor = Color.White;
                    panel4.BackgroundImage = null;

                    // Add bottom separator paint
                    panel4.Paint -= PanelBottomBorder_Paint;
                    panel4.Paint += PanelBottomBorder_Paint;

                    foreach (Control child in panel4.Controls)
                    {
                        // Page title label
                        if (child.Name == "label2")
                        {
                            child.ForeColor = PrimaryDarkGreen;
                            child.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
                        }
                        // Total Records label
                        else if (child.Name == "label1")
                        {
                            child.ForeColor = MutedText;
                            child.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        }
                        // Total count badge
                        else if (child.Name == "lbltotal")
                        {
                            child.BackColor = LightGreenTint;
                            child.ForeColor = PrimaryDarkGreen;
                            child.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                        }
                        // Search card panel — style only, don't move
                        else if (child.Name == "panelSearchCard")
                        {
                            Panel card = (Panel)child;
                            card.BackColor = Color.FromArgb(250, 252, 250);
                            card.Paint -= CardPanel_Paint;
                            card.Paint += CardPanel_Paint;

                            foreach (Control filter in card.Controls)
                            {
                                if (filter is RadioButton)
                                {
                                    filter.ForeColor = DarkText;
                                    filter.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                    filter.BackColor = Color.Transparent;
                                }
                                else if (filter is ComboBox)
                                {
                                    filter.Font = new Font("Segoe UI", 9.5F);
                                    filter.BackColor = Color.White;
                                    filter.ForeColor = DarkText;
                                }
                                else if (filter is TextBox)
                                {
                                    filter.Font = new Font("Segoe UI", 9.5F);
                                    filter.BackColor = Color.White;
                                    filter.ForeColor = DarkText;
                                }
                            }
                        }
                        // Style action buttons
                        else if (child is Button)
                        {
                            Button btn = (Button)child;
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderSize = 1;
                            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            btn.Cursor = Cursors.Hand;

                            if (btn.Name == "btnadd")
                            {
                                // Primary green button
                                btn.BackColor = PrimaryDarkGreen;
                                btn.ForeColor = Color.White;
                                btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                            }
                            else
                            {
                                // Secondary outlined button
                                btn.BackColor = Color.White;
                                btn.ForeColor = PrimaryDarkGreen;
                                btn.FlatAppearance.BorderColor = PrimaryDarkGreen;
                            }
                        }
                    }
                }

                // Style panel1 (contains ListView) — keep DockStyle.Fill intact
                Panel panel1 = form.Controls["panel1"] as Panel;
                if (panel1 != null)
                {
                    panel1.BackColor = Color.White;

                    ListView lv = panel1.Controls["lstv_Student"] as ListView;
                    if (lv != null)
                    {
                        lv.BackColor = Color.White;
                        lv.ForeColor = DarkText;
                        lv.Font = new Font("Segoe UI", 9.5F);
                        lv.OwnerDraw = true;
                        lv.FullRowSelect = true;
                        lv.GridLines = false;
                        lv.Dock = DockStyle.Fill; // Grid fills the entire panel1

                        lv.DrawColumnHeader -= ListView_DrawColumnHeader;
                        lv.DrawItem        -= ListView_DrawItem;
                        lv.DrawSubItem     -= ListView_DrawSubItem;

                        lv.DrawColumnHeader += ListView_DrawColumnHeader;
                        lv.DrawItem         += ListView_DrawItem;
                        lv.DrawSubItem      += ListView_DrawSubItem;
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleStudentForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // Adjust form height dynamically to fit within screen working area safely
                int screenHeight = Screen.FromControl(form).WorkingArea.Height;
                int targetHeight = Math.Min(820, screenHeight - 40);
                form.Size = new Size(1412, targetHeight);
                form.MinimumSize = new Size(1200, 600);

                // ── 1. STYLE HEADER PANEL ─────────────────────────────────────────────
                Panel header = form.Controls["panel1"] as Panel;
                if (header != null)
                {
                    header.Dock = DockStyle.None;
                    header.Location = new Point(0, 0);
                    header.Width = form.ClientSize.Width;
                    header.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    header.Height = 85;
                    header.BackColor = Color.White;
                    header.BackgroundImage = null;
                    header.Paint -= PanelBottomBorder_Paint;
                    header.Paint += PanelBottomBorder_Paint;

                    foreach (Control child in header.Controls)
                    {
                        if (child.Name == "pictureBox10")
                        {
                            child.Location = new Point(25, 20);
                            child.Size = new Size(45, 45);
                        }
                        else if (child.Name == "label23")
                        {
                            child.Text = "Student Information";
                            child.ForeColor = PrimaryDarkGreen;
                            child.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                            child.Location = new Point(80, 15);
                        }
                        else if (child.Name == "label3")
                        {
                            child.Text = "Enter Student Registration Details";
                            child.ForeColor = MutedText;
                            child.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                            child.Location = new Point(80, 48);
                        }
                        else if (child.Name == "label16")
                        {
                            child.Text = "|";
                            child.ForeColor = BorderColor;
                            child.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                            child.Location = new Point(345, 48);
                        }
                        else if (child.Name == "label15")
                        {
                            child.Text = "Mode :";
                            child.ForeColor = MutedText;
                            child.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            child.Location = new Point(360, 48);
                        }
                        else if (child.Name == "lbl_Mode")
                        {
                            child.Visible = false;
                        }
                        else if (child.Name == "BTN_PNL_CLOSE")
                        {
                            child.Location = new Point(header.Width - 60, 10);
                            child.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                        }
                    }

                    Label lblVisual = header.Controls["lbl_ModeVisual"] as Label;
                    if (lblVisual == null)
                    {
                        lblVisual = new Label();
                        lblVisual.Name = "lbl_ModeVisual";
                        lblVisual.BackColor = Color.FromArgb(232, 245, 233);
                        lblVisual.ForeColor = PrimaryDarkGreen;
                        lblVisual.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                        lblVisual.Location = new Point(410, 46);
                        lblVisual.Size = new Size(100, 22);
                        lblVisual.TextAlign = ContentAlignment.MiddleCenter;
                        header.Controls.Add(lblVisual);

                        Control realMode = header.Controls["lbl_Mode"];
                        if (realMode != null)
                        {
                            realMode.TextChanged += (s, ev) =>
                            {
                                if (realMode.Text.Contains("Adding") || realMode.Text.Contains("Add"))
                                    lblVisual.Text = "Add Mode";
                                else if (realMode.Text.Contains("Modifying") || realMode.Text.Contains("Modify"))
                                    lblVisual.Text = "Modify Mode";
                                else
                                    lblVisual.Text = realMode.Text;
                            };
                            if (realMode.Text.Contains("Adding") || realMode.Text.Contains("Add"))
                                lblVisual.Text = "Add Mode";
                            else
                                lblVisual.Text = "Modify Mode";
                        }
                    }
                }

                // ── 2. CREATE FIXED BOTTOM ACTION BAR ────────────────────────────────
                // Use a helper so the panel is only built once
                Panel panelButtons = form.Controls["panelStudentActionBar"] as Panel;
                if (panelButtons == null)
                {
                    panelButtons = new Panel();
                    panelButtons.Name = "panelStudentActionBar";
                    panelButtons.Height = 62;
                    panelButtons.Dock = DockStyle.Bottom;
                    panelButtons.BackColor = Color.White;
                    panelButtons.Paint += (s, e) =>
                    {
                        using (Pen pen = new Pen(Color.FromArgb(220, 230, 222), 1F))
                            e.Graphics.DrawLine(pen, 0, 0, ((Control)s).Width, 0);
                    };

                    // Action button names in display order
                    string[] btnNames = new string[] { "btnSave", "btnUpdate", "btnCancel", "glassButton1", "btnclose" };

                    // Collect controls using Control type (avoids GlassButton → Button cast issues)
                    List<Control> btnsToMove = new List<Control>();
                    foreach (string name in btnNames)
                    {
                        Control found = null;
                        foreach (Control fc in form.Controls)
                        {
                            if (fc.Name == name)
                            {
                                found = fc;
                                break;
                            }
                        }
                        if (found != null) btnsToMove.Add(found);
                    }

                    // Remove from form, add to panel
                    foreach (Control btn in btnsToMove)
                    {
                        form.Controls.Remove(btn);
                        btn.Size = new Size(115, 40);
                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        panelButtons.Controls.Add(btn);
                    }

                    // Add the panel to the form first
                    form.Controls.Add(panelButtons);
                    panelButtons.BringToFront();

                    // Style and center buttons — called on load and on resize
                    MethodInvoker centerButtons = delegate
                    {
                        int count = 0;
                        foreach (Control fc in panelButtons.Controls)
                            if (fc is ButtonBase) count++;

                        if (count == 0) return;

                        int btnW = 115;
                        int gap = 10;
                        int totalW = count * btnW + (count - 1) * gap;
                        int startX = Math.Max(10, (panelButtons.Width - totalW) / 2);
                        int y = (panelButtons.Height - 40) / 2;
                        int x = startX;

                        foreach (string name in btnNames)
                        {
                            Control btn = panelButtons.Controls[name];
                            if (btn == null) continue;
                            btn.Location = new Point(x, y);
                            btn.Size = new Size(btnW, 40);

                            // Style based on button role
                            if (name == "btnSave" || name == "btnUpdate")
                            {
                                btn.BackColor = PrimaryDarkGreen;
                                btn.ForeColor = Color.White;
                                try { ((ButtonBase)btn).FlatStyle = FlatStyle.Flat; } catch { }
                                try { ((ButtonBase)btn).FlatAppearance.BorderColor = PrimaryDarkGreen; } catch { }
                                try { ((ButtonBase)btn).FlatAppearance.BorderSize = 0; } catch { }
                            }
                            else
                            {
                                btn.BackColor = Color.White;
                                btn.ForeColor = PrimaryDarkGreen;
                                try { ((ButtonBase)btn).FlatStyle = FlatStyle.Flat; } catch { }
                                try { ((ButtonBase)btn).FlatAppearance.BorderColor = PrimaryDarkGreen; } catch { }
                                try { ((ButtonBase)btn).FlatAppearance.BorderSize = 1; } catch { }
                            }

                            btn.Cursor = Cursors.Hand;
                            x += btnW + gap;
                        }
                    };

                    MethodInvoker cb = centerButtons;
                    panelButtons.SizeChanged += (s, ev) => cb();

                    // Call immediately once layout is ready
                    form.Load += (s, ev) => cb();

                    // Also call now in case form is already loaded
                    centerButtons();

                }

                // ── 3. POSITION TOP FIELDS (2 rows) ─────────────────────────────────
                int row1Y = 100;
                int row2Y = 145;

                foreach (Control c in form.Controls)
                {
                    if (c.Name == "label5")        { c.Location = new Point(25,  row1Y + 4); c.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); c.ForeColor = PrimaryDarkGreen; c.Text = "Select Class *"; }
                    else if (c.Name == "com_cName") { c.Location = new Point(145, row1Y);     c.Width = 150; }
                    else if (c.Name == "btn_Link")  { c.Location = new Point(300, row1Y);     c.Width = 30; c.Height = 26; c.Text = "..."; }

                    else if (c.Name == "label33")   { c.Location = new Point(360, row1Y + 4); c.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); c.ForeColor = PrimaryDarkGreen; }
                    else if (c.Name == "cmbsection"){ c.Location = new Point(470, row1Y);     c.Width = 140; }

                    else if (c.Name == "label37")   { c.Location = new Point(645, row1Y + 4); c.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); c.ForeColor = PrimaryDarkGreen; }
                    else if (c.Name == "cmbshift")  { c.Location = new Point(730, row1Y);     c.Width = 140; }

                    else if (c.Name == "label7")    { c.Location = new Point(900, row1Y + 4); c.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); c.ForeColor = PrimaryDarkGreen; }
                    else if (c.Name == "txt_Rollno"){ c.Location = new Point(980, row1Y);     c.Width = 140; }

                    else if (c.Name == "label9")           { c.Location = new Point(25,  row2Y + 4); c.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); c.ForeColor = PrimaryDarkGreen; }
                    else if (c.Name == "txtadmissiondate") { c.Location = new Point(145, row2Y);     c.Width = 185; }

                    else if (c.Name == "label34")          { c.Location = new Point(360, row2Y + 4); c.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); c.ForeColor = PrimaryDarkGreen; c.Text = "Admission No *"; }
                    else if (c.Name == "txtadmissionno")   { c.Location = new Point(470, row2Y);     c.Width = 140; }

                    else if (c.Name == "label38")   { c.Location = new Point(645, row2Y + 4); c.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); c.ForeColor = PrimaryDarkGreen; }
                    else if (c.Name == "cmbtype")   { c.Location = new Point(730, row2Y);     c.Width = 140; }

                    else if (c.Name == "label35")   { c.Location = new Point(900, row2Y + 4); c.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold); c.ForeColor = PrimaryDarkGreen; }
                    else if (c.Name == "cmbsession"){ c.Location = new Point(980, row2Y);     c.Width = 140; }

                    // ── 4. TABCONTROL — anchored, fills remaining space ───────────────
                    else if (c is TabControl && c.Name == "image")
                    {
                        TabControl tab = (TabControl)c;
                        int tabTop = 195;
                        int tabH = form.ClientSize.Height - tabTop - panelButtons.Height - 5;
                        tab.Location = new Point(20, tabTop);
                        tab.Width = form.ClientSize.Width - 40;
                        tab.Height = Math.Max(tabH, 200);
                        tab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                        tab.Appearance = TabAppearance.Normal;

                        foreach (TabPage page in tab.TabPages)
                            page.AutoScroll = true;
                    }
                }
            }
            catch (Exception) { }
        }


        private static void PanelBottomBorder_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Control c = (Control)sender;
                using (Pen borderPen = new Pen(Color.FromArgb(220, 230, 222), 1F))
                {
                    e.Graphics.DrawLine(borderPen, 0, c.Height - 1, c.Width, c.Height - 1);
                }
            }
            catch { }
        }

        private static void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                TabControl tab = (TabControl)sender;
                TabPage page = tab.TabPages[e.Index];
                bool isSelected = (tab.SelectedIndex == e.Index);

                // Fill background
                using (Brush bgBrush = new SolidBrush(OffWhiteBg))
                {
                    e.Graphics.FillRectangle(bgBrush, e.Bounds);
                }

                // Fill tab header background
                Color tabBg = isSelected ? Color.White : Color.FromArgb(240, 243, 241);
                using (Brush tabBrush = new SolidBrush(tabBg))
                {
                    Rectangle tabBounds = e.Bounds;
                    tabBounds.Inflate(-1, -1);
                    e.Graphics.FillRectangle(tabBrush, tabBounds);

                    using (Pen borderPen = new Pen(BorderColor, 1F))
                    {
                        e.Graphics.DrawRectangle(borderPen, tabBounds);
                    }

                    if (isSelected)
                    {
                        using (Brush accentBrush = new SolidBrush(PrimaryDarkGreen))
                        {
                            Rectangle accentRect = new Rectangle(tabBounds.X, tabBounds.Bottom - 3, tabBounds.Width, 3);
                            e.Graphics.FillRectangle(accentBrush, accentRect);
                        }
                    }
                }

                // Draw text
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
                Color textColor = isSelected ? PrimaryDarkGreen : DarkText;
                using (Font font = new Font("Segoe UI", 9.5F, isSelected ? FontStyle.Bold : FontStyle.Regular))
                {
                    TextRenderer.DrawText(e.Graphics, page.Text, font, e.Bounds, textColor, flags);
                }
            }
            catch { }
        }

        private static void StyleAttendanceForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // 1. PAGE HEADER (panel4 / panelHeader)
                Panel panel4 = (form.Controls["panel4"] as Panel) ?? (form.Controls["panelHeader"] as Panel);
                if (panel4 != null)
                {
                    panel4.BackColor = PrimaryDarkGreen;
                    panel4.Height = 65;
                    panel4.Paint -= PanelBottomBorder_Paint;
                    panel4.Paint += PanelBottomBorder_Paint;

                    bool hasPic = false;
                    foreach (Control c in panel4.Controls)
                    {
                        if (c is PictureBox && c.Visible) { hasPic = true; break; }
                    }

                    foreach (Control c in panel4.Controls)
                    {
                        if (c is Label)
                        {
                            Label lbl = (Label)c;
                            lbl.ForeColor = Color.White;
                            if (lbl.Name == "label11" || lbl.Name == "label4" || lbl.Name == "lblTitle" || lbl.Name == "label1")
                            {
                                lbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                                if (hasPic) lbl.Location = new Point(60, 14);
                            }
                            else if (lbl.Name == "lblHeaderSub")
                            {
                                lbl.ForeColor = LightGreenTint;
                                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                            }
                        }
                        else if (c is PictureBox)
                        {
                            c.Location = new Point(18, 14);
                        }
                        else if (c is Button || c is Glass.GlassButton)
                        {
                            c.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            c.BackColor = Color.White;
                            c.ForeColor = PrimaryDarkGreen;
                            c.Cursor = Cursors.Hand;
                            if (c is Button)
                            {
                                Button b = (Button)c;
                                b.FlatStyle = FlatStyle.Flat;
                                b.FlatAppearance.BorderSize = 0;
                            }
                        }
                    }
                }

                // 2. SEARCH / CARDS PANEL (panel3 or panelContent)
                Panel panel3 = form.Controls["panel3"] as Panel;
                if (panel3 != null)
                {
                    panel3.BackColor = Color.FromArgb(238, 247, 240);
                    panel3.Paint -= CardContainer_Paint;
                    panel3.Paint += CardContainer_Paint;
                    panel3.Paint -= PanelSearchCard_Paint;
                    panel3.Paint += PanelSearchCard_Paint;

                    foreach (Control child in panel3.Controls)
                    {
                        if (child is Label)
                        {
                            Label lbl = (Label)child;
                            lbl.ForeColor = PrimaryDarkGreen;
                            lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        }
                        else if (child is ComboBox)
                        {
                            ComboBox cb = (ComboBox)child;
                            cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                            cb.BackColor = Color.White;
                            cb.ForeColor = DarkText;
                            cb.FlatStyle = FlatStyle.Popup;
                        }
                        else if (child is DateTimePicker)
                        {
                            DateTimePicker dtp = (DateTimePicker)child;
                            dtp.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                        }
                        else if (child is GroupBox)
                        {
                            GroupBox gb = (GroupBox)child;
                            gb.BackColor = Color.FromArgb(238, 247, 240);
                            gb.ForeColor = PrimaryDarkGreen;
                            gb.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                            foreach (Control sub in gb.Controls)
                            {
                                if (sub is RadioButton)
                                {
                                    RadioButton rdo = (RadioButton)sub;
                                    rdo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                                    rdo.ForeColor = PrimaryDarkGreen;
                                    rdo.BackColor = Color.FromArgb(238, 247, 240);
                                }
                            }
                        }
                        else if (child is Button || child is Glass.GlassButton)
                        {
                            Control btn = child;
                            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            btn.Cursor = Cursors.Hand;
                            string nameLower = btn.Name.ToLower();
                            string textLower = btn.Text.ToLower();

                            if (nameLower == "btnshow" || nameLower == "button1" || nameLower == "btnsave" || textLower.Contains("show") || textLower.Contains("update") || textLower.Contains("generate"))
                            {
                                btn.BackColor = PrimaryDarkGreen;
                                btn.ForeColor = Color.White;
                                if (btn is Button)
                                {
                                    Button b = (Button)btn;
                                    b.FlatStyle = FlatStyle.Flat;
                                    b.FlatAppearance.BorderSize = 0;
                                }
                            }
                            else if (nameLower == "btndelete" || textLower.Contains("delete"))
                            {
                                btn.BackColor = DangerRed;
                                btn.ForeColor = Color.White;
                                if (btn is Button)
                                {
                                    Button b = (Button)btn;
                                    b.FlatStyle = FlatStyle.Flat;
                                    b.FlatAppearance.BorderSize = 0;
                                }
                            }
                            else if (nameLower == "btnprint" || nameLower == "frmclose" || textLower.Contains("print") || textLower.Contains("close"))
                            {
                                btn.BackColor = Color.White;
                                btn.ForeColor = PrimaryDarkGreen;
                                if (btn is Button)
                                {
                                    Button b = (Button)btn;
                                    b.FlatStyle = FlatStyle.Flat;
                                    b.FlatAppearance.BorderSize = 1;
                                    b.FlatAppearance.BorderColor = PrimaryDarkGreen;
                                }
                            }
                        }
                    }
                }

                // 3. DATAGRIDVIEW / LISTVIEW STYLING
                foreach (Control c in form.Controls)
                {
                    if (c is DataGridView)
                    {
                        DataGridView dgv = (DataGridView)c;
                        dgv.EnableHeadersVisualStyles = false;
                        dgv.BackgroundColor = OffWhiteBg;
                        dgv.BorderStyle = BorderStyle.FixedSingle;
                        dgv.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                        dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDarkGreen;
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        dgv.ColumnHeadersHeight = 35;

                        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244);
                        dgv.DefaultCellStyle.SelectionBackColor = EmeraldGreen;
                        dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                        dgv.GridColor = BorderColor;
                    }
                    else if (c is Panel && c.Name == "panel1")
                    {
                        Panel pnl1 = (Panel)c;
                        foreach (Control child in pnl1.Controls)
                        {
                            if (child is DataGridView)
                            {
                                DataGridView dgv = (DataGridView)child;
                                dgv.EnableHeadersVisualStyles = false;
                                dgv.BackgroundColor = OffWhiteBg;
                                dgv.BorderStyle = BorderStyle.FixedSingle;
                                dgv.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                                dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDarkGreen;
                                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                dgv.ColumnHeadersHeight = 35;

                                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244);
                                dgv.DefaultCellStyle.SelectionBackColor = EmeraldGreen;
                                dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                                dgv.GridColor = BorderColor;
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleAcademicsForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // 1. PAGE HEADER (panel4 / panelHeader)
                Panel panel4 = (form.Controls["panel4"] as Panel) ?? (form.Controls["panelHeader"] as Panel);
                if (panel4 != null)
                {
                    panel4.BackColor = PrimaryDarkGreen;
                    panel4.Height = 60;
                    panel4.Paint -= PanelBottomBorder_Paint;
                    panel4.Paint += PanelBottomBorder_Paint;

                    bool hasPic = false;
                    foreach (Control c in panel4.Controls)
                    {
                        if (c is PictureBox && c.Visible) { hasPic = true; break; }
                    }

                    foreach (Control c in panel4.Controls)
                    {
                        if (c is Label)
                        {
                            Label lbl = (Label)c;
                            if (lbl.Name == "label11" || lbl.Name == "label14" || lbl.Name == "label13" || lbl.Name == "label6" || lbl.Name == "label7")
                            {
                                if (lbl.Text == "|" || lbl.Text.Contains("Mode") || lbl.Text.Contains("Enter All") || lbl.Location.X > 800)
                                {
                                    lbl.Visible = false;
                                }
                            }
                            else if (lbl.Name == "label2" || lbl.Name == "label3" || lbl.Name == "label8" || lbl.Name == "label12" || lbl.Name == "lblTitle" || lbl.Name == "label1")
                            {
                                lbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                                lbl.ForeColor = Color.White;
                                if (hasPic) lbl.Location = new Point(60, 14);
                            }
                            else if (lbl.Name == "lbl_ModeVisual" || lbl.Name == "lbl_Mode")
                            {
                                lbl.AutoSize = false;
                                lbl.Size = new Size(130, 28);
                                lbl.Location = new Point(690, 16);
                                lbl.BackColor = LightGreenTint;
                                lbl.ForeColor = PrimaryDarkGreen;
                                lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                lbl.TextAlign = ContentAlignment.MiddleCenter;
                                lbl.Visible = true;
                            }
                            else if (lbl.Name == "lblHeaderSub")
                            {
                                lbl.ForeColor = LightGreenTint;
                                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                            }
                        }
                        else if (c is PictureBox)
                        {
                            c.Location = new Point(18, 14);
                            c.Size = new Size(31, 31);
                        }
                    }
                }

                // 2. SEARCH & CARDS PANELS (groupboxform, groupBox1, groupBox2, panel1, panel3, panelContent)
                foreach (Control c in form.Controls)
                {
                    if (c is GroupBox || c is Panel)
                    {
                        if (c != panel4)
                        {
                            Control container = c;
                            if (container.Name.Contains("card") || container.Name == "panel1" || container.Name == "panel3" || container.Name == "groupboxform" || container.Name == "groupBox1")
                            {
                                container.BackColor = Color.FromArgb(238, 247, 240);
                                container.Paint -= PanelSearchCard_Paint;
                                container.Paint += PanelSearchCard_Paint;
                            }

                            container.Paint -= CardContainer_Paint;
                            container.Paint += CardContainer_Paint;

                            foreach (Control child in container.Controls)
                            {
                                if (child is Label)
                                {
                                    Label lbl = (Label)child;
                                    lbl.ForeColor = MutedText;
                                    lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                                }
                                else if (child is ComboBox)
                                {
                                    ComboBox cb = (ComboBox)child;
                                    cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                    cb.BackColor = Color.White;
                                    cb.ForeColor = DarkText;
                                    cb.FlatStyle = FlatStyle.Popup;
                                }
                                else if (child is TextBox)
                                {
                                    TextBox tb = (TextBox)child;
                                    tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                    tb.BackColor = Color.White;
                                    tb.ForeColor = DarkText;
                                }
                                else if (child is DateTimePicker)
                                {
                                    DateTimePicker dtp = (DateTimePicker)child;
                                    dtp.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                }
                                else if (child is RadioButton)
                                {
                                    RadioButton rdo = (RadioButton)child;
                                    rdo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                                    rdo.ForeColor = PrimaryDarkGreen;
                                }
                                else if (child is Button || child is Glass.GlassButton)
                                {
                                    Control btn = child;
                                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                    btn.Cursor = Cursors.Hand;
                                    string nameLower = btn.Name.ToLower();
                                    string textLower = btn.Text.ToLower();

                                    if (nameLower.Contains("save") || nameLower.Contains("update") || nameLower.Contains("refresh") || nameLower.Contains("add") || nameLower == "button2" || textLower.Contains("save") || textLower.Contains("update"))
                                    {
                                        btn.BackColor = PrimaryDarkGreen;
                                        btn.ForeColor = Color.White;
                                        if (btn is Button)
                                        {
                                            Button b = (Button)btn;
                                            b.FlatStyle = FlatStyle.Flat;
                                            b.FlatAppearance.BorderSize = 0;
                                        }
                                    }
                                    else if (nameLower.Contains("del") || nameLower.Contains("delete") || textLower.Contains("delete"))
                                    {
                                        btn.BackColor = DangerRed;
                                        btn.ForeColor = Color.White;
                                        if (btn is Button)
                                        {
                                            Button b = (Button)btn;
                                            b.FlatStyle = FlatStyle.Flat;
                                            b.FlatAppearance.BorderSize = 0;
                                        }
                                    }
                                    else if (nameLower.Contains("cancel") || textLower.Contains("cancel"))
                                    {
                                        btn.BackColor = Color.FromArgb(107, 114, 128);
                                        btn.ForeColor = Color.White;
                                        if (btn is Button)
                                        {
                                            Button b = (Button)btn;
                                            b.FlatStyle = FlatStyle.Flat;
                                            b.FlatAppearance.BorderSize = 0;
                                        }
                                    }
                                    else if (nameLower.Contains("close") || nameLower.Contains("print") || textLower.Contains("close") || textLower.Contains("print"))
                                    {
                                        btn.BackColor = Color.White;
                                        btn.ForeColor = PrimaryDarkGreen;
                                        if (btn is Button)
                                        {
                                            Button b = (Button)btn;
                                            b.FlatStyle = FlatStyle.Flat;
                                            b.FlatAppearance.BorderSize = 1;
                                            b.FlatAppearance.BorderColor = PrimaryDarkGreen;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (c is ListView)
                    {
                        ListView lst = (ListView)c;
                        lst.BackColor = Color.White;
                        lst.ForeColor = DarkText;
                        lst.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    }
                    else if (c is DataGridView)
                    {
                        DataGridView dgv = (DataGridView)c;
                        dgv.EnableHeadersVisualStyles = false;
                        dgv.BackgroundColor = OffWhiteBg;
                        dgv.BorderStyle = BorderStyle.FixedSingle;
                        dgv.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                        dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDarkGreen;
                        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        dgv.ColumnHeadersHeight = 35;

                        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244);
                        dgv.DefaultCellStyle.SelectionBackColor = ActiveGreen;
                        dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                        dgv.GridColor = Color.FromArgb(180, 195, 210);
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleSessionSelectForm(Form form)
        {
            try
            {
                form.ClientSize = new Size(500, 310);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.BackColor = OffWhiteBg;

                // Dynamically center inner card (panelCard)
                Panel panelCard = form.Controls["panelCard"] as Panel;
                Panel panel1 = form.Controls["panel1"] as Panel;
                if (panelCard != null)
                {
                    panelCard.Left = Math.Max(0, (form.ClientSize.Width - panelCard.Width) / 2);
                    int topOffset = (panel1 != null) ? panel1.Bottom : 0;
                    int remainingH = form.ClientSize.Height - topOffset;
                    panelCard.Top = topOffset + Math.Max(6, (remainingH - panelCard.Height) / 2);

                    Button btnshow = panelCard.Controls["btnshow"] as Button;
                    Button btnexit = panelCard.Controls["btnexit"] as Button;
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
            catch (Exception) { }
        }

        private static void StyleProcessForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // 1. PAGE HEADER (panel4 / panelHeader)
                Panel panel4 = (form.Controls["panel4"] as Panel) ?? (form.Controls["panelHeader"] as Panel);
                if (panel4 != null)
                {
                    panel4.BackColor = PrimaryDarkGreen;
                    panel4.Height = 60;
                    panel4.Paint -= PanelBottomBorder_Paint;
                    panel4.Paint += PanelBottomBorder_Paint;

                    foreach (Control c in panel4.Controls)
                    {
                        if (c is Label)
                        {
                            Label lbl = (Label)c;
                            lbl.ForeColor = Color.White;
                            lbl.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                        }
                    }
                }

                // 2. GROUPBOX & CONTROLS STYLING
                foreach (Control c in form.Controls)
                {
                    if (c is GroupBox)
                    {
                        GroupBox gb = (GroupBox)c;
                        gb.BackColor = Color.FromArgb(238, 247, 240);
                        gb.ForeColor = PrimaryDarkGreen;
                        gb.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                        foreach (Control sub in gb.Controls)
                        {
                            if (sub is Label)
                            {
                                sub.ForeColor = DarkText;
                                sub.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                            else if (sub is TextBox || sub is ComboBox || sub is DateTimePicker)
                            {
                                sub.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                                if (sub is ComboBox)
                                {
                                    ComboBox cb = (ComboBox)sub;
                                    cb.FlatStyle = FlatStyle.Flat;
                                }
                            }
                            else if (sub is Button)
                            {
                                Button btn = (Button)sub;
                                if (btn.Name.Contains("del") || btn.Name.Contains("delete") || btn.Text.ToLower().Contains("delete"))
                                {
                                    btn.BackColor = DangerRed;
                                    btn.ForeColor = Color.White;
                                    btn.FlatStyle = FlatStyle.Flat;
                                    btn.FlatAppearance.BorderSize = 0;
                                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                }
                                else
                                {
                                    btn.BackColor = PrimaryDarkGreen;
                                    btn.ForeColor = Color.White;
                                    btn.FlatStyle = FlatStyle.Flat;
                                    btn.FlatAppearance.BorderSize = 0;
                                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                }
                            }
                        }
                    }
                    else if (c is Button)
                    {
                        Button btn = (Button)c;
                        btn.BackColor = PrimaryDarkGreen;
                        btn.ForeColor = Color.White;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    }
                    else if (c is ListView)
                    {
                        ListView lstv = (ListView)c;
                        lstv.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                    }
                }
            }
            catch (Exception) { }
        }

        private static void StyleGenerateFeeForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panel4) ───────────────────────────────────
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.BackColor = PrimaryDarkGreen;
                    panel4.Height = 60;
                    panel4.Paint -= PanelBottomBorder_Paint;

                    foreach (Control c in panel4.Controls)
                    {
                        if (c.Name == "label2" || c is Label)
                        {
                            c.ForeColor = Color.White;
                            c.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                            c.Location = new Point(60, 14);
                        }
                        else if (c is PictureBox)
                        {
                            c.Location = new Point(18, 14);
                            c.Size = new Size(32, 32);
                        }
                    }
                }

                // ── 2. LEFT PANEL (panel1) & GROUPBOX (groupBox1) ─────────────
                Panel panel1 = form.Controls["panel1"] as Panel;
                if (panel1 != null)
                {
                    panel1.BackColor = OffWhiteBg;
                    GroupBox groupBox1 = panel1.Controls["groupBox1"] as GroupBox;
                    if (groupBox1 != null)
                    {
                        groupBox1.BackColor = Color.FromArgb(238, 247, 240);
                        groupBox1.ForeColor = PrimaryDarkGreen;
                        groupBox1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                        foreach (Control c in groupBox1.Controls)
                        {
                            if (c is Label)
                            {
                                Label lbl = (Label)c;
                                if (lbl.Name == "label15")
                                {
                                    lbl.ForeColor = PrimaryDarkGreen;
                                    lbl.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                                }
                                else if (lbl.Name == "lblmonth")
                                {
                                    lbl.BackColor = Color.FromArgb(209, 231, 221);
                                    lbl.ForeColor = PrimaryDarkGreen;
                                    lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                                }
                                else if (lbl.Name == "label9")
                                {
                                    lbl.ForeColor = PrimaryDarkGreen;
                                    lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                                }
                                else if (lbl.Name == "label3")
                                {
                                    lbl.ForeColor = PrimaryDarkGreen;
                                    lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                }
                                else if (lbl.Name == "label14")
                                {
                                    lbl.ForeColor = MutedText;
                                    lbl.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
                                }
                                else
                                {
                                    lbl.ForeColor = DarkText;
                                    lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                                }
                            }
                            else if (c is CheckBox)
                            {
                                CheckBox chk = (CheckBox)c;
                                chk.ForeColor = PrimaryDarkGreen;
                                chk.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            }
                            else if (c is Button)
                            {
                                Button btn = (Button)c;
                                btn.BackColor = PrimaryDarkGreen;
                                btn.ForeColor = Color.White;
                                btn.FlatStyle = FlatStyle.Flat;
                                btn.FlatAppearance.BorderSize = 0;
                                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                            else if (c is GroupBox && c.Name == "groupBox4")
                            {
                                GroupBox gb4 = (GroupBox)c;
                                gb4.BackColor = Color.White;
                                gb4.ForeColor = PrimaryDarkGreen;
                                gb4.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

                                foreach (Control sub in gb4.Controls)
                                {
                                    if (sub is Label)
                                    {
                                        sub.ForeColor = MutedText;
                                        sub.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
                                    }
                                    else if (sub is Button)
                                    {
                                        Button b = (Button)sub;
                                        b.FlatStyle = FlatStyle.Flat;
                                        b.FlatAppearance.BorderSize = 0;
                                        b.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                                        b.ForeColor = Color.White;

                                        if (b.Name == "btnproc")
                                        {
                                            b.BackColor = PrimaryDarkGreen;
                                        }
                                        else if (b.Name == "button3")
                                        {
                                            b.BackColor = Color.FromArgb(15, 118, 110);
                                        }
                                        else if (b.Name == "frmvprinting")
                                        {
                                            b.BackColor = Color.FromArgb(2, 132, 199);
                                        }
                                        else
                                        {
                                            b.BackColor = PrimaryDarkGreen;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // ── 3. RIGHT PANELS (panel2 & panel3) ─────────────────────────
                Panel panel2 = form.Controls["panel2"] as Panel;
                if (panel2 != null)
                {
                    panel2.AutoScroll = true;
                    panel2.BackColor = Color.White;
                    foreach (Control c in panel2.Controls)
                    {
                        if (c is DataGridView)
                        {
                            DataGridView dgv = (DataGridView)c;
                            dgv.EnableHeadersVisualStyles = false;
                            dgv.BackgroundColor = OffWhiteBg;
                            dgv.BorderStyle = BorderStyle.FixedSingle;
                            dgv.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                            dgv.ScrollBars = ScrollBars.Both;

                            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDarkGreen;
                            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                            dgv.ColumnHeadersHeight = 35;

                            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244);
                            dgv.DefaultCellStyle.SelectionBackColor = ActiveGreen;
                            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                            dgv.GridColor = Color.FromArgb(180, 195, 210);

                            if (dgv.Name == "fee_Class_updateDataGridView")
                            {
                                dgv.Location = new Point(1, 36);
                                dgv.Size = new Size(panel2.Width - 2, panel2.Height - 38);
                                dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                            }
                        }
                        else if (c is BindingNavigator)
                        {
                            BindingNavigator bn = (BindingNavigator)c;
                            bn.Renderer = new GreenToolStripRenderer();
                            bn.BackColor = Color.White;
                            bn.ForeColor = DarkText;
                            bn.GripStyle = ToolStripGripStyle.Hidden;
                            bn.Dock = DockStyle.Top;
                            bn.Height = 34;
                            bn.BringToFront();
                            foreach (ToolStripItem item in bn.Items)
                            {
                                item.ForeColor = DarkText;
                                item.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                            }
                        }
                    }
                }

                Panel panel3 = form.Controls["panel3"] as Panel;
                if (panel3 != null)
                {
                    panel3.AutoScroll = true;
                    panel3.BackColor = Color.White;
                    foreach (Control c in panel3.Controls)
                    {
                        if (c is ListView)
                        {
                            ListView lv = (ListView)c;
                            lv.BackColor = Color.White;
                            lv.ForeColor = DarkText;
                            lv.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                            lv.FullRowSelect = true;
                            lv.GridLines = true;
                            lv.Scrollable = true;
                        }
                    }
                }

                form.AutoScroll = true;
            }
            catch (Exception) { }
        }

        private static void StyleEditFeeForm(Form form)
        {
            try
            {
                form.BackColor = OffWhiteBg;

                // ── 1. PAGE HEADER (panel4) ───────────────────────────────────
                Panel panel4 = form.Controls["panel4"] as Panel;
                if (panel4 != null)
                {
                    panel4.BackColor = PrimaryDarkGreen;
                    panel4.Height = 60;
                    panel4.Paint -= PanelBottomBorder_Paint;

                    foreach (Control c in panel4.Controls)
                    {
                        if (c.Name == "label4" || c is Label)
                        {
                            c.ForeColor = Color.White;
                            c.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                            c.Location = new Point(60, 14);
                        }
                        else if (c is PictureBox)
                        {
                            c.Location = new Point(18, 14);
                            c.Size = new Size(32, 32);
                        }
                    }
                }

                // ── 2. MAIN CONTAINER (panel1) ────────────────────────────────
                Panel panel1 = form.Controls["panel1"] as Panel;
                if (panel1 != null)
                {
                    panel1.BackColor = OffWhiteBg;
                    panel1.AutoScroll = true;

                    StyleEditFeeControlRecursive(panel1);
                }
            }
            catch (Exception) { }
        }

        private static void StyleEditFeeControlRecursive(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is GroupBox)
                {
                    GroupBox gb = (GroupBox)c;
                    gb.BackColor = Color.FromArgb(238, 247, 240);
                    gb.ForeColor = PrimaryDarkGreen;
                    gb.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    StyleEditFeeControlRecursive(gb);
                }
                else if (c is Label)
                {
                    Label lbl = (Label)c;
                    lbl.ForeColor = PrimaryDarkGreen;
                    lbl.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                else if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    tb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    tb.BackColor = Color.White;
                }
                else if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                    cb.FlatStyle = FlatStyle.Flat;
                }
                else if (c is Button)
                {
                    Button btn = (Button)c;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    btn.ForeColor = Color.White;

                    if (btn.Name == "btnshow" || btn.Name == "button1" || btn.Name == "button2" || btn.Name == "btnsave")
                    {
                        btn.BackColor = PrimaryDarkGreen;
                    }
                    else if (btn.Name == "btnprint")
                    {
                        btn.BackColor = Color.FromArgb(15, 118, 110);
                    }
                    else if (btn.Name == "btncancel")
                    {
                        btn.BackColor = Color.FromArgb(220, 38, 38);
                    }
                    else
                    {
                        btn.BackColor = PrimaryDarkGreen;
                    }
                }
                else if (c is DataGridView)
                {
                    DataGridView dgv = (DataGridView)c;
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.BackgroundColor = OffWhiteBg;
                    dgv.BorderStyle = BorderStyle.FixedSingle;
                    dgv.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                    dgv.ScrollBars = ScrollBars.Both;

                    dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDarkGreen;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    dgv.ColumnHeadersHeight = 35;

                    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 253, 244);
                    dgv.DefaultCellStyle.SelectionBackColor = ActiveGreen;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.GridColor = Color.FromArgb(180, 195, 210);
                }
                else if (c is BindingNavigator)
                {
                    BindingNavigator bn = (BindingNavigator)c;
                    bn.Renderer = new GreenToolStripRenderer();
                    bn.BackColor = Color.White;
                    bn.ForeColor = DarkText;
                    bn.GripStyle = ToolStripGripStyle.Hidden;
                    foreach (ToolStripItem item in bn.Items)
                    {
                        item.ForeColor = DarkText;
                        item.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                    }
                }
                else if (c is Panel)
                {
                    Panel p = (Panel)c;
                    if (p.Name == "panel3")
                    {
                        p.BackColor = Color.White;
                        p.BackgroundImage = null;
                        p.BorderStyle = BorderStyle.FixedSingle;
                    }
                    StyleEditFeeControlRecursive(p);
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

        public override Color MenuItemSelected { get { return ThemeHelper.HoverGreen; } }
        public override Color MenuItemSelectedGradientBegin { get { return ThemeHelper.HoverGreen; } }
        public override Color MenuItemSelectedGradientEnd { get { return ThemeHelper.HoverGreen; } }
        public override Color MenuItemBorder { get { return Color.Transparent; } }

        public override Color MenuItemPressedGradientBegin { get { return ThemeHelper.ActiveGreen; } }
        public override Color MenuItemPressedGradientEnd { get { return ThemeHelper.ActiveGreen; } }

        public override Color ToolStripDropDownBackground { get { return Color.White; } }
        public override Color ImageMarginGradientBegin { get { return Color.White; } }
        public override Color ImageMarginGradientMiddle { get { return Color.White; } }
        public override Color ImageMarginGradientEnd { get { return Color.White; } }

        public override Color MenuBorder { get { return Color.FromArgb(163, 217, 165); } }
    }

    public class GreenToolStripRenderer : ToolStripProfessionalRenderer
    {
        public GreenToolStripRenderer() : base(new GreenColorTable()) { }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is MenuStrip && e.ToolStrip.Name == "menuStrip1")
            {
                using (Brush brush = new SolidBrush(ThemeHelper.PrimaryDarkGreen))
                {
                    e.Graphics.FillRectangle(brush, e.AffectedBounds);
                }
            }
            else if (e.ToolStrip is ToolStripDropDownMenu)
            {
                using (Brush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillRectangle(brush, e.AffectedBounds);
                }
            }
            else
            {
                base.OnRenderToolStripBackground(e);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is MenuStrip && e.ToolStrip.Name == "menuStrip1")
            {
                using (Pen pen = new Pen(Color.FromArgb(6, 90, 46), 1F))
                {
                    e.Graphics.DrawLine(pen, e.ToolStrip.Width - 1, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height);
                }
            }
            else if (e.ToolStrip is ToolStripDropDownMenu)
            {
                using (Pen pen = new Pen(Color.FromArgb(163, 217, 165), 1F))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
                }
            }
            else
            {
                base.OnRenderToolStripBorder(e);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.IsOnDropDown)
            {
                e.TextColor = e.Item.Selected ? Color.FromArgb(8, 120, 61) : Color.FromArgb(30, 41, 59);
                e.TextFont = e.Item.Selected ? new Font("Segoe UI", 9.5F, FontStyle.Bold) : new Font("Segoe UI", 9.5F, FontStyle.Regular);

                Rectangle r = e.TextRectangle;
                r.X = 36;
                e.TextRectangle = r;
                base.OnRenderItemText(e);
            }
            else if ((e.ToolStrip is MenuStrip && (e.ToolStrip.Name == "menuStrip1" || e.ToolStrip.Dock == DockStyle.Left)) && e.Item.Height >= 40)
            {
                e.TextColor = Color.White;
                e.TextFont = new Font("Segoe UI", 9.25F, FontStyle.Bold);

                Rectangle r = e.Item.ContentRectangle;
                r.Y = e.Item.Height < 58 ? 32 : (e.Item.Height < 66 ? 38 : 46);
                r.Height = 22;
                e.TextRectangle = r;
                e.TextFormat = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine;
                base.OnRenderItemText(e);
            }
            else
            {
                Color bg = e.ToolStrip != null ? e.ToolStrip.BackColor : Color.White;
                bool isDarkBg = (bg.R * 0.299 + bg.G * 0.587 + bg.B * 0.114) < 140;
                e.TextColor = isDarkBg ? Color.White : ThemeHelper.DarkText;
                e.TextFont = new Font("Segoe UI", 9F, FontStyle.Regular);
                base.OnRenderItemText(e);
            }
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            if (e.Item.IsOnDropDown)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int ix = 12;
                int iy = (e.Item.Height - 16) / 2;
                if (iy < 2) iy = 2;

                if (e.Image != null)
                {
                    g.DrawImage(e.Image, new Rectangle(ix, iy, 16, 16));
                }
                else
                {
                    string text = e.Item.Text != null ? e.Item.Text.ToLower() : "";
                    Color iconColor = e.Item.Selected ? Color.FromArgb(8, 120, 61) : Color.FromArgb(100, 116, 139);
                    DrawSubmenuIcon(g, text, ix, iy, iconColor);
                }
            }
            else if ((e.ToolStrip is MenuStrip && (e.ToolStrip.Name == "menuStrip1" || e.ToolStrip.Dock == DockStyle.Left)) && e.Item.Height >= 40 && e.Image != null)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int circleSize = e.Item.Height < 58 ? 28 : (e.Item.Height < 66 ? 32 : 38);
                int cx = (e.Item.Width - circleSize) / 2;
                int cy = e.Item.Height < 58 ? 2 : (e.Item.Height < 66 ? 4 : 6);

                using (SolidBrush circleBrush = new SolidBrush(Color.FromArgb(35, 255, 255, 255)))
                {
                    g.FillEllipse(circleBrush, cx, cy, circleSize, circleSize);
                }
                using (Pen circlePen = new Pen(Color.FromArgb(65, 255, 255, 255), 1F))
                {
                    g.DrawEllipse(circlePen, cx, cy, circleSize, circleSize);
                }

                int maxIcon = circleSize - 10;
                if (maxIcon < 16) maxIcon = 16;
                int imgW = e.Image.Width > maxIcon ? maxIcon : e.Image.Width;
                int imgH = e.Image.Height > maxIcon ? maxIcon : e.Image.Height;
                int ix = cx + (circleSize - imgW) / 2;
                int iy = cy + (circleSize - imgH) / 2;
                g.DrawImage(e.Image, new Rectangle(ix, iy, imgW, imgH));
            }
            else
            {
                base.OnRenderItemImage(e);
            }
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected || (e.Item is ToolStripButton && ((ToolStripButton)e.Item).Checked))
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(1, 1, e.Item.Width - 2, e.Item.Height - 2);
                Color fill = e.Item.Pressed ? Color.FromArgb(200, 230, 205) : Color.FromArgb(232, 245, 233);
                Color border = Color.FromArgb(163, 217, 165);
                using (Brush b = new SolidBrush(fill))
                using (Pen p = new Pen(border, 1F))
                {
                    using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRect(rect, 4))
                    {
                        g.FillPath(b, path);
                        g.DrawPath(p, path);
                    }
                }
            }
            else
            {
                base.OnRenderButtonBackground(e);
            }
        }

        private void DrawSubmenuIcon(Graphics g, string text, int x, int y, Color color)
        {
            try
            {
                using (Pen pen = new Pen(color, 1.4F))
                using (SolidBrush brush = new SolidBrush(color))
                {
                    if (text.Contains("session"))
                    {
                        // Calendar icon
                        g.DrawRectangle(pen, x + 1, y + 2, 14, 12);
                        g.FillRectangle(brush, x + 1, y + 2, 14, 4);
                        g.FillRectangle(brush, x + 4, y + 8, 2, 2);
                        g.FillRectangle(brush, x + 7, y + 8, 2, 2);
                        g.FillRectangle(brush, x + 10, y + 8, 2, 2);
                        g.FillRectangle(brush, x + 4, y + 11, 2, 2);
                        g.FillRectangle(brush, x + 7, y + 11, 2, 2);
                    }
                    else if (text.Contains("class"))
                    {
                        // School/Building icon
                        Point[] roof = { new Point(x + 8, y + 1), new Point(x + 1, y + 6), new Point(x + 15, y + 6) };
                        g.FillPolygon(brush, roof);
                        g.DrawRectangle(pen, x + 3, y + 6, 10, 8);
                        g.FillRectangle(brush, x + 7, y + 9, 2, 5);
                    }
                    else if (text.Contains("section"))
                    {
                        // Grid icon
                        g.DrawRectangle(pen, x + 1, y + 1, 6, 6);
                        g.DrawRectangle(pen, x + 9, y + 1, 6, 6);
                        g.DrawRectangle(pen, x + 1, y + 9, 6, 6);
                        g.DrawRectangle(pen, x + 9, y + 9, 6, 6);
                    }
                    else if (text.Contains("shift"))
                    {
                        // Clock icon
                        g.DrawEllipse(pen, x + 1, y + 1, 14, 14);
                        g.DrawLine(pen, x + 8, y + 4, x + 8, y + 8);
                        g.DrawLine(pen, x + 8, y + 8, x + 11, y + 8);
                    }
                    else if (text.Contains("fee head") || (text.Contains("fee") && !text.Contains("voucher")))
                    {
                        // Cash/Money icon
                        g.DrawRectangle(pen, x + 1, y + 3, 14, 10);
                        g.DrawEllipse(pen, x + 6, y + 6, 4, 4);
                    }
                    else if (text.Contains("employee") || text.Contains("staff") || text.Contains("user"))
                    {
                        // Person/Users icon
                        g.DrawEllipse(pen, x + 5, y + 1, 6, 6);
                        g.DrawArc(pen, x + 2, y + 8, 12, 8, 180, 180);
                    }
                    else if (text.Contains("expense head") || text.Contains("head"))
                    {
                        // Document icon
                        g.DrawRectangle(pen, x + 2, y + 1, 12, 14);
                        g.DrawLine(pen, x + 5, y + 5, x + 11, y + 5);
                        g.DrawLine(pen, x + 5, y + 8, x + 11, y + 8);
                        g.DrawLine(pen, x + 5, y + 11, x + 9, y + 11);
                    }
                    else if (text.Contains("expense detail") || text.Contains("detail") || text.Contains("voucher"))
                    {
                        // Receipt/List icon
                        g.DrawRectangle(pen, x + 2, y + 1, 12, 14);
                        g.FillRectangle(brush, x + 4, y + 4, 2, 2);
                        g.DrawLine(pen, x + 7, y + 5, x + 11, y + 5);
                        g.FillRectangle(brush, x + 4, y + 8, 2, 2);
                        g.DrawLine(pen, x + 7, y + 9, x + 11, y + 9);
                    }
                    else if (text.Contains("bank"))
                    {
                        // Bank icon
                        Point[] roof = { new Point(x + 8, y + 1), new Point(x + 1, y + 5), new Point(x + 15, y + 5) };
                        g.FillPolygon(brush, roof);
                        g.DrawLine(pen, x + 3, y + 5, x + 3, y + 12);
                        g.DrawLine(pen, x + 8, y + 5, x + 8, y + 12);
                        g.DrawLine(pen, x + 13, y + 5, x + 13, y + 12);
                        g.DrawLine(pen, x + 1, y + 13, x + 15, y + 13);
                    }
                    else
                    {
                        // Bullet dot icon
                        g.FillEllipse(brush, x + 5, y + 5, 6, 6);
                    }
                }
            }
            catch { }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                if (!e.Item.IsOnDropDown)
                {
                    bool isActive = (e.Item == ThemeHelper.ActiveSidebarItem);
                    bool isHovered = e.Item.Selected;

                    Rectangle rect = new Rectangle(4, 2, e.Item.Width - 8, e.Item.Height - 4);

                    if (isActive || e.Item.Pressed)
                    {
                        using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRect(rect, 8))
                        using (Brush brush = new SolidBrush(ThemeHelper.ActiveGreen))
                        {
                            g.FillPath(brush, path);
                        }
                        using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRect(rect, 8))
                        using (Pen pen = new Pen(Color.FromArgb(70, 255, 255, 255), 1F))
                        {
                            g.DrawPath(pen, path);
                        }
                        return;
                    }
                    else if (isHovered)
                    {
                        using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRect(rect, 8))
                        using (Brush brush = new SolidBrush(ThemeHelper.HoverGreen))
                        {
                            g.FillPath(brush, path);
                        }
                        return;
                    }
                }
                else
                {
                    if (e.Item.Selected)
                    {
                        Rectangle rect = new Rectangle(3, 1, e.Item.Width - 6, e.Item.Height - 2);
                        using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundedRect(rect, 6))
                        using (Brush brush = new SolidBrush(Color.FromArgb(232, 245, 233)))
                        {
                            g.FillPath(brush, path);
                        }
                        using (Brush barBrush = new SolidBrush(ThemeHelper.PrimaryDarkGreen))
                        {
                            g.FillRectangle(barBrush, 3, 3, 3.5F, e.Item.Height - 6);
                        }
                        return;
                    }
                    else
                    {
                        using (Brush bgBrush = new SolidBrush(Color.White))
                        {
                            g.FillRectangle(bgBrush, e.Item.ContentRectangle);
                        }
                        return;
                    }
                }
            }
            base.OnRenderMenuItemBackground(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDownMenu)
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 238, 232), 1F))
                {
                    int y = e.Item.Height / 2;
                    e.Graphics.DrawLine(pen, 12, y, e.Item.Width - 12, y);
                }
            }
            else
            {
                base.OnRenderSeparator(e);
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            return ThemeHelper.GetRoundedRect(bounds, radius);
        }
    }
}
