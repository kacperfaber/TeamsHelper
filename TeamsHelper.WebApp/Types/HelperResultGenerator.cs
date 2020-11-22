using System.Collections.Generic;

namespace TeamsHelper.WebApp
{
    public class HelperResultGenerator : IHelperResultGenerator
    {
        public HelperResult Generate(List<Event> events, List<CanceledEvent> canceledEvents)
        {
            return new HelperResult {Events = events, CanceledEvents = canceledEvents};
        }
    }
}