<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentDashboard.aspx.cs" Inherits="StudentDashboard" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Student Dashboard · School Management</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <nav class="topbar" aria-label="Main">
        <div class="topbar-inner">
            <a class="brand" href="StudentDashboard.aspx"><span class="brand-mark">SM</span> School Management</a>
            <ul class="nav-links">
                <li><a href="StudentDashboard.aspx" class="active">Dashboard</a></li>
                <li><a href="ViewAttendance.aspx">Attendance</a></li>
                <li><a href="ViewResults.aspx">Results</a></li>
                <li><a href="ViewFees.aspx">Fees</a></li>
                <li><a href="LibraryBooks.aspx">Library</a></li>
                <li><a href="TransportInfo.aspx">Transport</a></li>
            </ul>
            <div class="topbar-meta">
                <div class="user-chip">
                    <span class="avatar"><asp:Literal ID="litUserInitial" runat="server" Text="U" /></span>
                    <span>
                        <asp:Literal ID="litUsername" runat="server" Text="User" />
                        <span class="role-tag"> · <asp:Literal ID="litUserRole" runat="server" Text="Student" /></span>
                    </span>
                </div>
                <a class="btn-logout" href="Logout.aspx">Logout</a>
            </div>
        </div>
    </nav>

    <div class="page">
        <div class="page-header">
            <div class="header-text">
                <span class="eyebrow">Student portal</span>
                <h1>Hello, <asp:Literal ID="litStudentName" runat="server" Text="Student" /></h1>
                <p class="subtitle">Your attendance, results, fees, and campus services in one place.</p>
            </div>
        </div>
        <div class="stat-row">
            <div class="stat-card">
                <div class="stat-top"><span class="stat-tab">Class</span></div>
                <div class="stat-value" style="font-size:1.25rem;"><asp:Literal ID="litClass" runat="server">—</asp:Literal></div>
                <div class="stat-foot">Current enrollment</div>
            </div>
            <div class="stat-card">
                <div class="stat-top"><span class="stat-tab">Attendance</span></div>
                <div class="stat-value"><asp:Literal ID="litAttendance" runat="server">—</asp:Literal></div>
                <div class="stat-foot">Present rate</div>
            </div>
            <div class="stat-card">
                <div class="stat-top"><span class="stat-tab">Results</span></div>
                <div class="stat-value"><asp:Literal ID="litResultCount" runat="server">0</asp:Literal></div>
                <div class="stat-foot">Published scores</div>
            </div>
            <div class="stat-card">
                <div class="stat-top"><span class="stat-tab">Fees due</span></div>
                <div class="stat-value" style="font-size:1.2rem;"><asp:Literal ID="litFeesDue" runat="server">Rs. 0</asp:Literal></div>
                <div class="stat-foot">Pending balance</div>
            </div>
        </div>
        <div class="card">
            <div class="section-title">Quick links</div>
            <div class="tile-grid">
                <a class="tile" href="ViewAttendance.aspx"><span class="tile-icon">AT</span><strong>Attendance</strong><span>Daily present / absent log</span></a>
                <a class="tile" href="ViewResults.aspx"><span class="tile-icon">RS</span><strong>Results</strong><span>Exam marks and grades</span></a>
                <a class="tile" href="ViewFees.aspx"><span class="tile-icon">FE</span><strong>Fees</strong><span>Invoices and payment status</span></a>
                <a class="tile" href="LibraryBooks.aspx"><span class="tile-icon">LB</span><strong>Library</strong><span>Books issued to you</span></a>
                <a class="tile" href="TransportInfo.aspx"><span class="tile-icon">TR</span><strong>Transport</strong><span>Your bus route details</span></a>
            </div>
        </div>
    </div>

    <footer class="site-footer">
        <div class="site-footer-inner">
            <div><strong>School Management System</strong> — academic operations console</div>
            <div>Secure role-based access · Admin · Teacher · Student · Parent</div>
        </div>
    </footer>
    </form>

</body>
</html>
