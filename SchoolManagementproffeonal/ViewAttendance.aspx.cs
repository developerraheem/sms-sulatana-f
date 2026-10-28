using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Student");
        BindUserChrome();
        if (!IsPostBack) LoadAttendance();
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadAttendance()
    {
        int? sid = AuthHelper.GetStudentIdForUser();
        if (sid == null) return;
        try
        {
            gvAttendance.DataSource = DbHelper.ExecuteTable(
                "SELECT AttendanceDate, Status FROM Attendance WHERE StudentID=@ID ORDER BY AttendanceDate DESC",
                DbHelper.P("@ID", sid.Value));
        }
        catch
        {
            gvAttendance.DataSource = DbHelper.ExecuteTable(
                "SELECT Date AS AttendanceDate, Status FROM Attendance WHERE StudentID=@ID ORDER BY Date DESC",
                DbHelper.P("@ID", sid.Value));
        }
        gvAttendance.DataBind();
    }
}
