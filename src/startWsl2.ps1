### Read input params
param ($wslDistro, $wslHostname)
# Write-Host "wslDistro: $wslDistro"

if ($null -eq $wslDistro -or '' -eq $wslDistro) {
    Write-Host "ERROR: WSL distro not specified or invalid ([-wslDistro] param)!"
    exit
}

if ($null -eq $wslHostname -or "" -eq $wslHostname) {
    $wslHostname = "wslhost"
}
$hostsFile = "$env:SystemRoot\System32\drivers\etc\hosts"
$oldIp = ""

#Write-Host "Starting $wslDistro..."
$wslIp = (wsl -d $wslDistro hostname -I | Out-String).Trim()

$oldIpLine = Select-String -Path $hostsFile -Pattern $wslHostname | Select-Object Line
$lineBits = [regex]::Split($oldIpLine.Line, "\s+")
if ($lineBits.count -eq 2) {
    $oldIp = $lineBits[0];
    if ($oldIp.SubString(0,1) -eq "#") {
        $oldIp = $oldIp.SubString(1).Trim()
    }
}

if ($wslIp -ne "" -and $oldIp -ne "") {
#    Write-Host "Replacing old IP [$oldIp] with new IP [$wslIp]..."
#    (Get-Content $hostsFile).replace($oldIp,$wslIp) | Set-Content $hostsFile
    Start-Process pwsh -ArgumentList "-Command (Get-Content $hostsFile).replace('$oldIp','$wslIp') | Set-Content $hostsFile" -Verb runAs -Wait
}

#Write-Host "WSL2 Started."
# Read-Host -Prompt "Press Enter to exit"