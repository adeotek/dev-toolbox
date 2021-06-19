using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using Adeotek.DevToolbox.Common;
using Adeotek.DevToolbox.Models;
using Microsoft.Extensions.Logging;

namespace Adeotek.DevToolbox.Tasks
{
    public class WindowsActionsExecutor
    {
        private const string HostsFileRelativePath = @"System32\drivers\etc\hosts";
        
        private readonly ILogger<WindowsActionsExecutor> _logger;
        private readonly string _windowsPath;

        public WindowsActionsExecutor(ILogger<WindowsActionsExecutor> logger)
        {
            _logger = logger;
            _windowsPath = Environment.GetEnvironmentVariable("windir");
        }
        
        public void LaunchApp(string executable, IEnumerable<string> args = null, string processName = null)
        {
            if (string.IsNullOrEmpty(executable))
            {
                throw new ArgumentException(@"Null or empty", nameof(executable));
            }
            
            if (!string.IsNullOrEmpty(processName) && Helpers.IsProcessRunning(processName))
            {
                throw new ApplicationAlreadyRunningException(processName);
            }

            var enumerable = args == null ? Array.Empty<string>() : args as string[] ?? args.ToArray();
            if (!enumerable.Any())
            {
                _logger.LogDebug("Launching app: {Executable}", executable);
                Process.Start(executable);
            }
            else
            {
                var arguments = string.Join(" ", enumerable.ToArray());
                _logger.LogDebug("Launching app: {Executable} with args: {Arguments}", executable, arguments);
                Process.Start(executable, arguments);
            }
        }

        public void LaunchApp(AppTask task)
        {
            if (!(task?.IsActive ?? false))
            {
                return;
            }
            
            if (task.Arguments == null)
            {
                throw new ArgumentNullException("Task.Arguments");
            }
            
            var executable = task.Arguments.ContainsKey("Executable") ? task.Arguments["Executable"] : null;
            var checkIfRunning = !task.Arguments.ContainsKey("CheckIfRunning") || task.Arguments["CheckIfRunning"]?.ToLower() == "true";
            var processName = checkIfRunning && task.Arguments.ContainsKey("ProcessName") ? task.Arguments["ProcessName"] : null;
            var arguments = task.Arguments.ContainsKey("Arguments") && !string.IsNullOrEmpty(task.Arguments["Arguments"]) 
                ? new [] {task.Arguments["Arguments"]} 
                : null;
            LaunchApp(executable, arguments, processName);
            _logger.LogInformation("App launched {AppName} with args {Arguments}", task.Arguments.ContainsKey("ProcessName") ? task.Arguments["ProcessName"] : processName ?? executable, string.Join(" ", arguments ?? Array.Empty<string>()));
        }

        public void StartWsl2(string distroName, string wslHostname)
        {
            if (string.IsNullOrEmpty(distroName))
            {
                throw new ArgumentException(@"Null or empty", nameof(distroName));
            }
            
            if (string.IsNullOrEmpty(wslHostname))
            {
                throw new ArgumentException(@"Null or empty", nameof(wslHostname));
            }
            
            var currentIpAddress = GetCommandOutput("wsl.exe", $"-d {distroName} hostname -I")?.ToList() ?? new List<string>();
            if (currentIpAddress.Count == 0)
            {
                throw new Exception($"Unable to start WSL {distroName}");
            }
            
            _logger.LogInformation("WSL {Distro} started with IP: {IpAddress}", distroName, currentIpAddress[0]);
            var hostsFile = Path.Combine(_windowsPath, HostsFileRelativePath);
            var hostsContent = File.ReadAllLines(hostsFile);
            var oldIpAddress = hostsContent.FirstOrDefault(l => l.Contains(wslHostname))?.Replace(wslHostname, string.Empty).Trim();
            
            if (string.IsNullOrWhiteSpace(oldIpAddress) || string.IsNullOrWhiteSpace(currentIpAddress[0]))
            {
                return;
            }

            var newHostsContent = hostsContent.Select(l => l.Contains(oldIpAddress) ? l.Replace(oldIpAddress, currentIpAddress[0]) : l).ToArray();
            File.WriteAllLines(hostsFile, newHostsContent);
            _logger.LogInformation("hosts file IP changed from {OldIp} to {NewIp}", oldIpAddress, currentIpAddress[0]);
        }
        
