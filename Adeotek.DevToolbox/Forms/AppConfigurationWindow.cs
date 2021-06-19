using System;
using System.IO;
using System.Windows.Forms;
using Adeotek.DevToolbox.Common;
using Adeotek.DevToolbox.Models;
using Adeotek.DevToolbox.Models.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Adeotek.DevToolbox.Forms
{
    public partial class AppConfigurationWindow : Form
    {
        private const string RegistryRunPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private const string RegistryValueKey = "AdeoTEK DEV Toolbox";
        private readonly AppSessionContext _context;
        private readonly EventsAggregator _eventsAggregator;
        private readonly ILogger _logger;

        public AppConfigurationWindow(
            AppSessionContext context,
            EventsAggregator eventsAggregator,
            ILogger logger)
        {
            _context = context;
            _eventsAggregator = eventsAggregator;
            _logger = logger;
            InitializeComponent();
            ConfigureComponents();
        }

        private void ConfigureComponents()
        {
            try
            {
                var appConfiguration = LoadConfigurationData();
                // Application
                DebugModeCheckBox.Checked = appConfiguration.Debug;
                // AutoStartWorkersCheckBox.Checked = appConfiguration.AutoStartWorkers;
                // AutoStartMonitorCheckBox.Checked = appConfiguration.AutoStartMonitor;
            }
            catch (Exception e)
            {
                _logger?.LogError(e, "LoadConfigurationData exception");
                MessageBox.Show(e.Message);
                Close();
            }
        }

        private AppConfiguration LoadConfigurationData()
        {
            var physicalPath = Path.Combine(_context.AppPath, "appsettings.json");
            if (!File.Exists(physicalPath))
            {
                throw new Exception($"Invalid or missing configuration file [{physicalPath}]!");
            }
            var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath));
            return jObject.TryGetValue("Application", out var config)
                ? JsonConvert.DeserializeObject<AppConfiguration>(config.ToString())
                : new AppConfiguration();
        }

        private void SaveConfiguration()
        {
            var physicalPath = Path.Combine(_context.AppPath, "appsettings.json");
            if (!File.Exists(physicalPath))
            {
                throw new Exception($"Invalid or missing configuration file [{physicalPath}]!");
            }
            var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath)) ?? new JObject {{"Application", null}};
            var originalConfiguration = jObject.TryGetValue("Application", out var config)
                ? JsonConvert.DeserializeObject<AppConfiguration>(config.ToString())
                : new AppConfiguration();

            var appConfiguration = new AppConfiguration
            {
                Debug = DebugModeCheckBox.Checked,
                // AutoStartWorkers = AutoStartWorkersCheckBox.Checked,
                // AutoStartMonitor = AutoStartMonitorCheckBox.Checked,
            };
            
            jObject["Application"] = JObject.Parse(JsonConvert.SerializeObject(appConfiguration));
            File.WriteAllText(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));

            _context.LoadAppConfiguration(appConfiguration);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _logger?.LogDebug("Save modified configuration...");
            try
            {
                SaveConfiguration();
                _logger?.LogDebug("Configuration changes saved");
                _eventsAggregator.OnContextChangeHandle(new AppContextChangedEventArgs { ConfigurationChanged = true });
                Close();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "SaveConfiguration exception");
                ErrorMessageLabel.Text = ex.Message;
            }
        }

        private void SetRunAtLogin(bool value)
        {
            try
            {
                var key = Registry.CurrentUser.OpenSubKey(RegistryRunPath, true);
                if (key == null)
                {
                    throw new Exception($@"Invalid registry key: [Computer\HKEY_CURRENT_USER\{RegistryRunPath}]");
                }
                key.SetValue(RegistryValueKey, Application.ExecutablePath);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "SetRunAtLogin [{Value}] exception: {Message}", value.ToString(), e.Message);
            }
        }
        
        private bool LoadRunAtLogin()
        {
            try
            {
                var key = Registry.CurrentUser.OpenSubKey(RegistryRunPath, true);
                if (key == null)
                {
                    throw new Exception($@"Invalid registry key: [Computer\HKEY_CURRENT_USER\{RegistryRunPath}]");
                }

                var value = key.GetValue(RegistryValueKey);
                return Application.ExecutablePath.Equals(value?.ToString() ?? string.Empty, StringComparison.InvariantCultureIgnoreCase);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "LoadRunAtLogin exception: {Message}", e.Message);
                MessageBox.Show($@"LoadRunAtLogin exception: {e.Message}");
                return false;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
