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
  
  # Capture the output and error of the push attempt
  OUTPUT=$(dotnet nuget push "$PACKAGE" --source "$NUGET_SOURCE" --api-key "$GITHUB_TOKEN" 2>&1)
  
  # Print the raw output for debugging purposes
  echo "$OUTPUT"

  # Check if the error is a 409 Conflict, which indicates the package has already been pushed
  if echo "$OUTPUT" | grep -q "409 Conflict"; then
    echo "⚠️ Package $PACKAGE has already been published (409 Conflict). Skipping..."
  else
    # If another error occurs, display it and exit
    if [[ $? -ne 0 ]]; then
      echo "❌ Error occurred while publishing $PACKAGE. Exiting..."
      echo "$OUTPUT"
      exit 1
    fi
  fi
done

echo "✅ All packages processed successfully!"
