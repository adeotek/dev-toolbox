
namespace Adeotek.DevToolbox.Forms
{
    partial class MonitorWindow
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
            this.AutoScrollCheckBox = new System.Windows.Forms.CheckBox();
            this.RunDefaultScenario = new System.Windows.Forms.Button();
            this.RunAllTasks = new System.Windows.Forms.Button();
            this.TestingButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.MonitorRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AutoScrollCheckBox
            // 
            this.AutoScrollCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AutoScrollCheckBox.AutoSize = true;
            this.AutoScrollCheckBox.Checked = true;
            this.AutoScrollCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoScrollCheckBox.Location = new System.Drawing.Point(12, 650);
            this.AutoScrollCheckBox.Name = "AutoScrollCheckBox";
            this.AutoScrollCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AutoScrollCheckBox.Size = new System.Drawing.Size(83, 19);
            this.AutoScrollCheckBox.TabIndex = 1;
            this.AutoScrollCheckBox.Text = "Auto scroll";
            this.AutoScrollCheckBox.UseVisualStyleBackColor = true;
            // 
            // RunDefaultScenario
            // 
            this.RunDefaultScenario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RunDefaultScenario.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RunDefaultScenario.Location = new System.Drawing.Point(500, 676);
            this.RunDefaultScenario.Name = "RunDefaultScenario";
            this.RunDefaultScenario.Size = new System.Drawing.Size(140, 23);
            this.RunDefaultScenario.TabIndex = 4;
            this.RunDefaultScenario.Text = "Run Default Scenario";
            this.RunDefaultScenario.UseVisualStyleBackColor = false;
            this.RunDefaultScenario.Click += new System.EventHandler(this.RunDefaultScenarioButton_Click);
            // 
            // RunAllTasks
            // 
            this.RunAllTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RunAllTasks.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RunAllTasks.Location = new System.Drawing.Point(646, 676);
            this.RunAllTasks.Name = "RunAllTasks";
            this.RunAllTasks.Size = new System.Drawing.Size(140, 23);
            this.RunAllTasks.TabIndex = 6;
            this.RunAllTasks.Text = "Run All Tasks";
            this.RunAllTasks.UseVisualStyleBackColor = false;
            this.RunAllTasks.Click += new System.EventHandler(this.RunAllTasksButton_Click);
            // 
            // TestingButton
            // 
            this.TestingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TestingButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TestingButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TestingButton.ForeColor = System.Drawing.Color.Maroon;
            this.TestingButton.Location = new System.Drawing.Point(792, 647);
            this.TestingButton.Name = "TestingButton";
            this.TestingButton.Size = new System.Drawing.Size(140, 23);
            this.TestingButton.TabIndex = 8;
            this.TestingButton.Text = "TEST";
            this.TestingButton.UseVisualStyleBackColor = false;
            this.TestingButton.Click += new System.EventHandler(this.TestingButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClearButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClearButton.ForeColor = System.Drawing.Color.Maroon;
            this.ClearButton.Location = new System.Drawing.Point(12, 676);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(140, 23);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MonitorRichTextBox
            // 
            this.MonitorRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MonitorRichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MonitorRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MonitorRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.MonitorRichTextBox.Name = "MonitorRichTextBox";
            this.MonitorRichTextBox.ReadOnly = true;
            this.MonitorRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.MonitorRichTextBox.ShowSelectionMargin = true;
            this.MonitorRichTextBox.Size = new System.Drawing.Size(932, 629);
            this.MonitorRichTextBox.TabIndex = 0;
            this.MonitorRichTextBox.Text = "";
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SettingsButton.Location = new System.Drawing.Point(792, 676);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(140, 23);
            this.SettingsButton.TabIndex = 11;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // MonitorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(944, 711);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.MonitorRichTextBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.TestingButton);
            this.Controls.Add(this.RunAllTasks);
            this.Controls.Add(this.RunDefaultScenario);
            this.Controls.Add(this.AutoScrollCheckBox);
            this.MinimumSize = new System.Drawing.Size(770, 450);
            this.Name = "MonitorWindow";
            this.Text = "Monitor";
            this.Load += new System.EventHandler(this.MonitorWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox AutoScrollCheckBox;
        private System.Windows.Forms.Button RunDefaultScenario;
        private System.Windows.Forms.Button RunAllTasks;
        private System.Windows.Forms.Button TestingButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.RichTextBox MonitorRichTextBox;
        private System.Windows.Forms.Button SettingsButton;
    }
}