using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClassTimetable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Teacher", "Admin");
        BindUserChrome();
        if (!IsPostBack) LoadClasses();
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
        int? teacherId = AuthHelper.GetTeacherIdForUser();
        if (teacherId == null && AuthHelper.Role == "Teacher")
        {
            gvClasses.DataSource = null; gvClasses.DataBind(); return;
        }
        string filter = teacherId != null ? " WHERE c.TeacherID = " + teacherId.Value : "";
        gvClasses.DataSource = DbHelper.ExecuteTable(@"
            SELECT c.ClassName, c.Section,
                   (SELECT COUNT(*) FROM Students s WHERE s.ClassID = c.ClassID) AS StudentCount,
                   ISNULL((SELECT STUFF((SELECT ', ' + sub.SubjectName FROM Subjects sub WHERE sub.ClassID = c.ClassID FOR XML PATH(''), TYPE).value('.','nvarchar(max)'),1,2,'')), '—') AS SubjectList
            FROM Classes c" + filter + " ORDER BY c.ClassName");
        gvClasses.DataBind();
    }
}
