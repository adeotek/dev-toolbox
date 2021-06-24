param ($oldIp, $newIp)
#Write-Host "oldIp: $oldIp"
#Write-Host "newIp: $newIp"

if ($null -eq $oldIp -or "" -eq $oldIp -or $null -eq $newIp -or "" -eq $newIp)
{
    exit
}

$hostsFile = "$env:SystemRoot\System32\drivers\etc\hosts"
#Write-Host "Replacing old IP [$oldIp] with new IP [$newIp] in host file..."
Start-Process powershell -ArgumentList "-Command (Get-Content $hostsFile).replace('$oldIp','$newIp') | Set-Content $hostsFile" -Verb runAs -Wait
