using System;

namespace TeamsHelper.WebApp
{
    public class TomorrowDatesGenerator : ITomorrowDatesGenerator
    {
        public TomorrowDates Generate(DateTime nowOrToday)
        {
            DateTime tomorrow = nowOrToday.Date.AddDays(1);

            return new TomorrowDates
            {
                DayEndingAt = nowOrToday.AddHours(23).AddMinutes(59).AddSeconds(59),
                DayStartingAt = nowOrToday // TODO: TESTING, CHANGE TO TOMORROW.
            };
        }
    }
}