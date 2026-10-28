foreach ($pidVal in @(18792, 21664)) {
    $proc = Get-Process -Id $pidVal -ErrorAction SilentlyContinue
    if ($proc) {
        Write-Host "PID $pidVal : CPU=$($proc.CPU), Responding=$($proc.Responding)"
        $threads = $proc.Threads
        foreach ($t in $threads) {
            Write-Host "  Thread $($t.Id): State=$($t.ThreadState), WaitReason=$($t.WaitReason)"
        }
    }
}
