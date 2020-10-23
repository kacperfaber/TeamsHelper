using System;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public class GoogleTimeGenerator : IGoogleTimeGenerator
    {
        public GoogleTime Generate(DateTime dt)
        {
            return new GoogleTime {Date = dt};
        }
    }
}