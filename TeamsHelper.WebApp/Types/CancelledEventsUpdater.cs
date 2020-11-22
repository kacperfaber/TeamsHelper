using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class CancelledEventsUpdater : ICancelledEventsUpdater
    {
        public ITeamsEventIsCanceledChecker IsCanceledChecker;
        public IGoogleEventFinder GoogleEventFinder;
        public GoogleApi GoogleApi;
        public IUpdateCanceledEventPayloadGenerator UpdateCanceledEventPayloadGenerator;

        public CancelledEventsUpdater(IUpdateCanceledEventPayloadGenerator updateCanceledEventPayloadGenerator, GoogleApi googleApi,
            IGoogleEventFinder googleEventFinder, ITeamsEventIsCanceledChecker isCanceledChecker)
        {
            UpdateCanceledEventPayloadGenerator = updateCanceledEventPayloadGenerator;
            GoogleApi = googleApi;
            GoogleEventFinder = googleEventFinder;
            IsCanceledChecker = isCanceledChecker;
        }

        public async Task<List<CanceledEvent>> UpdateAsync(IEnumerable<TeamsEvent> teamsEvents, GoogleCalendar googleCalendar,
            List<GoogleEvent> googleEvents, GoogleConfiguration configuration, string googleToken)
        {
            List<CanceledEvent> canceledEvents = new List<CanceledEvent>();

            foreach (TeamsEvent teamsEvent in teamsEvents)
            {
                if (IsCanceledChecker.Check(teamsEvent))
                {
                    GoogleEvent googleEvent = await GoogleEventFinder.FindAsync(googleEvents, teamsEvent.Id);

                    if (configuration.DeleteCanceled)
                    {
                        await GoogleApi.DeleteAsync(googleCalendar.Id, googleEvent.Id, googleToken);
                    }

                    else
                    {
                        UpdateEventPayload payload = UpdateCanceledEventPayloadGenerator.Generate(googleEvent, teamsEvent, configuration);
                        await GoogleApi.UpdateAsync(payload, googleCalendar.Id, googleEvent.Id, googleToken);
                    }

                    canceledEvents.Add(new CanceledEvent
                    {
                        EndingAt = googleEvent.End.DateTime,
                        StartingAt = googleEvent.Start.DateTime,
                        GoogleId = googleEvent.Id,
                        GoogleDescription = googleEvent.Description,
                        GoogleSummary = googleEvent.Summary,
                        TeamsId = teamsEvent.Id,
                        TeamsOrganizerEmailAddress = teamsEvent.TeamsOrganizer.EmailAddress.Address
                    });
                }
            }

            return canceledEvents;
        }
    }
}