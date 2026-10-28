<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ParentDashboard.aspx.cs" Inherits="ParentDashboard" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Parent Dashboard · School Management</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <nav class="topbar" aria-label="Main">
        <div class="topbar-inner">
            <a class="brand" href="ParentDashboard.aspx"><span class="brand-mark">SM</span> School Management</a>
            <ul class="nav-links">
                <li><a href="ParentDashboard.aspx" class="active">Dashboard</a></li>
                <li><a href="ChildAttendance.aspx">Attendance</a></li>
                <li><a href="ChildResults.aspx">Results</a></li>
                <li><a href="ChildFees.aspx">Fees</a></li>
            </ul>
            <div class="topbar-meta">
                <div class="user-chip">
                    <span class="avatar"><asp:Literal ID="litUserInitial" runat="server" Text="U" /></span>
                    <span>
                        <asp:Literal ID="litUsername" runat="server" Text="User" />
                        <span class="role-tag"> · <asp:Literal ID="litUserRole" runat="server" Text="Parent" /></span>
                    </span>
                </div>
                <a class="btn-logout" href="Logout.aspx">Logout</a>
            </div>
        </div>
    </nav>

    <div class="page">
        <div class="page-header">
            <div class="header-text">
                <span class="eyebrow">Parent portal</span>
                <h1>Welcome, <asp:Literal ID="litParentName" runat="server" Text="Parent" /></h1>
                <p class="subtitle">Monitor your children's attendance, results, and fee status.</p>
            </div>
        </div>
        <div class="card">
            <div class="section-title">Your children</div>
            <div class="table-wrap">
                <asp:GridView ID="gvChildren" runat="server" AutoGenerateColumns="false" CssClass="data-table" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Student" />
                        <asp:BoundField DataField="ClassName" HeaderText="Class" />
                        <asp:BoundField DataField="Contact" HeaderText="Contact" />
                    </Columns>
                    <EmptyDataTemplate><div class="empty-state">No children linked to this parent account yet.</div></EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
        <div class="card">
            <div class="section-title">Quick links</div>
            <div class="tile-grid">
                <a class="tile" href="ChildAttendance.aspx"><span class="tile-icon">AT</span><strong>Attendance</strong><span>Daily log for each child</span></a>
                <a class="tile" href="ChildResults.aspx"><span class="tile-icon">RS</span><strong>Results</strong><span>Exam performance</span></a>
                <a class="tile" href="ChildFees.aspx"><span class="tile-icon">FE</span><strong>Fees</strong><span>Pending and paid invoices</span></a>
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
