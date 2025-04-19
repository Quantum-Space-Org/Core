#!/bin/bash
set -e

# Move to the repo root (assuming this script is in ./IaaC)
cd "$(dirname "$0")/.."

NUGET_SOURCE="https://nuget.pkg.github.com/Quantum-Space-Org/index.json"

# Initialize an associative array to store the latest version of each package
declare -A latest_versions

# Find all .nupkg files in ./build
echo "🔍 Searching for NuGet packages in ./build ..."
nupkgs=$(find ./build -name "*.nupkg")

if [ -z "$nupkgs" ]; then
  echo "❌ No .nupkg files found in ./build"
  exit 1
fi

echo "✅ Found the following .nupkg files:"
echo "$nupkgs"

# Loop through each .nupkg file and keep track of the latest version for each package
for PACKAGE in $nupkgs; do
  # Extract the file name and remove the .nupkg extension
  FILE_NAME=$(basename "$PACKAGE" .nupkg)

  # Use regex to match and extract the package name and version
  if [[ "$FILE_NAME" =~ ^(Quantum\.[A-Za-z0-9]+)\.([0-9]+\.[0-9]+\.[0-9]+.*)$ ]]; then
    PACKAGE_ID="${BASH_REMATCH[1]}"
    VERSION="${BASH_REMATCH[2]}"

    # Compare versions and keep the latest
    CURRENT_VERSION="${latest_versions[$PACKAGE_ID]}"
    if [[ -z "$CURRENT_VERSION" || "$VERSION" > "$CURRENT_VERSION" ]]; then
      latest_versions["$PACKAGE_ID"]="$VERSION"
      package_paths["$PACKAGE_ID"]="$PACKAGE"
    fi
  else
    # If the filename doesn't match the expected pattern, print a warning
    echo "⚠️ Skipping unrecognized package filename format: $FILE_NAME"
  fi
done

# Now publish only the latest version for each package
echo "🚀 Starting to publish the latest versions of packages..."

for PACKAGE_ID in "${!package_paths[@]}"; do
  PACKAGE="${package_paths[$PACKAGE_ID]}"
  echo "🚀 Publishing $PACKAGE to GitHub Packages..."

  # Attempt to push the package and handle conflicts gracefully
  if ! dotnet nuget push "$PACKAGE" \
    --source "$NUGET_SOURCE" \
    --skip-duplicate \
    --api-key "$GITHUB_TOKEN"; then
    # If the push fails due to conflict, print a message and skip
    echo "⚠️ Package $PACKAGE has already been published. Skipping..."
  fi
done

echo "✅ All latest versions of the packages have been processed successfully!"
