using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public class TeamsHelper
    {
        public TeamsApi.TeamsApi TeamsApi;
        public GoogleApi GoogleApi;
        public ITeamsCalendarProvider TeamsCalendarProvider;
        public ITomorrowDatesGenerator TomorrowDatesGenerator;
        public IGoogleEventsGenerator GoogleEventsGenerator;
        public IGoogleCalendarChooser 

        public async Task DoSomething(string accessToken)
        {
            List<TeamsCalendar> allCalendars = await TeamsApi.GetCalendarsAsync(accessToken);
            
            TeamsCalendar teamsCalendar = await TeamsCalendarProvider.ProvideAsync(allCalendars);

            // Get events for tomorrow
            TomorrowDates tomorrowDates = TomorrowDatesGenerator.Generate(DateTime.Now);
            List<TeamsEvent> events = await TeamsApi.GetEventsAsync(teamsCalendar, tomorrowDates.DayStartingAt, tomorrowDates.DayEndingAt, ""); //TODO: Token

            // Translate TeamsEvent into and GoogleEvent.
            List<Event> googleEvents = await GoogleEventsGenerator.GenerateAsync(events);
            
            // Find gogle-calendar or create new.
            List<Calendar> allGoogleCalendars = await GoogleApi.GetCalendarsAsync("");
            

            // Put into google calendar.
        }
    }
}