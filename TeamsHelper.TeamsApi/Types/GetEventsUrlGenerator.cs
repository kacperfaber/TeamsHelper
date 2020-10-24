using System;

namespace TeamsHelper.TeamsApi
{
    public class GetEventsUrlGenerator : IGetEventsUrlGenerator
    {
        public string Generate(TeamsCalendar calendar, DateTime startingAt, DateTime endingAt)
        {
            return
                $"https://graph.microsoft.com/v1.0/me/calendars/{calendar.Id}/calendarView?startDateTime={DateTimeToString(startingAt)}&endDateTime={DateTimeToString(endingAt)}&top=1000";
        }

        string DateTimeToString(DateTime dt) => dt.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }
}