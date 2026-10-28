<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChildResults.aspx.cs" Inherits="ChildResults" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Child Results · School Management</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <nav class="topbar" aria-label="Main">
        <div class="topbar-inner">
            <a class="brand" href="ParentDashboard.aspx"><span class="brand-mark">SM</span> School Management</a>
            <ul class="nav-links">
                <li><a href="ParentDashboard.aspx">Dashboard</a></li>
                <li><a href="ChildAttendance.aspx">Attendance</a></li>
                <li><a href="ChildResults.aspx" class="active">Results</a></li>
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
                <span class="eyebrow">Results</span>
                <h1>Child exam results</h1>
            </div>
        </div>
        <div class="card">
            <div class="field mb-3" style="max-width:320px;">
                <label>Child</label>
                <asp:DropDownList ID="ddlChild" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlChild_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="table-wrap">
                <asp:GridView ID="gvResults" runat="server" AutoGenerateColumns="false" CssClass="data-table" GridLines="None">
                    <Columns>

                        <asp:BoundField DataField="SubjectName" HeaderText="Subject" />
                        <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="MarksObtained" HeaderText="Marks" />
                        <asp:BoundField DataField="MaxMarks" HeaderText="Out of" />
                        <asp:TemplateField HeaderText="Grade">
                            <ItemTemplate><span class="badge badge-accent"><%# Eval("Grade") %></span></ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <EmptyDataTemplate><div class="empty-state">No records for this child.</div></EmptyDataTemplate>
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
