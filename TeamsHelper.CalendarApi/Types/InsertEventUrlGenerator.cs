namespace TeamsHelper.CalendarApi
{
    public class InsertEventUrlGenerator : IInsertEventUrlGenerator
    {
        public string Generate(Calendar calendar)
        {
            return $"https://www.googleapis.com/calendar/v3/calendars/{calendar.Id}/events";
        }
    }
}