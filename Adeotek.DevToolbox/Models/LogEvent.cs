using System;

namespace Adeotek.DevToolbox.Models
{
    public class LogEvent
    {
        /// <summary>
        /// The time at which the event occurred.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The level of the event.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// The rendered message of the event.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// An exception associated with the event, or null.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Propagate to next event
        /// </summary>
        public bool Propagate { get; set; }
    }
}