using System;

namespace TeamsHelper.WebApp
{
    public interface IIsNightChecker
    {
        bool Check(DateTime dateTime);
    }
}