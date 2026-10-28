$binPath = (Resolve-Path 'bin\Debug\School.exe').Path
$asm = [System.Reflection.Assembly]::LoadFrom($binPath)
[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.ReportViewer.WinForms") | Out-Null

$dsType = $asm.GetType('School.DataSet_Fee_Summary_Reports')
$ds = [Activator]::CreateInstance($dsType)

$adapterType = $asm.GetType('School.DataSet_Fee_Summary_ReportsTableAdapters.HEAD_STUDENT_WISE_FEETableAdapter')
$adapter = [Activator]::CreateInstance($adapterType)
$prop = $adapterType.GetProperty('Connection', [System.Reflection.BindingFlags]'Instance,NonPublic,Public')
$conn = $prop.GetValue($adapter, $null)
$conn.ConnectionString = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True'

$table = $ds.Tables['HEAD_STUDENT_WISE_FEE']
$adapter.FillBy_ALL($table, "49", "05 2025", "Boys", "Girls", "General", "General", 122, 182) | Out-Null

# 1. Render Head_student_wise_fee_withouthead.rdlc
$rv = New-Object Microsoft.Reporting.WinForms.ReportViewer
$rv.LocalReport.ReportPath = (Resolve-Path 'Fee_Summary_Reports\Head_student_wise_fee_withouthead.rdlc').Path
$rds = New-Object Microsoft.Reporting.WinForms.ReportDataSource
$rds.Name = 'DataSet1'
$rds.Value = $table
$rv.LocalReport.DataSources.Add($rds)

$bytes = $rv.LocalReport.Render("PDF")
[System.IO.File]::WriteAllBytes("scratch\Head_student_wise_fee_withouthead.pdf", $bytes)
Write-Host ("Rendered Head_student_wise_fee_withouthead.pdf, size: " + $bytes.Length)

# 2. Render Head_student_wise_fee.rdlc
$rv2 = New-Object Microsoft.Reporting.WinForms.ReportViewer
$rv2.LocalReport.ReportPath = (Resolve-Path 'Fee_Summary_Reports\Head_student_wise_fee.rdlc').Path
$rds2 = New-Object Microsoft.Reporting.WinForms.ReportDataSource
$rds2.Name = 'DataSet1'
$rds2.Value = $table
$rv2.LocalReport.DataSources.Add($rds2)

$bytes2 = $rv2.LocalReport.Render("PDF")
[System.IO.File]::WriteAllBytes("scratch\Head_student_wise_fee.pdf", $bytes2)
Write-Host ("Rendered Head_student_wise_fee.pdf, size: " + $bytes2.Length)
