[string]$SCRIPT = 'cake/build.cake'
[string]$CAKE_ARGS = "--verbosity=verbose"

dotnet --list-sdks

dotnet tool restore

dotnet format --check --verbosity minimal

Write-Host "dotnet cake $SCRIPT $CAKE_ARGS $ARGS" -ForegroundColor GREEN

dotnet cake $SCRIPT $CAKE_ARGS $ARGS
