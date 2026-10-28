using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageSubjects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack)
        {
            LoadClasses();
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

    private void LoadClasses()
    {
        DbHelper.BindDropDown(ddlClass,
            "SELECT ClassID, ClassName + ISNULL(' - ' + Section,'') AS ClassName FROM Classes ORDER BY ClassName",
            "ClassName", "ClassID", "— Select class —");
    }

    private void LoadList()
    {
        gvList.DataSource = DbHelper.ExecuteTable(@"
            SELECT sub.SubjectID, sub.SubjectName,
                   c.ClassName + ISNULL(' - ' + c.Section,'') AS ClassName
            FROM Subjects sub
            JOIN Classes c ON sub.ClassID = c.ClassID
            ORDER BY c.ClassName, sub.SubjectName");
        gvList.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtSubjectName.Text) || string.IsNullOrEmpty(ddlClass.SelectedValue))
        {
            lblMessage.CssClass = "msg msg-error";
            lblMessage.Text = "Subject name and class are required.";
            return;
        }

        int rows = DbHelper.ExecuteNonQuery(
            "INSERT INTO Subjects (SubjectName, ClassID) VALUES (@SubjectName, @ClassID)",
            DbHelper.P("@SubjectName", txtSubjectName.Text.Trim()),
            DbHelper.P("@ClassID", Convert.ToInt32(ddlClass.SelectedValue)));

        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Subject saved successfully." : "Could not save subject.";
        if (rows > 0) { ClearForm(); LoadList(); }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
        lblMessage.Text = string.Empty;
    }

    private void ClearForm()
    {
        txtSubjectName.Text = string.Empty;
        if (ddlClass.Items.Count > 0) ddlClass.SelectedIndex = 0;
    }

    protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            DbHelper.ExecuteNonQuery("DELETE FROM Subjects WHERE SubjectID=@ID", DbHelper.P("@ID", Convert.ToInt32(e.CommandArgument)));
            LoadList();
            lblMessage.CssClass = "msg msg-success";
            lblMessage.Text = "Subject deleted.";
        }
    }
}
