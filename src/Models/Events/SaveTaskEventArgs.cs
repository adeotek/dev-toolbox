namespace Adeotek.DevToolbox.Models.Events
{
    public class SaveTaskEventArgs
    {
        public AppTask Data { get; set; }
        public bool IsEdit { get; set; }
    }
}