using System.Threading.Tasks;
using GoogleEvent = TeamsHelper.CalendarApi.GoogleEvent;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;


namespace TeamsHelper.WebApp
{
    public interface IGoogleEventGenerator
    {
        Task<GoogleEvent> GenerateAsync(TeamsEvent teamsEvent);
    }
}