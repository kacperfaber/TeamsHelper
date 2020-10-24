using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class GoogleCalendarCleaner : IGoogleCalendarCleaner
    {
        public ITeamsEventFinder TeamsEventFinder;
        public IGoogleEventPropertiesGenerator GoogleEventPropertiesGenerator;
        public GoogleApi GoogleApi;
        public ITeamsEventIsActiveValidator IsActiveValidator;

        public GoogleCalendarCleaner(IGoogleEventPropertiesGenerator googleEventPropertiesGenerator, ITeamsEventFinder teamsEventFinder, GoogleApi googleApi, ITeamsEventIsActiveValidator isActiveValidator)
        {
            GoogleEventPropertiesGenerator = googleEventPropertiesGenerator;
            TeamsEventFinder = teamsEventFinder;
            GoogleApi = googleApi;
            IsActiveValidator = isActiveValidator;
        }

        public async Task CleanAsync(GoogleCalendar googleCalendar, IEnumerable<GoogleEvent> googleEvents, IEnumerable<TeamsEvent> teamsEvents, string accessToken)
        {
            foreach (GoogleEvent googleEvent in googleEvents)
            {
                GoogleEventProperties eventProperties = await GoogleEventPropertiesGenerator.GenerateAsync(googleEvent.ExtendedProperties.Private);
                TeamsEvent teamsEvent = await TeamsEventFinder.FindAsync(teamsEvents, eventProperties.TeamsId);

                if (teamsEvent != null)
                {
                    if (await IsActiveValidator.ValidateAsync(teamsEvent))
                    {
                        continue;
                    }
                }
                
                await GoogleApi.DeleteAsync(googleCalendar.Id, googleEvent.Id, accessToken);
            }
        }
    }
}