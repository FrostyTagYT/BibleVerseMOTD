$ErrorActionPreference = "Stop"

$projectDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$gorillaTag = if ($env:GORILLA_TAG_PATH) { $env:GORILLA_TAG_PATH } else { "C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag" }
$version = "1.2.1"
$distDir = Join-Path $projectDir "dist"
$packageName = "BibleVerseMOTD-FullInstall-v$version"
$packageDir = Join-Path $distDir $packageName
$zipPath = Join-Path $distDir "$packageName.zip"

if (-not (Test-Path (Join-Path $gorillaTag "Gorilla Tag.exe"))) {
    throw "Gorilla Tag not found at '$gorillaTag'. Set GORILLA_TAG_PATH."
}

Write-Host "Building mod DLL..."
Push-Location $projectDir
dotnet build -c Release | Out-Null
Pop-Location

if (Test-Path $packageDir) { Remove-Item $packageDir -Recurse -Force }
if (Test-Path $zipPath) { Remove-Item $zipPath -Force }
New-Item -ItemType Directory -Force -Path $packageDir | Out-Null

# Game root loader files
$rootFiles = @("winhttp.dll", "doorstop_config.ini", "changelog.txt", ".doorstop_version")
foreach ($file in $rootFiles) {
    $source = Join-Path $gorillaTag $file
    if (Test-Path $source) {
        Copy-Item $source (Join-Path $packageDir $file) -Force
    }
}

# BepInEx core
$coreSource = Join-Path $gorillaTag "BepInEx\core"
$coreDest = Join-Path $packageDir "BepInEx\core"
New-Item -ItemType Directory -Force -Path $coreDest | Out-Null
Copy-Item (Join-Path $coreSource "*") $coreDest -Recurse -Force

# Plugins
$pluginsDest = Join-Path $packageDir "BepInEx\plugins"
New-Item -ItemType Directory -Force -Path $pluginsDest | Out-Null
Copy-Item (Join-Path $projectDir "bin\Release\netstandard2.1\BibleVerseMOTD.dll") $pluginsDest -Force
Copy-Item (Join-Path $gorillaTag "BepInEx\plugins\Utilla.dll") $pluginsDest -Force

# Config
$configDest = Join-Path $packageDir "BepInEx\config"
New-Item -ItemType Directory -Force -Path $configDest | Out-Null
Copy-Item (Join-Path $gorillaTag "BepInEx\config\BepInEx.cfg") $configDest -Force
Copy-Item (Join-Path $projectDir "config\com.frostytagyt.bibleversemotd.cfg") (Join-Path $configDest "com.frostytagyt.bibleversemotd.cfg") -Force

# Docs in package
Copy-Item (Join-Path $projectDir "INSTALL.md") (Join-Path $packageDir "INSTALL.md") -Force
Copy-Item (Join-Path $projectDir "CREDITS.md") (Join-Path $packageDir "CREDITS.md") -Force
Copy-Item (Join-Path $projectDir "README.md") (Join-Path $packageDir "README.md") -Force

@"
Bible Verse MOTD - Full Install Package v$version
Made by FrostyTagYT
https://github.com/FrostyTagYT/BibleVerseMOTD
=================================================

1. Close Gorilla Tag
2. Extract ALL files in this zip into your Gorilla Tag folder
   (the folder that contains Gorilla Tag.exe)
3. Choose overwrite/merge when Windows asks
4. Launch Gorilla Tag and go to the stump

Included:
- BepInEx 5.4.23.5
- Utilla 1.7.0
- Bible Verse MOTD $version

See INSTALL.md for details.
"@ | Set-Content (Join-Path $packageDir "START_HERE.txt") -Encoding UTF8

Compress-Archive -Path $packageDir -DestinationPath $zipPath -Force

Write-Host "Created: $zipPath"
Write-Host "Package folder: $packageDir"