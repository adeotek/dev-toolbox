﻿using System;
using System.Collections.Generic;

namespace Adeotek.DevToolbox.Models
{
    public class AppConfiguration
    {
        public bool Debug { get; set; }
        public bool RunDefaultScenarioOnStartup { get; set; }
        public bool AutoOpenMonitor { get; set; }
        public Guid? DefaultScenario { get; set; }
        public List<AppTask> Tasks { get; set; }
        public List<Scenario> Scenarios { get; set; }

        public AppConfiguration()
        {
            Tasks = new List<AppTask>();
            Scenarios = new List<Scenario>();
        }
    }
}
