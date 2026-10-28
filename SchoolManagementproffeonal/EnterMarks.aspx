<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnterMarks.aspx.cs" Inherits="EnterMarks" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Enter Marks · School Management</title>
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
                <li><a href="EnterMarks.aspx" class="active">Enter Marks</a></li>
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
                <span class="eyebrow">Assessment</span>
                <h1>Enter exam marks</h1>
                <p class="subtitle">Choose an exam and fill in marks for each student in that class.</p>
            </div>
        </div>
        <div class="card">
            <div class="form-grid">
                <div class="field">
                    <label>Exam</label>
                    <asp:DropDownList ID="ddlExam" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlExam_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="table-wrap">
                <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="false" CssClass="data-table"
                    GridLines="None" DataKeyNames="StudentID">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Student" />
                        <asp:TemplateField HeaderText="Marks obtained">
                            <ItemTemplate>
                                <asp:TextBox ID="txtMarks" runat="server" CssClass="form-control" placeholder="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate><div class="empty-state">Select an exam to load students.</div></EmptyDataTemplate>
                </asp:GridView>
            </div>
            <div class="form-actions mt-4">
                <asp:Button ID="btnSave" runat="server" Text="Save marks" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            </div>
            <asp:Label ID="lblMessage" runat="server" CssClass="msg msg-info"></asp:Label>
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
