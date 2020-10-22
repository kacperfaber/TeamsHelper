using TeamsHelper.CalendarApi;
using TeamsHelper.Database;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;

namespace TeamsHelper.WebApp
{
    public class GoogleEventEndGenerator : IGoogleEventEndGenerator
    {
        public IGoogleTimeGenerator TimeGenerator;

        public GoogleEventEndGenerator(IGoogleTimeGenerator timeGenerator)
        {
            TimeGenerator = timeGenerator;
        }

        public GoogleTime Generate(TeamsEvent teamsEvent)
        {
            return TimeGenerator.Generate(teamsEvent.End.DateTime);
        }
    }
}