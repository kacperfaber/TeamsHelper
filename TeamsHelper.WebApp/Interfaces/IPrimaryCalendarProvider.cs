using System.Threading.Tasks;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public interface IPrimaryCalendarProvider
    {
        Task<GoogleCalendar> Provide(string accessToken);
    }
}