using System;

namespace Adeotek.DevToolbox.Tasks
{
    public class ApplicationAlreadyRunningException : Exception
    {
        public string ProcessName { get; }

        public ApplicationAlreadyRunningException(string processName) : base(string.Empty)
        {
            ProcessName = processName;
        }
        
        public ApplicationAlreadyRunningException(string processName, string message) : base(message)
        {
            ProcessName = processName;
        }

        public override string Message => string.IsNullOrEmpty(base.Message) ? $"Application \"{ProcessName}\" is already running" : Message;
    }
}