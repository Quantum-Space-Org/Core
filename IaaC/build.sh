#!/bin/bash
set -e

PROJECT_PATH="../src"
CONFIG="Release"
OUTPUT_DIR="../build"

echo "🔨 Building $PROJECT_PATH..."
dotnet build "$PROJECT_PATH" --configuration $CONFIG

echo "📦 Packing..."
dotnet pack "$PROJECT_PATH" --configuration $CONFIG --output $OUTPUT_DIR
