
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
            this.DebugModeLabel = new System.Windows.Forms.Label();
            this.DebugModeCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoRunDefaultScenarioLabel = new System.Windows.Forms.Label();
            this.AutoRunDefaultScenarioCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoOpenMonitorLabel = new System.Windows.Forms.Label();
            this.AutoOpenMonitorCheckBox = new System.Windows.Forms.CheckBox();
            this.TasksTabPage = new System.Windows.Forms.TabPage();
            this.ErrorMessageLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ScenariosTabPage = new System.Windows.Forms.TabPage();
            this.AutoRunAtLoginLabel = new System.Windows.Forms.Label();
            this.AutoRunAtLogin = new System.Windows.Forms.CheckBox();
            this.ConfigurationTabControl.SuspendLayout();
            this.ApplicationTabPage.SuspendLayout();
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
            this.ConfigurationTabControl.Location = new System.Drawing.Point(12, 12);
            this.ConfigurationTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ConfigurationTabControl.Name = "ConfigurationTabControl";
            this.ConfigurationTabControl.SelectedIndex = 0;
            this.ConfigurationTabControl.Size = new System.Drawing.Size(318, 304);
            this.ConfigurationTabControl.TabIndex = 0;
            // 
            // ApplicationTabPage
            // 
            this.ApplicationTabPage.Controls.Add(this.AutoRunAtLoginLabel);
            this.ApplicationTabPage.Controls.Add(this.AutoRunAtLogin);
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
            this.ApplicationTabPage.Size = new System.Drawing.Size(310, 276);
            this.ApplicationTabPage.TabIndex = 0;
            this.ApplicationTabPage.Text = "General";
            this.ApplicationTabPage.UseVisualStyleBackColor = true;
            // 
            // DebugModeLabel
            // 
            this.DebugModeLabel.AutoSize = true;
            this.DebugModeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.DebugModeLabel.Location = new System.Drawing.Point(30, 176);
            this.DebugModeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DebugModeLabel.Name = "DebugModeLabel";
            this.DebugModeLabel.Size = new System.Drawing.Size(75, 15);
            this.DebugModeLabel.TabIndex = 5;
            this.DebugModeLabel.Text = "Debug mode";
            // 
            // DebugModeCheckBox
            // 
            this.DebugModeCheckBox.AutoSize = true;
            this.DebugModeCheckBox.Location = new System.Drawing.Point(244, 177);
            this.DebugModeCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DebugModeCheckBox.Name = "DebugModeCheckBox";
            this.DebugModeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DebugModeCheckBox.Size = new System.Drawing.Size(15, 14);
            this.DebugModeCheckBox.TabIndex = 4;
            this.DebugModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoRunDefaultScenarioLabel
            // 
            this.AutoRunDefaultScenarioLabel.AutoSize = true;
            this.AutoRunDefaultScenarioLabel.Location = new System.Drawing.Point(30, 72);
            this.AutoRunDefaultScenarioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AutoRunDefaultScenarioLabel.Name = "AutoRunDefaultScenarioLabel";
            this.AutoRunDefaultScenarioLabel.Size = new System.Drawing.Size(144, 15);
            this.AutoRunDefaultScenarioLabel.TabIndex = 3;
            this.AutoRunDefaultScenarioLabel.Text = "Auto-run default Scenario";
            // 
            // AutoRunDefaultScenarioCheckBox
            // 
            this.AutoRunDefaultScenarioCheckBox.AutoSize = true;
            this.AutoRunDefaultScenarioCheckBox.Location = new System.Drawing.Point(244, 73);
            this.AutoRunDefaultScenarioCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AutoRunDefaultScenarioCheckBox.Name = "AutoRunDefaultScenarioCheckBox";
            this.AutoRunDefaultScenarioCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AutoRunDefaultScenarioCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AutoRunDefaultScenarioCheckBox.TabIndex = 2;
            this.AutoRunDefaultScenarioCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoOpenMonitorLabel
            // 
            this.AutoOpenMonitorLabel.AutoSize = true;
            this.AutoOpenMonitorLabel.Location = new System.Drawing.Point(30, 98);
            this.AutoOpenMonitorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AutoOpenMonitorLabel.Name = "AutoOpenMonitorLabel";
            this.AutoOpenMonitorLabel.Size = new System.Drawing.Size(111, 15);
            this.AutoOpenMonitorLabel.TabIndex = 3;
            this.AutoOpenMonitorLabel.Text = "Auto-open Monitor";
            // 
            // AutoOpenMonitorCheckBox
            // 
            this.AutoOpenMonitorCheckBox.AutoSize = true;
            this.AutoOpenMonitorCheckBox.Location = new System.Drawing.Point(244, 99);
            this.AutoOpenMonitorCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AutoOpenMonitorCheckBox.Name = "AutoOpenMonitorCheckBox";
            this.AutoOpenMonitorCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AutoOpenMonitorCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AutoOpenMonitorCheckBox.TabIndex = 2;
            this.AutoOpenMonitorCheckBox.UseVisualStyleBackColor = true;
            // 
            // TasksTabPage
            // 
            this.TasksTabPage.Location = new System.Drawing.Point(4, 24);
            this.TasksTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TasksTabPage.Name = "TasksTabPage";
            this.TasksTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TasksTabPage.Size = new System.Drawing.Size(978, 852);
            this.TasksTabPage.TabIndex = 1;
            this.TasksTabPage.Text = "Tasks";
            this.TasksTabPage.UseVisualStyleBackColor = true;
            // 
            // ErrorMessageLabel
            // 
            this.ErrorMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMessageLabel.ForeColor = System.Drawing.Color.Maroon;
            this.ErrorMessageLabel.Location = new System.Drawing.Point(12, 311);
            this.ErrorMessageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ErrorMessageLabel.Name = "ErrorMessageLabel";
            this.ErrorMessageLabel.Size = new System.Drawing.Size(318, 37);
            this.ErrorMessageLabel.TabIndex = 10;
            this.ErrorMessageLabel.Text = "Error";
            this.ErrorMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.Location = new System.Drawing.Point(118, 351);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 23);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.Location = new System.Drawing.Point(12, 351);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 23);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ScenariosTabPage
            // 
            this.ScenariosTabPage.Location = new System.Drawing.Point(4, 24);
            this.ScenariosTabPage.Name = "ScenariosTabPage";
            this.ScenariosTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ScenariosTabPage.Size = new System.Drawing.Size(310, 276);
            this.ScenariosTabPage.TabIndex = 2;
            this.ScenariosTabPage.Text = "Scenarios";
            this.ScenariosTabPage.UseVisualStyleBackColor = true;
            // 
            // AutoRunAtLoginLabel
            // 
            this.AutoRunAtLoginLabel.AutoSize = true;
            this.AutoRunAtLoginLabel.Location = new System.Drawing.Point(30, 29);
            this.AutoRunAtLoginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AutoRunAtLoginLabel.Name = "AutoRunAtLoginLabel";
            this.AutoRunAtLoginLabel.Size = new System.Drawing.Size(163, 15);
            this.AutoRunAtLoginLabel.TabIndex = 7;
            this.AutoRunAtLoginLabel.Text = "Auto-start on Windows Login";
            // 
            // AutoRunAtLogin
            // 
            this.AutoRunAtLogin.AutoSize = true;
            this.AutoRunAtLogin.Location = new System.Drawing.Point(244, 30);
            this.AutoRunAtLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AutoRunAtLogin.Name = "AutoRunAtLogin";
            this.AutoRunAtLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AutoRunAtLogin.Size = new System.Drawing.Size(15, 14);
            this.AutoRunAtLogin.TabIndex = 6;
            this.AutoRunAtLogin.UseVisualStyleBackColor = true;
            // 
            // AppConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(342, 386);
            this.Controls.Add(this.ErrorMessageLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ConfigurationTabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(358, 425);
            this.Name = "AppConfigurationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.ConfigurationTabControl.ResumeLayout(false);
            this.ApplicationTabPage.ResumeLayout(false);
            this.ApplicationTabPage.PerformLayout();
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
        private System.Windows.Forms.CheckBox AutoRunAtLogin;
    }
}