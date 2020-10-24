using System.Collections.Generic;

namespace TeamsHelper.WebApp
{
    public class GoogleConfiguration
    {
        public bool DeleteCanceled { get; set; }

        public GoogleConfigurationColors Colors { get; set; }

        public List<GoogleConfigurationReminder> Reminders { get; set; }

        public List<GoogleConfigurationReminder> CanceledReminders { get; set; }
    }
}