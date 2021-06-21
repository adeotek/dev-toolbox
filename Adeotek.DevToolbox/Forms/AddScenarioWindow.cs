using System;
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
