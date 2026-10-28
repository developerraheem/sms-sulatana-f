$connStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
$bReadOnlyField.SetValue($settings, $false)
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $connStr, "System.Data.SqlClient")
$settings.Remove("Sqlconn")
$settings.Add($newCs)

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$sysType = $asm.GetType("SYSTEMSETTING")
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "78")

$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
$form = [System.Activator]::CreateInstance($formType)

$flags = [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance
$dtpStart = $formType.GetField("txtstartdate", $flags).GetValue($form)
$dtpEnd = $formType.GetField("txtenddate", $flags).GetValue($form)
$dtpFrom = $formType.GetField("txtdatefrom", $flags).GetValue($form)
$dtpTo = $formType.GetField("txtdateto", $flags).GetValue($form)

Write-Host "Initial Values before Load:"
Write-Host "txtstartdate: $($dtpStart.Value)"
Write-Host "txtenddate:   $($dtpEnd.Value)"
Write-Host "txtdatefrom:  $($dtpFrom.Value)"
Write-Host "txtdateto:    $($dtpTo.Value)"

# Now simulate Load
$loadMethod = $formType.GetMethod("Frm_generatefee_Load", $flags)
$loadMethod.Invoke($form, @($null, [EventArgs]::Empty))

Write-Host "`nAfter Load:"
Write-Host "txtstartdate: $($dtpStart.Value)"
Write-Host "txtenddate:   $($dtpEnd.Value)"
Write-Host "txtdatefrom:  $($dtpFrom.Value)"
Write-Host "txtdateto:    $($dtpTo.Value)"
