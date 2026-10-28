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
$cSession = $panel3.Controls['cmbsessionfrom']
$cClass = $panel3.Controls['cmbclassfrom']
$cShift = $panel3.Controls['cmbshift']
$cSection = $panel3.Controls['cmbsection']

$props = @(
    'DropDownStyle', 'DropDownHeight', 'DropDownWidth', 'IntegralHeight',
    'ItemHeight', 'MaxDropDownItems', 'DrawMode', 'FlatStyle',
    'Font', 'Height', 'Margin', 'Padding', 'Size',
    'FormattingEnabled', 'FormatString', 'CausesValidation'
)

Write-Output ("Property".PadRight(20) + " | " + "cmbsessionfrom".PadRight(18) + " | " + "cmbclassfrom".PadRight(18) + " | " + "cmbshift".PadRight(18) + " | " + "cmbsection".PadRight(18))
Write-Output ("-" * 100)

foreach ($p in $props) {
    $vSess = ($cSession.GetType().GetProperty($p).GetValue($cSession, $null))
    $vClass = ($cClass.GetType().GetProperty($p).GetValue($cClass, $null))
    $vShift = ($cShift.GetType().GetProperty($p).GetValue($cShift, $null))
    $vSec = ($cSection.GetType().GetProperty($p).GetValue($cSection, $null))
    
    Write-Output ($p.PadRight(20) + " | " + "$vSess".PadRight(18) + " | " + "$vClass".PadRight(18) + " | " + "$vShift".PadRight(18) + " | " + "$vSec".PadRight(18))
}
