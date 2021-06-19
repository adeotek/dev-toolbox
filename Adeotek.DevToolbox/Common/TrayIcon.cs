using System;
using System.ComponentModel;
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
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            _trayIcon.BalloonTipText = $@"Version {currentVersion}";
            _trayIcon.Text = $@"{DefaultTooltipTitle}{Environment.NewLine}Version {currentVersion}";
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
        // Controls
        private NotifyIcon _trayIcon;
        private ContextMenuStrip _mainMenu;
        private ToolStripMenuItem _offlineSigningMenuItem;
        private ToolStripMenuItem _onlineSigningMenuItem;
        private ToolStripMenuItem _restartWorkersMenuItem;
        private ToolStripSeparator _menuSeparator1;
        private ToolStripMenuItem _monitorMenuItem;
        private ToolStripMenuItem _testingMenuItem;
        private ToolStripSeparator _menuSeparator2;
        private ToolStripMenuItem _configurationMenuItem;
        private ToolStripMenuItem _aboutMenuItem;
        private ToolStripSeparator _menuSeparator3;
        private ToolStripMenuItem _exitMenuItem;

        private void InitializeComponent()
        {
            var resources = new ComponentResourceManager();
            this._trayIcon = new System.Windows.Forms.NotifyIcon();
            this._mainMenu = new System.Windows.Forms.ContextMenuStrip();
            this._offlineSigningMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._onlineSigningMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._restartWorkersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._monitorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._testingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._configurationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mainMenu.SuspendLayout();
            //
            // trayIcon
            //
            this._trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            this._trayIcon.BalloonTipText = "";
            this._trayIcon.BalloonTipTitle = DefaultTooltipTitle;
            this._trayIcon.ContextMenuStrip = this._mainMenu;
            this._trayIcon.Icon = Properties.Resources.LogoRound;
            this._trayIcon.Text = DefaultTooltipTitle;
            this._trayIcon.Visible = true;
            this._trayIcon.DoubleClick += this.OnDoubleClick;
            //
            // mainMenu
            //
            this._mainMenu.Items.AddRange(new ToolStripItem[] {
            this._offlineSigningMenuItem,
            this._onlineSigningMenuItem,
            this._menuSeparator1,
            this._monitorMenuItem,
            this._restartWorkersMenuItem,
            this._testingMenuItem,
            this._menuSeparator2,
            this._configurationMenuItem,
            this._aboutMenuItem,
            this._menuSeparator3,
            this._exitMenuItem});
            this._mainMenu.Name = "_mainMenu";
            this._mainMenu.Size = new System.Drawing.Size(274, 110);
            //
            // tsmnuGoOffline
            //
            this._offlineSigningMenuItem.Name = "_offlineSigningMenuItem";
            this._offlineSigningMenuItem.Size = new System.Drawing.Size(273, 24);
            this._offlineSigningMenuItem.Text = "Empty option 1";
            this._offlineSigningMenuItem.Click += this.OnGoOfflineMenuClick;
            _offlineSigningMenuItem.Enabled = false;
            //
            // tsmnuGoOnline
            //
            this._onlineSigningMenuItem.Name = "_onlineSigningMenuItem";
            this._onlineSigningMenuItem.Size = new System.Drawing.Size(273, 24);
            this._onlineSigningMenuItem.Text = "Empty option 2";
            this._onlineSigningMenuItem.Click += this.OnGoOnlineMenuClick;
            _onlineSigningMenuItem.Enabled = false;
            //
            // tsmnuSeparator1
            //
            this._menuSeparator1.Name = "_menuSeparator1";
            this._menuSeparator1.Size = new System.Drawing.Size(270, 6);
            //
            // tsmnuStart
            //
            this._restartWorkersMenuItem.Name = "_restartWorkersMenuItem";
            this._restartWorkersMenuItem.Size = new System.Drawing.Size(273, 24);
            this._restartWorkersMenuItem.Text = "Start...";
            this._restartWorkersMenuItem.Click += this.OnRestartMenuClick;
            //
            // tsmnuLog
            //
            this._monitorMenuItem.Name = "_monitorMenuItem";
            this._monitorMenuItem.Size = new System.Drawing.Size(273, 24);
            this._monitorMenuItem.Text = "Monitor";
            this._monitorMenuItem.Click += this.OnMonitorViewMenuClick;
            //
            // tsmnuTesting
            //
            this._testingMenuItem.Name = "_testingMenuItem";
            this._testingMenuItem.Size = new System.Drawing.Size(273, 24);
            this._testingMenuItem.Text = "TESTING";
            this._testingMenuItem.Click += this.OnTestingMenuClick;
            this._testingMenuItem.Visible = _context.DebugMode;
            //
            // tsmnuSeparator2
            //
            this._menuSeparator2.Name = "_menuSeparator2";
            this._menuSeparator2.Size = new System.Drawing.Size(270, 6);
            //
            // tsmnuConfig
            //
            this._configurationMenuItem.Name = "_configurationMenuItem";
            this._configurationMenuItem.Size = new System.Drawing.Size(273, 24);
            this._configurationMenuItem.Text = "Settings";
            this._configurationMenuItem.Click += this.OnConfigurationMenuClick;
            //
            // _aboutMenuItem
            //
            this._aboutMenuItem.Name = "_aboutMenuItem";
            this._aboutMenuItem.Size = new System.Drawing.Size(273, 24);
            this._aboutMenuItem.Text = "About";
            this._aboutMenuItem.Click += this.OnAboutMenuClick;
            //
            // tsmnuSeparator3
            //
            this._menuSeparator3.Name = "_menuSeparator3";
            this._menuSeparator3.Size = new System.Drawing.Size(270, 6);
            //
            // tsmnuExit
            //
            this._exitMenuItem.Name = "_exitMenuItem";
            this._exitMenuItem.Size = new System.Drawing.Size(273, 24);
            this._exitMenuItem.Text = "Exit";
            this._exitMenuItem.Click += this.OnExitMenuClick;
            // Last
            this._mainMenu.ResumeLayout(false);
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

        private void OnRestartMenuClick(object sender, EventArgs e)
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

        private void OnTestingMenuClick(object sender, EventArgs e)
        {
            
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
                    MessageBox.Show($@"{e.Message}{Environment.NewLine}{e.Exception?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "WARNING":
                    MessageBox.Show(e.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show(e.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void OnGoOfflineMenuClick(object sender, EventArgs e)
        {
            
        }

        private void OnGoOnlineMenuClick(object sender, EventArgs e)
        {
            
        }
        
        private void OnApplicationClosingHandle(ApplicationClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
