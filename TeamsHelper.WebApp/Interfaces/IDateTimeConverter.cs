using System;

namespace TeamsHelper.WebApp
{
    public interface IDateTimeConverter
    {
        string Convert(DateTime dateTime, StringDateTime stringDateTime);
    }
}