using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public interface IGoogleEventEndGenerator
    {
        GoogleTime Generate(TeamsEvent teamsEvent);
    }
}