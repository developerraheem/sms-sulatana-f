using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && AuthHelper.IsLoggedIn)
            Response.Redirect(AuthHelper.HomeForRole(AuthHelper.Role), true);

        if (!IsPostBack)
            lblMessage.Text = string.Empty;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblMessage.CssClass = "msg msg-error";
        string username = (txtUsername.Text ?? string.Empty).Trim();
        string password = txtPassword.Text ?? string.Empty;
        string selectedRole = rblRole.SelectedValue;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            lblMessage.Text = "Please enter both username and password.";
            return;
        }

        try
        {
            using (SqlConnection conn = DbHelper.OpenConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT UserID, Role FROM Users WHERE Username=@Username AND PasswordHash=@Password", conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        lblMessage.Text = "Invalid username or password.";
                        return;
                    }

                    int userId = Convert.ToInt32(reader["UserID"]);
                    string actualRole = Convert.ToString(reader["Role"]);
                    reader.Close();

                    if (!string.Equals(actualRole, selectedRole, StringComparison.OrdinalIgnoreCase))
                    {
                        lblMessage.Text = "This account is registered as " + actualRole + ", not " + selectedRole + ".";
                        return;
                    }

                    Session["UserID"] = userId;
                    Session["Role"] = actualRole;
                    Session["Username"] = username;
                    Response.Redirect(AuthHelper.HomeForRole(actualRole), false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Unable to sign in right now. Please try again. (" + Server.HtmlEncode(ex.Message) + ")";
        }
    }
}
