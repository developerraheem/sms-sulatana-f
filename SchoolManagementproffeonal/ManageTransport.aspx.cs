using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageTransport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack) { LoadStudents(); LoadTransport(); }
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadStudents()
    {
        DbHelper.BindDropDown(ddlStudent, "SELECT StudentID, Name FROM Students ORDER BY Name", "Name", "StudentID", "— Select student —");
    }
    private void LoadTransport()
    {
        // Flexible column names
        try
        {
            gvTransport.DataSource = DbHelper.ExecuteTable(@"
                SELECT t.TransportID, s.Name AS StudentName, t.Route, t.VehicleNo
                FROM Transport t JOIN Students s ON t.StudentID = s.StudentID
                ORDER BY s.Name");
        }
        catch
        {
            gvTransport.DataSource = DbHelper.ExecuteTable(@"
                SELECT t.TransportID, s.Name AS StudentName, t.RouteName AS Route, t.BusNumber AS VehicleNo
                FROM Transport t JOIN Students s ON t.StudentID = s.StudentID
                ORDER BY s.Name");
        }
        gvTransport.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ddlStudent.SelectedValue) || string.IsNullOrWhiteSpace(txtRoute.Text))
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Student and route are required."; return; }
        int rows = 0;
        try
        {
            rows = DbHelper.ExecuteNonQuery(
                "INSERT INTO Transport (StudentID, Route, VehicleNo) VALUES (@S,@R,@V)",
                DbHelper.P("@S", Convert.ToInt32(ddlStudent.SelectedValue)),
                DbHelper.P("@R", txtRoute.Text.Trim()),
                DbHelper.P("@V", txtVehicle.Text.Trim()));
        }
        catch
        {
            rows = DbHelper.ExecuteNonQuery(
                "INSERT INTO Transport (StudentID, RouteName, BusNumber) VALUES (@S,@R,@V)",
                DbHelper.P("@S", Convert.ToInt32(ddlStudent.SelectedValue)),
                DbHelper.P("@R", txtRoute.Text.Trim()),
                DbHelper.P("@V", txtVehicle.Text.Trim()));
        }
        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Assignment saved." : "Could not save assignment.";
        if (rows > 0) { txtRoute.Text = txtVehicle.Text = ""; LoadTransport(); }
    }
    protected void gvTransport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRow")
        {
            DbHelper.ExecuteNonQuery("DELETE FROM Transport WHERE TransportID=@ID", DbHelper.P("@ID", Convert.ToInt32(e.CommandArgument)));
            LoadTransport();
            lblMessage.CssClass="msg msg-success"; lblMessage.Text="Assignment removed.";
        }
    }
}
