using System;

namespace TeamsHelper.TeamsApi
{
    public class GetEventsUrlGenerator : IGetEventsUrlGenerator
    {
        public string Generate(TeamsCalendar calendar, DateTime startingAt, DateTime endingAt)
        {
            return
                $"https://graph.microsoft.com/v1.0/me/calendars/{calendar.Id}/calendarView?startDateTime={startingAt}&endDateTime={endingAt}";
        }
    }
}