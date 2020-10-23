namespace TeamsHelper.CalendarApi
{
    public class UpdateEventUrlGenerator : IUpdateEventUrlGenerator
    {
        public string Generate(string calendarId, string eventId)
        {
            return $"https://www.googleapis.com/calendar/v3/calendars/{calendarId}/events/{eventId}";
        }
    }
}