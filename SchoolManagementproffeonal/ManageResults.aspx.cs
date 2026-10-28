using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageResults : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack) { LoadStudents(); LoadExams(); LoadResults(); }
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadStudents()
    {
        DbHelper.BindDropDown(ddlStudent, "SELECT StudentID, Name FROM Students ORDER BY Name", "Name", "StudentID", "— Select student —");
    }
    private void LoadExams()
    {
        DbHelper.BindDropDown(ddlExam, @"
            SELECT e.ExamID, sub.SubjectName + ' — ' + CONVERT(varchar(10), e.Date, 23) + ' (' + CAST(e.MaxMarks as varchar) + ')' AS Label
            FROM Exams e JOIN Subjects sub ON e.SubjectID = sub.SubjectID
            ORDER BY e.Date DESC", "Label", "ExamID", "— Select exam —");
    }
    private void LoadResults()
    {
        gvResults.DataSource = DbHelper.ExecuteTable(@"
            SELECT s.Name AS StudentName, sub.SubjectName, e.Date, r.MarksObtained, e.MaxMarks,
                CASE
                  WHEN e.MaxMarks = 0 THEN '—'
                  WHEN r.MarksObtained * 100.0 / e.MaxMarks >= 90 THEN 'A+'
                  WHEN r.MarksObtained * 100.0 / e.MaxMarks >= 80 THEN 'A'
                  WHEN r.MarksObtained * 100.0 / e.MaxMarks >= 70 THEN 'B'
                  WHEN r.MarksObtained * 100.0 / e.MaxMarks >= 60 THEN 'C'
                  WHEN r.MarksObtained * 100.0 / e.MaxMarks >= 50 THEN 'D'
                  ELSE 'F' END AS Grade
            FROM Results r
            JOIN Students s ON r.StudentID = s.StudentID
            JOIN Exams e ON r.ExamID = e.ExamID
            JOIN Subjects sub ON e.SubjectID = sub.SubjectID
            ORDER BY e.Date DESC");
        gvResults.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ddlStudent.SelectedValue) || string.IsNullOrEmpty(ddlExam.SelectedValue))
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Select student and exam."; return; }
        decimal marks;
        if (!decimal.TryParse(txtMarks.Text, out marks))
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Enter valid marks."; return; }
        int rows = DbHelper.ExecuteNonQuery(
            "INSERT INTO Results (StudentID, ExamID, MarksObtained) VALUES (@S,@E,@M)",
            DbHelper.P("@S", Convert.ToInt32(ddlStudent.SelectedValue)),
            DbHelper.P("@E", Convert.ToInt32(ddlExam.SelectedValue)),
            DbHelper.P("@M", marks));
        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Result saved." : "Could not save result.";
        if (rows > 0) { txtMarks.Text = ""; LoadResults(); }
    }
}
