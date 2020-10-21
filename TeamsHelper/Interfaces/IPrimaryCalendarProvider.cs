using System.Threading.Tasks;
using TeamsHelper.CalendarApi;

namespace TeamsHelper
{
    public interface IPrimaryCalendarProvider
    {
        Task<GoogleCalendar> Provide(string accessToken);
    }
}