using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageExams : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) { Response.Redirect("Exam.aspx", true); }
}
