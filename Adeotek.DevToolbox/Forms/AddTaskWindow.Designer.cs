
namespace Adeotek.DevToolbox.Forms
{
    partial class AddTaskWindow
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
            this.DefaultScenarioLabel = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ActiveLabel = new System.Windows.Forms.Label();
            this.IsActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IsShortcutCheckBox = new System.Windows.Forms.CheckBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ArgumentsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ArgumentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DefaultScenarioLabel
            // 
            this.DefaultScenarioLabel.AutoSize = true;
            this.DefaultScenarioLabel.Location = new System.Drawing.Point(13, 9);
            this.DefaultScenarioLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DefaultScenarioLabel.Name = "DefaultScenarioLabel";
            this.DefaultScenarioLabel.Size = new System.Drawing.Size(31, 15);
            this.DefaultScenarioLabel.TabIndex = 13;
            this.DefaultScenarioLabel.Text = "Type";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TypeComboBox.BackColor = System.Drawing.SystemColors.Info;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(12, 27);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(337, 23);
            this.TypeComboBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.NameTextBox.Location = new System.Drawing.Point(12, 71);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(337, 23);
            this.NameTextBox.TabIndex = 14;
            // 
            // ActiveLabel
            // 
            this.ActiveLabel.AutoSize = true;
            this.ActiveLabel.Location = new System.Drawing.Point(13, 112);
            this.ActiveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ActiveLabel.Name = "ActiveLabel";
            this.ActiveLabel.Size = new System.Drawing.Size(40, 15);
            this.ActiveLabel.TabIndex = 17;
            this.ActiveLabel.Text = "Active";
            // 
            // IsActiveCheckBox
            // 
            this.IsActiveCheckBox.AutoSize = true;
            this.IsActiveCheckBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.IsActiveCheckBox.Location = new System.Drawing.Point(140, 112);
            this.IsActiveCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.IsActiveCheckBox.Name = "IsActiveCheckBox";
            this.IsActiveCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IsActiveCheckBox.Size = new System.Drawing.Size(15, 14);
            this.IsActiveCheckBox.TabIndex = 16;
            this.IsActiveCheckBox.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Shortcut";
            // 
            // IsShortcutCheckBox
            // 
            this.IsShortcutCheckBox.AutoSize = true;
            this.IsShortcutCheckBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.IsShortcutCheckBox.Location = new System.Drawing.Point(140, 141);
            this.IsShortcutCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.IsShortcutCheckBox.Name = "IsShortcutCheckBox";
            this.IsShortcutCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IsShortcutCheckBox.Size = new System.Drawing.Size(15, 14);
            this.IsShortcutCheckBox.TabIndex = 18;
            this.IsShortcutCheckBox.UseVisualStyleBackColor = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CloseButton.Location = new System.Drawing.Point(121, 415);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 23);
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SaveButton.Location = new System.Drawing.Point(13, 415);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 23);
            this.SaveButton.TabIndex = 20;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ArgumentsDataGridView
            // 
            this.ArgumentsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArgumentsDataGridView.BackgroundColor = System.Drawing.SystemColors.Info;
            this.ArgumentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ArgumentsDataGridView.Location = new System.Drawing.Point(13, 170);
            this.ArgumentsDataGridView.Name = "ArgumentsDataGridView";
            this.ArgumentsDataGridView.RowTemplate.Height = 25;
            this.ArgumentsDataGridView.Size = new System.Drawing.Size(336, 227);
            this.ArgumentsDataGridView.TabIndex = 22;
            // 
            // AddTaskWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(361, 450);
            this.Controls.Add(this.ArgumentsDataGridView);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IsShortcutCheckBox);
            this.Controls.Add(this.ActiveLabel);
            this.Controls.Add(this.IsActiveCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.DefaultScenarioLabel);
            this.Controls.Add(this.TypeComboBox);
            this.MinimumSize = new System.Drawing.Size(377, 489);
            this.Name = "AddTaskWindow";
            this.Text = "Add Task";
            ((System.ComponentModel.ISupportInitialize)(this.ArgumentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DefaultScenarioLabel;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label ActiveLabel;
        private System.Windows.Forms.CheckBox IsActiveCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox IsShortcutCheckBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DataGridView ArgumentsDataGridView;
    }
}