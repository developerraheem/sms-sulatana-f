using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthHelper.RequireRoles(this, "Admin");
        BindUserChrome();
        if (!IsPostBack)
            LoadCounts();
    }

    private void BindUserChrome()
    {
        string name = AuthHelper.Username;
        if (string.IsNullOrEmpty(name)) name = "User";
        litUsername.Text = Server.HtmlEncode(name);
        litUserRole.Text = Server.HtmlEncode(AuthHelper.Role);
        litUserInitial.Text = Server.HtmlEncode(name.Substring(0, 1).ToUpperInvariant());
    }

    private void LoadCounts()
    {
        int studentsCount = Convert.ToInt32(DbHelper.ExecuteScalar("SELECT COUNT(*) FROM Students") ?? 0);
        int teachersCount = Convert.ToInt32(DbHelper.ExecuteScalar("SELECT COUNT(*) FROM Teachers") ?? 0);
        int classesCount = Convert.ToInt32(DbHelper.ExecuteScalar("SELECT COUNT(*) FROM Classes") ?? 0);

        object paidResult = DbHelper.ExecuteScalar("SELECT SUM(Amount) FROM Fees WHERE PaidStatus='Paid'");
        object pendingResult = DbHelper.ExecuteScalar("SELECT SUM(Amount) FROM Fees WHERE PaidStatus='Pending'");
        decimal feesPaid = (paidResult != null && paidResult != DBNull.Value) ? Convert.ToDecimal(paidResult) : 0m;
        decimal feesPending = (pendingResult != null && pendingResult != DBNull.Value) ? Convert.ToDecimal(pendingResult) : 0m;

        litStudents.Text = studentsCount.ToString(CultureInfo.InvariantCulture);
        litTeachers.Text = teachersCount.ToString(CultureInfo.InvariantCulture);
        litClasses.Text = classesCount.ToString(CultureInfo.InvariantCulture);
        litFees.Text = "Rs. " + feesPaid.ToString("N0", CultureInfo.InvariantCulture);

        litChartData.Text = string.Format(CultureInfo.InvariantCulture,
            "<script>const chalkboardData = {{ enrollment: {{ students: {0}, teachers: {1}, classes: {2} }}, fees: {{ paid: {3}, pending: {4} }} }};</script>",
            studentsCount, teachersCount, classesCount,
            feesPaid.ToString("0.##", CultureInfo.InvariantCulture),
            feesPending.ToString("0.##", CultureInfo.InvariantCulture));
    }
}
