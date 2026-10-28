<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherDashboard.aspx.cs" Inherits="TeacherDashboard" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Teacher Dashboard · School Management</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <nav class="topbar" aria-label="Main">
        <div class="topbar-inner">
            <a class="brand" href="TeacherDashboard.aspx"><span class="brand-mark">SM</span> School Management</a>
            <ul class="nav-links">
                <li><a href="TeacherDashboard.aspx" class="active">Dashboard</a></li>
                <li><a href="Attendance.aspx">Attendance</a></li>
                <li><a href="EnterMarks.aspx">Enter Marks</a></li>
                <li><a href="ClassTimetable.aspx">My Classes</a></li>
            </ul>
            <div class="topbar-meta">
                <div class="user-chip">
                    <span class="avatar"><asp:Literal ID="litUserInitial" runat="server" Text="U" /></span>
                    <span>
                        <asp:Literal ID="litUsername" runat="server" Text="User" />
                        <span class="role-tag"> · <asp:Literal ID="litUserRole" runat="server" Text="Teacher" /></span>
                    </span>
                </div>
                <a class="btn-logout" href="Logout.aspx">Logout</a>
            </div>
        </div>
    </nav>

    <div class="page">
        <div class="page-header">
            <div class="header-text">
                <span class="eyebrow">Teacher portal</span>
                <h1>Welcome, <asp:Literal ID="litTeacherName" runat="server" Text="Teacher" /></h1>
                <p class="subtitle">Mark attendance, enter exam scores, and review your assigned classes.</p>
            </div>
        </div>
        <div class="stat-row">
            <div class="stat-card">
                <div class="stat-top"><span class="stat-tab">My classes</span></div>
                <div class="stat-value"><asp:Literal ID="litClassCount" runat="server">0</asp:Literal></div>
                <div class="stat-foot">Assigned as class teacher</div>
            </div>
            <div class="stat-card">
                <div class="stat-top"><span class="stat-tab">Students</span></div>
                <div class="stat-value"><asp:Literal ID="litStudentCount" runat="server">0</asp:Literal></div>
                <div class="stat-foot">Across your classes</div>
            </div>
            <div class="stat-card">
                <div class="stat-top"><span class="stat-tab">Upcoming exams</span></div>
                <div class="stat-value"><asp:Literal ID="litExamCount" runat="server">0</asp:Literal></div>
                <div class="stat-foot">Scheduled sittings</div>
            </div>
            <div class="stat-card">
                <div class="stat-top"><span class="stat-tab">Contact</span></div>
                <div class="stat-value" style="font-size:1.1rem;"><asp:Literal ID="litContact" runat="server">—</asp:Literal></div>
                <div class="stat-foot">On file</div>
            </div>
        </div>
        <div class="card">
            <div class="section-title">Quick actions</div>
            <div class="tile-grid">
                <a class="tile" href="Attendance.aspx"><span class="tile-icon">AT</span><strong>Mark attendance</strong><span>Record present / absent for a class</span></a>
                <a class="tile" href="EnterMarks.aspx"><span class="tile-icon">MK</span><strong>Enter marks</strong><span>Capture exam scores for students</span></a>
                <a class="tile" href="ClassTimetable.aspx"><span class="tile-icon">CL</span><strong>My classes</strong><span>See assigned sections and headcount</span></a>
            </div>
        </div>
        <div class="card">
            <div class="section-title">Your classes</div>
            <div class="table-wrap">
                <asp:GridView ID="gvClasses" runat="server" AutoGenerateColumns="false" CssClass="data-table" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="ClassName" HeaderText="Class" />
                        <asp:BoundField DataField="Section" HeaderText="Section" />
                        <asp:BoundField DataField="StudentCount" HeaderText="Students" />
                    </Columns>
                    <EmptyDataTemplate><div class="empty-state">You are not assigned as class teacher yet. Ask admin to link your profile.</div></EmptyDataTemplate>
                </asp:GridView>
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
