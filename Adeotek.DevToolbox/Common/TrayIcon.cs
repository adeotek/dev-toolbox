using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Adeotek.DevToolbox.Forms;
using Adeotek.DevToolbox.Models;
using Adeotek.DevToolbox.Models.Events;

namespace Adeotek.DevToolbox.Common
{
    public class TrayIcon : Control
    {
        private const string DefaultTooltipTitle = "AdeoTEK DEV Toolbox";

        private delegate void NewUserMessageDelegate(LogEvent e);
        private readonly ILogger<TrayIcon> _logger;
        private readonly AppSessionContext _context;
        private readonly EventsAggregator _eventsAggregator;

        public TrayIcon(
            AppSessionContext context,
            EventsAggregator eventsAggregator,
            ILogger<TrayIcon> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _eventsAggregator = eventsAggregator ?? throw new ArgumentNullException(nameof(eventsAggregator));
            _eventsAggregator.OnApplicationClosing += OnApplicationClosingHandle;
            _eventsAggregator.OnOpenConfiguration += OnOpenConfigurationHandle;
            _eventsAggregator.OnNewUserMessage += OnNewUserMessageHandle;
            _logger = logger;
            InitializeComponent();
            ConfigureComponents();
            if (_context.AutoOpenMonitor)
            {
                ShowMonitorWindow();
            }

            if (!_context.RunDefaultScenarioOnStartup)
            {
                return;
            } 
            _context.ExecuteDefaultScenario();
        }

        // Forms
        private MonitorWindow _monitorWindow;
        private AppConfigurationWindow _configurationWindow;
        private SplashScreen _splashScreen;
        // Fixed Controls
        private NotifyIcon _trayIcon;
        private ContextMenuStrip _mainMenu;
        private ToolStripSeparator _menuSeparator0;
        private ToolStripSeparator _menuSeparator1;
        private ToolStripMenuItem _monitorMenuItem;
        private ToolStripSeparator _menuSeparator2;
        private ToolStripMenuItem _configurationMenuItem;
        private ToolStripMenuItem _aboutMenuItem;
        private ToolStripSeparator _menuSeparator3;
        private ToolStripMenuItem _exitMenuItem;
        // Dynamic controls
        private readonly Dictionary<string, ToolStripMenuItem> _dynamicMenuItems = new();

        private void InitializeComponent()
        {
            _trayIcon = new NotifyIcon();
            _mainMenu = new ContextMenuStrip();
            _menuSeparator0 = new ToolStripSeparator();
            _menuSeparator1 = new ToolStripSeparator();
            _monitorMenuItem = new ToolStripMenuItem();
            _menuSeparator2 = new ToolStripSeparator();
            _configurationMenuItem = new ToolStripMenuItem();
            _aboutMenuItem = new ToolStripMenuItem();
            _menuSeparator3 = new ToolStripSeparator();
            _exitMenuItem = new ToolStripMenuItem();
            _mainMenu.SuspendLayout();
            //
            // trayIcon
            //
            _trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            _trayIcon.BalloonTipText = "";
            _trayIcon.BalloonTipTitle = DefaultTooltipTitle;
            _trayIcon.ContextMenuStrip = _mainMenu;
            _trayIcon.Icon = Properties.Resources.LogoRound;
            _trayIcon.Text = DefaultTooltipTitle;
            _trayIcon.Visible = true;
            _trayIcon.DoubleClick += OnDoubleClick;
            //
            // mainMenu
            //
            _mainMenu.Name = "_mainMenu";
            _mainMenu.Size = new System.Drawing.Size(274, 110);
            //
            // tsmnuSeparator0
            //
            _menuSeparator0.Name = "_menuSeparator0";
            _menuSeparator0.Size = new System.Drawing.Size(270, 6);
            //
            // tsmnuSeparator1
            //
            _menuSeparator1.Name = "_menuSeparator1";
            _menuSeparator1.Size = new System.Drawing.Size(270, 6);
            //
            // tsmnuLog
            //
            _monitorMenuItem.Name = "_monitorMenuItem";
            _monitorMenuItem.Size = new System.Drawing.Size(273, 24);
            _monitorMenuItem.Text = @"Monitor";
            _monitorMenuItem.Click += OnMonitorViewMenuClick;
            //
            // tsmnuSeparator2
            //
            _menuSeparator2.Name = "_menuSeparator2";
            _menuSeparator2.Size = new System.Drawing.Size(270, 6);
            //
            // tsmnuConfig
            //
            _configurationMenuItem.Name = "_configurationMenuItem";
            _configurationMenuItem.Size = new System.Drawing.Size(273, 24);
            _configurationMenuItem.Text = @"Settings";
            _configurationMenuItem.Click += OnConfigurationMenuClick;
            //
            // _aboutMenuItem
            //
            _aboutMenuItem.Name = "_aboutMenuItem";
            _aboutMenuItem.Size = new System.Drawing.Size(273, 24);
            _aboutMenuItem.Text = @"About";
            _aboutMenuItem.Click += OnAboutMenuClick;
            //
            // tsmnuSeparator3
            //
            _menuSeparator3.Name = "_menuSeparator3";
            _menuSeparator3.Size = new System.Drawing.Size(270, 6);
            //
            // tsmnuExit
            //
            _exitMenuItem.Name = "_exitMenuItem";
            _exitMenuItem.Size = new System.Drawing.Size(273, 24);
            _exitMenuItem.Text = @"Exit";
            _exitMenuItem.Click += OnExitMenuClick;
            // Last
            _mainMenu.ResumeLayout(false);
        }

