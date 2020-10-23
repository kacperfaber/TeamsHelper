using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public class GoogleEventHasExtendedPropertiesChecker : IGoogleEventHasExtendedPropertiesChecker
    {
        public bool Check(GoogleEvent googleEvent)
        {
            return googleEvent.ExtendedProperties != null;
        }
    }
}