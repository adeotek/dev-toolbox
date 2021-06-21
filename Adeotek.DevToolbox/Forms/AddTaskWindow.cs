﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Adeotek.DevToolbox.Models;
using Adeotek.DevToolbox.Models.Events;
using Microsoft.Extensions.Logging;

namespace Adeotek.DevToolbox.Forms
{
    public partial class AddTaskWindow : Form
    {
        public delegate void SaveHandler(SaveTaskEventArgs e);
        public event SaveHandler OnSave;
        private readonly ILogger _logger;
        private readonly AppTask _task;
        private readonly List<Argument> _arguments;
        private readonly bool _isEdit;
        
        public AddTaskWindow(AppTask task, ILogger logger)
        {
            _logger = logger;
            InitializeComponent();

            if (task == null)
            {
                _isEdit = false;
                _task = new AppTask
                {
                    Guid = Guid.NewGuid()
                };
                _arguments = new List<Argument>();

                var typeItems = Enum.GetNames<TaskTypes>().Where(i=> i != "Undefined").Select(i => new {Value = i, Name = i}).ToList();
                TypeComboBox.DataSource = typeItems;
                TypeComboBox.ValueMember = "Value";
                TypeComboBox.DisplayMember = "Name";
                TypeComboBox.SelectedValue = _task.Type ?? "Null";
            }
            else
            {
                _isEdit = true;
                _task = task;
                _arguments = _task.Arguments.Select(a => new Argument
                {
                    Name = a.Key,
                    Value = a.Value
                }).ToList();
                
                TypeComboBox.Visible = false;
            }

            NameTextBox.Text = _task.Name;
            IsActiveCheckBox.Checked = _task.IsActive;
            IsShortcutCheckBox.Checked = _task.IsShortcut;
            ArgumentsDataGridView.DataSource = _arguments;
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string) TypeComboBox.SelectedValue))
            {
                MessageBox.Show(@"Invalid Type!");
                return;
            }
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show(@"Invalid Name!");
                return;
            }

            if (!_isEdit)
            {
                _task.Type = (string) TypeComboBox.SelectedValue;
            }
            _task.Name = NameTextBox.Text;
            _task.IsActive = IsActiveCheckBox.Checked;
            _task.IsShortcut = IsShortcutCheckBox.Checked;
            _task.Arguments = new Dictionary<string, string>();
            _arguments.ForEach(a => _task.Arguments.Add(a.Name, a.Value));

            var onSaveArgs = new SaveTaskEventArgs
            {
                Data = _task,
                IsEdit = _isEdit
            };
            _logger.LogDebug("OnSave.Invoke: {Object}", JsonSerializer.Serialize(onSaveArgs));
            OnSave?.Invoke(onSaveArgs);

            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
