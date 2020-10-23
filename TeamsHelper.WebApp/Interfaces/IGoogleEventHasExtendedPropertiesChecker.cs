using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public interface IGoogleEventHasExtendedPropertiesChecker
    {
        bool Check(GoogleEvent googleEvent);
    }
}