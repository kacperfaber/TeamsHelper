namespace TeamsHelper.CalendarApi
{
    public class GetCalendarsUrlGenerator : IGetCalendarsUrlGenerator
    {
        public string Generate()
        {
            return "https://www.googleapis.com/calendar/v3/users/me/calendarList";
        }
    }
}