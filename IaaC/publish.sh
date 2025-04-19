#!/bin/bash
set -e

# Move to the repo root (assuming this script is in ./IaaC)
cd "$(dirname "$0")/.."

NUGET_SOURCE="https://nuget.pkg.github.com/Quantum-Space-Org/index.json"

# Initialize an array to store all found .nupkg files
declare -a nupkgs

# Find all .nupkg files in ./build
echo "🔍 Searching for NuGet packages in ./build ..."
nupkgs=$(find ./build -name "*.nupkg")

if [ -z "$nupkgs" ]; then
  echo "❌ No .nupkg files found in ./build"
  exit 1
fi

echo "✅ Found the following .nupkg files:"
echo "$nupkgs"

# Loop through each .nupkg file and try to push it
echo "🚀 Starting to publish all packages..."

for PACKAGE in $nupkgs; do
  # Attempt to push the package
  echo "🚀 Publishing $PACKAGE to GitHub Packages..."
  
  if ! dotnet nuget push "$PACKAGE" \
    --source "$NUGET_SOURCE" \
    --api-key "$GITHUB_TOKEN"; then
    # Handle the conflict error (409), meaning the package was already published
    if [[ $? -eq 1 ]]; then
      echo "⚠️ Package $PACKAGE has already been published (409 Conflict). Skipping..."
    else
      echo "❌ Error occurred while publishing $PACKAGE. Exiting..."
      exit 1
    fi
  fi
done

echo "✅ All packages processed successfully!"
