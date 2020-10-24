﻿using System.Collections.Generic;
using System.Linq;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public class GoogleEventRemindersGenerator : IGoogleEventRemindersGenerator
    {
        public GoogleEventReminders Generate(GoogleConfiguration googleConfiguration, bool isCanceled)
        {
            return new GoogleEventReminders
            {
                UseDefault = false,
                Reminds = (isCanceled ? googleConfiguration.CanceledReminders : googleConfiguration.Reminders).ConvertAll(x => new GoogleRemind {Method = "popup", Minutes = x.MinutesBefore})
            };
        }
    }
}