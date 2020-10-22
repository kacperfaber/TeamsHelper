using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.Database;
using GoogleEvent = TeamsHelper.CalendarApi.GoogleEvent;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;

namespace TeamsHelper.WebApp
{
    public interface IGoogleEventsGenerator
    {
        Task<List<GoogleEvent>> GenerateAsync(IEnumerable<TeamsEvent> events);
    }
}