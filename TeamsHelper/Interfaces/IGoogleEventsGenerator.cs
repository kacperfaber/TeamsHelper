using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public interface IGoogleEventsGenerator
    {
        Task<List<Event>> GenerateAsync(IEnumerable<TeamsEvent> events);
    }
}