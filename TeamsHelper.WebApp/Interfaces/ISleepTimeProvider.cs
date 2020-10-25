using System;

namespace TeamsHelper.WebApp
{
    public interface ISleepTimeProvider
    {
        TimeSpan Provide(DateTime currentDateTime, ServiceConfiguration serviceConfiguration);
    }
}