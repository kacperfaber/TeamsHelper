namespace TeamsHelper.CalendarApi
{
    public interface IUpdateEventUrlGenerator
    {
        string Generate(string calendarId, string eventId);
    }
}