using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public interface IGoogleEventsGenerator
    {
        Task<List<GoogleEvent>> GenerateAsync(IEnumerable<TeamsEvent> events);
    }
}