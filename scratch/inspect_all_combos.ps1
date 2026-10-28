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

foreach ($name in @('cmbsessionfrom', 'cmbclassfrom', 'cmbshift', 'cmbsection')) {
    $cmb = $panel3.Controls[$name]
    Write-Output ("=== " + $name + " (Count: " + $cmb.Items.Count + ") ===")
    for ($i = 0; $i -lt $cmb.Items.Count; $i++) {
        $drv = $cmb.Items[$i]
        $txt = $drv[$cmb.DisplayMember]
        $val = $drv[$cmb.ValueMember]
        Write-Output ("  [" + $i + "] Value=" + $val + " | Text=[" + $txt + "]")
    }
}
