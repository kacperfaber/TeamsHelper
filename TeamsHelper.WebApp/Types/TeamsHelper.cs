using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public IGoogleCalendarCleaner GoogleCalendarCleaner;
        public IGoogleEventCorrector GoogleEventCorrector;
        public IUpdateEventPayloadGenerator UpdateEventPayloadGenerator;
        public IInsertEventPayloadGenerator InsertEventPayloadGenerator;
        public ITeamsEventIsCanceledChecker TeamsEventIsCanceledChecker;

        public TeamsHelper(TeamsApi.TeamsApi teamsApi, GoogleApi googleApi, ITeamsCalendarProvider teamsCalendarProvider,
            IEventsDatesGenerator eventsDatesGenerator, IPrimaryCalendarProvider primaryCalendarProvider,
            IInsertEventPayloadGenerator insertEventPayloadGenerator, IUpdateEventPayloadGenerator updateEventPayloadGenerator,
            IGoogleEventCorrector googleEventCorrector, IGoogleCalendarCleaner googleCalendarCleaner, IGoogleEventValidator googleEventValidator,
            IGoogleEventsProvider googleEventsProvider, IGoogleEventFinder googleEventFinder, ITeamsEventIsCanceledChecker teamsEventIsCanceledChecker)
        {
            TeamsApi = teamsApi;
            GoogleApi = googleApi;
            TeamsCalendarProvider = teamsCalendarProvider;
            EventsDatesGenerator = eventsDatesGenerator;
            PrimaryCalendarProvider = primaryCalendarProvider;
            InsertEventPayloadGenerator = insertEventPayloadGenerator;
            UpdateEventPayloadGenerator = updateEventPayloadGenerator;
            GoogleEventCorrector = googleEventCorrector;
            GoogleCalendarCleaner = googleCalendarCleaner;
            GoogleEventValidator = googleEventValidator;
            GoogleEventsProvider = googleEventsProvider;
            GoogleEventFinder = googleEventFinder;
            TeamsEventIsCanceledChecker = teamsEventIsCanceledChecker;
        }

        public async Task<Raport> DoSomething(string microsoftToken, string googleToken)
        {
            List<TeamsCalendar> allCalendars = await TeamsApi.GetCalendarsAsync(microsoftToken);

            TeamsCalendar teamsCalendar = await TeamsCalendarProvider.ProvideAsync(allCalendars);

            EventsDates eventsDates = EventsDatesGenerator.Generate(DateTime.Now);
            
            List<TeamsEvent> teamsEvents =
                await TeamsApi.GetEventsAsync(teamsCalendar, eventsDates.DayStartingAt, eventsDates.DayEndingAt, microsoftToken);

            GoogleCalendar googleCalendar = await PrimaryCalendarProvider.Provide(googleToken);
            List<GoogleEvent> googleEvents = await GoogleEventsProvider.ProvideAsync(googleCalendar, googleToken);

            foreach (TeamsEvent teamsEvent in teamsEvents)
            {
                if (TeamsEventIsCanceledChecker.Check(teamsEvent))
                {
                    continue;
                }

                GoogleEvent googleEvent = await GoogleEventFinder.FindAsync(googleEvents, teamsEvent.Id);

                if (googleEvent == null)
                {
                    InsertEventPayload insertPayload = await InsertEventPayloadGenerator.GenerateAsync(teamsEvent);
                    await GoogleApi.InsertAsync(insertPayload, googleCalendar.Id, googleToken);
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

            await GoogleCalendarCleaner.CleanAsync(googleCalendar, googleEvents, teamsEvents, googleToken);

            return new Raport();
        }
    }
}