# Script: Quet UI bang WinAppDriver de phat hien chong lap/che text
# Luu y: Can chay tren may co giao dien desktop

$duong_dan_winapp = "C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe"
$duong_dan_app = "d:\FTC\Visual_BasicNet\WindTown\WindTown_VB\bin\Debug\WindTown_VB.exe"
$thu_muc_bao_cao = "d:\FTC\Visual_BasicNet\WindTown\WindTown_VB\UIUX\.agent\scripts"
$tep_bao_cao_json = Join-Path $thu_muc_bao_cao "scan-report.json"
$tep_bao_cao_md = Join-Path $thu_muc_bao_cao "scan-report.md"
$winapp_da_khoi_dong = $false

if (-not (Test-Path $duong_dan_winapp)) {
    Write-Host "Khong tim thay WinAppDriver.exe tai: $duong_dan_winapp"
    exit 1
}

if (-not (Test-Path $duong_dan_app)) {
    Write-Host "Khong tim thay app: $duong_dan_app"
    exit 1
}

function KiemTraWinAppDriver {
    try {
        $trang_thai = Invoke-RestMethod -Method Get -Uri "http://127.0.0.1:4723/status" -TimeoutSec 3
        return $true
    } catch {
        return $false
    }
}

if (-not (KiemTraWinAppDriver)) {
    Write-Host "Dang khoi dong WinAppDriver..."
    Start-Process -FilePath $duong_dan_winapp -ArgumentList "127.0.0.1 4723/wd/hub" | Out-Null
    Start-Sleep -Seconds 2
    $winapp_da_khoi_dong = $true
}

if (-not (KiemTraWinAppDriver)) {
    Write-Host "Khong the ket noi WinAppDriver."
    exit 1
}

function TaoSession {
    Write-Host "Dang tao session..."
    $noi_dung_session = @{
        desiredCapabilities = @{
            app = $duong_dan_app
            platformName = "Windows"
            deviceName = "WindowsPC"
            newCommandTimeout = 120
        }
    } | ConvertTo-Json -Depth 4

    $session_moi = Invoke-RestMethod -Method Post -Uri "http://127.0.0.1:4723/session" -Body $noi_dung_session -ContentType "application/json"
    return $session_moi.sessionId
}

function TaoSessionTheoHandle {
    param([int]$handle)
    $handle_hex = $handle.ToString("x")
    $noi_dung_session = @{
        desiredCapabilities = @{
            appTopLevelWindow = $handle_hex
            platformName = "Windows"
            deviceName = "WindowsPC"
            newCommandTimeout = 120
        }
    } | ConvertTo-Json -Depth 4

    $session_moi = Invoke-RestMethod -Method Post -Uri "http://127.0.0.1:4723/session" -Body $noi_dung_session -ContentType "application/json"
    return $session_moi.sessionId
}

function ThuChuyenCheDoUI {
    param([string]$session_id)
    try {
        $tim_fontend = @{ using = "name"; value = "Fontend" } | ConvertTo-Json
        $pt_fontend = Invoke-RestMethod -Method Post -Uri "http://127.0.0.1:4723/session/$session_id/element" -Body $tim_fontend -ContentType "application/json"
        $id_fontend = $pt_fontend.value.ELEMENT
        if (-not $id_fontend) { $id_fontend = $pt_fontend.value.'element-6066-11e4-a52e-4f735466cecf' }
        if ($id_fontend) {
            Invoke-RestMethod -Method Post -Uri "http://127.0.0.1:4723/session/$session_id/element/$id_fontend/click" | Out-Null
            Start-Sleep -Seconds 2
        }
    } catch {
        # Neu khong tim thay nut, bo qua
    }
}

function LayDanhSachControl {
    param([string]$session_id)
    $noi_dung_phan_tu = @{ using = "xpath"; value = "//*" } | ConvertTo-Json
    return Invoke-RestMethod -Method Post -Uri "http://127.0.0.1:4723/session/$session_id/elements" -Body $noi_dung_phan_tu -ContentType "application/json"
}

function ChuanHoaChuoi {
    param([string]$gia_tri)
    if ([string]::IsNullOrWhiteSpace($gia_tri)) { return $gia_tri }
    $co_a = $gia_tri.IndexOf([char]0x00C3)
    $co_b = $gia_tri.IndexOf([char]0x00C4)
    $co_c = $gia_tri.IndexOf([char]0x00C2)
    $co_d = $gia_tri.IndexOf([char]0x00BA)
    $co_e = $gia_tri.IndexOf([char]0x00AD)
    if ($co_a -ge 0 -or $co_b -ge 0 -or $co_c -ge 0 -or $co_d -ge 0 -or $co_e -ge 0) {
        $bytes = [System.Text.Encoding]::GetEncoding(28591).GetBytes($gia_tri)
        return [System.Text.Encoding]::UTF8.GetString($bytes)
    }
    return $gia_tri
}

$tu_dong_chuyen = $true
$da_thu_lai = $false

while ($true) {
    $session_id = TaoSession
    if (-not $session_id) {
        Write-Host "Khong tao duoc session."
        exit 1
    }

    if ($tu_dong_chuyen) {
        Write-Host "Thu chuyen sang che do UI neu co..."
        ThuChuyenCheDoUI -session_id $session_id
        Start-Sleep -Seconds 1
    }

    Write-Host "Dang lay danh sach control..."
    try {
        $ds_phan_tu = LayDanhSachControl -session_id $session_id
        break
    } catch {
        if (-not $da_thu_lai) {
            Write-Host "Session bi dong, thu gan vao cua so chinh..."
            try {
                $process = Get-Process -Name "WindTown_VB" -ErrorAction SilentlyContinue | Select-Object -First 1
                if ($process -and $process.MainWindowHandle -ne 0) {
                    $session_id = TaoSessionTheoHandle -handle $process.MainWindowHandle
                    $ds_phan_tu = LayDanhSachControl -session_id $session_id
                    break
                }
            } catch {
                # Bo qua va thu lai
            }
        }
        if ($da_thu_lai) { throw }
        Write-Host "Khong gan duoc cua so chinh, thu tao session moi (bo qua chuyen che do)..."
        $da_thu_lai = $true
        $tu_dong_chuyen = $false
        continue
    }
}

