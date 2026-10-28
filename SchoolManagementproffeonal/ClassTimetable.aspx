<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassTimetable.aspx.cs" Inherits="ClassTimetable" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>My Classes · School Management</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <nav class="topbar" aria-label="Main">
        <div class="topbar-inner">
            <a class="brand" href="TeacherDashboard.aspx"><span class="brand-mark">SM</span> School Management</a>
            <ul class="nav-links">
                <li><a href="TeacherDashboard.aspx">Dashboard</a></li>
                <li><a href="Attendance.aspx">Attendance</a></li>
                <li><a href="EnterMarks.aspx">Enter Marks</a></li>
                <li><a href="ClassTimetable.aspx" class="active">My Classes</a></li>
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
                <span class="eyebrow">Overview</span>
                <h1>Your classes & subjects</h1>
                <p class="subtitle">Sections where you are the assigned class teacher.</p>
            </div>
        </div>
        <div class="card">
            <div class="section-title">Assigned as class teacher</div>
            <div class="table-wrap">
                <asp:GridView ID="gvClasses" runat="server" AutoGenerateColumns="false" CssClass="data-table" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="ClassName" HeaderText="Class" />
                        <asp:BoundField DataField="Section" HeaderText="Section" />
                        <asp:BoundField DataField="StudentCount" HeaderText="Students" />
                        <asp:BoundField DataField="SubjectList" HeaderText="Subjects" />
                    </Columns>
                    <EmptyDataTemplate><div class="empty-state">You are not assigned to any class yet.</div></EmptyDataTemplate>
                </asp:GridView>
            </div>
            <p class="help-text">
                A full period timetable can be added later with a <span class="kbd">Timetable</span> table
                (Day, Period, ClassID, SubjectID, TeacherID).
            </p>
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
