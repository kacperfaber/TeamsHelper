﻿using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class UpdateCanceledEventPayloadGenerator : IUpdateCanceledEventPayloadGenerator
    {
        public IGoogleEventRemindersGenerator RemindersGenerator;
        public ICancelledEventsDescriptionGenerator DescriptionGenerator;

        public UpdateCanceledEventPayloadGenerator(IGoogleEventRemindersGenerator remindersGenerator, ICancelledEventsDescriptionGenerator descriptionGenerator)
        {
            RemindersGenerator = remindersGenerator;
            DescriptionGenerator = descriptionGenerator;
        }

        public UpdateEventPayload Generate(GoogleEvent googleEvent, TeamsEvent teamsEvent, GoogleConfiguration configuration)
        {
            return new UpdateEventPayload
            {
                Description = DescriptionGenerator.Generate(googleEvent.Description, configuration.DescriptionAfterCancelled),
                Summary = teamsEvent.Subject,
                Start = googleEvent.Start,
                End = googleEvent.End,
                ExtendedProperties = googleEvent.ExtendedProperties,
                Reminders = RemindersGenerator.Generate(configuration, true),
                ColorId = configuration.Colors.Canceled
            };
        }
    }
}