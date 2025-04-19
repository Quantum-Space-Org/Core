#!/bin/bash
set -e

# Move to the repo root (assuming this script is in ./IaaC)
cd "$(dirname "$0")/.."

NUGET_SOURCE="https://nuget.pkg.github.com/Quantum-Space-Org/index.json"

# Find all .nupkg files in ./build
echo "🔍 Searching for NuGet packages in ./build ..."
nupkgs=$(find ./build -name "*.nupkg")

if [ -z "$nupkgs" ]; then
  echo "❌ No .nupkg files found in ./build"
  exit 1
fi

echo "✅ Found the following .nupkg files:"
echo "$nupkgs"

# Iterate over all found packages and publish them
for PACKAGE in $nupkgs; do
  echo "🚀 Publishing $PACKAGE to GitHub Packages..."
  dotnet nuget push "$PACKAGE" \
    --source "$NUGET_SOURCE" \
    --api-key "$GITHUB_TOKEN"
done

echo "✅ All packages have been published successfully!"
