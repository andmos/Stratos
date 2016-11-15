Write-Host "Installing Stratos as as windows service..."

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
        Write-Host "Uninstalling $service_name..."

        $fileToUninstall = Join-Path "$srcDir\" $serviceFileName
        . $fileToUninstall uninstall
    }

    $fileToInstall = Join-Path "$destDir\" $serviceFileName
    . $fileToInstall install
}
catch {
    throw $_.Exception
}
try{
    . $fileToInstall start
}
catch{
    Write-Host "$process_name was succesfully installed, but could not be started. This is most likely beacause of a configuration error. Please check the Windows Event Log."
}