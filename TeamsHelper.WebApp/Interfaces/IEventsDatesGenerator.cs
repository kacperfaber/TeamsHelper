using System;

namespace TeamsHelper.WebApp
{
    public interface IEventsDatesGenerator
    {
        EventsDates Generate(DateTime nowOrToday);
    }
}