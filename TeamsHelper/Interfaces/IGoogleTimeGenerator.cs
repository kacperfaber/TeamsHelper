using System;
using TeamsHelper.CalendarApi;

namespace TeamsHelper
{
    public interface IGoogleTimeGenerator
    {
        GoogleTime Generate(DateTime dt);
    }
}