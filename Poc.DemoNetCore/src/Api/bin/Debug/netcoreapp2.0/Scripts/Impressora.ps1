Param(
    [Parameter(Mandatory = $false, ParameterSetName = "PrinterName")]
    [string]$PrinterName ,
    [switch]$Jobs
)


if ($PrinterName -ne "") {
    $result= Get-Printer -Name $PrinterName 
}
else {
    $result= Get-Printer 
}



return $result |Select-Object -Property Name,JobCount,Datatype,DriverName,PortName,@{Name = "PrinterStatus"; Expression = {[string]$_.PrinterStatus}} |ConvertTo-Json