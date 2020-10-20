using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public interface IGoogleEventStartGenerator
    {
        GoogleTime Generate(TeamsEvent teamsEvent);
    }
}