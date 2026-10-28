using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Shared database and session helpers for the School Management System.
/// </summary>
public static class DbHelper
{
    public static string ConnectionString
    {
        get { return ConfigurationManager.ConnectionStrings["SchoolDBConn"].ConnectionString; }
    }

    public static SqlConnection OpenConnection()
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        conn.Open();
        return conn;
    }

    public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection conn = OpenConnection())
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }
    }

    public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection conn = OpenConnection())
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }
    }

    public static DataTable ExecuteTable(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public static void BindDropDown(DropDownList ddl, string sql, string textField, string valueField, string emptyText)
    {
        DataTable dt = ExecuteTable(sql);
        ddl.DataSource = dt;
        ddl.DataTextField = textField;
        ddl.DataValueField = valueField;
        ddl.DataBind();
        if (!string.IsNullOrEmpty(emptyText))
            ddl.Items.Insert(0, new ListItem(emptyText, ""));
    }

    public static SqlParameter P(string name, object value)
    {
        return new SqlParameter(name, value ?? DBNull.Value);
    }
}

/// <summary>
/// Session / role gate used by every authenticated page.
/// </summary>
public static class AuthHelper
{
    public static bool IsLoggedIn
    {
        get { return HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session["UserID"] != null; }
    }

    public static int UserId
    {
        get { return IsLoggedIn ? Convert.ToInt32(HttpContext.Current.Session["UserID"]) : 0; }
    }

    public static string Role
    {
        get { return IsLoggedIn ? Convert.ToString(HttpContext.Current.Session["Role"]) : string.Empty; }
    }

    public static string Username
    {
        get { return IsLoggedIn ? Convert.ToString(HttpContext.Current.Session["Username"]) : string.Empty; }
    }

    /// <summary>Redirects to Login if the session is missing or the role is not allowed.</summary>
    public static void RequireRoles(Page page, params string[] allowedRoles)
    {
        if (!IsLoggedIn)
        {
            page.Response.Redirect("Login.aspx", true);
            return;
        }

        if (allowedRoles == null || allowedRoles.Length == 0)
            return;

        string role = Role;
        bool ok = false;
        foreach (string r in allowedRoles)
        {
            if (string.Equals(r, role, StringComparison.OrdinalIgnoreCase))
            {
                ok = true;
                break;
            }
        }

        if (!ok)
            page.Response.Redirect(HomeForRole(role), true);
    }

    public static string HomeForRole(string role)
    {
        if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase)) return "Dashboard.aspx";
        if (string.Equals(role, "Teacher", StringComparison.OrdinalIgnoreCase)) return "TeacherDashboard.aspx";
        if (string.Equals(role, "Student", StringComparison.OrdinalIgnoreCase)) return "StudentDashboard.aspx";
        if (string.Equals(role, "Parent", StringComparison.OrdinalIgnoreCase)) return "ParentDashboard.aspx";
        return "Login.aspx";
    }

    public static void SignOut(Page page)
    {
        if (page.Session != null)
        {
            page.Session.Clear();
            page.Session.Abandon();
        }
        page.Response.Redirect("Login.aspx", true);
    }

    public static int? GetTeacherIdForUser()
    {
        object o = DbHelper.ExecuteScalar("SELECT TeacherID FROM Teachers WHERE UserID=@U", DbHelper.P("@U", UserId));
        if (o == null || o == DBNull.Value) return null;
        return Convert.ToInt32(o);
    }

    public static int? GetStudentIdForUser()
    {
        object o = DbHelper.ExecuteScalar("SELECT StudentID FROM Students WHERE UserID=@U", DbHelper.P("@U", UserId));
        if (o == null || o == DBNull.Value) return null;
        return Convert.ToInt32(o);
    }

    public static int? GetParentIdForUser()
    {
        object o = DbHelper.ExecuteScalar("SELECT ParentID FROM Parents WHERE UserID=@U", DbHelper.P("@U", UserId));
        if (o == null || o == DBNull.Value) return null;
        return Convert.ToInt32(o);
    }
}
