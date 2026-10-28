<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageLibrary.aspx.cs" Inherits="ManageLibrary" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="School Management System" />
    <title>Manage Library · School Management</title>
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
                <li><a href="ManageLibrary.aspx" class="active">Library</a></li>
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
                <span class="eyebrow">Library</span>
                <h1>Book issue desk</h1>
                <p class="subtitle">Issue books to students and mark returns.</p>
            </div>
        </div>
        <div class="panel-grid">
            <div class="card">
                <div class="section-title">Issue a book</div>
                <div class="field mb-3">
                    <label>Student</label>
                    <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="field mb-3">
                    <label>Book title</label>
                    <asp:TextBox ID="txtBook" runat="server" CssClass="form-control" placeholder="e.g. Introduction to Physics"></asp:TextBox>
                </div>
                <div class="field mb-3">
                    <label>Issue date</label>
                    <asp:TextBox ID="txtIssueDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="field mb-3">
                    <label>Return date (optional)</label>
                    <asp:TextBox ID="txtReturnDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="form-actions">
                    <asp:Button ID="btnSave" runat="server" Text="Issue book" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                </div>
                <asp:Label ID="lblMessage" runat="server" CssClass="msg msg-info"></asp:Label>
            </div>
            <div class="card">
                <div class="section-title">Issued books</div>
                <div class="table-wrap">
                    <asp:GridView ID="gvLibrary" runat="server" AutoGenerateColumns="false" CssClass="data-table"
                        GridLines="None" OnRowCommand="gvLibrary_RowCommand" DataKeyNames="LibraryID">
                        <Columns>
                            <asp:BoundField DataField="StudentName" HeaderText="Student" />
                            <asp:BoundField DataField="BookName" HeaderText="Book" />
                            <asp:BoundField DataField="IssueDate" HeaderText="Issued" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="ReturnDate" HeaderText="Returned" DataFormatString="{0:d}" />
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <span class='<%# Eval("ReturnDate") == DBNull.Value ? "badge badge-warning" : "badge badge-success" %>'>
                                        <%# Eval("ReturnDate") == DBNull.Value ? "Out" : "Returned" %>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRet" runat="server" CommandName="MarkReturned" CommandArgument='<%# Eval("LibraryID") %>'
                                        CssClass="link-btn" Visible='<%# Eval("ReturnDate") == DBNull.Value %>'>Mark returned</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div class="empty-state">No library records yet.</div></EmptyDataTemplate>
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
