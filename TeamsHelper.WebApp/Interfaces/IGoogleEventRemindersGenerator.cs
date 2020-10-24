using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public interface IGoogleEventRemindersGenerator
    {
        GoogleEventReminders Generate(GoogleConfiguration googleConfiguration, bool isCanceled);
    }
}