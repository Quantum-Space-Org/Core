#!/bin/bash
set -e

# Move to the repo root (assuming this script is in ./IaaC)
cd "$(dirname "$0")/.."

NUGET_SOURCE="https://nuget.pkg.github.com/Quantum-Space-Org/index.json"

# Declare associative arrays
declare -A latest_versions
declare -A package_paths

echo "🔍 Searching for NuGet packages in ./build ..."

# Find all .nupkg files
PKG_LIST=$(find ./build -name "*.nupkg")

if [[ -z "$PKG_LIST" ]]; then
  echo "❌ No .nupkg files found in ./build"
  exit 1
else
  echo "✅ Found the following .nupkg files:"
  echo "$PKG_LIST"
fi

# Process each package
while IFS= read -r PACKAGE; do
  FILE_NAME=$(basename "$PACKAGE" .nupkg)

  # Use regex to split package name and version
  if [[ "$FILE_NAME" =~ ^(.+)-([0-9]+\.[0-9]+\.[0-9]+.*)$ ]]; then
    PACKAGE_ID="${BASH_REMATCH[1]}"
    VERSION="${BASH_REMATCH[2]}"

    CURRENT="${latest_versions[$PACKAGE_ID]}"
    if [[ -z "$CURRENT" || "$VERSION" > "$CURRENT" ]]; then
      latest_versions["$PACKAGE_ID"]="$VERSION"
      package_paths["$PACKAGE_ID"]="$PACKAGE"
    fi
  else
    echo "⚠️ Skipping unrecognized package filename format: $FILE_NAME"
  fi
done <<< "$PKG_LIST"

# Push only the latest versions
echo ""
echo "🚀 Starting to publish the latest versions of packages..."

for PACKAGE_ID in "${!package_paths[@]}"; do
  PACKAGE="${package_paths[$PACKAGE_ID]}"
  echo "📦 Publishing: $PACKAGE_ID (${latest_versions[$PACKAGE_ID]})"
  dotnet nuget push "$PACKAGE" \
    --source "$NUGET_SOURCE" \
    --api-key "$GITHUB_TOKEN"
done

echo ""
echo "✅ All packages published successfully."
