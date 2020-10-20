using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public interface ITeamsCalendarValidator
    {
        Task<bool> ValidateAsync(TeamsCalendar teamsCalendar);
    }
}