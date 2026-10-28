using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewResults : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Student");
        BindUserChrome();
        if (!IsPostBack) LoadResults();
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadResults()
    {
        int? sid = AuthHelper.GetStudentIdForUser();
        if (sid == null) return;
        gvResults.DataSource = DbHelper.ExecuteTable(@"
            SELECT sub.SubjectName, e.Date, r.MarksObtained, e.MaxMarks,
              CASE WHEN e.MaxMarks=0 THEN '—'
                   WHEN r.MarksObtained*100.0/e.MaxMarks>=90 THEN 'A+'
                   WHEN r.MarksObtained*100.0/e.MaxMarks>=80 THEN 'A'
                   WHEN r.MarksObtained*100.0/e.MaxMarks>=70 THEN 'B'
                   WHEN r.MarksObtained*100.0/e.MaxMarks>=60 THEN 'C'
                   WHEN r.MarksObtained*100.0/e.MaxMarks>=50 THEN 'D'
                   ELSE 'F' END AS Grade
            FROM Results r
            JOIN Exams e ON r.ExamID=e.ExamID
            JOIN Subjects sub ON e.SubjectID=sub.SubjectID
            WHERE r.StudentID=@ID ORDER BY e.Date DESC", DbHelper.P("@ID", sid.Value));
        gvResults.DataBind();
    }
}
