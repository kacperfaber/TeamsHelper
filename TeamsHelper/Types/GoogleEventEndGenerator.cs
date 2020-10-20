using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
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