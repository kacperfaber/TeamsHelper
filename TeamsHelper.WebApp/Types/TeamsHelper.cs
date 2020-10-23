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
        public ITomorrowDatesGenerator TomorrowDatesGenerator;
        public IGoogleEventGenerator GoogleEventGenerator;
        public IPrimaryCalendarProvider PrimaryCalendarProvider;

        public IGoogleEventFinder GoogleEventFinder;
        public IGoogleEventsProvider GoogleEventsProvider;
        public IGoogleEventValidator GoogleEventValidator;
        public IGoogleCalendarCleaner GoogleCalendarCleaner;
        public IGoogleEventCorrector GoogleEventCorrector;
        public IUpdateEventPayloadGenerator UpdateEventPayloadGenerator;

        public TeamsHelper(TeamsApi.TeamsApi teamsApi, GoogleApi googleApi, ITeamsCalendarProvider teamsCalendarProvider, ITomorrowDatesGenerator tomorrowDatesGenerator, IPrimaryCalendarProvider primaryCalendarProvider)
        {
            TeamsApi = teamsApi;
            GoogleApi = googleApi;
            TeamsCalendarProvider = teamsCalendarProvider;
            TomorrowDatesGenerator = tomorrowDatesGenerator;
            PrimaryCalendarProvider = primaryCalendarProvider;
        }

        public async Task<Raport> DoSomething(string microsoftToken, string googleToken)
        {
            List<TeamsCalendar> allCalendars = await TeamsApi.GetCalendarsAsync(microsoftToken);
            
            TeamsCalendar teamsCalendar = await TeamsCalendarProvider.ProvideAsync(allCalendars);
            
            TomorrowDates tomorrowDates = TomorrowDatesGenerator.Generate(DateTime.Now);
            List<TeamsEvent> teamsEvents = await TeamsApi.GetEventsAsync(teamsCalendar, tomorrowDates.DayStartingAt, tomorrowDates.DayEndingAt, microsoftToken);
            
            GoogleCalendar googleCalendar = await PrimaryCalendarProvider.Provide(googleToken);
            List<GoogleEvent> googleEvents = await GoogleEventsProvider.ProvideAsync(googleCalendar, googleToken);

            foreach (TeamsEvent teamsEvent in teamsEvents)
            {
                GoogleEvent googleEvent = await GoogleEventFinder.FindAsync(googleEvents, teamsEvent.Id);

                if (googleEvent == null)
                {
                    GoogleEvent newEvent = await GoogleEventGenerator.GenerateAsync(teamsEvent);
                    await GoogleApi.InsertEventAsync(googleCalendar, newEvent, googleToken);
                }

                else
                {
                    GoogleEventValidationResult validationResult = await GoogleEventValidator.ValidateAsync(googleEvent, teamsEvent);

                    if (!validationResult.Validated)
                    {
                        await GoogleEventCorrector.CorrectAsync(googleEvent, teamsEvent, validationResult);
                        
                        UpdateEventPayload updatePayload = await UpdateEventPayloadGenerator.GenerateAsync(googleEvent);
                        
                        await GoogleApi.UpdateAsync(updatePayload, googleToken);
                    }
                }
            }

            await GoogleCalendarCleaner.CleanAsync(googleCalendar, googleEvents, teamsEvents, googleToken);
            
            return new Raport();
        }
    }
}