using Serilog.Core;
using Serilog.Events;
using LogEventModel = Adeotek.DevToolbox.Models.LogEvent;

namespace Adeotek.DevToolbox.Common
{
    public class SerilogSinkEventsAggregator : ILogEventSink
    {
        private readonly EventsAggregator _eventsAggregator;

        public SerilogSinkEventsAggregator(EventsAggregator eventsAggregator)
        {
            _eventsAggregator = eventsAggregator;
        }

        /// <summary>
        /// Emit the provided log event to the sink.
        /// </summary>
        /// <param name="logEvent">The log event to write</param>
        public void Emit(LogEvent logEvent)
        {
            _eventsAggregator?.PublishLogEvent(new LogEventModel
            {
                Timestamp = logEvent.Timestamp,
                Level = logEvent.Level.ToString(),
                Message = logEvent.RenderMessage(),
                Exception = logEvent.Exception
            });
        }
    }
}
