using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security;
using System.Text.Json;
using System.Windows.Forms;
using Adeotek.DevToolbox.Models;
using Adeotek.DevToolbox.Models.Events;
using Microsoft.Extensions.Logging;

namespace Adeotek.DevToolbox.Forms
{
    public partial class AddStartAppTaskWindow : Form
    {
        public delegate void SaveHandler(SaveTaskEventArgs e);
        public event SaveHandler OnSave;
        private readonly ILogger _logger;
        private readonly AppTask _task;
        private readonly bool _isEdit;
        
        public AddStartAppTaskWindow(AppTask task, ILogger logger)
        {
            _logger = logger;
            InitializeComponent();

            if (task == null)
            {
                _isEdit = false;
                _task = new AppTask
                {
                    Guid = Guid.NewGuid(),
                    Type = TaskTypes.StartApp.ToString()
                };
            }
            else
            {
                if (task.Type != TaskTypes.StartApp.ToString())
                {
                    throw new Exception($"Invalid task type: {task.Type}");
                }

                _isEdit = true;
                _task = task;
                ExecutableTextBox.Text = _task.Arguments.FirstOrDefault(a => a.Key == "Executable").Value ?? string.Empty;
                ArgumentsTextBox.Text = _task.Arguments.FirstOrDefault(a => a.Key == "Arguments").Value ?? string.Empty;
                CheckIfRunningCheckBox.Checked = _task.Arguments.FirstOrDefault(a => a.Key == "CheckIfRunning").Value == "true";
                ProcessNameTextBox.Text = _task.Arguments.FirstOrDefault(a => a.Key == "ProcessName").Value ?? string.Empty;
            }

            TypeTextBox.Text = _task.Type;
            NameTextBox.Text = _task.Name;
            IsActiveCheckBox.Checked = _task.IsActive;
            IsShortcutCheckBox.Checked = _task.IsShortcut;
        }

        private void SelectExecutableButtonClick(object sender, EventArgs e)
        {
            if (ExecutableOpenFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            ExecutableTextBox.Text = ExecutableOpenFileDialog.FileName;
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show(@"Invalid Task Name!");
                return;
            }

            if (string.IsNullOrWhiteSpace(ExecutableTextBox.Text))
            {
                MessageBox.Show(@"Invalid Executable!");
                return;
            }

            _task.Name = NameTextBox.Text;
            _task.IsActive = IsActiveCheckBox.Checked;
            _task.IsShortcut = IsShortcutCheckBox.Checked;
            _task.Arguments = new Dictionary<string, string>
            {
                {"Executable", ExecutableTextBox.Text},
                {"Arguments", ArgumentsTextBox.Text},
                {"CheckIfRunning", CheckIfRunningCheckBox.Checked ? "true" : "false"},
                {"ProcessName", ProcessNameTextBox.Text}
            };

            var onSaveArgs = new SaveTaskEventArgs
            {
                Data = _task,
                IsEdit = _isEdit
            };
            _logger.LogDebug("OnSave.Invoke: {Object}", JsonSerializer.Serialize(onSaveArgs));
            OnSave?.Invoke(onSaveArgs);

            Close();
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
