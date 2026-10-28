[xml]$xml = Get-Content 'c:\Users\nahee\OneDrive\Desktop\Sultana Foundation\Fee_Summary_Reports\Head_student_wise_fee_withouthead.rdlc'
$ns = New-Object System.Xml.XmlNamespaceManager($xml.NameTable)
$ns.AddNamespace('rd', 'http://schemas.microsoft.com/SQLServer/reporting/reportdesigner')
$ns.AddNamespace('def', 'http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition')

$tablix = $xml.SelectSingleNode('//def:Tablix', $ns)
$headers = $tablix.SelectNodes('.//def:TablixRow[1]//def:Textbox', $ns)
foreach ($h in $headers) {
    Write-Output "Header: $($h.Paragraphs.Paragraph.TextRuns.TextRun.Value)"
}

$details = $tablix.SelectNodes('.//def:TablixRow[2]//def:Textbox', $ns)
foreach ($d in $details) {
    Write-Output "Detail: $($d.Paragraphs.Paragraph.TextRuns.TextRun.Value)"
}
