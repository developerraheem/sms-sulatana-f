using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChildAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Parent");
        BindUserChrome();
        if (!IsPostBack) { LoadChildren(); LoadAttendance(); }
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadChildren()
    {
        int? pid = AuthHelper.GetParentIdForUser();
        if (pid == null) return;
        DbHelper.BindDropDown(ddlChild, "SELECT StudentID, Name FROM Students WHERE ParentID=@P ORDER BY Name",
            "Name", "StudentID", null);
        // re-bind without empty
        ddlChild.DataSource = DbHelper.ExecuteTable("SELECT StudentID, Name FROM Students WHERE ParentID=@P ORDER BY Name", DbHelper.P("@P", pid.Value));
        ddlChild.DataTextField = "Name"; ddlChild.DataValueField = "StudentID"; ddlChild.DataBind();
    }
    protected void ddlChild_SelectedIndexChanged(object sender, EventArgs e) { LoadAttendance(); }
    private void LoadAttendance()
    {
        if (string.IsNullOrEmpty(ddlChild.SelectedValue)) return;
        int sid = Convert.ToInt32(ddlChild.SelectedValue);
        try
        {
            gvAttendance.DataSource = DbHelper.ExecuteTable(
                "SELECT AttendanceDate, Status FROM Attendance WHERE StudentID=@ID ORDER BY AttendanceDate DESC", DbHelper.P("@ID", sid));
        }
        catch
        {
            gvAttendance.DataSource = DbHelper.ExecuteTable(
                "SELECT Date AS AttendanceDate, Status FROM Attendance WHERE StudentID=@ID ORDER BY Date DESC", DbHelper.P("@ID", sid));
        }
        gvAttendance.DataBind();
    }
}
