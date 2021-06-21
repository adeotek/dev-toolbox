
using System.Windows.Forms;

namespace Adeotek.DevToolbox.Forms
{
    partial class SplashScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.Logo = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.SubTitleLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.Image = global::Adeotek.DevToolbox.Properties.Resources.LogoRound300;
            this.Logo.Location = new System.Drawing.Point(120, 20);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(60, 60);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.Location = new System.Drawing.Point(15, 86);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(270, 20);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VersionLabel
            // 
            this.VersionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VersionLabel.Location = new System.Drawing.Point(15, 129);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(270, 20);
            this.VersionLabel.TabIndex = 2;
            this.VersionLabel.Text = "Version";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageLabel
            // 
            this.MessageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.MessageLabel.Location = new System.Drawing.Point(15, 155);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(270, 20);
            this.MessageLabel.TabIndex = 3;
            this.MessageLabel.Text = "Message";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubTitleLabel
            // 
            this.SubTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SubTitleLabel.Location = new System.Drawing.Point(12, 105);
            this.SubTitleLabel.Name = "SubTitleLabel";
            this.SubTitleLabel.Size = new System.Drawing.Size(270, 20);
            this.SubTitleLabel.TabIndex = 4;
            this.SubTitleLabel.Text = "Subtitle";
            this.SubTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(120, 159);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(60, 29);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Visible = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.ControlBox = false;
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SubTitleLabel);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label SubTitleLabel;
        private Button CloseButton;
    }
}