[xml]$xml = Get-Content 'c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\Fee_Summary_Reports\Head_student_wise_fee_withouthead.rdlc'
$ns = New-Object System.Xml.XmlNamespaceManager($xml.NameTable)
$ns.AddNamespace('rd', 'http://schemas.microsoft.com/SQLServer/reporting/reportdesigner')
$ns.AddNamespace('def', 'http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition')

$tablix = $xml.SelectSingleNode('//def:Tablix', $ns)
Write-Output "Tablix Name: $($tablix.GetAttribute('Name'))"

$groups = $tablix.SelectNodes('.//def:Group', $ns)
foreach ($g in $groups) {
    Write-Output "Group: $($g.GetAttribute('Name'))"
    $exprs = $g.SelectNodes('.//def:GroupExpression', $ns)
    foreach ($e in $exprs) {
        Write-Output "  Expr: $($e.InnerText)"
    }
}

Write-Output "=== Tablix Columns ==="
$textboxes = $tablix.SelectNodes('.//def:TablixRowHierarchy//def:TablixMember', $ns)
$cells = $tablix.SelectNodes('.//def:TablixCell', $ns)
Write-Output "Cells count: $($cells.Count)"
foreach ($cell in $cells) {
    $val = $cell.SelectSingleNode('.//def:Value', $ns)
    if ($val) {
        Write-Output "  Cell: $($val.InnerText)"
    }
}
