param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Debug",

    [switch]$Clean,

    [switch]$Publish,

    [string]$PublishDir,

    [switch]$Run
)

$ErrorActionPreference = "Stop"

$solution = Join-Path $PSScriptRoot "WindTown_VB\WindTown_VB.sln"
$project = Join-Path $PSScriptRoot "WindTown_VB\WindTown_VB.vbproj"
$projectName = [System.IO.Path]::GetFileNameWithoutExtension($project)

if (-not (Test-Path $solution)) {
    throw "Khong tim thay solution tai $solution"
}

if (-not (Test-Path $project)) {
    throw "Khong tim thay project tai $project"
}

try {
    $isSdkStyle = Select-String -Path $project -Pattern '<Project\s+Sdk=' -Quiet
}
catch {
    throw "Khong the doc file project: $project. $_"
}

if ($Publish -and $Run) {
    throw "Khong ho tro dung cung luc -Publish va -Run. Hay publish hoac build-va-run."
}

if (-not $PublishDir) {
    $PublishDir = Join-Path $PSScriptRoot "publish\$Configuration"
}

$resolvedPublishDir = $null

function Start-BuiltApplication {
    param(
        [string]$ProjectPath,
        [string]$BuildConfiguration
    )

    $projectDirectory = Split-Path -Parent $ProjectPath
    $projectBaseName = [System.IO.Path]::GetFileNameWithoutExtension($ProjectPath)
    $targetFramework = $null

    try {
        $targetFramework = Select-String -Path $ProjectPath -Pattern '<TargetFramework>(.+)</TargetFramework>' |
            ForEach-Object { $_.Matches[0].Groups[1].Value } |
            Select-Object -First 1
    }
    catch {
        throw "Khong the doc TargetFramework tu $ProjectPath. $_"
    }

    $candidatePaths = @()

    if ($targetFramework) {
        $candidatePaths += Join-Path $projectDirectory "bin\$BuildConfiguration\$targetFramework\$projectBaseName.exe"
    }

    $candidatePaths += Join-Path $projectDirectory "bin\$BuildConfiguration\$projectBaseName.exe"

    $appPath = $candidatePaths | Where-Object { Test-Path $_ } | Select-Object -First 1

    if (-not $appPath) {
        $appPath = Get-ChildItem -Path (Join-Path $projectDirectory "bin\$BuildConfiguration") -Filter "$projectBaseName.exe" -Recurse -ErrorAction SilentlyContinue |
            Select-Object -ExpandProperty FullName -First 1
    }

    if (-not $appPath) {
        throw "Build thanh cong nhung khong tim thay file chay .exe trong thu muc bin\$BuildConfiguration."
    }

    Write-Host "Dang chay app: $appPath"
    Start-Process -FilePath $appPath | Out-Null
}

function Invoke-ExternalCommand {
    param(
        [Parameter(Mandatory = $true)]
        [string]$FilePath,

        [Parameter(Mandatory = $true)]
        [string[]]$Arguments
    )

    & $FilePath @Arguments
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

if ($isSdkStyle) {
    $dotnet = Get-Command dotnet -ErrorAction SilentlyContinue
    if (-not $dotnet) {
        throw "Khong tim thay dotnet CLI. Vui long cai .NET SDK."
    }

    if ($Clean) {
        Invoke-ExternalCommand -FilePath $dotnet.Source -Arguments @("clean", $solution, "-c", $Configuration)
    }

    if ($Publish) {
        $resolvedPublishDir = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($PublishDir)
        Invoke-ExternalCommand -FilePath $dotnet.Source -Arguments @("publish", $project, "-c", $Configuration, "-o", $resolvedPublishDir)
        Write-Host "Publish xong tai: $resolvedPublishDir"
        exit 0
    }

    Invoke-ExternalCommand -FilePath $dotnet.Source -Arguments @("build", $solution, "-c", $Configuration)

    if ($Run) {
        Start-BuiltApplication -ProjectPath $project -BuildConfiguration $Configuration
    }

    exit 0
}

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

if ($Clean) {
    Invoke-ExternalCommand -FilePath $msbuild -Arguments @($solution, "/t:Clean", "/p:Configuration=$Configuration", "/m")
}

if ($Publish) {
    $resolvedPublishDir = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($PublishDir)
    if (-not (Test-Path $resolvedPublishDir)) {
        New-Item -ItemType Directory -Path $resolvedPublishDir -Force | Out-Null
    }

    Invoke-ExternalCommand -FilePath $msbuild -Arguments @(
        $project,
        "/t:Publish",
        "/p:Configuration=$Configuration",
        "/p:PublishDir=$resolvedPublishDir\",
        "/m"
    )
    Write-Host "Publish xong tai: $resolvedPublishDir"
    exit 0
}

Invoke-ExternalCommand -FilePath $msbuild -Arguments @($solution, "/t:Build", "/p:Configuration=$Configuration", "/m")

if ($Run) {
    Start-BuiltApplication -ProjectPath $project -BuildConfiguration $Configuration
}

exit 0
