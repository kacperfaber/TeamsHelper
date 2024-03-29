﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public class GoogleEventsProvider : IGoogleEventsProvider
    {
        public GoogleApi GoogleApi;
        public IGoogleEventHasExtendedPropertiesChecker HasExtendedPropertiesChecker;

        public GoogleEventsProvider(IGoogleEventHasExtendedPropertiesChecker hasExtendedPropertiesChecker, GoogleApi googleApi)
        {
            HasExtendedPropertiesChecker = hasExtendedPropertiesChecker;
            GoogleApi = googleApi;
        }

        public async Task<List<GoogleEvent>> ProvideAsync(GoogleCalendar googleCalendar, string accessToken)
        {
            List<GoogleEvent> events = await GoogleApi.ListAsync(googleCalendar.Id, DateTime.Today.Subtract(TimeSpan.FromDays(14)), accessToken);

            return events.Where(x => HasExtendedPropertiesChecker.Check(x))
                .Where(x => x.ExtendedProperties.Private.ContainsKey("teamsId"))
                .ToList();
        }
    }
}