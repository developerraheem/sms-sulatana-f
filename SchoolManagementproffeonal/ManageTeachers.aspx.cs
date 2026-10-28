using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageTeachers : System.Web.UI.Page
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
            "SELECT UserID, Username FROM Users WHERE Role='Teacher' ORDER BY Username",
            "Username", "UserID", "— No linked account —");
    }

    private void LoadList()
    {
        gvList.DataSource = DbHelper.ExecuteTable(@"
            SELECT t.TeacherID, t.Name, t.Contact, t.Salary, ISNULL(u.Username, '—') AS Username
            FROM Teachers t
            LEFT JOIN Users u ON t.UserID = u.UserID
            ORDER BY t.Name");
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

        decimal salary;
        if (!decimal.TryParse(txtSalary.Text, out salary))
        {
            lblMessage.CssClass = "msg msg-error";
            lblMessage.Text = "Enter a valid salary amount.";
            return;
        }

        object userId = string.IsNullOrEmpty(ddlUser.SelectedValue) ? (object)DBNull.Value : (object)Convert.ToInt32(ddlUser.SelectedValue);

        int rows = DbHelper.ExecuteNonQuery(
            "INSERT INTO Teachers (Name, Salary, Contact, UserID) VALUES (@Name, @Salary, @Contact, @UserID)",
            DbHelper.P("@Name", txtName.Text.Trim()),
            DbHelper.P("@Salary", salary),
            DbHelper.P("@Contact", txtContact.Text.Trim()),
            DbHelper.P("@UserID", userId));

        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Teacher saved successfully." : "Could not save teacher.";
        if (rows > 0) { ClearForm(); LoadList(); }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
        lblMessage.Text = string.Empty;
    }

    private void ClearForm()
    {
        txtName.Text = txtSalary.Text = txtContact.Text = string.Empty;
        if (ddlUser.Items.Count > 0) ddlUser.SelectedIndex = 0;
    }

    protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            DbHelper.ExecuteNonQuery("DELETE FROM Teachers WHERE TeacherID=@ID", DbHelper.P("@ID", Convert.ToInt32(e.CommandArgument)));
            LoadList();
            lblMessage.CssClass = "msg msg-success";
            lblMessage.Text = "Teacher deleted.";
        }
    }
}
