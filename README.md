Stratos
===
When using [Chocolatey](https://chocolatey.org/) and tools like [Octopus Deploy](https://octopus.com/), deploying software to tens or hundreds of servers goes like a breeze. But it is also easy to get confused: "What is actually running on the server right now?"

Stratos is a dead simple HTTP API that provides this information for you - making it great for information gathering on the entire testing cluster or just a simple check on that one team server.


[![CI / CD](https://github.com/andmos/Stratos/actions/workflows/CI.yaml/badge.svg?branch=master)](https://github.com/andmos/Stratos/actions/workflows/CI.yaml)

[![Chocolatey](https://img.shields.io/chocolatey/v/stratos.svg)](https://chocolatey.org/packages/stratos/)

Create the installable Chocolatey package: `$ docker run -v $(pwd):/workspace -w "/workspace" -it mono ./build.sh &&
./package.sh`

Example usage:
```shell
# Install some packages:

choco install jdk8
choco install jq

# Install Stratos and invoke:

choco install stratos
(Invoke-WebRequest http://localhost:1337/api/chocoPackages).Content
# [
#   {
#     "packageName": "chocolatey",
#     "version": {
#       "version": {
#         "major": 0,
#         "minor": 10,
#         "build": 12,
#         "revision": 0,
#         "majorRevision": 0,
#         "minorRevision": 0
#       },
#       "specialVersion": "beta-20181011"
#     }
#   },
#   {
#     "packageName": "DotNet4.5.2",
#     "version": {
#       "version": {
#         "major": 4,
#         "minor": 5,
#         "build": 2,
#         "revision": 20140902,
#         "majorRevision": 307,
#         "minorRevision": 21350
#       },
#       "specialVersion": ""
#     }
#   },
#   {
#     "packageName": "jdk8",
#     "version": {
#       "version": {
#         "major": 8,
#         "minor": 0,
#         "build": 201,
#         "revision": 0,
#         "majorRevision": 0,
#         "minorRevision": 0
#       },
#       "specialVersion": ""
#     }
#   },
#   {
#     "packageName": "jq",
#     "version": {
#       "version": {
#         "major": 1,
#         "minor": 5,
#         "build": 0,
#         "revision": 0,
#         "majorRevision": 0,
#         "minorRevision": 0
#       },
#       "specialVersion": ""
#     }
#   },
#   {
#     "packageName": "stratos",
#     "version": {
#       "version": {
#         "major": 0,
#         "minor": 6,
#         "build": 5,
#         "revision": 0,
#         "majorRevision": 0,
#         "minorRevision": 0
#       },
#       "specialVersion": ""
#     }
#   }
# ]

```

> Stratos is a chocolate made by Nidar in Trondheim, Norway. Please don't sue me for the name of this project, I love that chocolate.
