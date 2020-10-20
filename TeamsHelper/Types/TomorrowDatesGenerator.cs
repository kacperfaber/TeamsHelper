using System;

namespace TeamsHelper
{
    public class TomorrowDatesGenerator : ITomorrowDatesGenerator
    {
        public TomorrowDates Generate(DateTime nowOrToday)
        {
            DateTime tomorrow = nowOrToday.Date.AddDays(1);

            return new TomorrowDates
            {
                DayEndingAt = tomorrow.AddHours(23).AddMinutes(59).AddSeconds(59),
                DayStartingAt = tomorrow
            };
        }
    }
}