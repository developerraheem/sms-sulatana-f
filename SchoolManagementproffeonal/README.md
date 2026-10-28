# School Management System

Professional ASP.NET Web Forms application for campus operations across four roles:

| Role | Portal home | Capabilities |
|------|-------------|--------------|
| **Admin** | `Dashboard.aspx` | Students, teachers, parents, classes, subjects, fees, exams, results, library, transport, user accounts |
| **Teacher** | `TeacherDashboard.aspx` | Mark attendance, enter marks, view assigned classes |
| **Student** | `StudentDashboard.aspx` | Attendance, results, fees, library books, transport |
| **Parent** | `ParentDashboard.aspx` | Per-child attendance, results, and fees |

## What’s included

- Consistent navy / gold professional UI (`Content/style.css`)
- Sticky top navigation with user chip + logout on every authenticated page
- Session role gates (`App_Code/DbHelper.cs` → `AuthHelper`)
- Listing grids + delete / mark-paid / mark-returned actions on admin modules
- New pages: **Manage Parents**, **Logout**, **Default** redirect, **ManageFees / ManageExams** aliases
- Responsive layout, empty states, badges, charts on admin dashboard
- SQL schema + upgrade script: `docs/schema_upgrade.sql`

## Requirements

- IIS / IIS Express or Visual Studio
- .NET Framework 4.5+ (configured for 4.8)
- SQL Server (LocalDB / Express / full)

## Setup

1. Create database `SchoolManagementDB` and run `docs/schema_upgrade.sql`.
2. Open `web.config` and set your SQL instance in `SchoolDBConn`.
3. Host the folder as an ASP.NET website (File → Open Web Site in Visual Studio, or IIS site pointing here).
4. Browse to the site — you land on **Login**.
5. Default seed admin (if script was run):  
   - Username: `admin`  
   - Password: `admin123`  
   - Role: **Admin**

## Linking portal users

1. **Accounts** → create a user with role Teacher / Student / Parent.  
2. Open **Teachers / Students / Parents** and choose that login in **Linked user account**.  
3. That person then only sees their own data after sign-in.

## Project layout

```
SchoolManagementPro/
  App_Code/DbHelper.cs     Shared DB + auth helpers
  Content/style.css        Design system
  docs/schema_upgrade.sql  Database script
  *.aspx / *.aspx.cs       Pages
  web.config
  README.md
```

## Notes

- Passwords are stored as provided in `Users.PasswordHash` (plain for academic demos). Hash before production use.
- Library / Transport / Attendance code tolerates a few alternate column names from earlier schemas.
- Connection string still points at `RAHEEMSARDAR\SQLEXPRESS` — change it for your machine.
