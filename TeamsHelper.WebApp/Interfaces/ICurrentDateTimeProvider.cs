using System;

namespace TeamsHelper.WebApp
{
    public interface ICurrentDateTimeProvider
    {
        DateTime Provide();
    }
}