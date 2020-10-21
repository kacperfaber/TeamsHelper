namespace TeamsHelper.CalendarApi
{
    public class InsertEventUrlGenerator : IInsertEventUrlGenerator
    {
        public string Generate(GoogleCalendar googleCalendar)
        {
            return $"https://www.googleapis.com/calendar/v3/calendars/{googleCalendar.Id}/events";
        }
    }
}