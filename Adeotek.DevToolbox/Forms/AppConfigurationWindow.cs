using System;
using System.Collections.Generic;
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
        private List<AppTask> _tasks;
        private List<Scenario> _scenarios;

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
                // General
                AutoRunAtLogin.Checked = LoadRunAtLogin();
                AutoRunDefaultScenarioCheckBox.Checked = appConfiguration.RunDefaultScenarioOnStartup;
                AutoOpenMonitorCheckBox.Checked = appConfiguration.AutoOpenMonitor;
                DebugModeCheckBox.Checked = appConfiguration.Debug;
                //cbo
                // Tasks
                _tasks = appConfiguration.Tasks ?? new List<AppTask>();
                // Scenarios
                _scenarios = appConfiguration.Scenarios ?? new List<Scenario>();
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
            var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath)) ?? new JObject {{"Application", null}};
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
            // var originalConfiguration = jObject.TryGetValue("Application", out var config)
            //     ? JsonConvert.DeserializeObject<AppConfiguration>(config.ToString())
            //     : new AppConfiguration();

            var appConfiguration = new AppConfiguration
            {
                RunDefaultScenarioOnStartup = AutoRunDefaultScenarioCheckBox.Checked,
                AutoOpenMonitor = AutoOpenMonitorCheckBox.Checked,
                // DefaultScenario = 
                Debug = DebugModeCheckBox.Checked,
                Scenarios = _scenarios,
                Tasks = _tasks
            };
            
            jObject["Application"] = JObject.Parse(JsonConvert.SerializeObject(appConfiguration));
            File.WriteAllText(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));
            SetRunAtLogin(AutoRunAtLogin.Checked);

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

                if (value)
                {
                    key.SetValue(RegistryValueKey, Application.ExecutablePath);
                }
                else
                {
                    key.DeleteValue(RegistryValueKey);
                }
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
