#! /bin/bash 
set -e

RELEASEFOLDER=src/bin/Release

cp chocolatey/*.ps1 $RELEASEFOLDER
cp chocolatey/VERIFICATION $RELEASEFOLDER
cp LICENSE src/bin/Release/

echo "$(basename $(ls $RELEASEFOLDER/*.dll))" >> $RELEASEFOLDER/VERIFICATION
echo "$(basename $(ls $RELEASEFOLDER/*.exe))" >> $RELEASEFOLDER/VERIFICATION

nuget pack chocolatey/Stratos.nuspec -BasePath $RELEASEFOLDER
