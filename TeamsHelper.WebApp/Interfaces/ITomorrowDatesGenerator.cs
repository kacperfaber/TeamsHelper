using System;

namespace TeamsHelper.WebApp
{
    public interface ITomorrowDatesGenerator
    {
        TomorrowDates Generate(DateTime nowOrToday);
    }
}