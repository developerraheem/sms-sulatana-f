<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attendance.aspx.cs" Inherits="Attendance" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Mark Attendance · School Management</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <nav class="topbar" aria-label="Main">
        <div class="topbar-inner">
            <a class="brand" href="TeacherDashboard.aspx"><span class="brand-mark">SM</span> School Management</a>
            <ul class="nav-links">
                <li><a href="TeacherDashboard.aspx">Dashboard</a></li>
                <li><a href="Attendance.aspx" class="active">Attendance</a></li>
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
                <span class="eyebrow">Attendance</span>
                <h1>Mark today's attendance</h1>
                <p class="subtitle">Select a class and set each student as Present or Absent.</p>
            </div>
        </div>
        <div class="card">
            <div class="form-grid">
                <div class="field">
                    <label>Class</label>
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="field">
                    <label>Date</label>
                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <div class="table-wrap">
                <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="false" CssClass="data-table"
                    GridLines="None" DataKeyNames="StudentID">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Student" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Present" Value="Present" />
                                    <asp:ListItem Text="Absent" Value="Absent" />
                                    <asp:ListItem Text="Late" Value="Late" />
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate><div class="empty-state">Select a class to load students.</div></EmptyDataTemplate>
                </asp:GridView>
            </div>
            <div class="form-actions mt-4">
                <asp:Button ID="btnSave" runat="server" Text="Save attendance" CssClass="btn btn-primary" OnClick="btnSave_Click" />
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
