<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="School Management System" />
    <title>User Accounts · School Management</title>
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

    <nav class="topbar" aria-label="Main">
        <div class="topbar-inner">
            <a class="brand" href="Dashboard.aspx"><span class="brand-mark">SM</span> School Management</a>
            <ul class="nav-links">
                <li><a href="Dashboard.aspx">Dashboard</a></li>
                <li><a href="ManageStudents.aspx">Students</a></li>
                <li><a href="ManageTeachers.aspx">Teachers</a></li>
                <li><a href="ManageParents.aspx">Parents</a></li>
                <li><a href="ManageClasses.aspx">Classes</a></li>
                <li><a href="ManageSubjects.aspx">Subjects</a></li>
                <li><a href="Fees.aspx">Fees</a></li>
                <li><a href="Exam.aspx">Exams</a></li>
                <li><a href="ManageResults.aspx">Results</a></li>
                <li><a href="ManageLibrary.aspx">Library</a></li>
                <li><a href="ManageTransport.aspx">Transport</a></li>
                <li><a href="Register.aspx" class="active">Accounts</a></li>
            </ul>
            <div class="topbar-meta">
                <div class="user-chip">
                    <span class="avatar"><asp:Literal ID="litUserInitial" runat="server" Text="U" /></span>
                    <span>
                        <asp:Literal ID="litUsername" runat="server" Text="User" />
                        <span class="role-tag"> · <asp:Literal ID="litUserRole" runat="server" Text="Admin" /></span>
                    </span>
                </div>
                <a class="btn-logout" href="Logout.aspx">Logout</a>
            </div>
        </div>
    </nav>

    <div class="page">
        <div class="page-header">
            <div class="header-text">
                <span class="eyebrow">Accounts</span>
                <h1>Create a login account</h1>
                <p class="subtitle">Provision portal access for admins, teachers, students, and parents.</p>
            </div>
        </div>
        <div class="panel-grid">
            <div class="card">
                <div class="section-title">New account</div>
                <div class="form-grid">
                    <div class="field">
                        <label>Username</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="e.g. bilal.ahmed"></asp:TextBox>
                    </div>
                    <div class="field">
                        <label>Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="field">
                        <label>Confirm password</label>
                        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="field">
                        <label>Role</label>
                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Admin" Value="Admin" />
                            <asp:ListItem Text="Teacher" Value="Teacher" />
                            <asp:ListItem Text="Student" Value="Student" />
                            <asp:ListItem Text="Parent" Value="Parent" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:Button ID="btnRegister" runat="server" Text="Create account" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
                </div>
                <asp:Label ID="lblMessage" runat="server" CssClass="msg msg-info"></asp:Label>
                <p class="help-text">
                    After creating a Teacher / Student / Parent account, open the matching profile page
                    and link this account so the user only sees their own data when they sign in.
                </p>
            </div>
            <div class="card">
                <div class="section-title">Existing accounts</div>
                <div class="table-wrap">
                    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" CssClass="data-table"
                        GridLines="None" DataKeyNames="UserID" OnRowCommand="gvUsers_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="UserID" HeaderText="ID" />
                            <asp:BoundField DataField="Username" HeaderText="Username" />
                            <asp:TemplateField HeaderText="Role">
                                <ItemTemplate><span class="badge badge-muted"><%# Eval("Role") %></span></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDel" runat="server" CommandName="DeleteRow"
                                        CommandArgument='<%# Eval("UserID") %>' CssClass="link-btn"
                                        OnClientClick="return confirm('Delete this account?');">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div class="empty-state">No user accounts yet.</div></EmptyDataTemplate>
                    </asp:GridView>
                </div>
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
