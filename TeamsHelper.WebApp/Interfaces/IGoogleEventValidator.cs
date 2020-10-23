using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface IGoogleEventValidator
    {
        Task<GoogleEventValidationResult> ValidateAsync(GoogleEvent googleEvent, TeamsEvent teamsEvent);
    }
}