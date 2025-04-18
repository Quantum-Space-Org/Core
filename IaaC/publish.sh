#!/bin/bash
set -e

# Move to the repo root (assuming this script is in ./IaaC)
cd "$(dirname "$0")/.."

PACKAGE_PATH=$(find ./build -name "*.nupkg" | head -n 1)

if [ -z "$PACKAGE_PATH" ]; then
  echo "❌ No .nupkg file found in ./build"
  exit 1
fi

echo "🚀 Publishing $PACKAGE_PATH to GitHub Packages..."

dotnet nuget push "$PACKAGE_PATH" \
  --source "https://nuget.pkg.github.com/Quantum-Space-Org/index.json" \
  --api-key "$GITHUB_TOKEN"

