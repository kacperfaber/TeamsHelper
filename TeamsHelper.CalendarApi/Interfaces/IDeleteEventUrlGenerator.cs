using System;

namespace TeamsHelper.CalendarApi
{
    public interface IDeleteEventUrlGenerator
    {
        string Generate(string calendarId, string eventId);
    }
}