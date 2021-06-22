using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Adeotek.DevToolbox.Models;
using Adeotek.DevToolbox.Models.Events;
using Microsoft.Extensions.Logging;

namespace Adeotek.DevToolbox.Forms
{
    public partial class AddStartServiceTaskWindow : Form
    {
        public delegate void SaveHandler(SaveTaskEventArgs e);
        public event SaveHandler OnSave;
        private readonly ILogger _logger;
        private readonly AppTask _task;
        private readonly bool _isEdit;
        
        public AddStartServiceTaskWindow(AppTask task, ILogger logger)
        {
            _logger = logger;
            InitializeComponent();

            if (task == null)
            {
                _isEdit = false;
                _task = new AppTask
                {
                    Guid = Guid.NewGuid(),
                    Type = TaskTypes.StartService.ToString()
                };
            }
            else
            {
                if (task.Type != TaskTypes.StartService.ToString())
                {
                    throw new Exception($"Invalid task type: {task.Type}");
                }

                _isEdit = true;
                _task = task;
                ServiceNameTextBox.Text = _task.Arguments.FirstOrDefault(a => a.Key == "ServiceName").Value ?? string.Empty;
            }

            TypeTextBox.Text = _task.Type;
            NameTextBox.Text = _task.Name;
            IsActiveCheckBox.Checked = _task.IsActive;
            IsShortcutCheckBox.Checked = _task.IsShortcut;
        }
        
        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show(@"Invalid Task Name!");
                return;
            }

            if (string.IsNullOrWhiteSpace(ServiceNameTextBox.Text))
            {
                MessageBox.Show(@"Invalid Service Name!");
                return;
            }

            _task.Name = NameTextBox.Text;
            _task.IsActive = IsActiveCheckBox.Checked;
            _task.IsShortcut = IsShortcutCheckBox.Checked;
            _task.Arguments = new Dictionary<string, string> {{"ServiceName", ServiceNameTextBox.Text}};

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
