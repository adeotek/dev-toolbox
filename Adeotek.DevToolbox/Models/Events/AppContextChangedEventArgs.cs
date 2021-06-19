namespace Adeotek.DevToolbox.Models.Events
{
    public class AppContextChangedEventArgs
    {
        public bool ConfigurationChanged { get; set; }
        public bool CertificateChanged { get; set; }
    }
}
