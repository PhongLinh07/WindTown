$ErrorActionPreference = "Stop"

$solution = Join-Path $PSScriptRoot "WindTown_VB\WindTown_VB.sln"
$vswhere = Join-Path ${env:ProgramFiles(x86)} "Microsoft Visual Studio\Installer\vswhere.exe"

if (-not (Test-Path $vswhere)) {
    throw "Khong tim thay vswhere.exe. Vui long cai Visual Studio Build Tools/VS."
}

$vsInstall = & $vswhere -latest -products * -requires Microsoft.Component.MSBuild -property installationPath
if (-not $vsInstall) {
    throw "Khong tim thay Visual Studio co MSBuild."
}

$msbuild = Join-Path $vsInstall "MSBuild\Current\Bin\MSBuild.exe"
if (-not (Test-Path $msbuild)) {
    throw "Khong tim thay MSBuild.exe tai $msbuild"
}

& $msbuild $solution /t:Build /p:Configuration=Debug /m
