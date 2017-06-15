Stratos HTTP API
===

### GET

    /api/ping
    # Returns pong

    /api/chocoVersion
    # Returns version string of Chocolatey itself.

    /api/chocoPackages
    # Returns JSON with all installed chocolatey packages and versions.

    /api/failedChocoPackages
    # Returns JSON with all failed chocolatey packages (failed packages are placed in the `lib-bad` folder)

    /api/
    # Returns list of all available routes.
