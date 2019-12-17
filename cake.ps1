[string]$SCRIPT = '0-build/build.cake'
[string]$CAKE_ARGS = "--verbosity=verbose"

dotnet --list-sdks

dotnet tool restore

dotnet format --check --dry-run --verbosity minimal

Write-Host "dotnet cake $SCRIPT $CAKE_ARGS $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT $CAKE_ARGS $ARGS
