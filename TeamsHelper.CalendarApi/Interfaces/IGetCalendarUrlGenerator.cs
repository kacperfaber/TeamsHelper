namespace TeamsHelper.CalendarApi
{
    public interface IGetCalendarUrlGenerator
    {
        string Generate(string calendarId);
    }
}