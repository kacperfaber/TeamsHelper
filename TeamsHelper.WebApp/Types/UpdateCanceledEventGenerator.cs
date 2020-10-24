using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class UpdateCanceledEventGenerator : IUpdateCanceledEventGenerator
    {
        public IGoogleEventRemindersGenerator RemindersGenerator;

        public UpdateCanceledEventGenerator(IGoogleEventRemindersGenerator remindersGenerator)
        {
            RemindersGenerator = remindersGenerator;
        }

        public UpdateEventPayload Generate(GoogleEvent googleEvent, TeamsEvent teamsEvent, GoogleConfiguration configuration)
        {
            return new UpdateEventPayload
            {
                Description = googleEvent.Description,
                Summary = teamsEvent.Subject,
                Start = googleEvent.Start,
                End = googleEvent.End,
                ExtendedProperties = googleEvent.ExtendedProperties,
                Reminders = RemindersGenerator.Generate(configuration, true)
            };
        }
    }
}