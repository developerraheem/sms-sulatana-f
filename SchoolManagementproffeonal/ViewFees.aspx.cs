using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewFees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Student");
        BindUserChrome();
        if (!IsPostBack) LoadFees();
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadFees()
    {
        int? sid = AuthHelper.GetStudentIdForUser();
        if (sid == null) return;
        gvFees.DataSource = DbHelper.ExecuteTable(
            "SELECT Amount, DueDate, PaidStatus FROM Fees WHERE StudentID=@ID ORDER BY DueDate DESC",
            DbHelper.P("@ID", sid.Value));
        gvFees.DataBind();
    }
}
