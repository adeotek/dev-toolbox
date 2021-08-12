using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Adeotek.DevToolbox.Common;
using Adeotek.DevToolbox.Forms;
using Adeotek.DevToolbox.Models.Events;
using Adeotek.DevToolbox.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Win32;
using Serilog;
using Serilog.Events;

namespace Adeotek.DevToolbox
{
    static class Program
    {
        private const string AppProcessName = "Adeotek.DevToolbox";
        private const string AppAlreadyStartedMessage = "The application is already running!";
        private const string AppCannotBeStartedMessage = "The application did not start correctly!{0}{1}";
        private const int SplashScreenDuration = 2000;
        private const string AppSettingsFileName = "appsettings.json";
        private const string UserSettingsFilePath = @".adeotek\DevToolbox";
        public const string UserSettingsFileName = "settings.json";

        private static EventsAggregator _eventsAggregator;
        private static TrayIcon _rootControl;
        private static string _environmentName;
        private static IConfiguration _configuration;
        private static string _appHash = "AdeoTEK-DEV-Toolbox-{0}";
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (Helpers.CheckIfAnotherInstanceIsRunning(AppProcessName))
            {
                MessageBox.Show(AppAlreadyStartedMessage);
                Log.Fatal("Application already running!");
                return;
            }
            
            _appHash = string.Format(_appHash, Assembly.GetExecutingAssembly().GetType().GUID.ToString());
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                var splashScreen = new SplashScreen(false);
                splashScreen.Show();
                splashScreen.Refresh();

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                LoadConfiguration(false, args);
                var host = CreateHostBuilder().Build();
                // Set SessionSwitch event handle
                SystemEvents.SessionSwitch += OnSessionSwitch;

                using (_rootControl = host.Services.GetRequiredService<TrayIcon>())
                {
                    stopwatch.Stop();
                    if (stopwatch.ElapsedMilliseconds < SplashScreenDuration)
                    {
                        Task.Delay(SplashScreenDuration - (int)stopwatch.ElapsedMilliseconds).Wait();
                    }
                    splashScreen.Close();

                    Log.Debug("Application initialized...");
                    Application.Run();
                }
                GC.KeepAlive(_rootControl);
            }
            catch (Exception ex)
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.File($"{AppProcessName}_errors.log",
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} - {Level:u3} - {Message:lj}{NewLine:1}{Exception:1}")
                    .CreateLogger();
                Log.Fatal(ex, "The web application application failed to start correctly");
                Log.CloseAndFlush();
                MessageBox.Show(string.Format(AppCannotBeStartedMessage, Environment.NewLine, ex.Message));
            }
        }
        
        private static IHostBuilder CreateHostBuilder()
            => Host.CreateDefaultBuilder().ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // Events aggregator
            _eventsAggregator = new EventsAggregator();
            services.AddSingleton(_eventsAggregator);
            // Configuration
            services.AddSingleton(_configuration);
            // Logger
            if (!Directory.Exists(Path.Combine(_configuration["UserSettingsPath"], "logs")))
            {
                Directory.CreateDirectory(Path.Combine(_configuration["UserSettingsPath"], "logs"));
            }
            var logMessages = new SerilogSinkEventsAggregator(_eventsAggregator);
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(_configuration)
                .WriteTo.Sink(logMessages, _configuration.GetValue<bool>("Application:Debug") ? LogEventLevel.Debug : LogEventLevel.Information)
                .CreateLogger();
            services.AddLogging(configure => configure.AddSerilog(logger, true));
            // Task related
            services.AddSingleton<WindowsActionsExecutor>();
            services.AddSingleton<TasksManager>();
            // Core components
            services.AddSingleton<AppSessionContext>();
            // UI components
            services.AddSingleton<TrayIcon>();
        }
        
        private static void LoadConfiguration(bool reload = false, string[] args = null)
        {
            if (reload || _configuration != null)
            {
                return;
            }

            if (args != null)
            {
                _environmentName = args
                    .Where(a => a.StartsWith("DOTNET_ENVIRONMENT="))
                    .Select(a => a.Replace("DOTNET_ENVIRONMENT=", ""))
                    .FirstOrDefault();
            }

            if (string.IsNullOrEmpty(_environmentName))
            {
                _environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
            }

            var userSettingsDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), UserSettingsFilePath);
            if (!Directory.Exists(userSettingsDirectoryPath))
            {
                Directory.CreateDirectory(userSettingsDirectoryPath);
            }

            var userSettingsFile = Path.Combine(userSettingsDirectoryPath, UserSettingsFileName);
            if (!File.Exists(userSettingsFile))
            {
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppSettingsFileName), userSettingsFile);
            }

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(userSettingsDirectoryPath)
                .AddJsonFile(UserSettingsFileName, optional: false, reloadOnChange: true);
            _configuration = configurationBuilder.Build();
            _configuration["AppPath"] = AppDomain.CurrentDomain.BaseDirectory;
            _configuration["UserSettingsPath"] = userSettingsDirectoryPath;
        }

        private static void OnSessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (_rootControl == null)
            {
                return;
            }

            var currentProcess = Process.GetCurrentProcess();
            var proc = (from p in Process.GetProcesses()
                        where p.ProcessName.StartsWith(AppProcessName)
                              && p.Id != currentProcess.Id && p.SessionId != currentProcess.SessionId
                        select p).FirstOrDefault();

            _eventsAggregator.OnWindowsSessionSwitchHandler(new WindowsSessionSwitchEventArgs
            {
                Reason = (WindowsSessionSwitchReasons)(int)e.Reason,
                IsMultiInstance = proc != null
            });
        }
    }
}