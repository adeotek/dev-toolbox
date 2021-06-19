namespace Adeotek.DevToolbox.Models.Events
{
    public enum WindowsSessionSwitchReasons
    {
        /// <devdoc>
        ///      Notify for this session
        /// </devdoc>
        NotifyForThisSession = 0, // NOTIFY_FOR_THIS_SESSION
        /// <devdoc>
        ///      A session was connected to the console session (Login).
        /// </devdoc>
        ConsoleConnect = 1, // WTS_CONSOLE_CONNECT
        /// <devdoc>
        ///      A session was disconnected from the console session (Logout).
        /// </devdoc>
        ConsoleDisconnect = 2, // WTS_CONSOLE_DISCONNECT
        /// <devdoc>
        ///      A session was connected to the remote session.
        /// </devdoc>
        RemoteConnect = 3, // WTS_REMOTE_CONNECT
        /// <devdoc>
        ///      A session was disconnected from the remote session.
        /// </devdoc>
        RemoteDisconnect = 4, // WTS_REMOTE_DISCONNECT
        /// <devdoc>
        ///      A user has logged on to the session.
        /// </devdoc>
        SessionLogon = 5, // WTS_SESSION_LOGON
        /// <devdoc>
        ///      A user has logged off the session.
        /// </devdoc>
        SessionLogoff = 6, // WTS_SESSION_LOGOFF
        /// <devdoc>
        ///      A session has been locked (Lock or Logout after ConsoleConnect).
        /// </devdoc>
        SessionLock = 7, // WTS_SESSION_LOCK
        /// <devdoc>
        ///      A session has been unlocked (Unlock or Login after ConsoleDisconnect).
        /// </devdoc>
        SessionUnlock = 8, // WTS_SESSION_UNLOCK
        /// <devdoc>
        ///      A session has changed its remote controlled status.
        /// </devdoc>
        SessionRemoteControl = 9 // WTS_SESSION_REMOTE_CONTROL
    }

    public class WindowsSessionSwitchEventArgs
    {
        public WindowsSessionSwitchReasons Reason { get; set; }
        public bool IsMultiInstance { get; set; }
    }
}