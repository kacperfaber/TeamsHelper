namespace TeamsHelper.WebApp
{
    public class GoogleConfiguration
    {
        public bool DeleteCanceled { get; set; }

        public GoogleConfigurationColors Colors { get; set; }

        public GoogleConfigurationReminders Reminders { get; set; }

        public GoogleConfigurationReminders CanceledReminders { get; set; }
    }
}