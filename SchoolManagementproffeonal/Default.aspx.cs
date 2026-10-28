using System;
using System.Web.UI;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (AuthHelper.IsLoggedIn)
            Response.Redirect(AuthHelper.HomeForRole(AuthHelper.Role), true);
        else
            Response.Redirect("Login.aspx", true);
    }
}
