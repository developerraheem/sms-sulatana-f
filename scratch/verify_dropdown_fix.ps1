Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))
$tSettings = $asm.GetType('School.Properties.Settings')
$settings = $tSettings.GetProperty('Default', [System.Reflection.BindingFlags]'Public,Static').GetValue($null, $null)
$settings['sql_conn'] = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"

$tSys = $asm.GetType('SYSTEMSETTING')
if ($tSys -eq $null) { $tSys = $asm.GetType('School.SYSTEMSETTING') }
$tSys.GetField('branch_ID', [System.Reflection.BindingFlags]'Public,Static').SetValue($null, '6')

$t = $asm.GetType('School._forms.frm_student_promotions')
$f = [System.Activator]::CreateInstance($t)
$loadMethod = $t.GetMethod('frm_student_promotions_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$loadMethod.Invoke($f, @($null, [System.EventArgs]::Empty))

$panel3 = $f.Controls['panel3']
$panel1 = $f.Controls['panel1']

Write-Output "=== cmbsessionfrom (Source Session Dropdown) ==="
$cmbFrom = $panel3.Controls['cmbsessionfrom']
Write-Output ("Item Count: " + $cmbFrom.Items.Count)
for ($i = 0; $i -lt $cmbFrom.Items.Count; $i++) {
    $drv = $cmbFrom.Items[$i]
    Write-Output ("  Item [" + $i + "]: ID=" + $drv['SessionID'] + " | Display=[" + $drv['SessionName'] + "]")
}

Write-Output "`n=== cmbsessionto (Destination Session Dropdown) ==="
$cmbTo = $panel1.Controls['cmbsessionto']
Write-Output ("Item Count: " + $cmbTo.Items.Count)
for ($i = 0; $i -lt $cmbTo.Items.Count; $i++) {
    $drv = $cmbTo.Items[$i]
    Write-Output ("  Item [" + $i + "]: ID=" + $drv['SessionID'] + " | Display=[" + $drv['SessionName'] + "]")
}

Write-Output "`n=== Other Dropdowns on Student Shifting / Promotions ==="
foreach ($name in @('cmbclassfrom', 'cmbshift', 'cmbsection')) {
    $c = $panel3.Controls[$name]
    Write-Output ($name + " Item Count: " + $c.Items.Count + " (First item: [" + $c.Items[0][$c.DisplayMember] + "])")
}
