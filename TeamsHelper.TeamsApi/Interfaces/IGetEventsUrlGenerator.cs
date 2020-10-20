using System;
using System.Collections.Generic;

namespace TeamsHelper.TeamsApi
{
    public interface IGetEventsUrlGenerator
    {
        string Generate(TeamsCalendar calendar, DateTime startingAt, DateTime endingAt);
    }
}