using System.Threading.Tasks;
using TeamsHelper.CalendarApi;

namespace TeamsHelper
{
    public class PrimaryCalendarProvider : IPrimaryCalendarProvider
    {
        public GoogleApi GoogleApi;

        public PrimaryCalendarProvider(GoogleApi googleApi)
        {
            GoogleApi = googleApi;
        }

        public Task<Calendar> Provide(string accessToken)
        {
            return GoogleApi.GetCalendar("PRIMARY", accessToken);
        }
    }
}