using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public class GoogleEventsGenerator : IGoogleEventsGenerator
    {
        public IGoogleEventGenerator GoogleEventGenerator;

        public GoogleEventsGenerator(IGoogleEventGenerator googleEventGenerator)
        {
            GoogleEventGenerator = googleEventGenerator;
        }

        public Task<List<Event>> GenerateAsync(IEnumerable<TeamsEvent> events)
        {
            return Task.Run(async () =>
            {
                List<Event> output = new List<Event>();
                foreach (TeamsEvent teamsEvent in events)
                {
                    Event @event = await GoogleEventGenerator.GenerateAsync(teamsEvent);
                    output.Add(@event);
                }

                return output;
            });
        }
    }
}