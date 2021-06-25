param ($serviceName, $action)
#Write-Host "serviceName: $serviceName"
#Write-Host "action: $action"

$service = Get-CimInstance win32_service | Where-Object Name -eq $serviceName
#Write-Host "Service status [$serviceName]: $($service.State)"

if ($null -eq $action -or $action.ToLower() -eq "start") {
    if ($service.State -ne 'Stopped') {
        exit
    }
    Start-Process pwsh -ArgumentList "-Command Start-Service '$serviceName'" -Verb runAs -Wait
} elseif($action.ToLower() -eq "stop") {
    if ($service.State -eq 'Stopped') {
        exit
    }
    Start-Process pwsh -ArgumentList "-Command Stop-Service '$serviceName'" -Verb runAs -Wait
} elseif($action.ToLower() -eq "restart") {
    if ($service.State -eq 'Stopped') {
        Start-Process pwsh -ArgumentList "-Command Start-Service '$serviceName'" -Verb runAs -Wait
    } else {
        Start-Process pwsh -ArgumentList "-Command Restart-Service '$serviceName'" -Verb runAs -Wait
    }
}
