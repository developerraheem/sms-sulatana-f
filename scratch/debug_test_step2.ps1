$settings = [System.Configuration.ConfigurationManager]::ConnectionStrings
$bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if (-not $bReadOnlyField) {
    $bReadOnlyField = [System.Configuration.ConfigurationElementCollection].GetField("_bReadOnly", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
}
$bReadOnlyField.SetValue($settings, $false)
$testConnStr = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCMS_SF_TEST;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Connect Timeout=30;"
$newCs = New-Object System.Configuration.ConnectionStringSettings("Sqlconn", $testConnStr, "System.Data.SqlClient")
$settings.Remove("Sqlconn")
$settings.Add($newCs)

$exePath = "C:\Users\nahee\OneDrive\Desktop\Sultana Foundation\bin\Debug\School.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$settingsType = $asm.GetType("School.Properties.Settings")
$settingsProp = $settingsType.GetProperty("Default")
$appSettings = $settingsProp.GetValue($null, $null)
$appSettings["sql_conn"] = $testConnStr

$sysType = $asm.GetType("SYSTEMSETTING")
$sysType.GetField("branch_ID").SetValue($null, "1")
$sysType.GetField("sessionid").SetValue($null, "78")

Add-Type @"
using System;
using System.Threading;
using System.Runtime.InteropServices;

public class ModalCloser {
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    public static void CloseNextDialog(string windowTitle, int timeoutMs) {
        ThreadPool.QueueUserWorkItem(state => {
            int elapsed = 0;
            while (elapsed < timeoutMs) {
                IntPtr hwnd = FindWindow(null, windowTitle);
                if (hwnd != IntPtr.Zero) {
                    PostMessage(hwnd, 0x0010, IntPtr.Zero, IntPtr.Zero);
                    break;
                }
                Thread.Sleep(50);
                elapsed += 50;
            }
        });
    }
}
"@

$formType = $asm.GetType("School._forms.Frm_generatefee_multi")
$form = [System.Activator]::CreateInstance($formType)

Write-Host "Calling Frm_generatefee_Load..."
$loadMethod = $formType.GetMethod("Frm_generatefee_Load", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$loadMethod.Invoke($form, @($null, [System.EventArgs]::Empty))

Write-Host "Setting comboBox1 = 169..."
$cmbClassProp = $formType.GetField("comboBox1", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$cmbClass = $cmbClassProp.GetValue($form)
$cmbClass.SelectedValue = [decimal]169

$gridField = $formType.GetField("fee_Class_updateDataGridView", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$grid = $gridField.GetValue($form)
Write-Host "Grid row count: $($grid.Rows.Count)"

$targetRow = $null
for ($i = 0; $i -lt $grid.Rows.Count; $i++) {
    if ([decimal]$grid.Rows[$i].Cells[0].Value -eq [decimal]52375) {
        $targetRow = $grid.Rows[$i]
        break
    }
}
Write-Host "Target row found: $($targetRow -ne $null), Active=$($targetRow.Cells[4].Value)"

$grid.CurrentCell = $targetRow.Cells[4]
$grid.BeginEdit($true)
$targetRow.Cells[4].Value = $false

Write-Host "Invoking CurrentCellDirtyStateChanged..."
$dirtyMethod = $formType.GetMethod("fee_Class_updateDataGridView_CurrentCellDirtyStateChanged", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
if ($dirtyMethod) {
    $dirtyMethod.Invoke($form, @($grid, [System.EventArgs]::Empty))
}
Write-Host "Dirty state handled."

$saveMethod = $formType.GetMethod("fee_Class_updateBindingNavigatorSaveItem_Click", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$saveBtnField = $formType.GetField("fee_Class_updateBindingNavigatorSaveItem", [System.Reflection.BindingFlags]::NonPublic -bor [System.Reflection.BindingFlags]::Instance)
$saveBtn = $saveBtnField.GetValue($form)

Write-Host "Launching ModalCloser and invoking saveMethod..."
[ModalCloser]::CloseNextDialog("[School Management System]", 5000)
try {
    $saveMethod.Invoke($form, @($saveBtn, [System.EventArgs]::Empty))
    Write-Host "saveMethod finished successfully."
} catch {
    Write-Host "saveMethod exception: $_"
}

$conn = New-Object System.Data.SqlClient.SqlConnection($testConnStr)
$conn.Open()
$cmd = $conn.CreateCommand()
$cmd.CommandText = "SELECT ACTIVE FROM FEE_CLASS WHERE FEE_CLASS_ID = 52375"
$dbActive = $cmd.ExecuteScalar()
Write-Host "Database Active after save: $dbActive"
$conn.Close()
$form.Dispose()
