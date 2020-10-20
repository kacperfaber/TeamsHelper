using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public interface IGoogleEventGenerator
    {
        Task<Event> GenerateAsync(TeamsEvent teamsEvent);
    }
}