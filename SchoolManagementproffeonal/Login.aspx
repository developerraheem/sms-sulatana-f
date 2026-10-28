<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="School Management System" />
    <title>Sign in · School Management</title>
    <link href="Content/style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">


    <div class="auth-shell">
        <div class="auth-card">
            <div class="brand-mark">SM</div>
            <h1>School Management</h1>
            <p>Sign in with your campus account</p>

            <div class="field">
                <label>I am signing in as</label>
                <asp:RadioButtonList ID="rblRole" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="role-list">
                    <asp:ListItem Text="Admin" Value="Admin" Selected="True" />
                    <asp:ListItem Text="Teacher" Value="Teacher" />
                    <asp:ListItem Text="Student" Value="Student" />
                    <asp:ListItem Text="Parent" Value="Parent" />
                </asp:RadioButtonList>
            </div>

            <div class="field">
                <label for="txtUsername">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter username" autocomplete="username"></asp:TextBox>
            </div>
            <div class="field">
                <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter password" autocomplete="current-password"></asp:TextBox>
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Sign in" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="msg msg-error"></asp:Label>

            <div class="auth-footer">
                Authorized personnel only. Contact the school office if you need an account.
            </div>
        </div>
    </div>


    </form>

</body>
</html>
