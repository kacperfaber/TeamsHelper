namespace TeamsHelper.TeamsApi
{
    public class GetCalendarsUrlGenerator : IGetCalendarsUrlGenerator
    {
        public string Generate()
        {
            return "https://graph.microsoft.com/v1.0/me/calendars";
        }
    }
}