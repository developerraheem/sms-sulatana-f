using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TransportInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Student");
        BindUserChrome();
        if (!IsPostBack) LoadTransport();
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadTransport()
    {
        int? sid = AuthHelper.GetStudentIdForUser();
        if (sid == null) return;
        try
        {
            gvTransport.DataSource = DbHelper.ExecuteTable(
                "SELECT Route, VehicleNo FROM Transport WHERE StudentID=@ID", DbHelper.P("@ID", sid.Value));
        }
        catch
        {
            gvTransport.DataSource = DbHelper.ExecuteTable(
                "SELECT RouteName AS Route, BusNumber AS VehicleNo FROM Transport WHERE StudentID=@ID", DbHelper.P("@ID", sid.Value));
        }
        gvTransport.DataBind();
    }
}
