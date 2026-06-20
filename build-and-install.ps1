$ErrorActionPreference = "Stop"

$projectDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$gorillaTag = if ($env:GORILLA_TAG_PATH) { $env:GORILLA_TAG_PATH } else { "C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag" }
$pluginsDir = Join-Path $gorillaTag "BepInEx\plugins"

if (-not (Test-Path (Join-Path $gorillaTag "Gorilla Tag.exe"))) {
    throw "Gorilla Tag not found at '$gorillaTag'. Set GORILLA_TAG_PATH to your install folder."
}

Push-Location $projectDir
try {
    dotnet build -c Release
    $dll = Join-Path $projectDir "bin\Release\netstandard2.1\BibleVerseMOTD.dll"
    if (-not (Test-Path $dll)) {
        throw "Build output not found at $dll"
    }

    New-Item -ItemType Directory -Force -Path $pluginsDir | Out-Null
    Copy-Item $dll (Join-Path $pluginsDir "BibleVerseMOTD.dll") -Force
    Write-Host "Installed BibleVerseMOTD.dll to $pluginsDir"
}
finally {
    Pop-Location
}