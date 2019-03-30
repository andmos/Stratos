Write-Host "Stopping Stratos windows service as part of upgrade or uninstall..."

try {

    $service_name = "StratosService"
    $process_name = "StratosService"
    $serviceFileName = "Stratos.exe"

    $PSScriptRoot = Split-Path -parent $MyInvocation.MyCommand.Definition
    $packageDir = $PSScriptRoot | Split-Path;
    $srcDir = "$($PSScriptRoot)\..\bin"
    $destDir = "$srcDir"

    $service = Get-Service | Where-Object {$_.Name -eq $service_name}

    if($service){
        Stop-Service $service_name
        $service.WaitForStatus("Stopped")
        kill -processname $process_name -force -ErrorAction SilentlyContinue
        Wait-Process -Name $process_name -ErrorAction SilentlyContinue
        
    }
}
catch {
    throw $_.Exception
}