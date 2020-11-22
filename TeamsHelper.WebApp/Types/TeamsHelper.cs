using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;
using GoogleEvent = TeamsHelper.CalendarApi.GoogleEvent;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;


namespace TeamsHelper.WebApp
{
    public class TeamsHelper
    {
        public TeamsApi.TeamsApi TeamsApi;
        public GoogleApi GoogleApi;
        public ITeamsCalendarProvider TeamsCalendarProvider;
        public IEventsDatesGenerator EventsDatesGenerator;
        public IGoogleEventGenerator GoogleEventGenerator;
        public IPrimaryCalendarProvider PrimaryCalendarProvider;
        public IGoogleEventFinder GoogleEventFinder;
        public IGoogleEventsProvider GoogleEventsProvider;
        public IGoogleEventValidator GoogleEventValidator;
        public IGoogleEventCorrector GoogleEventCorrector;
        public IUpdateEventPayloadGenerator UpdateEventPayloadGenerator;
        public IInsertEventPayloadGenerator InsertEventPayloadGenerator;
        public ITeamsEventIsCanceledChecker TeamsEventIsCanceledChecker;
        public ICancelledEventsUpdater CancelledEventsUpdater;
        public IGoogleConfigurationProvider GoogleConfigurationProvider;
        public IConfiguration Configuration;
        
        public IEventGenerator EventGenerator;
        public IHelperResultGenerator HelperResultGenerator;

        public TeamsHelper(TeamsApi.TeamsApi teamsApi, GoogleApi googleApi, ITeamsCalendarProvider teamsCalendarProvider,
            IEventsDatesGenerator eventsDatesGenerator, IPrimaryCalendarProvider primaryCalendarProvider,
            IInsertEventPayloadGenerator insertEventPayloadGenerator, IUpdateEventPayloadGenerator updateEventPayloadGenerator,
            IGoogleEventCorrector googleEventCorrector, IGoogleEventValidator googleEventValidator,
            IGoogleEventsProvider googleEventsProvider, IGoogleEventFinder googleEventFinder,
            ITeamsEventIsCanceledChecker teamsEventIsCanceledChecker, ICancelledEventsUpdater cancelledEventsUpdater, IGoogleConfigurationProvider googleConfigurationProvider, IConfiguration configuration, IEventGenerator eventGenerator, IHelperResultGenerator helperResultGenerator)
        {
            TeamsApi = teamsApi;
            GoogleApi = googleApi;
            TeamsCalendarProvider = teamsCalendarProvider;
            EventsDatesGenerator = eventsDatesGenerator;
            PrimaryCalendarProvider = primaryCalendarProvider;
            InsertEventPayloadGenerator = insertEventPayloadGenerator;
            UpdateEventPayloadGenerator = updateEventPayloadGenerator;
            GoogleEventCorrector = googleEventCorrector;
            GoogleEventValidator = googleEventValidator;
            GoogleEventsProvider = googleEventsProvider;
            GoogleEventFinder = googleEventFinder;
            TeamsEventIsCanceledChecker = teamsEventIsCanceledChecker;
            CancelledEventsUpdater = cancelledEventsUpdater;
            GoogleConfigurationProvider = googleConfigurationProvider;
            Configuration = configuration;
            EventGenerator = eventGenerator;
            HelperResultGenerator = helperResultGenerator;
        }

        public async Task<HelperResult> DoSomething(string microsoftToken, string googleToken)
        {
            List<Event> eventsResult = new List<Event>();
            
            List<TeamsCalendar> allCalendars = await TeamsApi.GetCalendarsAsync(microsoftToken);

            TeamsCalendar teamsCalendar = await TeamsCalendarProvider.ProvideAsync(allCalendars);

            EventsDates eventsDates = EventsDatesGenerator.Generate(DateTime.Now);

            List<TeamsEvent> teamsEvents =
                await TeamsApi.GetEventsAsync(teamsCalendar, eventsDates.DayStartingAt, eventsDates.DayEndingAt, microsoftToken);

            GoogleCalendar googleCalendar = await PrimaryCalendarProvider.Provide(googleToken);
            List<GoogleEvent> googleEvents = await GoogleEventsProvider.ProvideAsync(googleCalendar, googleToken);

            GoogleConfiguration googleConfiguration = GoogleConfigurationProvider.Provide(Configuration);
            
            foreach (TeamsEvent teamsEvent in teamsEvents)
            {
                if (TeamsEventIsCanceledChecker.Check(teamsEvent))
                {
                    continue;
                }

                GoogleEvent googleEvent = await GoogleEventFinder.FindAsync(googleEvents, teamsEvent.Id);

                if (googleEvent == null)
                {
                    InsertEventPayload insertPayload = await InsertEventPayloadGenerator.GenerateAsync(teamsEvent,googleConfiguration);
                    GoogleEvent insertedEvent = await GoogleApi.InsertAsync(insertPayload, googleCalendar.Id, googleToken);

                    Event @event = EventGenerator.Generate(teamsEvent, insertedEvent, false);
                    eventsResult.Add(@event);
                }

                else
                {
                    GoogleEventValidationResult validationResult = await GoogleEventValidator.ValidateAsync(googleEvent, teamsEvent);

                    if (!validationResult.Validated)
                    {
                        await GoogleEventCorrector.CorrectAsync(googleEvent, teamsEvent, validationResult);

                        UpdateEventPayload updatePayload = await UpdateEventPayloadGenerator.GenerateAsync(googleEvent);

                        await GoogleApi.UpdateAsync(updatePayload, googleCalendar.Id, googleEvent.Id, googleToken);
                    }
                }
            }

            List<CanceledEvent> canceledEvents = await CancelledEventsUpdater.UpdateAsync(teamsEvents, googleCalendar, googleEvents, googleConfiguration, googleToken);

            return HelperResultGenerator.Generate(eventsResult, canceledEvents);
        }
    }
}