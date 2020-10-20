using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public interface ITeamsCalendarProvider
    {
        Task<TeamsCalendar> ProvideAsync();
    }
}