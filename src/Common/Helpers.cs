using System.Diagnostics;
using System.Linq;

namespace Adeotek.DevToolbox.Common
{
    public static class Helpers
    {
        /// <summary>
        /// Check if process has another instance running
        /// </summary>
        /// <param name="processName">Name of the process to be checked</param>
        /// <returns></returns>
        public static bool CheckIfAnotherInstanceIsRunning(string processName = null)
        {
            var currentProcess = Process.GetCurrentProcess();
            var altProcess = (from p in Process.GetProcesses()
                where p.ProcessName == (processName ?? currentProcess.ProcessName)
                      && p.SessionId == currentProcess.SessionId && p.Id != currentProcess.Id 
                select p).FirstOrDefault();
            return altProcess != null;
        }
        
        public static bool IsProcessRunning(string processName)
        {
            var proc = (from p in Process.GetProcesses()
                where p.ProcessName.Equals(processName)
                select p).FirstOrDefault();
            return proc != null;
        }
    }
}