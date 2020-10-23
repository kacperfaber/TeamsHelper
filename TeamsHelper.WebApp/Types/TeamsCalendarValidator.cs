using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class TeamsCalendarValidator : ITeamsCalendarValidator
    {
        public Task<bool> ValidateAsync(TeamsCalendar teamsCalendar)
        {
            return Task.Run(() => true);
        }
    }
}