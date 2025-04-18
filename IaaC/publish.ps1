# Exit on error
$ErrorActionPreference = "Stop"

# Find the .nupkg file in the build directory
$PACKAGE_PATH = Get-ChildItem -Path "../build" -Filter "*.nupkg" | Select-Object -First 1

if ($null -eq $PACKAGE_PATH) {
    Write-Host "❌ No .nupkg file found in ../build"
    exit 1
}

Write-Host "🚀 Publishing $PACKAGE_PATH to GitHub Packages..."
dotnet nuget push $PACKAGE_PATH.FullName `
  --source "github" `
  --api-key "$env:GITHUB_TOKEN"
