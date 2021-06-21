using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Adeotek.DevToolbox.Common;
using Adeotek.DevToolbox.Models;
using Adeotek.DevToolbox.Models.Events;
using Microsoft.Extensions.Logging;

namespace Adeotek.DevToolbox.Forms
{
    public partial class AddScenarioWindow : Form
    {
        public delegate void SaveHandler(SaveScenarioEventArgs e);
        public event SaveHandler OnSave;
        
        private readonly AppSessionContext _context;
        private readonly ILogger _logger;
        private readonly Scenario _scenario;
        private readonly List<ScenarioTask> _scenarioTasks;
        private readonly bool _isEdit;
        
        public AddScenarioWindow(
            Scenario scenario,
            AppSessionContext context,
            ILogger logger)
        {
            _context = context;
            _logger = logger;
            InitializeComponent();
            
            if (scenario == null)
            {
                _isEdit = false;
                _scenario = new Scenario
                {
                    Guid = Guid.NewGuid()
                };
            }
            else
            {
                _isEdit = true;
                _scenario = scenario;
            }

            NameTextBox.Text = _scenario.Name;
            IsActiveCheckBox.Checked = _scenario.IsActive;

            _scenarioTasks = (from t in _context.Tasks
                join s in _scenario.Tasks on t.Guid equals s into stj
                from st in stj.DefaultIfEmpty()
                select new ScenarioTask
                {
                    Guid = t.Guid,
                    Name = t.Name,
                    IsSelected = st != Guid.Empty
                }).ToList();
            var bindingList = new BindingList<ScenarioTask>(_scenarioTasks);
            TasksDataGridView.DataSource = bindingList;
            TasksDataGridView.AllowUserToResizeColumns = true;
            TasksDataGridView.Columns[0].Visible = false;
            TasksDataGridView.Columns[1].MinimumWidth = 160;
            TasksDataGridView.Columns[1].Resizable = DataGridViewTriState.True;
            TasksDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            TasksDataGridView.Columns[2].Resizable = DataGridViewTriState.False;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show(@"Invalid Name!");
                return;
            }
            
            _scenario.Name = NameTextBox.Text;
            _scenario.IsActive = IsActiveCheckBox.Checked;
            _scenario.Tasks = new List<Guid>();
            _scenarioTasks.Where(t => t.IsSelected).ToList()
                .ForEach(t => _scenario.Tasks.Add(t.Guid));

            var onSaveArgs = new SaveScenarioEventArgs
            {
                Data = _scenario,
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
