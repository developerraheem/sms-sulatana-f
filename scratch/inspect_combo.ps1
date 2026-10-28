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
$cmb = $panel3.Controls['cmbsessionfrom']

Write-Output ("Item Count: " + $cmb.Items.Count)
Write-Output ("DropDownHeight: " + $cmb.DropDownHeight)
Write-Output ("ItemHeight: " + $cmb.ItemHeight)
Write-Output ("IntegralHeight: " + $cmb.IntegralHeight)
Write-Output ("MaxDropDownItems: " + $cmb.MaxDropDownItems)
Write-Output ("DrawMode: " + $cmb.DrawMode)
Write-Output ("FlatStyle: " + $cmb.FlatStyle)
Write-Output ("DropDownStyle: " + $cmb.DropDownStyle)

for ($i = 0; $i -lt $cmb.Items.Count; $i++) {
    $drv = $cmb.Items[$i]
    Write-Output ("[" + $i + "] Value=" + $drv["SessionID"] + " | Text=[" + $drv["SessionName"] + "]")
}
