using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public interface IGoogleEventCorrector
    {
        Task CorrectAsync(GoogleEvent googleEvent, TeamsEvent teamsEvent, GoogleEventValidationResult validationResult);
    }
}