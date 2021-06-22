
namespace Adeotek.DevToolbox.Forms
{
    partial class AppConfigurationWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConfigurationTabControl = new System.Windows.Forms.TabControl();
            this.ApplicationTabPage = new System.Windows.Forms.TabPage();
            this.DefaultScenarioLabel = new System.Windows.Forms.Label();
            this.DefaultScenarioComboBox = new System.Windows.Forms.ComboBox();
            this.AutoRunAtLoginLabel = new System.Windows.Forms.Label();
            this.AutoRunAtLoginCheckBox = new System.Windows.Forms.CheckBox();
            this.DebugModeLabel = new System.Windows.Forms.Label();
            this.DebugModeCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoRunDefaultScenarioLabel = new System.Windows.Forms.Label();
            this.AutoRunDefaultScenarioCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoOpenMonitorLabel = new System.Windows.Forms.Label();
            this.AutoOpenMonitorCheckBox = new System.Windows.Forms.CheckBox();
            this.TasksTabPage = new System.Windows.Forms.TabPage();
            this.AddStartServiceTaskButton = new System.Windows.Forms.Button();
            this.AddStartAppTaskButton = new System.Windows.Forms.Button();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.TasksDataGridView = new System.Windows.Forms.DataGridView();
            this.ScenariosTabPage = new System.Windows.Forms.TabPage();
            this.AddScenarioButton = new System.Windows.Forms.Button();
            this.ScenariosDataGridView = new System.Windows.Forms.DataGridView();
            this.ErrorMessageLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ConfigurationTabControl.SuspendLayout();
            this.ApplicationTabPage.SuspendLayout();
            this.TasksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).BeginInit();
            this.ScenariosTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScenariosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ConfigurationTabControl
            // 
            this.ConfigurationTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigurationTabControl.Controls.Add(this.ApplicationTabPage);
            this.ConfigurationTabControl.Controls.Add(this.TasksTabPage);
            this.ConfigurationTabControl.Controls.Add(this.ScenariosTabPage);
            this.ConfigurationTabControl.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.ConfigurationTabControl.Name = "ConfigurationTabControl";
            this.ConfigurationTabControl.Padding = new System.Drawing.Point(0, 0);
            this.ConfigurationTabControl.SelectedIndex = 0;
            this.ConfigurationTabControl.Size = new System.Drawing.Size(377, 339);
            this.ConfigurationTabControl.TabIndex = 0;
            // 
            // ApplicationTabPage
            // 
            this.ApplicationTabPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ApplicationTabPage.Controls.Add(this.DefaultScenarioLabel);
            this.ApplicationTabPage.Controls.Add(this.DefaultScenarioComboBox);
            this.ApplicationTabPage.Controls.Add(this.AutoRunAtLoginLabel);
            this.ApplicationTabPage.Controls.Add(this.AutoRunAtLoginCheckBox);
            this.ApplicationTabPage.Controls.Add(this.DebugModeLabel);
            this.ApplicationTabPage.Controls.Add(this.DebugModeCheckBox);
            this.ApplicationTabPage.Controls.Add(this.AutoRunDefaultScenarioLabel);
            this.ApplicationTabPage.Controls.Add(this.AutoRunDefaultScenarioCheckBox);
            this.ApplicationTabPage.Controls.Add(this.AutoOpenMonitorLabel);
            this.ApplicationTabPage.Controls.Add(this.AutoOpenMonitorCheckBox);
            this.ApplicationTabPage.Location = new System.Drawing.Point(4, 24);
            this.ApplicationTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ApplicationTabPage.Name = "ApplicationTabPage";
            this.ApplicationTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ApplicationTabPage.Size = new System.Drawing.Size(369, 311);
            this.ApplicationTabPage.TabIndex = 0;
            this.ApplicationTabPage.Text = "General";
            // 
            // DefaultScenarioLabel
            // 
            this.DefaultScenarioLabel.AutoSize = true;
            this.DefaultScenarioLabel.Location = new System.Drawing.Point(70, 116);
            this.DefaultScenarioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DefaultScenarioLabel.Name = "DefaultScenarioLabel";
            this.DefaultScenarioLabel.Size = new System.Drawing.Size(93, 15);
            this.DefaultScenarioLabel.TabIndex = 9;
            this.DefaultScenarioLabel.Text = "Default Scenario";
            // 
            // DefaultScenarioComboBox
            // 
            this.DefaultScenarioComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.DefaultScenarioComboBox.FormattingEnabled = true;
            this.DefaultScenarioComboBox.Location = new System.Drawing.Point(70, 134);
            this.DefaultScenarioComboBox.Name = "DefaultScenarioComboBox";
            this.DefaultScenarioComboBox.Size = new System.Drawing.Size(229, 23);
            this.DefaultScenarioComboBox.TabIndex = 8;
            // 
            // AutoRunAtLoginLabel
            // 
            this.AutoRunAtLoginLabel.AutoSize = true;
            this.AutoRunAtLoginLabel.Location = new System.Drawing.Point(70, 30);
            this.AutoRunAtLoginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AutoRunAtLoginLabel.Name = "AutoRunAtLoginLabel";
            this.AutoRunAtLoginLabel.Size = new System.Drawing.Size(163, 15);
            this.AutoRunAtLoginLabel.TabIndex = 7;
            this.AutoRunAtLoginLabel.Text = "Auto-start on Windows Login";
            // 
            // AutoRunAtLoginCheckBox
            // 
            this.AutoRunAtLoginCheckBox.AutoSize = true;
            this.AutoRunAtLoginCheckBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AutoRunAtLoginCheckBox.Location = new System.Drawing.Point(284, 31);
            this.AutoRunAtLoginCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AutoRunAtLoginCheckBox.Name = "AutoRunAtLoginCheckBox";
            this.AutoRunAtLoginCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AutoRunAtLoginCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AutoRunAtLoginCheckBox.TabIndex = 6;
            this.AutoRunAtLoginCheckBox.UseVisualStyleBackColor = false;
            // 
            // DebugModeLabel
            // 
            this.DebugModeLabel.AutoSize = true;
            this.DebugModeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.DebugModeLabel.Location = new System.Drawing.Point(70, 261);
            this.DebugModeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DebugModeLabel.Name = "DebugModeLabel";
            this.DebugModeLabel.Size = new System.Drawing.Size(75, 15);
            this.DebugModeLabel.TabIndex = 5;
            this.DebugModeLabel.Text = "Debug mode";
            // 
            // DebugModeCheckBox
            // 
            this.DebugModeCheckBox.AutoSize = true;
            this.DebugModeCheckBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DebugModeCheckBox.Location = new System.Drawing.Point(284, 262);
            this.DebugModeCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DebugModeCheckBox.Name = "DebugModeCheckBox";
            this.DebugModeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DebugModeCheckBox.Size = new System.Drawing.Size(15, 14);
            this.DebugModeCheckBox.TabIndex = 4;
            this.DebugModeCheckBox.UseVisualStyleBackColor = false;
            // 
            // AutoRunDefaultScenarioLabel
            // 
            this.AutoRunDefaultScenarioLabel.AutoSize = true;
            this.AutoRunDefaultScenarioLabel.Location = new System.Drawing.Point(70, 88);
            this.AutoRunDefaultScenarioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AutoRunDefaultScenarioLabel.Name = "AutoRunDefaultScenarioLabel";
            this.AutoRunDefaultScenarioLabel.Size = new System.Drawing.Size(144, 15);
            this.AutoRunDefaultScenarioLabel.TabIndex = 3;
            this.AutoRunDefaultScenarioLabel.Text = "Auto-run default Scenario";
            // 
            // AutoRunDefaultScenarioCheckBox
            // 
            this.AutoRunDefaultScenarioCheckBox.AutoSize = true;
            this.AutoRunDefaultScenarioCheckBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AutoRunDefaultScenarioCheckBox.Location = new System.Drawing.Point(284, 89);
            this.AutoRunDefaultScenarioCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AutoRunDefaultScenarioCheckBox.Name = "AutoRunDefaultScenarioCheckBox";
            this.AutoRunDefaultScenarioCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AutoRunDefaultScenarioCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AutoRunDefaultScenarioCheckBox.TabIndex = 2;
            this.AutoRunDefaultScenarioCheckBox.UseVisualStyleBackColor = false;
            // 
            // AutoOpenMonitorLabel
            // 
            this.AutoOpenMonitorLabel.AutoSize = true;
            this.AutoOpenMonitorLabel.Location = new System.Drawing.Point(70, 233);
            this.AutoOpenMonitorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AutoOpenMonitorLabel.Name = "AutoOpenMonitorLabel";
            this.AutoOpenMonitorLabel.Size = new System.Drawing.Size(111, 15);
            this.AutoOpenMonitorLabel.TabIndex = 3;
            this.AutoOpenMonitorLabel.Text = "Auto-open Monitor";
            // 
            // AutoOpenMonitorCheckBox
            // 
            this.AutoOpenMonitorCheckBox.AutoSize = true;
            this.AutoOpenMonitorCheckBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AutoOpenMonitorCheckBox.Location = new System.Drawing.Point(284, 234);
            this.AutoOpenMonitorCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AutoOpenMonitorCheckBox.Name = "AutoOpenMonitorCheckBox";
            this.AutoOpenMonitorCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AutoOpenMonitorCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AutoOpenMonitorCheckBox.TabIndex = 2;
            this.AutoOpenMonitorCheckBox.UseVisualStyleBackColor = false;
            // 
            // TasksTabPage
            // 
            this.TasksTabPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TasksTabPage.Controls.Add(this.AddStartServiceTaskButton);
            this.TasksTabPage.Controls.Add(this.AddStartAppTaskButton);
            this.TasksTabPage.Controls.Add(this.AddTaskButton);
            this.TasksTabPage.Controls.Add(this.TasksDataGridView);
            this.TasksTabPage.Location = new System.Drawing.Point(4, 24);
            this.TasksTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TasksTabPage.Name = "TasksTabPage";
            this.TasksTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TasksTabPage.Size = new System.Drawing.Size(369, 311);
            this.TasksTabPage.TabIndex = 1;
            this.TasksTabPage.Text = "Tasks";
            // 
            // AddStartServiceTaskButton
            // 
            this.AddStartServiceTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddStartServiceTaskButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddStartServiceTaskButton.Location = new System.Drawing.Point(139, 6);
            this.AddStartServiceTaskButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddStartServiceTaskButton.Name = "AddStartServiceTaskButton";
            this.AddStartServiceTaskButton.Size = new System.Drawing.Size(137, 23);
            this.AddStartServiceTaskButton.TabIndex = 12;
            this.AddStartServiceTaskButton.Text = "Add StartService Task";
            this.AddStartServiceTaskButton.UseVisualStyleBackColor = false;
            this.AddStartServiceTaskButton.Click += new System.EventHandler(this.AddServiceStartTaskButtonClick);
            // 
            // AddStartAppTaskButton
            // 
            this.AddStartAppTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddStartAppTaskButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddStartAppTaskButton.Location = new System.Drawing.Point(31, 6);
            this.AddStartAppTaskButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddStartAppTaskButton.Name = "AddStartAppTaskButton";
            this.AddStartAppTaskButton.Size = new System.Drawing.Size(100, 23);
            this.AddStartAppTaskButton.TabIndex = 11;
            this.AddStartAppTaskButton.Text = "Add StartApp Task";
            this.AddStartAppTaskButton.UseVisualStyleBackColor = false;
            this.AddStartAppTaskButton.Click += new System.EventHandler(this.AddAppStartTaskButtonClick);
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddTaskButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddTaskButton.Location = new System.Drawing.Point(284, 6);
            this.AddTaskButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(78, 23);
            this.AddTaskButton.TabIndex = 10;
            this.AddTaskButton.Text = "Add Task";
            this.AddTaskButton.UseVisualStyleBackColor = false;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButtonClick);
            // 
            // TasksDataGridView
            // 
            this.TasksDataGridView.AllowUserToAddRows = false;
            this.TasksDataGridView.AllowUserToDeleteRows = false;
            this.TasksDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TasksDataGridView.BackgroundColor = System.Drawing.SystemColors.Info;
            this.TasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksDataGridView.Location = new System.Drawing.Point(7, 35);
            this.TasksDataGridView.Name = "TasksDataGridView";
            this.TasksDataGridView.ReadOnly = true;
            this.TasksDataGridView.RowTemplate.Height = 25;
            this.TasksDataGridView.Size = new System.Drawing.Size(355, 270);
            this.TasksDataGridView.TabIndex = 0;
            // 
            // ScenariosTabPage
            // 
            this.ScenariosTabPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ScenariosTabPage.Controls.Add(this.AddScenarioButton);
            this.ScenariosTabPage.Controls.Add(this.ScenariosDataGridView);
            this.ScenariosTabPage.Location = new System.Drawing.Point(4, 24);
            this.ScenariosTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.ScenariosTabPage.Name = "ScenariosTabPage";
            this.ScenariosTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ScenariosTabPage.Size = new System.Drawing.Size(369, 311);
            this.ScenariosTabPage.TabIndex = 2;
            this.ScenariosTabPage.Text = "Scenarios";
            // 
            // AddScenarioButton
            // 
            this.AddScenarioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddScenarioButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddScenarioButton.Location = new System.Drawing.Point(263, 6);
            this.AddScenarioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddScenarioButton.Name = "AddScenarioButton";
            this.AddScenarioButton.Size = new System.Drawing.Size(100, 23);
            this.AddScenarioButton.TabIndex = 10;
            this.AddScenarioButton.Text = "Add Scenario";
            this.AddScenarioButton.UseVisualStyleBackColor = false;
            this.AddScenarioButton.Click += new System.EventHandler(this.AddScenarioButtonClick);
            // 
            // ScenariosDataGridView
            // 
            this.ScenariosDataGridView.AllowUserToAddRows = false;
            this.ScenariosDataGridView.AllowUserToDeleteRows = false;
            this.ScenariosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScenariosDataGridView.BackgroundColor = System.Drawing.SystemColors.Info;
            this.ScenariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScenariosDataGridView.Location = new System.Drawing.Point(6, 35);
            this.ScenariosDataGridView.Name = "ScenariosDataGridView";
            this.ScenariosDataGridView.RowTemplate.Height = 25;
            this.ScenariosDataGridView.Size = new System.Drawing.Size(357, 270);
            this.ScenariosDataGridView.TabIndex = 1;
            // 
            // ErrorMessageLabel
            // 
            this.ErrorMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMessageLabel.ForeColor = System.Drawing.Color.Maroon;
            this.ErrorMessageLabel.Location = new System.Drawing.Point(12, 346);
            this.ErrorMessageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ErrorMessageLabel.Name = "ErrorMessageLabel";
            this.ErrorMessageLabel.Size = new System.Drawing.Size(350, 37);
            this.ErrorMessageLabel.TabIndex = 10;
            this.ErrorMessageLabel.Text = "Error";
            this.ErrorMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CloseButton.Location = new System.Drawing.Point(118, 386);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 23);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButtonClick);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SaveButton.Location = new System.Drawing.Point(12, 386);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // AppConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(374, 421);
            this.Controls.Add(this.ErrorMessageLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ConfigurationTabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 450);
            this.Name = "AppConfigurationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.ConfigurationTabControl.ResumeLayout(false);
            this.ApplicationTabPage.ResumeLayout(false);
            this.ApplicationTabPage.PerformLayout();
            this.TasksTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TasksDataGridView)).EndInit();
            this.ScenariosTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScenariosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ConfigurationTabControl;
        private System.Windows.Forms.TabPage ApplicationTabPage;
        private System.Windows.Forms.TabPage TasksTabPage;
        private System.Windows.Forms.Label ErrorMessageLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox AutoRunDefaultScenarioCheckBox;
        private System.Windows.Forms.Label DebugModeLabel;
        private System.Windows.Forms.CheckBox DebugModeCheckBox;
        private System.Windows.Forms.Label AutoRunDefaultScenarioLabel;
        private System.Windows.Forms.CheckBox AutoOpenMonitorCheckBox;
        private System.Windows.Forms.Label AutoOpenMonitorLabel;
        private System.Windows.Forms.TabPage ScenariosTabPage;
        private System.Windows.Forms.Label AutoRunAtLoginLabel;
        private System.Windows.Forms.CheckBox AutoRunAtLoginCheckBox;
        private System.Windows.Forms.Label DefaultScenarioLabel;
        private System.Windows.Forms.ComboBox DefaultScenarioComboBox;
        private System.Windows.Forms.DataGridView TasksDataGridView;
        private System.Windows.Forms.DataGridView ScenariosDataGridView;
        private System.Windows.Forms.Button AddTaskButton;
        private System.Windows.Forms.Button AddScenarioButton;
        private System.Windows.Forms.Button AddStartServiceTaskButton;
        private System.Windows.Forms.Button AddStartAppTaskButton;
    }
}