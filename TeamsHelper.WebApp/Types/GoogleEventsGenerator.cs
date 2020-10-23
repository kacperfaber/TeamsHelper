using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleEvent = TeamsHelper.CalendarApi.GoogleEvent;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;

namespace TeamsHelper.WebApp
{
    public class GoogleEventsGenerator : IGoogleEventsGenerator
    {
        public IGoogleEventGenerator GoogleEventGenerator;

        public GoogleEventsGenerator(IGoogleEventGenerator googleEventGenerator)
        {
            GoogleEventGenerator = googleEventGenerator;
        }

        public Task<List<GoogleEvent>> GenerateAsync(IEnumerable<TeamsEvent> events)
        {
            return Task.Run(async () =>
            {
                List<GoogleEvent> output = new List<GoogleEvent>();
                
                foreach (TeamsEvent teamsEvent in events)
                {
                    GoogleEvent googleEvent = await GoogleEventGenerator.GenerateAsync(teamsEvent);
                    output.Add(googleEvent);
                }

                return output;
            });
        }
    }
}