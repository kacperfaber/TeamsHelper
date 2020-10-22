using System;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public interface IGoogleTimeGenerator
    {
        GoogleTime Generate(DateTime dt);
    }
}