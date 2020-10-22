using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.Database;
using TeamsHelper.TeamsApi;
using TeamsHelper.WebApp;
using GoogleEvent = TeamsHelper.CalendarApi.GoogleEvent;
using TeamsEvent = TeamsHelper.TeamsApi.TeamsEvent;


namespace TeamsHelper
{
    public class TeamsHelper
    {
        public TeamsApi.TeamsApi TeamsApi;
        public GoogleApi GoogleApi;
        public ITeamsCalendarProvider TeamsCalendarProvider;
        public ITomorrowDatesGenerator TomorrowDatesGenerator;
        public IGoogleEventsGenerator GoogleEventsGenerator;
        public IPrimaryCalendarProvider PrimaryCalendarProvider;

        public TeamsHelper(TeamsApi.TeamsApi teamsApi, GoogleApi googleApi, ITeamsCalendarProvider teamsCalendarProvider, ITomorrowDatesGenerator tomorrowDatesGenerator, IGoogleEventsGenerator googleEventsGenerator, IPrimaryCalendarProvider primaryCalendarProvider)
        {
            TeamsApi = teamsApi;
            GoogleApi = googleApi;
            TeamsCalendarProvider = teamsCalendarProvider;
            TomorrowDatesGenerator = tomorrowDatesGenerator;
            GoogleEventsGenerator = googleEventsGenerator;
            PrimaryCalendarProvider = primaryCalendarProvider;
        }

        public async Task<Raport> DoSomething(string microsoftToken, string googleToken)
        {
            List<TeamsCalendar> allCalendars = await TeamsApi.GetCalendarsAsync(microsoftToken);
            
            TeamsCalendar teamsCalendar = await TeamsCalendarProvider.ProvideAsync(allCalendars);
            
            TomorrowDates tomorrowDates = TomorrowDatesGenerator.Generate(DateTime.Now);
            List<TeamsEvent> events = await TeamsApi.GetEventsAsync(teamsCalendar, tomorrowDates.DayStartingAt, tomorrowDates.DayEndingAt, googleToken);
            
            List<GoogleEvent> googleEvents = await GoogleEventsGenerator.GenerateAsync(events);
            
            GoogleCalendar googleCalendar = await PrimaryCalendarProvider.Provide(googleToken);
            
            foreach (GoogleEvent googleEvent in googleEvents)
            {
                await GoogleApi.InsertEventAsync(googleCalendar, googleEvent, googleToken);
            }

            return new Raport();
        }
    }
}