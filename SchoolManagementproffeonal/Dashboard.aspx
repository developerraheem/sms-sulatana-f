<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="School Management System" />
    <title>Admin Dashboard · School Management</title>
    <link href="Content/style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

    <nav class="topbar" aria-label="Main">
        <div class="topbar-inner">
            <a class="brand" href="Dashboard.aspx"><span class="brand-mark">SM</span> School Management</a>
            <ul class="nav-links">
                <li><a href="Dashboard.aspx" class="active">Dashboard</a></li>
                <li><a href="ManageStudents.aspx">Students</a></li>
                <li><a href="ManageTeachers.aspx">Teachers</a></li>
                <li><a href="ManageParents.aspx">Parents</a></li>
                <li><a href="ManageClasses.aspx">Classes</a></li>
                <li><a href="ManageSubjects.aspx">Subjects</a></li>
                <li><a href="Fees.aspx">Fees</a></li>
                <li><a href="Exam.aspx">Exams</a></li>
                <li><a href="ManageResults.aspx">Results</a></li>
                <li><a href="ManageLibrary.aspx">Library</a></li>
                <li><a href="ManageTransport.aspx">Transport</a></li>
                <li><a href="Register.aspx">Accounts</a></li>
            </ul>
            <div class="topbar-meta">
                <div class="user-chip">
                    <span class="avatar"><asp:Literal ID="litUserInitial" runat="server" Text="U" /></span>
                    <span>
                        <asp:Literal ID="litUsername" runat="server" Text="User" />
                        <span class="role-tag"> · <asp:Literal ID="litUserRole" runat="server" Text="Admin" /></span>
                    </span>
                </div>
                <a class="btn-logout" href="Logout.aspx">Logout</a>
            </div>
        </div>
    </nav>

    <div class="page">
        <div class="page-header">
            <div class="header-text">
                <span class="eyebrow">Admin console</span>
                <h1>Operations overview</h1>
                <p class="subtitle">Live enrollment, faculty, and fee collection snapshot for the current term.</p>
            </div>
            <div class="header-actions">
                <a class="btn btn-ghost btn-sm" href="ManageStudents.aspx">Add student</a>
                <a class="btn btn-primary btn-sm" href="Register.aspx">Create account</a>
            </div>
        </div>

        <div class="stat-row">
            <div class="stat-card">
                <div class="stat-top">
                    <span class="stat-tab">Students</span>
                    <span class="stat-icon">
                        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.8" stroke-linecap="round" stroke-linejoin="round"><path d="M2 8.5 12 4l10 4.5-10 4.5-10-4.5Z"/><path d="M6 10.7v4.8c0 1.4 2.7 2.5 6 2.5s6-1.1 6-2.5v-4.8"/><path d="M21 9.5v6"/></svg>
                    </span>
                </div>
                <div class="stat-value"><asp:Literal ID="litStudents" runat="server">0</asp:Literal></div>
                <div class="stat-foot">Active enrollment</div>
            </div>
            <div class="stat-card">
                <div class="stat-top">
                    <span class="stat-tab">Teachers</span>
                    <span class="stat-icon">
                        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.8" stroke-linecap="round" stroke-linejoin="round"><circle cx="12" cy="7.5" r="3.2"/><path d="M5.5 20c0-3.6 2.9-6.2 6.5-6.2s6.5 2.6 6.5 6.2"/></svg>
                    </span>
                </div>
                <div class="stat-value"><asp:Literal ID="litTeachers" runat="server">0</asp:Literal></div>
                <div class="stat-foot">On faculty</div>
            </div>
            <div class="stat-card">
                <div class="stat-top">
                    <span class="stat-tab">Classes</span>
                    <span class="stat-icon">
                        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.8" stroke-linecap="round" stroke-linejoin="round"><rect x="3.5" y="4" width="17" height="12" rx="1.5"/><path d="M8 20h8"/><path d="M12 16v4"/></svg>
                    </span>
                </div>
                <div class="stat-value"><asp:Literal ID="litClasses" runat="server">0</asp:Literal></div>
                <div class="stat-foot">Currently running</div>
            </div>
            <div class="stat-card">
                <div class="stat-top">
                    <span class="stat-tab">Fees collected</span>
                    <span class="stat-icon">
                        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.8" stroke-linecap="round" stroke-linejoin="round"><circle cx="12" cy="12" r="8"/><path d="M12 7.5v9"/><path d="M15 9.8c0-1.3-1.3-2.3-3-2.3s-3 .9-3 2.1c0 3 6 1.5 6 4.4 0 1.3-1.3 2.2-3 2.2s-3-.9-3-2.2"/></svg>
                    </span>
                </div>
                <div class="stat-value"><asp:Literal ID="litFees" runat="server">0</asp:Literal></div>
                <div class="stat-foot">Paid in full this term</div>
            </div>
        </div>

        <div class="chalkboard">
            <div class="chalkboard-head">
                <div>
                    <span class="eyebrow">Live metrics</span>
                    <h2>Enrollment & finance overview</h2>
                </div>
                <span class="chalkboard-sub">Updated on page load</span>
            </div>
            <div class="chart-grid">
                <div class="chart-box">
                    <div class="chart-box-title">Enrollment</div>
                    <canvas id="chartEnrollment" height="210"></canvas>
                </div>
                <div class="chart-box">
                    <div class="chart-box-title">Fees: paid vs pending</div>
                    <canvas id="chartFees" height="210"></canvas>
                </div>
            </div>
        </div>

        <div class="card mt-4">
            <div class="section-title">Quick actions</div>
            <div class="tile-grid">
                <a class="tile" href="ManageStudents.aspx"><span class="tile-icon">ST</span><strong>Students</strong><span>Enroll and update student profiles</span></a>
                <a class="tile" href="ManageTeachers.aspx"><span class="tile-icon">TC</span><strong>Teachers</strong><span>Maintain faculty records</span></a>
                <a class="tile" href="Fees.aspx"><span class="tile-icon">FE</span><strong>Fees</strong><span>Record payments and dues</span></a>
                <a class="tile" href="Exam.aspx"><span class="tile-icon">EX</span><strong>Exams</strong><span>Schedule assessments</span></a>
                <a class="tile" href="ManageResults.aspx"><span class="tile-icon">RS</span><strong>Results</strong><span>Publish marks and grades</span></a>
                <a class="tile" href="ManageLibrary.aspx"><span class="tile-icon">LB</span><strong>Library</strong><span>Issue and return books</span></a>
            </div>
        </div>
    </div>


    <footer class="site-footer">
        <div class="site-footer-inner">
            <div><strong>School Management System</strong> — academic operations console</div>
            <div>Secure role-based access · Admin · Teacher · Student · Parent</div>
        </div>
    </footer>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/chart.js@4.4.4/dist/chart.umd.min.js"></script>
    <asp:Literal ID="litChartData" runat="server"></asp:Literal>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            if (typeof chalkboardData === 'undefined' || typeof Chart === 'undefined') return;
            Chart.defaults.color = 'rgba(248, 250, 252, 0.85)';
            Chart.defaults.font.family = "'Plus Jakarta Sans', sans-serif";
            Chart.defaults.font.size = 12;
            new Chart(document.getElementById('chartEnrollment'), {
                type: 'bar',
                data: {
                    labels: ['Students', 'Teachers', 'Classes'],
                    datasets: [{
                        data: [chalkboardData.enrollment.students, chalkboardData.enrollment.teachers, chalkboardData.enrollment.classes],
                        backgroundColor: ['#4F46E5', '#10B981', '#F59E0B'],
                        borderRadius: 8,
                        barThickness: 44
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: { legend: { display: false } },
                    scales: {
                        y: { beginAtZero: true, ticks: { precision: 0, color: 'rgba(248, 250, 252, 0.65)' }, grid: { color: 'rgba(255, 255, 255, 0.08)' } },
                        x: { ticks: { color: 'rgba(248, 250, 252, 0.85)', font: { weight: '600' } }, grid: { display: false } }
                    }
                }
            });
            new Chart(document.getElementById('chartFees'), {
                type: 'doughnut',
                data: {
                    labels: ['Paid', 'Pending'],
                    datasets: [{
                        data: [chalkboardData.fees.paid, chalkboardData.fees.pending],
                        backgroundColor: ['#10B981', '#F59E0B'],
                        borderColor: '#0F172A',
                        borderWidth: 3
                    }]
                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        legend: {
                            position: 'bottom',
                            labels: {
                                boxWidth: 12,
                                boxHeight: 12,
                                borderRadius: 3,
                                useBorderRadius: true,
                                padding: 16,
                                color: 'rgba(248, 250, 252, 0.85)',
                                font: { weight: '600' }
                            }
                        }
                    },
                    cutout: '68%'
                }
            });
        });
    </script>

</body>
</html>
