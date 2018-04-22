Param(
    [Parameter(Mandatory = $false, ParameterSetName = "PrinterName")]
    [string]$PrinterName 
)


$result =Get-PrintJob -PrinterName $PrinterName  | Select-Object -Property ID, DocumentName,PrinterName, @{Name = "JobStatus"; Expression = {[string]$_.JobStatus}}  -ExcludeProperty $exclude
if ($result -is [array]) {
    return $result | Select-Object -Property Id, DocumentName,PrinterName,@{Name = "JobStatus"; Expression = {[string]$_.JobStatus}} |  ConvertTo-Json
}
$itens = New-Object System.Collections.Generic.List[System.Object]
$itens.Add($result)


return  @($result) | Select-Object -Property Id, DocumentName,PrinterName,@{Name = "JobStatus"; Expression = {[string]$_.JobStatus}} | ConvertTo-Json