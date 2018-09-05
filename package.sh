#! /bin/bash 
set -e

RELEASEFOLDER=src/bin/Release

cp chocolatey/*.ps1 $RELEASEFOLDER
cp chocolatey/VERIFICATION.txt $RELEASEFOLDER
cp LICENSE.txt src/bin/Release/

echo "$(basename $(ls $RELEASEFOLDER/*.dll))" >> $RELEASEFOLDER/VERIFICATION.txt
echo "$(basename $(ls $RELEASEFOLDER/*.exe))" >> $RELEASEFOLDER/VERIFICATION.txt

nuget pack chocolatey/Stratos.nuspec -BasePath $RELEASEFOLDER
