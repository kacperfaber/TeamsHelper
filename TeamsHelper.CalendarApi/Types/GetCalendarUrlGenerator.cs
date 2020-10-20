namespace TeamsHelper.CalendarApi
{
    public class GetCalendarUrlGenerator : IGetCalendarUrlGenerator
    {
        public string Generate(string calendarId)
        {
            return $"https://www.googleapis.com/calendar/v3/calendars/{calendarId}";
        }
    }
}