using System;

namespace Adeotek.DevToolbox.Models.Events
{
    public enum RunActionTypes
    {
        Null,
        Task,
        Scenario
    }
    
    public class RunActionEventArgs
    {
        public RunActionTypes Type { get; set; } = RunActionTypes.Null;
        public Guid TargetGuid { get; set; }
        public bool Default { get; set; }
        public bool All { get; set; }
    }
}
