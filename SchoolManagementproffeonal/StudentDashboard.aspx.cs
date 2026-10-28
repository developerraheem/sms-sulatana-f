using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Student");
        BindUserChrome();
        if (!IsPostBack) LoadOverview();
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadOverview()
    {
        int? sid = AuthHelper.GetStudentIdForUser();
        if (sid == null)
        {
            litStudentName.Text = AuthHelper.Username;
            litClass.Text = "Not linked";
            litAttendance.Text = "—";
            litResultCount.Text = "0";
            litFeesDue.Text = "Rs. 0";
            return;
        }
        DataTable st = DbHelper.ExecuteTable(@"
            SELECT s.Name, ISNULL(c.ClassName,'—') + ISNULL(' - ' + c.Section,'') AS ClassName
            FROM Students s LEFT JOIN Classes c ON s.ClassID = c.ClassID
            WHERE s.StudentID=@ID", DbHelper.P("@ID", sid.Value));
        if (st.Rows.Count > 0)
        {
            litStudentName.Text = Server.HtmlEncode(Convert.ToString(st.Rows[0]["Name"]));
            litClass.Text = Server.HtmlEncode(Convert.ToString(st.Rows[0]["ClassName"]));
        }

        object total = null, present = null;
        try
        {
            total = DbHelper.ExecuteScalar("SELECT COUNT(*) FROM Attendance WHERE StudentID=@ID", DbHelper.P("@ID", sid.Value));
            present = DbHelper.ExecuteScalar("SELECT COUNT(*) FROM Attendance WHERE StudentID=@ID AND Status='Present'", DbHelper.P("@ID", sid.Value));
        }
        catch { }
        int t = Convert.ToInt32(total ?? 0);
        int p = Convert.ToInt32(present ?? 0);
        litAttendance.Text = t == 0 ? "—" : ((p * 100) / t).ToString() + "%";

        object rc = DbHelper.ExecuteScalar("SELECT COUNT(*) FROM Results WHERE StudentID=@ID", DbHelper.P("@ID", sid.Value));
        litResultCount.Text = Convert.ToInt32(rc ?? 0).ToString();

        object due = DbHelper.ExecuteScalar("SELECT SUM(Amount) FROM Fees WHERE StudentID=@ID AND PaidStatus='Pending'", DbHelper.P("@ID", sid.Value));
        decimal d = (due != null && due != DBNull.Value) ? Convert.ToDecimal(due) : 0m;
        litFeesDue.Text = "Rs. " + d.ToString("N0", CultureInfo.InvariantCulture);
    }
}
