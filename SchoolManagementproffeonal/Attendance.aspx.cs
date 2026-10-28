using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Attendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Teacher", "Admin");
        BindUserChrome();
        if (!IsPostBack)
        {
            LoadClasses();
            txtDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
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
        int? teacherId = AuthHelper.GetTeacherIdForUser();
        string sql = "SELECT ClassID, ClassName + ISNULL(' - ' + Section,'') AS ClassName FROM Classes ORDER BY ClassName";
        if (AuthHelper.Role == "Teacher" && teacherId != null)
            sql = "SELECT ClassID, ClassName + ISNULL(' - ' + Section,'') AS ClassName FROM Classes WHERE TeacherID=" + teacherId.Value + " ORDER BY ClassName";
        DbHelper.BindDropDown(ddlClass, sql, "ClassName", "ClassID", "— Select class —");
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e) { LoadStudents(); }
    private void LoadStudents()
    {
        if (string.IsNullOrEmpty(ddlClass.SelectedValue)) { gvStudents.DataSource = null; gvStudents.DataBind(); return; }
        gvStudents.DataSource = DbHelper.ExecuteTable(
            "SELECT StudentID, Name FROM Students WHERE ClassID=@C ORDER BY Name",
            DbHelper.P("@C", Convert.ToInt32(ddlClass.SelectedValue)));
        gvStudents.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime date;
        if (string.IsNullOrEmpty(ddlClass.SelectedValue) || !DateTime.TryParse(txtDate.Text, out date))
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Select a class and valid date."; return; }

        int saved = 0;
        foreach (GridViewRow row in gvStudents.Rows)
        {
            int studentId = Convert.ToInt32(gvStudents.DataKeys[row.RowIndex].Value);
            DropDownList ddl = (DropDownList)row.FindControl("ddlStatus");
            string status = ddl != null ? ddl.SelectedValue : "Present";
            // Avoid duplicates for same day: delete then insert
            DbHelper.ExecuteNonQuery("DELETE FROM Attendance WHERE StudentID=@S AND AttendanceDate=@D",
                DbHelper.P("@S", studentId), DbHelper.P("@D", date.Date));
            try
            {
                DbHelper.ExecuteNonQuery(
                    "INSERT INTO Attendance (StudentID, AttendanceDate, Status) VALUES (@S,@D,@St)",
                    DbHelper.P("@S", studentId), DbHelper.P("@D", date.Date), DbHelper.P("@St", status));
            }
            catch
            {
                DbHelper.ExecuteNonQuery(
                    "INSERT INTO Attendance (StudentID, Date, Status) VALUES (@S,@D,@St)",
                    DbHelper.P("@S", studentId), DbHelper.P("@D", date.Date), DbHelper.P("@St", status));
            }
            saved++;
        }
        lblMessage.CssClass = "msg msg-success";
        lblMessage.Text = "Attendance saved for " + saved + " student(s).";
    }
}
