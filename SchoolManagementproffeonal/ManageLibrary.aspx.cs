using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageLibrary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack)
        {
            LoadStudents();
            LoadLibrary();
            txtIssueDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
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

    private void LoadStudents()
    {
        DbHelper.BindDropDown(ddlStudent, "SELECT StudentID, Name FROM Students ORDER BY Name", "Name", "StudentID", "— Select student —");
    }
    private void LoadLibrary()
    {
        gvLibrary.DataSource = DbHelper.ExecuteTable(@"
            SELECT l.LibraryID, s.Name AS StudentName, l.BookName, l.IssueDate, l.ReturnDate
            FROM Library l JOIN Students s ON l.StudentID = s.StudentID
            ORDER BY l.IssueDate DESC");
        gvLibrary.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ddlStudent.SelectedValue) || string.IsNullOrWhiteSpace(txtBook.Text))
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Student and book title are required."; return; }
        DateTime issue; object ret = DBNull.Value;
        if (!DateTime.TryParse(txtIssueDate.Text, out issue))
        { lblMessage.CssClass="msg msg-error"; lblMessage.Text="Enter a valid issue date."; return; }
        DateTime rd;
        if (!string.IsNullOrWhiteSpace(txtReturnDate.Text) && DateTime.TryParse(txtReturnDate.Text, out rd))
            ret = rd;

        // Support both BookName and Title column naming
        int rows = 0;
        try
        {
            rows = DbHelper.ExecuteNonQuery(
                "INSERT INTO Library (StudentID, BookName, IssueDate, ReturnDate) VALUES (@S,@B,@I,@R)",
                DbHelper.P("@S", Convert.ToInt32(ddlStudent.SelectedValue)),
                DbHelper.P("@B", txtBook.Text.Trim()),
                DbHelper.P("@I", issue), DbHelper.P("@R", ret));
        }
        catch
        {
            rows = DbHelper.ExecuteNonQuery(
                "INSERT INTO Library (StudentID, Title, IssueDate, ReturnDate) VALUES (@S,@B,@I,@R)",
                DbHelper.P("@S", Convert.ToInt32(ddlStudent.SelectedValue)),
                DbHelper.P("@B", txtBook.Text.Trim()),
                DbHelper.P("@I", issue), DbHelper.P("@R", ret));
        }
        lblMessage.CssClass = rows > 0 ? "msg msg-success" : "msg msg-error";
        lblMessage.Text = rows > 0 ? "Book issued." : "Could not issue book.";
        if (rows > 0) { txtBook.Text = txtReturnDate.Text = ""; LoadLibrary(); }
    }
    protected void gvLibrary_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MarkReturned")
        {
            DbHelper.ExecuteNonQuery("UPDATE Library SET ReturnDate=@D WHERE LibraryID=@ID",
                DbHelper.P("@D", DateTime.Today), DbHelper.P("@ID", Convert.ToInt32(e.CommandArgument)));
            LoadLibrary();
            lblMessage.CssClass="msg msg-success"; lblMessage.Text="Marked as returned.";
        }
    }
}
