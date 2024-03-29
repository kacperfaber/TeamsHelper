﻿namespace TeamsHelper.CalendarApi
{
    public class InsertEventUrlGenerator : IInsertEventUrlGenerator
    {
        public string Generate(string calendarId)
        {
            return $"https://www.googleapis.com/calendar/v3/calendars/{calendarId}/events";
        }
    }
}