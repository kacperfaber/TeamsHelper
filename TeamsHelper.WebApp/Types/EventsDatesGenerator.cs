using System;

namespace TeamsHelper.WebApp
{
    public class EventsDatesGenerator : IEventsDatesGenerator
    {
        public EventsDates Generate(DateTime nowOrToday)
        {
            DateTime b = nowOrToday.Date;
            
            return new EventsDates
            {
                DayEndingAt = b.AddDays(14).AddHours(23).AddMinutes(59).AddSeconds(59),
                DayStartingAt = b
            };
        }
    }
}