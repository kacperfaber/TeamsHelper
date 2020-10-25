using System;

namespace TeamsHelper.WebApp
{
    public class DateTimeConverter : IDateTimeConverter
    {
        public string Convert(DateTime dateTime, StringDateTime stringDateTime)
        {
            return $"{dateTime.Hour}:{dateTime.Minute} {dateTime.Day}.{dateTime.Month}.{dateTime.Year}";
        }
    }
}