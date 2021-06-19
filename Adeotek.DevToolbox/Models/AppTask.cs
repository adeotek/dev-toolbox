using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Adeotek.DevToolbox.Models
{
    public class AppTask
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsShortcut { get; set; }
        public string Type { get; set; }
        public Dictionary<string, string> Arguments { get; set; }

        public AppTask()
        {
            Arguments = new Dictionary<string, string>();
        }
        
        [JsonIgnore]
        public TaskTypes TypeAsEnum => string.IsNullOrEmpty(Type) ? TaskTypes.Undefined : Enum.Parse<TaskTypes>(Type);
    }
}