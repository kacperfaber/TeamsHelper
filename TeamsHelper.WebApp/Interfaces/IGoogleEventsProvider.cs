using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public interface IGoogleEventsProvider
    {
        Task<List<GoogleEvent>> ProvideAsync(GoogleCalendar googleCalendar, string accessToken);
    }
}