using Adeotek.DevToolbox.Models;
using Adeotek.DevToolbox.Models.Events;

namespace Adeotek.DevToolbox.Common
{
    public class EventsAggregator
    {
        public delegate void RunActionHandler(RunActionEventArgs e);
        public event RunActionHandler OnRunAction;
        public void OnRunActionHandler(RunActionEventArgs e)
        {
            OnRunAction?.Invoke(e);
        }
        
        public delegate void NewUserMessageHandler(LogEvent e);
        public event NewUserMessageHandler OnNewUserMessage;
        public void PublishUserMessage(LogEvent e)
        {
            OnNewUserMessage?.Invoke(e);
        }

        public delegate void NewLogEventHandler(LogEvent e);
        public event NewLogEventHandler OnNewLogEvent;
        public void PublishLogEvent(LogEvent e)
        {
            OnNewLogEvent?.Invoke(e);
        }

        public delegate void ContextChangeHandler(AppContextChangedEventArgs e);
        public event ContextChangeHandler OnContextChange;
        public void OnContextChangeHandle(AppContextChangedEventArgs e)
        {
            OnContextChange?.Invoke(e);
        }
        
        public delegate void OpenConfigurationHandler(OpenConfigurationWindowEventArgs e);
        public event OpenConfigurationHandler OnOpenConfiguration;
        public void OnOpenConfigurationHandler(OpenConfigurationWindowEventArgs e)
        {
            OnOpenConfiguration?.Invoke(e);
        }
        
        public delegate void WindowsSessionSwitchHandler(WindowsSessionSwitchEventArgs e);
        public event WindowsSessionSwitchHandler OnWindowsSessionSwitch;
        public void OnWindowsSessionSwitchHandler(WindowsSessionSwitchEventArgs e)
        {
            OnWindowsSessionSwitch?.Invoke(e);
        }
        
        public delegate void ApplicationClosingHandler(ApplicationClosingEventArgs e);
        public event ApplicationClosingHandler OnApplicationClosing;
        public void OnApplicationClosingHandler(ApplicationClosingEventArgs e)
        {
            OnApplicationClosing?.Invoke(e);
        }
    }
}
