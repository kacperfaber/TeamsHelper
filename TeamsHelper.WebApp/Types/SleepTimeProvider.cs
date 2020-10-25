using System;

namespace TeamsHelper.WebApp
{
    public class SleepTimeProvider : ISleepTimeProvider
    {
        
        public TimeSpan Provide(DateTime currentDateTime, ServiceConfiguration serviceConfiguration)
        {
            return TimeSpan.FromMinutes(serviceConfiguration.SleepMinutes);
        }
    }
}