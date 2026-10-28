using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ParentDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Parent");
        BindUserChrome();
        if (!IsPostBack) LoadChildren();
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
        litParentName.Text = Server.HtmlEncode(AuthHelper.Username);
        if (pid == null) return;
        try
        {
            object n = DbHelper.ExecuteScalar("SELECT Name FROM Parents WHERE ParentID=@ID", DbHelper.P("@ID", pid.Value));
            if (n != null) litParentName.Text = Server.HtmlEncode(Convert.ToString(n));
        }
        catch { }
        gvChildren.DataSource = DbHelper.ExecuteTable(@"
            SELECT s.Name, ISNULL(c.ClassName,'—') + ISNULL(' - ' + c.Section,'') AS ClassName, ISNULL(s.Contact,'—') AS Contact
            FROM Students s LEFT JOIN Classes c ON s.ClassID = c.ClassID
            WHERE s.ParentID=@PID ORDER BY s.Name", DbHelper.P("@PID", pid.Value));
        gvChildren.DataBind();
    }
}
