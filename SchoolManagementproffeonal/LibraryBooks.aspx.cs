using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LibraryBooks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Student");
        BindUserChrome();
        if (!IsPostBack) LoadBooks();
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadBooks()
    {
        int? sid = AuthHelper.GetStudentIdForUser();
        if (sid == null) return;
        try
        {
            gvBooks.DataSource = DbHelper.ExecuteTable(
                "SELECT BookName, IssueDate, ReturnDate FROM Library WHERE StudentID=@ID ORDER BY IssueDate DESC",
                DbHelper.P("@ID", sid.Value));
        }
        catch
        {
            gvBooks.DataSource = DbHelper.ExecuteTable(
                "SELECT Title AS BookName, IssueDate, ReturnDate FROM Library WHERE StudentID=@ID ORDER BY IssueDate DESC",
                DbHelper.P("@ID", sid.Value));
        }
        gvBooks.DataBind();
    }
}
