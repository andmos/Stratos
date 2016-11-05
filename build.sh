#!/bin/bash
nuget restore src/Stratos.sln
xbuild src/Stratos.sln 

echo "Running tests: "
mono src/packages/xunit.runner.console.2.1.0/tools/xunit.console.exe src/TestStratos/bin/Debug/TestStratos.dll
