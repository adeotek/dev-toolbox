using System;
using System.Collections.Generic;

namespace Adeotek.DevToolbox.Models
{
    public class Scenario
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Guid> Tasks { get; set; }
    }
}