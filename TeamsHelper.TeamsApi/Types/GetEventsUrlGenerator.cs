using System;

namespace TeamsHelper.TeamsApi
{
    public class GetEventsUrlGenerator : IGetEventsUrlGenerator
    {
        public string Generate(TeamsCalendar calendar, DateTime startingAt, DateTime endingAt)
        {
            return
                $"https://outlook.office.com/api/v2.0/me/calendars/{calendar.Id}/calendarview?startDateTime={startingAt}&endDateTime={endingAt}";
        }
    }
}