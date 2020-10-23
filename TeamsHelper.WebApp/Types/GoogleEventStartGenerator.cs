using TeamsHelper.CalendarApi;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;

namespace TeamsHelper.WebApp
{
    public class GoogleEventStartGenerator : IGoogleEventStartGenerator
    {

        public IGoogleTimeGenerator GoogleTimeGenerator;

        public GoogleEventStartGenerator(IGoogleTimeGenerator googleTimeGenerator)
        {
            GoogleTimeGenerator = googleTimeGenerator;
        }

        public GoogleTime Generate(TeamsEvent teamsEvent)
        {
            return GoogleTimeGenerator.Generate(teamsEvent.Start.DateTime);
        }
    }
}