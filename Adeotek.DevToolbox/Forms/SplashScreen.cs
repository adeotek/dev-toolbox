using System;
using System.Reflection;
using System.Windows.Forms;

namespace Adeotek.DevToolbox.Forms
{
    public partial class SplashScreen : Form
    {
        public SplashScreen(bool manuallyOpened = false)
        {
            InitializeComponent();
            TitleLabel.Text = "AdeoTEK DEV Toolbox";
            SubTitleLabel.Text = "Open Source Developers Toolbox";
            VersionLabel.Text = $"Version: {Assembly.GetExecutingAssembly().GetName().Version}";
            MessageLabel.Text = "Initializing application...";
            CloseButton.Text = "Close";
            MessageLabel.Visible = !manuallyOpened;
            CloseButton.Visible = manuallyOpened;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
