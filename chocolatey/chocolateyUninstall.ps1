Write-Host "Removing Stratos windows service as part of uninstall..."

try 
{
    $serviceFileName = "Stratos.exe"

    $PSScriptRoot = Split-Path -parent $MyInvocation.MyCommand.Definition
    $packageDir = $PSScriptRoot | Split-Path;
    $srcDir = "$($PSScriptRoot)\..\bin"

    $fileToUninstall = Join-Path "$srcDir\" $serviceFileName
    . $fileToUninstall uninstall
}
catch {
    throw $_.Exception
}