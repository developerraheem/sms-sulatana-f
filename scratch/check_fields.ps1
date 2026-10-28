$asm = [System.Reflection.Assembly]::LoadFrom("C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe")
$t = $asm.GetType("School._forms.Frm_generatefee_multi")
$fields = $t.GetFields([System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance -bor [System.Reflection.BindingFlags]::Public)
foreach ($f in $fields) {
    if ($f.Name -match "txt|cmb|chk|lbl|check") {
        Write-Host "$($f.Name) ($($f.FieldType.Name))"
    }
}
