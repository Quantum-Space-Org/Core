#!/bin/bash
set -e

PACKAGE_PATH=$(find ../build -name "*.nupkg" | head -n 1)

if [ -z "$PACKAGE_PATH" ]; then
  echo "❌ No .nupkg file found in ../build"
  exit 1
fi

echo "🚀 Publishing $PACKAGE_PATH to GitHub Packages..."
dotnet nuget push "$PACKAGE_PATH" \
  --source "github" \
  --api-key "$GITHUB_TOKEN"
