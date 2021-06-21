using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Adeotek.DevToolbox.Common;
using Adeotek.DevToolbox.Models;
using Adeotek.DevToolbox.Models.Events;
using Microsoft.Extensions.Logging;

namespace Adeotek.DevToolbox.Forms
{
    public partial class MonitorWindow : Form
    {
        private readonly AppSessionContext _context;
        private readonly EventsAggregator _eventsAggregator;
        private readonly ILogger _logger;

        private delegate void NewLogMessageDelegate(LogEvent message);

        public MonitorWindow(
            AppSessionContext context,
            EventsAggregator eventsAggregator,
            ILogger logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _eventsAggregator = eventsAggregator ?? throw new ArgumentNullException(nameof(eventsAggregator));
            _eventsAggregator.OnNewLogEvent += UpdateLog;
            _logger = logger;
            InitializeComponent();
        }

        private void ConfigureComponents()
        {
            TestingButton.Visible = _context.DebugMode;
            MonitorRichTextBox.Text = string.Empty;
        }

        private void MonitorWindow_Load(object sender, EventArgs e)
        {
            ConfigureComponents();
            _logger.LogInformation("Monitor started...");
        }

        public void UpdateLog(LogEvent message)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new NewLogMessageDelegate(UpdateLog), message);
                return;
            }

            AddEntry(message.Message, message.Level, message.Timestamp.DateTime);
        }

        private void AddEntry(string message, string level = "Information", DateTime? timestamp = null)
        {
            switch (level)
            {
                case "Debug":
                    MonitorAppendText(
                        $"{timestamp ?? DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [DEBUG]: {message}{Environment.NewLine}",
                        Color.DarkGreen);
                    break;
                case "Warning":
                    MonitorAppendText(
                        $"{timestamp ?? DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [WARNING]: {message}{Environment.NewLine}",
                        Color.DarkOrchid);
                    break;
                case "Error":
                    MonitorAppendText(
                        $"{timestamp ?? DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [ERROR]: {message}{Environment.NewLine}",
                        Color.DarkRed);
                    break;
                default:
                    MonitorAppendText(
                        $"{timestamp ?? DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [INFO]: {message}{Environment.NewLine}",
                        Color.Black);
                    break;
            }
        }

        private void MonitorAppendText(string text, Color color)
        {
            try
            {
                MonitorRichTextBox.SelectionStart = MonitorRichTextBox.TextLength;
                MonitorRichTextBox.SelectionLength = 0;
                MonitorRichTextBox.SelectionColor = color;
                MonitorRichTextBox.AppendText(text);
                MonitorRichTextBox.SelectionColor = MonitorRichTextBox.ForeColor;
                if (!AutoScrollCheckBox.Checked)
                {
                    return;
                }

                MonitorRichTextBox.SelectionStart = MonitorRichTextBox.TextLength;
                MonitorRichTextBox.ScrollToCaret();
            }
            catch (Exception e)
            {
                Console.WriteLine($@"MonitorAppendText exception on thread [{Environment.CurrentManagedThreadId.ToString()}]: {e.Message}");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            MonitorRichTextBox.Text = string.Empty;
        }

        private void RunDefaultScenarioButton_Click(object sender, EventArgs e)
        {
            _logger.LogInformation("Running default scenario...");
            _eventsAggregator.OnRunActionHandler(new RunActionEventArgs
            {
                Type = RunActionTypes.Scenario,
                Default = true
            });
        }

        private void RunAllTasksButton_Click(object sender, EventArgs e)
        {
            _logger.LogInformation("Run all active tasks...");
            _eventsAggregator.OnRunActionHandler(new RunActionEventArgs
            {
                Type = RunActionTypes.Task,
                All = true
            });
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            _logger.LogInformation("Oppening settings...");
            _eventsAggregator.OnOpenConfigurationHandler(new OpenConfigurationWindowEventArgs {OpenWindow = true});
        }

       private void TestingButton_Click(object sender, EventArgs e)
        {
            // DoMonitorTest();
            _context.DoTest();
        }

        private void DoMonitorTest()
        {
            _logger.LogDebug("Starting monitor test...");
            const int maxI = 10;
            for (var i = 0; i < maxI; i++)
            {
                var r = new Random().Next(1, 5);
                var m = $"Test text {i} of {maxI.ToString()}...";
                switch (r)
                {
                    case 2:
                        _logger.LogDebug(m);
                        break;
                    case 3:
                        _logger.LogWarning(m);
                        break;
                    case 4:
                        _logger.LogError(m);
                        break;
                    default:
                        _logger.LogInformation(m);
                        break;
                }
            }
        }
    }
}
