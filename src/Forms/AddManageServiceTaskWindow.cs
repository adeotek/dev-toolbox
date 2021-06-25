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
    public partial class AddManageServiceTaskWindow : Form
    {
        public delegate void SaveHandler(SaveTaskEventArgs e);
        public event SaveHandler OnSave;
        private readonly ILogger _logger;
        private readonly AppTask _task;
        private readonly bool _isEdit;
        
        public AddManageServiceTaskWindow(AppTask task, ILogger logger)
        {
            _logger = logger;
            InitializeComponent();

            if (task == null)
            {
                _isEdit = false;
                _task = new AppTask
                {
                    Guid = Guid.NewGuid(),
                    Type = TaskTypes.ManageService.ToString()
                };
            }
            else
            {
                if (task.Type != TaskTypes.ManageService.ToString())
                {
                    throw new Exception($"Invalid task type: {task.Type}");
                }

                _isEdit = true;
                _task = task;
                ServiceNameTextBox.Text = _task.Arguments.FirstOrDefault(a => a.Key == "ServiceName").Value ?? string.Empty;
                ActionComboBox.SelectedItem = _task.Arguments.FirstOrDefault(a => a.Key == "Action").Value ?? string.Empty;
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
            _task.Arguments = new Dictionary<string, string>
            {
                {"ServiceName", ServiceNameTextBox.Text},
                {"Action", ActionComboBox.SelectedItem?.ToString()}
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
