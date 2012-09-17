Get-ChildItem -Include bin,obj -Recurse | ? { $_.PsIsContainer -eq $true } | foreach ($_) {
    Write-Host -ForegroundColor 'yellow' "Removing: $_"
    Remove-Item $_ -Recurse -Force -ErrorAction Continue
}
Write-Host -ForegroundColor 'yellow' "Removing: .\packages"
Remove-Item .\packages -Recurse -Force -ErrorAction Continue
