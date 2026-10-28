using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChildFees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Parent");
        BindUserChrome();
        if (!IsPostBack) { LoadChildren(); LoadFees(); }
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
        ddlChild.DataSource = DbHelper.ExecuteTable("SELECT StudentID, Name FROM Students WHERE ParentID=@P ORDER BY Name", DbHelper.P("@P", pid.Value));
        ddlChild.DataTextField = "Name"; ddlChild.DataValueField = "StudentID"; ddlChild.DataBind();
    }
    protected void ddlChild_SelectedIndexChanged(object sender, EventArgs e) { LoadFees(); }
    private void LoadFees()
    {
        if (string.IsNullOrEmpty(ddlChild.SelectedValue)) return;
        int sid = Convert.ToInt32(ddlChild.SelectedValue);
        gvFees.DataSource = DbHelper.ExecuteTable(
            "SELECT Amount, DueDate, PaidStatus FROM Fees WHERE StudentID=@ID ORDER BY DueDate DESC", DbHelper.P("@ID", sid));
        gvFees.DataBind();
    }
}
