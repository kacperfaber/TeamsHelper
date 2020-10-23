using System;

namespace TeamsHelper.CalendarApi
{
    public class DeleteEventUrlGenerator : IDeleteEventUrlGenerator
    {
        public string Generate(string calendarId, string eventId)
        {
            return $"https://www.googleapis.com/calendar/v3/calendars/{calendarId}/events/{eventId}";
        }
    }
}