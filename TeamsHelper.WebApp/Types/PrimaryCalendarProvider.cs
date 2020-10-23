using System.Threading.Tasks;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public class PrimaryCalendarProvider : IPrimaryCalendarProvider
    {
        public GoogleApi GoogleApi;

        public PrimaryCalendarProvider(GoogleApi googleApi)
        {
            GoogleApi = googleApi;
        }

        public Task<GoogleCalendar> Provide(string accessToken)
        {
            return GoogleApi.GetCalendar("PRIMARY", accessToken);
        }
    }
}