$binDir = (Resolve-Path "bin\Debug").Path

# Pre-load all referenced dlls into current AppDomain
Get-ChildItem -Path $binDir -Filter "*.dll" | ForEach-Object {
    try {
        [System.Reflection.Assembly]::LoadFrom($_.FullName) | Out-Null
    } catch {}
}

$asm = [System.Reflection.Assembly]::LoadFrom("$binDir\School.exe")
$type = $asm.GetType("School._forms.FrmExcelImportPreview")
Write-Output "Type loaded: $($type.FullName)"

# Test month normalization method
$normMethod = $type.GetMethod("TryNormalizeFeeMonth", [System.Reflection.BindingFlags]::Public -bor [System.Reflection.BindingFlags]::Static)
$argsArr = @("10 2026", $null)
$res = $normMethod.Invoke($null, $argsArr)
Write-Output "TryNormalizeFeeMonth('10 2026') -> Result=$res, Normalized=$($argsArr[1])"
