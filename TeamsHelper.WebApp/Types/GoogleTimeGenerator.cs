using System;
using TeamsHelper.CalendarApi;
using TeamsHelper.WebApp;

namespace TeamsHelper
{
    public class GoogleTimeGenerator : IGoogleTimeGenerator
    {
        public GoogleTime Generate(DateTime dt)
        {
            return new GoogleTime {Date = dt};
        }
    }
}