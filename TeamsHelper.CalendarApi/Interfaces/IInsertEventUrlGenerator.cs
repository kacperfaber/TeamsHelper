﻿namespace TeamsHelper.CalendarApi
{
    public interface IInsertEventUrlGenerator
    {
        string Generate(string calendarId);
    }
}