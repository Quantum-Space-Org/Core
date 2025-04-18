#!/bin/bash
set -e

# Move to the repo root (assuming this script is in ./IaaC)
cd "$(dirname "$0")/.."

NUGET_SOURCE="https://nuget.pkg.github.com/Quantum-Space-Org/index.json"

# Collect and process all .nupkg files
find ./build -name "*.nupkg" | while read -r PACKAGE; do
  # Extract the file name without extension
  FILE_NAME=$(basename "$PACKAGE" .nupkg)

  # Split into package ID and version (by last dot before version)
  PACKAGE_ID="${FILE_NAME%.*}"
  VERSION="${FILE_NAME##*.}"

  echo "$PACKAGE_ID,$VERSION,$PACKAGE"
done | sort -t',' -k1,1 -k2,2V | uniq -f0 --check-chars=100 --all-repeated=separate | awk -F',' '{ seen[$1]=$3 } END { for (p in seen) print seen[p] }' | while read -r PACKAGE; do
  echo "🚀 Publishing $PACKAGE to GitHub Packages..."
  dotnet nuget push "$PACKAGE" \
    --source "$NUGET_SOURCE" \
    --api-key "$GITHUB_TOKEN"
done