using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageClasses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack)
        {
            LoadTeachers();
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

    private void LoadTeachers()
    {
        DbHelper.BindDropDown(ddlTeacher, "SELECT TeacherID, Name FROM Teachers ORDER BY Name", "Name", "TeacherID", "— Select teacher —");
    }

    private void LoadList()
    {
        gvList.DataSource = DbHelper.ExecuteTable(@"
            SELECT c.ClassID, c.ClassName, c.Section,
                   ISNULL(t.Name,'—') AS TeacherName,
                   (SELECT COUNT(*) FROM Students s WHERE s.ClassID = c.ClassID) AS StudentCount
            FROM Classes c
            LEFT JOIN Teachers t ON c.TeacherID = t.TeacherID
            ORDER BY c.ClassName, c.Section");
        gvList.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtClassName.Text) || string.IsNullOrEmpty(ddlTeacher.SelectedValue))
        {
            lblMessage.CssClass = "msg msg-error";
            lblMessage.Text = "Class name and teacher are required.";
            return;
        }

        int rows = DbHelper.ExecuteNonQuery(
            "INSERT INTO Classes (ClassName, Section, TeacherID) VALUES (@ClassName, @Section, @TeacherID)",
            DbHelper.P("@ClassName", txtClassName.Text.Trim()),
            DbHelper.P("@Section", txtSection.Text.Trim()),
            DbHelper.P("@TeacherID", Convert.ToInt32(ddlTeacher.SelectedValue)));

        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Class saved successfully." : "Could not save class.";
        if (rows > 0) { ClearForm(); LoadList(); }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
        lblMessage.Text = string.Empty;
    }

    private void ClearForm()
    {
        txtClassName.Text = txtSection.Text = string.Empty;
        if (ddlTeacher.Items.Count > 0) ddlTeacher.SelectedIndex = 0;
    }

    protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            DbHelper.ExecuteNonQuery("DELETE FROM Classes WHERE ClassID=@ID", DbHelper.P("@ID", Convert.ToInt32(e.CommandArgument)));
            LoadList();
            lblMessage.CssClass = "msg msg-success";
            lblMessage.Text = "Class deleted.";
        }
    }
}
