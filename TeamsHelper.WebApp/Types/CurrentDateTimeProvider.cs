using System;

namespace TeamsHelper.WebApp
{
    public class CurrentDateTimeProvider : ICurrentDateTimeProvider
    {
        public DateTime Provide() => DateTime.Now;
    }
}