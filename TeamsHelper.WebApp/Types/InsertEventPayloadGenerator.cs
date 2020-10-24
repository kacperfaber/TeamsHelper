using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;
using TeamsHelper.TeamsApi;

namespace TeamsHelper.WebApp
{
    public class InsertEventPayloadGenerator : IInsertEventPayloadGenerator
    {
        public IGoogleTimeGenerator GoogleTimeGenerator;

        public InsertEventPayloadGenerator(IGoogleTimeGenerator googleTimeGenerator)
        {
            GoogleTimeGenerator = googleTimeGenerator;
        }

        public Task<InsertEventPayload> GenerateAsync(TeamsEvent teamsEvent)
        {
            return Task.Run(() => new InsertEventPayload
            {
                ExtendedProperties = new ExtendedProperties
                {
                    Private = new Dictionary<string, string> {{"teamsId", teamsEvent.Id}}
                },
                Description = $"Grupa: \"{teamsEvent.TeamsOrganizer.EmailAddress.Name}\"",
                Summary = teamsEvent.Subject,
                End = GoogleTimeGenerator.Generate(teamsEvent.End.DateTime),
                Start = GoogleTimeGenerator.Generate(teamsEvent.Start.DateTime)
            });
        }
    }
}