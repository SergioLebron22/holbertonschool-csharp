param (
    [string]$projectPath
)

if (-not (Test-Path $projectPath)) {
    Write-Host "Project path does not exist."
    dotnet new console -n $projectPath
    exit 1
}


# Build the project
dotnet build $projectPath

if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed."
    Pop-Location
    exit 1
}

# Run the project
dotnet run --project $projectPath