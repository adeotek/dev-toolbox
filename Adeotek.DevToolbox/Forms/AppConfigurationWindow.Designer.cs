
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
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.DebugModeLabel = new System.Windows.Forms.Label();
            this.DebugModeCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoStartWorkersLabel = new System.Windows.Forms.Label();
            this.AutoStartWorkersCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoStartMonitorLabel = new System.Windows.Forms.Label();
            this.AutoStartMonitorCheckBox = new System.Windows.Forms.CheckBox();
            this.AppModeGroupBox = new System.Windows.Forms.GroupBox();
            this.DESReportingCheckBox = new System.Windows.Forms.CheckBox();
            this.SIUIReportingCheckBox = new System.Windows.Forms.CheckBox();
            this.SIUIGetCatalogsCheckBox = new System.Windows.Forms.CheckBox();
            this.WsSIUIValidationCheckBox = new System.Windows.Forms.CheckBox();
            this.SIUIValidationCheckBox = new System.Windows.Forms.CheckBox();
            this.SigningCheckBox = new System.Windows.Forms.CheckBox();
            this.DatabaseTabPage = new System.Windows.Forms.TabPage();
            this.TimezoneLabel = new System.Windows.Forms.Label();
            this.TimezoneTextBox = new System.Windows.Forms.TextBox();
            this.DbNameLabel = new System.Windows.Forms.Label();
            this.DbNameTextBox = new System.Windows.Forms.TextBox();
            this.EncryptPasswordLabel = new System.Windows.Forms.Label();
            this.EncryptPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.DbPasswordLabel = new System.Windows.Forms.Label();
            this.DbPasswordTextBox = new System.Windows.Forms.TextBox();
            this.DbUserLabel = new System.Windows.Forms.Label();
            this.DbUserTextBox = new System.Windows.Forms.TextBox();
            this.DbIsLabel = new System.Windows.Forms.Label();
            this.DbIsCheckBox = new System.Windows.Forms.CheckBox();
            this.DbServerLabel = new System.Windows.Forms.Label();
            this.DbServerTextBox = new System.Windows.Forms.TextBox();
            this.ConnectivityTabPage = new System.Windows.Forms.TabPage();
            this.PortLabel = new System.Windows.Forms.Label();
            this.HostLabel = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.HostTextBox = new System.Windows.Forms.TextBox();
            this.WebSocketLabel = new System.Windows.Forms.Label();
            this.WebSocketCheckBox = new System.Windows.Forms.CheckBox();
            this.ErrorMessageLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ConfigurationTabControl.SuspendLayout();
            this.ApplicationTabPage.SuspendLayout();
            this.AppModeGroupBox.SuspendLayout();
            this.DatabaseTabPage.SuspendLayout();
            this.ConnectivityTabPage.SuspendLayout();
            this.SuspendLayout();
            //
            // ConfigurationTabControl
            //
            this.ConfigurationTabControl.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigurationTabControl.Controls.Add(this.ApplicationTabPage);
            this.ConfigurationTabControl.Controls.Add(this.DatabaseTabPage);
            this.ConfigurationTabControl.Controls.Add(this.ConnectivityTabPage);
            this.ConfigurationTabControl.Location = new System.Drawing.Point(10, 10);
            this.ConfigurationTabControl.Name = "ConfigurationTabControl";
            this.ConfigurationTabControl.SelectedIndex = 0;
            this.ConfigurationTabControl.Size = new System.Drawing.Size(273, 350);
            this.ConfigurationTabControl.TabIndex = 0;
            //
            // ApplicationTabPage
            //
            this.ApplicationTabPage.Controls.Add(this.PasswordLabel);
            this.ApplicationTabPage.Controls.Add(this.PasswordTextBox);
            this.ApplicationTabPage.Controls.Add(this.DebugModeLabel);
            this.ApplicationTabPage.Controls.Add(this.DebugModeCheckBox);
            this.ApplicationTabPage.Controls.Add(this.AutoStartWorkersLabel);
            this.ApplicationTabPage.Controls.Add(this.AutoStartWorkersCheckBox);
            this.ApplicationTabPage.Controls.Add(this.AutoStartMonitorLabel);
            this.ApplicationTabPage.Controls.Add(this.AutoStartMonitorCheckBox);
            this.ApplicationTabPage.Controls.Add(this.AppModeGroupBox);
            this.ApplicationTabPage.Location = new System.Drawing.Point(4, 22);
            this.ApplicationTabPage.Name = "ApplicationTabPage";
            this.ApplicationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ApplicationTabPage.Size = new System.Drawing.Size(265, 324);
            this.ApplicationTabPage.TabIndex = 0;
            this.ApplicationTabPage.Text = "Application";
            this.ApplicationTabPage.UseVisualStyleBackColor = true;
            //
            // PasswordLabel
            //
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(34, 268);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.PasswordLabel.TabIndex = 8;
            this.PasswordLabel.Text = "Password";
            //
            // PasswordTextBox
            //
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Location = new System.Drawing.Point(34, 284);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(199, 20);
            this.PasswordTextBox.TabIndex = 7;
            this.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            //
            // DebugModeLabel
            //
            this.DebugModeLabel.AutoSize = true;
            this.DebugModeLabel.Location = new System.Drawing.Point(34, 233);
            this.DebugModeLabel.Name = "DebugModeLabel";
            this.DebugModeLabel.Size = new System.Drawing.Size(68, 13);
            this.DebugModeLabel.TabIndex = 5;
            this.DebugModeLabel.Text = "Debug mode";
            //
            // DebugModeCheckBox
            //
            this.DebugModeCheckBox.AutoSize = true;
            this.DebugModeCheckBox.Location = new System.Drawing.Point(218, 234);
            this.DebugModeCheckBox.Name = "DebugModeCheckBox";
            this.DebugModeCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DebugModeCheckBox.Size = new System.Drawing.Size(15, 14);
            this.DebugModeCheckBox.TabIndex = 4;
            this.DebugModeCheckBox.UseVisualStyleBackColor = true;
            //
            // AutoStartWorkersLabel
            //
            this.AutoStartWorkersLabel.AutoSize = true;
            this.AutoStartWorkersLabel.Location = new System.Drawing.Point(34, 186);
            this.AutoStartWorkersLabel.Name = "AutoStartWorkersLabel";
            this.AutoStartWorkersLabel.Size = new System.Drawing.Size(95, 13);
            this.AutoStartWorkersLabel.TabIndex = 3;
            this.AutoStartWorkersLabel.Text = "Auto-start Workers";
            //
            // AutoStartWorkersCheckBox
            //
            this.AutoStartWorkersCheckBox.AutoSize = true;
            this.AutoStartWorkersCheckBox.Location = new System.Drawing.Point(218, 187);
            this.AutoStartWorkersCheckBox.Name = "AutoStartWorkersCheckBox";
            this.AutoStartWorkersCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AutoStartWorkersCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AutoStartWorkersCheckBox.TabIndex = 2;
            this.AutoStartWorkersCheckBox.UseVisualStyleBackColor = true;
            //
            // AutoStartMonitorLabel
            //
            this.AutoStartMonitorLabel.AutoSize = true;
            this.AutoStartMonitorLabel.Location = new System.Drawing.Point(34, 209);
            this.AutoStartMonitorLabel.Name = "AutoStartMonitorLabel";
            this.AutoStartMonitorLabel.Size = new System.Drawing.Size(90, 13);
            this.AutoStartMonitorLabel.TabIndex = 3;
            this.AutoStartMonitorLabel.Text = "Auto-start Monitor";
            //
            // AutoStartMonitorCheckBox
            //
            this.AutoStartMonitorCheckBox.AutoSize = true;
            this.AutoStartMonitorCheckBox.Location = new System.Drawing.Point(218, 210);
            this.AutoStartMonitorCheckBox.Name = "AutoStartMonitorCheckBox";
            this.AutoStartMonitorCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AutoStartMonitorCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AutoStartMonitorCheckBox.TabIndex = 2;
            this.AutoStartMonitorCheckBox.UseVisualStyleBackColor = true;
            //
            // AppModeGroupBox
            //
            this.AppModeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.AppModeGroupBox.Controls.Add(this.DESReportingCheckBox);
            this.AppModeGroupBox.Controls.Add(this.SIUIReportingCheckBox);
            this.AppModeGroupBox.Controls.Add(this.SIUIGetCatalogsCheckBox);
            this.AppModeGroupBox.Controls.Add(this.WsSIUIValidationCheckBox);
            this.AppModeGroupBox.Controls.Add(this.SIUIValidationCheckBox);
            this.AppModeGroupBox.Controls.Add(this.SigningCheckBox);
            this.AppModeGroupBox.Location = new System.Drawing.Point(4, 3);
            this.AppModeGroupBox.Name = "AppModeGroupBox";
            this.AppModeGroupBox.Size = new System.Drawing.Size(259, 167);
            this.AppModeGroupBox.TabIndex = 1;
            this.AppModeGroupBox.TabStop = false;
            this.AppModeGroupBox.Text = "Application Mode";
            //
            // DESReportingCheckBox
            //
            this.DESReportingCheckBox.AutoSize = true;
            this.DESReportingCheckBox.Location = new System.Drawing.Point(30, 137);
            this.DESReportingCheckBox.Name = "DESReportingCheckBox";
            this.DESReportingCheckBox.Size = new System.Drawing.Size(109, 17);
            this.DESReportingCheckBox.TabIndex = 5;
            this.DESReportingCheckBox.Text = "    DES Reporting";
            this.DESReportingCheckBox.UseVisualStyleBackColor = true;
            //
            // SIUIReportingCheckBox
            //
            this.SIUIReportingCheckBox.AutoSize = true;
            this.SIUIReportingCheckBox.Location = new System.Drawing.Point(30, 71);
            this.SIUIReportingCheckBox.Name = "SIUIReportingCheckBox";
            this.SIUIReportingCheckBox.Size = new System.Drawing.Size(108, 17);
            this.SIUIReportingCheckBox.TabIndex = 4;
            this.SIUIReportingCheckBox.Text = "    SIUI Reporting";
            this.SIUIReportingCheckBox.UseVisualStyleBackColor = true;
            //
            // SiuiGetCatalogs
            //
            this.SIUIGetCatalogsCheckBox.AutoSize = true;
            this.SIUIGetCatalogsCheckBox.Location = new System.Drawing.Point(30, 114);
            this.SIUIGetCatalogsCheckBox.Name = "SIUIGetCatalogsCheckBox";
            this.SIUIGetCatalogsCheckBox.Size = new System.Drawing.Size(130, 17);
            this.SIUIGetCatalogsCheckBox.TabIndex = 3;
            this.SIUIGetCatalogsCheckBox.Text = "    SIUI Catalogs Sync";
            this.SIUIGetCatalogsCheckBox.UseVisualStyleBackColor = true;
            //
            // WsSIUIValidationCheckBox
            //
            this.WsSIUIValidationCheckBox.AutoSize = true;
            this.WsSIUIValidationCheckBox.Location = new System.Drawing.Point(30, 92);
            this.WsSIUIValidationCheckBox.Name = "WsSIUIValidationCheckBox";
            this.WsSIUIValidationCheckBox.Size = new System.Drawing.Size(165, 17);
            this.WsSIUIValidationCheckBox.TabIndex = 2;
            this.WsSIUIValidationCheckBox.Text = "    WebServer SIUI Validation";
            this.WsSIUIValidationCheckBox.UseVisualStyleBackColor = true;
            //
            // SIUIValidationCheckBox
            //
            this.SIUIValidationCheckBox.AutoSize = true;
            this.SIUIValidationCheckBox.Location = new System.Drawing.Point(30, 49);
            this.SIUIValidationCheckBox.Name = "SIUIValidationCheckBox";
            this.SIUIValidationCheckBox.Size = new System.Drawing.Size(108, 17);
            this.SIUIValidationCheckBox.TabIndex = 1;
            this.SIUIValidationCheckBox.Text = "    SIUI Validation";
            this.SIUIValidationCheckBox.UseVisualStyleBackColor = true;
            //
            // SigningCheckBox
            //
            this.SigningCheckBox.AutoSize = true;
            this.SigningCheckBox.Location = new System.Drawing.Point(30, 27);
            this.SigningCheckBox.Name = "SigningCheckBox";
            this.SigningCheckBox.Size = new System.Drawing.Size(73, 17);
            this.SigningCheckBox.TabIndex = 0;
            this.SigningCheckBox.Text = "    Signing";
            this.SigningCheckBox.UseVisualStyleBackColor = true;
            //
            // DatabaseTabPage
            //
            this.DatabaseTabPage.Controls.Add(this.TimezoneLabel);
            this.DatabaseTabPage.Controls.Add(this.TimezoneTextBox);
            this.DatabaseTabPage.Controls.Add(this.DbNameLabel);
            this.DatabaseTabPage.Controls.Add(this.DbNameTextBox);
            this.DatabaseTabPage.Controls.Add(this.EncryptPasswordLabel);
            this.DatabaseTabPage.Controls.Add(this.EncryptPasswordCheckBox);
            this.DatabaseTabPage.Controls.Add(this.DbPasswordLabel);
            this.DatabaseTabPage.Controls.Add(this.DbPasswordTextBox);
            this.DatabaseTabPage.Controls.Add(this.DbUserLabel);
            this.DatabaseTabPage.Controls.Add(this.DbUserTextBox);
            this.DatabaseTabPage.Controls.Add(this.DbIsLabel);
            this.DatabaseTabPage.Controls.Add(this.DbIsCheckBox);
            this.DatabaseTabPage.Controls.Add(this.DbServerLabel);
            this.DatabaseTabPage.Controls.Add(this.DbServerTextBox);
            this.DatabaseTabPage.Location = new System.Drawing.Point(4, 22);
            this.DatabaseTabPage.Name = "DatabaseTabPage";
            this.DatabaseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DatabaseTabPage.Size = new System.Drawing.Size(265, 324);
            this.DatabaseTabPage.TabIndex = 1;
            this.DatabaseTabPage.Text = "Database";
            this.DatabaseTabPage.UseVisualStyleBackColor = true;
            //
            // TimezoneLabel
            //
            this.TimezoneLabel.AutoSize = true;
            this.TimezoneLabel.Location = new System.Drawing.Point(34, 267);
            this.TimezoneLabel.Name = "TimezoneLabel";
            this.TimezoneLabel.Size = new System.Drawing.Size(53, 13);
            this.TimezoneLabel.TabIndex = 22;
            this.TimezoneLabel.Text = "Timezone";
            //
            // TimezoneTextBox
            //
            this.TimezoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimezoneTextBox.Location = new System.Drawing.Point(34, 283);
            this.TimezoneTextBox.Name = "TimezoneTextBox";
            this.TimezoneTextBox.Size = new System.Drawing.Size(197, 20);
            this.TimezoneTextBox.TabIndex = 21;
            this.TimezoneTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // DbNameLabel
            //
            this.DbNameLabel.AutoSize = true;
            this.DbNameLabel.Location = new System.Drawing.Point(34, 229);
            this.DbNameLabel.Name = "DbNameLabel";
            this.DbNameLabel.Size = new System.Drawing.Size(53, 13);
            this.DbNameLabel.TabIndex = 20;
            this.DbNameLabel.Text = "Database";
            //
            // DbNameTextBox
            //
            this.DbNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DbNameTextBox.Location = new System.Drawing.Point(34, 244);
            this.DbNameTextBox.Name = "DbNameTextBox";
            this.DbNameTextBox.Size = new System.Drawing.Size(197, 20);
            this.DbNameTextBox.TabIndex = 19;
            this.DbNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // EncryptPasswordLabel
            //
            this.EncryptPasswordLabel.AutoSize = true;
            this.EncryptPasswordLabel.Location = new System.Drawing.Point(34, 191);
            this.EncryptPasswordLabel.Name = "EncryptPasswordLabel";
            this.EncryptPasswordLabel.Size = new System.Drawing.Size(91, 13);
            this.EncryptPasswordLabel.TabIndex = 18;
            this.EncryptPasswordLabel.Text = "Encrypt password";
            //
            // EncryptPasswordCheckBox
            //
            this.EncryptPasswordCheckBox.AutoSize = true;
            this.EncryptPasswordCheckBox.Location = new System.Drawing.Point(218, 192);
            this.EncryptPasswordCheckBox.Name = "EncryptPasswordCheckBox";
            this.EncryptPasswordCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EncryptPasswordCheckBox.Size = new System.Drawing.Size(15, 14);
            this.EncryptPasswordCheckBox.TabIndex = 17;
            this.EncryptPasswordCheckBox.UseVisualStyleBackColor = true;
            //
            // DbPasswordLabel
            //
            this.DbPasswordLabel.AutoSize = true;
            this.DbPasswordLabel.Location = new System.Drawing.Point(34, 133);
            this.DbPasswordLabel.Name = "DbPasswordLabel";
            this.DbPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.DbPasswordLabel.TabIndex = 16;
            this.DbPasswordLabel.Text = "Password";
            //
            // DbPasswordTextBox
            //
            this.DbPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DbPasswordTextBox.Location = new System.Drawing.Point(34, 148);
            this.DbPasswordTextBox.Name = "DbPasswordTextBox";
            this.DbPasswordTextBox.Size = new System.Drawing.Size(197, 20);
            this.DbPasswordTextBox.TabIndex = 15;
            this.DbPasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // DbUserLabel
            //
            this.DbUserLabel.AutoSize = true;
            this.DbUserLabel.Location = new System.Drawing.Point(34, 94);
            this.DbUserLabel.Name = "DbUserLabel";
            this.DbUserLabel.Size = new System.Drawing.Size(29, 13);
            this.DbUserLabel.TabIndex = 14;
            this.DbUserLabel.Text = "User";
            //
            // DbUserTextBox
            //
            this.DbUserTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DbUserTextBox.Location = new System.Drawing.Point(34, 110);
            this.DbUserTextBox.Name = "DbUserTextBox";
            this.DbUserTextBox.Size = new System.Drawing.Size(197, 20);
            this.DbUserTextBox.TabIndex = 13;
            this.DbUserTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // DbIsLabel
            //
            this.DbIsLabel.AutoSize = true;
            this.DbIsLabel.Location = new System.Drawing.Point(34, 62);
            this.DbIsLabel.Name = "DbIsLabel";
            this.DbIsLabel.Size = new System.Drawing.Size(94, 13);
            this.DbIsLabel.TabIndex = 12;
            this.DbIsLabel.Text = "Integrated security";
            //
            // DbIsCheckBox
            //
            this.DbIsCheckBox.AutoSize = true;
            this.DbIsCheckBox.Location = new System.Drawing.Point(218, 63);
            this.DbIsCheckBox.Name = "DbIsCheckBox";
            this.DbIsCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DbIsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.DbIsCheckBox.TabIndex = 11;
            this.DbIsCheckBox.UseVisualStyleBackColor = true;
            //
            // DbServerLabel
            //
            this.DbServerLabel.AutoSize = true;
            this.DbServerLabel.Location = new System.Drawing.Point(34, 8);
            this.DbServerLabel.Name = "DbServerLabel";
            this.DbServerLabel.Size = new System.Drawing.Size(38, 13);
            this.DbServerLabel.TabIndex = 10;
            this.DbServerLabel.Text = "Server";
            //
            // DbServerTextBox
            //
            this.DbServerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DbServerTextBox.Location = new System.Drawing.Point(34, 23);
            this.DbServerTextBox.Name = "DbServerTextBox";
            this.DbServerTextBox.Size = new System.Drawing.Size(197, 20);
            this.DbServerTextBox.TabIndex = 9;
            this.DbServerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // ConnectivityTabPage
            //
            this.ConnectivityTabPage.Controls.Add(this.PortLabel);
            this.ConnectivityTabPage.Controls.Add(this.HostLabel);
            this.ConnectivityTabPage.Controls.Add(this.PortTextBox);
            this.ConnectivityTabPage.Controls.Add(this.HostTextBox);
            this.ConnectivityTabPage.Controls.Add(this.WebSocketLabel);
            this.ConnectivityTabPage.Controls.Add(this.WebSocketCheckBox);
            this.ConnectivityTabPage.Location = new System.Drawing.Point(4, 22);
            this.ConnectivityTabPage.Name = "ConnectivityTabPage";
            this.ConnectivityTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConnectivityTabPage.Size = new System.Drawing.Size(265, 324);
            this.ConnectivityTabPage.TabIndex = 2;
            this.ConnectivityTabPage.Text = "Connectivity";
            this.ConnectivityTabPage.UseVisualStyleBackColor = true;
            //
            // PortLabel
            //
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(34, 80);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(26, 13);
            this.PortLabel.TabIndex = 27;
            this.PortLabel.Text = "Port";
            //
            // HostLabel
            //
            this.HostLabel.AutoSize = true;
            this.HostLabel.Location = new System.Drawing.Point(34, 29);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(29, 13);
            this.HostLabel.TabIndex = 26;
            this.HostLabel.Text = "Host";
            //
            // PortTextBox
            //
            this.PortTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PortTextBox.Location = new System.Drawing.Point(34, 95);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(197, 20);
            this.PortTextBox.TabIndex = 25;
            this.PortTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // HostTextBox
            //
            this.HostTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HostTextBox.Location = new System.Drawing.Point(34, 45);
            this.HostTextBox.Name = "HostTextBox";
            this.HostTextBox.Size = new System.Drawing.Size(197, 20);
            this.HostTextBox.TabIndex = 24;
            this.HostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //
            // WebSocketLabel
            //
            this.WebSocketLabel.AutoSize = true;
            this.WebSocketLabel.Location = new System.Drawing.Point(34, 154);
            this.WebSocketLabel.Name = "WebSocketLabel";
            this.WebSocketLabel.Size = new System.Drawing.Size(86, 13);
            this.WebSocketLabel.TabIndex = 23;
            this.WebSocketLabel.Text = "Use WebSocket";
            //
            // WebSocketCheckBox
            //
            this.WebSocketCheckBox.AutoSize = true;
            this.WebSocketCheckBox.Location = new System.Drawing.Point(218, 155);
            this.WebSocketCheckBox.Name = "WebSocketCheckBox";
            this.WebSocketCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WebSocketCheckBox.Size = new System.Drawing.Size(15, 14);
            this.WebSocketCheckBox.TabIndex = 22;
            this.WebSocketCheckBox.UseVisualStyleBackColor = true;
            //
            // ErrorMessageLabel
            //
            this.ErrorMessageLabel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMessageLabel.ForeColor = System.Drawing.Color.Maroon;
            this.ErrorMessageLabel.Location = new System.Drawing.Point(10, 356);
            this.ErrorMessageLabel.Name = "ErrorMessageLabel";
            this.ErrorMessageLabel.Size = new System.Drawing.Size(273, 32);
            this.ErrorMessageLabel.TabIndex = 10;
            this.ErrorMessageLabel.Text = "Error";
            this.ErrorMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // CloseButton
            //
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.Location = new System.Drawing.Point(101, 391);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(86, 20);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            //
            // SaveButton
            //
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.Location = new System.Drawing.Point(10, 391);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(86, 20);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            //
            // AppConfigurationWindow
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(293, 421);
            this.Controls.Add(this.ErrorMessageLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ConfigurationTabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(309, 460);
            this.MinimumSize = new System.Drawing.Size(309, 460);
            this.Name = "AppConfigurationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.ConfigurationTabControl.ResumeLayout(false);
            this.ApplicationTabPage.ResumeLayout(false);
            this.ApplicationTabPage.PerformLayout();
            this.AppModeGroupBox.ResumeLayout(false);
            this.AppModeGroupBox.PerformLayout();
            this.DatabaseTabPage.ResumeLayout(false);
            this.DatabaseTabPage.PerformLayout();
            this.ConnectivityTabPage.ResumeLayout(false);
            this.ConnectivityTabPage.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl ConfigurationTabControl;
        private System.Windows.Forms.TabPage ApplicationTabPage;
        private System.Windows.Forms.TabPage DatabaseTabPage;
        private System.Windows.Forms.TabPage ConnectivityTabPage;
        private System.Windows.Forms.Label ErrorMessageLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox AppModeGroupBox;
        private System.Windows.Forms.CheckBox SIUIValidationCheckBox;
        private System.Windows.Forms.CheckBox SigningCheckBox;
        private System.Windows.Forms.CheckBox DESReportingCheckBox;
        private System.Windows.Forms.CheckBox WsSIUIValidationCheckBox;
        private System.Windows.Forms.CheckBox AutoStartWorkersCheckBox;
        private System.Windows.Forms.Label DebugModeLabel;
        private System.Windows.Forms.CheckBox DebugModeCheckBox;
        private System.Windows.Forms.Label AutoStartWorkersLabel;
        private System.Windows.Forms.CheckBox AutoStartMonitorCheckBox;
        private System.Windows.Forms.Label AutoStartMonitorLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label DbServerLabel;
        private System.Windows.Forms.TextBox DbServerTextBox;
        private System.Windows.Forms.Label TimezoneLabel;
        private System.Windows.Forms.TextBox TimezoneTextBox;
        private System.Windows.Forms.Label DbNameLabel;
        private System.Windows.Forms.TextBox DbNameTextBox;
        private System.Windows.Forms.Label EncryptPasswordLabel;
        private System.Windows.Forms.CheckBox EncryptPasswordCheckBox;
        private System.Windows.Forms.Label DbPasswordLabel;
        private System.Windows.Forms.TextBox DbPasswordTextBox;
        private System.Windows.Forms.Label DbUserLabel;
        private System.Windows.Forms.TextBox DbUserTextBox;
        private System.Windows.Forms.Label DbIsLabel;
        private System.Windows.Forms.CheckBox DbIsCheckBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.TextBox HostTextBox;
        private System.Windows.Forms.Label WebSocketLabel;
        private System.Windows.Forms.CheckBox WebSocketCheckBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.CheckBox SIUIReportingCheckBox;
        private System.Windows.Forms.CheckBox SIUIGetCatalogsCheckBox;
    }
}