        private void ConfigureComponents()
        {
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            _trayIcon.BalloonTipText = $@"Version {currentVersion}";
            _trayIcon.Text = $@"{DefaultTooltipTitle}{Environment.NewLine}Version {currentVersion}";
            // Add scenarios to menu
            var scenarios = _context.Scenarios?.ToList() ?? new List<Scenario>();
            if (scenarios.Count > 0)
            {
                foreach (var scenario in scenarios.Where(s => (s?.IsActive ?? false) && !string.IsNullOrEmpty(s.Name)))
                {
                    _dynamicMenuItems.Add(scenario.Guid.ToString(), CreateToolStripMenuItem(scenario.Name, scenario.Guid, false));
                    _mainMenu.Items.Add(_dynamicMenuItems[scenario.Guid.ToString()]);
                }
                _mainMenu.Items.Add(_menuSeparator0);
            }
            // Add shortcut tasks to menu
            var tasks = _context.Tasks?.ToList() ?? new List<AppTask>();
            if (tasks.Count > 0)
            {
                foreach (var task in tasks.Where(t => (t?.IsActive ?? false) && !string.IsNullOrEmpty(t.Name) && t.IsShortcut))
                {
                    _dynamicMenuItems.Add(task.Guid.ToString(), CreateToolStripMenuItem(task.Name, task.Guid, true));
                    _mainMenu.Items.Add(_dynamicMenuItems[task.Guid.ToString()]);
                }
                _mainMenu.Items.Add(_menuSeparator1);
            }
            // Add menu fixed items
            _mainMenu.Items.AddRange(new ToolStripItem[] {
            _monitorMenuItem,
            _menuSeparator2,
            _configurationMenuItem,
            _aboutMenuItem,
            _menuSeparator3,
            _exitMenuItem});
        }

        private void ShowMonitorWindow()
        {
            if (_monitorWindow == null || _monitorWindow.IsDisposed)
            {
                _monitorWindow = new MonitorWindow(_context, _eventsAggregator, _logger);
                _monitorWindow.Show();
            }
            else
            {
                if (_monitorWindow.WindowState != FormWindowState.Normal &&
                    _monitorWindow.WindowState != FormWindowState.Maximized)
                {
                    _monitorWindow.WindowState = FormWindowState.Normal;
                }
                _monitorWindow.Activate();
            }
        }

        private void OnDoubleClick(object sender, EventArgs e)
        {
            ShowMonitorWindow();
        }

        private void OnMonitorViewMenuClick(object sender, EventArgs e)
        {
            ShowMonitorWindow();
        }

        private void OnConfigurationMenuClick(object sender, EventArgs e)
        {
            if (_configurationWindow == null || _configurationWindow.IsDisposed)
            {
                _configurationWindow = new AppConfigurationWindow(_context, _eventsAggregator, _logger);
                _configurationWindow.Show();
            }
            else
            {
                if (_configurationWindow.WindowState != FormWindowState.Normal &&
                    _configurationWindow.WindowState != FormWindowState.Maximized)
                {
                    _configurationWindow.WindowState = FormWindowState.Normal;
                }
                _configurationWindow.Activate();
            }
        }

        private void OnAboutMenuClick(object sender, EventArgs e)
        {
            if (_splashScreen == null || _splashScreen.IsDisposed)
            {
                _splashScreen = new SplashScreen(true);
                _splashScreen.Show();
            }
            else
            {
                _splashScreen.Activate();
            }
        }

        private void OnExitMenuClick(object sender, EventArgs e)
        {
            _logger?.LogDebug("Application close requested...");
            _eventsAggregator.OnApplicationClosingHandler(new ApplicationClosingEventArgs());
        }

        private void OnOpenConfigurationHandle(OpenConfigurationWindowEventArgs e)
        {
            if (e.OpenWindow)
            {
                OnConfigurationMenuClick(this, new EventArgs());
            }
        }

        private void OnNewUserMessageHandle(LogEvent e)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new NewUserMessageDelegate(OnNewUserMessageHandle), e);
                return;
            }

            if (e.Propagate)
            {
                _eventsAggregator?.PublishLogEvent(e);
            }

            switch (e.Level.ToUpper())
            {
                case "ERROR":
                    MessageBox.Show($@"{e.Message}{Environment.NewLine}{e.Exception?.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "WARNING":
                    MessageBox.Show(e.Message, @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show(e.Message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        
        private void OnApplicationClosingHandle(ApplicationClosingEventArgs e)
        {
            Application.Exit();
        }

        private void OnRunScenarioClick(object sender, EventArgs e)
        {
            // _eventAggregator.PublishOnCurrentThreadAsync(new WorkersManagerControlEventArgs { Action = WorkersManagerActions.Restart });
            try
            {
                // do work
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnRestartMenuClick exception");
            }
        }

        private void OnRunTaskClick(object sender, EventArgs e)
        {
            // _eventAggregator.PublishOnCurrentThreadAsync(new WorkersManagerControlEventArgs { Action = WorkersManagerActions.Restart });
            try
            {
                // do work
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OnRestartMenuClick exception");
            }
        }

        private ToolStripMenuItem CreateToolStripMenuItem(string text, Guid guid, bool isTask)
        {
            var result = new ToolStripMenuItem
            {
                Name = guid.ToString(),
                Text = text,
                Size = new System.Drawing.Size(273, 24)
            };
            if (isTask)
            {
                result.Click += OnRunTaskClick;
                result.Font = new System.Drawing.Font(result.Font.FontFamily, result.Font.Size, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            }
            else
            {
                result.Click += OnRunScenarioClick;
            }
            return result;
        }
    }
}
