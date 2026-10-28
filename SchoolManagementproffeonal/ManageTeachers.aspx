<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageTeachers.aspx.cs" Inherits="ManageTeachers" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="School Management System" />
    <title>Manage Teachers · School Management</title>
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
                <li><a href="ManageTeachers.aspx" class="active">Teachers</a></li>
                <li><a href="ManageParents.aspx">Parents</a></li>
                <li><a href="ManageClasses.aspx">Classes</a></li>
                <li><a href="ManageSubjects.aspx">Subjects</a></li>
                <li><a href="Fees.aspx">Fees</a></li>
                <li><a href="Exam.aspx">Exams</a></li>
                <li><a href="ManageResults.aspx">Results</a></li>
                <li><a href="ManageLibrary.aspx">Library</a></li>
                <li><a href="ManageTransport.aspx">Transport</a></li>
                <li><a href="Register.aspx">Accounts</a></li>
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
                <span class="eyebrow">Faculty</span>
                <h1>Manage teachers</h1>
                <p class="subtitle">Add faculty members and optionally link them to a login account (User ID).</p>
            </div>
        </div>
        <div class="panel-grid">
            <div class="card">
                <div class="section-title">Teacher profile</div>
                <div class="form-grid">
                    <div class="field">
                        <label>Full name</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="e.g. Bilal Ahmed"></asp:TextBox>
                    </div>
                    <div class="field">
                        <label>Monthly salary</label>
                        <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="e.g. 45000"></asp:TextBox>
                    </div>
                    <div class="field">
                        <label>Contact number</label>
                        <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="03xx-xxxxxxx"></asp:TextBox>
                    </div>
                    <div class="field">
                        <label>Linked user account (optional)</label>
                        <asp:DropDownList ID="ddlUser" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:Button ID="btnSave" runat="server" Text="Save teacher" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-ghost" OnClick="btnClear_Click" CausesValidation="false" />
                </div>
                <asp:Label ID="lblMessage" runat="server" CssClass="msg msg-info"></asp:Label>
            </div>
            <div class="card">
                <div class="section-title">All teachers</div>
                <div class="table-wrap">
                    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="data-table"
                        GridLines="None" DataKeyNames="TeacherID" OnRowCommand="gvList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="TeacherID" HeaderText="ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Contact" HeaderText="Contact" />
                            <asp:BoundField DataField="Salary" HeaderText="Salary" DataFormatString="{0:N0}" />
                            <asp:BoundField DataField="Username" HeaderText="Login" />
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDel" runat="server" CommandName="DeleteRow"
                                        CommandArgument='<%# Eval("TeacherID") %>' CssClass="link-btn"
                                        OnClientClick="return confirm('Delete this teacher?');">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div class="empty-state">No teachers yet.</div></EmptyDataTemplate>
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
