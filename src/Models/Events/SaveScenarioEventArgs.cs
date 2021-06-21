namespace Adeotek.DevToolbox.Models.Events
{
    public class SaveScenarioEventArgs
    {
        public Scenario Data { get; set; }
        public bool IsEdit { get; set; }
    }
}