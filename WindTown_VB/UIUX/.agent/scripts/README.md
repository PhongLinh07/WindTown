# Scripts quan ly WinAppDriver

## run-winappdriver.ps1
- Khoi dong WinAppDriver va mo app de kiem tra UI.
- Tu dong dong app va WinAppDriver de tranh khoa file build.

## run-ui-scan.ps1
- Quet UI bang WinAppDriver de phat hien chong lap.
- Tao bao cao JSON va Markdown tai `UIUX/.agent/scripts/`.

## Cach dung
```powershell
PowerShell -ExecutionPolicy Bypass -File "WindTown_VB\UIUX\.agent\scripts\run-winappdriver.ps1"
PowerShell -ExecutionPolicy Bypass -File "WindTown_VB\UIUX\.agent\scripts\run-ui-scan.ps1"
```
