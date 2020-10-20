namespace TeamsHelper.CalendarApi
{
    public class CreateCalendarUrlGenerator : ICreateCalendarUrlGenerator
    {
        public string Generate()
        {
            return "https://www.googleapis.com/calendar/v3/calendars";
        }
    }
}