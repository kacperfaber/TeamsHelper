using System.Collections.Generic;
using TeamsHelper.Database;

namespace TeamsHelper.WebApp
{
    public class SynchronizationEventsGenerator : ISynchronizationEventsGenerator
    {
        public ISynchronizationEventGenerator EventGenerator;

        public SynchronizationEventsGenerator(ISynchronizationEventGenerator eventGenerator)
        {
            EventGenerator = eventGenerator;
        }

        public IEnumerable<SynchronizedEvent> Generate(HelperResult result)
        {
            foreach (Event e in result.Events)
            {
                yield return EventGenerator.Generate(e);
            }
        }
    }
}