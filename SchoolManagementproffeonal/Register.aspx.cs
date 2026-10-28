using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack) LoadUsers();
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadUsers()
    {
        gvUsers.DataSource = DbHelper.ExecuteTable("SELECT UserID, Username, Role FROM Users ORDER BY Role, Username");
        gvUsers.DataBind();
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string user = (txtUsername.Text ?? "").Trim();
        string pass = txtPassword.Text ?? "";
        string conf = txtConfirm.Text ?? "";
        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Username and password are required."; return; }
        if (pass != conf)
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Passwords do not match."; return; }
        if (pass.Length < 4)
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Password must be at least 4 characters."; return; }

        object exists = DbHelper.ExecuteScalar("SELECT COUNT(*) FROM Users WHERE Username=@U", DbHelper.P("@U", user));
        if (Convert.ToInt32(exists) > 0)
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="That username is already taken."; return; }

        int rows = DbHelper.ExecuteNonQuery(
            "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@U,@P,@R)",
            DbHelper.P("@U", user), DbHelper.P("@P", pass), DbHelper.P("@R", ddlRole.SelectedValue));
        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Account created successfully." : "Could not create account.";
        if (rows > 0) { txtUsername.Text = txtPassword.Text = txtConfirm.Text = ""; LoadUsers(); }
    }
    protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (id == AuthHelper.UserId)
            { lblMessage.CssClass="msg msg-error"; lblMessage.Text="You cannot delete your own account while signed in."; return; }
            DbHelper.ExecuteNonQuery("DELETE FROM Users WHERE UserID=@ID", DbHelper.P("@ID", id));
            LoadUsers();
            lblMessage.CssClass="msg msg-success"; lblMessage.Text="Account deleted.";
        }
    }
}
