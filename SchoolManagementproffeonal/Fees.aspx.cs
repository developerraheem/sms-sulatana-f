using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack) { LoadStudents(); LoadFees(); }
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
    private void LoadFees()
    {
        gvFees.DataSource = DbHelper.ExecuteTable(@"
            SELECT f.FeeID, s.Name AS StudentName, f.Amount, f.DueDate, f.PaidStatus
            FROM Fees f JOIN Students s ON f.StudentID = s.StudentID
            ORDER BY f.DueDate DESC");
        gvFees.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ddlStudent.SelectedValue)) { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Select a student."; return; }
        decimal amount; DateTime due;
        if (!decimal.TryParse(txtAmount.Text, out amount) || !DateTime.TryParse(txtDueDate.Text, out due))
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Enter a valid amount and due date."; return; }

        int rows = DbHelper.ExecuteNonQuery(
            "INSERT INTO Fees (StudentID, Amount, DueDate, PaidStatus) VALUES (@S,@A,@D,@P)",
            DbHelper.P("@S", Convert.ToInt32(ddlStudent.SelectedValue)),
            DbHelper.P("@A", amount), DbHelper.P("@D", due), DbHelper.P("@P", ddlStatus.SelectedValue));
        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Fee record saved." : "Could not save fee record.";
        if (rows > 0) { txtAmount.Text = txtDueDate.Text = ""; LoadFees(); }
    }
    protected void gvFees_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MarkPaid")
        {
            DbHelper.ExecuteNonQuery("UPDATE Fees SET PaidStatus='Paid' WHERE FeeID=@ID", DbHelper.P("@ID", Convert.ToInt32(e.CommandArgument)));
            LoadFees();
            lblMessage.CssClass = "msg msg-success";
            lblMessage.Text = "Marked as paid.";
        }
    }
}