$ket_qua = @()
foreach ($pt in $ds_phan_tu.value) {
    $id = $pt.ELEMENT
    if (-not $id) {
        $id = $pt.'element-6066-11e4-a52e-4f735466cecf'
    }
    if (-not $id) { continue }
    try {
        $vi_tri = Invoke-RestMethod -Method Get -Uri "http://127.0.0.1:4723/session/$session_id/element/$id/location"
        $kich_thuoc = Invoke-RestMethod -Method Get -Uri "http://127.0.0.1:4723/session/$session_id/element/$id/size"
    } catch {
        continue
    }
    $ten = Invoke-RestMethod -Method Get -Uri "http://127.0.0.1:4723/session/$session_id/element/$id/attribute/Name"
    $lop = Invoke-RestMethod -Method Get -Uri "http://127.0.0.1:4723/session/$session_id/element/$id/attribute/ClassName"

    if ($kich_thuoc.value.width -le 0 -or $kich_thuoc.value.height -le 0) { continue }

    $ten_gia_tri = ChuanHoaChuoi -gia_tri $ten.value
    $lop_gia_tri = $lop.value

    if ([string]::IsNullOrWhiteSpace($lop_gia_tri)) { continue }
    if ($lop_gia_tri -like "WindowsForms10.Window*") { continue }
    if ($ten_gia_tri -in @("Minimize", "Maximize", "Close", "System")) { continue }

    $ket_qua += [pscustomobject]@{
        id = $id
        ten = $ten_gia_tri
        lop = $lop_gia_tri
        x = [int]$vi_tri.value.x
        y = [int]$vi_tri.value.y
        w = [int]$kich_thuoc.value.width
        h = [int]$kich_thuoc.value.height
    }
}

Write-Host "Dang phan tich chong lap..."
$chong_lap = @()
for ($i = 0; $i -lt $ket_qua.Count; $i++) {
    for ($j = $i + 1; $j -lt $ket_qua.Count; $j++) {
        $a = $ket_qua[$i]
        $b = $ket_qua[$j]

        $x1 = [Math]::Max($a.x, $b.x)
        $y1 = [Math]::Max($a.y, $b.y)
        $x2 = [Math]::Min($a.x + $a.w, $b.x + $b.w)
        $y2 = [Math]::Min($a.y + $a.h, $b.y + $b.h)

        $w = $x2 - $x1
        $h = $y2 - $y1

        if ($w -gt 2 -and $h -gt 2) {
            $chong_lap += [pscustomobject]@{
                a = $a
                b = $b
                dien_tich = $w * $h
            }
        }
    }
}

$bao_cao = [pscustomobject]@{
    thoi_gian = (Get-Date).ToString("yyyy-MM-dd HH:mm:ss")
    so_control = $ket_qua.Count
    so_cap_chong_lap = $chong_lap.Count
    control_mau = $ket_qua | Select-Object -First 50
    chong_lap = $chong_lap | Sort-Object -Property dien_tich -Descending | Select-Object -First 50
}

Write-Host "Ghi bao cao..."
$bao_cao | ConvertTo-Json -Depth 6 | Out-File -FilePath $tep_bao_cao_json -Encoding UTF8

$md = @()
$md += "# Bao cao quet UI"
$md += ""
$md += "- Thoi gian: $($bao_cao.thoi_gian)"
$md += "- So control: $($bao_cao.so_control)"
$md += "- So cap chong lap: $($bao_cao.so_cap_chong_lap)"
$md += ""
$md += "## Control mau (toi da 50)"
if ($bao_cao.so_control -eq 0) {
    $md += "- Khong lay duoc control."
} else {
    foreach ($item in $bao_cao.control_mau) {
        $md += "- [$($item.lop)] '$($item.ten)' ($($item.x),$($item.y),$($item.w),$($item.h))"
    }
}
$md += ""
$md += "## Chong lap noi bat (toi da 50)"
if ($bao_cao.so_cap_chong_lap -eq 0) {
    $md += "- Khong phat hien chong lap."
} else {
    foreach ($item in $bao_cao.chong_lap) {
        $md += "- A: [$($item.a.lop)] '$($item.a.ten)' ($($item.a.x),$($item.a.y),$($item.a.w),$($item.a.h))"
        $md += "  B: [$($item.b.lop)] '$($item.b.ten)' ($($item.b.x),$($item.b.y),$($item.b.w),$($item.b.h)) | Dien tich: $($item.dien_tich)"
    }
}

$md | Out-File -FilePath $tep_bao_cao_md -Encoding UTF8

Write-Host "Dong session..."
Invoke-RestMethod -Method Delete -Uri "http://127.0.0.1:4723/session/$session_id" | Out-Null

Write-Host "Dong app..."
Get-Process -Name "WindTown_VB" -ErrorAction SilentlyContinue | Stop-Process -Force

if ($winapp_da_khoi_dong) {
    Write-Host "Dung WinAppDriver..."
    Get-Process -Name "WinAppDriver" -ErrorAction SilentlyContinue | Stop-Process -Force
}

Write-Host "Hoan tat. Bao cao: $tep_bao_cao_md"
