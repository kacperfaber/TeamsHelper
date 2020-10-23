namespace TeamsHelper.CalendarApi
{
    public class ListEventsUrlGenerator : IListEventsUrlGenerator
    {
        public string Generate(string calendarId)
        {
            return $"https://www.googleapis.com/calendar/v3/calendars/{calendarId}/events";
        }
    }
}