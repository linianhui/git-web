#!/bin/sh

set -ex

SCRIPT='cake/build.cake'

if command -v git >/dev/null 2>&1; then 
  GIT_COMMIT_SHA=$(git rev-parse --short HEAD)
fi

dotnet --list-sdks

dotnet tool restore

dotnet format --check --verbosity minimal

CAKE_ARGS="$SCRIPT --verbosity=verbose -git-commit-sha=$GIT_COMMIT_SHA"

dotnet cake $CAKE_ARGS "$@"
