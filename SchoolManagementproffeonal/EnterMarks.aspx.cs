using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EnterMarks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Teacher", "Admin");
        BindUserChrome();
        if (!IsPostBack) LoadExams();
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadExams()
    {
        DbHelper.BindDropDown(ddlExam, @"
            SELECT e.ExamID,
                   sub.SubjectName + ' — ' + c.ClassName + ' — ' + CONVERT(varchar(10), e.Date, 23) + ' (/' + CAST(e.MaxMarks as varchar) + ')' AS Label
            FROM Exams e
            JOIN Subjects sub ON e.SubjectID = sub.SubjectID
            JOIN Classes c ON sub.ClassID = c.ClassID
            ORDER BY e.Date DESC", "Label", "ExamID", "— Select exam —");
    }
    protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e) { LoadStudents(); }
    private void LoadStudents()
    {
        if (string.IsNullOrEmpty(ddlExam.SelectedValue)) { gvStudents.DataSource=null; gvStudents.DataBind(); return; }
        gvStudents.DataSource = DbHelper.ExecuteTable(@"
            SELECT s.StudentID, s.Name
            FROM Students s
            JOIN Subjects sub ON s.ClassID = sub.ClassID
            JOIN Exams e ON e.SubjectID = sub.SubjectID
            WHERE e.ExamID=@E
            ORDER BY s.Name", DbHelper.P("@E", Convert.ToInt32(ddlExam.SelectedValue)));
        gvStudents.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ddlExam.SelectedValue))
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Select an exam first."; return; }
        int examId = Convert.ToInt32(ddlExam.SelectedValue);
        int saved = 0;
        foreach (GridViewRow row in gvStudents.Rows)
        {
            int studentId = Convert.ToInt32(gvStudents.DataKeys[row.RowIndex].Value);
            TextBox txt = (TextBox)row.FindControl("txtMarks");
            decimal marks;
            if (txt == null || string.IsNullOrWhiteSpace(txt.Text) || !decimal.TryParse(txt.Text, out marks))
                continue;
            DbHelper.ExecuteNonQuery("DELETE FROM Results WHERE StudentID=@S AND ExamID=@E",
                DbHelper.P("@S", studentId), DbHelper.P("@E", examId));
            DbHelper.ExecuteNonQuery(
                "INSERT INTO Results (StudentID, ExamID, MarksObtained) VALUES (@S,@E,@M)",
                DbHelper.P("@S", studentId), DbHelper.P("@E", examId), DbHelper.P("@M", marks));
            saved++;
        }
        lblMessage.CssClass = "msg msg-success";
        lblMessage.Text = "Saved marks for " + saved + " student(s).";
    }
}
