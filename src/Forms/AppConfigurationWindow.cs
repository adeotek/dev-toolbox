using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private const string X64RegistryRunPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run";
        private const string RegistryValueKey = "AdeoTEK DEV Toolbox";
        private readonly AppSessionContext _context;
        private readonly EventsAggregator _eventsAggregator;
        private readonly ILogger _logger;
        private List<AppTask> _tasks;
        private List<Scenario> _scenarios;
        private AddScenarioWindow _scenarioWindow;
        private AddTaskWindow _taskWindow;

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
            ErrorMessageLabel.Text = string.Empty;
            try
            {
                var appConfiguration = LoadConfigurationData();
                // Tasks
                _tasks = appConfiguration.Tasks ?? new List<AppTask>();
                // Scenarios
                _scenarios = appConfiguration.Scenarios ?? new List<Scenario>();
                // General
                AutoRunAtLoginCheckBox.Checked = LoadRunAtLogin();
                AutoRunDefaultScenarioCheckBox.Checked = appConfiguration.RunDefaultScenarioOnStartup;
                AutoOpenMonitorCheckBox.Checked = appConfiguration.AutoOpenMonitor;
                DebugModeCheckBox.Checked = appConfiguration.Debug;
                // DefaultScenario               
                DefaultScenarioComboBox.DataSource = _scenarios;
                DefaultScenarioComboBox.ValueMember = "Guid";
                DefaultScenarioComboBox.DisplayMember = "Name";
                DefaultScenarioComboBox.SelectedValue = appConfiguration.DefaultScenario;
                // Tasks
                TasksDataGridView.DataSource = _tasks;
                TasksDataGridView.CellClick += TasksDataGridViewCellClick;
                TasksDataGridView.Columns["Guid"].Visible = false;
                TasksDataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TasksDataGridView.Columns["Type"].ReadOnly = true;
                TasksDataGridView.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                TasksDataGridView.Columns["IsActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                TasksDataGridView.Columns["IsShortcut"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                TasksDataGridView.Columns["Arguments"].Visible = false;
                TasksDataGridView.Columns["TypeAsEnum"].Visible = false;
                TasksDataGridView.Columns["EditButtonText"].Visible = false;
                TasksDataGridView.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "TaskEditButton",
                    HeaderText = @"...",
                    DataPropertyName = "EditButtonText",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                });
                // Scenarios
                ScenariosDataGridView.DataSource = _scenarios;
                ScenariosDataGridView.CellClick += ScenariosDataGridViewCellClick;
                ScenariosDataGridView.Columns["Guid"].Visible = false;
                ScenariosDataGridView.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ScenariosDataGridView.Columns["IsActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                ScenariosDataGridView.Columns["EditButtonText"].Visible = false;
                ScenariosDataGridView.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "ScenarioEditButton",
                    HeaderText = @"...",
                    DataPropertyName = "EditButtonText",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                });
            }
            catch (Exception e)
            {
                _logger?.LogError(e, "LoadConfigurationData exception: {Message}", e.Message);
                MessageBox.Show(e.Message);
                Close();
            }
        }

        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            ShowAddTaskWindow();
        }

        private void AddScenarioButton_Click(object sender, EventArgs e)
        {
            ShowAddScenarioWindow();
        }

        private void TasksDataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TasksDataGridView.Columns[e.ColumnIndex].Name != "TaskEditButton")
            {
                return;
            }

            try
            {
                var guid = (Guid) TasksDataGridView.Rows[e.RowIndex].Cells[0].Value;
                var task = _tasks.FirstOrDefault(t => t.Guid == guid);
                ShowAddTaskWindow(task);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "TasksDataGridViewCellClick exception: {Message}", ex.Message);
            }
        }

        private void ScenariosDataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ScenariosDataGridView.Columns[e.ColumnIndex].Name != "ScenarioEditButton")
            {
                return;
            }
            
            try
            {
                var guid = (Guid) ScenariosDataGridView.Rows[e.RowIndex].Cells[0].Value;
                var scenario = _scenarios.FirstOrDefault(s => s.Guid == guid);
                ShowAddScenarioWindow(scenario);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "ScenariosDataGridViewCellClick exception: {Message}", ex.Message);
            }
        }

        private void ShowAddTaskWindow(AppTask task = null)
        {
            if (_taskWindow == null || _taskWindow.IsDisposed)
            {
                _taskWindow = new AddTaskWindow(task, _logger);
                _taskWindow.OnSave += OnTaskSaveHandle;
                _taskWindow.Show();
            }
            else
            {
                if (_taskWindow.WindowState != FormWindowState.Normal &&
                    _taskWindow.WindowState != FormWindowState.Maximized)
                {
                    _taskWindow.WindowState = FormWindowState.Normal;
                }
                _taskWindow.Activate();
            }
        }
        
        private void ShowAddScenarioWindow(Scenario scenario = null)
        {
            if (_scenarioWindow == null || _scenarioWindow.IsDisposed)
            {
                _scenarioWindow = new AddScenarioWindow(scenario, _context, _logger);
                _scenarioWindow.OnSave += OnScenarioSaveHandle;
                _scenarioWindow.Show();
            }
            else
            {
                if (_scenarioWindow.WindowState != FormWindowState.Normal &&
                    _scenarioWindow.WindowState != FormWindowState.Maximized)
                {
                    _scenarioWindow.WindowState = FormWindowState.Normal;
                }
                _scenarioWindow.Activate();
            }
        }

        private void OnTaskSaveHandle(SaveTaskEventArgs e)
        {
            try
            {
                if (!e.IsEdit)
                {
                    _tasks.Add(e.Data);
                    return;
                }
                
                var task = _tasks.FirstOrDefault(t => t.Guid == e.Data.Guid);
                if (task == null)
                {
                    _tasks.Add(e.Data);
                }
                else
                {
                    task.Name = e.Data.Name;
                    task.IsActive = e.Data.IsActive;
                    task.IsShortcut = e.Data.IsShortcut;
                    task.Arguments = e.Data.Arguments;
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "OnTaskSaveHandle exception: {Message}", ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        
        private void OnScenarioSaveHandle(SaveScenarioEventArgs e)
        {
            try
            {
                if (!e.IsEdit)
                {
                    _scenarios.Add(e.Data);
                    return;
                }

                var scenario = _scenarios.FirstOrDefault(s => s.Guid == e.Data.Guid);
                if (scenario == null)
                {
                    _scenarios.Add(e.Data);
                }
                else
                {
                    scenario.Name = e.Data.Name;
                    scenario.IsActive = e.Data.IsActive;
                    scenario.Tasks = e.Data.Tasks;
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "OnScenarioSaveHandle exception: {Message}", ex.Message);
                MessageBox.Show(ex.Message);
            }
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
                _logger?.LogError(ex, "SaveConfiguration exception: {Message}", ex.Message);
                ErrorMessageLabel.Text = ex.Message;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Load/Save Data
        private AppConfiguration LoadConfigurationData()
        {
            var physicalPath = Path.Combine(_context.AppPath, "appsettings.json");
            if (!File.Exists(physicalPath))
            {
                throw new Exception($"Invalid or missing configuration file [{physicalPath}]!");
            }
            var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath)) ?? new JObject { { "Application", null } };
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
            var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath)) ?? new JObject { { "Application", null } };
            // var originalConfiguration = jObject.TryGetValue("Application", out var config)
            //     ? JsonConvert.DeserializeObject<AppConfiguration>(config.ToString())
            //     : new AppConfiguration();

            var appConfiguration = new AppConfiguration
            {
                RunDefaultScenarioOnStartup = AutoRunDefaultScenarioCheckBox.Checked,
                AutoOpenMonitor = AutoOpenMonitorCheckBox.Checked,
                DefaultScenario = (Guid)(DefaultScenarioComboBox.SelectedValue ?? Guid.Empty),
                Debug = DebugModeCheckBox.Checked,
                Scenarios = _scenarios,
                Tasks = _tasks
            };

            jObject["Application"] = JObject.Parse(JsonConvert.SerializeObject(appConfiguration));
            File.WriteAllText(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));
            SetRunAtLogin(AutoRunAtLoginCheckBox.Checked);

            _context.LoadAppConfiguration(appConfiguration);
        }

        private void SetRunAtLogin(bool value)
        {
            try
            {
                var key = GetStartUpRegistryKey(true);
                if (value)
                {
                    key.SetValue(RegistryValueKey, $"\"{Application.ExecutablePath}\"");
                }
                else if (key.GetValue(RegistryValueKey) != null)
                {
                    key.DeleteValue(RegistryValueKey);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "SetRunAtLogin {Value} to [{ValueName}] exception: {Message}", value.ToString(), RegistryValueKey, e.Message);
            }
        }

        private bool LoadRunAtLogin()
        {
            try
            {
                var key = GetStartUpRegistryKey();
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

        private RegistryKey GetStartUpRegistryKey(bool writable = false)
        {
            var x64Key = Registry.LocalMachine.OpenSubKey(X64RegistryRunPath ,writable);
            var key = x64Key ?? Registry.CurrentUser.OpenSubKey(RegistryRunPath, writable);
            if (key == null)
            {
                throw new Exception($@"Invalid registry key: [{RegistryRunPath}]");
            }

            return key;
        }
        #endregion
    }
}
