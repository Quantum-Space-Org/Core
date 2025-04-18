#!/bin/bash
set -e

# Move to the repo root (assuming this script is in ./IaaC)
cd "$(dirname "$0")/.."

CONFIG="Release"
OUTPUT_DIR="build"

echo "🔨 Building solution in $(pwd) ..."
dotnet build Quantum.Core.sln --configuration $CONFIG

echo "📦 Packing..."
dotnet pack Quantum.Core.sln --configuration $CONFIG --output $OUTPUT_DIR