        public void StartWsl2(AppTask task)
        {
            if (!(task?.IsActive ?? false))
            {
                return;
            }
            
            if (task.Arguments == null)
            {
                throw new ArgumentNullException("Task.Arguments");
            }

            StartWsl2(task.Arguments.ContainsKey("DistroName") ? task.Arguments["DistroName"] : null, task.Arguments.ContainsKey("WslHostname") ? task.Arguments["WslHostname"] : null);
        }

        public void StartService(string serviceName)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                throw new ArgumentException(@"Null or empty", nameof(serviceName));
            }

            var service = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName.Equals(serviceName, StringComparison.InvariantCultureIgnoreCase));
            if (service == null)
            {
                throw new Exception($"Service {serviceName} does not exists");
            }
            
            _logger.LogDebug("Service {ServiceName} status: {Status}", serviceName, service.Status.ToString());
            if (service.Status == ServiceControllerStatus.Stopped)
            {
                service.Start();
            }
            else
            {
                _logger.LogDebug("Service {ServiceName} already running", serviceName);
            }
        }

        public void StartService(AppTask task)
        {
            if (!(task?.IsActive ?? false))
            {
                return;
            }
            
            if (task.Arguments == null)
            {
                throw new ArgumentNullException("Task.Arguments");
            }

            var serviceName = task.Arguments.ContainsKey("ServiceName") ? task.Arguments["ServiceName"] : null;
            StartService(serviceName);
            _logger.LogInformation("Service started {ServiceName}", serviceName);
        }
        
        public void ExecuteCommand(string executable, string arguments = null)
        {
            if (string.IsNullOrEmpty(executable))
            {
                throw new ArgumentException(@"Null or empty", nameof(executable));
            }
            
            using var p = new Process
            {
                // set start info
                StartInfo = new ProcessStartInfo(executable)
                {
                    // WorkingDirectory = @"C:\"
                    Arguments = arguments ?? string.Empty, 
                    RedirectStandardOutput = true,
                    UseShellExecute = false, 
                    CreateNoWindow = true
                }
            };
            // event handlers for output & error
            p.ErrorDataReceived += OnErrorDataReceived;
            p.OutputDataReceived += OnOutputDataReceived;
            _logger.LogInformation("Starting process: {Command}", $"{executable} {arguments}");
            // start process
            p.Start();
            p.BeginOutputReadLine();
            //wait
            p.WaitForExit();
            _logger.LogInformation("Process exited with code: {Code}", p.ExitCode.ToString());
            // p.Close();
        }
        
        public IEnumerable<string> GetCommandOutput(string executable, string arguments = null)
        {
            if (string.IsNullOrEmpty(executable))
            {
                throw new ArgumentException(@"Null or empty", nameof(executable));
            }
            
            var result = new List<string>();
            using var p = new Process
            {
                // set start info
                StartInfo = new ProcessStartInfo(executable)
                {
                    // WorkingDirectory = @"C:\"
                    Arguments = arguments ?? string.Empty, 
                    RedirectStandardOutput = true,
                    UseShellExecute = false, 
                    CreateNoWindow = true
                }
            };
            // start process
            p.Start();
            while (!p.StandardOutput.EndOfStream)
            {
                result.Add(p.StandardOutput.ReadLine());
            }
            //wait
            p.WaitForExit();
            
            // while(!p.HasExited)
            // {
            //     result.Add(p.StandardOutput.ReadToEnd());
            // }
            
            return result;
        }

        private void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
            {
                _logger.LogDebug("Error: null");
            }
            else
            {
                _logger.LogError("Error: {Data}", e.Data);
            }
        }

        private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
            {
                _logger.LogDebug("null");
            }
            else
            {
                _logger.LogInformation("{Data}", e.Data);
            }
        }
    }
}