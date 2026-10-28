<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fees.aspx.cs" Inherits="Fees" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="School Management System" />
    <title>Fee Collection · School Management</title>
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
                <li><a href="Fees.aspx" class="active">Fees</a></li>
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
                <span class="eyebrow">Finance</span>
                <h1>Fee collection</h1>
                <p class="subtitle">Create fee invoices and mark payments as received.</p>
            </div>
        </div>
        <div class="panel-grid">
            <div class="card">
                <div class="section-title">Add a fee record</div>
                <div class="field mb-3">
                    <label>Student</label>
                    <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="field mb-3">
                    <label>Amount (Rs.)</label>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" placeholder="e.g. 5000"></asp:TextBox>
                </div>
                <div class="field mb-3">
                    <label>Due date</label>
                    <asp:TextBox ID="txtDueDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="field mb-3">
                    <label>Status</label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Pending" Value="Pending" />
                        <asp:ListItem Text="Paid" Value="Paid" />
                    </asp:DropDownList>
                </div>
                <div class="form-actions">
                    <asp:Button ID="btnSave" runat="server" Text="Save fee record" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                </div>
                <asp:Label ID="lblMessage" runat="server" CssClass="msg msg-info"></asp:Label>
            </div>
            <div class="card">
                <div class="section-title">All fee records</div>
                <div class="table-wrap">
                    <asp:GridView ID="gvFees" runat="server" AutoGenerateColumns="false" CssClass="data-table"
                        GridLines="None" OnRowCommand="gvFees_RowCommand" DataKeyNames="FeeID">
                        <Columns>
                            <asp:BoundField DataField="StudentName" HeaderText="Student" />
                            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:N0}" />
                            <asp:BoundField DataField="DueDate" HeaderText="Due date" DataFormatString="{0:d}" />
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <span class='<%# Eval("PaidStatus").ToString() == "Paid" ? "badge badge-success" : "badge badge-danger" %>'><%# Eval("PaidStatus") %></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPaid" runat="server" CommandName="MarkPaid" CommandArgument='<%# Eval("FeeID") %>'
                                        CssClass="link-btn" Visible='<%# Eval("PaidStatus").ToString() != "Paid" %>'>Mark paid</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div class="empty-state">No fee records yet.</div></EmptyDataTemplate>
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
