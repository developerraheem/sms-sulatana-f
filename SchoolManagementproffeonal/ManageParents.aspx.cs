using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageParents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack)
        {
            LoadUsers();
            LoadList();
        }
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
        DbHelper.BindDropDown(ddlUser,
            "SELECT UserID, Username FROM Users WHERE Role='Parent' ORDER BY Username",
            "Username", "UserID", "— No linked account —");
    }

    private void LoadList()
    {
        // Graceful query: Email/UserID may be null if columns missing — use ISNULL on optional fields when present.
        try
        {
            gvList.DataSource = DbHelper.ExecuteTable(@"
                SELECT p.ParentID, p.Name, ISNULL(p.Contact,'—') AS Contact,
                       ISNULL(p.Email,'—') AS Email,
                       ISNULL(u.Username,'—') AS Username,
                       (SELECT COUNT(*) FROM Students s WHERE s.ParentID = p.ParentID) AS ChildCount
                FROM Parents p
                LEFT JOIN Users u ON p.UserID = u.UserID
                ORDER BY p.Name");
        }
        catch
        {
            // Fallback for minimal Parents(Name, Contact) schema
            gvList.DataSource = DbHelper.ExecuteTable(@"
                SELECT p.ParentID, p.Name, ISNULL(p.Contact,'—') AS Contact,
                       '—' AS Email, '—' AS Username,
                       (SELECT COUNT(*) FROM Students s WHERE s.ParentID = p.ParentID) AS ChildCount
                FROM Parents p
                ORDER BY p.Name");
        }
        gvList.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMessage.CssClass = "msg msg-info";
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            lblMessage.CssClass = "msg msg-error";
            lblMessage.Text = "Name is required.";
            return;
        }

        object userId = string.IsNullOrEmpty(ddlUser.SelectedValue) ? (object)DBNull.Value : (object)Convert.ToInt32(ddlUser.SelectedValue);

        int rows = 0;
        try
        {
            rows = DbHelper.ExecuteNonQuery(
                "INSERT INTO Parents (Name, Contact, Email, Address, UserID) VALUES (@Name,@Contact,@Email,@Address,@UserID)",
                DbHelper.P("@Name", txtName.Text.Trim()),
                DbHelper.P("@Contact", txtContact.Text.Trim()),
                DbHelper.P("@Email", txtEmail.Text.Trim()),
                DbHelper.P("@Address", txtAddress.Text.Trim()),
                DbHelper.P("@UserID", userId));
        }
        catch
        {
            rows = DbHelper.ExecuteNonQuery(
                "INSERT INTO Parents (Name, Contact) VALUES (@Name,@Contact)",
                DbHelper.P("@Name", txtName.Text.Trim()),
                DbHelper.P("@Contact", txtContact.Text.Trim()));
        }

        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Parent saved successfully." : "Could not save parent.";
        if (rows > 0) { ClearForm(); LoadList(); }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
        lblMessage.Text = string.Empty;
    }

    private void ClearForm()
    {
        txtName.Text = txtContact.Text = txtEmail.Text = txtAddress.Text = string.Empty;
        if (ddlUser.Items.Count > 0) ddlUser.SelectedIndex = 0;
    }

    protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            DbHelper.ExecuteNonQuery("DELETE FROM Parents WHERE ParentID=@ID", DbHelper.P("@ID", Convert.ToInt32(e.CommandArgument)));
            LoadList();
            lblMessage.CssClass = "msg msg-success";
            lblMessage.Text = "Parent deleted.";
        }
    }
}
