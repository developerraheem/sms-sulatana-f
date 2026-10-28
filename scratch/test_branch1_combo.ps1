Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$asm = [System.Reflection.Assembly]::LoadFrom((Resolve-Path 'bin\Debug\School.exe'))
$tSettings = $asm.GetType('School.Properties.Settings')
$settings = $tSettings.GetProperty('Default', [System.Reflection.BindingFlags]'Public,Static').GetValue($null, $null)
$settings['sql_conn'] = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF;Integrated Security=True;"

$tSys = $asm.GetType('SYSTEMSETTING')
if ($tSys -eq $null) { $tSys = $asm.GetType('School.SYSTEMSETTING') }
$tSys.GetField('branch_ID', [System.Reflection.BindingFlags]'Public,Static').SetValue($null, '1')

$t = $asm.GetType('School._forms.frm_student_promotions')
$f = [System.Activator]::CreateInstance($t)
$loadMethod = $t.GetMethod('frm_student_promotions_Load', [System.Reflection.BindingFlags]'NonPublic,Instance')
$loadMethod.Invoke($f, @($null, [System.EventArgs]::Empty))

$panel3 = $f.Controls['panel3']
$cSession = $panel3.Controls['cmbsessionfrom']

Write-Output ("=== Branch 1 cmbsessionfrom (Count: " + $cSession.Items.Count + ") ===")
for ($i = 0; $i -lt $cSession.Items.Count; $i++) {
    $drv = $cSession.Items[$i]
    Write-Output ("  [" + $i + "] Value=" + $drv["SessionID"] + " | Text=[" + $drv["SessionName"] + "]")
}
