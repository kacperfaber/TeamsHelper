using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface ITeamsCalendarValidator
    {
        Task<bool> ValidateAsync(TeamsCalendar teamsCalendar);
    }
}