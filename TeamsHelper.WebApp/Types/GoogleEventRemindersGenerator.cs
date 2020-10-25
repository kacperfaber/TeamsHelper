using System.Collections.Generic;
using System.Linq;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public class GoogleEventRemindersGenerator : IGoogleEventRemindersGenerator
    {
        public GoogleEventReminders Generate(GoogleConfiguration googleConfiguration, bool isCancelled)
        {
            List<GoogleRemind> reminds = (isCancelled ? googleConfiguration.CancelledReminders : googleConfiguration.Reminders).ConvertAll(x => new GoogleRemind {Method = "popup", Minutes = x.MinutesBefore});

            return new GoogleEventReminders
            {
                UseDefault = false,
                Reminds = reminds
            };
        }
    }
}