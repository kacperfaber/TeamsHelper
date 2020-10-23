using System;
using System.Threading.Tasks;
using TeamsHelper.CalendarApi;

namespace TeamsHelper.WebApp
{
    public class UpdateEventPayloadGenerator : IUpdateEventPayloadGenerator
    {
        public IGoogleTimeGenerator TimeGenerator;

        public UpdateEventPayloadGenerator(IGoogleTimeGenerator timeGenerator)
        {
            TimeGenerator = timeGenerator;
        }

        public Task<UpdateEventPayload> GenerateAsync(GoogleEvent googleEvent)
        {
            return Task.Run(() => new UpdateEventPayload
            {
                Description = googleEvent.Description, 
                Start = TimeGenerator.Generate((DateTime)googleEvent.Start.DateTime),
                End = TimeGenerator.Generate((DateTime)googleEvent.End.DateTime),
                Id = googleEvent.Id,
                Summary = googleEvent.Summary,
                ExtendedProperties = googleEvent.ExtendedProperties
            });
        }
    }
}