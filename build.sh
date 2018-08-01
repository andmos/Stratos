#!/bin/bash
set -e
nuget restore src/Stratos.sln
msbuild /property:Configuration=Release src/Stratos.sln 

echo "Running tests: "
mono src/packages/xunit.runner.console.2.2.0/tools/xunit.console.exe src/TestStratos/bin/Release/TestStratos.dll

