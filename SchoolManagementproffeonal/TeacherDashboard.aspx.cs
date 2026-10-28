using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeacherDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Teacher");
        BindUserChrome();
        if (!IsPostBack) LoadTeacherInfo();
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadTeacherInfo()
    {
        int? teacherId = AuthHelper.GetTeacherIdForUser();
        if (teacherId == null)
        {
            litTeacherName.Text = AuthHelper.Username;
            litClassCount.Text = litStudentCount.Text = litExamCount.Text = "0";
            litContact.Text = "Profile not linked";
            return;
        }

        DataTable t = DbHelper.ExecuteTable("SELECT Name, Contact FROM Teachers WHERE TeacherID=@ID", DbHelper.P("@ID", teacherId.Value));
        if (t.Rows.Count > 0)
        {
            litTeacherName.Text = Server.HtmlEncode(Convert.ToString(t.Rows[0]["Name"]));
            litContact.Text = Server.HtmlEncode(Convert.ToString(t.Rows[0]["Contact"]));
        }

        DataTable classes = DbHelper.ExecuteTable(@"
            SELECT c.ClassName, c.Section,
                   (SELECT COUNT(*) FROM Students s WHERE s.ClassID = c.ClassID) AS StudentCount
            FROM Classes c WHERE c.TeacherID=@TID ORDER BY c.ClassName", DbHelper.P("@TID", teacherId.Value));
        gvClasses.DataSource = classes;
        gvClasses.DataBind();
        litClassCount.Text = classes.Rows.Count.ToString();
        int students = 0;
        foreach (DataRow r in classes.Rows) students += Convert.ToInt32(r["StudentCount"]);
        litStudentCount.Text = students.ToString();
        object exams = DbHelper.ExecuteScalar("SELECT COUNT(*) FROM Exams WHERE Date >= CAST(GETDATE() AS date)");
        litExamCount.Text = Convert.ToInt32(exams ?? 0).ToString();
    }
}
