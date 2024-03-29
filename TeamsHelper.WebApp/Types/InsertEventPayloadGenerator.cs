﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class InsertEventPayloadGenerator : IInsertEventPayloadGenerator
    {
        public IGoogleTimeGenerator GoogleTimeGenerator;
        public IGoogleEventRemindersGenerator RemindersGenerator;
        public ISummaryGenerator SummaryGenerator;

        public InsertEventPayloadGenerator(IGoogleTimeGenerator googleTimeGenerator, IGoogleEventRemindersGenerator remindersGenerator, ISummaryGenerator summaryGenerator)
        {
            GoogleTimeGenerator = googleTimeGenerator;
            RemindersGenerator = remindersGenerator;
            SummaryGenerator = summaryGenerator;
        }

        public Task<InsertEventPayload> GenerateAsync(TeamsEvent teamsEvent, GoogleConfiguration googleConfiguration)
        {
            return Task.Run(() => new InsertEventPayload
            {
                ExtendedProperties = new ExtendedProperties
                {
                    Private = new Dictionary<string, string> {{"teamsId", teamsEvent.Id}}
                },
                Description = $"{teamsEvent.TeamsOrganizer.EmailAddress.Name}",
                Summary = SummaryGenerator.Generate(teamsEvent.Subject),
                End = GoogleTimeGenerator.Generate(teamsEvent.End.DateTime),
                Start = GoogleTimeGenerator.Generate(teamsEvent.Start.DateTime),
                ColorId = googleConfiguration.Colors.Active,
                Reminders = RemindersGenerator.Generate(googleConfiguration, false)
            });
        }
    }
}