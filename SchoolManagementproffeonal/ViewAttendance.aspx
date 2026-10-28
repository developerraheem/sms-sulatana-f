<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAttendance.aspx.cs" Inherits="ViewAttendance" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>My Attendance · School Management</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <nav class="topbar" aria-label="Main">
        <div class="topbar-inner">
            <a class="brand" href="StudentDashboard.aspx"><span class="brand-mark">SM</span> School Management</a>
            <ul class="nav-links">
                <li><a href="StudentDashboard.aspx">Dashboard</a></li>
                <li><a href="ViewAttendance.aspx" class="active">Attendance</a></li>
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
                <span class="eyebrow">Attendance</span>
                <h1>Attendance history</h1>
            </div>
        </div>
        <div class="card">
            <div class="table-wrap">
                <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="false" CssClass="data-table" GridLines="None">
                    <Columns>

                        <asp:BoundField DataField="AttendanceDate" HeaderText="Date" DataFormatString="{0:d}" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <span class='<%# Eval("Status").ToString()=="Present"?"badge badge-success":(Eval("Status").ToString()=="Late"?"badge badge-warning":"badge badge-danger") %>'><%# Eval("Status") %></span>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <EmptyDataTemplate><div class="empty-state">No records found.</div></EmptyDataTemplate>
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
