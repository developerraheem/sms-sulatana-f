using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack) { LoadSubjects(); LoadExams(); }
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadSubjects()
    {
        DbHelper.BindDropDown(ddlSubject, @"
            SELECT sub.SubjectID, sub.SubjectName + ' (' + c.ClassName + ISNULL(' - ' + c.Section,'') + ')' AS SubjectName
            FROM Subjects sub JOIN Classes c ON sub.ClassID = c.ClassID
            ORDER BY c.ClassName, sub.SubjectName", "SubjectName", "SubjectID", "— Select subject —");
    }
    private void LoadExams()
    {
        gvExams.DataSource = DbHelper.ExecuteTable(@"
            SELECT e.ExamID, sub.SubjectName, c.ClassName + ISNULL(' - ' + c.Section,'') AS ClassName, e.Date, e.MaxMarks
            FROM Exams e
            JOIN Subjects sub ON e.SubjectID = sub.SubjectID
            JOIN Classes c ON sub.ClassID = c.ClassID
            ORDER BY e.Date DESC");
        gvExams.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ddlSubject.SelectedValue)) { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Select a subject."; return; }
        DateTime dt; int max;
        if (!DateTime.TryParse(txtDate.Text, out dt) || !int.TryParse(txtMaxMarks.Text, out max))
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Enter a valid date and max marks."; return; }
        int rows = DbHelper.ExecuteNonQuery(
            "INSERT INTO Exams (SubjectID, Date, MaxMarks) VALUES (@S,@D,@M)",
            DbHelper.P("@S", Convert.ToInt32(ddlSubject.SelectedValue)),
            DbHelper.P("@D", dt), DbHelper.P("@M", max));
        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Exam scheduled." : "Could not schedule exam.";
        if (rows > 0) { txtDate.Text = txtMaxMarks.Text = ""; LoadExams(); }
    }
    protected void gvExams_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            DbHelper.ExecuteNonQuery("DELETE FROM Exams WHERE ExamID=@ID", DbHelper.P("@ID", Convert.ToInt32(e.CommandArgument)));
            LoadExams();
            lblMessage.CssClass="msg msg-success"; lblMessage.Text="Exam deleted.";
        }
    }
}
