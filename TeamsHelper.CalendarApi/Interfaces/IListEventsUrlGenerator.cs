namespace TeamsHelper.CalendarApi
{
    public interface IListEventsUrlGenerator
    {
        string Generate(string calendarId);
    }
}