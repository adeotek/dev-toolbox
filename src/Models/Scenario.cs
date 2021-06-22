using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Adeotek.DevToolbox.Models
{
    public class Scenario
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Guid> Tasks { get; set; }

        public Scenario()
        {
            Tasks = new List<Guid>();
        }
        
        [JsonIgnore]
        public string EditButtonText { get; set; } = "Edit";
        [JsonIgnore]
        public string DeleteButtonText { get; set; } = "Delete";
    }
}