using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageStudents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack)
        {
            LoadLookups();
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

    private void LoadLookups()
    {
        DbHelper.BindDropDown(ddlClass, "SELECT ClassID, ClassName + ISNULL(' - ' + Section,'') AS ClassName FROM Classes ORDER BY ClassName", "ClassName", "ClassID", "— Select class —");
        DbHelper.BindDropDown(ddlParent, "SELECT ParentID, Name FROM Parents ORDER BY Name", "Name", "ParentID", "— Select parent —");
        DbHelper.BindDropDown(ddlUser, "SELECT UserID, Username FROM Users WHERE Role='Student' ORDER BY Username", "Username", "UserID", "— No linked account —");
    }

    private void LoadList()
    {
        gvList.DataSource = DbHelper.ExecuteTable(@"
            SELECT s.StudentID, s.Name, s.Contact,
                   ISNULL(c.ClassName,'—') AS ClassName,
                   ISNULL(p.Name,'—') AS ParentName,
                   ISNULL(u.Username,'—') AS Username
            FROM Students s
            LEFT JOIN Classes c ON s.ClassID = c.ClassID
            LEFT JOIN Parents p ON s.ParentID = p.ParentID
            LEFT JOIN Users u ON s.UserID = u.UserID
            ORDER BY s.Name");
        gvList.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMessage.CssClass = "msg msg-info";
        if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrEmpty(ddlClass.SelectedValue))
        {
            lblMessage.CssClass = "msg msg-error";
            lblMessage.Text = "Name and class are required.";
            return;
        }

        DateTime dob;
        object dobVal = DBNull.Value;
        if (!string.IsNullOrWhiteSpace(txtDOB.Text))
        {
            if (!DateTime.TryParse(txtDOB.Text, out dob))
            {
                lblMessage.CssClass = "msg msg-error";
                lblMessage.Text = "Enter a valid date of birth.";
                return;
            }
            dobVal = dob;
        }

        object parentId = string.IsNullOrEmpty(ddlParent.SelectedValue) ? (object)DBNull.Value : (object)Convert.ToInt32(ddlParent.SelectedValue);
        object userId = string.IsNullOrEmpty(ddlUser.SelectedValue) ? (object)DBNull.Value : (object)Convert.ToInt32(ddlUser.SelectedValue);

        int rows = DbHelper.ExecuteNonQuery(
            "INSERT INTO Students (Name, DOB, Address, Contact, ClassID, ParentID, UserID) VALUES (@Name,@DOB,@Address,@Contact,@ClassID,@ParentID,@UserID)",
            DbHelper.P("@Name", txtName.Text.Trim()),
            DbHelper.P("@DOB", dobVal),
            DbHelper.P("@Address", txtAddress.Text.Trim()),
            DbHelper.P("@Contact", txtContact.Text.Trim()),
            DbHelper.P("@ClassID", Convert.ToInt32(ddlClass.SelectedValue)),
            DbHelper.P("@ParentID", parentId),
            DbHelper.P("@UserID", userId));

        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Student saved successfully." : "Could not save student.";
        if (rows > 0) { ClearForm(); LoadList(); }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
        lblMessage.Text = string.Empty;
    }

    private void ClearForm()
    {
        txtName.Text = txtDOB.Text = txtAddress.Text = txtContact.Text = string.Empty;
        if (ddlClass.Items.Count > 0) ddlClass.SelectedIndex = 0;
        if (ddlParent.Items.Count > 0) ddlParent.SelectedIndex = 0;
        if (ddlUser.Items.Count > 0) ddlUser.SelectedIndex = 0;
    }

    protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            DbHelper.ExecuteNonQuery("DELETE FROM Students WHERE StudentID=@ID", DbHelper.P("@ID", Convert.ToInt32(e.CommandArgument)));
            LoadList();
            lblMessage.CssClass = "msg msg-success";
            lblMessage.Text = "Student deleted.";
        }
    }
}
