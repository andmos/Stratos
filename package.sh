#! /bin/bash 
set -e
cp chocolatey/*.ps1 src/bin/Release/
nuget pack chocolatey/Stratos.nuspec -BasePath src/bin/Release
