using System;

namespace TeamsHelper.WebApp
{
    public class IsNightChecker : IIsNightChecker
    {
        public bool Check(DateTime dateTime)
        {
            return dateTime.TimeOfDay.Hours >= 23 || dateTime.TimeOfDay.Hours < 6;
        }
    }
}