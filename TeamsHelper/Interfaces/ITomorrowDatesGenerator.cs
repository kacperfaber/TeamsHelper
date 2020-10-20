using System;

namespace TeamsHelper
{
    public interface ITomorrowDatesGenerator
    {
        TomorrowDates Generate(DateTime nowOrToday);
    }
}