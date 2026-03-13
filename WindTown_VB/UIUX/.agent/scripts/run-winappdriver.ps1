# Script: Khoi dong WinAppDriver va mo app de kiem tra UI
# Yeu cau: WinAppDriver da duoc cai tai "C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe"

$winAppDriverPath = "C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe"
$appPath = "d:\FTC\Visual_BasicNet\WindTown\WindTown_VB\bin\Debug\WindTown_VB.exe"

if (-not (Test-Path $winAppDriverPath)) {
    Write-Host "Khong tim thay WinAppDriver.exe tai: $winAppDriverPath"
    exit 1
}

if (-not (Test-Path $appPath)) {
    Write-Host "Khong tim thay app: $appPath"
    exit 1
}

Write-Host "Dang khoi dong WinAppDriver..."
$winAppDriverProcess = Start-Process -FilePath $winAppDriverPath -ArgumentList "127.0.0.1 4723/wd/hub" -PassThru
Start-Sleep -Seconds 2

Write-Host "Dang khoi dong app..."
$appProcess = Start-Process -FilePath $appPath -PassThru
Start-Sleep -Seconds 5

if ($appProcess.HasExited) {
    Write-Host "App da thoat som voi ma loi: $($appProcess.ExitCode)"
} else {
    Write-Host "App dang chay. Dong app de tranh khoa file build."
    Stop-Process -Id $appProcess.Id -Force
}

if ($winAppDriverProcess -and !$winAppDriverProcess.HasExited) {
    Write-Host "Dung WinAppDriver..."
    Stop-Process -Id $winAppDriverProcess.Id -Force
}

Write-Host "Hoan tat."
