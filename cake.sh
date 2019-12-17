#!/bin/sh

set -x -e

SCRIPT='0-build/build.cake'

dotnet --info

dotnet tool restore

dotnet format --check --dry-run --verbosity minimal

CAKE_ARGS="$SCRIPT --verbosity=diagnostic -git-commit-sha=$GIT_COMMIT_SHA"

dotnet cake $CAKE_ARGS "$@"
