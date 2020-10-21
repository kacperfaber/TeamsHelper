namespace TeamsHelper.CalendarApi
{
    public interface IInsertEventUrlGenerator
    {
        string Generate(GoogleCalendar googleCalendar);
    }
}