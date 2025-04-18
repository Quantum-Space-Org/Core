#!/bin/bash
set -e

# Move to the repo root (assuming this script is in ./IaaC)
cd "$(dirname "$0")/.."

NUGET_SOURCE="https://nuget.pkg.github.com/Quantum-Space-Org/index.json"

# Gather all .nupkg files and extract package name/version
declare -A latest_versions

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
  fi
done < <(find ./build -name "*.nupkg")

# Push only the latest versions
for PACKAGE_ID in "${!package_paths[@]}"; do
  PACKAGE="${package_paths[$PACKAGE_ID]}"
  echo "🚀 Publishing $PACKAGE to GitHub Packages..."
  dotnet nuget push "$PACKAGE" \
    --source "$NUGET_SOURCE" \
    --api-key "$GITHUB_TOKEN"
done
