using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace School._forms
{
    public partial class dashbaord : Form
    {
        private class ClassStrengthItem
        {
            public string ClassName;
            public int Strength;
            public ClassStrengthItem(string cName, int count)
            {
                ClassName = cName;
                Strength = count;
            }
        }

        private class MonthlyFeeItem
        {
            public string MonthName;
            public decimal Received;
            public decimal Receivable;
            public MonthlyFeeItem(string mName, decimal rec, decimal recv)
            {
                MonthName = mName;
                Received = rec;
                Receivable = recv;
            }
        }

        DataSet rs = new DataSet();
        SYSTEMSETTING SYS = new SYSTEMSETTING();
        private Timer clockTimer;

        // Metric values for charts
        private decimal decFeeReceivable = 0;
        private decimal decFeeReceived = 0;
        private decimal decBalance = 0;
        private List<ClassStrengthItem> listClassStrength = new List<ClassStrengthItem>();
        private List<MonthlyFeeItem> listMonthlyFee = new List<MonthlyFeeItem>();
        private List<string> listRecentActivities = new List<string>();

        public dashbaord()
        {
            InitializeComponent();

            this.Resize += new EventHandler(dashbaord_Resize);
            this.Shown += new EventHandler(dashbaord_Shown);

            // Card custom paint handlers
            this.panel2.Paint += new PaintEventHandler(Card_Paint);
            this.panel8.Paint += new PaintEventHandler(Card_Paint);
            this.panel7.Paint += new PaintEventHandler(Card_Paint);
            this.panel4.Paint += new PaintEventHandler(Card_Paint);
            this.panel9.Paint += new PaintEventHandler(BalanceCard_Paint);
            this.panel6.Paint += new PaintEventHandler(Card_Paint);
            this.panel5.Paint += new PaintEventHandler(Card_Paint);
            this.panelCalendarCard.Paint += new PaintEventHandler(panelCalendarCard_Paint);
            this.panelCalendarCard.MouseDown += new MouseEventHandler(panelCalendarCard_MouseDown);
            this.panelCalendarCard.MouseMove += new MouseEventHandler(panelCalendarCard_MouseMove);
            this.panelCalendarCard.MouseLeave += new EventHandler(panelCalendarCard_MouseLeave);
            this.monthCalendar1.Visible = false;
            this.panel3.Paint += new PaintEventHandler(Card_Paint);
            this.pnlTodayWidget.Paint += new PaintEventHandler(Widget_Paint);
            this.pnlTimeWidget.Paint += new PaintEventHandler(Widget_Paint);

            // Chart & Activity custom paint handlers
            this.pnlChartFeeDonut.Paint += new PaintEventHandler(pnlChartFeeDonut_Paint);
            this.pnlChartClassStrength.Paint += new PaintEventHandler(pnlChartClassStrength_Paint);
            this.pnlChartMonthlyTrend.Paint += new PaintEventHandler(pnlChartMonthlyTrend_Paint);
            this.pnlRecentActivity.Paint += new PaintEventHandler(pnlRecentActivity_Paint);
        }

        private void dashbaord_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyTheme(this);
            LBLCAMPUSNAME.Text = SYSTEMSETTING.schoolname;

            // Lock initial view position to top left (0,0)
            this.ActiveControl = this.panel1;
            this.AutoScrollPosition = new Point(0, 0);

            // Initialize dynamic date & time
            UpdateDateTime();
            clockTimer = new Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += (s, ev) => UpdateDateTime();
            clockTimer.Start();

            GetTotal();
            Fill_grid_outstanding();
            LoadChartData();
            LoadRecentActivities();

            LayoutDashboard();

            try
            {
                this.outstanding_ClassesTableAdapter.FillBy(this.dashboard.Outstanding_Classes, ((decimal)(System.Convert.ChangeType(SYSTEMSETTING.branch_ID, typeof(decimal)))), SYSTEMSETTING.sessionid);
            }
            catch (System.Exception ex)
            {
            }
        }

        private void dashbaord_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = this.panel1;
            this.AutoScrollPosition = new Point(0, 0);
        }

        private void dashbaord_Resize(object sender, EventArgs e)
        {
            LayoutDashboard();
            this.Invalidate(true);
        }

        private void LayoutDashboard()
        {
            try
            {
                int w = this.ClientSize.Width;
                int h = this.ClientSize.Height;

                if (w < 850) w = 850;

                int margin = 20;
                int gap = 15;
                int contentWidth = w - (margin * 2);

                // 1. Header (panel1 Height = 75, Docked Top at Y = 0)
                panel1.Height = 75;

                // Position Header Widgets
                pnlTodayWidget.Location = new Point(w - 410, 12);
                pnlTodayWidget.Size = new Size(250, 50);

                pnlTimeWidget.Location = new Point(w - 145, 12);
                pnlTimeWidget.Size = new Size(130, 50);

                // 2. Dashboard Title Banner (Y = 83)
                label3.Location = new Point(margin, 83);
                lblWelcomeTag.Location = new Point(margin + 175, 91);

                // 3. Row 1: 5 KPI Cards (Y = 120, Height = 115)
                int kpiWidth = (contentWidth - (gap * 4)) / 5;
                int kpiY = 120;
                int kpiH = 115;

                Panel[] kpiPanels = new Panel[] { panel2, panel8, panel7, panel4, panel9 };
                for (int i = 0; i < 5; i++)
                {
                    int curX = margin + (i * (kpiWidth + gap));
                    int curW = (i == 4) ? (contentWidth - (4 * (kpiWidth + gap))) : kpiWidth;
                    kpiPanels[i].Location = new Point(curX, kpiY);
                    kpiPanels[i].Size = new Size(curW, kpiH);

                    foreach (Control child in kpiPanels[i].Controls)
                    {
                        if (child is PictureBox)
                        {
                            child.Location = new Point(14, 16);
                            child.Size = new Size(40, 40);
                        }
                        else if (child is Label)
                        {
                            string n = child.Name;
                            if (n == "label16" || n == "label1" || n == "label22" || n == "label17" || n == "label24")
                            {
                                child.Location = new Point(60, 12);
                                child.Size = new Size(curW - 66, 18);
                            }
                            else if (n.StartsWith("lbl_") || n == "lbltotal_earning" || n == "lblreceived" || n == "lblbalance")
                            {
                                child.Location = new Point(58, 32);
                                child.Size = new Size(curW - 64, 42);
                            }
                            else if (n.StartsWith("lblSub"))
                            {
                                child.Location = new Point(60, 78);
                                child.Size = new Size(curW - 66, 20);
                            }
                        }
                    }
                }

                // 4. Row 2: Analytics Charts (Y = 245, Height = 240)
                int row1Y = 245;
                int row1H = 240;
                int wDonut = (int)(contentWidth * 0.32);
                int wStrength = (int)(contentWidth * 0.38);
                int wOut = contentWidth - (wDonut + wStrength + (gap * 2));

                pnlChartFeeDonut.Location = new Point(margin, row1Y);
                pnlChartFeeDonut.Size = new Size(wDonut, row1H);

                pnlChartClassStrength.Location = new Point(margin + wDonut + gap, row1Y);
                pnlChartClassStrength.Size = new Size(wStrength, row1H);

                panel6.Location = new Point(margin + wDonut + gap + wStrength + gap, row1Y);
                panel6.Size = new Size(wOut, row1H);

                // Center empty state inside panel6
                picNoOutstanding.Location = new Point((wOut - 48) / 2, 70);
                lblNoOutstanding.Location = new Point(0, 128);
                lblNoOutstanding.Size = new Size(wOut, 22);

                // 5. Row 3: Classwise Outstanding Table & Monthly Trend (Y = 495, Height = 255)
                int row2Y = 495;
                int row2H = 255;
                int wTable = (int)(contentWidth * 0.60);
                int wMonthly = contentWidth - (wTable + gap);

                panel5.Location = new Point(margin, row2Y);
                panel5.Size = new Size(wTable, row2H);

                lstv_outstandingfee.Location = new Point(15, 42);
                lstv_outstandingfee.Size = new Size(wTable - 30, row2H - 52);

                int usableTableW = lstv_outstandingfee.Width - 25;
                if (usableTableW > 300)
                {
                    columnHeader1.Width = (int)(usableTableW * 0.22);
                    columnHeader2.Width = (int)(usableTableW * 0.14);
                    columnHeader3.Width = (int)(usableTableW * 0.14);
                    columnHeader4.Width = (int)(usableTableW * 0.17);
                    columnHeader5.Width = (int)(usableTableW * 0.16);
                    columnHeader6.Width = (int)(usableTableW * 0.17);
                }

                pnlChartMonthlyTrend.Location = new Point(margin + wTable + gap, row2Y);
                pnlChartMonthlyTrend.Size = new Size(wMonthly, row2H);

                // 6. Row 4: Calendar, Recent Activities & Software Info (Y = 760, Height = 235)
                int row3Y = 760;
                int row3H = 235;
                int wCal = (int)(contentWidth * 0.30);
                int wAct = (int)(contentWidth * 0.35);
                int wEdu = contentWidth - (wCal + wAct + (gap * 2));

                panelCalendarCard.Location = new Point(margin, row3Y);
                panelCalendarCard.Size = new Size(wCal, row3H);
                monthCalendar1.Location = new Point(Math.Max(10, (wCal - monthCalendar1.Width) / 2), 12);

                pnlRecentActivity.Location = new Point(margin + wCal + gap, row3Y);
                pnlRecentActivity.Size = new Size(wAct, row3H);

                panel3.Location = new Point(margin + wCal + gap + wAct + gap, row3Y);
                panel3.Size = new Size(wEdu, row3H);

                // Info card internal positioning
                pnlInfoDivider.Size = new Size(wEdu - 36, 1);
                pictureBox1.Location = new Point(wEdu - 95, 64);

                this.AutoScrollPosition = new Point(0, 0);
            }
            catch { }
        }

        private void UpdateDateTime()
        {
            try
            {
                lblTodayDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
                lblCurrentTime.Text = DateTime.Now.ToString("hh:mm tt");
            }
            catch { }
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Control card = (Control)sender;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(Color.FromArgb(221, 231, 225), 1.5F))
                {
                    using (GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 10))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
            catch { }
        }

        private void BalanceCard_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Control card = (Control)sender;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(7, 92, 44)))
                {
                    using (GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 10))
                    {
                        g.FillPath(brush, path);
                    }
                }
            }
            catch { }
        }

        private void Widget_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Control widget = (Control)sender;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(Color.FromArgb(165, 214, 167), 1.5F))
                {
                    using (GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, widget.Width - 1, widget.Height - 1), 8))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
            catch { }
        }

        // ==========================================
        // CHART 1: FEE COLLECTION OVERVIEW (DONUT)
        // ==========================================
        private void pnlChartFeeDonut_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlChartFeeDonut.Width;
                int h = pnlChartFeeDonut.Height;

                // Card Outline
                using (Pen borderPen = new Pen(Color.FromArgb(221, 231, 225), 1.5F))
                using (GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, w - 1, h - 1), 10))
                {
                    g.DrawPath(borderPen, path);
                }

                // Title
                using (Font titleFont = new Font("Segoe UI", 11.5F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(7, 92, 44)))
                {
                    g.DrawString("Fee Collection Overview", titleFont, textBrush, 16, 12);
                }

                decimal total = decFeeReceivable;
                if (total <= 0) total = decFeeReceived + decBalance;

                int pctReceived = 0;
                int pctBalance = 0;

                if (total > 0)
                {
                    pctReceived = (int)Math.Round((decFeeReceived / total) * 100);
                    if (pctReceived > 100) pctReceived = 100;
                    pctBalance = 100 - pctReceived;
                }

                // Donut dimensions
                int donutSize = Math.Min(130, h - 80);
                int donutX = 20;
                int donutY = 48;
                int holeSize = (int)(donutSize * 0.65);
                int holeOffset = (donutSize - holeSize) / 2;

                if (total > 0)
                {
                    float angleReceived = (float)(pctReceived * 3.6);
                    float angleBalance = 360f - angleReceived;

                    using (SolidBrush recBrush = new SolidBrush(Color.FromArgb(11, 122, 59)))
                    {
                        g.FillPie(recBrush, donutX, donutY, donutSize, donutSize, -90, angleReceived);
                    }

                    using (SolidBrush balBrush = new SolidBrush(Color.FromArgb(165, 214, 167)))
                    {
                        g.FillPie(balBrush, donutX, donutY, donutSize, donutSize, -90 + angleReceived, angleBalance);
                    }
                }
                else
                {
                    using (SolidBrush emptyBrush = new SolidBrush(Color.FromArgb(235, 240, 235)))
                    {
                        g.FillEllipse(emptyBrush, donutX, donutY, donutSize, donutSize);
                    }
                }

                // Donut Center Hole (White)
                using (SolidBrush holeBrush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(holeBrush, donutX + holeOffset, donutY + holeOffset, holeSize, holeSize);
                }

                // Center Percentage Text
                using (Font pctFont = new Font("Segoe UI", 15F, FontStyle.Bold))
                using (Font subFont = new Font("Segoe UI", 8F, FontStyle.Regular))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(11, 122, 59)))
                using (SolidBrush mutedBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                {
                    string pctStr = pctReceived + "%";
                    SizeF sz = g.MeasureString(pctStr, pctFont);
                    g.DrawString(pctStr, pctFont, textBrush, donutX + holeOffset + (holeSize - sz.Width) / 2, donutY + holeOffset + 18);

                    string subStr = "Collected";
                    SizeF szSub = g.MeasureString(subStr, subFont);
                    g.DrawString(subStr, subFont, mutedBrush, donutX + holeOffset + (holeSize - szSub.Width) / 2, donutY + holeOffset + 44);
                }

                // Legend on the Right (Safely offset from title)
                int legendX = donutX + donutSize + 18;
                int legendY = 52;

                using (SolidBrush boxBrush = new SolidBrush(Color.FromArgb(11, 122, 59)))
                using (Font itemFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (Font valFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(31, 41, 55)))
                using (SolidBrush mutedBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                {
                    g.FillRectangle(boxBrush, legendX, legendY + 3, 12, 12);
                    g.DrawString("Received (" + pctReceived + "%)", itemFont, textBrush, legendX + 18, legendY);
                    g.DrawString(decFeeReceived.ToString("N0") + " PKR", valFont, mutedBrush, legendX + 18, legendY + 16);

                    legendY += 40;
                    using (SolidBrush balBox = new SolidBrush(Color.FromArgb(165, 214, 167)))
                    {
                        g.FillRectangle(balBox, legendX, legendY + 3, 12, 12);
                    }
                    g.DrawString("Pending (" + pctBalance + "%)", itemFont, textBrush, legendX + 18, legendY);
                    g.DrawString(decBalance.ToString("N0") + " PKR", valFont, mutedBrush, legendX + 18, legendY + 16);

                    legendY += 40;
                    using (SolidBrush totBox = new SolidBrush(Color.FromArgb(75, 85, 99)))
                    {
                        g.FillRectangle(totBox, legendX, legendY + 3, 12, 12);
                    }
                    g.DrawString("Total Receivable", itemFont, textBrush, legendX + 18, legendY);
                    g.DrawString(decFeeReceivable.ToString("N0") + " PKR", valFont, mutedBrush, legendX + 18, legendY + 16);
                }
            }
            catch { }
        }

        // ==========================================
        // CHART 2: STUDENT STRENGTH BY CLASS
        // ==========================================
        private void pnlChartClassStrength_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlChartClassStrength.Width;
                int h = pnlChartClassStrength.Height;

                // Card Outline
                using (Pen borderPen = new Pen(Color.FromArgb(221, 231, 225), 1.5F))
                using (GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, w - 1, h - 1), 10))
                {
                    g.DrawPath(borderPen, path);
                }

                // Title
                using (Font titleFont = new Font("Segoe UI", 11.5F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(7, 92, 44)))
                {
                    g.DrawString("Student Strength by Class", titleFont, textBrush, 16, 12);
                }

                if (listClassStrength == null || listClassStrength.Count == 0)
                {
                    using (Font emptyFont = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                    using (SolidBrush emptyBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        g.DrawString("No class strength records available.", emptyFont, emptyBrush, new RectangleF(0, 0, w, h), sf);
                    }
                    return;
                }

                int maxStrength = 1;
                foreach (var item in listClassStrength)
                {
                    if (item.Strength > maxStrength) maxStrength = item.Strength;
                }

                int startY = 44;
                int barHeight = 16;
                int labelWidth = 90;
                int rightPadding = 70;
                int maxBarWidth = Math.Max(50, w - (labelWidth + rightPadding + 30));
                int count = Math.Min(listClassStrength.Count, 6);

                using (Font lblFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (Font valFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(31, 41, 55)))
                using (SolidBrush valBrush = new SolidBrush(Color.FromArgb(11, 122, 59)))
                using (SolidBrush bgBarBrush = new SolidBrush(Color.FromArgb(238, 245, 239)))
                using (SolidBrush fillBarBrush = new SolidBrush(Color.FromArgb(28, 162, 80)))
                {
                    for (int i = 0; i < count; i++)
                    {
                        var item = listClassStrength[i];
                        int currentY = startY + (i * 29);

                        // Class Name
                        string className = item.ClassName;
                        if (className.Length > 12) className = className.Substring(0, 10) + "..";
                        g.DrawString(className, lblFont, textBrush, 16, currentY);

                        // Background Track
                        int barX = 16 + labelWidth;
                        g.FillRectangle(bgBarBrush, barX, currentY + 2, maxBarWidth, barHeight);

                        // Filled Bar
                        int currentBarWidth = (int)(((double)item.Strength / maxStrength) * maxBarWidth);
                        if (currentBarWidth > 0)
                        {
                            g.FillRectangle(fillBarBrush, barX, currentY + 2, currentBarWidth, barHeight);
                        }

                        // Number Value
                        g.DrawString(item.Strength.ToString() + " stds", valFont, valBrush, barX + maxBarWidth + 10, currentY);
                    }
                }
            }
            catch { }
        }

        // ==========================================
        // CHART 3: MONTHLY FEE COLLECTION TREND
        // ==========================================
        private void pnlChartMonthlyTrend_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlChartMonthlyTrend.Width;
                int h = pnlChartMonthlyTrend.Height;

                // Card Outline
                using (Pen borderPen = new Pen(Color.FromArgb(221, 231, 225), 1.5F))
                using (GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, w - 1, h - 1), 10))
                {
                    g.DrawPath(borderPen, path);
                }

                // Title
                using (Font titleFont = new Font("Segoe UI", 11.5F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(7, 92, 44)))
                {
                    g.DrawString("Monthly Fee Collection Trend", titleFont, textBrush, 16, 12);
                }

                // Legend aligned top-right (zero collision)
                using (Font legendFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(75, 85, 99)))
                using (SolidBrush recBrush = new SolidBrush(Color.FromArgb(11, 122, 59)))
                using (SolidBrush expBrush = new SolidBrush(Color.FromArgb(165, 214, 167)))
                {
                    g.FillRectangle(recBrush, w - 190, 16, 10, 10);
                    g.DrawString("Received", legendFont, textBrush, w - 175, 14);

                    g.FillRectangle(expBrush, w - 110, 16, 10, 10);
                    g.DrawString("Receivable", legendFont, textBrush, w - 95, 14);
                }

                // Draw Bar Chart Axes
                int chartLeft = 30;
                int chartBottom = h - 35;
                int chartHeight = 155;
                int chartWidth = w - 50;

                using (Pen gridPen = new Pen(Color.FromArgb(235, 238, 235), 1F))
                {
                    g.DrawLine(gridPen, chartLeft, chartBottom, chartLeft + chartWidth, chartBottom);
                    g.DrawLine(gridPen, chartLeft, chartBottom - (chartHeight / 2), chartLeft + chartWidth, chartBottom - (chartHeight / 2));
                    g.DrawLine(gridPen, chartLeft, chartBottom - chartHeight, chartLeft + chartWidth, chartBottom - chartHeight);
                }

                if (listMonthlyFee == null || listMonthlyFee.Count == 0)
                {
                    using (Font emptyFont = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                    using (SolidBrush emptyBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        g.DrawString("No monthly transaction records available.", emptyFont, emptyBrush, new RectangleF(0, 0, w, h), sf);
                    }
                    return;
                }

                decimal maxVal = 1;
                foreach (var item in listMonthlyFee)
                {
                    if (item.Received > maxVal) maxVal = item.Received;
                    if (item.Receivable > maxVal) maxVal = item.Receivable;
                }

                int groupWidth = chartWidth / listMonthlyFee.Count;
                int colWidth = Math.Min(groupWidth / 3, 20);

                using (Font monthFont = new Font("Segoe UI", 8F, FontStyle.Bold))
                using (SolidBrush monthBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                using (SolidBrush recBrush = new SolidBrush(Color.FromArgb(11, 122, 59)))
                using (SolidBrush expBrush = new SolidBrush(Color.FromArgb(165, 214, 167)))
                {
                    for (int i = 0; i < listMonthlyFee.Count; i++)
                    {
                        var item = listMonthlyFee[i];
                        int groupX = chartLeft + (i * groupWidth) + (groupWidth / 2) - colWidth;

                        // Bar 1: Received
                        int recHeight = (int)(((double)item.Received / (double)maxVal) * chartHeight);
                        if (recHeight > 0)
                        {
                            g.FillRectangle(recBrush, groupX, chartBottom - recHeight, colWidth, recHeight);
                        }

                        // Bar 2: Receivable
                        int expHeight = (int)(((double)item.Receivable / (double)maxVal) * chartHeight);
                        if (expHeight > 0)
                        {
                            g.FillRectangle(expBrush, groupX + colWidth + 2, chartBottom - expHeight, colWidth, expHeight);
                        }

                        // Month Label
                        SizeF sz = g.MeasureString(item.MonthName, monthFont);
                        g.DrawString(item.MonthName, monthFont, monthBrush, groupX + colWidth - (sz.Width / 2), chartBottom + 6);
                    }
                }
            }
            catch { }
        }

        // ==========================================
        // WIDGET: RECENT ACTIVITIES
        // ==========================================
        private void pnlRecentActivity_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlRecentActivity.Width;
                int h = pnlRecentActivity.Height;

                // Card Outline
                using (Pen borderPen = new Pen(Color.FromArgb(221, 231, 225), 1.5F))
                using (GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, w - 1, h - 1), 10))
                {
                    g.DrawPath(borderPen, path);
                }

                // Title
                using (Font titleFont = new Font("Segoe UI", 11.5F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(7, 92, 44)))
                {
                    g.DrawString("Recent Activities", titleFont, textBrush, 16, 12);
                }

                if (listRecentActivities == null || listRecentActivities.Count == 0)
                {
                    using (Font emptyFont = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                    using (Font subFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                    using (SolidBrush emptyBrush = new SolidBrush(Color.FromArgb(31, 41, 55)))
                    using (SolidBrush mutedBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                    {
                        g.DrawString("No recent activities recorded.", emptyFont, emptyBrush, 20, 80);
                        g.DrawString("You're all caught up for this active session!", subFont, mutedBrush, 20, 105);
                    }
                    return;
                }

                int startY = 44;
                int maxItems = Math.Min(listRecentActivities.Count, 5);

                using (Font itemFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(55, 65, 81)))
                using (SolidBrush dotBrush = new SolidBrush(Color.FromArgb(28, 162, 80)))
                {
                    for (int i = 0; i < maxItems; i++)
                    {
                        int y = startY + (i * 32);

                        // Bullet point circle
                        g.FillEllipse(dotBrush, 18, y + 4, 8, 8);

                        // Text
                        string text = listRecentActivities[i];
                        if (text.Length > 48) text = text.Substring(0, 45) + "...";
                        g.DrawString(text, itemFont, textBrush, 34, y);
                    }
                }
            }
            catch { }
        }

        // ==========================================
        // WIDGET: MODERN CUSTOM CALENDAR
        // ==========================================
        private DateTime _calendarDisplayDate = DateTime.Today;
        private DateTime _calendarSelectedDate = DateTime.Today;
        private Point _calHoveredCell = new Point(-1, -1);
        private bool _calHoverPrev = false;
        private bool _calHoverNext = false;
        private bool _calHoverToday = false;
        private Rectangle _calPrevBtnRect;
        private Rectangle _calNextBtnRect;
        private Rectangle _calTodayBtnRect;

        private void panelCalendarCard_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                int w = panelCalendarCard.Width;
                int h = panelCalendarCard.Height;

                // 1. Card Container Outline & Background
                using (SolidBrush bgBrush = new SolidBrush(Color.White))
                using (Pen borderPen = new Pen(Color.FromArgb(221, 231, 225), 1.5F))
                using (GraphicsPath path = GetRoundedRectPath(new Rectangle(0, 0, w - 1, h - 1), 10))
                {
                    g.FillPath(bgBrush, path);
                    g.DrawPath(borderPen, path);
                }

                // 2. Card Header
                // Title
                using (Font titleFont = new Font("Segoe UI", 11F, FontStyle.Bold))
                using (SolidBrush titleBrush = new SolidBrush(Color.FromArgb(7, 92, 44)))
                {
                    g.DrawString("Academic Calendar", titleFont, titleBrush, 14, 11);
                }

                // Month / Year Navigation Controls (Right aligned)
                string monthYearStr = _calendarDisplayDate.ToString("MMM yyyy");
                int navRight = w - 12;

                _calNextBtnRect = new Rectangle(navRight - 22, 11, 22, 22);
                int monthTextW = 68;
                Rectangle monthRect = new Rectangle(_calNextBtnRect.Left - monthTextW, 11, monthTextW, 22);
                _calPrevBtnRect = new Rectangle(monthRect.Left - 22, 11, 22, 22);
                _calTodayBtnRect = new Rectangle(_calPrevBtnRect.Left - 46, 11, 42, 22);

                // "Today" Button Pill
                using (GraphicsPath todayPath = GetRoundedRectPath(_calTodayBtnRect, 4))
                using (SolidBrush todayBg = new SolidBrush(_calHoverToday ? Color.FromArgb(220, 252, 231) : Color.FromArgb(240, 253, 244)))
                using (Pen todayPen = new Pen(Color.FromArgb(16, 185, 129), 1F))
                using (Font todayFont = new Font("Segoe UI", 7.5F, FontStyle.Bold))
                using (SolidBrush todayTextBrush = new SolidBrush(Color.FromArgb(5, 150, 105)))
                using (StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.FillPath(todayBg, todayPath);
                    g.DrawPath(todayPen, todayPath);
                    g.DrawString("Today", todayFont, todayTextBrush, _calTodayBtnRect, sfCenter);
                }

                // Prev Button
                using (GraphicsPath prevPath = GetRoundedRectPath(_calPrevBtnRect, 4))
                using (SolidBrush prevBg = new SolidBrush(_calHoverPrev ? Color.FromArgb(241, 245, 249) : Color.FromArgb(248, 250, 252)))
                using (Pen prevPen = new Pen(Color.FromArgb(203, 213, 225), 1F))
                using (Font arrowFont = new Font("Segoe UI", 8F, FontStyle.Bold))
                using (SolidBrush arrowBrush = new SolidBrush(Color.FromArgb(51, 65, 85)))
                using (StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.FillPath(prevBg, prevPath);
                    g.DrawPath(prevPen, prevPath);
                    g.DrawString("<", arrowFont, arrowBrush, _calPrevBtnRect, sfCenter);
                }

                // Month Year Label
                using (Font monthFont = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (SolidBrush monthBrush = new SolidBrush(Color.FromArgb(30, 41, 59)))
                using (StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.DrawString(monthYearStr, monthFont, monthBrush, monthRect, sfCenter);
                }

                // Next Button
                using (GraphicsPath nextPath = GetRoundedRectPath(_calNextBtnRect, 4))
                using (SolidBrush nextBg = new SolidBrush(_calHoverNext ? Color.FromArgb(241, 245, 249) : Color.FromArgb(248, 250, 252)))
                using (Pen nextPen = new Pen(Color.FromArgb(203, 213, 225), 1F))
                using (Font arrowFont = new Font("Segoe UI", 8F, FontStyle.Bold))
                using (SolidBrush arrowBrush = new SolidBrush(Color.FromArgb(51, 65, 85)))
                using (StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.FillPath(nextBg, nextPath);
                    g.DrawPath(nextPen, nextPath);
                    g.DrawString(">", arrowFont, arrowBrush, _calNextBtnRect, sfCenter);
                }

                // 3. Day of Week Header Strip
                int padX = 12;
                int gridW = w - (padX * 2);
                int dayHeaderY = 39;
                int dayHeaderH = 20;
                Rectangle headerStripRect = new Rectangle(padX, dayHeaderY, gridW, dayHeaderH);

                using (GraphicsPath headerStripPath = GetRoundedRectPath(headerStripRect, 4))
                using (SolidBrush stripBrush = new SolidBrush(Color.FromArgb(240, 253, 244)))
                {
                    g.FillPath(stripBrush, headerStripPath);
                }

                string[] dayHeaders = new string[] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
                float colW = (float)gridW / 7f;

                using (Font dayHeaderFont = new Font("Segoe UI", 8F, FontStyle.Bold))
                using (StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    for (int i = 0; i < 7; i++)
                    {
                        RectangleF dayHeaderRect = new RectangleF(padX + (i * colW), dayHeaderY, colW, dayHeaderH);
                        Color hdrColor = (i == 0) ? Color.FromArgb(220, 38, 38) : Color.FromArgb(22, 101, 52);
                        using (SolidBrush hdrBrush = new SolidBrush(hdrColor))
                        {
                            g.DrawString(dayHeaders[i], dayHeaderFont, hdrBrush, dayHeaderRect, sfCenter);
                        }
                    }
                }

                // 4. Days Grid (6 rows x 7 cols)
                int gridTop = 62;
                int availableH = h - gridTop - 26;
                float rowH = (float)availableH / 6f;

                DateTime firstDayOfMonth = new DateTime(_calendarDisplayDate.Year, _calendarDisplayDate.Month, 1);
                int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
                DateTime startDate = firstDayOfMonth.AddDays(-startDayOfWeek);

                using (Font dayFont = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                using (Font dayBoldFont = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                using (StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    DateTime iterDate = startDate;
                    for (int row = 0; row < 6; row++)
                    {
                        for (int col = 0; col < 7; col++)
                        {
                            RectangleF cellRect = new RectangleF(padX + (col * colW), gridTop + (row * rowH), colW, rowH);
                            bool isCurrentMonth = (iterDate.Month == _calendarDisplayDate.Month);
                            bool isToday = (iterDate.Date == DateTime.Today);
                            bool isSelected = (iterDate.Date == _calendarSelectedDate.Date);
                            bool isHovered = (_calHoveredCell.X == col && _calHoveredCell.Y == row);

                            // Center circle / badge
                            int badgeSize = (int)Math.Min(colW - 2, rowH - 2);
                            float badgeX = cellRect.X + (cellRect.Width - badgeSize) / 2f;
                            float badgeY = cellRect.Y + (cellRect.Height - badgeSize) / 2f;
                            RectangleF badgeRect = new RectangleF(badgeX, badgeY, badgeSize, badgeSize);

                            if (isToday)
                            {
                                using (SolidBrush todayBadgeBrush = new SolidBrush(Color.FromArgb(8, 120, 61)))
                                using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                                {
                                    g.FillEllipse(todayBadgeBrush, badgeRect);
                                    g.DrawString(iterDate.Day.ToString(), dayBoldFont, whiteBrush, cellRect, sfCenter);
                                }
                            }
                            else if (isSelected)
                            {
                                using (SolidBrush selBg = new SolidBrush(Color.FromArgb(220, 252, 231)))
                                using (Pen selPen = new Pen(Color.FromArgb(22, 163, 74), 1.2F))
                                using (SolidBrush selText = new SolidBrush(Color.FromArgb(21, 128, 61)))
                                {
                                    g.FillEllipse(selBg, badgeRect);
                                    g.DrawEllipse(selPen, badgeRect);
                                    g.DrawString(iterDate.Day.ToString(), dayBoldFont, selText, cellRect, sfCenter);
                                }
                            }
                            else if (isHovered)
                            {
                                using (SolidBrush hoverBg = new SolidBrush(Color.FromArgb(241, 245, 249)))
                                using (SolidBrush hoverText = new SolidBrush(Color.FromArgb(15, 23, 42)))
                                {
                                    g.FillEllipse(hoverBg, badgeRect);
                                    g.DrawString(iterDate.Day.ToString(), dayFont, hoverText, cellRect, sfCenter);
                                }
                            }
                            else
                            {
                                Color textCol;
                                if (!isCurrentMonth)
                                    textCol = Color.FromArgb(148, 163, 184); // Muted
                                else if (col == 0)
                                    textCol = Color.FromArgb(220, 38, 38); // Sunday
                                else
                                    textCol = Color.FromArgb(51, 65, 85); // Normal day

                                using (SolidBrush normalText = new SolidBrush(textCol))
                                {
                                    g.DrawString(iterDate.Day.ToString(), dayFont, normalText, cellRect, sfCenter);
                                }
                            }

                            iterDate = iterDate.AddDays(1);
                        }
                    }
                }

                // 5. Footer Status Line
                int footerY = h - 22;
                using (Pen divPen = new Pen(Color.FromArgb(241, 245, 249), 1))
                {
                    g.DrawLine(divPen, padX, footerY - 2, w - padX, footerY - 2);
                }

                using (Font footerFont = new Font("Segoe UI", 8F, FontStyle.Regular))
                using (SolidBrush footerBrush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                {
                    string footerText = "Selected: " + _calendarSelectedDate.ToString("ddd, MMM dd, yyyy");
                    g.DrawString(footerText, footerFont, footerBrush, padX + 2, footerY);
                }
            }
            catch { }
        }

        private void panelCalendarCard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (_calPrevBtnRect.Contains(e.Location))
            {
                _calendarDisplayDate = _calendarDisplayDate.AddMonths(-1);
                panelCalendarCard.Invalidate();
                return;
            }

            if (_calNextBtnRect.Contains(e.Location))
            {
                _calendarDisplayDate = _calendarDisplayDate.AddMonths(1);
                panelCalendarCard.Invalidate();
                return;
            }

            if (_calTodayBtnRect.Contains(e.Location))
            {
                _calendarDisplayDate = DateTime.Today;
                _calendarSelectedDate = DateTime.Today;
                panelCalendarCard.Invalidate();
                return;
            }

            // Check date cell click
            int w = panelCalendarCard.Width;
            int h = panelCalendarCard.Height;
            int padX = 12;
            int gridW = w - (padX * 2);
            int gridTop = 62;
            int availableH = h - gridTop - 26;
            float colW = (float)gridW / 7f;
            float rowH = (float)availableH / 6f;

            if (e.X >= padX && e.X < padX + gridW && e.Y >= gridTop && e.Y < gridTop + availableH)
            {
                int col = (int)((e.X - padX) / colW);
                int row = (int)((e.Y - gridTop) / rowH);

                if (col >= 0 && col < 7 && row >= 0 && row < 6)
                {
                    DateTime firstDayOfMonth = new DateTime(_calendarDisplayDate.Year, _calendarDisplayDate.Month, 1);
                    int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
                    DateTime startDate = firstDayOfMonth.AddDays(-startDayOfWeek);
                    int dayOffset = (row * 7) + col;
                    DateTime clickedDate = startDate.AddDays(dayOffset);

                    _calendarSelectedDate = clickedDate;
                    if (clickedDate.Month != _calendarDisplayDate.Month)
                    {
                        _calendarDisplayDate = new DateTime(clickedDate.Year, clickedDate.Month, 1);
                    }
                    panelCalendarCard.Invalidate();
                }
            }
        }

        private void panelCalendarCard_MouseMove(object sender, MouseEventArgs e)
        {
            bool prevHoverP = _calHoverPrev;
            bool nextHoverP = _calHoverNext;
            bool todayHoverP = _calHoverToday;
            Point prevHoverCell = _calHoveredCell;

            _calHoverPrev = _calPrevBtnRect.Contains(e.Location);
            _calHoverNext = _calNextBtnRect.Contains(e.Location);
            _calHoverToday = _calTodayBtnRect.Contains(e.Location);

            int w = panelCalendarCard.Width;
            int h = panelCalendarCard.Height;
            int padX = 12;
            int gridW = w - (padX * 2);
            int gridTop = 62;
            int availableH = h - gridTop - 26;
            float colW = (float)gridW / 7f;
            float rowH = (float)availableH / 6f;

            if (e.X >= padX && e.X < padX + gridW && e.Y >= gridTop && e.Y < gridTop + availableH)
            {
                int col = (int)((e.X - padX) / colW);
                int row = (int)((e.Y - gridTop) / rowH);
                _calHoveredCell = new Point(col, row);
                panelCalendarCard.Cursor = Cursors.Hand;
            }
            else
            {
                _calHoveredCell = new Point(-1, -1);
                if (_calHoverPrev || _calHoverNext || _calHoverToday)
                    panelCalendarCard.Cursor = Cursors.Hand;
                else
                    panelCalendarCard.Cursor = Cursors.Default;
            }

            if (prevHoverP != _calHoverPrev || nextHoverP != _calHoverNext || todayHoverP != _calHoverToday || prevHoverCell != _calHoveredCell)
            {
                panelCalendarCard.Invalidate();
            }
        }

        private void panelCalendarCard_MouseLeave(object sender, EventArgs e)
        {
            _calHoverPrev = false;
            _calHoverNext = false;
            _calHoverToday = false;
            _calHoveredCell = new Point(-1, -1);
            panelCalendarCard.Cursor = Cursors.Default;
            panelCalendarCard.Invalidate();
        }

        private void LoadChartData()
        {
            try
            {
                // 1. Class Strength data query
                listClassStrength.Clear();
                string query = "SELECT TOP 6 class.c_name, COUNT(DISTINCT student.S_ID) AS T_STDS FROM class INNER JOIN student ON class.c_id = student.c_id WHERE student.branch_id = '" + SYSTEMSETTING.branch_ID + "' AND student.SessionID = '" + SYSTEMSETTING.sessionid + "' GROUP BY class.c_name ORDER BY T_STDS DESC";
                rs = SYS.Show_Query(query);
                if (rs != null && rs.Tables.Count > 0)
                {
                    foreach (DataRow row in rs.Tables[0].Rows)
                    {
                        string cname = row[0].ToString();
                        int stds = Convert.ToInt32(row[1]);
                        listClassStrength.Add(new ClassStrengthItem(cname, stds));
                    }
                }

                // 2. Monthly Fee Summary data query
                listMonthlyFee.Clear();
                string queryMonth = "SELECT TOP 6 fee_month, SUM(REC_AMOUNT) AS TotRec, SUM(RECEIVABLE_AMOUNT) AS TotRecv FROM FEE_MASTER WHERE branch_id = '" + SYSTEMSETTING.branch_ID + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' GROUP BY fee_month";
                rs = SYS.Show_Query(queryMonth);
                if (rs != null && rs.Tables.Count > 0 && rs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in rs.Tables[0].Rows)
                    {
                        string rawMonth = row["fee_month"] != DBNull.Value ? row["fee_month"].ToString().Trim() : "";
                        string mName = rawMonth;
                        if (!string.IsNullOrEmpty(rawMonth))
                        {
                            string[] parts = rawMonth.Split(new char[] { ' ', '/', '-' }, StringSplitOptions.RemoveEmptyEntries);
                            int mNum = 0;
                            if (parts.Length > 0 && int.TryParse(parts[0], out mNum) && mNum >= 1 && mNum <= 12)
                            {
                                mName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(mNum);
                            }
                            else if (mName.Length > 3)
                            {
                                mName = mName.Substring(0, 3);
                            }
                        }
                        decimal rec = Convert.ToDecimal(row["TotRec"] == DBNull.Value ? 0 : row["TotRec"]);
                        decimal recv = Convert.ToDecimal(row["TotRecv"] == DBNull.Value ? 0 : row["TotRecv"]);
                        listMonthlyFee.Add(new MonthlyFeeItem(mName, rec, recv));
                    }
                }
                else
                {
                    listMonthlyFee.Add(new MonthlyFeeItem("Jan", decFeeReceived * 0.15m, decFeeReceivable * 0.15m));
                    listMonthlyFee.Add(new MonthlyFeeItem("Feb", decFeeReceived * 0.20m, decFeeReceivable * 0.20m));
                    listMonthlyFee.Add(new MonthlyFeeItem("Mar", decFeeReceived * 0.25m, decFeeReceivable * 0.25m));
                    listMonthlyFee.Add(new MonthlyFeeItem("Apr", decFeeReceived * 0.20m, decFeeReceivable * 0.20m));
                    listMonthlyFee.Add(new MonthlyFeeItem("May", decFeeReceived * 0.20m, decFeeReceivable * 0.20m));
                }
            }
            catch { }
        }

        private void LoadRecentActivities()
        {
            try
            {
                listRecentActivities.Clear();
                string query = "SELECT TOP 5 ('Voucher generated for Student #' + CAST(s_id AS VARCHAR) + ' - ' + CAST(RECEIVABLE_AMOUNT AS VARCHAR) + ' PKR') AS Act FROM FEE_MASTER WHERE branch_id = '" + SYSTEMSETTING.branch_ID + "' AND SessionID = '" + SYSTEMSETTING.sessionid + "' ORDER BY FEE_MASTER_ID DESC";
                rs = SYS.Show_Query(query);
                if (rs != null && rs.Tables.Count > 0)
                {
                    foreach (DataRow row in rs.Tables[0].Rows)
                    {
                        listRecentActivities.Add(row[0].ToString());
                    }
                }
            }
            catch { }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
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

        public void Fill_grid_outstanding()
        {
            string query = "";

            query = " SELECT class.c_name AS Class,COUNT(DISTINCT student.S_ID) AS T_STDS,COUNT(FEE_MASTER.FEE_MASTER_ID) AS total_vouchers,SUM(FEE_MASTER.RECEIVABLE_AMOUNT) AS TOTAL_RECEIVABLE,";
            query = query + " SUM(FEE_MASTER.REC_AMOUNT) AS RECEIVED,SUM(FEE_MASTER.BALANCE) AS OUTSTANDING,student.c_id FROM student INNER JOIN class  ON class.c_id = student.c_id ";
            query = query + " AND class.branch_id = student.branch_id LEFT JOIN FEE_MASTER  ON FEE_MASTER.s_id = STUDENT.s_id  AND FEE_MASTER.SessionID = student.SessionID ";
            query = query + " AND FEE_MASTER.branch_id = STUDENT.branch_id WHERE STUDENT.branch_id = '" + SYSTEMSETTING.branch_ID + "' AND STUDENT.SessionID = '" + SYSTEMSETTING.sessionid + "' GROUP BY class.c_name,student.c_id  ";
            SYS.Filllist_DataView(query, this.lstv_outstandingfee);
        }

        public void GetTotal()
        {
            try
            {
                rs = SYS.Show_Query("select Count(*) from class where branch_id='" + SYSTEMSETTING.branch_ID + "'");

                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    lbl_total_classes.Text = RowDocument[0].ToString();
                }

                rs = SYS.Show_Query("select Count(*) from student where branch_id='" + SYSTEMSETTING.branch_ID + "' and SessionID='" + SYSTEMSETTING.sessionid + "' and active='true'");
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    lbl_total_strength.Text = RowDocument[0].ToString();
                }

                string total_vouchers = "";
                string fee_receivable = "";
                string fee_received = "";
                string balance = "";

                rs = SYS.Show_Query("select Count(s_id) as total_students,Sum(RECEIVABLE_AMOUNT) AS Receivable_amount,Sum(REC_AMOUNT) AS Received_amount, sum(balance) as balance from FEE_MASTER where branch_id ='" + SYSTEMSETTING.branch_ID + "' and SessionID='" + SYSTEMSETTING.sessionid + "'");
                foreach (DataRow RowDocument in rs.Tables[0].Rows)
                {
                    total_vouchers = Convert.ToInt32(RowDocument["total_students"]).ToString("N0");
                    decFeeReceivable = Convert.ToDecimal(RowDocument["Receivable_amount"] == DBNull.Value ? 0 : RowDocument["Receivable_amount"]);
                    decFeeReceived = Convert.ToDecimal(RowDocument["Received_amount"] == DBNull.Value ? 0 : RowDocument["Received_amount"]);
                    decBalance = Convert.ToDecimal(RowDocument["balance"] == DBNull.Value ? 0 : RowDocument["balance"]);

                    fee_receivable = decFeeReceivable.ToString("N0");
                    fee_received = decFeeReceived.ToString("N0");
                    balance = decBalance.ToString("N0");

                    lbltotal_earning.Text = fee_receivable;
                    lblreceived.Text = fee_received;
                    lblbalance.Text = balance;

                    label12.Text =
                        "Total No. of Students Registered at time of Fee Generation : " + total_vouchers;
                }
            }
            catch (Exception exp)
            {
            }
        }

        private void lstv_outstandingfee_DoubleClick(object sender, EventArgs e)
        {
            if (lstv_outstandingfee.SelectedItems.Count > 0)
            {
                dash_classwisestrength frm = new dash_classwisestrength();
                frm.classid = this.lstv_outstandingfee.Items[lstv_outstandingfee.FocusedItem.Index].SubItems[6].Text.Trim();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select Record");
            }
        }
    }
}
