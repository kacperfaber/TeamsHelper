using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.TeamsApi;

namespace TeamsHelper
{
    public class TeamsHelper
    {
        public TeamsApi.TeamsApi TeamsApi;
        public ITeamsCalendarProvider TeamsCalendarProvider;
        public ITomorrowDatesGenerator TomorrowDatesGenerator;

        public async Task DoSomething(string accessToken)
        {
            List<TeamsCalendar> allCalendars = await TeamsApi.GetCalendarsAsync(accessToken);
            
            TeamsCalendar teamsCalendar = await TeamsCalendarProvider.ProvideAsync(allCalendars);

            // Get events for tomorrow
            TomorrowDates tomorrowDates = TomorrowDatesGenerator.Generate(DateTime.Now);
            List<TeamsEvent> events = await TeamsApi.GetEventsAsync(teamsCalendar, tomorrowDates.DayStartingAt, tomorrowDates.DayEndingAt, ""); //TODO: Token

            // Translate TeamsEvent into and GoogleEvent.
            

            // Put into google calendar.
        }
    }
}s